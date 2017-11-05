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

namespace PagoAgilFrba.AbmFactura
{
    public partial class AbmFactura : Form
    {
        public AbmFactura()
        {
            InitializeComponent();
            ocultarTodosLosItems();
            llenarComboBoxEmpresa();
            llenarComboBoxCliente();
            llenarFechaAlta();
        }

        private void ocultarTodosLosItems()
        {
            labelNroFac.Visible = false;
            textBoxNroFac.Visible = false;
            labelEmpresa.Visible = false;
            comboBoxEmpresa.Visible = false;
            labelCliente.Visible = false;
            comboBoxCliente.Visible = false;
            labelFechaDeVenc.Visible = false;
            monthCalendar1.Visible = false;
            buttonAceptar.Visible = false;
            buttonLimpiar.Visible = false;
            labelTitulo.Visible = false;
            textBoxFechaAlta.Visible = false;
            labelFechaAlta.Visible = false;
            textBoxTotal.Visible = false;
            labelTotal.Visible = false;
            labelItemMonto.Visible = false;
            textBoxItemMonto.Visible = false;
            labelItemCantidad.Visible = false;
            textBoxItemCantidad.Visible = false;
        }

        private void llenarComboBoxEmpresa()
        {

            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT TOP 50 empresa_nombre FROM GOQ.Empresa",
                PagoAgilFrba.ModuloGlobal.getConexion());
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxEmpresa.Items.Add(Convert.ToString(reader.GetValue(0)));
            }
            reader.Close();
        }

        

        private void llenarComboBoxCliente()
        {

            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT TOP 50 cli_nombre + ' ' + cli_apellido FROM GOQ.Cliente",
            PagoAgilFrba.ModuloGlobal.getConexion());
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxCliente.Items.Add(Convert.ToString(reader.GetValue(0)));
            }
            reader.Close();
        }

        private void llenarFechaAlta()
        {
            DateTime now = DateTime.Now;
            textBoxFechaAlta.Text = now.ToString();
        }

        private void limpiarCampos()
        {
            textBoxNroFac.Text = "";
            comboBoxEmpresa.Text = "";
            comboBoxCliente.Text = "";
            monthCalendar1.Text = "";
        }

        private void mostrarAlta()
        {
            labelNroFac.Visible = true;
            textBoxNroFac.Visible = true;
            labelEmpresa.Visible = true;
            comboBoxEmpresa.Visible = true;
            labelCliente.Visible = true;
            comboBoxCliente.Visible = true;
            labelFechaDeVenc.Visible = true;
            monthCalendar1.Visible = true;
            buttonAceptar.Visible = true;
            buttonLimpiar.Visible = true;
            labelTitulo.Visible = true;
            labelFechaAlta.Visible = true;
            textBoxFechaAlta.Visible = true;
            textBoxTotal.Visible = true;
            labelTotal.Visible = true;
            labelItemMonto.Visible = true;
            textBoxItemMonto.Visible = true;
            labelItemCantidad.Visible = true;
            textBoxItemCantidad.Visible = true;
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ocultarTodosLosItems();
            limpiarCampos();
            labelTitulo.Text = "ALTA";
            mostrarAlta();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

       
        private bool facturaNoEstaRepetido(long NroFac)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT fac_id FROM GOQ.Factura WHERE empresa_cuit = @NroFac", PagoAgilFrba.ModuloGlobal.getConexion());
            cmd.Parameters.Add("NroFac", SqlDbType.Decimal).Value = NroFac;
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

        private void darAltaFactura(long NroFac, string empresa_desc, string cliente_nom_ape, string fechaVenc, string fechaAlta, string Total, string ItemMonto, string ItemCantidad)
        {
           int filasRetornadas;
           int empresa_id = 0;
           int cliente_id = 0;

           SqlDataReader reader = null;
           SqlCommand cmd = new SqlCommand("SELECT ID_empresa FROM GOQ.Empresa WHERE empresa_nombre = @EMPRESA ",
           PagoAgilFrba.ModuloGlobal.getConexion());
           cmd.Parameters.Add("EMPRESA", SqlDbType.NVarChar).Value = empresa_desc;
           reader = cmd.ExecuteReader();
           if (reader.HasRows)
           {
               reader.Read();
               empresa_id = Convert.ToInt32(reader.GetValue(0));
           }

           string[] camposABuscar = comboBoxCliente.SelectedItem.ToString().Replace(" ", "").Split(new Char[] { ' ' });
           string nombre = Convert.ToString(camposABuscar[0]);
           string apellido = Convert.ToString(camposABuscar[1]);
           
           SqlDataReader reader1 = null;
           SqlCommand cmd1 = new SqlCommand("SELECT ID_empresa FROM GOQ.Cliente WHERE cli_nombre = @NOMBRE AND cli_apellido= @APELLIDO",
           PagoAgilFrba.ModuloGlobal.getConexion());
           cmd1.Parameters.Add("NOMBRE", SqlDbType.NVarChar).Value = nombre;
           cmd1.Parameters.Add("APELLIDO", SqlDbType.NVarChar).Value = apellido;
           reader1 = cmd1.ExecuteReader();
           if (reader.HasRows)
           {
               reader1.Read();
               cliente_id = Convert.ToInt32(reader1.GetValue(0));
           }

           SqlCommand cmd2 = new SqlCommand(string.Format("INSERT INTO GOQ.Factura (fac_id, fac_empresa_id, fac_cli_id, fac_fecha_vec, fac_fecha_alta, fac_total) VALUES ('{0}', '{1}','{2}', '{3}', '{4}','{5}')",
           NroFac, empresa_id, cliente_id, fechaVenc, fechaAlta, Total), PagoAgilFrba.ModuloGlobal.getConexion());
           filasRetornadas = cmd2.ExecuteNonQuery();

                if (filasRetornadas > 0)
                {
                    SqlParameter[] sqls = new SqlParameter[1];
                    sqls[0] = new SqlParameter("MONTO", ItemMonto);
                    sqls[1] = new SqlParameter("CANTIDAD", ItemCantidad);
                    SqlCommand cmd3 = new SqlCommand("GOQ.SP_Insertar_Item", PagoAgilFrba.ModuloGlobal.getConexion());
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.Parameters.AddRange(sqls);

                    MessageBox.Show("La factura se ha registrado con éxito!", "Información");

                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar registrar la factura", "Error");
                }
            
        }

        private void accionBotonAlta()
        {
            
            if (textBoxNroFac.Text.Length == 0)
            {
                MessageBox.Show("Por favor, complete el campo Nro Factura e inténtelo nuevamente");
                return;
            }

            if (comboBoxEmpresa.Text.Length == 0)
            {
                MessageBox.Show("Por favor, complete el campo Empresa e inténtelo nuevamente");
                return;
            }

            if (comboBoxCliente.Text.Length == 0)
            {
                MessageBox.Show("Por favor, complete el campo Cliente e inténtelo nuevamente");
                return;
            }

            /*if (monthCalendar1.Text.Length == 0)
            {
                MessageBox.Show("Por favor, complete el campo Fecha de vencimiento e inténtelo nuevamente");
                return;
            }*/

            if (textBoxFechaAlta.Text.Length == 0)
            {
                MessageBox.Show("Por favor, complete el campo Fecha de Alta e inténtelo nuevamente");
                return;
            }

            if (textBoxTotal.Text.Length == 0)
            {
                MessageBox.Show("Por favor, complete el campo Fecha de Total e inténtelo nuevamente");
                return;
            }

            if (textBoxItemMonto.Text.Length == 0)
            {
                MessageBox.Show("Por favor, complete el campo Item Monto e inténtelo nuevamente");
                return;
            }

            if (textBoxItemCantidad.Text.Length == 0)
            {
                MessageBox.Show("Por favor, complete el campo Item Cantidad e inténtelo nuevamente");
                return;
            }
            
            if (facturaNoEstaRepetido(Convert.ToInt64(textBoxNroFac.Text)))
            {
                darAltaFactura(Convert.ToInt64(textBoxNroFac.Text), comboBoxEmpresa.Text, comboBoxCliente.Text, monthCalendar1.Text, textBoxFechaAlta.Text, textBoxTotal.Text, textBoxItemMonto.Text, textBoxItemCantidad.Text);
            }
            else
            {
                MessageBox.Show("La factura ingresada ya se encuentra registrada, intente con otra.", "Error");
            }
            
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            if (labelTitulo.Text == "ALTA")
            {
                accionBotonAlta();
            }
            else if (labelTitulo.Text == "MODIFICACION")
            {
                //accionBotonModificacion();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
