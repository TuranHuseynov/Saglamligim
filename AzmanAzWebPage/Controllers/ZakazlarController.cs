using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AzmanAzWebPage.Models;

namespace AzmanAzWebPage.Controllers
{
    [UserFilterController]
    public class ZakazlarController : Controller
    {
        private DB_A3E145_SaglamligimEntities db = new DB_A3E145_SaglamligimEntities();

        // GET: Zakazlar
        public ActionResult Index()
        {
            return View(db.Zakazims.ToList());
        }

        // GET: Zakazlar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zakazim zakazim = db.Zakazims.Find(id);
            if (zakazim == null)
            {
                return HttpNotFound();
            }
            return View(zakazim);
        }

        // GET: Zakazlar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zakazlar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "zakazim_id,zakazim_adi_soyad,zakazim_telefon,zakazim_mehsul,zakaz_vaxti")] Zakazim zakazim)
        {
            if (ModelState.IsValid)
            {
                db.Zakazims.Add(zakazim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zakazim);
        }

        // GET: Zakazlar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zakazim zakazim = db.Zakazims.Find(id);
            if (zakazim == null)
            {
                return HttpNotFound();
            }
            return View(zakazim);
        }

        // POST: Zakazlar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "zakazim_id,zakazim_adi_soyad,zakazim_telefon,zakazim_mehsul,zakaz_vaxti")] Zakazim zakazim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zakazim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zakazim);
        }

        // GET: Zakazlar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zakazim zakazim = db.Zakazims.Find(id);
            if (zakazim == null)
            {
                return HttpNotFound();
            }
            return View(zakazim);
        }

        // POST: Zakazlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zakazim zakazim = db.Zakazims.Find(id);
            db.Zakazims.Remove(zakazim);
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
