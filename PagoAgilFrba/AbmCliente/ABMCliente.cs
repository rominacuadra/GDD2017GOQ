using System;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;


namespace PagoAgilFrba.AbmCliente
{
    public partial class ABMCliente : Form
    {

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public ABMCliente()
        {
            InitializeComponent();
            ocultarTodosLosItems();
            comboBoxFiltro.Items.Add("Todos");
            comboBoxFiltro.Items.Add("DNI");
            comboBoxFiltro.Items.Add("Apellido");
            comboBoxFiltro.Items.Add("Nombre");
        }

        private int DNIAModificar = 0, DNISinModificar = 0;
        private string ApellidoAModificar = "", NombreAModificar = "", MailSinModificar = "";

        private void mostrarAlta()
        {
            labelNombre.Visible = true;
            labelApellido.Visible = true;
            labelDNI.Visible = true;
            labelMail.Visible = true;
            labelTelefono.Visible = true;
            labelDireccion.Visible = true;
            labelNroPiso.Visible = true;
            labelDepto.Visible = true;
            labelLocalidad.Visible = true;
            labelCodigoPostal.Visible = true;
            labelFechaDeNacimiento.Visible = true;
            labelCalle.Visible = true;
            textBoxNombre.Visible = true;
            textBoxApellido.Visible = true;
            textBoxDNI.Visible = true;
            textBoxMail.Visible = true;
            textBoxTelefono.Visible = true;
            textBoxCalle.Visible = true;
            textBoxNroPiso.Visible = true;
            textBoxDepto.Visible = true;
            textBoxLocalidad.Visible = true;
            textBoxCodigoPostal.Visible = true;
            textBoxFechaDeNacimiento.Visible = true;
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
            labelApellido.Visible = false;
            labelDNI.Visible = false;
            labelMail.Visible = false;
            labelTelefono.Visible = false;
            labelDireccion.Visible = false;
            labelNroPiso.Visible = false;
            labelDepto.Visible = false;
            labelLocalidad.Visible = false;
            labelCodigoPostal.Visible = false;
            labelFechaDeNacimiento.Visible = false;
            labelCalle.Visible = false;
            textBoxNombre.Visible = false;
            textBoxApellido.Visible = false;
            textBoxDNI.Visible = false;
            textBoxMail.Visible = false;
            textBoxTelefono.Visible = false;
            textBoxCalle.Visible = false;
            textBoxNroPiso.Visible = false;
            textBoxDepto.Visible = false;
            textBoxLocalidad.Visible = false;
            textBoxCodigoPostal.Visible = false;
            textBoxFechaDeNacimiento.Visible = false;
            labelTitulo.Visible = false;
            buttonAceptar.Visible = false;
            buttonLimpiar.Visible = false;

            buttonBuscar.Visible = false;
            labelResultadoBusqueda.Visible = false;
            comboBoxResultadoBusqueda.Visible = false;
            labelFiltro.Visible = false;
            comboBoxFiltro.Visible = false;
            checkBoxCliente.Visible = false;
        }

