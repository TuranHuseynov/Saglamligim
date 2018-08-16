using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AzmanAzWebPage.Controllers;
using AzmanAzWebPage.Models;

namespace AzmanAzWebPage.Areas.Az.Controllers
{
    [UserFilterController]
    public class EndirimlerController : Controller
    {
        private DB_A3E145_SaglamligimEntities db = new DB_A3E145_SaglamligimEntities();

        // GET: Az/Endirimler
        public ActionResult Index()
        {
            return View(db.Endirims.ToList());
        }

        // GET: Az/Endirimler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endirim endirim = db.Endirims.Find(id);
            if (endirim == null)
            {
                return HttpNotFound();
            }
            return View(endirim);
        }

        // GET: Az/Endirimler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Az/Endirimler/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "endirim_id,endirim_novu,edirim_faiz,endirim_detail")] Endirim endirim)
        {
            if (ModelState.IsValid)
            {
                db.Endirims.Add(endirim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(endirim);
        }

        // GET: Az/Endirimler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endirim endirim = db.Endirims.Find(id);
            if (endirim == null)
            {
                return HttpNotFound();
            }
            return View(endirim);
        }

        // POST: Az/Endirimler/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "endirim_id,endirim_novu,edirim_faiz,endirim_detail")] Endirim endirim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(endirim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(endirim);
        }

        // GET: Az/Endirimler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endirim endirim = db.Endirims.Find(id);
            if (endirim == null)
            {
                return HttpNotFound();
            }
            return View(endirim);
        }

        // POST: Az/Endirimler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Endirim endirim = db.Endirims.Find(id);
            db.Endirims.Remove(endirim);
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
