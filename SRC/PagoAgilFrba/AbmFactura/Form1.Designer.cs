namespace PagoAgilFrba.AbmFactura
{
    partial class AbmFactura
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
            this.menuABMCli = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelNroFac = new System.Windows.Forms.Label();
            this.textBoxNroFac = new System.Windows.Forms.TextBox();
            this.labelEmpresa = new System.Windows.Forms.Label();
            this.comboBoxEmpresa = new System.Windows.Forms.ComboBox();
            this.labelCliente = new System.Windows.Forms.Label();
            this.comboBoxCliente = new System.Windows.Forms.ComboBox();
            this.labelFechaDeVenc = new System.Windows.Forms.Label();
            this.buttonAceptar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.labelFechaAlta = new System.Windows.Forms.Label();
            this.textBoxFechaAlta = new System.Windows.Forms.TextBox();
            this.labelTotal = new System.Windows.Forms.Label();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.labelItemMonto = new System.Windows.Forms.Label();
            this.labelItemCantidad = new System.Windows.Forms.Label();
            this.textBoxItemMonto = new System.Windows.Forms.TextBox();
            this.textBoxItemCantidad = new System.Windows.Forms.TextBox();
            this.dtFechaVen = new System.Windows.Forms.DateTimePicker();
            this.menuABMCli.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuABMCli
            // 
            this.menuABMCli.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuABMCli.Location = new System.Drawing.Point(0, 0);
            this.menuABMCli.Name = "menuABMCli";
            this.menuABMCli.Size = new System.Drawing.Size(654, 24);
            this.menuABMCli.TabIndex = 102;
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
            // 
            // bajaToolStripMenuItem
            // 
            this.bajaToolStripMenuItem.Name = "bajaToolStripMenuItem";
            this.bajaToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.bajaToolStripMenuItem.Text = "Baja";
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
            this.groupBox1.Location = new System.Drawing.Point(47, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 41);
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Administración Factura";
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Location = new System.Drawing.Point(54, 71);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(33, 13);
            this.labelTitulo.TabIndex = 119;
            this.labelTitulo.Text = "Titulo";
            // 
            // labelNroFac
            // 
            this.labelNroFac.AutoSize = true;
            this.labelNroFac.Location = new System.Drawing.Point(54, 164);
            this.labelNroFac.Name = "labelNroFac";
            this.labelNroFac.Size = new System.Drawing.Size(66, 13);
            this.labelNroFac.TabIndex = 120;
            this.labelNroFac.Text = "Nro Factura:";
            // 
            // textBoxNroFac
            // 
            this.textBoxNroFac.Location = new System.Drawing.Point(180, 164);
            this.textBoxNroFac.Name = "textBoxNroFac";
            this.textBoxNroFac.Size = new System.Drawing.Size(114, 20);
            this.textBoxNroFac.TabIndex = 121;
            // 
            // labelEmpresa
            // 
            this.labelEmpresa.AutoSize = true;
            this.labelEmpresa.Location = new System.Drawing.Point(54, 201);
            this.labelEmpresa.Name = "labelEmpresa";
            this.labelEmpresa.Size = new System.Drawing.Size(51, 13);
            this.labelEmpresa.TabIndex = 122;
            this.labelEmpresa.Text = "Empresa:";
            // 
            // comboBoxEmpresa
            // 
            this.comboBoxEmpresa.FormattingEnabled = true;
            this.comboBoxEmpresa.Location = new System.Drawing.Point(180, 201);
            this.comboBoxEmpresa.Name = "comboBoxEmpresa";
            this.comboBoxEmpresa.Size = new System.Drawing.Size(114, 21);
            this.comboBoxEmpresa.TabIndex = 123;
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Location = new System.Drawing.Point(54, 244);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(42, 13);
            this.labelCliente.TabIndex = 124;
            this.labelCliente.Text = "Cliente:";
            // 
            // comboBoxCliente
            // 
            this.comboBoxCliente.FormattingEnabled = true;
            this.comboBoxCliente.Location = new System.Drawing.Point(180, 241);
            this.comboBoxCliente.Name = "comboBoxCliente";
            this.comboBoxCliente.Size = new System.Drawing.Size(114, 21);
            this.comboBoxCliente.TabIndex = 125;
            // 
            // labelFechaDeVenc
            // 
            this.labelFechaDeVenc.AutoSize = true;
            this.labelFechaDeVenc.Location = new System.Drawing.Point(54, 286);
            this.labelFechaDeVenc.Name = "labelFechaDeVenc";
            this.labelFechaDeVenc.Size = new System.Drawing.Size(115, 13);
            this.labelFechaDeVenc.TabIndex = 126;
            this.labelFechaDeVenc.Text = "Fecha de vencimiento:";
            // 
            // buttonAceptar
            // 
            this.buttonAceptar.Location = new System.Drawing.Point(65, 524);
            this.buttonAceptar.Name = "buttonAceptar";
            this.buttonAceptar.Size = new System.Drawing.Size(75, 23);
            this.buttonAceptar.TabIndex = 132;
            this.buttonAceptar.Text = "Aceptar";
            this.buttonAceptar.UseVisualStyleBackColor = true;
            this.buttonAceptar.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(180, 524);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 133;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // labelFechaAlta
            // 
            this.labelFechaAlta.AutoSize = true;
            this.labelFechaAlta.Location = new System.Drawing.Point(57, 340);
            this.labelFechaAlta.Name = "labelFechaAlta";
            this.labelFechaAlta.Size = new System.Drawing.Size(75, 13);
            this.labelFechaAlta.TabIndex = 134;
            this.labelFechaAlta.Text = "Fecha de alta:";
            // 
            // textBoxFechaAlta
            // 
            this.textBoxFechaAlta.Location = new System.Drawing.Point(180, 337);
            this.textBoxFechaAlta.Name = "textBoxFechaAlta";
            this.textBoxFechaAlta.Size = new System.Drawing.Size(114, 20);
            this.textBoxFechaAlta.TabIndex = 135;
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(62, 385);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(34, 13);
            this.labelTotal.TabIndex = 136;
            this.labelTotal.Text = "Total:";
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.Location = new System.Drawing.Point(180, 382);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.Size = new System.Drawing.Size(114, 20);
            this.textBoxTotal.TabIndex = 137;
            // 
            // labelItemMonto
            // 
            this.labelItemMonto.AutoSize = true;
            this.labelItemMonto.Location = new System.Drawing.Point(62, 430);
            this.labelItemMonto.Name = "labelItemMonto";
            this.labelItemMonto.Size = new System.Drawing.Size(63, 13);
            this.labelItemMonto.TabIndex = 138;
            this.labelItemMonto.Text = "Item Monto:";
            // 
            // labelItemCantidad
            // 
            this.labelItemCantidad.AutoSize = true;
            this.labelItemCantidad.Location = new System.Drawing.Point(62, 478);
            this.labelItemCantidad.Name = "labelItemCantidad";
            this.labelItemCantidad.Size = new System.Drawing.Size(75, 13);
            this.labelItemCantidad.TabIndex = 139;
            this.labelItemCantidad.Text = "Item Cantidad:";
            this.labelItemCantidad.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBoxItemMonto
            // 
            this.textBoxItemMonto.Location = new System.Drawing.Point(180, 427);
            this.textBoxItemMonto.Name = "textBoxItemMonto";
            this.textBoxItemMonto.Size = new System.Drawing.Size(114, 20);
            this.textBoxItemMonto.TabIndex = 140;
            // 
            // textBoxItemCantidad
            // 
            this.textBoxItemCantidad.Location = new System.Drawing.Point(180, 478);
            this.textBoxItemCantidad.Name = "textBoxItemCantidad";
            this.textBoxItemCantidad.Size = new System.Drawing.Size(114, 20);
            this.textBoxItemCantidad.TabIndex = 141;
            // 
            // dtFechaVen
            // 
            this.dtFechaVen.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaVen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaVen.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaVen.Location = new System.Drawing.Point(180, 286);
            this.dtFechaVen.Name = "dtFechaVen";
            this.dtFechaVen.Size = new System.Drawing.Size(114, 26);
            this.dtFechaVen.TabIndex = 142;
            // 
            // AbmFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 564);
            this.Controls.Add(this.dtFechaVen);
            this.Controls.Add(this.textBoxItemCantidad);
            this.Controls.Add(this.textBoxItemMonto);
            this.Controls.Add(this.labelItemCantidad);
            this.Controls.Add(this.labelItemMonto);
            this.Controls.Add(this.textBoxTotal);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.textBoxFechaAlta);
            this.Controls.Add(this.labelFechaAlta);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonAceptar);
            this.Controls.Add(this.labelFechaDeVenc);
            this.Controls.Add(this.comboBoxCliente);
            this.Controls.Add(this.labelCliente);
            this.Controls.Add(this.comboBoxEmpresa);
            this.Controls.Add(this.labelEmpresa);
            this.Controls.Add(this.textBoxNroFac);
            this.Controls.Add(this.labelNroFac);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuABMCli);
            this.Name = "AbmFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administracion de Factura";
            this.menuABMCli.ResumeLayout(false);
            this.menuABMCli.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuABMCli;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelNroFac;
        private System.Windows.Forms.TextBox textBoxNroFac;
        private System.Windows.Forms.Label labelEmpresa;
        private System.Windows.Forms.ComboBox comboBoxEmpresa;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.ComboBox comboBoxCliente;
        private System.Windows.Forms.Label labelFechaDeVenc;
        private System.Windows.Forms.Button buttonAceptar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Label labelFechaAlta;
        private System.Windows.Forms.TextBox textBoxFechaAlta;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.Label labelItemMonto;
        private System.Windows.Forms.Label labelItemCantidad;
        private System.Windows.Forms.TextBox textBoxItemMonto;
        private System.Windows.Forms.TextBox textBoxItemCantidad;
        private System.Windows.Forms.DateTimePicker dtFechaVen;
    }
}