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

namespace PagoAgilFrba.AbmSucursal
{
    public partial class ABMSucursal : Form
    {
        public ABMSucursal()
        {
            InitializeComponent();
            ocultarTodosLosItems();
            comboBoxFiltro.Items.Add("Todos");
            comboBoxFiltro.Items.Add("Nombre");
            comboBoxFiltro.Items.Add("Dirección");
            comboBoxFiltro.Items.Add("Codigo Postal");
        }

        private int CPSinModificar = 0;

        private void mostrarAlta()
        {
            labelNombre.Visible = true;
            labelDirec.Visible = true;
            labelCodigoPostal.Visible = true;
            textBoxNombre.Visible = true;
            textBoxDirec.Visible = true;
            textBoxCodigoPostal.Visible = true;
            labelTitulo.Visible = true;
            buttonAceptar.Visible = true;
            buttonLimpiar.Visible = true;
        }

        private void mostrarBusqueda()
        {
            labelTitulo.Visible = true;
            labelFiltro.Visible = true;
            comboBoxFiltro.Visible = true;
        }

        private void mostrarResultadosBusqueda()
        {
            labelResultadoBusqueda.Visible = true;
            comboBoxResultadoBusqueda.Visible = true;
        }

        private void ocultarResultadosBusqueda()
        {
            labelResultadoBusqueda.Visible = false;
            comboBoxResultadoBusqueda.Visible = false;
        }

        private void ocultarTodosLosItems()
        {
            labelNombre.Visible = false;
            labelDirec.Visible = false;
            labelCodigoPostal.Visible = false;
            textBoxNombre.Visible = false;
            textBoxDirec.Visible = false;
            textBoxCodigoPostal.Visible = false;
            labelTitulo.Visible = false;
            buttonAceptar.Visible = false;
            buttonLimpiar.Visible = false;

            buttonBuscar.Visible = false;
            labelResultadoBusqueda.Visible = false;
            comboBoxResultadoBusqueda.Visible = false;
            labelFiltro.Visible = false;
            comboBoxFiltro.Visible = false;
            checkBoxSucu.Visible = false;
        }

