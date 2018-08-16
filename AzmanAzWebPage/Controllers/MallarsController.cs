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
    public class MallarsController : Controller
    {
        private DB_A3E145_SaglamligimEntities db = new DB_A3E145_SaglamligimEntities();

        // GET: Mallars
        public ActionResult Index()
        {
            var mallars = db.Mallars.Include(m => m.Kategoriya);
            return View(mallars.ToList());
        }

        // GET: Mallars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mallar mallar = db.Mallars.Find(id);
            if (mallar == null)
            {
                return HttpNotFound();
            }
            return View(mallar);
        }

        // GET: Mallars/Create
        public ActionResult Create()
        {
            ViewBag.mal_kateqoriyasi = new SelectList(db.Kategoriyas, "kategorya_id", "kategorya_adi");
            return View();
        }

        // POST: Mallars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Mallar mallar, HttpPostedFileBase mal_resmi)
        {
            if (ModelState.IsValid)
            {
                var file_name = Path.GetFileName(mal_resmi.FileName);
                var src = Path.Combine(Server.MapPath("~/Yuklenen"), file_name);
                mal_resmi.SaveAs(src);

                mallar.mal_resmi = Path.GetFileName(mal_resmi.FileName);
                db.Mallars.Add(mallar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.mal_kateqoriyasi = new SelectList(db.Kategoriyas, "kategorya_id", "kategorya_adi", mallar.mal_kateqoriyasi);
            return View(mallar);
        }

        // GET: Mallars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mallar mallar = db.Mallars.Find(id);
            if (mallar == null)
            {
                return HttpNotFound();
            }
            ViewBag.mal_kateqoriyasi = new SelectList(db.Kategoriyas, "kategorya_id", "kategorya_adi", mallar.mal_kateqoriyasi);
            return View(mallar);
        }

        // POST: Mallars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mal_id,mal_adi,mal_qiymeti,mal_youtube_link,mal_web_link,mal_info,mal_bawliq,mal_kateqoriyasi,mal_resmi")] Mallar mallar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mallar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.mal_kateqoriyasi = new SelectList(db.Kategoriyas, "kategorya_id", "kategorya_adi", mallar.mal_kateqoriyasi);
            return View(mallar);
        }

        // GET: Mallars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mallar mallar = db.Mallars.Find(id);
            if (mallar == null)
            {
                return HttpNotFound();
            }
            return View(mallar);
        }

        // POST: Mallars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mallar mallar = db.Mallars.Find(id);
            db.Mallars.Remove(mallar);
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
