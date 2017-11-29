using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Globalization;



namespace PagoAgilFrba.AbmRol
{
    public partial class Roles : Form
    {
        int indexUsuario = -1;
        int indexRol= -1;


        public Roles()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Roles_Load(object sender, EventArgs e)
        {
            
            
        }

        private void cargarUsuario() {

            int cant = 0;
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT usu_id,usu_username,usu_habilitado FROM GOQ.Usuario WHERE usu_habilitado =1", PagoAgilFrba.ModuloGlobal.getConexion());//getConexion());

            reader = cmd.ExecuteReader();
            reader.Read();
            
            if (reader.HasRows)
            {
                
                do
                {
                    cant += 1;
                    lbUsuario.Items.Add(reader.GetString(1));
                }
                while (reader.Read());
            }

            if (!reader.HasRows)
            {
                MessageBox.Show("No hay roles habilitados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            reader.Close();

        }

        private void cargarRolesHabilitados()
        {
            int cant = 0;
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT ROL_NOMBRE, ROL_ID FROM GOQ.ROL WHERE ROL_HABILITADO=1", PagoAgilFrba.ModuloGlobal.getConexion());//getConexion());

            reader = cmd.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                
                do
                {
                    cant += 1;
                    lbRolHab.Items.Add(reader.GetString(0));
                }
                while (reader.Read());
            }

            if (!reader.HasRows)
            {
                MessageBox.Show("No hay roles habilitados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            reader.Close();
        }

        private void cargarRoles() {

            int cant = 0;
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT ROL_NOMBRE, ROL_ID FROM GOQ.ROL R INNER JOIN GOQ.Funcionalidad_Rol F ON (R.rol_id=F.fun_rol_rol_id)", PagoAgilFrba.ModuloGlobal.getConexion());//getConexion());

            
            reader = cmd.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {  
                do
                {
                    cant += 1;
                    lbRoles.Items.Add(reader.GetString(0));
                }
                while (reader.Read());
            }

            if (!reader.HasRows) {
                MessageBox.Show("No tiene roles, ingresar como administrador y generar un rol para el usuario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            }
            reader.Close();
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarCheckBox();
            try { 
                cargarFuncionalidadSegunRol(lbRoles.SelectedItem.ToString()); }
            catch 
            {
                lbRoles.SelectedIndex = 0; 
            }
            
        }

        private void limpiarCheckBox()
        {
            cbRol_1.Checked = false;
            cbCliente_2.Checked = false;
            cbEmpresa_3.Checked = false;
            cbSucursal_4.Checked = false;
            cbFactura_5.Checked = false;
            cbPagoRegistro_6.Checked = false;
            cbPagoRendicion_7.Checked = false;
            cbDevolucion_8.Checked = false;
            cbEstadistico_9.Checked = false;
        }

        private void cargarFuncionalidadSegunRol(string rol)
        {

            int cant = 0;
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT distinct fun_rol_fun_id FROM [GOQ].[Funcionalidad_Rol] F INNER JOIN [GOQ].[Rol] R ON(F.fun_rol_rol_id=r.rol_id) where R.rol_nombre=@NOMBREROL;", PagoAgilFrba.ModuloGlobal.getConexion());

            cmd.Parameters.Add("NOMBREROL", SqlDbType.NVarChar).Value = rol;

            reader = cmd.ExecuteReader();
            
                while (reader.Read())
                {
                    switch (reader.GetValue(0).ToString())
                    {
                        case "1":
                            cbRol_1.Checked = true;
                            break;
                        case "2":
                            cbCliente_2.Checked = true;
                            break;
                        case "3":
                            cbEmpresa_3.Checked = true;
                            break;
                        case "4":
                            cbSucursal_4.Checked = true;
                            break;
                        case "5":
                            cbFactura_5.Checked = true;
                            break;
                        case "6":
                            cbPagoRegistro_6.Checked = true;
                            break;
                        case "7":
                            cbPagoRendicion_7.Checked = true;
                            break;
                        case "8":
                            cbDevolucion_8.Checked = true;
                            break;
                        case "9":
                            cbEstadistico_9.Checked = true;
                            break;
                        default:
                            //Console.WriteLine("Default case");
                            break;
                    }

                    cant += 1;
                } 
          //  }
                reader.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lbRoles.SelectedItems.Count > 0) 
            {
                
                SqlCommand cmd = new SqlCommand("UPDATE GOQ.Rol SET rol_habilitado = 0 WHERE rol_nombre = @NOMBREROL",
                PagoAgilFrba.ModuloGlobal.getConexion());
                cmd.Parameters.Add("NOMBREROL", SqlDbType.VarChar).Value = lbRoles.SelectedItem.ToString();

                int cantidadFilasAfectadas = cmd.ExecuteNonQuery();
                if (cantidadFilasAfectadas > 0)
                {
                    MessageBox.Show("Rol inhabilitado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lbRoles.Items.Clear();
                    cargarRoles();
                    cargarRolesHabilitados();
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al intentar inhabilitar al rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar un rol a inhabilitar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool funcionalidadesEnFalse(){

            if (cbRol_1.Checked==false && cbCliente_2.Checked==false && cbEmpresa_3.Checked==false && cbSucursal_4.Checked==false  && cbFactura_5.Checked==false && cbPagoRegistro_6.Checked==false && cbPagoRendicion_7.Checked==false && cbDevolucion_8.Checked==false && cbEstadistico_9.Checked==false ){
                return true;
            }else{
                return true;
            }
            
        }

        private void quienesNoTenganFuncionalidadNoFueronCargadosCorrectamente() {

            SqlCommand cmdDelete = new SqlCommand("DELETE GOQ.ROL WHERE rol_id NOT IN (SELECT F.fun_rol_rol_id FROM GOQ.Funcionalidad_Rol F )",
            PagoAgilFrba.ModuloGlobal.getConexion());

            cmdDelete.ExecuteNonQuery();
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
                string nombre_rol = "";

                quienesNoTenganFuncionalidadNoFueronCargadosCorrectamente();

                nombre_rol=  Interaction.InputBox("Nombre de Rol","Ingrese Nombre de Rol");

                TextInfo miTituloCase= new CultureInfo("en-US", false).TextInfo;

                if (nombre_rol.ToString().Length > 0) {


                                            SqlCommand cmd = new SqlCommand("INSERT INTO [GOQ].[Rol] ([rol_nombre],[rol_habilitado]) VALUES (@NOMBREROL ,1)",
                        PagoAgilFrba.ModuloGlobal.getConexion());

                        cmd.Parameters.Add("NOMBREROL", SqlDbType.Text).Value = nombre_rol.ToUpper().Trim();//miTituloCase.ToTitleCase(nombre_rol);//nombre_rol.To ToString().ToUpperInvariant();

                        int cantidadFilasAfectadas = cmd.ExecuteNonQuery();

                        if (cantidadFilasAfectadas > 0)
                        {
                            //MessageBox.Show("Rol agregado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lbRoles.Items.Clear();
                            limpiarCheckBox();
                            cargarRoles();
                            lbRoles.Items.Add(nombre_rol.ToUpper().Trim());
                            MessageBox.Show("Seleccione el rol y elija sus funcionalidades para que se registre correctamente, de lo contrario no se cargará.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió un error al intentar agregar un rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    


                    
                }
                else
                {
                    MessageBox.Show("Debe ingresar un nombre de rol.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



        }

        private int dameElIDdelRol(string nombreRol) {
        
                        SqlDataReader reader = null;
                        SqlCommand cmdInsert = new SqlCommand("SELECT distinct rol_id FROM [GOQ].[Rol] WHERE ltrim(rtrim(upper(rol_nombre)))=@NOMBREROL;", PagoAgilFrba.ModuloGlobal.getConexion());

                        MessageBox.Show(nombreRol.ToUpper().Trim());
                        cmdInsert.Parameters.Add("NOMBREROL", SqlDbType.NVarChar).Value = nombreRol.ToUpper().Trim();
                        
                        
                        reader = cmdInsert.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            return reader.GetInt32(0);
                            
                        }
                        else
                        {
                            MessageBox.Show("No existe un id para el rol.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return -1;
                            
                        }
                       
           
        }

        private void insertarFuncionalidad(int rol_id, int funcionalidad_id) {

            SqlCommand cmdInsert = new SqlCommand("INSERT INTO [GOQ].[Funcionalidad_Rol] ([fun_rol_rol_id],[fun_rol_fun_id]) VALUES (@ROL_ID,@FUNCIONALIDAD_ID)",
            PagoAgilFrba.ModuloGlobal.getConexion());
            cmdInsert.Parameters.Add("ROL_ID", SqlDbType.Int).Value = rol_id;
            cmdInsert.Parameters.Add("FUNCIONALIDAD_ID", SqlDbType.Int).Value = funcionalidad_id;
            cmdInsert.ExecuteNonQuery();
            //MessageBox.Show("Inserté funcionalidad "+funcionalidad_id.ToString(), "Ingreso de datos.");
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (noHayFuncionalidadHabilitadas())
            {

                MessageBox.Show("Debe seleccionar un rol y tildar las funcionalidades que posee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string nombre_rol = "";
                int rol_id;
                nombre_rol = lbRoles.SelectedItem.ToString();
                rol_id = dameElIDdelRol(nombre_rol.ToString().ToUpper());

                if (nombre_rol.Length>0) {

                    SqlCommand cmdDelete = new SqlCommand("DELETE from [GOQ].[Funcionalidad_Rol] where fun_rol_rol_id =@ROL_ID;", //IN (SELECT distinct rol_id FROM [GOQ].[Rol] WHERE rol_nombre=@NOMBREROL) ;",
                    PagoAgilFrba.ModuloGlobal.getConexion());

                    cmdDelete.Parameters.Add("ROL_ID", SqlDbType.Int).Value = rol_id;

                    cmdDelete.ExecuteNonQuery();

                    //inserto las funcionalidades por rol.

                    if (cbRol_1.Checked == true)
                    {

                        insertarFuncionalidad(rol_id, 1);

                    }
                     if (cbCliente_2.Checked == true)
                    {
                        insertarFuncionalidad(rol_id, 2);
                    }
                     if (cbEmpresa_3.Checked == true)
                    {
                        insertarFuncionalidad(rol_id, 3);
                    }
                     if (cbSucursal_4.Checked == true)
                    {
                        insertarFuncionalidad(rol_id, 4);
                    }
                     if (cbFactura_5.Checked == true)
                    {
                        insertarFuncionalidad(rol_id, 5);
                    }
                     if (cbPagoRegistro_6.Checked == true)
                    {
                        insertarFuncionalidad(rol_id, 6);
                    }
                     if (cbPagoRendicion_7.Checked == true)
                    {
                        insertarFuncionalidad(rol_id, 7);
                    }
                     if (cbDevolucion_8.Checked == true)
                    {
                        insertarFuncionalidad(rol_id, 8);
                    }
                     if (cbEstadistico_9.Checked == true)
                    {
                        insertarFuncionalidad(rol_id, 9);
                    }
                     MessageBox.Show("Aplicado. Los cambios se verán reflejados cuando vuelva a loguearse.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     
                    
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un Rol.", "Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    
                }

                
            }    
        }

        private bool noHayFuncionalidadHabilitadas() {

            if ((cbRol_1.Checked == false & cbCliente_2.Checked == false & cbEmpresa_3.Checked == false & cbSucursal_4.Checked == false & cbFactura_5.Checked == false & cbPagoRegistro_6.Checked == false & cbPagoRendicion_7.Checked == false & cbDevolucion_8.Checked == false & cbEstadistico_9.Checked == false) || lbRoles.SelectedItems.Count == 0)
            {
                return true;
            }

            return false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            quienesNoTenganFuncionalidadNoFueronCargadosCorrectamente();
            if (checkBox1.Checked==false) {
                gbAdmRol.Enabled = false;
                lbRoles.Items.Clear();
            }else {
                gbAdmRol.Enabled = true;
                cargarRoles();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                gbRolUsuario.Enabled = false;
                lbUsuario.Items.Clear();
                lbRolHab.Items.Clear();
            } else {
                gbRolUsuario.Enabled = true;
                cargarUsuario();
                cargarRolesHabilitados();
            }
        }

        private int controlDeUsuarioRolExistente(int usu_id, int rol_id)
        {
                SqlDataReader readerRol = null;
                SqlCommand cmdSelect = new SqlCommand("SELECT DISTINCT rol_usu_rol_id,rol_usu_usu_id FROM GOQ.Rol_Usuario WHERE rol_usu_rol_id=@ROL_ID AND rol_usu_usu_id=@USU_ID;", PagoAgilFrba.ModuloGlobal.getConexion());

                cmdSelect.Parameters.Add("ROL_ID", SqlDbType.NVarChar).Value = usu_id;
                cmdSelect.Parameters.Add("USU_ID", SqlDbType.NVarChar).Value = rol_id;

                readerRol = cmdSelect.ExecuteReader();
                readerRol.Read();

                if (readerRol.HasRows)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
                     

    }

        private void btnAsgRol_Click(object sender, EventArgs e)
        {
            
            if (lbUsuario.SelectedIndex >= 0) {

                
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("SELECT distinct usu_id FROM GOQ.Usuario WHERE usu_username=@USUARIO", PagoAgilFrba.ModuloGlobal.getConexion());
                cmd.Parameters.Add("USUARIO", SqlDbType.VarChar).Value = lbUsuario.SelectedItem.ToString();

                reader = cmd.ExecuteReader();
                reader.Read();

                if (reader.HasRows)
                {
                    indexUsuario = reader.GetInt32(0);
                }else{
                    MessageBox.Show("Error al recuperar el Id del Usuario.", "Información");
                }
                                
                reader.Close();
            
                if (lbRolHab.SelectedIndex>=0){


                            SqlDataReader readerRol = null;
                            SqlCommand cmdSelect = new SqlCommand("SELECT distinct rol_id FROM [GOQ].[Rol] WHERE rol_nombre=@NOMBREROL;", PagoAgilFrba.ModuloGlobal.getConexion());

                            cmdSelect.Parameters.Add("NOMBREROL", SqlDbType.NVarChar).Value = lbRolHab.SelectedItem.ToString();

                            readerRol = cmdSelect.ExecuteReader();
                            readerRol.Read();

                            if (readerRol.HasRows)
                            {
                                
                                indexRol = readerRol.GetInt32(0);

                                if (controlDeUsuarioRolExistente(indexRol,indexUsuario) == 1) {

                                    MessageBox.Show("El Rol ya existe para el usuario seleccionado.", "Información");

                                }else{
                                    int cant = 0;
                                    SqlCommand cmdInsert = new SqlCommand("INSERT INTO GOQ.Rol_Usuario (rol_usu_rol_id,rol_usu_usu_id) VALUES (@ROL_ID,@USU_ID)",
                                    PagoAgilFrba.ModuloGlobal.getConexion());
                                    cmdInsert.Parameters.Add("ROL_ID", SqlDbType.Int).Value = indexRol;
                                    cmdInsert.Parameters.Add("USU_ID", SqlDbType.Int).Value = indexUsuario;
                                    cant=cmdInsert.ExecuteNonQuery();
                                    if (cant > 0) { MessageBox.Show("Rol asignado correctamente.", "Información");
                                    }
                                    else { MessageBox.Show("Error en la asignación.", "Información"); }
                                    
                                }

                                
                            }
                            else
                            {
                                MessageBox.Show("Error al recuperar el Id del Rol.", "Información");
                            }


                }else{
                    MessageBox.Show("Debe seleccionar un rol.", "Information");
                }

            }else{
                MessageBox.Show("Debe seleccionar un usuario.", "Information");
            }
        }
        private bool tieneHabilitadaFuncionalidades(string nombreRol)
        {
            int cant = 0;
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM GOQ.Funcionalidad_Rol F INNER JOIN GOQ.Rol R ON (F.fun_rol_rol_id=R.rol_id) WHERE R.rol_nombre=@USUARIO", PagoAgilFrba.ModuloGlobal.getConexion());
            cmd.Parameters.Add("USUARIO", SqlDbType.VarChar).Value = nombreRol;

            reader = cmd.ExecuteReader();
            reader.Read();

            if (reader.HasRows)
            {
                cant = reader.GetInt32(0);
                if (cant > 0)
                {
                    reader.Close();
                    return true;
                }else{
                    reader.Close();
                    return false;
                }
            }
            else
            {
                reader.Close();
                return false;
            }
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lbRoles.SelectedItems.Count > 0)
            {

                if (tieneHabilitadaFuncionalidades(lbRoles.SelectedItem.ToString())) {


                    SqlCommand cmd = new SqlCommand("UPDATE GOQ.Rol SET rol_habilitado = 1 WHERE rol_nombre = @NOMBREROL",
                    PagoAgilFrba.ModuloGlobal.getConexion());
                    cmd.Parameters.Add("NOMBREROL", SqlDbType.VarChar).Value = lbRoles.SelectedItem.ToString();

                    int cantidadFilasAfectadas = cmd.ExecuteNonQuery();
                    if (cantidadFilasAfectadas > 0)
                    {
                        MessageBox.Show("Rol habilitado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lbRoles.Items.Clear();
                        cargarRoles();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrió un error al intentar habilitar al rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else{

                    MessageBox.Show("El rol seleccionado no tiene funcionalidades habilitadas.", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }
            else
            {
                MessageBox.Show("Debe seleccionar un rol a habilitar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (lbRoles.SelectedIndex==-1) {
                MessageBox.Show("Debe seleccionar el Rol a renombrar", "Información", MessageBoxButtons.OK);
            }else{


                string nombre_rol = "";

                quienesNoTenganFuncionalidadNoFueronCargadosCorrectamente();

                nombre_rol = Interaction.InputBox("Renombrar a: ", "Ingrese Nuevo Nombre del Rol");

                TextInfo miTituloCase = new CultureInfo("en-US", false).TextInfo;

                if (nombre_rol.ToString().Length > 0)
                {

                    SqlCommand cmd = new SqlCommand("UPDATE [GOQ].[Rol] SET [rol_nombre]=@RENOMBRAR WHERE ltrim(rtrim(upper([rol_nombre])))=@ORIGINAL",
                    PagoAgilFrba.ModuloGlobal.getConexion());

                    cmd.Parameters.Add("RENOMBRAR", SqlDbType.VarChar).Value = nombre_rol.ToUpper().Trim();//miTituloCase.ToTitleCase(nombre_rol);//nombre_rol.To ToString().ToUpperInvariant();
                    cmd.Parameters.Add("ORIGINAL", SqlDbType.VarChar).Value = lbRoles.SelectedItem.ToString();

                    int cantidadFilasAfectadas = cmd.ExecuteNonQuery();

                    if (cantidadFilasAfectadas > 0)
                    {
                        //MessageBox.Show("Rol agregado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lbRoles.Items.Clear();
                        limpiarCheckBox();
                        cargarRoles();
                        MessageBox.Show("Se modificó el nombre correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se ha modificado el nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
        }
    }
}
