using AzmanAzWebPage.Models;
using AzmanAzWebPage.Viewmodel;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AzmanAzWebPage.Controllers
{
    public class HomeController : Controller
    {
        DB_A3E145_SaglamligimEntities db = new DB_A3E145_SaglamligimEntities();
        MyModel vm = new MyModel();

        public ActionResult Index()
        {
            vm._adresim = db.Adresims.ToList();
            vm._slayder = db.Slayders.ToList();
            vm._slayder = db.Slayders.ToList();
            vm._mallar = db.Mallars.ToList();
            vm._endirim = db.Endirims.Take(3).ToList();
            vm._servis = db.Servis.Take(3).ToList();
            vm._karusel = db.Karusels.Take(9).ToList();
            
            
            return View(vm);
        }


        [HttpPost]
        public ActionResult Contact(FormCollection frm)
        {
            vm._endirim = db.Endirims.Take(3).ToList();
            vm._servis = db.Servis.Take(3).ToList();
            vm._karusel = db.Karusels.Take(9).ToList();
            vm._mallar = db.Mallars.ToList();
            vm._adresim = db.Adresims.ToList();
            Elaqe elaqemiz = new Elaqe();
            elaqemiz.elaqe_ad = frm["elaqe_ad"];
            elaqemiz.elaqe_soyad = frm["elaqe_soyad"];
            elaqemiz.elaqe_telefon = frm["elaqe_telefon"];
            elaqemiz.elaqe_mesaji = frm["elaqe_mesaji"];

            db.Elaqes.Add(elaqemiz);
            db.SaveChanges();

            return View("Index",vm);


        }

        public ActionResult Blog(int id)
        {
            vm._mallar = db.Mallars.Where(m => m.mal_id == id).ToList();
            vm._adresim = db.Adresims.ToList();

            return View(vm);

        }

        [HttpPost]
        public ActionResult BlogForm(FormCollection frm)
        {
         
            Zakazim zkz = new Zakazim();
            zkz.zakazim_adi_soyad = frm["zakazim_adi_soyad"];
            zkz.zakazim_telefon = frm["zakazim_telefon"];
            zkz.zakazim_mehsul = frm["zakazim_mehsul"];
            zkz.zakaz_vaxti = DateTime.Now;

            

            db.Zakazims.Add(zkz);
            db.SaveChanges();

            return RedirectToAction("Index");
        }



        public ActionResult EndirimBlog(int id)
        {

            vm._adresim = db.Adresims.ToList();
            vm._endirim = db.Endirims.Where(e => e.endirim_id == id).ToList();
          

            return View(vm);

        }


        public ActionResult Şirkətimiz()
        {

            vm._adresim = db.Adresims.ToList();
            return View(vm);
        }



        public ActionResult Galereya()
        {
            
            vm._galereya = db.Galereyas.Take(8).ToList();
            vm._adresim = db.Adresims.ToList();

            return View(vm);

        }





        //public ActionResult Blog(int id)
        //{
        //    vm._mehsullarim = db.Mallars.Where(d => d.mehsul_id == id).ToList();

        //    vm._about = db.Abouts.ToList();
        //    return View(vm);
        //}


       

















    }
}