using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalBookStore.Models.EntityFramework;

namespace FinalBookStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Jsonresult version controller for contact page
        [HttpPost]
        public JsonResult Contact(Validation model)
        {
            ViewBag.Message = "Your contact page.";

            return Json(model);
        }
    }
}