using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Sk8ARG.Models
{
    public class BD
    {
        private static SqlConnection Conectar()
        {
            string strConn = "Server=.;Database =TP PAGINA;Trusted_Connection=True;";
            SqlConnection a = new SqlConnection(strConn);
            a.Open();
            return a;
        }
        private static void Desconectar(SqlConnection conn)
        {
            conn.Close();
        }
        public static bool Existe(Usuarios us)
        {
            bool Exist = false;
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "SELECT * from Usuarios where Nombre = '" + us.Mail + "'AND Contraseña = '" + us.Contraseña + "'";
            SqlDataReader Lector = Consulta.ExecuteReader();
            if (Lector.Read())
            {
                Exist = true;
            }
            return Exist;
        }
        public static List<SkateParks> ListarSkateParks()
        {
            List<SkateParks> ListaSkateParks = new List<SkateParks>();
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "SELECT * from SkateParks ";
            SqlDataReader Lector = Consulta.ExecuteReader();
            while (Lector.Read())
            {
                int IdSKP = Convert.ToInt32(Lector["idSkatePark"]);
                string Nom = (Lector["Nombre"].ToString());
                string Ub = (Lector["Ubicacion"].ToString());
                string Desc = (Lector["Descripcion"].ToString());
                string Foto = (Lector["Foto"].ToString());
                bool Dest = Convert.ToBoolean(Lector["Destacado"]);

                SkateParks miSkateParks = new SkateParks(IdSKP, Nom, Foto, Desc, Dest, Ub);
                ListaSkateParks.Add(miSkateParks);
            }

            Desconectar(Conn);
            return ListaSkateParks;

        }
        public static List<Ropa> ListarRopa()
        {
            List<Ropa> ListaRopa = new List<Ropa>();
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "SELECT * from Ropa";
            SqlDataReader Lector = Consulta.ExecuteReader();
            while (Lector.Read())
            {
                int IdR = Convert.ToInt32(Lector["idRopa"]);
                string Nom = (Lector["Nombre"].ToString());
                string Desc = (Lector["Descripcion"].ToString());
                string Foto = (Lector["Foto"].ToString());
                bool Dest = Convert.ToBoolean(Lector["Destacado"]);

                Ropa miRopa = new Ropa(IdR, Nom, Foto, Desc, Dest);
                ListaRopa.Add(miRopa);
            }

            Desconectar(Conn);
            return ListaRopa;

        }
        public static List<Hardware> ListarHardware()
        {
            List<Hardware> ListaHW= new List<Hardware>();
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "SELECT * from Hardware";
            SqlDataReader Lector = Consulta.ExecuteReader();
            while (Lector.Read())
            {
                int IdHW = Convert.ToInt32(Lector["idHardware"]);
                string Nom = (Lector["Nombre"].ToString());
                string Desc = (Lector["Descripcion"].ToString());
                string Foto = (Lector["Foto"].ToString());
                bool Dest = Convert.ToBoolean(Lector["Destacado"]);

                Hardware miHW = new Hardware(IdHW, Nom, Foto, Desc, Dest);
                ListaHW.Add(miHW);
            }

            Desconectar(Conn);
            return ListaHW;

        }
    }
}