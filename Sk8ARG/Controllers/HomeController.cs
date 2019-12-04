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
      
        public ActionResult Index(string palabra)
        {
            if (palabra == "cerrar")
            {
                Session["Login"] = null;
            }
            SkateParks a = new SkateParks();
            a = BD.TraerDestSKP();
            ViewBag.Dou = a;
            
            return View();
        }


        public ActionResult ViewSKP()
        {
          

            return View();
        }

        public ActionResult ListSKP()
        {
            List<SkateParks> lst = new List<SkateParks>();
            lst = BD.ListarSkateParks();
            ViewBag.Lista = lst;

            return View();
        }
        public ActionResult ListHW()
        {
            List<Hardware> lst = new List<Hardware>();
            lst = BD.ListarHardware();
            ViewBag.Lista = lst;
            return View();
        }
        public ActionResult ListRP()
        {
            List<Ropa> lst = new List<Ropa>();
            lst = BD.ListarRopa();
            ViewBag.Lista = lst;
           return View();
        }
        public ActionResult DetalleSKP(int IdSKP)
        {
            SkateParks a = BD.TraerSKP(IdSKP);
            ViewBag.FotoMapa = a.IdSkatePark + ".PNG";
            ViewBag.Skp = a;
            return View();
        }
        public ActionResult DetalleHW(int idHW)
        {
            Hardware a = BD.TraerHW(idHW);
            ViewBag.Hw = a;
            return View();
        }
        public ActionResult DetalleRP(int idRopa)
        {
            Ropa a = BD.TraerRopa(idRopa);
            ViewBag.Rp = a;
            return View();
        }
       
    }
}