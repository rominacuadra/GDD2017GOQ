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
using System.Configuration;

namespace PagoAgilFrba.RegistroPago
{
    public partial class RegistroPago : Form
    {
        public RegistroPago()
        {
            InitializeComponent();
            ocultarElementos();
            llenarComboBoxFiltro();
            llenarComboBoxEmpresa();
            llenarComboBoxCliente();
            llenarComboBoxTipoPago();
        }

        private void llenarComboBoxFiltro()
        {
            comboBoxFiltro.Items.Add("Nro de Factura");
            comboBoxFiltro.Items.Add("Empresa");
            comboBoxFiltro.Items.Add("Cliente");
        }

        private void mostrarResultadosFacturas()
        {
            comboBoxFacEnc.Visible = true;

            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT cli_dni FROM GOQ.Cliente WHERE cli_habilitado = 1",
                PagoAgilFrba.ModuloGlobal.getConexion());
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxFacEnc.Items.Add((Convert.ToString(reader.GetValue(0))));
            }
            reader.Close();

        }

        private void llenarComboBoxEmpresa()
        {

            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT empresa_nombre + '/' + empresa_cuit FROM GOQ.Empresa WHERE empresa_habilitado = 1",
                PagoAgilFrba.ModuloGlobal.getConexion());
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxEmp.Items.Add(Convert.ToString(reader.GetValue(0)));
            }
            reader.Close();
        }

        private void llenarComboBoxCliente()
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT cli_dni FROM GOQ.Cliente WHERE cli_habilitado = 1 order by cli_dni ASC",
                PagoAgilFrba.ModuloGlobal.getConexion());
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxCli.Items.Add(Convert.ToString(reader.GetValue(0)));
            }
            reader.Close();
        }

        private void llenarComboBoxTipoPago()
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT tipo_pago_descripcion FROM GOQ.Tipo_Pago",
                PagoAgilFrba.ModuloGlobal.getConexion());
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxTipoPago.Items.Add(Convert.ToString(reader.GetValue(0)));
            }
            reader.Close();
        }

        private void ocultarElementos()
        {
            labelNroFac.Visible = false;
            labelImporte.Visible = false;
            labelFechaVenc.Visible = false;
            labelFechaCobro.Visible = false;
            labelEmp.Visible = false;
            labelCli.Visible = false;
            labelSuc.Visible = false;
            labelTipoPago.Visible = false;
            labelRCli.Visible = false;
            labelREmp.Visible = false;
            labelRFechaCob.Visible = false;
            labelRFechaVenc.Visible = false;
            labelRImp.Visible = false;
            labelRNroFac.Visible = false;
            labelRSuc.Visible = false;
            textBoxNroFact.Visible = false;
            comboBoxCli.Visible = false;
            comboBoxEmp.Visible = false;
            buttonFact.Visible = false;
            buttonBuscar.Visible = false;
            comboBoxTipoPago.Visible = false;
            labelFacEnc.Visible = false;
            comboBoxFacEnc.Visible = false;
        }

        private void mostrarDatosDeFactura()
        {
            labelNroFac.Visible = true;
            labelImporte.Visible = true;
            labelFechaVenc.Visible = true;
            labelFechaCobro.Visible = true;
            labelEmp.Visible = true;
            labelCli.Visible = true;
            labelSuc.Visible = true;
            labelTipoPago.Visible = true;
            labelRCli.Visible = true;
            labelREmp.Visible = true;
            labelRFechaCob.Visible = true;
            labelRFechaVenc.Visible = true;
            labelRImp.Visible = true;
            labelRNroFac.Visible = true;
            labelRSuc.Visible = true;
            comboBoxTipoPago.Visible = true;
            buttonFact.Visible = true;

        }

        private bool esFacturaValidaParaElPago(int NroFac)
        {
            var appSettings = ConfigurationManager.AppSettings;
            DateTime fechaActual = Convert.ToDateTime(appSettings["fechaActual"]);
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("select fac_id from GOQ.Factura f left join GOQ.Pago_factura pf on(f.fac_id = pf.pago_fac_fac_id) left join GOQ.Devolucion d on(f.fac_id = d.dev_fac_id) left join GOQ.Rendicion r on(f.fac_ren_id = r.ren_id) inner join GOQ.Cliente c on (f.fac_cli_id = c.cli_id) inner join GOQ.Empresa e on(e.ID_empresa = f.fac_empresa_id) where fac_id = @nroFac and c.cli_habilitado = 1 and e.empresa_habilitado = 1 and f.fac_fecha_vec <= @fechaActual and f.fac_total > 0 group by fac_id having (COUNT(pf.pago_fac_fac_id) = COUNT(d.dev_fac_id)) and COUNT(r.ren_id)=0;", PagoAgilFrba.ModuloGlobal.getConexion());
            cmd.Parameters.Add("nroFac", SqlDbType.Int).Value = NroFac;
            cmd.Parameters.Add("fechaActual", SqlDbType.DateTime).Value = fechaActual;
            reader = cmd.ExecuteReader();
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

        private void buscarPorNroFactSeleccionado(int NroFac)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string fechaActual = appSettings["fechaActual"];
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT fac_id, empresa_nombre, cli_dni, fac_fecha_vec, fac_total FROM GOQ.Factura f INNER JOIN GOQ.Empresa e ON (f.fac_empresa_id = e.ID_empresa) INNER JOIN GOQ.Cliente c ON (c.cli_id = f.fac_cli_id) WHERE fac_id = @NROFACT AND empresa_habilitado = 1 AND cli_habilitado = 1",
                PagoAgilFrba.ModuloGlobal.getConexion()); //Probar este getConexion
            cmd.Parameters.Add("NROFACT", SqlDbType.Decimal).Value = NroFac;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                labelRNroFac.Text = Convert.ToString(reader.GetValue(0));
                labelREmp.Text = Convert.ToString(reader.GetValue(1));
                labelRCli.Text = Convert.ToString(reader.GetValue(2));
                labelRFechaVenc.Text = Convert.ToString(reader.GetValue(3));
                labelRImp.Text = Convert.ToString(reader.GetValue(4));
                labelRFechaCob.Text = fechaActual;
                labelRSuc.Text = PagoAgilFrba.ModuloGlobal.suc_cob_id;
            }
            else
            {
                MessageBox.Show("La factura no fue encontrada o no se encuentra disponible para el pago.", "Error");
            }
            reader.Close();
        }

        private void llenarFacturasEncontradasPorCliente(int DNICli)
        {
            var appSettings = ConfigurationManager.AppSettings;
            DateTime fechaActual = Convert.ToDateTime(appSettings["fechaActual"]);
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT fac_id, fac_fecha_vec, fac_total FROM GOQ.Factura f INNER JOIN GOQ.Empresa e ON (f.fac_empresa_id = e.ID_empresa) INNER JOIN GOQ.Cliente c ON (f.fac_cli_id = c.cli_id) left join GOQ.Pago_factura pf on(f.fac_id = pf.pago_fac_fac_id) left join GOQ.Devolucion d on(f.fac_id = d.dev_fac_id) left join GOQ.Rendicion r on(f.fac_ren_id = r.ren_id) WHERE cli_dni = @DNICLI AND empresa_habilitado = 1 AND cli_habilitado = 1 AND f.fac_fecha_vec <= @FECHAACTUAL and f.fac_total > 0 group by fac_id, fac_fecha_vec, fac_total having (COUNT(pf.pago_fac_fac_id) = COUNT(d.dev_fac_id)) and COUNT(r.ren_id)=0 order by fac_id ASC;",
                PagoAgilFrba.ModuloGlobal.getConexion());
            cmd.Parameters.Add("DNICLI", SqlDbType.Decimal).Value = DNICli;
            cmd.Parameters.Add("FECHAACTUAL", SqlDbType.DateTime).Value = fechaActual;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    comboBoxFacEnc.Items.Add("Factura: " + Convert.ToString(reader.GetValue(0)) + " Fecha Vencimiento: " + Convert.ToString(reader.GetValue(1)) + " Importe: " + Convert.ToString(reader.GetValue(2)));
                    
                }
                reader.Close();
            }
            else
            {
                MessageBox.Show("Ocurrio un error en la consulta, intente nuevamente.", "Error");
            }
        }

        private void llenarFacturasEncontradasPorEmpresa(string EmpresaNom, string EmpresaCUIT)
        {
            var appSettings = ConfigurationManager.AppSettings;
            DateTime fechaActual = Convert.ToDateTime(appSettings["fechaActual"]);
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT fac_id, fac_fecha_vec, fac_total FROM GOQ.Factura f INNER JOIN GOQ.Empresa e ON (f.fac_empresa_id = e.ID_empresa) INNER JOIN GOQ.Cliente c ON (f.fac_cli_id = c.cli_id) left join GOQ.Pago_factura pf on(f.fac_id = pf.pago_fac_fac_id) left join GOQ.Devolucion d on(f.fac_id = d.dev_fac_id) left join GOQ.Rendicion r on(f.fac_ren_id = r.ren_id) WHERE empresa_cuit = @EMPRESACUIT AND empresa_habilitado = 1 AND cli_habilitado = 1 AND f.fac_fecha_vec <= @FECHAACTUAL  and f.fac_total > 0 group by fac_id, fac_fecha_vec, fac_total having (COUNT(pf.pago_fac_fac_id) = COUNT(d.dev_fac_id)) and COUNT(r.ren_id)=0 order by fac_id ASC;",
                PagoAgilFrba.ModuloGlobal.getConexion());
            cmd.Parameters.Add("FECHAACTUAL", SqlDbType.DateTime).Value = fechaActual;
            cmd.Parameters.Add("EMPRESACUIT", SqlDbType.NVarChar).Value = EmpresaCUIT;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    comboBoxFacEnc.Items.Add("Factura: " + Convert.ToString(reader.GetValue(0)) + " Fecha Vencimiento: " + Convert.ToString(reader.GetValue(1)) + " Importe: " + Convert.ToString(reader.GetValue(2)));
                   
                }
                reader.Close();
            }
            else
            {
                MessageBox.Show("Ocurrio un error en la consulta, intente nuevamente.", "Error");
            }
        }

        private int buscarIDSucursal(string sucursal)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT sucu_id FROM GOQ.Sucursal WHERE sucu_nombre = @NOMSUCU",
                PagoAgilFrba.ModuloGlobal.getConexion());

            cmd.Parameters.Add("NOMSUCU", SqlDbType.NVarChar).Value = sucursal;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                return Convert.ToInt32(reader.GetValue(0));
            }
            else
            {
                return 1;
            }
        }

        private void registrarPagoParaLasFacturasDeLaLista()
        {


            //----------
            var appSettings = ConfigurationManager.AppSettings;
            DateTime fechaActual = Convert.ToDateTime(appSettings["fechaActual"]);
            int IDSucursal = 0;
            int insert = 0;
            int IDPago = -1;
            IDSucursal = buscarIDSucursal(PagoAgilFrba.ModuloGlobal.suc_cob_id);
            bool error = false;
            foreach (string Item in listBoxFacturas.Items)
            {
                string[] direccion = Item.Split(new Char[] { '-', ':' });
                SqlDataReader reader = null;
                //Select que devuelve los datos de la factura
                SqlCommand cmd = new SqlCommand("SELECT f.fac_cli_id, tp.tipo_pago_id FROM GOQ.Factura f, GOQ.Tipo_Pago tp WHERE fac_id = @NROFACT AND tipo_pago_descripcion = @TIPOPAGO",
                    PagoAgilFrba.ModuloGlobal.getConexion());

                cmd.Parameters.Add("NROFACT", SqlDbType.Decimal).Value = Convert.ToInt32(direccion[1]);
                cmd.Parameters.Add("TIPOPAGO", SqlDbType.NVarChar).Value = direccion[3];
                reader = cmd.ExecuteReader();
                reader.Read();

                SqlCommand cmd2 = new SqlCommand("INSERT INTO GOQ.Pago (pago_fecha_cobro , pago_cliente_id, pago_importe, pago_tipo_id, pago_sucursal_id) VALUES (@FECHACOBRO, @CLI_ID, @IMP, @TIPO, @SUCU); SELECT SCOPE_IDENTITY();",
                    PagoAgilFrba.ModuloGlobal.getConexion());
                cmd2.Parameters.Add("FECHACOBRO", SqlDbType.DateTime).Value = fechaActual;
                cmd2.Parameters.Add("CLI_ID", SqlDbType.Int).Value = Convert.ToInt32(reader.GetValue(0));
                cmd2.Parameters.Add("IMP", SqlDbType.Decimal).Value = Convert.ToDecimal(direccion[5]);
                cmd2.Parameters.Add("TIPO", SqlDbType.Int).Value = Convert.ToInt32(reader.GetValue(1));
                cmd2.Parameters.Add("SUCU", SqlDbType.Int).Value = IDSucursal;
                IDPago = Convert.ToInt32(cmd2.ExecuteScalar());

                reader.Close();

                SqlCommand cmd3 = new SqlCommand("INSERT INTO GOQ.Pago_Factura VALUES(@PAGOID, @FACID)",
                PagoAgilFrba.ModuloGlobal.getConexion());

                cmd3.Parameters.Add("FACID", SqlDbType.Decimal).Value = Convert.ToInt32(direccion[1]);
                cmd3.Parameters.Add("PAGOID", SqlDbType.Decimal).Value = IDPago;
                insert = cmd3.ExecuteNonQuery();
                if (insert > 0)
                {
                    error = false;
                }
                else
                {
                    error = true;
                }
            }
            if (error)
            {
                MessageBox.Show("Ocurrió un error al intentar pagar la factura.", "Error");
            }
            else
            {
                MessageBox.Show("Las facturas han sido pagadas.", "Información");
            }
            listBoxFacturas.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            ocultarElementos();
            if (comboBoxFiltro.SelectedItem.ToString() == "Nro de Factura")
            {
                labelNroFac.Visible = true;
                textBoxNroFact.Visible = true;
            }
            else if (comboBoxFiltro.SelectedItem.ToString() == "Empresa")
            {
                labelEmp.Visible = true;
                comboBoxEmp.Visible = true;
            }
            else
            {
                labelCli.Visible = true;
                comboBoxCli.Visible = true;
            }
            buttonBuscar.Visible = true;
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            ocultarElementos();
            if (comboBoxFiltro.SelectedItem.ToString() == "Nro de Factura")
            {
                int esNumero;
                if (textBoxNroFact.TextLength > 0 && Int32.TryParse(textBoxNroFact.Text.ToString(), out esNumero))
                {
                    if (esFacturaValidaParaElPago(Convert.ToInt32(textBoxNroFact.Text)))
                    {
                        buscarPorNroFactSeleccionado(Convert.ToInt32(textBoxNroFact.Text));
                        mostrarDatosDeFactura();
                    }
                    else
                    {
                        MessageBox.Show("La factura seleccionada, no se encuentra válida para el pago.", "Error");
                    }

                }
                else
                {
                    MessageBox.Show("Debe ingresar una factura a buscar.", "Error");
                }
            }
            else if (comboBoxFiltro.SelectedItem.ToString() == "Empresa")
            {
                if (comboBoxEmp.SelectedItem.ToString().Length > 0)
                {
                    string[] direccion = comboBoxEmp.SelectedItem.ToString().Split(new Char[] { '/' });
                    llenarFacturasEncontradasPorEmpresa(direccion[0], direccion[1]);
                    comboBoxFacEnc.Visible = true;
                    labelFacEnc.Visible = true;
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una empresa a buscar.", "Error");
                }
            }
            else
            {
                if (comboBoxCli.SelectedItem.ToString().Length > 0)
                {
                    llenarFacturasEncontradasPorCliente(Convert.ToInt32(comboBoxCli.SelectedItem));
                    comboBoxFacEnc.Visible = true;
                    labelFacEnc.Visible = true;
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un cliente a buscar.", "Error");
                }
            }
        }

        private void buttonFact_Click(object sender, EventArgs e)
        {
            if (!comboBoxTipoPago.SelectedIndex.Equals(-1))
            {
                if (listBoxFacturas.Items.Contains("Factura:" + labelRNroFac.Text + "-Tipo:" + comboBoxTipoPago.SelectedItem.ToString() + "-Valor:" + labelRImp.Text))
                {
                    MessageBox.Show("La factura a agregar, ya se encuentra en la lista.", "Error");
                }
                else
                {
                    listBoxFacturas.Items.Add("Factura:" + labelRNroFac.Text + "-Tipo:" + comboBoxTipoPago.SelectedItem.ToString() + "-Valor:" + labelRImp.Text);
                    if (labelRTot.Text == "-")
                    {
                        labelRTot.Text = labelRImp.Text;
                    }
                    else
                    {
                        decimal total = Convert.ToDecimal(labelRTot.Text);
                        decimal importe = Convert.ToDecimal(labelRImp.Text);
                        decimal suma = total + importe;

                        labelRTot.Text = suma.ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un medio de Pago.", "Error");
            }

        }

        private void listBoxFacturas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonQuitar_Click(object sender, EventArgs e)
        {
            if (listBoxFacturas.SelectedItems.Count > 0)
            {
                string[] direccion = listBoxFacturas.SelectedItem.ToString().Split(new Char[] { '-', ':' });
                decimal total = Convert.ToDecimal(labelRTot.Text);
                decimal importe = Convert.ToDecimal(direccion[5]);
                decimal resta = total - importe;
                labelRTot.Text = resta.ToString();
                listBoxFacturas.Items.Remove(listBoxFacturas.SelectedItem);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una factura para quitar de la lista.", "Error");
            }
        }

        private void buttonPagar_Click(object sender, EventArgs e)
        {
            if (listBoxFacturas.Items.Count > 0)
            {
                registrarPagoParaLasFacturasDeLaLista();
                labelRTot.Text = "-";
            }
            else
            {
                MessageBox.Show("Debe agregar al menos una factura para pagar.", "Error");
            }
        }

        private void labelTitulo_Click(object sender, EventArgs e)
        {

        }

        private void textBoxNroFact_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCli_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxEmp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxFacEnc_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (!comboBoxFacEnc.SelectedItem.Equals(-1))
            {

                string[] direccion = comboBoxFacEnc.SelectedItem.ToString().Split(new Char[] { ' ' });
                buscarPorNroFactSeleccionado(Convert.ToInt32(direccion[1]));
                ocultarElementos();
                comboBoxFacEnc.Items.Clear();
                mostrarDatosDeFactura();
            }
        }
    }
}
