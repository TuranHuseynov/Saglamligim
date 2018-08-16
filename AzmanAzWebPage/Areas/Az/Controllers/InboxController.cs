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
    public class InboxController : Controller
    {
        private DB_A3E145_SaglamligimEntities db = new DB_A3E145_SaglamligimEntities();

        // GET: Az/Inbox
        public ActionResult Index()
        {
            return View(db.Elaqes.ToList());
        }

        // GET: Az/Inbox/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elaqe elaqe = db.Elaqes.Find(id);
            if (elaqe == null)
            {
                return HttpNotFound();
            }
            return View(elaqe);
        }

        // GET: Az/Inbox/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Az/Inbox/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "elaqe_id,elaqe_ad,elaqe_soyad,elaqe_telefon,elaqe_mesaji")] Elaqe elaqe)
        {
            if (ModelState.IsValid)
            {
                db.Elaqes.Add(elaqe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(elaqe);
        }

        // GET: Az/Inbox/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elaqe elaqe = db.Elaqes.Find(id);
            if (elaqe == null)
            {
                return HttpNotFound();
            }
            return View(elaqe);
        }

        // POST: Az/Inbox/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "elaqe_id,elaqe_ad,elaqe_soyad,elaqe_telefon,elaqe_mesaji")] Elaqe elaqe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(elaqe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(elaqe);
        }

        // GET: Az/Inbox/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Elaqe elaqe = db.Elaqes.Find(id);
            if (elaqe == null)
            {
                return HttpNotFound();
            }
            return View(elaqe);
        }

        // POST: Az/Inbox/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Elaqe elaqe = db.Elaqes.Find(id);
            db.Elaqes.Remove(elaqe);
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
