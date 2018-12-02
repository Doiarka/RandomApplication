using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using RandomApplications.Models;
using System.Configuration;
using System.Data.Linq;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;
using RandomApplications.Response;
using RandomApplications.Utils;

namespace RandomApplications.Services
{
    public class ApplicationService : IApplicationService
    {
        private static readonly string defaultConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        DataContext db = new DataContext(defaultConnection);
        SqlConnection con = new SqlConnection(defaultConnection);

        public async Task<ApplicationsListViewModel> GetAllApps(ApplicationsListViewModel avm)
        {
            try
            {
                con.Open();
                avm.Apps = FilterApps(avm);
                con.Close();

                return avm;
            }
            catch (Exception ex)
            {
                return avm;
            }
        }

        public IQueryable<BaseApplication> FilterApps(ApplicationsListViewModel searchModel)
        {
            var result = db.GetTable<BaseApplication>().AsQueryable();
            if (searchModel != null)
            {
                if (searchModel.statusList.SelectedValue != null)
                    result = result.Where(x => x.Status == (Status)searchModel.statusList.SelectedValue);
                if (searchModel.DateTo.HasValue)
                    result = result.Where(x => x.DateModify <= searchModel.DateTo);
                if (searchModel.DateFrom.HasValue)
                    result = result.Where(x => x.DateModify >= searchModel.DateFrom);
                /*if (searchModel.Status.HasValue)
                    result = result.Where(x => x.Status == searchModel.Status);
                if (searchModel.DateTo.HasValue)
                    result = result.Where(x => x.DateModify <= searchModel.DateTo);
                if (searchModel.DateFrom.HasValue)
                    result = result.Where(x => x.DateModify >= searchModel.DateFrom);*/
            }
            return result.OrderByDescending(x => x.DateModify);
        }

        public async Task<BaseApplication> GetDetailApp(long id)
        {
            try
            {
                con.Open();
                var apps = db.GetTable<BaseApplication>();
                var app = apps.FirstOrDefault(x => x.Id == id);
                con.Close();

                return app;
            }
            catch (Exception ex)
            {
                return new BaseApplication();
            }
        }

        public async Task CreateApp(string title, string description)
        {
            try
            {
                con.Open();
                var now = DateTime.UtcNow;
                var apps = db.GetTable<BaseApplication>();
                var app = new BaseApplication
                {
                    Title = title,
                    Description = description,
                    Status = Status.Open,
                    DateModify = now,
                    HistoryIds = new List<long>().SerializeToJson()
                };

                apps.InsertOnSubmit(app);
                db.SubmitChanges();

                var histories = db.GetTable<BaseHistory>();
                var history = new BaseHistory
                {
                    AppId = app.Id,
                    DateModify = now,
                    StatusOld = null,
                    StatusNew = app.Status,
                    Comment = null
                };

                histories.InsertOnSubmit(history);
                
                db.SubmitChanges();
                var appHistory = new JsonSerializer().Deserialize<List<long>>
                (new JsonTextReader
                    (new StringReader(app.HistoryIds)));
                appHistory.Add(history.Id);
                app.HistoryIds = appHistory.SerializeToJson();
                //app.HistoryIds = string.Join(",", history.Id.ToString());
                db.SubmitChanges();

                con.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task EditApp(long id, int statusId = 1, string comment = null)
        {
            try
            {
                if (comment == null)
                    return;

                con.Open();
                var now = DateTime.UtcNow;

                var apps = db.GetTable<BaseApplication>();
                var app = apps.FirstOrDefault(x => x.Id == id);
                var appStatusOld = app.Status;
                app.StatusId = statusId;
                /*if (app.Status == appStatusOld)
                {
                    //con.Close();
                    return;
                }*/

                app.DateModify = DateTime.UtcNow;
                db.SubmitChanges();

                var histories = db.GetTable<BaseHistory>();
                var history = new BaseHistory
                {
                    AppId = app.Id,
                    DateModify = now,
                    StatusOld = appStatusOld,
                    StatusNew = app.Status,
                    Comment = comment
                };

                histories.InsertOnSubmit(history);

                db.SubmitChanges();
                var appHistory = new JsonSerializer().Deserialize<List<long>>
                (new JsonTextReader
                    (new StringReader(app.HistoryIds)));
                appHistory.Add(history.Id);
                app.HistoryIds = appHistory.SerializeToJson();
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
        }

        public async Task<List<BaseHistory>> GetAppHistories(long id)
        {
            try
            {
                var histories = db.GetTable<BaseHistory>().Where(x => x.AppId == id);

                return histories.OrderByDescending(x => x.DateModify).ToList();
            }
            catch (Exception ex)
            {
                return new List<BaseHistory>();
            }
        }
    }

    public interface IApplicationService
    {
        Task<ApplicationsListViewModel> GetAllApps(ApplicationsListViewModel avm);

        Task<BaseApplication> GetDetailApp(long id);

        Task CreateApp(string title, string description);

        Task<List<BaseHistory>> GetAppHistories(long id);
    }
}

