using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PagoAgilFrba.AbmRol
{
    public partial class Roles : Form
    {
        public Roles()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Roles_Load(object sender, EventArgs e)
        {
            cargarUsuarios();
        }

        private void cargarUsuarios() {

            int cant = 0;
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT USU_ID, USU_INTENTOS,USU_HABILITADO, USU_USERNAME FROM GOQ.USUARIO WHERE USU_HABILITADO='1'", PagoAgilFrba.ModuloGlobal.getConexion());//getConexion());

            
            reader = cmd.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            { 
                while (reader.Read())
                {
                    cant += 1;
                    listBox1.Items.Add(reader.GetString(0));
                }
                
            }

            if (!reader.HasRows) {
                MessageBox.Show("No tiene roles, ingresar como administrador y generar un rol para el usuario.", "Información"); 
            }

            //cargar los usuarios al listbox
        
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

    }
}
