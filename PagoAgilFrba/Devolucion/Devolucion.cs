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

namespace PagoAgilFrba.Devolucion
{
    public partial class Devolucion : Form
    {
        public Devolucion()
        {
            InitializeComponent();
            llenarFacturasEnElCombo();
        }

        private void llenarFacturasEnElCombo()
        {
             SqlDataReader reader = null;
             SqlCommand cmd = new SqlCommand("select TOP 50 fac_id from GOQ.Facturas f join GOQ.Pago_factura pf on(f.fac_id = pf.pago_fac_fac_id) join Devolucion d on(f.fac_id = d.dev_fac_id)", PagoAgilFrba.ModuloGlobal.getConexion());
             reader = cmd.ExecuteReader();
             while (reader.Read())
             {
                 comboFacturas.Items.Add(Convert.ToString(reader.GetValue(0)));
             }
             reader.Close();
        }

        private bool Factura_valida(string factura){
            int numerofactura = Convert.ToInt32(factura);
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("select fac_id from GOQ.factura where fac_id = @nroFac", PagoAgilFrba.ModuloGlobal.getConexion());
            cmd.Parameters.Add("nroFac", SqlDbType.Int).Value = factura;
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



        //accioness

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(radioButtonError.Checked){
                string motivo = "ErrorCobro";
            }
            else if(radioButtonCliente.Checked){
                string motivo = "DecisionCliente";
            }
            else{
                MessageBox.Show("Seleccione el motivo de la devolucion","Error");
            }
        }

        private void comboFacturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void botonBuscar_Click(object sender, EventArgs e)
        {
            if(botonFactura.Checked &&  comboFacturas.SelectedItem.ToString().Length > 0){
               string Factura = comboFacturas.SelectedItem.ToString();
               int numerofactura = Convert.ToInt32(Factura);

            }
            else if(botonIngrese.Checked && boxIngreso.Text.Length > 0){

                if (Factura_valida(boxIngreso.Text))
                {
                    int numerofactura = Convert.ToInt32(boxIngreso.Text);
                }
                else
                {
                    MessageBox.Show("Numero de factura INVALIDO", "Error");
                }
            }
            else{
                MessageBox.Show("Elija o ingrese numero de factura","Error");
            
            }
        }

        
    }
}