        private void accionBotonAlta()
        {
            if (todosLosCamposCompletos())
            {
                int esNumero;
                if (Int32.TryParse(textBoxCodigoPostal.Text.ToString(), out esNumero))
                {
                    if (codigoPostalNoEstaRepetido(Convert.ToInt32(textBoxCodigoPostal.Text)))
                    {
                        darAltaSucursal(textBoxNombre.Text, textBoxDirec.Text, Convert.ToInt32(textBoxCodigoPostal.Text));
                    }
                    else
                    {
                        MessageBox.Show("El Codigo Postal ingresado ya se encuentra registrado, intente con otro.", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("El siguiente campo: Código Postal, es inválido.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos.", "Error");
            }
        }

        private void accionBotonModificacion()
        {
            if (todosLosCamposCompletos())
            {
                int esNumero;
                if (Int32.TryParse(textBoxCodigoPostal.Text.ToString(), out esNumero))
                {
                    modificarSucursal(textBoxNombre.Text, textBoxDirec.Text, Convert.ToInt32(textBoxCodigoPostal.Text));
                }
                else
                {
                    MessageBox.Show("El siguiente campo: Código Postal, es inválido.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos.", "Error");
            }
        }

        private bool todosLosCamposCompletos()
        {
            return textBoxNombre.Text.Length > 0 && textBoxDirec.Text.Length > 0 && textBoxCodigoPostal.Text.Length > 0 ? true : false;
        }

        private bool codigoPostalNoEstaRepetido(int CP)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT sucu_id FROM GOQ.Sucursal WHERE sucu_cp = @CP", PagoAgilFrba.ModuloGlobal.getConexion()); 
            cmd.Parameters.Add("CP", SqlDbType.Decimal).Value = CP;
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

        private void darAltaSucursal(string Nombre, string Direccion, int CodigoPostal)
        {
            int filasRetornadas;
            SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO GOQ.Sucursal (sucu_nombre, sucu_dir, sucu_cp, sucu_habilitado) VALUES ('{0}', '{1}', '{2}', 1)",
                Nombre, Direccion, CodigoPostal), PagoAgilFrba.ModuloGlobal.getConexion()); 
            filasRetornadas = cmd.ExecuteNonQuery();
            if (filasRetornadas > 0)
            {
                MessageBox.Show("La sucursal se ha registrado con éxito!", "Información");
            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar registrar la sucursal", "Error");
            }
        }

        private void modificarSucursal(string Nombre, string Direccion, int CodigoPostal)
        {
            int filasRetornadas, habilitado;
            if (checkBoxSucu.Visible && checkBoxSucu.Checked)
            {
                habilitado = 1;
            }
            else if (checkBoxSucu.Visible && checkBoxSucu.Checked == false)
            {
                habilitado = 0;
            }
            else
            {
                habilitado = 1;
            }
            if (CPSinModificar != CodigoPostal)
            {
                if (codigoPostalNoEstaRepetido(Convert.ToInt32(textBoxCodigoPostal.Text)))
                {
                    //modifica el codigo postal
                    SqlCommand cmd = new SqlCommand(string.Format("UPDATE GOQ.Sucursal SET sucu_nombre = '{0}', sucu_dir = '{1}', sucu_cp = '{2}', sucu_habilitado = '{3}' WHERE sucu_cp = '{4}'",
                    Nombre, Direccion, CodigoPostal, habilitado, CPSinModificar), PagoAgilFrba.ModuloGlobal.getConexion());
                    filasRetornadas = cmd.ExecuteNonQuery();
                }
                else
                {
                   
                    filasRetornadas = -1; //significa que no hice ningun cambio y se trata de este error.
                }
            }
            else
            {
                ////no modifica el CP
                SqlCommand cmd = new SqlCommand(string.Format("UPDATE GOQ.Sucursal SET sucu_nombre = '{0}', sucu_dir = '{1}', sucu_cp = '{2}', sucu_habilitado = '{3}' WHERE sucu_cp = '{4}'",
                Nombre, Direccion, CodigoPostal, habilitado, CPSinModificar), PagoAgilFrba.ModuloGlobal.getConexion()); 
                filasRetornadas = cmd.ExecuteNonQuery();
            }

            if (filasRetornadas > 0)
            {
                MessageBox.Show("La sucursal se ha modificado con éxito!", "Información");
            }
            else if (filasRetornadas == -1)
            {
                 MessageBox.Show("El codigo postal ingresado ya existe en el sistema", "Error");
            
            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar modificar la sucursal", "Error");
            }
        }

        private bool camposDeBusquedaCompletos()
        {
            if (comboBoxFiltro.SelectedItem.ToString() == "Todos")
            {
                return textBoxDirec.TextLength > 0 && textBoxNombre.TextLength > 0 && textBoxCodigoPostal.TextLength > 0;
            }
            else if (comboBoxFiltro.SelectedItem.ToString() == "Nombre")
            {
                return textBoxNombre.TextLength > 0;
            }
            else if (comboBoxFiltro.SelectedItem.ToString() == "Dirección")
            {
                return textBoxDirec.TextLength > 0;
            }
            else
            {
                return textBoxCodigoPostal.TextLength > 0;
            }
        }

        private bool realizarBusquedayDevolverResultado()
        {
            comboBoxResultadoBusqueda.Items.Clear();
            if (comboBoxFiltro.SelectedItem.ToString() == "Todos")
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("SELECT CONVERT(varchar(18),sucu_cp) + '/' + sucu_dir + '/' + sucu_nombre FROM GOQ.Sucursal WHERE sucu_cp = @CP AND sucu_nombre = @NOMBRE AND sucu_dir = @DIR",
                    PagoAgilFrba.ModuloGlobal.getConexion()); 
                cmd.Parameters.Add("CP", SqlDbType.Decimal).Value = Convert.ToInt32(textBoxCodigoPostal.Text);
                cmd.Parameters.Add("DIR", SqlDbType.NVarChar).Value = textBoxDirec.Text;
                cmd.Parameters.Add("NOMBRE", SqlDbType.NVarChar).Value = textBoxNombre.Text;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxResultadoBusqueda.Items.Add(reader.GetString(0));
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
                SqlCommand cmd = new SqlCommand("SELECT CONVERT(varchar(18),sucu_cp) + '/' + sucu_dir + '/' + sucu_nombre FROM GOQ.Sucursal WHERE sucu_nombre = @NOMBRE",
                    PagoAgilFrba.ModuloGlobal.getConexion()); 
                cmd.Parameters.Add("NOMBRE", SqlDbType.NVarChar).Value = textBoxNombre.Text;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxResultadoBusqueda.Items.Add(reader.GetString(0));
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
            else if (comboBoxFiltro.SelectedItem.ToString() == "Dirección")
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("SELECT CONVERT(varchar(18),sucu_cp) + '/' + sucu_dir + '/' + sucu_nombre FROM GOQ.Sucursal WHERE sucu_dir = @DIR",
                    PagoAgilFrba.ModuloGlobal.getConexion()); 
                cmd.Parameters.Add("DIR", SqlDbType.NVarChar).Value = textBoxDirec.Text;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxResultadoBusqueda.Items.Add(reader.GetString(0));
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
                SqlCommand cmd = new SqlCommand("SELECT CONVERT(varchar(18),sucu_cp) + '/' + sucu_dir + '/' + sucu_nombre FROM GOQ.Sucursal WHERE sucu_cp = @CP",
                    PagoAgilFrba.ModuloGlobal.getConexion()); 
                cmd.Parameters.Add("CP", SqlDbType.Decimal).Value = Convert.ToInt32(textBoxCodigoPostal.Text);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxResultadoBusqueda.Items.Add(reader.GetString(0));
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

        private void inhabilitarSucursal(int CP, string Direccion, string Nombre)
        {
            SqlCommand cmd = new SqlCommand("UPDATE GOQ.Sucursal SET sucu_habilitado = 0 WHERE sucu_cp = @CP AND sucu_dir = @DIR AND sucu_nombre = @NOMBRE",
                    PagoAgilFrba.ModuloGlobal.getConexion()); 
            cmd.Parameters.Add("CP", SqlDbType.Decimal).Value = CP;
            cmd.Parameters.Add("DIR", SqlDbType.NVarChar).Value = Direccion;
            cmd.Parameters.Add("NOMBRE", SqlDbType.NVarChar).Value = Nombre;
            int cantidadFilasAfectadas = cmd.ExecuteNonQuery();
            if (cantidadFilasAfectadas > 0)
            {
                MessageBox.Show("Sucursal eliminada con éxito.", "Información");
            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar eliminar la sucursal.", "Error");
            }
        }

        private void limpiarCampos()
        {
            textBoxNombre.Text = "";
            textBoxDirec.Text = "";
            textBoxCodigoPostal.Text = "";
            checkBoxSucu.Checked = false;
            comboBoxResultadoBusqueda.Items.Clear();
        }

        private void llenarCamposParaModificar(int CP, string Direccion, string Nombre)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT sucu_nombre, sucu_dir, sucu_cp, sucu_habilitado FROM GOQ.Sucursal WHERE sucu_nombre = @NOMBRE AND sucu_dir = @DIR AND sucu_cp = @CP",
                PagoAgilFrba.ModuloGlobal.getConexion()); 
            cmd.Parameters.Add("CP", SqlDbType.Decimal).Value = CP;
            cmd.Parameters.Add("DIR", SqlDbType.NVarChar).Value = Direccion;
            cmd.Parameters.Add("NOMBRE", SqlDbType.NVarChar).Value = Nombre;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                textBoxNombre.Text = Convert.ToString(reader.GetValue(0));
                textBoxDirec.Text = Convert.ToString(reader.GetValue(1));
                CPSinModificar = Convert.ToInt32(reader.GetValue(2));
                textBoxCodigoPostal.Text = Convert.ToString(reader.GetValue(2));
                if (Convert.ToInt32(reader.GetValue(3)) == 0)
                {
                    checkBoxSucu.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error al obtener los datos de la sucursal.", "Error");
            }
            reader.Close();
        }

        private bool sucursalNoEstaInhabilitada(int CP, string Direccion, string Nombre)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT sucu_id FROM GOQ.Sucursal WHERE sucu_nombre = @NOMBRE AND sucu_dir = @DIR AND sucu_cp = @CP AND sucu_habilitado = 0",
                    PagoAgilFrba.ModuloGlobal.getConexion()); 
            cmd.Parameters.Add("CP", SqlDbType.Decimal).Value = CP;
            cmd.Parameters.Add("DIR", SqlDbType.NVarChar).Value = Direccion;
            cmd.Parameters.Add("NOMBRE", SqlDbType.NVarChar).Value = Nombre;
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

