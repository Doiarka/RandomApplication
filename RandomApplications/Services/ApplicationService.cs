using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using RandomApplications.Models;
using System.Configuration;

namespace RandomApplications.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly string defaultConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

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
    }

    public interface IApplicationService
    {
        Task<List<BaseApplication>> GetAllApps();
    }
}