        private void accionBotonAlta()
        {
            if (todosLosCamposCompletos())
            {
                if (mailNoEstaRepetido(textBoxMail.Text))
                {
                    darAltaCliente(textBoxNombre.Text, textBoxApellido.Text, Convert.ToInt32(textBoxDNI.Text), textBoxMail.Text, Convert.ToInt32(textBoxTelefono.Text), textBoxCalle.Text + " " + textBoxNroPiso.Text, textBoxCodigoPostal.Text, Convert.ToDateTime(textBoxFechaDeNacimiento.Text));
                }
                else
                {
                    MessageBox.Show("El mail ingresado ya se encuentra registrado, intente con otro.", "Error");
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
                modificarCliente(textBoxNombre.Text, textBoxApellido.Text, Convert.ToInt32(textBoxDNI.Text), textBoxMail.Text, Convert.ToInt32(textBoxTelefono.Text), textBoxCalle.Text + " " + textBoxNroPiso.Text, textBoxCodigoPostal.Text, Convert.ToDateTime(textBoxFechaDeNacimiento.Text));

            }
            else
            {
                MessageBox.Show("Debe completar todos los campos.", "Error");
            }
        }

        private bool todosLosCamposCompletos()
        {
            return textBoxNombre.Text.Length > 0 && textBoxApellido.Text.Length > 0 && textBoxDNI.Text.Length > 0 && textBoxMail.Text.Length > 0 &&
                textBoxTelefono.Text.Length > 0 && textBoxCalle.Text.Length > 0 && textBoxNroPiso.Text.Length > 0 &&
                textBoxLocalidad.Text.Length > 0 && textBoxCodigoPostal.Text.Length > 0 && textBoxFechaDeNacimiento.Text.Length > 0 ? true : false;
        }

        private bool mailNoEstaRepetido(string Mail)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT cli_id FROM GOQ.Cliente WHERE cli_mail = @MAIL", PagoAgilFrba.ModuloGlobal.getConexion());
            cmd.Parameters.Add("MAIL", SqlDbType.NVarChar).Value = Mail;
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

        private void darAltaCliente(string Nombre, string Apellido, int DNI, string Mail, int Telefono, string Direccion, string CodigoPostal, DateTime FechaDeNacimiento)
        {
            int filasRetornadas;
            SqlCommand cmd = new SqlCommand(string.Format("INSERT INTO GOQ.Cliente (cli_nombre, cli_apellido, cli_dni, cli_mail, cli_tel, cli_dir, cli_cp, cli_habilitado, cli_fecha_nac) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')",
                Nombre, Apellido, DNI, Mail, Telefono, Direccion, CodigoPostal, 1, FechaDeNacimiento), PagoAgilFrba.ModuloGlobal.getConexion());
            filasRetornadas = cmd.ExecuteNonQuery();
            if (filasRetornadas > 0)
            {
                MessageBox.Show("El cliente se ha registrado con éxito!", "Información");
            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar registrar el cliente", "Error");
            }
        }

        private void modificarCliente(string Nombre, string Apellido, int DNI, string Mail, int Telefono, string Direccion, string CodigoPostal, DateTime FechaDeNacimiento)
        {
            int filasRetornadas, habilitado;
            if (checkBoxCliente.Visible && checkBoxCliente.Checked)
            {
                habilitado = 1;
            }
            else if (checkBoxCliente.Visible && checkBoxCliente.Checked == false)
            {
                habilitado = 0;
            }
            else
            {
                habilitado = 1;
            }
            if (MailSinModificar == Mail && DNISinModificar != DNI)
            {
                //modifica DNI, MAIL no
                SqlCommand cmd = new SqlCommand(string.Format("UPDATE GOQ.Cliente SET cli_nombre = '{0}', cli_apellido = '{1}', cli_dni = '{2}', cli_tel = '{3}', cli_dir = '{4}', cli_cp = '{5}', cli_habilitado = '{6}', cli_fecha_nac =  '{7}' WHERE cli_dni = '{8}' AND cli_apellido = '{9}' AND cli_nombre = '{10}'",
                Nombre, Apellido, DNI, Telefono, Direccion, CodigoPostal, habilitado, FechaDeNacimiento,
                DNIAModificar, ApellidoAModificar, NombreAModificar), PagoAgilFrba.ModuloGlobal.getConexion());
                filasRetornadas = cmd.ExecuteNonQuery();
            }
            else if (MailSinModificar != Mail && DNISinModificar == DNI)
            {
                ////modifica Mail, DNI no
                SqlCommand cmd = new SqlCommand(string.Format("UPDATE GOQ.Cliente SET cli_nombre = '{0}', cli_apellido = '{1}', cli_mail = '{2}', cli_tel = '{3}', cli_dir = '{4}', cli_cp = '{5}', cli_habilitado = '{6}', cli_fecha_nac =  '{7}' WHERE cli_dni = '{8}' AND cli_apellido = '{9}' AND cli_nombre = '{10}'",
                Nombre, Apellido, Mail, Telefono, Direccion, CodigoPostal, habilitado, FechaDeNacimiento,
                DNIAModificar, ApellidoAModificar, NombreAModificar), PagoAgilFrba.ModuloGlobal.getConexion());
                filasRetornadas = cmd.ExecuteNonQuery();
            }
            else if (MailSinModificar != Mail && DNISinModificar != DNI)
            {
                ////modifica Mail y DNI
                SqlCommand cmd = new SqlCommand(string.Format("UPDATE GOQ.Cliente SET cli_nombre = '{0}', cli_apellido = '{1}', cli_dni = '{2}', cli_mail = '{3}', cli_tel = '{4}', cli_dir = '{5}', cli_cp = '{6}', cli_habilitado = '{7}', cli_fecha_nac =  '{8}' WHERE cli_dni = '{9}' AND cli_apellido = '{10}' AND cli_nombre = '{11}'",
                Nombre, Apellido, DNI, Mail, Telefono, Direccion, CodigoPostal, habilitado, FechaDeNacimiento,
                DNIAModificar, ApellidoAModificar, NombreAModificar), PagoAgilFrba.ModuloGlobal.getConexion());
                filasRetornadas = cmd.ExecuteNonQuery();
            }
            else
            {
                ////no modifica Mail ni DNI
                SqlCommand cmd = new SqlCommand(string.Format("UPDATE GOQ.Cliente SET cli_nombre = '{0}', cli_apellido = '{1}', cli_tel = '{2}', cli_dir = '{3}', cli_cp = '{4}', cli_habilitado = '{5}', cli_fecha_nac =  '{6}' WHERE cli_dni = '{7}' AND cli_apellido = '{8}' AND cli_nombre = '{9}'",
                Nombre, Apellido, Telefono, Direccion, CodigoPostal, habilitado, FechaDeNacimiento,
                DNIAModificar, ApellidoAModificar, NombreAModificar), PagoAgilFrba.ModuloGlobal.getConexion());
                filasRetornadas = cmd.ExecuteNonQuery();
            }

            if (filasRetornadas > 0)
            {
                MessageBox.Show("El cliente se ha modificado con éxito!", "Información");
            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar modificar el cliente", "Error");
            }
        }

        private bool camposDeBusquedaCompletos()
        {
            if (comboBoxFiltro.SelectedItem.ToString() == "Todos")
            {
                return textBoxApellido.TextLength > 0 && textBoxNombre.TextLength > 0 && textBoxDNI.TextLength > 0;
            }
            else if (comboBoxFiltro.SelectedItem.ToString() == "DNI")
            {
                return textBoxDNI.TextLength > 0;
            }
            else if (comboBoxFiltro.SelectedItem.ToString() == "Apellido")
            {
                return textBoxApellido.TextLength > 0;
            }
            else
            {
                return textBoxNombre.TextLength > 0;
            }
        }

        private bool realizarBusquedayDevolverResultado()
        {
            comboBoxResultadoBusqueda.Items.Clear();
            if (comboBoxFiltro.SelectedItem.ToString() == "Todos")
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("SELECT CONVERT(varchar(18),cli_dni) + ' - ' + cli_apellido + ' - ' + cli_nombre FROM GOQ.Cliente WHERE cli_dni = @DNI AND cli_apellido = @APELLIDO AND cli_nombre = @NOMBRE",
                    PagoAgilFrba.ModuloGlobal.getConexion());
                cmd.Parameters.Add("DNI", SqlDbType.Decimal).Value = Convert.ToInt32(textBoxDNI.Text);
                cmd.Parameters.Add("APELLIDO", SqlDbType.NVarChar).Value = textBoxApellido.Text;
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
            else if (comboBoxFiltro.SelectedItem.ToString() == "DNI")
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("SELECT CONVERT(varchar(18),cli_dni) + ' - ' + cli_apellido + ' - ' + cli_nombre FROM GOQ.Cliente WHERE cli_dni = @DNI",
                    PagoAgilFrba.ModuloGlobal.getConexion());
                cmd.Parameters.Add("DNI", SqlDbType.Decimal).Value = Convert.ToInt32(textBoxDNI.Text);
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
            else if (comboBoxFiltro.SelectedItem.ToString() == "Apellido")
            {
                SqlDataReader reader = null;
                SqlCommand cmd = new SqlCommand("SELECT CONVERT(varchar(18),cli_dni) + ' - ' + cli_apellido + ' - ' + cli_nombre FROM GOQ.Cliente WHERE cli_apellido = @APELLIDO",
                    PagoAgilFrba.ModuloGlobal.getConexion());
                cmd.Parameters.Add("APELLIDO", SqlDbType.NVarChar).Value = textBoxApellido.Text;
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
                SqlCommand cmd = new SqlCommand("SELECT CONVERT(varchar(18),cli_dni) + ' - ' + cli_apellido + ' - ' + cli_nombre FROM GOQ.Cliente WHERE cli_nombre = @NOMBRE",
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
        }

        private void inhabilitarCliente(int DNI, string Apellido, string Nombre)
        {
            SqlCommand cmd = new SqlCommand("UPDATE GOQ.Cliente SET cli_habilitado = 0 WHERE cli_dni = @DNI AND cli_apellido = @APELLIDO AND cli_nombre = @NOMBRE",
                    PagoAgilFrba.ModuloGlobal.getConexion());
            cmd.Parameters.Add("DNI", SqlDbType.Decimal).Value = DNI;
            cmd.Parameters.Add("APELLIDO", SqlDbType.NVarChar).Value = Apellido;
            cmd.Parameters.Add("NOMBRE", SqlDbType.NVarChar).Value = Nombre;
            int cantidadFilasAfectadas = cmd.ExecuteNonQuery();
            if (cantidadFilasAfectadas > 0)
            {
                MessageBox.Show("Cliente eliminado con éxito.", "Información");
            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar eliminar al cliente.", "Error");
            }
        }

        private void limpiarCampos()
        {
            textBoxNombre.Text = "";
            textBoxApellido.Text = "";
            textBoxDNI.Text = "";
            textBoxMail.Text = "";
            textBoxTelefono.Text = "";
            textBoxCalle.Text = "";
            textBoxNroPiso.Text = "";
            textBoxDepto.Text = "";
            textBoxLocalidad.Text = "";
            textBoxCodigoPostal.Text = "";
            textBoxFechaDeNacimiento.Text = "";
            comboBoxResultadoBusqueda.Items.Clear();
        }

        private void llenarCamposParaModificar(int DNI, string Apellido, string Nombre)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT cli_nombre, cli_apellido, cli_dni, cli_mail, cli_tel, cli_dir, cli_cp, cli_fecha_nac, cli_habilitado FROM GOQ.Cliente WHERE cli_dni = @DNI AND cli_apellido = @APELLIDO AND cli_nombre = @NOMBRE",
                PagoAgilFrba.ModuloGlobal.getConexion());
            cmd.Parameters.Add("DNI", SqlDbType.Decimal).Value = DNI;
            cmd.Parameters.Add("APELLIDO", SqlDbType.NVarChar).Value = Apellido;
            cmd.Parameters.Add("NOMBRE", SqlDbType.NVarChar).Value = Nombre;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                textBoxNombre.Text = Convert.ToString(reader.GetValue(0));
                textBoxApellido.Text = Convert.ToString(reader.GetValue(1));
                textBoxDNI.Text = Convert.ToString(reader.GetValue(2));
                DNISinModificar = Convert.ToInt32(textBoxDNI.Text);
                textBoxMail.Text = Convert.ToString(reader.GetValue(3));
                MailSinModificar = textBoxMail.Text;
                textBoxTelefono.Text = Convert.ToString(reader.GetValue(4));
                string[] direccion = Convert.ToString(reader.GetValue(5)).Split(new Char[] { ' ' });
                textBoxNroPiso.Text = Convert.ToString(direccion[direccion.Length - 1]);
                textBoxCalle.Text = Convert.ToString(reader.GetValue(5)).Remove((reader.GetString(5).Length - direccion[direccion.Length - 1].Length), direccion[direccion.Length - 1].Length);
                textBoxLocalidad.Text = "-";
                textBoxDepto.Text = "-";
                textBoxCodigoPostal.Text = Convert.ToString(reader.GetValue(6));
                textBoxFechaDeNacimiento.Text = Convert.ToString(reader.GetValue(7));
                if (Convert.ToInt32(reader.GetValue(8)) == 0)
                {
                    checkBoxCliente.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Ocurrió un error al obtener los datos del cliente.", "Error");
            }
            reader.Close();
        }

        private bool clienteNoEstaInhabilitado(int DNI, string Apellido, string Nombre)
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand("SELECT cli_id FROM GOQ.Cliente WHERE cli_dni = @DNI AND cli_apellido = @APELLIDO AND cli_nombre = @NOMBRE AND cli_habilitado = 0",
                    PagoAgilFrba.ModuloGlobal.getConexion());
            cmd.Parameters.Add("DNI", SqlDbType.Decimal).Value = DNI;
            cmd.Parameters.Add("APELLIDO", SqlDbType.NVarChar).Value = Apellido;
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

        private void altaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ocultarTodosLosItems();
            limpiarCampos();
            labelTitulo.Text = "ALTA";
            mostrarAlta();
        }


