using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sk8ARG.Models
{
    public class SkateParks
    {
        private int _idSkatePark;
        private string _Nombre;
        private string _Imagen;
        private HttpPostedFileBase _ArchivoImagen;
        private string _Desc;
        private bool _Destacado;
        private string _Ubic;

        public int IdSkatePark { get => _idSkatePark; set => _idSkatePark = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Imagen { get => _Imagen; set => _Imagen = value; }    
        public HttpPostedFileBase ArchivoImagen { get => _ArchivoImagen; set => _ArchivoImagen = value; }
        public string Desc { get => _Desc; set => _Desc = value; }
        public bool Destacado { get => _Destacado; set => _Destacado = value; }
        public string Ubic { get => _Ubic; set => _Ubic = value; }

        public SkateParks()
        {
            IdSkatePark = 0;
            Nombre = "";
            Imagen = "";
            Desc = "";
            Ubic = "";
            Destacado = false;
        }

        public SkateParks(int a, string b, string c, string d, bool e, string f)
        {
            IdSkatePark = a;
            Nombre = b;
            Imagen = c;
            Desc = d;
            Destacado = e;
            Ubic = f;
        }

    }
}