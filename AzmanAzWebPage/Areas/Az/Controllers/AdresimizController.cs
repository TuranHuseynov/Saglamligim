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
    public class AdresimizController : Controller
    {
        private DB_A3E145_SaglamligimEntities db = new DB_A3E145_SaglamligimEntities();

        // GET: Az/Adresimiz
        public ActionResult Index()
        {
            return View(db.Adresims.ToList());
        }

        // GET: Az/Adresimiz/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresim adresim = db.Adresims.Find(id);
            if (adresim == null)
            {
                return HttpNotFound();
            }
            return View(adresim);
        }

        // GET: Az/Adresimiz/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Az/Adresimiz/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "adres_id,adres_telefon,adres_gmail,adres_facebook,adres_instagram,adres_youtube,adres_about_text")] Adresim adresim)
        {
            if (ModelState.IsValid)
            {
                db.Adresims.Add(adresim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adresim);
        }

        // GET: Az/Adresimiz/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresim adresim = db.Adresims.Find(id);
            if (adresim == null)
            {
                return HttpNotFound();
            }
            return View(adresim);
        }

        // POST: Az/Adresimiz/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "adres_id,adres_telefon,adres_gmail,adres_facebook,adres_instagram,adres_youtube,adres_about_text")] Adresim adresim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adresim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adresim);
        }

        // GET: Az/Adresimiz/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresim adresim = db.Adresims.Find(id);
            if (adresim == null)
            {
                return HttpNotFound();
            }
            return View(adresim);
        }

        // POST: Az/Adresimiz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adresim adresim = db.Adresims.Find(id);
            db.Adresims.Remove(adresim);
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
