namespace PagoAgilFrba.AbmSucursal
{
    partial class ABMSucursal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ABMSucursal));
            this.labelTitulo = new System.Windows.Forms.Label();
            this.menuABMCli = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxSucu = new System.Windows.Forms.CheckBox();
            this.labelFiltro = new System.Windows.Forms.Label();
            this.comboBoxFiltro = new System.Windows.Forms.ComboBox();
            this.labelResultadoBusqueda = new System.Windows.Forms.Label();
            this.comboBoxResultadoBusqueda = new System.Windows.Forms.ComboBox();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.textBoxCodigoPostal = new System.Windows.Forms.TextBox();
            this.textBoxDirec = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.labelCodigoPostal = new System.Windows.Forms.Label();
            this.labelDirec = new System.Windows.Forms.Label();
            this.labelNombre = new System.Windows.Forms.Label();
            this.menuABMCli.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitulo.Location = new System.Drawing.Point(35, 80);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(52, 13);
            this.labelTitulo.TabIndex = 101;
            this.labelTitulo.Text = "TITULO";
            // 
            // menuABMCli
            // 
            this.menuABMCli.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuABMCli.Location = new System.Drawing.Point(0, 0);
            this.menuABMCli.Name = "menuABMCli";
            this.menuABMCli.Size = new System.Drawing.Size(607, 24);
            this.menuABMCli.TabIndex = 100;
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
            this.altaToolStripMenuItem.Click += new System.EventHandler(this.altaToolStripMenuItem_Click);
            // 
            // modificaciónToolStripMenuItem
            // 
            this.modificaciónToolStripMenuItem.Name = "modificaciónToolStripMenuItem";
            this.modificaciónToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.modificaciónToolStripMenuItem.Text = "Modificación";
            this.modificaciónToolStripMenuItem.Click += new System.EventHandler(this.modificaciónToolStripMenuItem_Click);
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
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(33, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(562, 41);
            this.groupBox1.TabIndex = 99;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administración Sucursal";
            // 
            // checkBoxSucu
            // 
            this.checkBoxSucu.AutoSize = true;
            this.checkBoxSucu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.checkBoxSucu.Location = new System.Drawing.Point(359, 258);
            this.checkBoxSucu.Name = "checkBoxSucu";
            this.checkBoxSucu.Size = new System.Drawing.Size(108, 17);
            this.checkBoxSucu.TabIndex = 98;
            this.checkBoxSucu.Text = "Habilitar Sucursal";
            this.checkBoxSucu.UseVisualStyleBackColor = true;
            // 
            // labelFiltro
            // 
            this.labelFiltro.AutoSize = true;
            this.labelFiltro.Location = new System.Drawing.Point(103, 116);
            this.labelFiltro.Name = "labelFiltro";
            this.labelFiltro.Size = new System.Drawing.Size(54, 13);
            this.labelFiltro.TabIndex = 97;
            this.labelFiltro.Text = "Filtrar Por:";
            // 
            // comboBoxFiltro
            // 
            this.comboBoxFiltro.FormattingEnabled = true;
            this.comboBoxFiltro.Location = new System.Drawing.Point(104, 132);
            this.comboBoxFiltro.Name = "comboBoxFiltro";
            this.comboBoxFiltro.Size = new System.Drawing.Size(216, 21);
            this.comboBoxFiltro.TabIndex = 96;
            this.comboBoxFiltro.SelectedIndexChanged += new System.EventHandler(this.comboBoxFiltro_SelectedIndexChanged);
            // 
            // labelResultadoBusqueda
            // 
            this.labelResultadoBusqueda.AutoSize = true;
            this.labelResultadoBusqueda.Location = new System.Drawing.Point(356, 140);
            this.labelResultadoBusqueda.Name = "labelResultadoBusqueda";
            this.labelResultadoBusqueda.Size = new System.Drawing.Size(125, 13);
            this.labelResultadoBusqueda.TabIndex = 95;
            this.labelResultadoBusqueda.Text = "Sucursales Encontradas:";
            // 
            // comboBoxResultadoBusqueda
            // 
            this.comboBoxResultadoBusqueda.FormattingEnabled = true;
            this.comboBoxResultadoBusqueda.Location = new System.Drawing.Point(347, 169);
            this.comboBoxResultadoBusqueda.Name = "comboBoxResultadoBusqueda";
            this.comboBoxResultadoBusqueda.Size = new System.Drawing.Size(226, 21);
            this.comboBoxResultadoBusqueda.TabIndex = 94;
            this.comboBoxResultadoBusqueda.SelectedIndexChanged += new System.EventHandler(this.comboBoxResultadoBusqueda_SelectedIndexChanged);
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(383, 313);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscar.TabIndex = 93;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(269, 313);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 92;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(155, 314);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(75, 23);
            this.buttonAceptar.TabIndex = 91;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // textBoxCodigoPostal
            // 
            this.textBoxCodigoPostal.Location = new System.Drawing.Point(220, 256);
            this.textBoxCodigoPostal.MaxLength = 16;
            this.textBoxCodigoPostal.Name = "textBoxCodigoPostal";
            this.textBoxCodigoPostal.Size = new System.Drawing.Size(100, 20);
            this.textBoxCodigoPostal.TabIndex = 89;
            // 
            // textBoxDirec
            // 
            this.textBoxDirec.Location = new System.Drawing.Point(220, 213);
            this.textBoxDirec.MaxLength = 40;
            this.textBoxDirec.Name = "textBoxDirec";
            this.textBoxDirec.Size = new System.Drawing.Size(100, 20);
            this.textBoxDirec.TabIndex = 81;
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(220, 170);
            this.textBoxNombre.MaxLength = 40;
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(100, 20);
            this.textBoxNombre.TabIndex = 80;
            // 
            // labelCodigoPostal
            // 
            this.labelCodigoPostal.AutoSize = true;
            this.labelCodigoPostal.Location = new System.Drawing.Point(103, 259);
            this.labelCodigoPostal.Name = "labelCodigoPostal";
            this.labelCodigoPostal.Size = new System.Drawing.Size(75, 13);
            this.labelCodigoPostal.TabIndex = 77;
            this.labelCodigoPostal.Text = "Código Postal:";
            // 
            // labelDirec
            // 
            this.labelDirec.AutoSize = true;
            this.labelDirec.Location = new System.Drawing.Point(101, 216);
            this.labelDirec.Name = "labelDirec";
            this.labelDirec.Size = new System.Drawing.Size(55, 13);
            this.labelDirec.TabIndex = 69;
            this.labelDirec.Text = "Dirección:";
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(101, 173);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(47, 13);
            this.labelNombre.TabIndex = 68;
            this.labelNombre.Text = "Nombre:";
            // 
            // ABMSucursal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 348);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.menuABMCli);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBoxSucu);
            this.Controls.Add(this.labelFiltro);
            this.Controls.Add(this.comboBoxFiltro);
            this.Controls.Add(this.labelResultadoBusqueda);
            this.Controls.Add(this.comboBoxResultadoBusqueda);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.textBoxCodigoPostal);
            this.Controls.Add(this.textBoxDirec);
            this.Controls.Add(this.textBoxNombre);
            this.Controls.Add(this.labelCodigoPostal);
            this.Controls.Add(this.labelDirec);
            this.Controls.Add(this.labelNombre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ABMSucursal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administracion de Sucursal";
            this.menuABMCli.ResumeLayout(false);
            this.menuABMCli.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.MenuStrip menuABMCli;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxSucu;
        private System.Windows.Forms.Label labelFiltro;
        private System.Windows.Forms.ComboBox comboBoxFiltro;
        private System.Windows.Forms.Label labelResultadoBusqueda;
        private System.Windows.Forms.ComboBox comboBoxResultadoBusqueda;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.TextBox textBoxCodigoPostal;
        private System.Windows.Forms.TextBox textBoxDirec;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label labelCodigoPostal;
        private System.Windows.Forms.Label labelDirec;
        private System.Windows.Forms.Label labelNombre;
    }
}