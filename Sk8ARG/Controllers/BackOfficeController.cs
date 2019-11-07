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
            ViewBag.Choice = a;
            switch (a)
            {
                case 1:
                    {
                        List<SkateParks> lstskp = BD.ListarSkateParks();
                        ViewBag.Lskp = lstskp;
                        return View("ABMS");
                    }
                case 2:
                    {
                        List<Ropa> lstropa = BD.ListarRopa();
                        ViewBag.Lr = lstropa;
                        return View("ABMR");
                    }
                case 3:
                    {
                        List<Hardware> lsthw = BD.ListarHardware();
                        ViewBag.Lhw = lsthw;
                        return View("ABMH");
                    }
            }
            return View();
        }
        
        public ActionResult ABM()
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
        public ActionResult ingresar(string accion)
        {
            SkateParks SKP = new SkateParks();
            ViewBag.Accion = accion;
            return View("Edición", SKP);
        }
        public ActionResult Editar(int idSKP, string accion)
        {
            SkateParks SKP = BD.TraerSKP(idSKP);
            ViewBag.nombreImagen = SKP.Imagen;
            ViewBag.Accion = accion;
            return View("Edición", SKP);
        }
        [HttpPost]
        public ActionResult grabar(SkateParks SKP, string accion)
        {
            if (accion == "Editar")
            {
                if (SKP.ArchivoImagen != null)
                {
                    string NuevaUbicacion = Server.MapPath("~/Content/images/") + SKP.ArchivoImagen.FileName;
                    SKP.ArchivoImagen.SaveAs(NuevaUbicacion);
                    SKP.Imagen = SKP.ArchivoImagen.FileName;
                }

                BD.EditarSKP(SKP);
                List<SkateParks> lstSKP = BD.ListarSkateParks();
                ViewBag.Lskp = lstSKP;
            }
            else
            {
                if (SKP.ArchivoImagen != null)
                {
                    string NuevaUbicacion = Server.MapPath("~/Content/images/") + SKP.ArchivoImagen.FileName;
                    SKP.ArchivoImagen.SaveAs(NuevaUbicacion);
                    SKP.Imagen = SKP.ArchivoImagen.FileName;
                }
                BD.InsertarSKP(SKP);
                List<SkateParks> lstSKPS = BD.ListarSkateParks();
                ViewBag.skps = lstSKPS;
            }
            return RedirectToAction("ABMS", new { a = 1 });
        }
        public ActionResult Eliminar(int idSKP)
        {
            BD.EliminarSKP(idSKP);
            return RedirectToAction("ABMS", new { a = 1 });
        }
        public ActionResult Destacar(int idSKP)
        {
            SkateParks b = new SkateParks();
            BD.Destacar(idSKP);
            b = BD.TraerSKP(idSKP);          
            return RedirectToAction("ABMS", new { a = 1 });
        }
    }
}