        //////////////////////////////////////////////COMIENZO CLICKS

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

        private void buttonAceptar_Click(object sender, EventArgs e)
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

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            if (camposDeBusquedaCompletos())
            {
                if (realizarBusquedayDevolverResultado())
                {
                    MessageBox.Show("La sucursal fue encontrada.", "Información");
                    mostrarResultadosBusqueda();
                }
                else
                {
                    MessageBox.Show("La sucursal no ha sido encontrada, intente nuevamente.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Complete alguno de los campos para realizar la búsqueda.", "Error");
            }
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
                labelDirec.Visible = true;
                labelCodigoPostal.Visible = true;
                textBoxNombre.Visible = true;
                textBoxDirec.Visible = true;
                textBoxCodigoPostal.Visible = true;
                buttonBuscar.Visible = true;
                buttonLimpiar.Visible = true;
            }
            else if (comboBoxFiltro.SelectedItem.ToString() == "Dirección")
            {
                labelDirec.Visible = true;
                textBoxDirec.Visible = true;
                buttonBuscar.Visible = true;
                buttonLimpiar.Visible = true;

            }
            else if (comboBoxFiltro.SelectedItem.ToString() == "Codigo Postal")
            {
                labelCodigoPostal.Visible = true;
                textBoxCodigoPostal.Visible = true;
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

        private void comboBoxResultadoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (labelTitulo.Text == "MODIFICACION")
            {
                if (MessageBox.Show("¿Desea modificar la sucursal seleccionada?", "Información",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ocultarTodosLosItems();
                    string[] camposABuscar = comboBoxResultadoBusqueda.SelectedItem.ToString().Split(new Char[] { '/' });
                    limpiarCampos();
                    //CP, DIRECCION, NOMBRE
                    llenarCamposParaModificar(Convert.ToInt32(camposABuscar[0]), camposABuscar[1], camposABuscar[2]);
                    mostrarAlta();
                }
            }
            else
            {
                if (MessageBox.Show("¿Desea eliminar la sucursal seleccionada?", "Información",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string[] camposABuscar = comboBoxResultadoBusqueda.SelectedItem.ToString().Split(new Char[] { '/' });
                    //int CP, string Direccion, string Nombre
                    if (sucursalNoEstaInhabilitada(Convert.ToInt32(camposABuscar[0]), camposABuscar[1], camposABuscar[2]))
                    {
                        //int CP, string Direccion, string Nombre
                        inhabilitarSucursal(Convert.ToInt32(camposABuscar[0]), camposABuscar[1], camposABuscar[2]);
                    }
                    else
                    {
                        MessageBox.Show("La sucursal ya se encuentra eliminada, intente con otra.", "Información");
                    }

                }
            }
        }

    }
}
