namespace PagoAgilFrba.Devolucion
{
    partial class Devolucion
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
            this.comboFacturas = new System.Windows.Forms.ComboBox();
            this.TextFacturas = new System.Windows.Forms.Label();
            this.TextIngreso = new System.Windows.Forms.Label();
            this.boxIngreso = new System.Windows.Forms.TextBox();
            this.radioButtonError = new System.Windows.Forms.RadioButton();
            this.radioButtonCliente = new System.Windows.Forms.RadioButton();
            this.TextMotivo = new System.Windows.Forms.Label();
            this.listBoxFacturas = new System.Windows.Forms.ListBox();
            this.quitar = new System.Windows.Forms.Button();
            this.devolver = new System.Windows.Forms.Button();
            this.agregar = new System.Windows.Forms.Button();
            this.textLista = new System.Windows.Forms.Label();
            this.botonFactura = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.botonIngrese = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.botonBuscar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboFacturas
            // 
            this.comboFacturas.FormattingEnabled = true;
            this.comboFacturas.Location = new System.Drawing.Point(32, 23);
            this.comboFacturas.Name = "comboFacturas";
            this.comboFacturas.Size = new System.Drawing.Size(69, 21);
            this.comboFacturas.TabIndex = 0;
            this.comboFacturas.SelectedIndexChanged += new System.EventHandler(this.comboFacturas_SelectedIndexChanged);
            // 
            // TextFacturas
            // 
            this.TextFacturas.AutoSize = true;
            this.TextFacturas.Location = new System.Drawing.Point(39, 21);
            this.TextFacturas.Name = "TextFacturas";
            this.TextFacturas.Size = new System.Drawing.Size(163, 13);
            this.TextFacturas.TabIndex = 1;
            this.TextFacturas.Text = "Seleccione la factura a devolver:";
            this.TextFacturas.Click += new System.EventHandler(this.label1_Click);
            // 
            // TextIngreso
            // 
            this.TextIngreso.AutoSize = true;
            this.TextIngreso.Location = new System.Drawing.Point(132, 51);
            this.TextIngreso.Name = "TextIngreso";
            this.TextIngreso.Size = new System.Drawing.Size(71, 13);
            this.TextIngreso.TabIndex = 3;
            this.TextIngreso.Text = "o Ingrese Nro";
            // 
            // boxIngreso
            // 
            this.boxIngreso.Location = new System.Drawing.Point(32, 53);
            this.boxIngreso.Name = "boxIngreso";
            this.boxIngreso.Size = new System.Drawing.Size(69, 20);
            this.boxIngreso.TabIndex = 4;
            // 
            // radioButtonError
            // 
            this.radioButtonError.AutoSize = true;
            this.radioButtonError.Location = new System.Drawing.Point(6, 19);
            this.radioButtonError.Name = "radioButtonError";
            this.radioButtonError.Size = new System.Drawing.Size(92, 17);
            this.radioButtonError.TabIndex = 5;
            this.radioButtonError.TabStop = true;
            this.radioButtonError.Text = "Error de cobro";
            this.radioButtonError.UseVisualStyleBackColor = true;
            // 
            // radioButtonCliente
            // 
            this.radioButtonCliente.AutoSize = true;
            this.radioButtonCliente.Location = new System.Drawing.Point(6, 55);
            this.radioButtonCliente.Name = "radioButtonCliente";
            this.radioButtonCliente.Size = new System.Drawing.Size(117, 17);
            this.radioButtonCliente.TabIndex = 6;
            this.radioButtonCliente.TabStop = true;
            this.radioButtonCliente.Text = "Decision del cliente";
            this.radioButtonCliente.UseVisualStyleBackColor = true;
            // 
            // TextMotivo
            // 
            this.TextMotivo.AutoSize = true;
            this.TextMotivo.Location = new System.Drawing.Point(39, 108);
            this.TextMotivo.Name = "TextMotivo";
            this.TextMotivo.Size = new System.Drawing.Size(164, 13);
            this.TextMotivo.TabIndex = 7;
            this.TextMotivo.Text = "Seleccione motivo de devolucion";
            // 
            // listBoxFacturas
            // 
            this.listBoxFacturas.FormattingEnabled = true;
            this.listBoxFacturas.Location = new System.Drawing.Point(360, 38);
            this.listBoxFacturas.Name = "listBoxFacturas";
            this.listBoxFacturas.Size = new System.Drawing.Size(162, 173);
            this.listBoxFacturas.TabIndex = 8;
            // 
            // quitar
            // 
            this.quitar.Location = new System.Drawing.Point(360, 225);
            this.quitar.Name = "quitar";
            this.quitar.Size = new System.Drawing.Size(75, 23);
            this.quitar.TabIndex = 9;
            this.quitar.Text = "Quitar";
            this.quitar.UseVisualStyleBackColor = true;
            // 
            // devolver
            // 
            this.devolver.Location = new System.Drawing.Point(447, 225);
            this.devolver.Name = "devolver";
            this.devolver.Size = new System.Drawing.Size(75, 23);
            this.devolver.TabIndex = 10;
            this.devolver.Text = "Devolver";
            this.devolver.UseVisualStyleBackColor = true;
            // 
            // agregar
            // 
            this.agregar.Location = new System.Drawing.Point(91, 225);
            this.agregar.Name = "agregar";
            this.agregar.Size = new System.Drawing.Size(100, 23);
            this.agregar.TabIndex = 11;
            this.agregar.Text = "AgregarFactura";
            this.agregar.UseVisualStyleBackColor = true;
            this.agregar.Click += new System.EventHandler(this.button3_Click);
            // 
            // textLista
            // 
            this.textLista.AutoSize = true;
            this.textLista.Location = new System.Drawing.Point(357, 17);
            this.textLista.Name = "textLista";
            this.textLista.Size = new System.Drawing.Size(107, 13);
            this.textLista.TabIndex = 12;
            this.textLista.Text = "Facturas a devolver: ";
            // 
            // botonFactura
            // 
            this.botonFactura.AutoSize = true;
            this.botonFactura.Location = new System.Drawing.Point(6, 26);
            this.botonFactura.Name = "botonFactura";
            this.botonFactura.Size = new System.Drawing.Size(14, 13);
            this.botonFactura.TabIndex = 13;
            this.botonFactura.TabStop = true;
            this.botonFactura.UseVisualStyleBackColor = true;
            this.botonFactura.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.botonIngrese);
            this.groupBox1.Controls.Add(this.botonFactura);
            this.groupBox1.Controls.Add(this.comboFacturas);
            this.groupBox1.Controls.Add(this.boxIngreso);
            this.groupBox1.Location = new System.Drawing.Point(209, -5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 86);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // botonIngrese
            // 
            this.botonIngrese.AutoSize = true;
            this.botonIngrese.Location = new System.Drawing.Point(6, 58);
            this.botonIngrese.Name = "botonIngrese";
            this.botonIngrese.Size = new System.Drawing.Size(14, 13);
            this.botonIngrese.TabIndex = 14;
            this.botonIngrese.TabStop = true;
            this.botonIngrese.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonError);
            this.groupBox2.Controls.Add(this.radioButtonCliente);
            this.groupBox2.Location = new System.Drawing.Point(52, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(139, 78);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // botonBuscar
            // 
            this.botonBuscar.Location = new System.Drawing.Point(235, 87);
            this.botonBuscar.Name = "botonBuscar";
            this.botonBuscar.Size = new System.Drawing.Size(75, 23);
            this.botonBuscar.TabIndex = 16;
            this.botonBuscar.Text = "Buscar";
            this.botonBuscar.UseVisualStyleBackColor = true;
            this.botonBuscar.Click += new System.EventHandler(this.botonBuscar_Click);
            // 
            // Devolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 260);
            this.Controls.Add(this.botonBuscar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textLista);
            this.Controls.Add(this.agregar);
            this.Controls.Add(this.devolver);
            this.Controls.Add(this.quitar);
            this.Controls.Add(this.listBoxFacturas);
            this.Controls.Add(this.TextMotivo);
            this.Controls.Add(this.TextIngreso);
            this.Controls.Add(this.TextFacturas);
            this.Name = "Devolucion";
            this.Text = "Devolucion";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboFacturas;
        private System.Windows.Forms.Label TextFacturas;
        private System.Windows.Forms.Label TextIngreso;
        private System.Windows.Forms.TextBox boxIngreso;
        private System.Windows.Forms.RadioButton radioButtonError;
        private System.Windows.Forms.RadioButton radioButtonCliente;
        private System.Windows.Forms.Label TextMotivo;
        private System.Windows.Forms.ListBox listBoxFacturas;
        private System.Windows.Forms.Button quitar;
        private System.Windows.Forms.Button devolver;
        private System.Windows.Forms.Button agregar;
        private System.Windows.Forms.Label textLista;
        private System.Windows.Forms.RadioButton botonFactura;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton botonIngrese;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button botonBuscar;
    }
}