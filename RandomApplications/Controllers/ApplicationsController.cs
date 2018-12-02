using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RandomApplications.Services;
using System.Configuration;
using System.Data;
using System.Data.Entity;
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
        ApplicationService appServ = new ApplicationService();

        // GET: Applications/List
        public ActionResult List(ApplicationsListViewModel avm)
        {
            //var apps = appServ.GetAllApps().GetAwaiter().GetResult();
            //var apps = _appService.GetAllApps().GetAwaiter().GetResult();
            //var status = (Status)Convert.ToInt32(collection["Статус"]);
            //ViewBag.Apps = appServ.GetAllApps(status).GetAwaiter().GetResult();
            avm.statusList = new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem { Selected = false, Text = "Открыта", Value = ((int)Status.Open).ToString()},
                    new SelectListItem { Selected = false, Text = "Решена", Value = ((int)Status.Ready).ToString()},
                    new SelectListItem { Selected = false, Text = "Возвращена", Value = ((int)Status.Return).ToString()},
                    new SelectListItem { Selected = false, Text = "Закрыта", Value = ((int)Status.Close).ToString()},
                }, "Value", "Text");
            avm = appServ.GetAllApps(avm).GetAwaiter().GetResult();
            

            return View(avm);
        }

        // POST: Applications/List
        [HttpPost]
        public ActionResult List(ApplicationsListViewModel avm, string smth)
        {
            //var apps = appServ.GetAllApps().GetAwaiter().GetResult();
            //var apps = _appService.GetAllApps().GetAwaiter().GetResult();
            //var status = (Status)Convert.ToInt32(collection["Статус"]);
            //ViewBag.Apps = appServ.GetAllApps(status).GetAwaiter().GetResult();
            avm.statusList = new SelectList(
                new List<SelectListItem>
                {
                    new SelectListItem { Selected = false, Text = "Открыта", Value = ((int)Status.Open).ToString()},
                    new SelectListItem { Selected = false, Text = "Решена", Value = ((int)Status.Ready).ToString()},
                    new SelectListItem { Selected = false, Text = "Возвращена", Value = ((int)Status.Return).ToString()},
                    new SelectListItem { Selected = false, Text = "Закрыта", Value = ((int)Status.Close).ToString()},
                }, "Value", "Text");
            avm = appServ.GetAllApps(avm).GetAwaiter().GetResult();
            smth = "test";


            return View(avm);
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
