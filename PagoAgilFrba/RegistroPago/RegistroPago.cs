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

        private void llenarComboBoxEmpresa()
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT TOP 50 empresa_nombre + '/' + empresa_cuit FROM GOQ.Empresa",
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
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT TOP 50 cli_dni FROM GOQ.Cliente",
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

        private void buscarPorNroFactSeleccionado(int NroFac)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT fac_id, empresa_nombre, cli_dni, fac_fecha_vec, fac_total FROM GOQ.Factura f INNER JOIN GOQ.Empresa e ON (f.fac_empresa_id = e.ID_empresa) INNER JOIN GOQ.Cliente c ON (c.cli_id = f.fac_cli_id) WHERE fac_id = @NROFACT",
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

                labelRFechaCob.Text = DateTime.Today.ToString(); //obtener fecha del sistema
                ;
                //labelRSuc.Text = ; //obtener de la variable global que se genere al ingresar el usuario en el sistema
            }
            else
            {
                MessageBox.Show("La factura no fue encontrada.","Error");
            }
            reader.Close();
        }

        private void buscarPorEmpresaSeleccionada(string EmpresaNom, string EmpresaCUIT)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT fac_id, empresa_nombre, cli_dni, fac_fecha_vec, fac_total FROM GOQ.Factura f INNER JOIN GOQ.Empresa e ON (f.fac_empresa_id = e.ID_empresa) INNER JOIN GOQ.Cliente c ON (c.cli_id = f.fac_cli_id) WHERE empresa_nombre = @EMPRESANOM AND empresa_cuit = @EMPRESACUIT",
                PagoAgilFrba.ModuloGlobal.getConexion()); //Probar este getConexion
            cmd.Parameters.Add("EMPRESANOM", SqlDbType.NVarChar).Value = EmpresaNom;
            cmd.Parameters.Add("EMPRESACUIT", SqlDbType.NVarChar).Value = EmpresaCUIT; 
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                labelRNroFac.Text = Convert.ToString(reader.GetValue(0));
                labelREmp.Text = Convert.ToString(reader.GetValue(1));
                labelRCli.Text = Convert.ToString(reader.GetValue(2));
                labelRFechaVenc.Text = Convert.ToString(reader.GetValue(3));
                labelRImp.Text = Convert.ToString(reader.GetValue(4));

                labelRFechaCob.Text = DateTime.Today.ToString(); //obtener fecha del sistema
                ;
                //labelRSuc.Text = ; //obtener de la variable global que se genere al ingresar el usuario en el sistema
            }
            else
            {
                MessageBox.Show("La factura no fue encontrada.", "Error");
            }
            reader.Close();
        }

        private void buscarPorClienteSeleccionado(int ClienteDNI)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT fac_id, empresa_nombre, cli_dni, fac_fecha_vec, fac_total FROM GOQ.Factura f INNER JOIN GOQ.Empresa e ON (f.fac_empresa_id = e.ID_empresa) INNER JOIN GOQ.Cliente c ON (c.cli_id = f.fac_cli_id) WHERE cli_dni = @DNICLI",
                PagoAgilFrba.ModuloGlobal.getConexion()); //Probar este getConexion
            cmd.Parameters.Add("DNICLI", SqlDbType.Decimal).Value = ClienteDNI;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                labelRNroFac.Text = Convert.ToString(reader.GetValue(0));
                labelREmp.Text = Convert.ToString(reader.GetValue(1));
                labelRCli.Text = Convert.ToString(reader.GetValue(2));
                labelRFechaVenc.Text = Convert.ToString(reader.GetValue(3));
                labelRImp.Text = Convert.ToString(reader.GetValue(4));

                labelRFechaCob.Text = DateTime.Today.ToString(); //obtener fecha del sistema
                //labelRSuc.Text = ; //obtener de la variable global que se genere al ingresar el usuario en el sistema
            }
            else
            {
                MessageBox.Show("La factura no fue encontrada.", "Error");
            }
            reader.Close();
        }

        //FALTA TERMINAR ESTE, SE DEBE INSERTAR TODOS LOS FACTURAS EN LA TABLA DE PAGO
        private void registrarPagoParaLasFacturasDeLaLista()
        {
            int sucursalID = 1; //Deberia reemplazarlo por el que obtenga del menu principal
            foreach(string Item in listBoxFacturas.Items)
            {
                string[] direccion = Item.Split(new Char[] { '-' , ':'});
                SqlDataReader reader = null;
                //cambiar este select por el select insert
                SqlCommand cmd = new SqlCommand("SELECT fac_id, empresa_nombre, cli_dni, fac_fecha_vec, fac_total FROM GOQ.Factura f INNER JOIN GOQ.Empresa e ON (f.fac_empresa_id = e.ID_empresa) INNER JOIN GOQ.Cliente c ON (c.cli_id = f.fac_cli_id) WHERE fac_id = @NROFACT",
                    PagoAgilFrba.ModuloGlobal.getConexion()); //Probar este getConexion

                cmd.Parameters.Add("NROFACT", SqlDbType.Decimal).Value = direccion[1];
                cmd.Parameters.Add("FECHACOBRO", SqlDbType.DateTime).Value = direccion[1];
                cmd.Parameters.Add("TIPOPAGO", SqlDbType.NVarChar).Value = direccion[1];
                cmd.Parameters.Add("SUCU", SqlDbType.Decimal).Value = sucursalID;
                reader = cmd.ExecuteReader();
            }
            listBoxFacturas.Items.Clear();
        }

        ////////////////////COMIENZO ACCIONES


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
            //una vez que devuelvo los resultados, se me muestra el boton agregar junto con los datos
            if (comboBoxFiltro.SelectedItem.ToString() == "Nro de Factura")
            {
                if (textBoxNroFact.TextLength > 0)
                {
                    buscarPorNroFactSeleccionado(Convert.ToInt32(textBoxNroFact.Text));
                    mostrarDatosDeFactura();
                }
                else
                {
                    MessageBox.Show("Debe ingresar una factura a buscar.","Error");
                }
            }
            else if (comboBoxFiltro.SelectedItem.ToString() == "Empresa")
            {
                if (comboBoxEmp.SelectedItem.ToString().Length > 0)
                {
                    string[] direccion = comboBoxEmp.SelectedItem.ToString().Split(new Char[] { '/' });
                    buscarPorEmpresaSeleccionada(direccion[0], direccion[1]);
                    mostrarDatosDeFactura();
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
                    buscarPorClienteSeleccionado(Convert.ToInt32(comboBoxCli.SelectedItem));
                    mostrarDatosDeFactura();
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
            if (listBoxFacturas.SelectedItem.ToString().Length > 0)
            {
                string[] direccion = listBoxFacturas.SelectedItem.ToString().Split(new Char[] { '-', ':' });
                decimal total = Convert.ToDecimal(labelRTot.Text);
                decimal importe = Convert.ToDecimal(direccion[5]);
                decimal resta = total - importe;
                labelRTot.Text = resta.ToString();
                //labelRTot.Text = Convert.ToString(Convert.ToInt32(labelRTot.Text) - Convert.ToInt32(direccion[5]));
                listBoxFacturas.Items.Remove(listBoxFacturas.SelectedItem);
            }
            else
            {
                MessageBox.Show("Debe seleccionar una factura para quitar de la lista.", "Error");
            }
        }

        private void buttonPagar_Click(object sender, EventArgs e)
        {
            if(listBoxFacturas.Items.Count > 0)
            {
                registrarPagoParaLasFacturasDeLaLista();
            }
            else
            {
                MessageBox.Show("Debe agregar al menos una factura para pagar.", "Error");
            }
        }

        private void labelTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}
