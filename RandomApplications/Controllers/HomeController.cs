using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RandomApplications.Controllers
{
    /// <summary>
    /// стандартный контроллер
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// главная страница
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Title = "Главная";

            return View();
        }
    }
}
