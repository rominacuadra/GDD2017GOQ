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

                    var connectionString = ConfigurationManager.ConnectionStrings;
                    
                    var str = connectionString["PagoAgil.Properties.Settings.GD2C2017ConnectionString"];
                    //String str = "Data Source=localhost\\SQLSERVER2012;Initial Catalog=GD2C2017;Integrated Security=True"; ;
                    conex = new SqlConnection(str.ConnectionString);
                    conex.ConnectionString = str.ConnectionString;
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
