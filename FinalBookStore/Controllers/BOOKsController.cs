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
    public class BOOKsController : Controller
    {
        private HENRY_ASPNETEntities db = new HENRY_ASPNETEntities();

        // GET: BOOKs
        public ActionResult Index()
        {
            var bOOKs = db.BOOKs.Include(b => b.PUBLISHER);
            return View(bOOKs.ToList());
        }

        // GET: BOOKs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOKs.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            return View(bOOK);
        }

        // GET: BOOKs/Create
        public ActionResult Create()
        {
            ViewBag.PUBLISHER_CODE = new SelectList(db.PUBLISHERs, "PUBLISHER_CODE", "PUBLISHER_NAME");
            return View();
        }

        // POST: BOOKs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BOOK_CODE,TITLE,PUBLISHER_CODE,TYPE,PRICE,PAPERBACK")] BOOK bOOK)
        {
            if (ModelState.IsValid)
            {
                db.BOOKs.Add(bOOK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PUBLISHER_CODE = new SelectList(db.PUBLISHERs, "PUBLISHER_CODE", "PUBLISHER_NAME", bOOK.PUBLISHER_CODE);
            return View(bOOK);
        }

        // GET: BOOKs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOKs.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            ViewBag.PUBLISHER_CODE = new SelectList(db.PUBLISHERs, "PUBLISHER_CODE", "PUBLISHER_NAME", bOOK.PUBLISHER_CODE);
            return View(bOOK);
        }

        // POST: BOOKs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BOOK_CODE,TITLE,PUBLISHER_CODE,TYPE,PRICE,PAPERBACK")] BOOK bOOK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bOOK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PUBLISHER_CODE = new SelectList(db.PUBLISHERs, "PUBLISHER_CODE", "PUBLISHER_NAME", bOOK.PUBLISHER_CODE);
            return View(bOOK);
        }

        // GET: BOOKs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOOK bOOK = db.BOOKs.Find(id);
            if (bOOK == null)
            {
                return HttpNotFound();
            }
            return View(bOOK);
        }

        // POST: BOOKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BOOK bOOK = db.BOOKs.Find(id);
            db.BOOKs.Remove(bOOK);
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
