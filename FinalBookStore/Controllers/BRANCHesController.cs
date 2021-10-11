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
    public class BRANCHesController : Controller
    {
        private HENRY_ASPNETEntities db = new HENRY_ASPNETEntities();

        // GET: BRANCHes
        public ActionResult Index()
        {
            return View(db.BRANCHes.ToList());
        }

        // GET: BRANCHes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BRANCH bRANCH = db.BRANCHes.Find(id);
            if (bRANCH == null)
            {
                return HttpNotFound();
            }
            return View(bRANCH);
        }

        // GET: BRANCHes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BRANCHes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BRANCH_NUM,BRANCH_NAME,BRANCH_LOCATION,NUM_EMPLOYEES")] BRANCH bRANCH)
        {
            if (ModelState.IsValid)
            {
                db.BRANCHes.Add(bRANCH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bRANCH);
        }

        // GET: BRANCHes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BRANCH bRANCH = db.BRANCHes.Find(id);
            if (bRANCH == null)
            {
                return HttpNotFound();
            }
            return View(bRANCH);
        }

        // POST: BRANCHes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BRANCH_NUM,BRANCH_NAME,BRANCH_LOCATION,NUM_EMPLOYEES")] BRANCH bRANCH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bRANCH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bRANCH);
        }

        // GET: BRANCHes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BRANCH bRANCH = db.BRANCHes.Find(id);
            if (bRANCH == null)
            {
                return HttpNotFound();
            }
            return View(bRANCH);
        }

        // POST: BRANCHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BRANCH bRANCH = db.BRANCHes.Find(id);
            db.BRANCHes.Remove(bRANCH);
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
