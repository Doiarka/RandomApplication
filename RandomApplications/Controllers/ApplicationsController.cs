using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RandomApplications.Services;
using System.Configuration;
using System.Data;
using System.Data.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Autofac;
using RandomApplications.Models;
using RandomApplications.Response;

namespace RandomApplications.Controllers
{
    public class ApplicationsController : Controller
    {
        //private static readonly string defaultConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //DataContext db = new DataContext(defaultConnection);
        ApplicationService appServ = new ApplicationService();
        BaseContext db = new BaseContext();

        // GET: Applications/List
        public ActionResult List(FormCollection collection)
        {
            var statusStr = collection["status"] ?? "0";
            var dateFrom = collection["dateFrom"] ?? null;
            var dateTo = collection["dateTo"] ?? null;
            var apps = db.BaseApplications.AsQueryable();
            //var apps = from s in db.GetTable<BaseApplication>() select s;
            var statusId = statusStr == "Все" ? 0 : statusStr == "" ? 0 : int.Parse(statusStr);
            if (statusId != 0)
                apps = apps.Where(x => x.StatusId == statusId);
            if (DateTime.TryParse(dateFrom, out DateTime from))
                apps = apps.Where(x => x.DateModify >= from);
            if (DateTime.TryParse(dateTo, out DateTime to))
                apps = apps.Where(x => x.DateModify <= to);

            return View(apps.ToList());
        }

        // GET: Applications/Details/5
        public ActionResult Details(int id)
        {
            var app = appServ.GetDetailApp(id).GetAwaiter().GetResult();

            return View(app);
        }

        // GET: Applications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Applications/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var title = collection[1];
                var description = collection[2];
            
                appServ.CreateApp(title, description).GetAwaiter().GetResult();

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: Applications/Edit/5
        public ActionResult Edit(long id)
        {
            var app = appServ.GetDetailApp(id).GetAwaiter().GetResult();
            ViewBag.Histories = appServ.GetAppHistories(id).GetAwaiter().GetResult();

            return View(app);
        }

        // POST: Applications/Edit/5
        [HttpPost]
        public ActionResult Edit(long id, FormCollection collection, string answer)
        {
            try
            {
                // TODO: Add update logic here
               
                if (ModelState.IsValid && !String.IsNullOrWhiteSpace(answer))
                {
                    int statusId = 2;
                    switch (answer)
                    {
                        case "Решена":
                            statusId = 2;
                            break;
                        case "Вернуть":
                            statusId = 3;
                            break;
                        case "Закрыть":
                            statusId = 4;
                            break;
                        default:
                            break;
                    }
                    var comment = collection[2];
                    //var statusId  = Convert.ToInt32(collection[2]);
                    appServ.EditApp(id, statusId, comment).GetAwaiter().GetResult();
                }
                //var title = collection[2];
                //var description = collection[3];
                

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        // GET: Applications/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Applications/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
