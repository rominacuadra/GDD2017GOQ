using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Security.Cryptography;



namespace PagoAgilFrba
{
    class ModuloGlobal
    {
        public static string usuarioLogueado="";
        public static string nombre_rol = "";
        public static string suc_cob_id="";

        public static SqlConnection getConexion()
        {



            SqlConnection conex = null;
            if (conex == null || conex.State == ConnectionState.Closed)
            {



                try
                {

                    String str = "Data Source=localhost\\SQLSERVER2012;Initial Catalog=GD2C2017;Integrated Security=True"; ;
                    //String str = ConfigurationManager.ConnectionStrings["GD1C2017"].ConnectionString; //VER SI FUNCIONA OK
                    conex = new SqlConnection(str);
                    conex.ConnectionString = str;
                    conex.Open();

                }
                catch (SqlException)
                {
                   
                }

            }

            return conex;

        }




    }
}
