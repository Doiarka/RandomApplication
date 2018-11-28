using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RandomApplications.Services;
using System.Configuration;
using System.Data;
using Autofac;

namespace RandomApplications.Controllers
{
    public class ApplicationsController : Controller
    {
        ApplicationService appServ = new ApplicationService();
        //private readonly IApplicationService _appService;
        // GET: List

        /*public ApplicationsController(IApplicationService appService)
        {
            _appService = appService;
        }*/

        public ActionResult List()
        {
            var apps = appServ.GetAllApps().GetAwaiter().GetResult();
            //var apps = _appService.GetAllApps().GetAwaiter().GetResult();

            return View(apps);
        }

        // GET: Applications/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Applications/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Applications/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
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
