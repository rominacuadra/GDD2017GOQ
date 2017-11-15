namespace PagoAgilFrba.AbmCliente
{
    partial class ABMCliente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ABMCliente));
            this.checkBoxCliente = new System.Windows.Forms.CheckBox();
            this.labelFiltro = new System.Windows.Forms.Label();
            this.comboBoxFiltro = new System.Windows.Forms.ComboBox();
            this.labelResultadoBusqueda = new System.Windows.Forms.Label();
            this.comboBoxResultadoBusqueda = new System.Windows.Forms.ComboBox();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.textBoxFechaDeNacimiento = new System.Windows.Forms.TextBox();
            this.textBoxCodigoPostal = new System.Windows.Forms.TextBox();
            this.textBoxLocalidad = new System.Windows.Forms.TextBox();
            this.textBoxDepto = new System.Windows.Forms.TextBox();
            this.textBoxNroPiso = new System.Windows.Forms.TextBox();
            this.textBoxCalle = new System.Windows.Forms.TextBox();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.textBoxDNI = new System.Windows.Forms.TextBox();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.labelCalle = new System.Windows.Forms.Label();
            this.labelFechaDeNacimiento = new System.Windows.Forms.Label();
            this.labelCodigoPostal = new System.Windows.Forms.Label();
            this.labelLocalidad = new System.Windows.Forms.Label();
            this.labelDepto = new System.Windows.Forms.Label();
            this.labelNroPiso = new System.Windows.Forms.Label();
            this.labelDireccion = new System.Windows.Forms.Label();
            this.labelTelefono = new System.Windows.Forms.Label();
            this.labelMail = new System.Windows.Forms.Label();
            this.labelDNI = new System.Windows.Forms.Label();
            this.labelApellido = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuABMCli = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.buttonMail1 = new System.Windows.Forms.Button();
            this.buttonMail2 = new System.Windows.Forms.Button();
            this.menuABMCli.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxCliente
            // 
            this.checkBoxCliente.AutoSize = true;
            this.checkBoxCliente.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.checkBoxCliente.Location = new System.Drawing.Point(416, 523);
            this.checkBoxCliente.Name = "checkBoxCliente";
            this.checkBoxCliente.Size = new System.Drawing.Size(99, 17);
            this.checkBoxCliente.TabIndex = 64;
            this.checkBoxCliente.Text = "Habilitar Cliente";
            this.checkBoxCliente.UseVisualStyleBackColor = true;
            // 
            // labelFiltro
            // 
            this.labelFiltro.AutoSize = true;
            this.labelFiltro.Location = new System.Drawing.Point(103, 93);
            this.labelFiltro.Name = "labelFiltro";
            this.labelFiltro.Size = new System.Drawing.Size(54, 13);
            this.labelFiltro.TabIndex = 63;
            this.labelFiltro.Text = "Filtrar Por:";
            // 
            // comboBoxFiltro
            // 
            this.comboBoxFiltro.FormattingEnabled = true;
            this.comboBoxFiltro.Location = new System.Drawing.Point(104, 109);
            this.comboBoxFiltro.Name = "comboBoxFiltro";
            this.comboBoxFiltro.Size = new System.Drawing.Size(216, 21);
            this.comboBoxFiltro.TabIndex = 62;
            this.comboBoxFiltro.SelectedIndexChanged += new System.EventHandler(this.comboBoxFiltro_SelectedIndexChanged_1);
            // 
            // labelResultadoBusqueda
            // 
            this.labelResultadoBusqueda.AutoSize = true;
            this.labelResultadoBusqueda.Location = new System.Drawing.Point(356, 117);
            this.labelResultadoBusqueda.Name = "labelResultadoBusqueda";
            this.labelResultadoBusqueda.Size = new System.Drawing.Size(110, 13);
            this.labelResultadoBusqueda.TabIndex = 61;
            this.labelResultadoBusqueda.Text = "Clientes Encontrados:";
            // 
            // comboBoxResultadoBusqueda
            // 
            this.comboBoxResultadoBusqueda.FormattingEnabled = true;
            this.comboBoxResultadoBusqueda.Location = new System.Drawing.Point(347, 146);
            this.comboBoxResultadoBusqueda.Name = "comboBoxResultadoBusqueda";
            this.comboBoxResultadoBusqueda.Size = new System.Drawing.Size(226, 21);
            this.comboBoxResultadoBusqueda.TabIndex = 60;
            this.comboBoxResultadoBusqueda.SelectedIndexChanged += new System.EventHandler(this.comboBoxResultadoBusqueda_SelectedIndexChanged);
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(391, 567);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscar.TabIndex = 59;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click_1);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(277, 567);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 58;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(174, 567);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(75, 23);
            this.buttonAceptar.TabIndex = 57;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // textBoxFechaDeNacimiento
            // 
            this.textBoxFechaDeNacimiento.Location = new System.Drawing.Point(220, 520);
            this.textBoxFechaDeNacimiento.Name = "textBoxFechaDeNacimiento";
            this.textBoxFechaDeNacimiento.Size = new System.Drawing.Size(100, 20);
            this.textBoxFechaDeNacimiento.TabIndex = 55;
            // 
            // textBoxCodigoPostal
            // 
            this.textBoxCodigoPostal.Location = new System.Drawing.Point(220, 476);
            this.textBoxCodigoPostal.Name = "textBoxCodigoPostal";
            this.textBoxCodigoPostal.Size = new System.Drawing.Size(100, 20);
            this.textBoxCodigoPostal.TabIndex = 54;
            // 
            // textBoxLocalidad
            // 
            this.textBoxLocalidad.Location = new System.Drawing.Point(473, 426);
            this.textBoxLocalidad.Name = "textBoxLocalidad";
            this.textBoxLocalidad.Size = new System.Drawing.Size(100, 20);
            this.textBoxLocalidad.TabIndex = 53;
            // 
            // textBoxDepto
            // 
            this.textBoxDepto.Location = new System.Drawing.Point(347, 426);
            this.textBoxDepto.Name = "textBoxDepto";
            this.textBoxDepto.Size = new System.Drawing.Size(100, 20);
            this.textBoxDepto.TabIndex = 52;
            // 
            // textBoxNroPiso
            // 
            this.textBoxNroPiso.Location = new System.Drawing.Point(220, 426);
            this.textBoxNroPiso.Name = "textBoxNroPiso";
            this.textBoxNroPiso.Size = new System.Drawing.Size(100, 20);
            this.textBoxNroPiso.TabIndex = 51;
            // 
            // textBoxCalle
            // 
            this.textBoxCalle.Location = new System.Drawing.Point(104, 426);
            this.textBoxCalle.Name = "textBoxCalle";
            this.textBoxCalle.Size = new System.Drawing.Size(100, 20);
            this.textBoxCalle.TabIndex = 50;
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.Location = new System.Drawing.Point(220, 329);
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(100, 20);
            this.textBoxTelefono.TabIndex = 49;
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(220, 281);
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(100, 20);
            this.textBoxMail.TabIndex = 48;
            // 
            // textBoxDNI
            // 
            this.textBoxDNI.Location = new System.Drawing.Point(220, 234);
            this.textBoxDNI.Name = "textBoxDNI";
            this.textBoxDNI.Size = new System.Drawing.Size(100, 20);
            this.textBoxDNI.TabIndex = 47;
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(220, 190);
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(100, 20);
            this.textBoxApellido.TabIndex = 46;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(220, 147);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(100, 20);
            this.textBoxNombre.TabIndex = 45;
            // 
            // labelCalle
            // 
            this.labelCalle.AutoSize = true;
            this.labelCalle.Location = new System.Drawing.Point(103, 400);
            this.labelCalle.Name = "labelCalle";
            this.labelCalle.Size = new System.Drawing.Size(33, 13);
            this.labelCalle.TabIndex = 44;
            this.labelCalle.Text = "Calle:";
            // 
            // labelFechaDeNacimiento
            // 
            this.labelFechaDeNacimiento.AutoSize = true;
            this.labelFechaDeNacimiento.Location = new System.Drawing.Point(103, 523);
            this.labelFechaDeNacimiento.Name = "labelFechaDeNacimiento";
            this.labelFechaDeNacimiento.Size = new System.Drawing.Size(111, 13);
            this.labelFechaDeNacimiento.TabIndex = 43;
            this.labelFechaDeNacimiento.Text = "Fecha de Nacimiento:";
            // 
            // labelCodigoPostal
            // 
            this.labelCodigoPostal.AutoSize = true;
            this.labelCodigoPostal.Location = new System.Drawing.Point(103, 479);
            this.labelCodigoPostal.Name = "labelCodigoPostal";
            this.labelCodigoPostal.Size = new System.Drawing.Size(75, 13);
            this.labelCodigoPostal.TabIndex = 42;
            this.labelCodigoPostal.Text = "Código Postal:";
            // 
            // labelLocalidad
            // 
            this.labelLocalidad.AutoSize = true;
            this.labelLocalidad.Location = new System.Drawing.Point(470, 400);
            this.labelLocalidad.Name = "labelLocalidad";
            this.labelLocalidad.Size = new System.Drawing.Size(56, 13);
            this.labelLocalidad.TabIndex = 41;
            this.labelLocalidad.Text = "Localidad:";
            // 
            // labelDepto
            // 
            this.labelDepto.AutoSize = true;
            this.labelDepto.Location = new System.Drawing.Point(344, 400);
            this.labelDepto.Name = "labelDepto";
            this.labelDepto.Size = new System.Drawing.Size(39, 13);
            this.labelDepto.TabIndex = 40;
            this.labelDepto.Text = "Depto:";
            // 
            // labelNroPiso
            // 
            this.labelNroPiso.AutoSize = true;
            this.labelNroPiso.Location = new System.Drawing.Point(217, 400);
            this.labelNroPiso.Name = "labelNroPiso";
            this.labelNroPiso.Size = new System.Drawing.Size(50, 13);
            this.labelNroPiso.TabIndex = 39;
            this.labelNroPiso.Text = "Nro Piso:";
            // 
            // labelDireccion
            // 
            this.labelDireccion.AutoSize = true;
            this.labelDireccion.Location = new System.Drawing.Point(101, 376);
            this.labelDireccion.Name = "labelDireccion";
            this.labelDireccion.Size = new System.Drawing.Size(55, 13);
            this.labelDireccion.TabIndex = 38;
            this.labelDireccion.Text = "Dirección:";
            // 
            // labelTelefono
            // 
            this.labelTelefono.AutoSize = true;
            this.labelTelefono.Location = new System.Drawing.Point(101, 332);
            this.labelTelefono.Name = "labelTelefono";
            this.labelTelefono.Size = new System.Drawing.Size(52, 13);
            this.labelTelefono.TabIndex = 37;
            this.labelTelefono.Text = "Teléfono:";
            // 
            // labelMail
            // 
            this.labelMail.AutoSize = true;
            this.labelMail.Location = new System.Drawing.Point(101, 284);
            this.labelMail.Name = "labelMail";
            this.labelMail.Size = new System.Drawing.Size(29, 13);
            this.labelMail.TabIndex = 36;
            this.labelMail.Text = "Mail:";
            // 
            // labelDNI
            // 
            this.labelDNI.AutoSize = true;
            this.labelDNI.Location = new System.Drawing.Point(101, 237);
            this.labelDNI.Name = "labelDNI";
            this.labelDNI.Size = new System.Drawing.Size(29, 13);
            this.labelDNI.TabIndex = 35;
            this.labelDNI.Text = "DNI:";
            // 
            // labelApellido
            // 
            this.labelApellido.AutoSize = true;
            this.labelApellido.Location = new System.Drawing.Point(101, 193);
            this.labelApellido.Name = "labelApellido";
            this.labelApellido.Size = new System.Drawing.Size(47, 13);
            this.labelApellido.TabIndex = 34;
            this.labelApellido.Text = "Apellido:";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(101, 150);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(47, 13);
            this.labelNombre.TabIndex = 33;
            this.labelNombre.Text = "Nombre:";
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(33, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 41);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administración del Cliente";
            // 
            // menuABMCli
            // 
            this.menuABMCli.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuABMCli.Location = new System.Drawing.Point(0, 0);
            this.menuABMCli.Name = "menuABMCli";
            this.menuABMCli.Size = new System.Drawing.Size(705, 24);
            this.menuABMCli.TabIndex = 66;
            this.menuABMCli.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaToolStripMenuItem,
            this.modificaciónToolStripMenuItem,
            this.bajaToolStripMenuItem,
            this.cerrarToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.archivoToolStripMenuItem.Text = "Administrar";
            // 
            // altaToolStripMenuItem
            // 
            this.altaToolStripMenuItem.Name = "altaToolStripMenuItem";
            this.altaToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.altaToolStripMenuItem.Text = "Alta";
            this.altaToolStripMenuItem.Click += new System.EventHandler(this.altaToolStripMenuItem_Click_1);
            // 
            // modificaciónToolStripMenuItem
            // 
            this.modificaciónToolStripMenuItem.Name = "modificaciónToolStripMenuItem";
            this.modificaciónToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.modificaciónToolStripMenuItem.Text = "Modificación";
            this.modificaciónToolStripMenuItem.Click += new System.EventHandler(this.modificaciónToolStripMenuItem_Click_1);
            // 
            // bajaToolStripMenuItem
            // 
            this.bajaToolStripMenuItem.Name = "bajaToolStripMenuItem";
            this.bajaToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.bajaToolStripMenuItem.Text = "Baja";
            this.bajaToolStripMenuItem.Click += new System.EventHandler(this.bajaToolStripMenuItem_Click);
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(35, 73);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(52, 13);
            this.labelTitulo.TabIndex = 67;
            this.labelTitulo.Text = "TITULO";
            // 
            // buttonMail1
            // 
            this.buttonMail1.Location = new System.Drawing.Point(174, 567);
            this.buttonMail1.Name = "buttonMail1";
            this.buttonMail1.Size = new System.Drawing.Size(75, 23);
            this.buttonMail1.TabIndex = 69;
            this.buttonMail1.Text = "Aceptar";
            this.buttonMail1.UseVisualStyleBackColor = true;
            this.buttonMail1.Click += new System.EventHandler(this.buttonMail1_Click);
            // 
            // buttonMail2
            // 
            this.buttonMail2.Location = new System.Drawing.Point(174, 567);
            this.buttonMail2.Name = "buttonMail2";
            this.buttonMail2.Size = new System.Drawing.Size(75, 23);
            this.buttonMail2.TabIndex = 70;
            this.buttonMail2.Text = "Aceptar";
            this.buttonMail2.UseVisualStyleBackColor = true;
            this.buttonMail2.Click += new System.EventHandler(this.buttonMail2_Click);
            // 
            // ABMCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 605);
            this.Controls.Add(this.buttonMail2);
            this.Controls.Add(this.buttonMail1);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.menuABMCli);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBoxCliente);
            this.Controls.Add(this.labelFiltro);
            this.Controls.Add(this.comboBoxFiltro);
            this.Controls.Add(this.labelResultadoBusqueda);
            this.Controls.Add(this.comboBoxResultadoBusqueda);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.textBoxFechaDeNacimiento);
            this.Controls.Add(this.textBoxCodigoPostal);
            this.Controls.Add(this.textBoxLocalidad);
            this.Controls.Add(this.textBoxDepto);
            this.Controls.Add(this.textBoxNroPiso);
            this.Controls.Add(this.textBoxCalle);
            this.Controls.Add(this.textBoxTelefono);
            this.Controls.Add(this.textBoxMail);
            this.Controls.Add(this.textBoxDNI);
            this.Controls.Add(this.textBoxApellido);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.labelCalle);
            this.Controls.Add(this.labelFechaDeNacimiento);
            this.Controls.Add(this.labelCodigoPostal);
            this.Controls.Add(this.labelLocalidad);
            this.Controls.Add(this.labelDepto);
            this.Controls.Add(this.labelNroPiso);
            this.Controls.Add(this.labelDireccion);
            this.Controls.Add(this.labelTelefono);
            this.Controls.Add(this.labelMail);
            this.Controls.Add(this.labelDNI);
            this.Controls.Add(this.labelApellido);
            this.Controls.Add(this.labelNombre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ABMCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administración del Cliente";
            this.menuABMCli.ResumeLayout(false);
            this.menuABMCli.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxCliente;
        private System.Windows.Forms.Label labelFiltro;
        private System.Windows.Forms.ComboBox comboBoxFiltro;
        private System.Windows.Forms.Label labelResultadoBusqueda;
        private System.Windows.Forms.ComboBox comboBoxResultadoBusqueda;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.TextBox textBoxFechaDeNacimiento;
        private System.Windows.Forms.TextBox textBoxCodigoPostal;
        private System.Windows.Forms.TextBox textBoxLocalidad;
        private System.Windows.Forms.TextBox textBoxDepto;
        private System.Windows.Forms.TextBox textBoxNroPiso;
        private System.Windows.Forms.TextBox textBoxCalle;
        private System.Windows.Forms.TextBox textBoxTelefono;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.TextBox textBoxDNI;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label labelCalle;
        private System.Windows.Forms.Label labelFechaDeNacimiento;
        private System.Windows.Forms.Label labelCodigoPostal;
        private System.Windows.Forms.Label labelLocalidad;
        private System.Windows.Forms.Label labelDepto;
        private System.Windows.Forms.Label labelNroPiso;
        private System.Windows.Forms.Label labelDireccion;
        private System.Windows.Forms.Label labelTelefono;
        private System.Windows.Forms.Label labelMail;
        private System.Windows.Forms.Label labelDNI;
        private System.Windows.Forms.Label labelApellido;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuABMCli;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Button buttonMail1;
        private System.Windows.Forms.Button buttonMail2;
    }
}