using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sk8ARG.Models;

namespace Sk8ARG.Controllers
{
    public class BackOfficeController : Controller
    {
        // GET: BackOffice
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ABMS(int a)
        {
            List<SkateParks> skateParks = new List<SkateParks>();
            //List<Ropa> Ropa = new List<Ropa>();
            //List<Hardware> Hardware = new List<Hardware>();
            switch (a)
            {
                case 1:
                    {
                        skateParks = BD.ListarSkateParks();
                        ViewBag.LSkp = skateParks;
                        break;
                    }
                case 2:
                    {

                        break;
                    }
                case 3:
                    {

                        break;
                    }
            }

            return View();
        }
        public ActionResult ABM()
        {

            return View();
        }
        public ActionResult mb()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Usuarios us)
        {
            BD.Existe(us);
            bool dou = BD.Existe(us);
            if (!dou)
            {
                @ViewBag.Mensaje = " El mail o contraseña son incorrectos";
                return View("Index", us);
            }
            else
            {
                List<SkateParks> Dou = new List<SkateParks>();
                SkateParks miskp = new SkateParks();

                Dou = BD.ListarSkateParks();
                ViewBag.Dou = Dou;
                return View("ABM");
            }
        }
    }

}