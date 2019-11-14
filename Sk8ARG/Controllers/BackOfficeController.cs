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
            if (Session["Login"]!=null)
            {
                return View("ABM");
            }
            else
            {
                return View();
            }

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
              
                Session["Login"] = true;
                return View("ABM");
                
            }
        }
        public ActionResult ingresarSKP(string accion)
        {
            SkateParks SKP = new SkateParks();
            ViewBag.Accion = accion;
            return View("Edición", SKP);
        }
        public ActionResult IngresarRopa(string accion)
        {
            Ropa Miropa = new Ropa();
            ViewBag.Accion = accion;
            return View("EdicionRopa", Miropa);
        }
        public ActionResult EditarSKP(int idSKP, string accion)
        {
            SkateParks SKP = BD.TraerSKP(idSKP);
            ViewBag.Foto= SKP.Imagen;
            ViewBag.Accion = accion;
            return View("Edición", SKP);
        }
        public ActionResult EditarRopa(int IdRopa, string accion)
        {
            Ropa MiRopa = BD.TraerRopa(IdRopa);
            ViewBag.Foto = MiRopa.Foto;
            ViewBag.Accion = accion;
            return View("EdicionRopa", MiRopa);
        }
        [HttpPost]
        public ActionResult grabarSKP(SkateParks SKP, string accion)
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
        [HttpPost]
        public ActionResult GrabarRopa(Ropa MiRopa, string accion)
        {
            if (accion == "Editar")
            {
                if (MiRopa.ArchivoImagen != null)
                {
                    string NuevaUbicacion = Server.MapPath("~/Content/images/") + MiRopa.ArchivoImagen.FileName;
                    MiRopa.ArchivoImagen.SaveAs(NuevaUbicacion);
                    MiRopa.Foto = MiRopa.ArchivoImagen.FileName;
                }
                BD.EditarRopa(MiRopa);
                List<Ropa> LstRopa = BD.ListarRopa();
                ViewBag.Lskp = LstRopa;
            }
            else
            {
                if (MiRopa.ArchivoImagen != null)
                {
                    string NuevaUbicacion = Server.MapPath("~/Content/images/") + MiRopa.ArchivoImagen.FileName;
                    MiRopa.ArchivoImagen.SaveAs(NuevaUbicacion);
                    MiRopa.Foto = MiRopa.ArchivoImagen.FileName;
                }
                BD.InsertarROPA(MiRopa);
                List<Ropa> ropas= BD.ListarRopa();
                ViewBag.LstRopa = ropas;
            }
            return RedirectToAction("ABMS", new { a = 2 });
        }
        public ActionResult EliminarSKP(int idSKP)
        {
            BD.EliminarSKP(idSKP);
            return RedirectToAction("ABMS", new { a = 1 });
        }
        public ActionResult EliminarRopa(int IdRopa)
        {
            BD.EliminarRopa(IdRopa);
            return RedirectToAction("ABMS", new { a = 1 });
        }
        public ActionResult DestacarSKP(int idSKP)
        {
            SkateParks b = new SkateParks();
            BD.DestacarSKP(idSKP);
            b = BD.TraerSKP(idSKP);          
            return RedirectToAction("ABMS", new { a = 1 });
        }
        public ActionResult DestacarRopa(int IdRopa)
        {
            Ropa b = new Ropa();
            BD.DestacarRopa(IdRopa);
            b = BD.TraerRopa(IdRopa);
            return RedirectToAction("ABMS", new { a = 2 });
        }
    }
}