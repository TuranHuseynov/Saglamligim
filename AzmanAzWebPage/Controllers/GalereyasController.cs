using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AzmanAzWebPage.Models;

namespace AzmanAzWebPage.Controllers
{
    [UserFilterController]
    public class GalereyasController : Controller
    {
        private DB_A3E145_SaglamligimEntities db = new DB_A3E145_SaglamligimEntities();

        // GET: Galereyas
        public ActionResult Index()
        {
            return View(db.Galereyas.ToList());
        }

        // GET: Galereyas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Galereya galereya = db.Galereyas.Find(id);
            if (galereya == null)
            {
                return HttpNotFound();
            }
            return View(galereya);
        }

        // GET: Galereyas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Galereyas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Galereya galereya, HttpPostedFileBase galery_image)
        {
            if (ModelState.IsValid)
            {
                var file_name = Path.GetFileName(galery_image.FileName);
                var src = Path.Combine(Server.MapPath("~/Yuklenen"), file_name);
                galery_image.SaveAs(src);

                galereya.galery_image = Path.GetFileName(galery_image.FileName);
                db.Galereyas.Add(galereya);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(galereya);
        }

        // GET: Galereyas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Galereya galereya = db.Galereyas.Find(id);
            if (galereya == null)
            {
                return HttpNotFound();
            }
            return View(galereya);
        }

        // POST: Galereyas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "galery_id,galery_header,galery_text,galery_image")] Galereya galereya)
        {
            if (ModelState.IsValid)
            {
                db.Entry(galereya).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(galereya);
        }

        // GET: Galereyas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Galereya galereya = db.Galereyas.Find(id);
            if (galereya == null)
            {
                return HttpNotFound();
            }
            return View(galereya);
        }

        // POST: Galereyas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Galereya galereya = db.Galereyas.Find(id);
            db.Galereyas.Remove(galereya);
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
