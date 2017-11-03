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
using System.Security.Cryptography;



namespace PagoAgilFrba
{
    

    public partial class Form1 : Form
    {
        bool yaSeLogueoPorOK = false;
        int id_usuario;

        public Form1()
        {
            InitializeComponent();
        }

        /******************************************************************************/

        private void Form1_Load(object sender, EventArgs e)
        {

            PagoAgilFrba.ModuloGlobal.getConexion();
        }

        /******************************************************************************/


        /******************************************************************************/


        /******************************************************************************/

        private SqlDataReader logueoCorrecto(String usuario, string password)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT USU_ID, USU_INTENTOS,USU_HABILITADO FROM GOQ.USUARIO WHERE USU_USERNAME = @USUARIO AND USU_PASSWORD = GOQ.F_Hash256(@PASS) AND USU_HABILITADO='1'", PagoAgilFrba.ModuloGlobal.getConexion());//getConexion());

            cmd.Parameters.Add("USUARIO", SqlDbType.NVarChar).Value = usuario;
            cmd.Parameters.Add("PASS", SqlDbType.NVarChar).Value = password;

            reader = cmd.ExecuteReader();
            reader.Read();

            return reader;
        }

        /******************************************************************************/

        private void inhabilitarUsuario(String usuario)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("UPDATE GOQ.USUARIO SET USU_HABILITADO ='I' WHERE USU_USERNAME = @USUARIO AND USU_HABILITADO='1'", PagoAgilFrba.ModuloGlobal.getConexion());

