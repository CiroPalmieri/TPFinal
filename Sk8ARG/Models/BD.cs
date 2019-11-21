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
            string strConn = "Server = A-CBO-03; Database = TP PAGINA; User Id = alumno;Password = alumno;";
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
                Boolean Dest = Convert.ToBoolean(Lector["Destacado"] is DBNull ? 0 : Lector["Destacado"]);

                SkateParks miSkateParks = new SkateParks(IdSKP, Nom, Foto, Desc, Dest, Ub);
                ListaSkateParks.Add(miSkateParks);
            }

            Desconectar(Conn);
            return ListaSkateParks;
        }
        public static SkateParks TraerSKP(int idSKP)
        {
            SkateParks SKP = new SkateParks();
            SqlConnection conn = Conectar();
            SqlCommand consulta = conn.CreateCommand();
            consulta.CommandText = "SELECT * FROM Skateparks where IdSkatePark = " + idSKP;
            consulta.CommandType = System.Data.CommandType.Text;
            SqlDataReader lector = consulta.ExecuteReader();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int IdSkatePark = Convert.ToInt32(lector["IdSkatePark"]);
                    string Nombre = lector["Nombre"].ToString();
                    string Ubicacion = lector["Ubicacion"].ToString();
                    string Descripcion = lector["Descripcion"].ToString();
                    string Imagen = lector["Foto"].ToString();
                    Boolean Destacada = Convert.ToBoolean(lector["Destacado"] is DBNull ? 0 : lector["Destacado"]);
                    SKP = new SkateParks(IdSkatePark, Nombre, Imagen, Descripcion, Destacada, Ubicacion);
                }
            }
            Desconectar(conn);
            return SKP;
        }
        public static SkateParks TraerDestSKP()
        {
            SkateParks SKP = new SkateParks();
            SqlConnection conn = Conectar();
            SqlCommand consulta = conn.CreateCommand();
            consulta.CommandText = "SELECT * FROM Skateparks where Destacado = " + 1;
            consulta.CommandType = System.Data.CommandType.Text;
            SqlDataReader lector = consulta.ExecuteReader();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int IdSkatePark = Convert.ToInt32(lector["IdSkatePark"]);
                    string Nombre = lector["Nombre"].ToString();
                    string Ubicacion = lector["Ubicacion"].ToString();
                    string Descripcion = lector["Descripcion"].ToString();
                    string Imagen = lector["Foto"].ToString();
                    Boolean Destacada = Convert.ToBoolean(lector["Destacado"] is DBNull ? 0 : lector["Destacado"]);
                    SKP = new SkateParks(IdSkatePark, Nombre, Imagen, Descripcion, Destacada, Ubicacion);
                }
            }
            Desconectar(conn);
            return SKP;
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
                string Prc = (Lector["Precio"].ToString());
                string Desc = (Lector["Descripcion"].ToString());
                string Foto = (Lector["Foto"].ToString());
                int Stock = Convert.ToInt32(Lector["Stock"]);
                Boolean Dest = Convert.ToBoolean(Lector["Destacado"] is DBNull ? 0 : Lector["Destacado"]);

                Ropa miRopa = new Ropa(IdR, Nom, Prc, Foto, Desc, Stock, Dest);
                ListaRopa.Add(miRopa);
            }

            Desconectar(Conn);
            return ListaRopa;

        }
        public static Ropa TraerRopa(int idRopa)
        {
            Ropa Ropita = new Ropa();
            SqlConnection conn = Conectar();
            SqlCommand consulta = conn.CreateCommand();
            consulta.CommandText = "SELECT * FROM Ropa where IdRopa = " + idRopa;
            consulta.CommandType = System.Data.CommandType.Text;
            SqlDataReader lector = consulta.ExecuteReader();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int IdRopa = Convert.ToInt32(lector["IdRopa"]);
                    string Nombre = lector["Nombre"].ToString();
                    string precio = lector["Precio"].ToString();
                    string Descripcion = lector["Descripcion"].ToString();
                    int Stock = Convert.ToInt32(lector["Stock"]);
                    string Imagen = lector["Foto"].ToString();
                    Boolean Destacada = Convert.ToBoolean(lector["Destacado"] is DBNull ? 0 : lector["Destacado"]);
                    Ropita = new Ropa(IdRopa, Nombre, precio, Imagen, Descripcion, Stock, Destacada);
                }
            }
            Desconectar(conn);
            return Ropita;
        }
        public static List<Hardware> ListarHardware()
        {
            List<Hardware> ListaHW = new List<Hardware>();
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "SELECT * from Hardware";
            SqlDataReader Lector = Consulta.ExecuteReader();
            while (Lector.Read())
            {
                int IdHW = Convert.ToInt32(Lector["IdHardware"]);
                int Stock = Convert.ToInt32(Lector["Stock"]);
                string Nom = (Lector["Nombre"].ToString());
                string Prec = (Lector["Precio"].ToString());
                string Desc = (Lector["Descripcion"].ToString());
                string Foto = (Lector["Foto"].ToString());
                Boolean Dest = Convert.ToBoolean(Lector["Destacado"] is DBNull ? 0 : Lector["Destacado"]);

                Hardware miHW = new Hardware(IdHW, Nom, Prec, Desc, Stock, Foto, Dest);
                ListaHW.Add(miHW);
            }

            Desconectar(Conn);
            return ListaHW;
        }
        public static Hardware TraerHW(int IdHW)
        {
            Hardware MiWH = new Hardware();
            SqlConnection conn = Conectar();
            SqlCommand consulta = conn.CreateCommand();
            consulta.CommandText = "SELECT * FROM Hardware where IdHardware = " + IdHW;
            consulta.CommandType = System.Data.CommandType.Text;
            SqlDataReader lector = consulta.ExecuteReader();

            if (lector.HasRows)
            {
                while (lector.Read())
                {
                    int IdHW1 = Convert.ToInt32(lector["IdHardware"]);
                    string Nombre = lector["Nombre"].ToString();
                    string precio = lector["Precio"].ToString();
                    string Descripcion = lector["Descripcion"].ToString();
                    int Stock = Convert.ToInt32(lector["Stock"]);
                    string Imagen = lector["Foto"].ToString();
                    Boolean Destacada = Convert.ToBoolean(lector["Destacado"] is DBNull ? 0 : lector["Destacado"]);
                    MiWH = new Hardware(IdHW1, Nombre, precio, Descripcion, Stock, Imagen, Destacada);
                }
            }
            Desconectar(conn);
            return MiWH;
        }
        public static void InsertarSKP(SkateParks MiSKP)
        {
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "INSERT into Skateparks(Nombre,Ubicacion,Descripcion,Foto) VALUES('" + MiSKP.Nombre + "','" + MiSKP.Ubic + "','" + MiSKP.Desc + "','" + MiSKP.Imagen + "')";
            Consulta.ExecuteNonQuery();
        }
        public static void InsertarROPA(Ropa Ropita)
        {
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "INSERT into Ropa(Nombre,Precio,Descripcion,Stock,Foto) VALUES('" + Ropita.Nombre + "','" + Ropita.Precio + "','" + Ropita.Descripcion + "'," + Ropita.Stock + ",'" + Ropita.Foto + "')";
            Consulta.ExecuteNonQuery();
        }
        public static void InsertarHW(Hardware MiHW)
        {
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "INSERT into HardWare(Nombre,Precio,Descripcion,Stock,Foto) VALUES('" + MiHW.Nombre + "','" + MiHW.Precio + "','" + MiHW.Descripcion + "'," + MiHW.Stock + ",'" + MiHW.Foto + "')";
            Consulta.ExecuteNonQuery();
        }
        public static void EditarSKP(SkateParks MiSKP)
        {
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;

            string SQL = "UPDATE Skateparks SET ";
            SQL += "Nombre = '" + MiSKP.Nombre + "', Foto='" + MiSKP.Imagen + "', " + "Descripcion= '" + MiSKP.Desc + "' WHERE IdSkatePark = " + MiSKP.IdSkatePark;
            Consulta.CommandText = SQL;
            Consulta.ExecuteNonQuery();
        }
        public static void EditarRopa(Ropa Ropita)
        {
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;

            string SQL = "UPDATE Ropa SET ";
            SQL += "Nombre = '" + Ropita.Nombre + "', Foto='" + Ropita.Foto + "', " + "Descripcion= '" + Ropita.Descripcion + "', " + " Stock = " + Ropita.Stock + " WHERE IdRopa = " + Ropita.IdRopa;
            Consulta.CommandText = SQL;
            Consulta.ExecuteNonQuery();
        }
        public static void EditarHW(Hardware MiHW)
        {
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;

            string SQL = "UPDATE Hardware SET ";
            SQL += "Nombre = '" + MiHW.Nombre + "', Foto='" + MiHW.Foto + "', " + "Descripcion= '" + MiHW.Descripcion + "', " + " Stock = " + MiHW.Stock + " WHERE IdHardware = " + MiHW.IdHW;
            Consulta.CommandText = SQL;
            Consulta.ExecuteNonQuery();
        }
        public static void EliminarSKP(int idSKP)
        {
            SkateParks SKP = new SkateParks();
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "DELETE  from Skateparks where IdSkatepark= " + idSKP + "";
            Consulta.ExecuteNonQuery();
        }
        public static void EliminarRopa(int IdRopa)
        {
            Ropa Ropita = new Ropa();
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "DELETE  from Ropa where IdRopa= " + IdRopa + "";
            Consulta.ExecuteNonQuery();
        }
        public static void EliminarHW(int IdHW)
        {
            Hardware MIHW = new Hardware();
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "DELETE  from HardWare where IdHardware= " + IdHW + "";
            Consulta.ExecuteNonQuery();
        }
        public static void DestacarSKP(int idSKP)
        {
            SkateParks skpDestacado = new SkateParks();
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "UPDATE Skateparks set Destacado = 0 where Destacado = 1";
            SqlDataReader Lector = Consulta.ExecuteReader();
            Lector.Close();
            Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "UPDATE Skateparks set Destacado = 1 where  IdSkatePark = " + idSKP;
            Lector = Consulta.ExecuteReader();
            Desconectar(Conn);
        }
        public static void DestacarRopa(int IdRopa)
        {
            SkateParks skpDestacado = new SkateParks();
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "UPDATE Ropa set Destacado = 0 where Destacado = 1";
            SqlDataReader Lector = Consulta.ExecuteReader();
            Lector.Close();
            Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "UPDATE Ropa set Destacado = 1 where  IdRopa = " + IdRopa;
            Lector = Consulta.ExecuteReader();
            Desconectar(Conn);
        }
        public static void DestacarHW(int IdHW)
        {
            Hardware HWD = new Hardware();
            SqlConnection Conn = Conectar();
            SqlCommand Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "UPDATE Hardware set Destacado = 0 where Destacado = 1";
            SqlDataReader Lector = Consulta.ExecuteReader();
            Lector.Close();
            Consulta = Conn.CreateCommand();
            Consulta.CommandType = System.Data.CommandType.Text;
            Consulta.CommandText = "UPDATE Hardware set Destacado = 1 where  IdHardware = " + IdHW;
            Lector = Consulta.ExecuteReader();
            Desconectar(Conn);
        }
    }
}