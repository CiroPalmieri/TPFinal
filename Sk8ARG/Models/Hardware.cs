using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sk8ARG.Models
{
    public class Hardware
    {
        private int idHW;
        private string nombre;
        private string precio;
        private string descripcion;
        private int stock;
        private string foto;
        private bool dest;

        public int IdHW { get => idHW; set => idHW = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Precio { get => precio; set => precio = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Stock { get => stock; set => stock = value; }
        public string Foto { get => foto; set => foto = value; }
        public bool Dest { get => dest; set => dest = value; }
        public Hardware()
        {
            IdHW = 0;
            Nombre = "";
            Precio = "";
            Stock = 0;
            Foto = "";
            Descripcion = "";
            Dest = false;
        }
        public Hardware(int a, string b, string c, string d, int e, string f, bool g)
        {
            idHW= a;
            Nombre = b;
            Precio = c;
            Foto = f;
            Descripcion = d;
            Stock = e;
            Dest = g;
        }
    }
}