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
    public class KaruselsController : Controller
    {
        private DB_A3E145_SaglamligimEntities db = new DB_A3E145_SaglamligimEntities();

        // GET: Karusels
        public ActionResult Index()
        {
            var karusels = db.Karusels.Include(k => k.Mallar);
            return View(karusels.ToList());
        }

        // GET: Karusels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Karusel karusel = db.Karusels.Find(id);
            if (karusel == null)
            {
                return HttpNotFound();
            }
            return View(karusel);
        }

        // GET: Karusels/Create
        public ActionResult Create()
        {
            ViewBag.karusel_mehsul_id = new SelectList(db.Mallars, "mal_id", "mal_adi");
            return View();
        }

        // POST: Karusels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Karusel karusel, HttpPostedFileBase karusel_image)
        {
            if (ModelState.IsValid)
            {

                var file_name = Path.GetFileName(karusel_image.FileName);
                var src = Path.Combine(Server.MapPath("~/Yuklenen"), file_name);
                karusel_image.SaveAs(src);

                karusel.karusel_image = Path.GetFileName(karusel_image.FileName);
                db.Karusels.Add(karusel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.karusel_mehsul_id = new SelectList(db.Mallars, "mal_id", "mal_adi", karusel.karusel_mehsul_id);
            return View(karusel);
        }

        // GET: Karusels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Karusel karusel = db.Karusels.Find(id);
            if (karusel == null)
            {
                return HttpNotFound();
            }
            ViewBag.karusel_mehsul_id = new SelectList(db.Mallars, "mal_id", "mal_adi", karusel.karusel_mehsul_id);
            return View(karusel);
        }

        // POST: Karusels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "karusel_id,karusel_image,karusel_mehsul_id")] Karusel karusel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(karusel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.karusel_mehsul_id = new SelectList(db.Mallars, "mal_id", "mal_adi", karusel.karusel_mehsul_id);
            return View(karusel);
        }

        // GET: Karusels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Karusel karusel = db.Karusels.Find(id);
            if (karusel == null)
            {
                return HttpNotFound();
            }
            return View(karusel);
        }

        // POST: Karusels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Karusel karusel = db.Karusels.Find(id);
            db.Karusels.Remove(karusel);
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
