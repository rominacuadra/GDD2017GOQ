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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbmFactura));
            this.menuABMCli = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelNroFac = new System.Windows.Forms.Label();
            this.labelEmpresa = new System.Windows.Forms.Label();
            this.comboBoxEmpresa = new System.Windows.Forms.ComboBox();
            this.labelCliente = new System.Windows.Forms.Label();
            this.comboBoxCliente = new System.Windows.Forms.ComboBox();
            this.labelFechaDeVenc = new System.Windows.Forms.Label();
            this.buttonCrearFactura = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.labelFechaAlta = new System.Windows.Forms.Label();
            this.textBoxFechaAlta = new System.Windows.Forms.TextBox();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelItemMonto = new System.Windows.Forms.Label();
            this.labelItemCantidad = new System.Windows.Forms.Label();
            this.textBoxItemMonto = new System.Windows.Forms.TextBox();
            this.textBoxItemCantidad = new System.Windows.Forms.TextBox();
            this.dtFechaVen = new System.Windows.Forms.DateTimePicker();
            this.buttonAgregarItem = new System.Windows.Forms.Button();
            this.labelItemsAAgregar = new System.Windows.Forms.Label();
            this.listBoxItems = new System.Windows.Forms.ListBox();
            this.buttonLimpiarItems = new System.Windows.Forms.Button();
            this.labelDatosFactura = new System.Windows.Forms.Label();
            this.labelDatosItem = new System.Windows.Forms.Label();
            this.maskedTextBoxNroFact = new System.Windows.Forms.MaskedTextBox();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.labelFiltro = new System.Windows.Forms.Label();
            this.comboBoxFiltro = new System.Windows.Forms.ComboBox();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.labelFacturasEncontradas = new System.Windows.Forms.Label();
            this.comboBoxFacturasEncontradas = new System.Windows.Forms.ComboBox();
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
            this.comboBoxCliente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxCliente.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
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
            // buttonCrearFactura
            // 
            this.buttonCrearFactura.Location = new System.Drawing.Point(221, 627);
            this.buttonCrearFactura.Name = "buttonCrearFactura";
            this.buttonCrearFactura.Size = new System.Drawing.Size(91, 23);
            this.buttonCrearFactura.TabIndex = 132;
            this.buttonCrearFactura.Text = "Aceptar";
            this.buttonCrearFactura.UseVisualStyleBackColor = true;
            this.buttonCrearFactura.Click += new System.EventHandler(this.buttonAceptar_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(382, 627);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 133;
            this.buttonLimpiar.Text = "Limpiar\r\n";
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
            this.textBoxFechaAlta.ReadOnly = true;
            this.textBoxFechaAlta.Size = new System.Drawing.Size(114, 20);
            this.textBoxFechaAlta.TabIndex = 135;
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(53, 389);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(34, 13);
            this.labelTotal.TabIndex = 136;
            this.labelTotal.Text = "Total:";
            this.labelTotal.Click += new System.EventHandler(this.labelTotal_Click);
            // 
            // labelItemMonto
            // 
            this.labelItemMonto.AutoSize = true;
            this.labelItemMonto.Location = new System.Drawing.Point(57, 485);
            this.labelItemMonto.Name = "labelItemMonto";
            this.labelItemMonto.Size = new System.Drawing.Size(63, 13);
            this.labelItemMonto.TabIndex = 138;
            this.labelItemMonto.Text = "Item Monto:";
            this.labelItemMonto.Click += new System.EventHandler(this.labelItemMonto_Click);
            // 
            // labelItemCantidad
            // 
            this.labelItemCantidad.AutoSize = true;
            this.labelItemCantidad.Location = new System.Drawing.Point(57, 529);
            this.labelItemCantidad.Name = "labelItemCantidad";
            this.labelItemCantidad.Size = new System.Drawing.Size(75, 13);
            this.labelItemCantidad.TabIndex = 139;
            this.labelItemCantidad.Text = "Item Cantidad:";
            this.labelItemCantidad.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBoxItemMonto
            // 
            this.textBoxItemMonto.Location = new System.Drawing.Point(180, 485);
            this.textBoxItemMonto.MaxLength = 16;
            this.textBoxItemMonto.Name = "textBoxItemMonto";
            this.textBoxItemMonto.Size = new System.Drawing.Size(114, 20);
            this.textBoxItemMonto.TabIndex = 140;
            // 
            // textBoxItemCantidad
            // 
            this.textBoxItemCantidad.Location = new System.Drawing.Point(180, 522);
            this.textBoxItemCantidad.MaxLength = 16;
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
            // buttonAgregarItem
            // 
            this.buttonAgregarItem.Location = new System.Drawing.Point(60, 578);
            this.buttonAgregarItem.Name = "buttonAgregarItem";
            this.buttonAgregarItem.Size = new System.Drawing.Size(85, 23);
            this.buttonAgregarItem.TabIndex = 143;
            this.buttonAgregarItem.Text = "Agregar Item";
            this.buttonAgregarItem.UseVisualStyleBackColor = true;
            this.buttonAgregarItem.Click += new System.EventHandler(this.buttonAgregarItem_Click);
            // 
            // labelItemsAAgregar
            // 
            this.labelItemsAAgregar.AutoSize = true;
            this.labelItemsAAgregar.Location = new System.Drawing.Point(351, 299);
            this.labelItemsAAgregar.Name = "labelItemsAAgregar";
            this.labelItemsAAgregar.Size = new System.Drawing.Size(89, 13);
            this.labelItemsAAgregar.TabIndex = 144;
            this.labelItemsAAgregar.Text = "Items Agregados:";
            // 
            // listBoxItems
            // 
            this.listBoxItems.FormattingEnabled = true;
            this.listBoxItems.Location = new System.Drawing.Point(354, 334);
            this.listBoxItems.Name = "listBoxItems";
            this.listBoxItems.Size = new System.Drawing.Size(228, 186);
            this.listBoxItems.TabIndex = 145;
            // 
            // buttonLimpiarItems
            // 
            this.buttonLimpiarItems.Location = new System.Drawing.Point(197, 578);
            this.buttonLimpiarItems.Name = "buttonLimpiarItems";
            this.buttonLimpiarItems.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiarItems.TabIndex = 147;
            this.buttonLimpiarItems.Text = "Borrar Items";
            this.buttonLimpiarItems.UseVisualStyleBackColor = true;
            this.buttonLimpiarItems.Click += new System.EventHandler(this.buttonLimpiarItems_Click);
            // 
            // labelDatosFactura
            // 
            this.labelDatosFactura.AutoSize = true;
            this.labelDatosFactura.Location = new System.Drawing.Point(54, 131);
            this.labelDatosFactura.Name = "labelDatosFactura";
            this.labelDatosFactura.Size = new System.Drawing.Size(100, 13);
            this.labelDatosFactura.TabIndex = 149;
            this.labelDatosFactura.Text = "Datos de la factura:";
            // 
            // labelDatosItem
            // 
            this.labelDatosItem.AutoSize = true;
            this.labelDatosItem.Location = new System.Drawing.Point(54, 441);
            this.labelDatosItem.Name = "labelDatosItem";
            this.labelDatosItem.Size = new System.Drawing.Size(78, 13);
            this.labelDatosItem.TabIndex = 150;
            this.labelDatosItem.Text = "Datos del Item:";
            // 
            // maskedTextBoxNroFact
            // 
            this.maskedTextBoxNroFact.Location = new System.Drawing.Point(180, 161);
            this.maskedTextBoxNroFact.Mask = "999999999";
            this.maskedTextBoxNroFact.Name = "maskedTextBoxNroFact";
            this.maskedTextBoxNroFact.Size = new System.Drawing.Size(114, 20);
            this.maskedTextBoxNroFact.TabIndex = 151;
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.Location = new System.Drawing.Point(180, 382);
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.ReadOnly = true;
            this.textBoxTotal.Size = new System.Drawing.Size(114, 20);
            this.textBoxTotal.TabIndex = 137;
            // 
            // labelFiltro
            // 
            this.labelFiltro.AutoSize = true;
            this.labelFiltro.Location = new System.Drawing.Point(57, 95);
            this.labelFiltro.Name = "labelFiltro";
            this.labelFiltro.Size = new System.Drawing.Size(54, 13);
            this.labelFiltro.TabIndex = 152;
            this.labelFiltro.Text = "Filtrar Por:";
            // 
            // comboBoxFiltro
            // 
            this.comboBoxFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFiltro.FormattingEnabled = true;
            this.comboBoxFiltro.Location = new System.Drawing.Point(137, 92);
            this.comboBoxFiltro.Name = "comboBoxFiltro";
            this.comboBoxFiltro.Size = new System.Drawing.Size(216, 21);
            this.comboBoxFiltro.TabIndex = 153;
            this.comboBoxFiltro.SelectedIndexChanged += new System.EventHandler(this.comboBoxFiltro_SelectedIndexChanged);
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(400, 92);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscar.TabIndex = 154;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // labelFacturasEncontradas
            // 
            this.labelFacturasEncontradas.AutoSize = true;
            this.labelFacturasEncontradas.Location = new System.Drawing.Point(351, 142);
            this.labelFacturasEncontradas.Name = "labelFacturasEncontradas";
            this.labelFacturasEncontradas.Size = new System.Drawing.Size(114, 13);
            this.labelFacturasEncontradas.TabIndex = 155;
            this.labelFacturasEncontradas.Text = "Facturas Encontradas:";
            // 
            // comboBoxFacturasEncontradas
            // 
            this.comboBoxFacturasEncontradas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFacturasEncontradas.FormattingEnabled = true;
            this.comboBoxFacturasEncontradas.Location = new System.Drawing.Point(354, 177);
            this.comboBoxFacturasEncontradas.Name = "comboBoxFacturasEncontradas";
            this.comboBoxFacturasEncontradas.Size = new System.Drawing.Size(226, 21);
            this.comboBoxFacturasEncontradas.TabIndex = 156;
            this.comboBoxFacturasEncontradas.SelectedIndexChanged += new System.EventHandler(this.comboBoxFacturasEncontradas_SelectedIndexChanged);
            // 
            // AbmFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 662);
            this.Controls.Add(this.comboBoxFacturasEncontradas);
            this.Controls.Add(this.labelFacturasEncontradas);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.comboBoxFiltro);
            this.Controls.Add(this.labelFiltro);
            this.Controls.Add(this.maskedTextBoxNroFact);
            this.Controls.Add(this.labelDatosItem);
            this.Controls.Add(this.labelDatosFactura);
            this.Controls.Add(this.buttonLimpiarItems);
            this.Controls.Add(this.listBoxItems);
            this.Controls.Add(this.labelItemsAAgregar);
            this.Controls.Add(this.buttonAgregarItem);
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
            this.Controls.Add(this.buttonCrearFactura);
            this.Controls.Add(this.labelFechaDeVenc);
            this.Controls.Add(this.comboBoxCliente);
            this.Controls.Add(this.labelCliente);
            this.Controls.Add(this.comboBoxEmpresa);
            this.Controls.Add(this.labelEmpresa);
            this.Controls.Add(this.labelNroFac);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuABMCli);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.Label labelEmpresa;
        private System.Windows.Forms.ComboBox comboBoxEmpresa;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.ComboBox comboBoxCliente;
        private System.Windows.Forms.Label labelFechaDeVenc;
        private System.Windows.Forms.Button buttonCrearFactura;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Label labelFechaAlta;
        private System.Windows.Forms.TextBox textBoxFechaAlta;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelItemMonto;
        private System.Windows.Forms.Label labelItemCantidad;
        private System.Windows.Forms.TextBox textBoxItemMonto;
        private System.Windows.Forms.TextBox textBoxItemCantidad;
        private System.Windows.Forms.DateTimePicker dtFechaVen;
        private System.Windows.Forms.Button buttonAgregarItem;
        private System.Windows.Forms.Label labelItemsAAgregar;
        private System.Windows.Forms.ListBox listBoxItems;
        private System.Windows.Forms.Button buttonLimpiarItems;
        private System.Windows.Forms.Label labelDatosFactura;
        private System.Windows.Forms.Label labelDatosItem;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxNroFact;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.Label labelFiltro;
        private System.Windows.Forms.ComboBox comboBoxFiltro;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Label labelFacturasEncontradas;
        private System.Windows.Forms.ComboBox comboBoxFacturasEncontradas;
    }
}