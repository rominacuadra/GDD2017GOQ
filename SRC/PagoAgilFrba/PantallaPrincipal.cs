using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PagoAgilFrba
{
    public partial class PantallaPrincipal : Form
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void administraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbmCliente.ABMCliente p = new AbmCliente.ABMCliente();
            p.ShowDialog();
        }

        private void activarMenuSegunUsario(string usuario_logueado) {

                        int cant = 0;
                        SqlDataReader reader = null;
                        SqlCommand cmd = new SqlCommand("SELECT distinct fun_rol_fun_id FROM [GOQ].[Funcionalidad_Rol] F INNER JOIN [GOQ].[Rol_Usuario] RU ON(F.fun_rol_rol_id=RU.rol_usu_rol_id) INNER JOIN [GOQ].[Usuario] U ON (U.USU_ID=RU.rol_usu_usu_id) INNER JOIN [GOQ].[Rol] R ON(R.rol_id=RU.rol_usu_rol_id) WHERE upper(u.usu_username)=@NOMBREUSUARIO AND upper(R.rol_nombre)=@NOMBREROL;", PagoAgilFrba.ModuloGlobal.getConexion());

                        cmd.Parameters.Add("NOMBREUSUARIO", SqlDbType.NVarChar).Value = usuario_logueado;
                        cmd.Parameters.Add("NOMBREROL", SqlDbType.NVarChar).Value = ModuloGlobal.nombre_rol;

                        reader = cmd.ExecuteReader();

                        string imprimir;

                        
                        while (reader.Read())
                        {
                            imprimir = reader.GetValue(0).ToString();

                            switch (imprimir)
                            {
                                case "1":
                                    rolToolStripMenuItem.Enabled = true;
                                    usuarioToolStripMenuItem.Enabled = true;
                                    break;
                                case "2":
                                    clienteToolStripMenuItem.Enabled = true;
                                    administraciónToolStripMenuItem.Enabled = true;
                                    break;
                                case "3":
                                    empresaToolStripMenuItem.Enabled = true;
                                    administraciónToolStripMenuItem1.Enabled = true;
                                    break;
                                case "4":
                                    sucursalToolStripMenuItem.Enabled = true;
                                    break;
                                case "5":
                                    facturaToolStripMenuItem.Enabled = true;
                                    administraciónToolStripMenuItem2.Enabled = true;
                                    break;
                                case "6":
                                    registroDePagoToolStripMenuItem.Enabled = true;
                                    break;
                                case "7":                                 
                                    rendicionToolStripMenuItem.Enabled = true;
                                    break;
                                case "8":
                                    devoluciónToolStripMenuItem.Enabled = true;
                                    break;
                                case "9":
                                    listadoEstadisticoToolStripMenuItem.Enabled = true;
                                    break;
                                default:
                                    //Console.WriteLine("Default case");
                                    break;
                            }

                            cant += 1;
                        }

                        reader.Close();


        }

        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {
            activarMenuSegunUsario(PagoAgilFrba.ModuloGlobal.usuarioLogueado);

        }

        private void rolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbmRol.Roles p = new AbmRol.Roles();
            p.ShowDialog();
        }

        private void listadoEstadisticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListadoEstadistico.ListadoEstadistico listado = new ListadoEstadistico.ListadoEstadistico();
            listado.ShowDialog();
        }

        private void devoluciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Devolucion.Devolucion devolucion = new Devolucion.Devolucion();
            devolucion.ShowDialog();
        }

        private void sucursalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbmSucursal.ABMSucursal sucursal = new AbmSucursal.ABMSucursal();
            sucursal.ShowDialog();
        }

        private void administraciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbmEmpresa.AbmEmpresa empresa = new AbmEmpresa.AbmEmpresa();
            empresa.ShowDialog();
        }

        private void administraciónToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AbmFactura.AbmFactura factura = new AbmFactura.AbmFactura();
            factura.ShowDialog();
        }


        private void rendicionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rendicion.ABMRendicion p = new Rendicion.ABMRendicion();
            p.ShowDialog();
        }

        private void registroDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistroPago.RegistroPago p = new RegistroPago.RegistroPago();
            p.ShowDialog();
        }


    }
}
