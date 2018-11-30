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

namespace RandomApplications.Services
{
    public class ApplicationService : IApplicationService
    {
        private static readonly string defaultConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        DataContext db = new DataContext(defaultConnection);
        //SqlConnection con = new SqlConnection(defaultConnection);

        public async Task<List<BaseApplication>> GetAllApps()
        {
            var con = new SqlConnection(defaultConnection);
            try
            {
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM BaseApplication";
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                //var apps = new List<BaseApplication>();

                var apps = (from DataRow row in dt.Rows

                    select new BaseApplication
                    {
                        Id = (long)row["Id"],
                        Title = row["Title"].ToString(),
                        Description = row["Description"].ToString(),
                        StatusId = (int)row["StatusId"]

                    }).ToList();

                /*foreach (var item in dt.Rows)
                {
                    apps.Add(new BaseApplication
                    {
                        Id = item[0],
                    });
                }*/
                con.Close();

                return apps;
            }
            catch (Exception ex)
            {
                return new List<BaseApplication>();
            }
        }

        public async Task<BaseApplication> GetDetailApp(long id)
        {
            var con = new SqlConnection(defaultConnection);
            try
            {
                con.Open();
                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = $"SELECT * FROM BaseApplication WHERE id = {id}";
                cmd.ExecuteNonQuery();
                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                //var apps = new List<BaseApplication>();

                var app = (from DataRow row in dt.Rows

                    select new BaseApplication
                    {
                        Id = (long)row["Id"],
                        Title = row["Title"].ToString(),
                        Description = row["Description"].ToString(),
                        StatusId = (int)row["StatusId"]

                    }).FirstOrDefault();

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
            var con = new SqlConnection(defaultConnection);
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
                    DateModify = now
                };

                apps.InsertOnSubmit(app);
                db.SubmitChanges();

                var histories = db.GetTable<BaseHistory>();
                var history = new BaseHistory
                {
                    AppId = app.Id,
                    DateModify = DateTime.UtcNow,
                    StatusOld = null,
                    StatusNew = app.Status,
                    Comment = null
                };

                histories.InsertOnSubmit(history);
                
                db.SubmitChanges();

                app.HistoryIds.Add(history.Id);
                db.SubmitChanges();

                con.Close();
            }
            catch (Exception ex)
            {

            }
        }
    }

    public interface IApplicationService
    {
        Task<List<BaseApplication>> GetAllApps();

        Task<BaseApplication> GetDetailApp(long id);

        Task CreateApp(string title, string description);
    }
}

