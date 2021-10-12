using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using FinalBookStore;
using FinalBookStore.Models.EntityFramework;

namespace FinalBookStore.Controllers
{
    public class AUTHORsController : Controller
    {
        private HENRY_ASPNETEntities db = new HENRY_ASPNETEntities();

        // GET: AUTHORs
        public ActionResult Index()
        {
            ViewBag.Authors = db.AUTHORs.ToList();
            return View(db.AUTHORs.ToList());
        }

        // GET: AUTHORs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AUTHOR aUTHOR = db.AUTHORs.Find(id);
            if (aUTHOR == null)
            {
                return HttpNotFound();
            }

            var wrotes = db.WROTEs.Where(x => x.AUTHOR_NUM == aUTHOR.AUTHOR_NUM);
            aUTHOR.WROTEs = wrotes.ToList();
            if (aUTHOR.WROTEs.Count > 1)
            {
                aUTHOR.BOOKs =
                    db.BOOKs.Where(x => wrotes.Any(y => x.BOOK_CODE == y.BOOK_CODE)).ToList();
                // get books by wrotes
            }

            else
            {
                WROTE wrote = aUTHOR.WROTEs.First();
                //aUTHOR.BOOKs = db.BOOKs.FirstOrDefault(x => x.BOOK_CODE == wrote.BOOK_CODE);
            }

            return View(aUTHOR);
        }

        // GET: AUTHORs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AUTHORs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AUTHOR_NUM,AUTHOR_LAST,AUTHOR_FIRST")] AUTHOR aUTHOR)
        {
            if (ModelState.IsValid)
            {
                db.AUTHORs.Add(aUTHOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aUTHOR);
        }

        // GET: AUTHORs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AUTHOR aUTHOR = db.AUTHORs.Find(id);
            if (aUTHOR == null)
            {
                return HttpNotFound();
            }
            return View(aUTHOR);
        }

        // POST: AUTHORs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AUTHOR_NUM,AUTHOR_LAST,AUTHOR_FIRST")] AUTHOR aUTHOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aUTHOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aUTHOR);
        }

        // GET: AUTHORs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AUTHOR aUTHOR = db.AUTHORs.Find(id);
            if (aUTHOR == null)
            {
                return HttpNotFound();
            }
            return View(aUTHOR);
        }

        // POST: AUTHORs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AUTHOR aUTHOR = db.AUTHORs.Find(id);
            db.AUTHORs.Remove(aUTHOR);
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
