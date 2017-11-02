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
            TextMotivo.Visible = false;
            groupBox2.Visible = false;
        }

        
        private string numerofactura;

        private void llenarFacturasEnElCombo()
        {
             SqlDataReader reader = null;
             SqlCommand cmd = new SqlCommand("select TOP 50 fac_id from GOQ.Factura f join GOQ.Pago_factura pf on(f.fac_id = pf.pago_fac_fac_id) left join GOQ.Devolucion d on(f.fac_id = d.dev_fac_id) left join GOQ.Rendicion r on(f.fac_ren_id = r.ren_id) group by fac_id having COUNT(pf.pago_fac_fac_id) > COUNT(d.dev_fac_id) and COUNT(r.ren_id)=0", PagoAgilFrba.ModuloGlobal.getConexion());
             reader = cmd.ExecuteReader();
             while (reader.Read())
             {
                 comboFacturas.Items.Add(Convert.ToString(reader.GetValue(0)));
             }
             reader.Close();
        }

        private bool Factura_valida(string factura){
            numerofactura = factura;
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("select fac_id from GOQ.Factura f join GOQ.Pago_factura pf on(f.fac_id = pf.pago_fac_fac_id) left join GOQ.Devolucion d on(f.fac_id = d.dev_fac_id) left join GOQ.Rendicion r on(f.fac_ren_id = r.ren_id) where fac_id = @nroFac group by fac_id having COUNT(pf.pago_fac_fac_id) > COUNT(d.dev_fac_id) and COUNT(r.ren_id)=0", PagoAgilFrba.ModuloGlobal.getConexion());
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
                
                if (listBoxFacturas.Items.Contains("Factura:" + numerofactura + "-Motivo:" + "ErrorCobro"))
                {
                    MessageBox.Show("La factura a agregar, ya se encuentra en la lista.", "Error");
                }
                else
                {
                    listBoxFacturas.Items.Add("Factura:" + numerofactura + "-Motivo:" + "ErrorCobro");
                    boxIngreso.Clear();                 
                    TextMotivo.Visible = false;
                    groupBox2.Visible = false;
                    agregar.Visible = false;
                }
            }
            else if(radioButtonCliente.Checked){
                
                if (listBoxFacturas.Items.Contains("Factura:" + numerofactura + "-Motivo:" + "DecisionCliente"))
                {
                    MessageBox.Show("La factura a agregar, ya se encuentra en la lista.", "Error");
                }
                else
                {
                    listBoxFacturas.Items.Add("Factura:" + numerofactura + "-Motivo:" + "DecisionCliente");
                    boxIngreso.Clear();
                    TextMotivo.Visible = false;
                    groupBox2.Visible = false;
                    agregar.Visible = false;
                }
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
            if(botonFactura.Checked &&  !comboFacturas.SelectedItem.Equals(-1)){
                numerofactura = comboFacturas.SelectedItem.ToString();
                TextMotivo.Visible = true;
                groupBox2.Visible = true;
                agregar.Visible = true;
              
               
            }
            else if(botonIngrese.Checked && boxIngreso.Text.Length > 0){

                if (Factura_valida(boxIngreso.Text))
                {
                    numerofactura = boxIngreso.Text;
                    TextMotivo.Visible = true;
                    groupBox2.Visible = true;
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

        private void quitar_Click(object sender, EventArgs e)
        {
            if (listBoxFacturas.SelectedItems.Count > 0)
            {
                listBoxFacturas.Items.Remove(listBoxFacturas.SelectedItem);
            }
            else { 
             
                MessageBox.Show("Debe seleccionar una factura para quitar de la lista.", "Error");
            }

        }

        private void devolver_Click(object sender, EventArgs e)
        {
            if (listBoxFacturas.Items.Count > 0)
            {
                registrarDevolucionParaLasFacturasDeLaLista();
            }
            else
            {
                MessageBox.Show("Debe agregar al menos una factura para devolver.", "Error");
            }
        }

        private void registrarDevolucionParaLasFacturasDeLaLista()
        {
            foreach (string Item in listBoxFacturas.Items)
            {
                string[] direccion = Item.Split(new Char[] { '-', ':' });
                SqlCommand cmd = new SqlCommand("insert into GOQ.Devolucion (dev_fac_id,dev_motivo) values(@NROFACT,@MOTIVO)", PagoAgilFrba.ModuloGlobal.getConexion()); 

                cmd.Parameters.Add("NROFACT", SqlDbType.Int).Value = Convert.ToInt32(direccion[1]);
                cmd.Parameters.Add("MOTIVO", SqlDbType.NVarChar).Value = direccion[3];
                int cantidadFilasAfectadas = cmd.ExecuteNonQuery();
                if (cantidadFilasAfectadas > 0)
                {
                    MessageBox.Show("Devolucion registrada con exito");
                }
                else
                {
                    MessageBox.Show("La devolucion que se quiso registrar no pudo completarse","Error");
                }
                
            }
            listBoxFacturas.Items.Clear();



        }

        
    }
}