            cmd.Parameters.Add("USUARIO", SqlDbType.NVarChar).Value = txtUsuario.Text;
            reader = cmd.ExecuteReader();
            reader.Read();
            MessageBox.Show("Usuario Inhabilitado", "Información");
            reader.Close();
        }

        /******************************************************************************/

        private SqlDataReader usuarioExiste(String usuario)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT USU_INTENTOS FROM GOQ.USUARIO WHERE USU_USERNAME = @USUARIO AND USU_HABILITADO='1'", PagoAgilFrba.ModuloGlobal.getConexion());

            cmd.Parameters.Add("USUARIO", SqlDbType.NVarChar).Value = txtUsuario.Text;
            reader = cmd.ExecuteReader();
            reader.Read();
            return reader;
        }

        /******************************************************************************/

        private void resetearIntentos(int nro)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("UPDATE GOQ.USUARIO SET USU_INTENTOS=@NRO WHERE USU_USERNAME = @USUARIO", PagoAgilFrba.ModuloGlobal.getConexion());

            cmd.Parameters.Add("USUARIO", SqlDbType.NVarChar).Value = txtUsuario.Text;
            cmd.Parameters.Add("NRO", SqlDbType.NVarChar).Value = nro;
            reader = cmd.ExecuteReader();
            reader.Close();
        }

        /******************************************************************************/

        /******************************************************************************/

        private void abrirPantallaPrincipal()
        {
            this.Hide();
             PantallaPrincipal  p = new PantallaPrincipal ();
             
             p.ShowDialog();
        }

        /******************************************************************************/

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Enter");
            if (e.KeyChar == (char)Keys.Enter)
            {

                btnIngresar.Focus();
            }
        }

        /******************************************************************************/

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int cargarRoles(string id)
        {
            int cant = 0;
            cbRol.Visible = true;
            
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("select distinct rol_nombre from [GOQ].[Rol] where rol_id in (select distinct rol_usu_rol_id from [GOQ].[Rol_Usuario] where rol_usu_usu_id = @ID)", PagoAgilFrba.ModuloGlobal.getConexion());
            
            cmd.Parameters.Add("ID", SqlDbType.NVarChar).Value = id;
            
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            { 
                while (reader.Read())
                {
                    cant += 1;
                    cbRol.Items.Add(reader.GetString(0));
                }
                
            }

            if (!reader.HasRows) {
                MessageBox.Show("No tiene roles, ingresar como administrador y generar un rol para el usuario.", "Información"); 
            }

            reader.Close(); 
            return cant;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            
            if (yaSeLogueoPorOK) {

                            if (cbRol.SelectedItem.ToString().Length > 0) 
                            {
                                    PagoAgilFrba.ModuloGlobal.usuarioLogueado = txtUsuario.Text.ToUpper();
                                    abrirPantallaPrincipal();
                            }
                            else 
                            {
                                     MessageBox.Show("No ingreso un rol.","Información");
                                     
                            }
                        }
                
            if ((txtUsuario.Text.Length > 0) && (txtClave.Text.Length > 0))
            {
                SqlDataReader reader = null;
                reader = logueoCorrecto(txtUsuario.Text, txtClave.Text);
                                            if (reader.HasRows)
                                            {
                                                
                                                id_usuario = reader.GetInt32(0);
                                                

                                                    if (cbRol.Text.Length == 0)
                                                    {

                                                        if (cargarRoles(logueoCorrecto(txtUsuario.Text, txtClave.Text).GetValue(0).ToString()) > 0)
                                                        {
                                                            MessageBox.Show("Seleccione un Rol...", "Información");
                                                            lblRol.Enabled = true;
                                                            cbRol.Enabled = true;
                                                           
                                                            yaSeLogueoPorOK=true; //Bandera para controlar el segundo "Aceptar" con Rol incluido.

                                                            if (logueoCorrecto(txtUsuario.Text, txtClave.Text).GetInt32(1)!=3)
                                                            {
                                                                MessageBox.Show("reseteando intentos", "Información");
                                                                resetearIntentos(3);
                                                            }
                                                            logueoCorrecto(txtUsuario.Text, txtClave.Text).Close();
                                                        }


                                                    }
 
                                            }
                                    else
                                    {
                                        MessageBox.Show("Ingreso incorrecto", "Información");
                                        //actualizar intentos descontar x 1
                                        int intento = 0;
                                        if (usuarioExiste(txtUsuario.Text).HasRows)
                                        {
                                            usuarioExiste(txtUsuario.Text).Read();

                                            intento = usuarioExiste(txtUsuario.Text).GetInt32(0);

                                            if (intento > 0)
                                            {
                                                resetearIntentos(intento - 1);
                                            }
                                            else
                                            {
                                                inhabilitarUsuario(txtUsuario.Text);
                                            }
                                            txtUsuario.Focus();
                                            usuarioExiste(txtUsuario.Text).Close();
                                        }

                                    }

                                    //if (cbRol.Text.Length > 0)
                                    //{
                                    //    abrirPantallaPrincipal();
                                    //}
                     
                }
            }

        private void cbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
             if((cbRol.SelectedItem.ToString())=="Cobrador") {
                 

                 cargarSucursales();
                 
             }


        }

        private  void cargarSucursales() {
            int cant = 0;
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT S.sucu_nombre,S.sucu_id FROM [GOQ].[Sucursal] S INNER JOIN [GOQ].[CobradorSucursal] C ON(S.sucu_id=C.sucu_id) INNER JOIN [GOQ].[Usuario] U ON (C.usu_id=U.usu_id) WHERE U.usu_id= @ID AND S.sucu_habilitado=1", PagoAgilFrba.ModuloGlobal.getConexion());

            cmd.Parameters.Add("ID", SqlDbType.NVarChar).Value = id_usuario;

            reader = cmd.ExecuteReader();

        
            if (reader.HasRows)
            {

                lblSuc.Enabled = true;
                cbSuc.Enabled = true;
                cbSuc.Visible = true;
                while (reader.Read())
                {
                    
                    cbSuc.Items.Add(reader.GetString(0));
                    cant += 1;
                }
            }
            else
            {

                MessageBox.Show("No tiene sucursales asignadas.", "Información");
                ModuloGlobal.suc_cob_id = null;
            }
            
        }

        private void cbSuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModuloGlobal.suc_cob_id = cbSuc.SelectedItem.ToString();
        }

        }

}
