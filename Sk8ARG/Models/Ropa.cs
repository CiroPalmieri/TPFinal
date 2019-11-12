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
        private bool dest;
        

        public int IdRopa { get => idRopa; set => idRopa = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Precio { get => precio; set => precio = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Foto { get => foto; set => foto = value; }
        public bool Dest { get => dest; set => dest = value; }
        public Ropa()
        {
            IdRopa = 0;
            Nombre = "";
            Precio = "";
            Foto = "";
            Descripcion = "";
            Dest = false;
        }
        public Ropa(int a, string b,string c, string d, string e, bool f)
        {
            IdRopa = a;
            Nombre = b;
            Precio = c;
            Foto = d;
            Descripcion = e;
            Dest = f;
        }
    }
}