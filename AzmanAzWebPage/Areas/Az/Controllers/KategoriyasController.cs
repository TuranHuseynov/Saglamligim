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
    public class KategoriyasController : Controller
    {
        private DB_A3E145_SaglamligimEntities db = new DB_A3E145_SaglamligimEntities();

        // GET: Az/Kategoriyas
        public ActionResult Index()
        {
            return View(db.Kategoriyas.ToList());
        }

        // GET: Az/Kategoriyas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoriya kategoriya = db.Kategoriyas.Find(id);
            if (kategoriya == null)
            {
                return HttpNotFound();
            }
            return View(kategoriya);
        }

        // GET: Az/Kategoriyas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Az/Kategoriyas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kategorya_id,kategorya_adi")] Kategoriya kategoriya)
        {
            if (ModelState.IsValid)
            {
                db.Kategoriyas.Add(kategoriya);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategoriya);
        }

        // GET: Az/Kategoriyas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoriya kategoriya = db.Kategoriyas.Find(id);
            if (kategoriya == null)
            {
                return HttpNotFound();
            }
            return View(kategoriya);
        }

        // POST: Az/Kategoriyas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kategorya_id,kategorya_adi")] Kategoriya kategoriya)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategoriya).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategoriya);
        }

        // GET: Az/Kategoriyas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kategoriya kategoriya = db.Kategoriyas.Find(id);
            if (kategoriya == null)
            {
                return HttpNotFound();
            }
            return View(kategoriya);
        }

        // POST: Az/Kategoriyas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kategoriya kategoriya = db.Kategoriyas.Find(id);
            db.Kategoriyas.Remove(kategoriya);
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
