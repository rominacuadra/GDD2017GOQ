namespace PagoAgilFrba.RegistroPago
{
    partial class RegistroPago
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
            this.labelTitulo = new System.Windows.Forms.Label();
            this.comboBoxFiltro = new System.Windows.Forms.ComboBox();
            this.labelFiltro = new System.Windows.Forms.Label();
            this.labelFechaCobro = new System.Windows.Forms.Label();
            this.labelEmp = new System.Windows.Forms.Label();
            this.labelCli = new System.Windows.Forms.Label();
            this.labelFechaVenc = new System.Windows.Forms.Label();
            this.labelImporte = new System.Windows.Forms.Label();
            this.labelSuc = new System.Windows.Forms.Label();
            this.buttonFact = new System.Windows.Forms.Button();
            this.listBoxFacturas = new System.Windows.Forms.ListBox();
            this.labelFactAPagar = new System.Windows.Forms.Label();
            this.buttonPagar = new System.Windows.Forms.Button();
            this.buttonQuitar = new System.Windows.Forms.Button();
            this.labelTotAPagar = new System.Windows.Forms.Label();
            this.labelNroFac = new System.Windows.Forms.Label();
            this.textBoxNroFact = new System.Windows.Forms.TextBox();
            this.comboBoxEmp = new System.Windows.Forms.ComboBox();
            this.comboBoxCli = new System.Windows.Forms.ComboBox();
            this.labelRNroFac = new System.Windows.Forms.Label();
            this.labelRFechaCob = new System.Windows.Forms.Label();
            this.labelREmp = new System.Windows.Forms.Label();
            this.labelRCli = new System.Windows.Forms.Label();
            this.labelRFechaVenc = new System.Windows.Forms.Label();
            this.labelRImp = new System.Windows.Forms.Label();
            this.labelRSuc = new System.Windows.Forms.Label();
            this.labelRTot = new System.Windows.Forms.Label();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.labelTipoPago = new System.Windows.Forms.Label();
            this.comboBoxTipoPago = new System.Windows.Forms.ComboBox();
            this.labelFacEnc = new System.Windows.Forms.Label();
            this.comboBoxFacEnc = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Location = new System.Drawing.Point(13, 13);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(66, 13);
            this.labelTitulo.TabIndex = 0;
            this.labelTitulo.Text = "COBRANZA";
            this.labelTitulo.Click += new System.EventHandler(this.labelTitulo_Click);
            // 
            // comboBoxFiltro
            // 
            this.comboBoxFiltro.FormattingEnabled = true;
            this.comboBoxFiltro.Location = new System.Drawing.Point(89, 39);
            this.comboBoxFiltro.Name = "comboBoxFiltro";
            this.comboBoxFiltro.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFiltro.TabIndex = 1;
            this.comboBoxFiltro.SelectedIndexChanged += new System.EventHandler(this.comboBoxFiltro_SelectedIndexChanged);
            // 
            // labelFiltro
            // 
            this.labelFiltro.AutoSize = true;
            this.labelFiltro.Location = new System.Drawing.Point(12, 42);
            this.labelFiltro.Name = "labelFiltro";
            this.labelFiltro.Size = new System.Drawing.Size(62, 13);
            this.labelFiltro.TabIndex = 2;
            this.labelFiltro.Text = "Buscar Por:";
            // 
            // labelFechaCobro
            // 
            this.labelFechaCobro.AutoSize = true;
            this.labelFechaCobro.Location = new System.Drawing.Point(13, 146);
            this.labelFechaCobro.Name = "labelFechaCobro";
            this.labelFechaCobro.Size = new System.Drawing.Size(86, 13);
            this.labelFechaCobro.TabIndex = 3;
            this.labelFechaCobro.Text = "Fecha de Cobro:";
            // 
            // labelEmp
            // 
            this.labelEmp.AutoSize = true;
            this.labelEmp.Location = new System.Drawing.Point(12, 180);
            this.labelEmp.Name = "labelEmp";
            this.labelEmp.Size = new System.Drawing.Size(51, 13);
            this.labelEmp.TabIndex = 4;
            this.labelEmp.Text = "Empresa:";
            // 
            // labelCli
            // 
            this.labelCli.AutoSize = true;
            this.labelCli.Location = new System.Drawing.Point(12, 213);
            this.labelCli.Name = "labelCli";
            this.labelCli.Size = new System.Drawing.Size(42, 13);
            this.labelCli.TabIndex = 5;
            this.labelCli.Text = "Cliente:";
            // 
            // labelFechaVenc
            // 
            this.labelFechaVenc.AutoSize = true;
            this.labelFechaVenc.Location = new System.Drawing.Point(13, 248);
            this.labelFechaVenc.Name = "labelFechaVenc";
            this.labelFechaVenc.Size = new System.Drawing.Size(116, 13);
            this.labelFechaVenc.TabIndex = 6;
            this.labelFechaVenc.Text = "Fecha de Vencimiento:";
            // 
            // labelImporte
            // 
            this.labelImporte.AutoSize = true;
            this.labelImporte.Location = new System.Drawing.Point(15, 283);
            this.labelImporte.Name = "labelImporte";
            this.labelImporte.Size = new System.Drawing.Size(45, 13);
            this.labelImporte.TabIndex = 7;
            this.labelImporte.Text = "Importe:";
            // 
            // labelSuc
            // 
            this.labelSuc.AutoSize = true;
            this.labelSuc.Location = new System.Drawing.Point(12, 321);
            this.labelSuc.Name = "labelSuc";
            this.labelSuc.Size = new System.Drawing.Size(51, 13);
            this.labelSuc.TabIndex = 8;
            this.labelSuc.Text = "Sucursal:";
            // 
            // buttonFact
            // 
            this.buttonFact.Location = new System.Drawing.Point(62, 392);
            this.buttonFact.Name = "buttonFact";
            this.buttonFact.Size = new System.Drawing.Size(75, 23);
            this.buttonFact.TabIndex = 9;
            this.buttonFact.Text = "Agregar";
            this.buttonFact.UseVisualStyleBackColor = true;
            this.buttonFact.Click += new System.EventHandler(this.buttonFact_Click);
            // 
            // listBoxFacturas
            // 
            this.listBoxFacturas.FormattingEnabled = true;
            this.listBoxFacturas.Location = new System.Drawing.Point(477, 113);
            this.listBoxFacturas.Name = "listBoxFacturas";
            this.listBoxFacturas.Size = new System.Drawing.Size(228, 160);
            this.listBoxFacturas.TabIndex = 10;
            this.listBoxFacturas.SelectedIndexChanged += new System.EventHandler(this.listBoxFacturas_SelectedIndexChanged);
            // 
            // labelFactAPagar
            // 
            this.labelFactAPagar.AutoSize = true;
            this.labelFactAPagar.Location = new System.Drawing.Point(474, 85);
            this.labelFactAPagar.Name = "labelFactAPagar";
            this.labelFactAPagar.Size = new System.Drawing.Size(91, 13);
            this.labelFactAPagar.TabIndex = 11;
            this.labelFactAPagar.Text = "Facturas a Pagar:";
            // 
            // buttonPagar
            // 
            this.buttonPagar.Location = new System.Drawing.Point(630, 314);
            this.buttonPagar.Name = "buttonPagar";
            this.buttonPagar.Size = new System.Drawing.Size(75, 23);
            this.buttonPagar.TabIndex = 12;
            this.buttonPagar.Text = "Pagar";
            this.buttonPagar.UseVisualStyleBackColor = true;
            this.buttonPagar.Click += new System.EventHandler(this.buttonPagar_Click);
            // 
            // buttonQuitar
            // 
            this.buttonQuitar.Location = new System.Drawing.Point(477, 314);
            this.buttonQuitar.Name = "buttonQuitar";
            this.buttonQuitar.Size = new System.Drawing.Size(75, 23);
            this.buttonQuitar.TabIndex = 13;
            this.buttonQuitar.Text = "Quitar";
            this.buttonQuitar.UseVisualStyleBackColor = true;
            this.buttonQuitar.Click += new System.EventHandler(this.buttonQuitar_Click);
            // 
            // labelTotAPagar
            // 
            this.labelTotAPagar.AutoSize = true;
            this.labelTotAPagar.Location = new System.Drawing.Point(474, 286);
            this.labelTotAPagar.Name = "labelTotAPagar";
            this.labelTotAPagar.Size = new System.Drawing.Size(74, 13);
            this.labelTotAPagar.TabIndex = 14;
            this.labelTotAPagar.Text = "Total a Pagar:";
            // 
            // labelNroFac
            // 
            this.labelNroFac.AutoSize = true;
            this.labelNroFac.Location = new System.Drawing.Point(13, 110);
            this.labelNroFac.Name = "labelNroFac";
            this.labelNroFac.Size = new System.Drawing.Size(101, 13);
            this.labelNroFac.TabIndex = 15;
            this.labelNroFac.Text = "Número de Factura:";
            // 
            // textBoxNroFact
            // 
            this.textBoxNroFact.Location = new System.Drawing.Point(289, 113);
            this.textBoxNroFact.Name = "textBoxNroFact";
            this.textBoxNroFact.Size = new System.Drawing.Size(100, 20);
            this.textBoxNroFact.TabIndex = 16;
            // 
            // comboBoxEmp
            // 
            this.comboBoxEmp.FormattingEnabled = true;
            this.comboBoxEmp.Location = new System.Drawing.Point(289, 180);
            this.comboBoxEmp.Name = "comboBoxEmp";
            this.comboBoxEmp.Size = new System.Drawing.Size(182, 21);
            this.comboBoxEmp.TabIndex = 17;
            // 
            // comboBoxCli
            // 
            this.comboBoxCli.FormattingEnabled = true;
            this.comboBoxCli.Location = new System.Drawing.Point(289, 216);
            this.comboBoxCli.Name = "comboBoxCli";
            this.comboBoxCli.Size = new System.Drawing.Size(182, 21);
            this.comboBoxCli.TabIndex = 18;
            // 
            // labelRNroFac
            // 
            this.labelRNroFac.AutoSize = true;
            this.labelRNroFac.Location = new System.Drawing.Point(134, 113);
            this.labelRNroFac.Name = "labelRNroFac";
            this.labelRNroFac.Size = new System.Drawing.Size(10, 13);
            this.labelRNroFac.TabIndex = 19;
            this.labelRNroFac.Text = "-";
            // 
            // labelRFechaCob
            // 
            this.labelRFechaCob.AutoSize = true;
            this.labelRFechaCob.Location = new System.Drawing.Point(134, 149);
            this.labelRFechaCob.Name = "labelRFechaCob";
            this.labelRFechaCob.Size = new System.Drawing.Size(10, 13);
            this.labelRFechaCob.TabIndex = 20;
            this.labelRFechaCob.Text = "-";
            // 
            // labelREmp
            // 
            this.labelREmp.AutoSize = true;
            this.labelREmp.Location = new System.Drawing.Point(134, 183);
            this.labelREmp.Name = "labelREmp";
            this.labelREmp.Size = new System.Drawing.Size(10, 13);
            this.labelREmp.TabIndex = 21;
            this.labelREmp.Text = "-";
            // 
            // labelRCli
            // 
            this.labelRCli.AutoSize = true;
            this.labelRCli.Location = new System.Drawing.Point(134, 216);
            this.labelRCli.Name = "labelRCli";
            this.labelRCli.Size = new System.Drawing.Size(10, 13);
            this.labelRCli.TabIndex = 22;
            this.labelRCli.Text = "-";
            // 
            // labelRFechaVenc
            // 
            this.labelRFechaVenc.AutoSize = true;
            this.labelRFechaVenc.Location = new System.Drawing.Point(134, 248);
            this.labelRFechaVenc.Name = "labelRFechaVenc";
            this.labelRFechaVenc.Size = new System.Drawing.Size(10, 13);
            this.labelRFechaVenc.TabIndex = 23;
            this.labelRFechaVenc.Text = "-";
            // 
            // labelRImp
            // 
            this.labelRImp.AutoSize = true;
            this.labelRImp.Location = new System.Drawing.Point(134, 283);
            this.labelRImp.Name = "labelRImp";
            this.labelRImp.Size = new System.Drawing.Size(10, 13);
            this.labelRImp.TabIndex = 24;
            this.labelRImp.Text = "-";
            // 
            // labelRSuc
            // 
            this.labelRSuc.AutoSize = true;
            this.labelRSuc.Location = new System.Drawing.Point(134, 321);
            this.labelRSuc.Name = "labelRSuc";
            this.labelRSuc.Size = new System.Drawing.Size(10, 13);
            this.labelRSuc.TabIndex = 25;
            this.labelRSuc.Text = "-";
            // 
            // labelRTot
            // 
            this.labelRTot.AutoSize = true;
            this.labelRTot.Location = new System.Drawing.Point(554, 286);
            this.labelRTot.Name = "labelRTot";
            this.labelRTot.Size = new System.Drawing.Size(10, 13);
            this.labelRTot.TabIndex = 26;
            this.labelRTot.Text = "-";
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(164, 392);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscar.TabIndex = 27;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // labelTipoPago
            // 
            this.labelTipoPago.AutoSize = true;
            this.labelTipoPago.Location = new System.Drawing.Point(12, 355);
            this.labelTipoPago.Name = "labelTipoPago";
            this.labelTipoPago.Size = new System.Drawing.Size(82, 13);
            this.labelTipoPago.TabIndex = 28;
            this.labelTipoPago.Text = "Medio de Pago:";
            // 
            // comboBoxTipoPago
            // 
            this.comboBoxTipoPago.FormattingEnabled = true;
            this.comboBoxTipoPago.Location = new System.Drawing.Point(137, 352);
            this.comboBoxTipoPago.Name = "comboBoxTipoPago";
            this.comboBoxTipoPago.Size = new System.Drawing.Size(160, 21);
            this.comboBoxTipoPago.TabIndex = 29;
            // 
            // labelFacEnc
            // 
            this.labelFacEnc.AutoSize = true;
            this.labelFacEnc.Location = new System.Drawing.Point(12, 77);
            this.labelFacEnc.Name = "labelFacEnc";
            this.labelFacEnc.Size = new System.Drawing.Size(114, 13);
            this.labelFacEnc.TabIndex = 33;
            this.labelFacEnc.Text = "Facturas Encontradas:";
            // 
            // comboBoxFacEnc
            // 
            this.comboBoxFacEnc.FormattingEnabled = true;
            this.comboBoxFacEnc.Location = new System.Drawing.Point(132, 74);
            this.comboBoxFacEnc.Name = "comboBoxFacEnc";
            this.comboBoxFacEnc.Size = new System.Drawing.Size(336, 21);
            this.comboBoxFacEnc.TabIndex = 32;
            this.comboBoxFacEnc.SelectedIndexChanged += new System.EventHandler(this.comboBoxFacEnc_SelectedIndexChanged_1);
            // 
            // RegistroPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 427);
            this.Controls.Add(this.labelFacEnc);
            this.Controls.Add(this.comboBoxFacEnc);
            this.Controls.Add(this.comboBoxTipoPago);
            this.Controls.Add(this.labelTipoPago);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.labelRTot);
            this.Controls.Add(this.labelRSuc);
            this.Controls.Add(this.labelRImp);
            this.Controls.Add(this.labelRFechaVenc);
            this.Controls.Add(this.labelRCli);
            this.Controls.Add(this.labelREmp);
            this.Controls.Add(this.labelRFechaCob);
            this.Controls.Add(this.labelRNroFac);
            this.Controls.Add(this.comboBoxCli);
            this.Controls.Add(this.comboBoxEmp);
            this.Controls.Add(this.textBoxNroFact);
            this.Controls.Add(this.labelNroFac);
            this.Controls.Add(this.labelTotAPagar);
            this.Controls.Add(this.buttonQuitar);
            this.Controls.Add(this.buttonPagar);
            this.Controls.Add(this.labelFactAPagar);
            this.Controls.Add(this.listBoxFacturas);
            this.Controls.Add(this.buttonFact);
            this.Controls.Add(this.labelSuc);
            this.Controls.Add(this.labelImporte);
            this.Controls.Add(this.labelFechaVenc);
            this.Controls.Add(this.labelCli);
            this.Controls.Add(this.labelEmp);
            this.Controls.Add(this.labelFechaCobro);
            this.Controls.Add(this.labelFiltro);
            this.Controls.Add(this.comboBoxFiltro);
            this.Controls.Add(this.labelTitulo);
            this.Name = "RegistroPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro de Pago";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.ComboBox comboBoxFiltro;
        private System.Windows.Forms.Label labelFiltro;
        private System.Windows.Forms.Label labelFechaCobro;
        private System.Windows.Forms.Label labelEmp;
        private System.Windows.Forms.Label labelCli;
        private System.Windows.Forms.Label labelFechaVenc;
        private System.Windows.Forms.Label labelImporte;
        private System.Windows.Forms.Label labelSuc;
        private System.Windows.Forms.Button buttonFact;
        private System.Windows.Forms.ListBox listBoxFacturas;
        private System.Windows.Forms.Label labelFactAPagar;
        private System.Windows.Forms.Button buttonPagar;
        private System.Windows.Forms.Button buttonQuitar;
        private System.Windows.Forms.Label labelTotAPagar;
        private System.Windows.Forms.Label labelNroFac;
        private System.Windows.Forms.TextBox textBoxNroFact;
        private System.Windows.Forms.ComboBox comboBoxEmp;
        private System.Windows.Forms.ComboBox comboBoxCli;
        private System.Windows.Forms.Label labelRNroFac;
        private System.Windows.Forms.Label labelRFechaCob;
        private System.Windows.Forms.Label labelREmp;
        private System.Windows.Forms.Label labelRCli;
        private System.Windows.Forms.Label labelRFechaVenc;
        private System.Windows.Forms.Label labelRImp;
        private System.Windows.Forms.Label labelRSuc;
        private System.Windows.Forms.Label labelRTot;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Label labelTipoPago;
        private System.Windows.Forms.ComboBox comboBoxTipoPago;
        private System.Windows.Forms.Label labelFacEnc;
        private System.Windows.Forms.ComboBox comboBoxFacEnc;
    }
}