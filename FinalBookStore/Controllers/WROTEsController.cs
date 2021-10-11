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
    public class WROTEsController : Controller
    {
        private HENRY_ASPNETEntities db = new HENRY_ASPNETEntities();

        // GET: WROTEs
        public ActionResult Index()
        {
            var wROTEs = db.WROTEs.Include(w => w.AUTHOR).Include(w => w.BOOK);
            return View(wROTEs.ToList());
        }

        // GET: WROTEs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WROTE wROTE = db.WROTEs.Find(id);
            if (wROTE == null)
            {
                return HttpNotFound();
            }
            return View(wROTE);
        }

        // GET: WROTEs/Create
        public ActionResult Create()
        {
            ViewBag.AUTHOR_NUM = new SelectList(db.AUTHORs, "AUTHOR_NUM", "AUTHOR_LAST");
            ViewBag.BOOK_CODE = new SelectList(db.BOOKs, "BOOK_CODE", "TITLE");
            return View();
        }

        // POST: WROTEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BOOK_CODE,AUTHOR_NUM,SEQUENCE")] WROTE wROTE)
        {
            if (ModelState.IsValid)
            {
                db.WROTEs.Add(wROTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AUTHOR_NUM = new SelectList(db.AUTHORs, "AUTHOR_NUM", "AUTHOR_LAST", wROTE.AUTHOR_NUM);
            ViewBag.BOOK_CODE = new SelectList(db.BOOKs, "BOOK_CODE", "TITLE", wROTE.BOOK_CODE);
            return View(wROTE);
        }

        // GET: WROTEs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WROTE wROTE = db.WROTEs.Find(id);
            if (wROTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.AUTHOR_NUM = new SelectList(db.AUTHORs, "AUTHOR_NUM", "AUTHOR_LAST", wROTE.AUTHOR_NUM);
            ViewBag.BOOK_CODE = new SelectList(db.BOOKs, "BOOK_CODE", "TITLE", wROTE.BOOK_CODE);
            return View(wROTE);
        }

        // POST: WROTEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BOOK_CODE,AUTHOR_NUM,SEQUENCE")] WROTE wROTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wROTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AUTHOR_NUM = new SelectList(db.AUTHORs, "AUTHOR_NUM", "AUTHOR_LAST", wROTE.AUTHOR_NUM);
            ViewBag.BOOK_CODE = new SelectList(db.BOOKs, "BOOK_CODE", "TITLE", wROTE.BOOK_CODE);
            return View(wROTE);
        }

        // GET: WROTEs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WROTE wROTE = db.WROTEs.Find(id);
            if (wROTE == null)
            {
                return HttpNotFound();
            }
            return View(wROTE);
        }

        // POST: WROTEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            WROTE wROTE = db.WROTEs.Find(id);
            db.WROTEs.Remove(wROTE);
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
