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

namespace PagoAgilFrba.ListadoEstadistico
{
    public partial class ListadoEstadistico : Form
    {
        public ListadoEstadistico()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
            cargarTrimestres();
            cargarListados();
            
        }

        private void consultarListado(int año, int mesInicio, int mesFin, string tipoListado){
            //antes de ejecutar la consulta tengo que vaciar todas las columnas y filas del datagridview
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            if (tipoListado == "Porcentaje de facturas cobradas por empresa")
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("select TOP 5 e.empresa_nombre,COUNT(fac_id)*100 / (select COUNT(fac_id) cantidadTotal from GOQ.Empresa e1 inner join GOQ.Factura f1 on(e1.ID_empresa = f1.fac_empresa_id) where e1.ID_empresa = f.fac_empresa_id) PorcentajeCobrado from GOQ.Factura f inner join GOQ.Pago_Factura pf on(f.fac_id = pf.pago_fac_fac_id) inner join GOQ.Pago p on(p.pago_id = pf.pago_fac_pago_id) inner join GOQ.Empresa e on(e.ID_empresa = f.fac_empresa_id) where year(p.pago_fecha_cobro) = @año and month(p.pago_fecha_cobro) between @mesInicio and @mesFin group by f.fac_empresa_id,e.empresa_nombre order by 2 DESC",
                    PagoAgilFrba.ModuloGlobal.getConexion());
                cmd.Parameters.Add("año", SqlDbType.Int).Value = año;
                cmd.Parameters.Add("mesInicio", SqlDbType.Int).Value = mesInicio;
                cmd.Parameters.Add("mesFin", SqlDbType.Int).Value = mesFin;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    DataGridViewColumn ColumnaEmpresa = new DataGridViewColumn();
                    ColumnaEmpresa.HeaderText = "Nombre de la Empresa";
                    ColumnaEmpresa.Width = 200;
                    ColumnaEmpresa.ReadOnly = true;
                    dataGridView1.Columns.Add(ColumnaEmpresa);

                    DataGridViewColumn Porcentaje = new DataGridViewColumn();
                    Porcentaje.HeaderText = "Porcentaje de facturas cobradas";
                    Porcentaje.Width = 200;
                    Porcentaje.ReadOnly = true;
                    dataGridView1.Columns.Add(Porcentaje);

                    
                    while (reader.Read())
                    {
                        //agregar fila, esto te devuelve de a una las filas de tu consulta select
                       
                        string[] fila = new string[]{  Convert.ToString(reader.GetValue(0)), Convert.ToString(reader.GetValue(1)) };
                        object[] rows = new object[] { fila };
                        dataGridView1.Rows.Add(rows);
                    }
                    
         
                }
                else
                {
                    MessageBox.Show("Error en la consulta ", "Error");
                }
                reader.Close();
            
            }
            else if(tipoListado == "Empresas con mayor monto rendido"){

                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("select TOP 5 e.empresa_nombre ,SUM(ren_imp_total) TotalMontoRendido from GOQ.Factura f inner join GOQ.Rendicion r on(f.fac_ren_id = r.ren_id) inner join GOQ.Empresa e on(e.ID_empresa = f.fac_empresa_id) where  year(ren_fecha_ren) = @año and month(ren_fecha_ren) between @mesInicio and @mesFin group by e.empresa_nombre order by 2 DESC", PagoAgilFrba.ModuloGlobal.getConexion());
                cmd.Parameters.Add("año", SqlDbType.Int).Value = año;
                cmd.Parameters.Add("mesInicio", SqlDbType.Int).Value = mesInicio;
                cmd.Parameters.Add("mesFin", SqlDbType.Int).Value = mesFin;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    DataGridViewColumn ColumnaEmpresa = new DataGridViewColumn();
                    ColumnaEmpresa.HeaderText = "Nombre de la Empresa";
                    ColumnaEmpresa.Width = 200;
                    ColumnaEmpresa.ReadOnly = true;
                    dataGridView1.Columns.Add(ColumnaEmpresa);

                    DataGridViewColumn MontoRendido = new DataGridViewColumn();
                    MontoRendido.HeaderText = "Monto Rendido";
                    MontoRendido.Width = 200;
                    MontoRendido.ReadOnly = true;
                    dataGridView1.Columns.Add(MontoRendido);

                    while (reader.Read())
                    {
                        //agregar fila, esto te devuelve de a una las filas de tu consulta select
                        dataGridView1.Rows.Add(Convert.ToString(reader.GetValue(0)), Convert.ToString(reader.GetValue(1)));
                    }

                }
                else
                {
                    MessageBox.Show("No hay facturas rendidas ", "Advertencia");
                }
                reader.Close();

            }
            else if (tipoListado == "Clientes con mas pagos")
            {

                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("select TOP 5 c.cli_apellido+','+c.cli_nombre ApellidoNombre, COUNT(pago_id) cantidadPagos from GOQ.Cliente c inner join GOQ.Pago P ON(c.cli_id = p.pago_cliente_id) where  year(p.pago_fecha_cobro) = @año and month(pago_fecha_cobro) between @mesInicio and @mesFin  group by c.cli_apellido, c.cli_nombre order by 2 DESC", PagoAgilFrba.ModuloGlobal.getConexion());
                cmd.Parameters.Add("año", SqlDbType.Int).Value = año;
                cmd.Parameters.Add("mesInicio", SqlDbType.Int).Value = mesInicio;
                cmd.Parameters.Add("mesFin", SqlDbType.Int).Value = mesFin;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    DataGridViewColumn NombreApellidoCliente = new DataGridViewColumn();
                    NombreApellidoCliente.HeaderText = "Nombre y Apellido";
                    NombreApellidoCliente.Width = 200;
                    NombreApellidoCliente.ReadOnly = true;
                    dataGridView1.Columns.Add(NombreApellidoCliente);

                    DataGridViewColumn CantidadPagos = new DataGridViewColumn();
                    CantidadPagos.HeaderText = "Cantidad de pagos efectuados";
                    CantidadPagos.Width = 200;
                    CantidadPagos.ReadOnly = true;
                    dataGridView1.Columns.Add(CantidadPagos);

                    while (reader.Read())
                    {
                        //agregar fila, esto te devuelve de a una las filas de tu consulta select
                        dataGridView1.Rows.Add(Convert.ToString(reader.GetValue(0)), Convert.ToString(reader.GetValue(1)));
                    }
                    
                   
                    MessageBox.Show("asd");


                }
                else
                {
                    MessageBox.Show("Error en la consulta ", "Error");
                }
                reader.Close();
            }
            else{
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("select TOP 5 c.cli_apellido+','+c.cli_nombre ApellidoNombre , COUNT(f.fac_id)*100/(select COUNT(f1.fac_id) cantidadTotal from GOQ.Factura f1 where f1.fac_cli_id = c.cli_id) PorcentajeFacturasPagadas from GOQ.Cliente c inner join GOQ.Factura f on(c.cli_id = f.fac_cli_id) inner join GOQ.Pago_Factura pf on(pf.pago_fac_fac_id = f.fac_id) inner join GOQ.Pago p on(p.pago_id = pf.pago_fac_pago_id) where year(p.pago_fecha_cobro) = @año and month(pago_fecha_cobro) between @mesInicio and @mesFin group by c.cli_id order by 2 DESC", PagoAgilFrba.ModuloGlobal.getConexion());
                cmd.Parameters.Add("año", SqlDbType.Int).Value = año;
                cmd.Parameters.Add("mesInicio", SqlDbType.Int).Value = mesInicio;
                cmd.Parameters.Add("mesFin", SqlDbType.Int).Value = mesFin;
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    DataGridViewColumn NombreApellidoCliente = new DataGridViewColumn();
                    NombreApellidoCliente.HeaderText = "Nombre de la Empresa";
                    NombreApellidoCliente.Width = 200;
                    NombreApellidoCliente.ReadOnly = true;
                    dataGridView1.Columns.Add(NombreApellidoCliente);

                    DataGridViewColumn Porcentaje = new DataGridViewColumn();
                    Porcentaje.HeaderText = "Porcentaje de facturas cobradas";
                    Porcentaje.Width = 200;
                    Porcentaje.ReadOnly = true;
                    dataGridView1.Columns.Add(Porcentaje);

                    while (reader.Read())
                    {
                        //agregar fila, esto te devuelve de a una las filas de tu consulta select
                        dataGridView1.Rows.Add(Convert.ToString(reader.GetValue(0)), Convert.ToString(reader.GetValue(1)));
                    }

                }
                else
                {
                    MessageBox.Show("Error en la consulta ", "Error");
                }
                reader.Close();
            


            }


        }

        private void cargarTrimestres()
        {
            listadotrimestre.Items.Add("1-3 / Enero a Marzo");
            listadotrimestre.Items.Add("4-6 / Abril a Junio");
            listadotrimestre.Items.Add("7-9 / Julio a Septiembre");
            listadotrimestre.Items.Add("10-12 / Octubre a Diciembre");
        }

        private void cargarListados()
        {
            listadoMostrar.Items.Add("Porcentaje de facturas cobradas por empresa");
            listadoMostrar.Items.Add("Empresas con mayor monto rendido");
            listadoMostrar.Items.Add("Clientes con mas pagos");
            listadoMostrar.Items.Add("Clientes con mayor porcentaje de facturas pagadas");
        }


        //-------------------------------------------ACCIONES---------------------------------------//

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
       
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textAño.Text.Length > 0 && listadotrimestre.SelectedItem.ToString().Length > 0)
            {
                dataGridView1.Visible = true;
                int año = Convert.ToInt32(textAño.Text);
                string[] trimestre = listadotrimestre.SelectedItem.ToString().Split(new Char[] { ' ', '-' });
                int mesInit = Convert.ToInt32(trimestre[0]);
                int mesFinish = Convert.ToInt32(trimestre[1]);

                consultarListado(año, mesInit, mesFinish, listadoMostrar.SelectedItem.ToString());

            }
            else
            {
                MessageBox.Show("Complete los campos solicitados","Error");
            
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

    }
}