        private void labelNroPiso_Click(object sender, EventArgs e)
        {

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void modificaciónToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ocultarTodosLosItems();
            limpiarCampos();
            labelTitulo.Text = "MODIFICACION";
            mostrarBusqueda();
        }

        private void buttonBuscar_Click_1(object sender, EventArgs e)
        {
            if (camposDeBusquedaCompletos())
            {
                if (realizarBusquedayDevolverResultado())
                {
                    MessageBox.Show("El cliente fue encontrado.", "Información");
                    mostrarResultadosBusqueda();
                }
                else
                {
                    MessageBox.Show("El cliente no ha sido encontrado, intente nuevamente.", "Error");
                }
            }
            else
            {
                MessageBox.Show("Complete alguno de los campos para realizar la búsqueda.", "Error");
            }

        }

        private void comboBoxResultadoBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (labelTitulo.Text == "MODIFICACION")
            {
                if (MessageBox.Show("¿Desea modificar el usuario seleccionado?", "Información",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ocultarTodosLosItems();
                    string[] camposABuscar = comboBoxResultadoBusqueda.SelectedItem.ToString().Replace(" ", "").Split(new Char[] { '-' });
                    limpiarCampos();
                    llenarCamposParaModificar(Convert.ToInt32(camposABuscar[0]), camposABuscar[1], camposABuscar[2]);
                    DNIAModificar = Convert.ToInt32(camposABuscar[0]);
                    ApellidoAModificar = camposABuscar[1];
                    NombreAModificar = camposABuscar[2];
                    mostrarAlta();
                }
            }
            else
            {
                if (MessageBox.Show("¿Desea eliminar al usuario seleccionado?", "Información",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string[] camposABuscar = comboBoxResultadoBusqueda.SelectedItem.ToString().Replace(" ", "").Split(new Char[] { '-' });
                    if (clienteNoEstaInhabilitado(Convert.ToInt32(camposABuscar[0]), camposABuscar[1], camposABuscar[2]))
                    {
                        inhabilitarCliente(Convert.ToInt32(camposABuscar[0]), camposABuscar[1], camposABuscar[2]);
                    }
                    else
                    {
                        MessageBox.Show("El cliente ya se encuentra eliminado, intente con otro.", "Información");
                    }

                }
            }
        }



        private void comboBoxResultadoBusqueda_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (labelTitulo.Text == "MODIFICACION")
            {
                if (MessageBox.Show("¿Desea modificar el usuario seleccionado?", "Información",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ocultarTodosLosItems();
                    string[] camposABuscar = comboBoxResultadoBusqueda.SelectedItem.ToString().Replace(" ", "").Split(new Char[] { '-' });
                    limpiarCampos();
                    llenarCamposParaModificar(Convert.ToInt32(camposABuscar[0]), camposABuscar[1], camposABuscar[2]);
                    DNIAModificar = Convert.ToInt32(camposABuscar[0]);
                    ApellidoAModificar = camposABuscar[1];
                    NombreAModificar = camposABuscar[2];
                    mostrarAlta();
                }
            }
            else
            {
                if (MessageBox.Show("¿Desea eliminar al usuario seleccionado?", "Información",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string[] camposABuscar = comboBoxResultadoBusqueda.SelectedItem.ToString().Replace(" ", "").Split(new Char[] { '-' });
                    if (clienteNoEstaInhabilitado(Convert.ToInt32(camposABuscar[0]), camposABuscar[1], camposABuscar[2]))
                    {
                        inhabilitarCliente(Convert.ToInt32(camposABuscar[0]), camposABuscar[1], camposABuscar[2]);
                    }
                    else
                    {
                        MessageBox.Show("El cliente ya se encuentra eliminado, intente con otro.", "Información");
                    }

                }
            }
        }




        private void bajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ocultarTodosLosItems();
            limpiarCampos();
            labelTitulo.Text = "BAJA";
            mostrarBusqueda();
        }



        private void comboBoxFiltro_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ocultarTodosLosItems();
            labelTitulo.Visible = true;
            labelFiltro.Visible = true;
            comboBoxFiltro.Visible = true;
            if (comboBoxFiltro.SelectedItem.ToString() == "Todos")
            {
                labelNombre.Visible = true;
                labelApellido.Visible = true;
                labelDNI.Visible = true;
                textBoxNombre.Visible = true;
                textBoxApellido.Visible = true;
                textBoxDNI.Visible = true;
                buttonBuscar.Visible = true;
                buttonLimpiar.Visible = true;
            }
            else if (comboBoxFiltro.SelectedItem.ToString() == "DNI")
            {
                labelDNI.Visible = true;
                textBoxDNI.Visible = true;
                buttonBuscar.Visible = true;
                buttonLimpiar.Visible = true;

            }
            else if (comboBoxFiltro.SelectedItem.ToString() == "Apellido")
            {
                labelApellido.Visible = true;
                textBoxApellido.Visible = true;
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
    }
}





