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
    public class ServisController : Controller
    {
        private DB_A3E145_SaglamligimEntities db = new DB_A3E145_SaglamligimEntities();

        // GET: Az/Servis
        public ActionResult Index()
        {
            return View(db.Servis.ToList());
        }

        // GET: Az/Servis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servi servi = db.Servis.Find(id);
            if (servi == null)
            {
                return HttpNotFound();
            }
            return View(servi);
        }

        // GET: Az/Servis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Az/Servis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "servis_id,servis_adi,servis_content,servis_icon")] Servi servi)
        {
            if (ModelState.IsValid)
            {
                db.Servis.Add(servi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servi);
        }

        // GET: Az/Servis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servi servi = db.Servis.Find(id);
            if (servi == null)
            {
                return HttpNotFound();
            }
            return View(servi);
        }

        // POST: Az/Servis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "servis_id,servis_adi,servis_content,servis_icon")] Servi servi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servi);
        }

        // GET: Az/Servis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servi servi = db.Servis.Find(id);
            if (servi == null)
            {
                return HttpNotFound();
            }
            return View(servi);
        }

        // POST: Az/Servis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servi servi = db.Servis.Find(id);
            db.Servis.Remove(servi);
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
