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
using Microsoft.VisualBasic;

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class AbmEmpresa : Form
    {
        public AbmEmpresa()
        {
            InitializeComponent();
            ocultarTodosLosItems();
            comboBoxFiltro.Items.Add("Todos");
            comboBoxFiltro.Items.Add("Nombre");
            comboBoxFiltro.Items.Add("Cuit");
            comboBoxFiltro.Items.Add("Servicio");
            llenarComboBoxServicio();
        }

        private void llenarComboBoxServicio()
        {

            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT TOP 50 serv_descripcion FROM GOQ.Servicio",
                PagoAgilFrba.ModuloGlobal.getConexion());
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxServicio.Items.Add(Convert.ToString(reader.GetValue(0)));
            }
            reader.Close();
        }

        private int idEmpresaSinModificar = 0;
        private int idServicioSinModificar = 0;
        
        private void ocultarTodosLosItems()
        {
            labelFiltro.Visible = false;
            comboBoxFiltro.Visible = false;
            labelEmpresasEncontradas.Visible = false;
            comboBoxEmpresasEncontradas.Visible = false;
            labelNombre.Visible = false;
            textBoxNombre.Visible = false;
            labelCuit.Visible = false;
            textBoxCuit.Visible = false;
            labelDireccion.Visible = false;
            textBoxDireccion.Visible = false;
            labelServicio.Visible = false;
            comboBoxServicio.Visible = false;
            checkBoxEmpresa.Visible = false;
            buttonAceptar.Visible = false;
            buttonLimpiar.Visible = false;
            buttonBuscar.Visible = false;
            labelTitulo.Visible = false;
        }

        private void limpiarCampos()
        {
            textBoxNombre.Text = "";
            textBoxCuit.Text = "";
            textBoxDireccion.Text = "";
            comboBoxServicio.Text = "";
            comboBoxEmpresasEncontradas.Items.Clear();
        }

        private void mostrarAlta()
        {
            labelNombre.Visible = true;
            labelCuit.Visible = true;
            labelDireccion.Visible = true;
            labelServicio.Visible = true;
            textBoxNombre.Visible = true;
            textBoxCuit.Visible = true;
            textBoxDireccion.Visible = true;
            comboBoxServicio.Visible = true;
            labelTitulo.Visible = true;
            buttonAceptar.Visible = true;
            buttonLimpiar.Visible = true;
            labelTitulo.Visible = true;
        }

        private void mostrarBusqueda()
        {
            labelTitulo.Visible = true;
            labelFiltro.Visible = true;
            comboBoxFiltro.Visible = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBoxFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            ocultarTodosLosItems();
            labelTitulo.Visible = true;
            labelFiltro.Visible = true;
            comboBoxFiltro.Visible = true;
            if (comboBoxFiltro.SelectedItem.ToString() == "Todos")
            {
                labelNombre.Visible = true;
                labelCuit.Visible = true;
                labelServicio.Visible = true;
                textBoxNombre.Visible = true;
                textBoxCuit.Visible = true;
                comboBoxServicio.Visible = true;
                buttonBuscar.Visible = true;
                buttonLimpiar.Visible = true;
            }
            else if (comboBoxFiltro.SelectedItem.ToString() == "Cuit")
            {
                labelCuit.Visible = true;
                textBoxCuit.Visible = true;
                buttonBuscar.Visible = true;
                buttonLimpiar.Visible = true;

            }
            else if (comboBoxFiltro.SelectedItem.ToString() == "Servicio")
            {
                labelServicio.Visible = true;
                comboBoxServicio.Visible = true;
                buttonBuscar.Visible = true;
                buttonLimpiar.Visible = true;
            }
            else if (comboBoxFiltro.SelectedItem.ToString() == "Nombre")
            {
                labelNombre.Visible = true;
                textBoxNombre.Visible = true;
                buttonBuscar.Visible = true;
                buttonLimpiar.Visible = true;
            }
        }


        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ocultarTodosLosItems();
            limpiarCampos();
            labelTitulo.Text = "ALTA";
            mostrarAlta();
        }

        private void modificaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ocultarTodosLosItems();
            limpiarCampos();
            labelTitulo.Text = "MODIFICACION";
            mostrarBusqueda();
        }

        private void bajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ocultarTodosLosItems();
            limpiarCampos();
            labelTitulo.Text = "BAJA";
            mostrarBusqueda();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool todosLosCamposCompletos()
        {
            bool result = Information.IsNumeric(Convert.ToInt64(textBoxCuit.Text));
            if(result)
            {
                return textBoxNombre.Text.Length > 0 && textBoxCuit.Text.Length == 11 && comboBoxServicio.Text.Length > 0 && textBoxDireccion.Text.Length > 0 ? true : false;
            }else
            {
                MessageBox.Show("El cuit debe ser numerico y contener 11 numeros sin guiones", "Información");
                return false;
            }
        }

        private bool cuitNoEstaRepetido(long Cuit)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT ID_empresa FROM GOQ.Empresa WHERE empresa_cuit = @Cuit", PagoAgilFrba.ModuloGlobal.getConexion());
            cmd.Parameters.Add("Cuit", SqlDbType.Decimal).Value = Cuit;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                return false;
            }
            else
            {
                reader.Close();
                return true;
            }
        }

        private void darAltaSucursal(string Nombre, long Cuit, string Servicio, string Direccion)
        {
            int serv_id = 0;
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT serv_id FROM GOQ.Servicio WHERE serv_descripcion = @SERVICIO ",
            PagoAgilFrba.ModuloGlobal.getConexion());
            cmd.Parameters.Add("SERVICIO", SqlDbType.NVarChar).Value = Servicio;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                serv_id = Convert.ToInt32(reader.GetValue(0));
            }

            if (serv_id != 0)
            {
                int filasRetornadas;
                SqlCommand cmd1 = new SqlCommand(string.Format("INSERT INTO GOQ.Empresa (empresa_nombre, empresa_cuit, empresa_dir, empresa_habilitado) VALUES ('{0}', '{1}','{2}', 1)",
                Nombre, Cuit, Direccion), PagoAgilFrba.ModuloGlobal.getConexion());
                filasRetornadas = cmd1.ExecuteNonQuery();

                if (filasRetornadas > 0)
                {
                    SqlParameter[] sqls = new SqlParameter[1];
                    sqls[0] = new SqlParameter("SERVICIO", serv_id);
                    SqlCommand cmd2 = new SqlCommand("GOQ.SP_Insertar_Servicio_Empresa", PagoAgilFrba.ModuloGlobal.getConexion());
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddRange(sqls);
                    
                    MessageBox.Show("La empresa se ha registrado con éxito!", "Información");
                   
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar registrar la empresa", "Error");
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar registrar la empresa", "Error");
            }
            
        }

        private void accionBotonAlta()
        {
            if (todosLosCamposCompletos())
            {
                if (cuitNoEstaRepetido(Convert.ToInt64(textBoxCuit.Text)))
                {
                    darAltaSucursal(textBoxNombre.Text, Convert.ToInt64(textBoxCuit.Text), comboBoxServicio.Text, textBoxDireccion.Text);
                }
                else
                {
                    MessageBox.Show("El Cuit ingresado ya se encuentra registrado, intente con otro.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos.", "Error");
            }
        }

        private void modificarEmpresa(string Nombre, Int64 Cuit, string Servicio, string Direccion)
        {
            int filasRetornadasEmpresa, filasRetornadasServicioEmpresa, habilitado, idServicio = 0;
            
            if (checkBoxEmpresa.Visible && checkBoxEmpresa.Checked)
            {
                habilitado = 1;
            }
            else if (checkBoxEmpresa.Visible && checkBoxEmpresa.Checked == false)
            {
                habilitado = 0;
            }
            else
            {
                habilitado = 1;
            }

            SqlCommand cmd = new SqlCommand(string.Format("UPDATE GOQ.Empresa SET  empresa_nombre = '{0}', empresa_cuit = '{1}', empresa_dir = '{2}', empresa_habilitado = '{3}' WHERE ID_empresa = '{4}'",
            Nombre, Cuit, Direccion, habilitado, idEmpresaSinModificar), PagoAgilFrba.ModuloGlobal.getConexion());
            filasRetornadasEmpresa = cmd.ExecuteNonQuery();

            SqlDataReader reader = null;
            SqlCommand cmd1 = new SqlCommand("SELECT serv_id FROM GOQ.Servicio WHERE serv_descripcion = @SERVICIO ",
            PagoAgilFrba.ModuloGlobal.getConexion());
            cmd1.Parameters.Add("SERVICIO", SqlDbType.NVarChar).Value = Servicio;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                idServicio = Convert.ToInt32(reader.GetValue(0));
            }

            if (filasRetornadasEmpresa > 0 && idServicio != 0)
            {
                SqlCommand cmd2 = new SqlCommand(string.Format("UPDATE GOQ.Servicio_Empresa SET  ID_servicio = '{0}' WHERE ID_empresa = '{1}'",
                idServicio, idEmpresaSinModificar), PagoAgilFrba.ModuloGlobal.getConexion());
                filasRetornadasServicioEmpresa = cmd2.ExecuteNonQuery();

                if (filasRetornadasServicioEmpresa > 0)
                {
                    MessageBox.Show("La empresa se ha modificado con éxito!", "Información");
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar modificar la empresa", "Error");
                }
                
            }
            
        }

        private void accionBotonModificacion()
        {
            if (todosLosCamposCompletos())
            {
                modificarEmpresa(textBoxNombre.Text, Convert.ToInt64(textBoxCuit.Text), comboBoxServicio.Text, textBoxDireccion.Text);
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos.", "Error");
            }
        }

        private void buttonAceptar_Click_1(object sender, EventArgs e)
        {
            if (labelTitulo.Text == "ALTA")
            {
                accionBotonAlta();
            }
            else if (labelTitulo.Text == "MODIFICACION")
            {
                accionBotonModificacion();
            }
        }

        private void checkBoxEmpresa_CheckedChanged(object sender, EventArgs e)
        {
        
        }

        private bool empresaNoEstaInhabilitada(Int64 Cuit)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT ID_empresa FROM GOQ.Empresa WHERE empresa_cuit = @CUIT AND empresa_habilitado = 0",
            PagoAgilFrba.ModuloGlobal.getConexion());
            cmd.Parameters.Add("CUIT", SqlDbType.BigInt).Value = Cuit;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void inhabilitarSucursal(Int64 Cuit)
        {
            SqlCommand cmd = new SqlCommand("UPDATE GOQ.Empresa SET empresa_habilitado = 0 WHERE empresa_cuit = @CUIT",
            PagoAgilFrba.ModuloGlobal.getConexion());
            cmd.Parameters.Add("CUIT", SqlDbType.BigInt).Value = Cuit;
            int cantidadFilasAfectadas = cmd.ExecuteNonQuery();
            if (cantidadFilasAfectadas > 0)
            {
                MessageBox.Show("Empresa  eliminada con éxito.", "Información");
            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar eliminar la empresa.", "Error");
            }
        }

        private void llenarCamposParaModificar(Int64 Cuit)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("select e.empresa_nombre, e.empresa_cuit, e.empresa_dir, s.serv_descripcion, e.empresa_habilitado,e.ID_empresa,s.serv_id from GOQ.Empresa as e inner join GOQ.Servicio_Empresa as se on se.ID_empresa = e.ID_empresa inner join GOQ.Servicio as s on s.serv_id = se.ID_servicio where e.empresa_cuit like @CUIT",
            PagoAgilFrba.ModuloGlobal.getConexion());
            cmd.Parameters.Add("CUIT", SqlDbType.BigInt).Value = Cuit;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                textBoxNombre.Text = reader.GetString(0);
                textBoxCuit.Text = reader.GetString(1);
                textBoxDireccion.Text = reader.GetString(2);
                comboBoxServicio.Text = reader.GetString(3);
                idEmpresaSinModificar = Convert.ToInt32(reader.GetValue(5));
                idServicioSinModificar = Convert.ToInt32(reader.GetValue(6));

                if (Convert.ToInt32(reader.GetValue(4)) == 0)
                {
                  checkBoxEmpresa.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error al obtener los datos de la empresa.", "Error");
            }
            reader.Close();
        }

        private void comboBoxEmpresasEncontradas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (labelTitulo.Text == "MODIFICACION")
            {
                if (MessageBox.Show("¿Desea modificar la empresa seleccionada?", "Información",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ocultarTodosLosItems();
                    string[] camposABuscar = comboBoxEmpresasEncontradas.SelectedItem.ToString().Replace(" ", "").Split(new Char[] { '/' });
                    limpiarCampos();
                    //NOMBRE,CUIT,DIRECCION,SERVICIO
                    llenarCamposParaModificar(Convert.ToInt64(camposABuscar[1]));
                    mostrarAlta();
                }
            }
            else
            {
                if (MessageBox.Show("¿Desea eliminar la empresa seleccionada?", "Información",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string[] camposABuscar = comboBoxEmpresasEncontradas.SelectedItem.ToString().Replace(" ", "").Split(new Char[] { '/' });
                    //NOMBRE,CUIT,DIRECCION,SERVICIO
                    if (empresaNoEstaInhabilitada(Convert.ToInt64(camposABuscar[1])))
                    {
                        inhabilitarSucursal(Convert.ToInt64(camposABuscar[1]));
                    }
                    else
                    {
                       MessageBox.Show("La sucursal ya se encuentra eliminada, intente con otra.", "Información");
                    }

                }
            }
        }

        private bool camposDeBusquedaCompletos()
        {
            if (comboBoxFiltro.SelectedItem.ToString() == "Todos")
            {
                return textBoxCuit.TextLength > 0 && textBoxNombre.TextLength > 0 && comboBoxServicio.SelectedItem.ToString() != "";
            }
            else if (comboBoxFiltro.SelectedItem.ToString() == "Nombre")
            {
                return textBoxNombre.TextLength > 0;
            }
            else if (comboBoxFiltro.SelectedItem.ToString() == "Cuit")
            {
                return textBoxCuit.TextLength > 0;
            }
            else
            {
                return comboBoxServicio.SelectedItem.ToString() != "";
            }
        }

        private bool realizarBusquedayDevolverResultado()
        {
            comboBoxEmpresasEncontradas.Items.Clear();
            if (comboBoxFiltro.SelectedItem.ToString() == "Todos")
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("select e.empresa_nombre + '/' + e.empresa_cuit + '/' + e.empresa_dir + '/' + s.serv_descripcion from GOQ.Empresa as e inner join GOQ.Servicio_Empresa as se on se.ID_empresa = e.ID_empresa inner join GOQ.Servicio as s on s.serv_id = se.ID_servicio where e.empresa_cuit like @CUIT and e.empresa_nombre like @NOMBRE and s.serv_descripcion like @SERVICIO;",
                PagoAgilFrba.ModuloGlobal.getConexion());
                cmd.Parameters.Add("CUIT", SqlDbType.BigInt).Value = Convert.ToInt64(textBoxCuit.Text);
                cmd.Parameters.Add("SERVICIO", SqlDbType.NVarChar).Value = comboBoxServicio.Text;
                cmd.Parameters.Add("NOMBRE", SqlDbType.NVarChar).Value = textBoxNombre.Text;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxEmpresasEncontradas.Items.Add(reader.GetString(0));
                }
                if (reader.HasRows)
                {
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
            else if (comboBoxFiltro.SelectedItem.ToString() == "Nombre")
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("select e.empresa_nombre + '/' + e.empresa_cuit + '/' + e.empresa_dir + '/' + s.serv_descripcion from GOQ.Empresa as e inner join GOQ.Servicio_Empresa as se on se.ID_empresa = e.ID_empresa inner join GOQ.Servicio as s on s.serv_id = se.ID_servicio where e.empresa_nombre like @NOMBRE",
                PagoAgilFrba.ModuloGlobal.getConexion());
                cmd.Parameters.Add("NOMBRE", SqlDbType.NVarChar).Value = textBoxNombre.Text;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxEmpresasEncontradas.Items.Add(reader.GetString(0));
                }
                if (reader.HasRows)
                {
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
            else if (comboBoxFiltro.SelectedItem.ToString() == "Cuit")
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("select e.empresa_nombre + '/' + e.empresa_cuit + '/' + e.empresa_dir + '/' + s.serv_descripcion from GOQ.Empresa as e inner join GOQ.Servicio_Empresa as se on se.ID_empresa = e.ID_empresa inner join GOQ.Servicio as s on s.serv_id = se.ID_servicio where e.empresa_cuit like @CUIT",
                PagoAgilFrba.ModuloGlobal.getConexion());
                cmd.Parameters.Add("CUIT", SqlDbType.BigInt).Value = Convert.ToInt64(textBoxCuit.Text);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxEmpresasEncontradas.Items.Add(reader.GetString(0));
                }
                if (reader.HasRows)
                {
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
            else
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("select e.empresa_nombre + '/' + e.empresa_cuit + '/' + e.empresa_dir + '/' + s.serv_descripcion from GOQ.Empresa as e inner join GOQ.Servicio_Empresa as se on se.ID_empresa = e.ID_empresa inner join GOQ.Servicio as s on s.serv_id = se.ID_servicio where s.serv_descripcion like @SERVICIO",
                PagoAgilFrba.ModuloGlobal.getConexion());
                cmd.Parameters.Add("SERVICIO", SqlDbType.NVarChar).Value = comboBoxServicio.Text;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxEmpresasEncontradas.Items.Add(reader.GetString(0));
                }
                if (reader.HasRows)
                {
                    reader.Close();
                    return true;
                }
                else
                {
                    reader.Close();
                    return false;
                }
            }
        }

        private void mostrarResultadosBusqueda()
        {
            labelEmpresasEncontradas.Visible = true;
            comboBoxEmpresasEncontradas.Visible = true;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (camposDeBusquedaCompletos())
            {
                if (realizarBusquedayDevolverResultado())
                {
                    MessageBox.Show("La empresa fue encontrada.", "Información");
                    mostrarResultadosBusqueda();
                }
                else
                {
                    MessageBox.Show("La empresa no ha sido encontrada, intente nuevamente.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Complete alguno de los campos para realizar la búsqueda.", "Error");
            }
        }

        private void textBoxCuit_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }
    }
}
