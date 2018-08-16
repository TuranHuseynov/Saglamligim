using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzmanAzWebPage.Areas.Az.Controllers
{
    public class LoginAdminController : Controller
    {
        // GET: Az/LoginAdmin
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult LogIn()
        {

            return View();
        }





        [HttpPost]
        public ActionResult LogIn(FormCollection frm)
        {
            Session["User_name"] = frm["User_name"];
            Session["User_Password"] = frm["User_password"];
            if (Session["User_Name"].ToString() == "admin")
            {
                if (Session["User_Password"].ToString() == "123456")
                {
                    return RedirectToAction("Index", "AnaSəhifə");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");

            }
        }

        public ActionResult LogOut()
        {


            Session.Abandon();
            return RedirectToAction("LogIn");



        }















    }
}