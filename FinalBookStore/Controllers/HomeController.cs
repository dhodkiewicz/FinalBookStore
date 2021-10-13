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
        private HENRY_ASPNETEntities db = new HENRY_ASPNETEntities();
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

            var branches = db.BRANCHes.ToList();
            ViewBag.branches = branches;
            return View();
        }

        //Jsonresult version controller for contact page
        [HttpPost]
        public JsonResult Contact(Validation model)
        {
            //get data from inbound model
            if (String.IsNullOrEmpty(model.Fname))
            {
                ModelState.AddModelError("First Name", "Please Enter First Name");
            }
            if (String.IsNullOrEmpty(model.Lname))
            {
                ModelState.AddModelError("Last Name", "Please Enter Last Name");
            }
            return Json(model);
        }
    }
}

