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
            comboBoxFiltro.Items.Add("NroFactura");
            comboBoxFiltro.Items.Add("Empresa");
            comboBoxFiltro.Items.Add("Cliente");
            ocultarTodosLosItems();
            llenarComboBoxEmpresa();
            llenarComboBoxCliente();
            llenarFechaAlta();
        }

        private Decimal totalItems = 0;
        private bool seModificanItems = false;
        private int idFacturaSinModificar = 0;
        
        private void ocultarTodosLosItems()
        {
            labelNroFac.Visible = false;
            maskedTextBoxNroFact.Visible = false;
            labelEmpresa.Visible = false;
            comboBoxEmpresa.Visible = false;
            labelCliente.Visible = false;
            comboBoxCliente.Visible = false;
            labelFechaDeVenc.Visible = false;
            dtFechaVen.Visible = false;
            buttonCrearFactura.Visible = false;
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
            buttonAgregarItem.Visible = false;
            labelItemsAAgregar.Visible = false;
            listBoxItems.Visible = false;
            labelDatosFactura.Visible = false;
            labelDatosItem.Visible = false;
            labelItemsAAgregar.Visible = false;
            buttonLimpiarItems.Visible = false;
            labelFiltro.Visible = false;
            comboBoxFiltro.Visible = false;
            buttonBuscar.Visible = false;
            labelFacturasEncontradas.Visible = false;
            comboBoxFacturasEncontradas.Visible = false;
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
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT TOP 50 cli_nombre + '/' + cli_apellido FROM GOQ.Cliente",
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
            maskedTextBoxNroFact.Text = "";
            comboBoxEmpresa.Text = "";
            comboBoxCliente.Text = "";
            dtFechaVen.Text = "";
            textBoxTotal.Text = "0";
            totalItems = 0;
        }

        private void mostrarAlta()
        {
            labelNroFac.Visible = true;
            maskedTextBoxNroFact.Visible = true;
            labelEmpresa.Visible = true;
            comboBoxEmpresa.Visible = true;
            labelCliente.Visible = true;
            comboBoxCliente.Visible = true;
            labelFechaDeVenc.Visible = true;
            dtFechaVen.Visible = true;
            buttonCrearFactura.Visible = true;
            buttonLimpiar.Visible = true;
            labelTitulo.Visible = true;
            labelFechaAlta.Visible = true;
            textBoxFechaAlta.Visible = true;
            textBoxTotal.Visible = true;
            labelTotal.Visible = true;
            labelDatosFactura.Visible = true;
        }

        private void mostrarModificacion()
        {
            labelEmpresa.Visible = true;
            comboBoxEmpresa.Visible = true;
            labelFechaDeVenc.Visible = true;
            dtFechaVen.Visible = true;
            buttonCrearFactura.Visible = true;
            buttonLimpiar.Visible = true;
            labelTitulo.Visible = true;
            textBoxTotal.Visible = true;
            labelTotal.Visible = true;
            labelDatosFactura.Visible = true;
            labelCliente.Visible = true;
            comboBoxCliente.Visible = true;
            labelNroFac.Visible = true;
            maskedTextBoxNroFact.Visible = true;
            maskedTextBoxNroFact.ReadOnly = true;
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ocultarTodosLosItems();
            limpiarCampos();
            labelTitulo.Text = "ALTA";
            mostrarAlta();
            mostrarItems();
            textBoxTotal.Text = totalItems.ToString();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            limpiarCamposItems();
        }

       
        private bool facturaNoEstaRepetido(decimal NroFac)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT fac_id FROM GOQ.Factura WHERE fac_id = @NroFac", PagoAgilFrba.ModuloGlobal.getConexion());
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

        private void darAltaFactura()
        {
           if (listBoxItems.Items.Count > 0)
           {
               int filasRetornadas;
               int itemsRetornados;
               string empresa = Convert.ToString(comboBoxEmpresa.Text);
               string[] camposABuscar = comboBoxCliente.SelectedItem.ToString().Replace(" ", "").Split(new Char[] { '/' });
               string nombre = Convert.ToString(camposABuscar[0]);
               string apellido = Convert.ToString(camposABuscar[1]);
               decimal total = Convert.ToDecimal(textBoxTotal.Text);

               SqlParameter[] sqls = new SqlParameter[7];
               sqls[0] = new SqlParameter("nroFact", Convert.ToDecimal(maskedTextBoxNroFact.Text));
               sqls[1] = new SqlParameter("empresa", empresa);
               sqls[2] = new SqlParameter("nombre", nombre);
               sqls[3] = new SqlParameter("apellido", apellido);
               sqls[4] = new SqlParameter("fechaVen", dtFechaVen.Text);
               sqls[5] = new SqlParameter("fechaAlta", textBoxFechaAlta.Text);
               sqls[6] = new SqlParameter("total", total);

               SqlCommand cmd1 = new SqlCommand("GOQ.SP_Insertar_Factura", PagoAgilFrba.ModuloGlobal.getConexion());
               cmd1.CommandType = CommandType.StoredProcedure;
               cmd1.Parameters.AddRange(sqls);
               filasRetornadas = cmd1.ExecuteNonQuery();

               if (filasRetornadas > 0)
               {
                   foreach (string Item in listBoxItems.Items)
                   {
                       
                        string[] monto_cant = Item.Split(new Char[] { '/'});
                       
                        SqlParameter[] sqls1 = new SqlParameter[3];
                        sqls1[0] = new SqlParameter("monto", Convert.ToDecimal(monto_cant[0]));
                        sqls1[1] = new SqlParameter("cantidad", monto_cant[1]);
                        sqls1[2] = new SqlParameter("factura", Convert.ToDecimal(maskedTextBoxNroFact.Text));
                        SqlCommand cmd2 = new SqlCommand("GOQ.SP_Insertar_Item", PagoAgilFrba.ModuloGlobal.getConexion());
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.AddRange(sqls1);
                        itemsRetornados = cmd2.ExecuteNonQuery();

                        if (itemsRetornados > 0)
                        {
                            MessageBox.Show("La factura se ha registrado con éxito!", "Información");
                        }
                        else
                        {
                            MessageBox.Show("Error al insertar los items", "Información");
                        }
                    }
               }
               else
               {
                   MessageBox.Show("Ocurrió un error al intentar registrar la factura", "Error");
               }
            }
        }

        private bool validarListaDeItems()
        {
            if (listBoxItems.Items.Count < 1)
            {
                MessageBox.Show("La factura debe tener al menos un item.", "Error");
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool validarCamposFactura()
        {
            string message = "";
            
            if (maskedTextBoxNroFact.Text.Length == 0)
            {
                message = message + "Nro Factura, ";
            }

            if (comboBoxEmpresa.Text.Length == 0)
            {
                message = message + "Empresa, ";
            }

            if (comboBoxCliente.Text.Length == 0)
            {
                message = message + "Cliente, ";
            }

            if (dtFechaVen.Value == null)
            {
                message = message + "Fecha de vencimiento, ";
            }

            if (message != "")
            {
                MessageBox.Show("Por favor, complete: " + message + "requeridos correctamente.", "Error");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void accionBotonAlta()
        {
            if (validarCamposFactura() && validarListaDeItems())
            {
                if (facturaNoEstaRepetido(Convert.ToDecimal(maskedTextBoxNroFact.Text)))
                {
                    darAltaFactura();
                }
                else
                {
                    MessageBox.Show("La factura ingresada ya se encuentra registrada, intente con otra.", "Error");
                }
            }
        }

        private void modificarFactura()
        {
            string empresa= Convert.ToString(comboBoxEmpresa.Text);
            string[] camposABuscar = comboBoxCliente.SelectedItem.ToString().Replace(" ", "").Split(new Char[] { '/' });
            string nombre = Convert.ToString(camposABuscar[0]);
            string apellido = Convert.ToString(camposABuscar[1]);
            int filasRetornadas;
            int itemsRetornados = 0;
            int itemsBorrados;
            int filasRetornadas_fac;

            if(seModificanItems)
            {
                SqlParameter[] sqls = new SqlParameter[6];
                sqls[0] = new SqlParameter("empresa", empresa);
                sqls[1] = new SqlParameter("nombre", nombre);
                sqls[2] = new SqlParameter("apellido", apellido);
                sqls[3] = new SqlParameter("fechaVen", dtFechaVen.Text);
                sqls[4] = new SqlParameter("total", Convert.ToDecimal(textBoxTotal.Text));
                sqls[5] = new SqlParameter("nroFact", idFacturaSinModificar);
                
                SqlCommand cmd1 = new SqlCommand("GOQ.SP_Modificar_Factura", PagoAgilFrba.ModuloGlobal.getConexion());
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddRange(sqls);
                filasRetornadas = cmd1.ExecuteNonQuery();

               if (filasRetornadas > 0)
               {
                   SqlParameter[] sqls2 = new SqlParameter[1];
                   sqls2[0] = new SqlParameter("nroFact", idFacturaSinModificar);

                   SqlCommand cmd3 = new SqlCommand("GOQ.SP_Borrar_Items", PagoAgilFrba.ModuloGlobal.getConexion());
                   cmd3.CommandType = CommandType.StoredProcedure;
                   cmd3.Parameters.AddRange(sqls2);
                   itemsBorrados = cmd3.ExecuteNonQuery();

                   if (itemsBorrados > 0)
                   {
                       foreach (string Item in listBoxItems.Items)
                       {
                           string[] monto_cant = Item.Split(new Char[] { '/' });

                           SqlParameter[] sqls1 = new SqlParameter[3];
                           sqls1[0] = new SqlParameter("monto", Convert.ToDecimal(monto_cant[0]));
                           sqls1[1] = new SqlParameter("cantidad", Convert.ToDecimal(monto_cant[1]));
                           sqls1[2] = new SqlParameter("factura", idFacturaSinModificar);
                           SqlCommand cmd2 = new SqlCommand("GOQ.SP_Insertar_Item", PagoAgilFrba.ModuloGlobal.getConexion());
                           cmd2.CommandType = CommandType.StoredProcedure;
                           cmd2.Parameters.AddRange(sqls1);
                           itemsRetornados = cmd2.ExecuteNonQuery();
                       }
                       if (itemsRetornados > 0)
                       {
                           MessageBox.Show("La factura se ha modificado con éxito!", "Información");
                       }
                       else
                       {
                           MessageBox.Show("Error al insertar los items", "Información");
                       }
                   }
                   
               }
               else
               {
                   MessageBox.Show("La factura no se ha modificado con éxito!", "Información");
               }
            }
            else
            {
                SqlParameter[] sqls = new SqlParameter[5];
                sqls[0] = new SqlParameter("empresa", empresa);
                sqls[1] = new SqlParameter("nombre", nombre);
                sqls[2] = new SqlParameter("apellido", apellido);
                sqls[3] = new SqlParameter("fechaVen", dtFechaVen.Text);
                sqls[4] = new SqlParameter("nroFact", idFacturaSinModificar);

                SqlCommand cmd1 = new SqlCommand("GOQ.SP_Modificar_Factura_PeroNoItems", PagoAgilFrba.ModuloGlobal.getConexion());
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddRange(sqls);
                filasRetornadas_fac = cmd1.ExecuteNonQuery();

                if (filasRetornadas_fac > 0)
                {
                    MessageBox.Show("La factura se ha modificado con éxito!", "Información");
                }
                else
                {
                    MessageBox.Show("Error al modificar la factura", "Información");
                }
            }
        }

        private void accionBotonModificacion()
        {
           if (validarCamposFactura())
           {
               if (seModificanItems)
               {
                   if (validarListaDeItems())
                   {
                       modificarFactura();
                   }
               }
               else
               {
                   modificarFactura();
               }
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
                accionBotonModificacion();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAgregarItem_Click(object sender, EventArgs e)
        {
            string message_items = "";
            decimal esNumero;

            if (textBoxItemMonto.Text.Length == 0)
            {
                message_items = message_items + "Monto, ";
            }

            if (textBoxItemCantidad.Text.Length == 0)
            {
                message_items = message_items + "Cantidad, ";
            }
            
            if (message_items != "")
            {
                MessageBox.Show("Por favor, complete: \n" + message_items + "requerido/os", "Error");
            }
            else{
                if (decimal.TryParse(textBoxItemMonto.Text.ToString(), out esNumero) && decimal.TryParse(textBoxItemCantidad.Text.ToString(), out esNumero))
                {
                    listBoxItems.Items.Add(textBoxItemMonto.Text + "/" + textBoxItemCantidad.Text);

                    int cantidad = Convert.ToInt32(textBoxItemCantidad.Text);
                    decimal monto = Convert.ToDecimal(textBoxItemMonto.Text);
                    decimal montoxcant = cantidad * monto;
                    totalItems = totalItems + montoxcant;
                    textBoxTotal.Text = Convert.ToString(totalItems);

                    decimal totalFactura = Convert.ToDecimal(textBoxTotal.Text);

                    textBoxItemMonto.Text = "";
                    textBoxItemCantidad.Text = "";
                }
                else
                {
                    MessageBox.Show("Los campos ingresados deben ser numéricos.", "Error");
                }
            }
        }

        private void buttonLimpiarItems_Click(object sender, EventArgs e)
        {
            listBoxItems.Items.Clear();
            textBoxItemMonto.Text = "";
            textBoxItemCantidad.Text = "";
            totalItems = 0;
            textBoxTotal.Text = "0";
        }

        private void labelItemMonto_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBoxTotal_(object sender, EventArgs e)
        {

        }

        private void mostrarBusqueda()
        {
            labelTitulo.Visible = true;
            labelFiltro.Visible = true;
            comboBoxFiltro.Visible = true;
        }

        private void modificaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ocultarTodosLosItems();
            limpiarCampos();
            labelTitulo.Text = "MODIFICACION";
            mostrarBusqueda();
        }

        private void comboBoxFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            ocultarTodosLosItems();
            labelTitulo.Visible = true;
            labelFiltro.Visible = true;
            comboBoxFiltro.Visible = true;

            
            if (comboBoxFiltro.SelectedItem.ToString() == "NroFactura")
            {
                labelNroFac.Visible = true;
                maskedTextBoxNroFact.Visible = true;
                buttonBuscar.Visible = true;
                buttonLimpiar.Visible = true;

            }
            else if (comboBoxFiltro.SelectedItem.ToString() == "Empresa")
            {
                labelEmpresa.Visible = true;
                comboBoxEmpresa.Visible = true;
                buttonBuscar.Visible = true;
                buttonLimpiar.Visible = true;
            }
            else if (comboBoxFiltro.SelectedItem.ToString() == "Cliente")
            {
                labelCliente.Visible = true;
                comboBoxCliente.Visible = true;
                buttonBuscar.Visible = true;
                buttonLimpiar.Visible = true;
            }
        }

        private bool realizarBusquedayDevolverResultado()
        {
            comboBoxFacturasEncontradas.Items.Clear();
            
            if (comboBoxFiltro.SelectedItem.ToString() == "NroFactura")
            {
                int fac_id = Convert.ToInt32(maskedTextBoxNroFact.Text);

                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("select CONVERT(varchar(50), f.fac_id) + '/' + e.empresa_nombre + '/' + c.cli_nombre + '/' + c.cli_apellido from GOQ.Factura as f inner join GOQ.Empresa as e on e.ID_empresa = f.fac_empresa_id inner join GOQ.Cliente as c on c.cli_id = f.fac_cli_id left join GOQ.Pago_Factura as pf on pf.pago_fac_fac_id = f.fac_id where f.fac_id = @nroFactura and pf.pago_fac_fac_id IS NULL and f.fac_ren_id IS NULL;",
                PagoAgilFrba.ModuloGlobal.getConexion());
                cmd.Parameters.Add("nroFactura", SqlDbType.Int).Value = fac_id;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxFacturasEncontradas.Items.Add(reader.GetString(0));
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
            else if (comboBoxFiltro.SelectedItem.ToString() == "Empresa")
            {
                string empresa = Convert.ToString(comboBoxEmpresa.Text);
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("select CONVERT(varchar(50), f.fac_id) + '/' + e.empresa_nombre + '/' + c.cli_nombre + '/' + c.cli_apellido from GOQ.Factura as f inner join GOQ.Empresa as e on e.ID_empresa = f.fac_empresa_id inner join GOQ.Cliente as c on c.cli_id = f.fac_cli_id left join GOQ.Pago_Factura as pf on pf.pago_fac_fac_id = f.fac_id where e.empresa_nombre = @empresa and pf.pago_fac_fac_id IS NULL and f.fac_ren_id IS NULL;",
                PagoAgilFrba.ModuloGlobal.getConexion());
                cmd.Parameters.Add("empresa", SqlDbType.NVarChar).Value = empresa;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBoxFacturasEncontradas.Items.Add(reader.GetString(0));
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
                string[] camposABuscar = comboBoxCliente.SelectedItem.ToString().Replace(" ", "").Split(new Char[] { '/' });
                string nombre = Convert.ToString(camposABuscar[0]);
                string apellido = Convert.ToString(camposABuscar[1]);
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("select CONVERT(varchar(50), f.fac_id) + '/' + e.empresa_nombre + '/' + c.cli_nombre + '/' + c.cli_apellido from GOQ.Factura as f inner join GOQ.Empresa as e on e.ID_empresa = f.fac_empresa_id inner join GOQ.Cliente as c on c.cli_id = f.fac_cli_id left join GOQ.Pago_Factura as pf on pf.pago_fac_fac_id = f.fac_id where c.cli_nombre = @nombre and c.cli_apellido = @apellido and pf.pago_fac_fac_id IS NULL and f.fac_ren_id IS NULL;",
                PagoAgilFrba.ModuloGlobal.getConexion());
                cmd.Parameters.Add("nombre", SqlDbType.NVarChar).Value = nombre;
                cmd.Parameters.Add("apellido", SqlDbType.NVarChar).Value = apellido;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxFacturasEncontradas.Items.Add(reader.GetString(0));
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
            labelFacturasEncontradas.Visible = true;
            comboBoxFacturasEncontradas.Visible = true;
        }
       
        private void buttonBuscar_Click(object sender, EventArgs e)
        {

            if (comboBoxFiltro.SelectedItem.ToString() == "NroFactura" && maskedTextBoxNroFact.Text.Length == 0)
            {
                MessageBox.Show("Por favor, complete el número de factura.");
            }
            else if (comboBoxFiltro.SelectedItem.ToString() == "Empresa" && comboBoxEmpresa.Text.Length == 0)
            {
                MessageBox.Show("Por favor, elija una empresa.");
            }
            else if (comboBoxFiltro.SelectedItem.ToString() == "Cliente" && comboBoxCliente.Text.Length == 0)
            {
                MessageBox.Show("Por favor, elija un cliente.");
            }
            else
            {
                if (realizarBusquedayDevolverResultado())
                {
                    MessageBox.Show("La factura fue encontrada.", "Información");
                    mostrarResultadosBusqueda();
                }
                else
                {
                    MessageBox.Show("La factura no ha sido encontrada, puede que su factura ya se haya pagado o rendido.", "Error");
                }
            }
        }

        private void llenarCamposParaModificar(int fac_id)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("select f.fac_id, e.empresa_nombre, c.cli_nombre + '/' + c.cli_apellido, f.fac_fecha_vec, f.fac_total from GOQ.Factura as f inner join GOQ.Empresa as e on e.ID_empresa = f.fac_empresa_id inner join GOQ.Cliente as c on c.cli_id = f.fac_cli_id where f.fac_id = @nroFactura; ",
            PagoAgilFrba.ModuloGlobal.getConexion());
            cmd.Parameters.Add("nroFactura", SqlDbType.Int).Value = fac_id;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                maskedTextBoxNroFact.Text = Convert.ToString(reader.GetValue(0));
                comboBoxEmpresa.Text = reader.GetString(1);
                comboBoxCliente.Text = reader.GetString(2);
                dtFechaVen.Value = Convert.ToDateTime(reader.GetValue(3));
                textBoxTotal.Text = Convert.ToString(reader.GetValue(4));
                idFacturaSinModificar = Convert.ToInt32(reader.GetValue(0));
            }
            else
            {
                MessageBox.Show("Ocurrió un error al obtener los datos de la factura.", "Error");
            }
            reader.Close();
        }

        private void ocultarItems()
        {
            labelDatosItem.Visible = false;
            labelItemsAAgregar.Visible = false;
            buttonLimpiarItems.Visible = false;
        }

        private void mostrarItems()
        {
            labelDatosItem.Visible = true;
            labelItemsAAgregar.Visible = true;
            buttonLimpiarItems.Visible = true;
            labelItemMonto.Visible = true;
            textBoxItemMonto.Visible = true;
            labelItemCantidad.Visible = true;
            textBoxItemCantidad.Visible = true;
            listBoxItems.Visible = true;
            buttonAgregarItem.Visible = true;
        }

        private void limpiarCamposItems()
        {
            listBoxItems.Items.Clear();
            textBoxItemMonto.Text = "";
            textBoxItemCantidad.Text = "";
        }
        private void comboBoxFacturasEncontradas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (labelTitulo.Text == "MODIFICACION")
            {
                if (MessageBox.Show("¿Desea modificar la factura seleccionada?", "Información",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ocultarTodosLosItems();
                    string[] camposABuscar = comboBoxFacturasEncontradas.SelectedItem.ToString().Replace(" ", "").Split(new Char[] { '/' });
                    limpiarCampos();
                    //IDFACTURA
                    llenarCamposParaModificar(Convert.ToInt32(camposABuscar[0]));
                    mostrarModificacion();

                    if (MessageBox.Show("¿Desea modificar los items?", "Información",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        limpiarCamposItems();
                        int fac_id = Convert.ToInt32(camposABuscar[0]);
                        totalItems = 0;

                        SqlDataReader reader = null;
                        SqlCommand cmd = new SqlCommand("select Monto,Cantidad from GOQ.Item where fac_id = @nroFactura;",
                        PagoAgilFrba.ModuloGlobal.getConexion());
                        cmd.Parameters.Add("nroFactura", SqlDbType.Int).Value = fac_id;
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            decimal monto = Convert.ToDecimal(reader.GetValue(0));
                            int cantidad = Convert.ToInt32(reader.GetValue(1));
                            decimal montoxcant = cantidad * monto;
                            totalItems = totalItems + montoxcant;
                            listBoxItems.Items.Add(Convert.ToString(reader.GetValue(0)) + "/" + Convert.ToString(reader.GetValue(1)));
                        }
                        textBoxTotal.Text = Convert.ToString(totalItems);
                        mostrarItems();
                        seModificanItems = true;
                    }
                }
            }
            else
            {
                if (MessageBox.Show("¿Desea eliminar la factura seleccionada?", "Información",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int itemsBorrados = 0;
                    
                    string[] camposABuscar = comboBoxFacturasEncontradas.SelectedItem.ToString().Replace(" ", "").Split(new Char[] { '/' });
                    //nrofactura
                    SqlParameter[] sqls2 = new SqlParameter[1];
                    sqls2[0] = new SqlParameter("nroFact", Convert.ToInt32(camposABuscar[0]));

                    SqlCommand cmd3 = new SqlCommand("GOQ.SP_Borrar_Factura_Items", PagoAgilFrba.ModuloGlobal.getConexion());
                    cmd3.CommandType = CommandType.StoredProcedure;
                    cmd3.Parameters.AddRange(sqls2);
                    itemsBorrados = Convert.ToInt32(cmd3.ExecuteNonQuery());
                    
                    if (itemsBorrados > 0)
                    {
                        MessageBox.Show("La factura y sus items se han borrado con exito", "Información");
                    }
                }
            }
        }

        private void labelTotal_Click(object sender, EventArgs e)
        {

        }

        private void bajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ocultarTodosLosItems();
            limpiarCampos();
            labelTitulo.Text = "BAJA";
            mostrarBusqueda();
        }
    }
}
