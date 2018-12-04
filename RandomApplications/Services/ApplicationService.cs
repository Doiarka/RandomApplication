using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using RandomApplications.Models;
using System.IO;
using Newtonsoft.Json;
using RandomApplications.Request;
using RandomApplications.Response;
using RandomApplications.Utils;

namespace RandomApplications.Services
{
    public class ApplicationService : IApplicationService
    {
        private BaseContext db = new BaseContext();

        public async Task<ApplicationsListViewModel> GetAllApps(ApplicationsListViewModel model)
        {
            var apps = db.BaseApplications.ToList();
            if (model.Status != Status.All)
                apps = apps.Where(x => x.Status == model.Status).ToList();
            if (model.DateFrom != null)
                apps = apps.Where(x => x.DateModify >= model.DateFrom).ToList();
            if (model.DateTo != null)
                apps = apps.Where(x => x.DateModify <= model.DateTo.Value.AddDays(1)).ToList();
                
            model.Apps = apps.OrderByDescending(x => x.DateModify).ToList();
            
            return model;
        }

        public async Task CreateApp(CreateApplicationRequest request)
        {
            try
            {
                var now = DateTime.UtcNow;
                var app = new BaseApplication
                {
                    Title = request.Title,
                    Description = request.Description,
                    Status = Status.Open,
                    DateModify = now,
                    HistoryIds = new List<long>().SerializeToJson()
                };
                db.BaseApplications.Add(app);
                db.SaveChanges();

                var histories = db.BaseHistories;
                var history = new BaseHistory
                {
                    AppId = app.Id,
                    DateModify = now,
                    StatusOld = null,
                    StatusNew = app.Status,
                    Comment = null
                };
                db.BaseHistories.Add(history);
                db.SaveChanges();

                var appHistory = new JsonSerializer().Deserialize<List<long>>
                (new JsonTextReader
                    (new StringReader(app.HistoryIds)));
                appHistory.Add(history.Id);
                app.HistoryIds = appHistory.SerializeToJson();
                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<EditApplicationRequest> GetDetailApp(EditApplicationRequest request)
        {
            var app = db.BaseApplications.FirstOrDefault(x => x.Id == request.Id);
            request.Title = app.Title;
            request.Description = app.Description;
            request.StatusOld = app.Status;
            request.Histories = db.BaseHistories.Where(x => x.AppId == request.Id).OrderByDescending(o => o.DateModify).ToList();
            return request;
        }

        public async Task EditApp(EditApplicationRequest request)
        {
            try
            {
                if (request.Comment == null)
                    return;

                var now = DateTime.UtcNow;

                var app = db.BaseApplications.FirstOrDefault(x => x.Id == request.Id);
                var appStatusOld = app.Status;
                app.Status = request.StatusNew;
                app.DateModify = now;
                db.SaveChanges();

                var history = new BaseHistory
                {
                    AppId = app.Id,
                    DateModify = now,
                    StatusOld = appStatusOld,
                    StatusNew = app.Status,
                    Comment = request.Comment
                };
                db.BaseHistories.Add(history);
                db.SaveChanges();

                var appHistory = new JsonSerializer().Deserialize<List<long>>
                (new JsonTextReader
                    (new StringReader(app.HistoryIds)));
                appHistory.Add(history.Id);
                app.HistoryIds = appHistory.SerializeToJson();
                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }
        }
    }

    public interface IApplicationService
    {
        Task<ApplicationsListViewModel> GetAllApps(ApplicationsListViewModel model);
        
        Task CreateApp(CreateApplicationRequest request);

        Task<EditApplicationRequest> GetDetailApp(EditApplicationRequest request);
    }
}

