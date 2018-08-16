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
    public class SlaydersController : Controller
    {
        private DB_A3E145_SaglamligimEntities db = new DB_A3E145_SaglamligimEntities();

        // GET: Slayders
        public ActionResult Index()
        {
            var slayders = db.Slayders.Include(s => s.Mallar);
            return View(slayders.ToList());
        }

        // GET: Slayders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slayder slayder = db.Slayders.Find(id);
            if (slayder == null)
            {
                return HttpNotFound();
            }
            return View(slayder);
        }

        // GET: Slayders/Create
        public ActionResult Create()
        {
            ViewBag.slider_mehsul_id = new SelectList(db.Mallars, "mal_id", "mal_adi");
            return View();
        }

        // POST: Slayders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Slayder slayder, HttpPostedFileBase slider_image)
        {
            if (ModelState.IsValid)
            {

                var file_name = Path.GetFileName(slider_image.FileName);
                var src = Path.Combine(Server.MapPath("~/Yuklenen"), file_name);
                slider_image.SaveAs(src);

                slayder.slider_image = Path.GetFileName(slider_image.FileName);

                db.Slayders.Add(slayder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.slider_mehsul_id = new SelectList(db.Mallars, "mal_id", "mal_adi", slayder.slider_mehsul_id);
            return View(slayder);
        }

        // GET: Slayders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slayder slayder = db.Slayders.Find(id);
            if (slayder == null)
            {
                return HttpNotFound();
            }
            ViewBag.slider_mehsul_id = new SelectList(db.Mallars, "mal_id", "mal_adi", slayder.slider_mehsul_id);
            return View(slayder);
        }

        // POST: Slayders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "slider_id,slider_image,slider_mehsul_id")] Slayder slayder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slayder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.slider_mehsul_id = new SelectList(db.Mallars, "mal_id", "mal_adi", slayder.slider_mehsul_id);
            return View(slayder);
        }

        // GET: Slayders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slayder slayder = db.Slayders.Find(id);
            if (slayder == null)
            {
                return HttpNotFound();
            }
            return View(slayder);
        }

        // POST: Slayders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slayder slayder = db.Slayders.Find(id);
            db.Slayders.Remove(slayder);
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
