using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalBookStore;
using FinalBookStore.Models.EntityFramework;

namespace FinalBookStore.Controllers
{
    public class PUBLISHERsController : Controller
    {
        private HENRY_ASPNETEntities db = new HENRY_ASPNETEntities();

        // GET: PUBLISHERs
        public ActionResult Index()
        {
            var publishers = db.PUBLISHERs.ToList();
            ViewBag.ModelList = db.PUBLISHERs.ToList();
            List<SelectListItem> pubList = new List<SelectListItem>();
            pubList.Add(new SelectListItem() { Text = "Select Publisher", Value = "" });
            foreach (PUBLISHER publisher in publishers)
            {
                pubList.Add(new SelectListItem() { Text = publisher.PUBLISHER_NAME, Value = publisher.PUBLISHER_CODE });
            }

            ViewBag.Publishers = pubList;

            return View(db.PUBLISHERs.ToList());

        }

        [HttpPost]
        public ActionResult Index(string id)
        {
            ViewBag.ModelList = db.PUBLISHERs.ToList();
            if (id == "")
            {
                ViewBag.message = "Please Make a Selection";
            }
            if (id != "")
            {
                ViewBag.message = "";
                var publisher = db.PUBLISHERs.Find(id);
                List<PUBLISHER> publisherList = new List<PUBLISHER>();
                publisherList.Add(publisher);
                return View(publisherList);
            }
            return View(db.PUBLISHERs.ToList());
        }

        // GET: PUBLISHERs/Details/5
        public ActionResult Details(PUBLISHER pub)
        {
            if (pub == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUBLISHER pUBLISHER = db.PUBLISHERs.Find(pub);
            return View(pUBLISHER);
        }

        // GET: PUBLISHERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PUBLISHERs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PUBLISHER_CODE,PUBLISHER_NAME,CITY")] PUBLISHER pUBLISHER)
        {
            if (ModelState.IsValid)
            {
                db.PUBLISHERs.Add(pUBLISHER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pUBLISHER);
        }

        // GET: PUBLISHERs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUBLISHER pUBLISHER = db.PUBLISHERs.Find(id);
            if (pUBLISHER == null)
            {
                return HttpNotFound();
            }
            return View(pUBLISHER);
        }

        // POST: PUBLISHERs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PUBLISHER_CODE,PUBLISHER_NAME,CITY")] PUBLISHER pUBLISHER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pUBLISHER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pUBLISHER);
        }

        // GET: PUBLISHERs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PUBLISHER pUBLISHER = db.PUBLISHERs.Find(id);
            if (pUBLISHER == null)
            {
                return HttpNotFound();
            }
            return View(pUBLISHER);
        }

        // POST: PUBLISHERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PUBLISHER pUBLISHER = db.PUBLISHERs.Find(id);
            db.PUBLISHERs.Remove(pUBLISHER);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
