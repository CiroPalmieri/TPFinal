using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sk8ARG.Models
{
    public class Ropa
    {
        private int idRopa;
        private string nombre;
        private string precio;
        private string descripcion;
        private string foto;
        private int stock;
        private bool dest;
        private HttpPostedFileBase _ArchivoImagen;


        public int IdRopa { get => idRopa; set => idRopa = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Precio { get => precio; set => precio = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Foto { get => foto; set => foto = value; }
        public int Stock { get => stock; set => stock = value; }
        public bool Dest { get => dest; set => dest = value; }
        public HttpPostedFileBase ArchivoImagen { get => _ArchivoImagen; set => _ArchivoImagen = value; }
        public Ropa()
        {
            IdRopa = 0;
            Nombre = "";
            Precio = "";
            Foto = "";
            Stock = 0;
            Descripcion = "";
            Dest = false;
        }
        public Ropa(int a, string b,string c, string d, string e, int f,bool g)
        {
            IdRopa = a;
            Nombre = b;
            Precio = c;
            Foto = d;
            Stock = f;
            Descripcion = e;
            Dest = g;
        }
    }
}