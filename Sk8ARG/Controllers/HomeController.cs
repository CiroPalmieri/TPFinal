
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sk8ARG.Models;
namespace Sk8ARG.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SkateParks a = new SkateParks();
            a = BD.TraerDestSKP();
            ViewBag.Dou = a;
            ViewBag.FotoUbi = a.Ubic + ".jpg";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}