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
    public class INVENTORiesController : Controller
    {
        private HENRY_ASPNETEntities db = new HENRY_ASPNETEntities();

        // GET: INVENTORies
        public ActionResult Index()
        {
            var iNVENTORies = db.INVENTORies.Include(i => i.BOOK).Include(i => i.BRANCH);
            return View(iNVENTORies.ToList());
        }

        // GET: INVENTORies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTORY iNVENTORY = db.INVENTORies.Find(id);
            if (iNVENTORY == null)
            {
                return HttpNotFound();
            }
            return View(iNVENTORY);
        }

        // GET: INVENTORies/Create
        public ActionResult Create()
        {
            ViewBag.BOOK_CODE = new SelectList(db.BOOKs, "BOOK_CODE", "TITLE");
            ViewBag.BRANCH_NUM = new SelectList(db.BRANCHes, "BRANCH_NUM", "BRANCH_NAME");
            return View();
        }

        // POST: INVENTORies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BOOK_CODE,BRANCH_NUM,ON_HAND")] INVENTORY iNVENTORY)
        {
            if (ModelState.IsValid)
            {
                db.INVENTORies.Add(iNVENTORY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BOOK_CODE = new SelectList(db.BOOKs, "BOOK_CODE", "TITLE", iNVENTORY.BOOK_CODE);
            ViewBag.BRANCH_NUM = new SelectList(db.BRANCHes, "BRANCH_NUM", "BRANCH_NAME", iNVENTORY.BRANCH_NUM);
            return View(iNVENTORY);
        }

        // GET: INVENTORies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTORY iNVENTORY = db.INVENTORies.Find(id);
            if (iNVENTORY == null)
            {
                return HttpNotFound();
            }
            ViewBag.BOOK_CODE = new SelectList(db.BOOKs, "BOOK_CODE", "TITLE", iNVENTORY.BOOK_CODE);
            ViewBag.BRANCH_NUM = new SelectList(db.BRANCHes, "BRANCH_NUM", "BRANCH_NAME", iNVENTORY.BRANCH_NUM);
            return View(iNVENTORY);
        }

        // POST: INVENTORies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BOOK_CODE,BRANCH_NUM,ON_HAND")] INVENTORY iNVENTORY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNVENTORY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BOOK_CODE = new SelectList(db.BOOKs, "BOOK_CODE", "TITLE", iNVENTORY.BOOK_CODE);
            ViewBag.BRANCH_NUM = new SelectList(db.BRANCHes, "BRANCH_NUM", "BRANCH_NAME", iNVENTORY.BRANCH_NUM);
            return View(iNVENTORY);
        }

        // GET: INVENTORies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTORY iNVENTORY = db.INVENTORies.Find(id);
            if (iNVENTORY == null)
            {
                return HttpNotFound();
            }
            return View(iNVENTORY);
        }

        // POST: INVENTORies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            INVENTORY iNVENTORY = db.INVENTORies.Find(id);
            db.INVENTORies.Remove(iNVENTORY);
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
