using AzmanAzWebPage.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AzmanAzWebPage.Areas.Az.Controllers
{
    [UserFilterController]
    public class AnaSəhifəController : Controller
    {
        // GET: Az/AnaSəhifə
        public ActionResult Index()
        {
            return View();
        }
    }
}