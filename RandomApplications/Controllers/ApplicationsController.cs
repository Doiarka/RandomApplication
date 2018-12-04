using System;
using System.Web.Mvc;
using RandomApplications.Models;
using RandomApplications.Services;
using RandomApplications.Response;
using RandomApplications.Request;

namespace RandomApplications.Controllers
{
    public class ApplicationsController : Controller
    {
        ApplicationService appServ = new ApplicationService();

        // GET: Applications/List
        public ActionResult List(ApplicationsListViewModel model)
        {
            model = appServ.GetAllApps(model).GetAwaiter().GetResult();
            return View(model);
        }

        // GET: Applications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Applications/Create
        [HttpPost]
        public ActionResult Create(CreateApplicationRequest request)
        {
            try
            {
                //var title = collection[1];
                //var description = collection[2];
            
                appServ.CreateApp(request).GetAwaiter().GetResult();

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }
        
        // GET: Applications/Edit/5
        public ActionResult Edit(EditApplicationRequest request)
        {
            //var app = appServ.GetDetailApp(request.Id).GetAwaiter().GetResult();
            //ViewBag.Histories = appServ.GetAppHistories().GetAwaiter().GetResult();
            request = appServ.GetDetailApp(request).GetAwaiter().GetResult();
            return View(request);
        }
        
        // POST: Applications/Edit/5
        [HttpPost]
        public ActionResult Edit(EditApplicationRequest request, string answer)
        {
            try
            {
                if (ModelState.IsValid && !String.IsNullOrWhiteSpace(answer))
                {
                    Status status = Status.Open;
                    switch (answer)
                    {
                        case "Решена":
                            status = Status.Ready;
                            break;
                        case "Вернуть":
                            status = Status.Return;
                            break;
                        case "Закрыть":
                            status = Status.Close;
                            break;
                        default:
                            break;
                    }
                    //var statusId  = Convert.ToInt32(collection[2]);
                    request.StatusNew = status;
                    appServ.EditApp(request).GetAwaiter().GetResult();
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
    }
}
