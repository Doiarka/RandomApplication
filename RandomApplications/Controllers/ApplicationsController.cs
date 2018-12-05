using System;
using System.Web.Mvc;
using RandomApplications.Models;
using RandomApplications.Services;
using RandomApplications.Response;
using RandomApplications.Request;

namespace RandomApplications.Controllers
{
    /// <summary>
    /// контроллер заявок
    /// </summary>
    public class ApplicationsController : Controller
    {
        ApplicationService appServ = new ApplicationService();

        /// <summary>
        /// получить список заявок
        /// URL: Applications/List
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult List(ApplicationsResponse model)
        {
            model = appServ.GetAllApps(model).GetAwaiter().GetResult();
            return View(model);
        }

        /// <summary>
        /// представление создания заявки
        /// URL: Applications/Create
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// создать заявку
        /// URL: Applications/Create
        /// </summary>
        /// <param name="request"></param>
        /// <returns>возврат на страницу списка заявок</returns>
        [HttpPost]
        public ActionResult Create(CreateApplicationRequest request)
        {
            try
            {
                appServ.CreateApp(request).GetAwaiter().GetResult();

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// представление просмотра заявки и изменения ее статуса
        /// URL: Applications/Edit/{long:Id}
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(EditApplicationRequest request)
        {
            try
            {
                request = appServ.GetDetailApp(request).GetAwaiter().GetResult();
            }
            catch
            {
                return RedirectToAction("List");
            }
            
            return View(request);
        }

        /// <summary>
        /// изменить статус заявки
        /// URL: Applications/Edit/{long:Id}
        /// </summary>
        /// <param name="request"></param>
        /// <param name="answer">название действия над заявкой</param>
        /// <returns>возврат на страницу списка заявок</returns>
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
                    request.StatusNew = status;
                    appServ.EditApp(request).GetAwaiter().GetResult();
                }

                return RedirectToAction("List");
            }
            catch
            {
                return View(request);
            }
        }
    }
}
