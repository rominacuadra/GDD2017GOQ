namespace PagoAgilFrba.ListadoEstadistico
{
    partial class ListadoEstadistico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListadoEstadistico));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelingresaranio = new System.Windows.Forms.Label();
            this.textAño = new System.Windows.Forms.TextBox();
            this.labeltrimestre = new System.Windows.Forms.Label();
            this.listadotrimestre = new System.Windows.Forms.ComboBox();
            this.labellistado = new System.Windows.Forms.Label();
            this.listadoMostrar = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(101, 158);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(510, 293);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // labelingresaranio
            // 
            this.labelingresaranio.AutoSize = true;
            this.labelingresaranio.Location = new System.Drawing.Point(46, 66);
            this.labelingresaranio.Name = "labelingresaranio";
            this.labelingresaranio.Size = new System.Drawing.Size(124, 13);
            this.labelingresaranio.TabIndex = 1;
            this.labelingresaranio.Text = "Ingresar año a consultar:";
            this.labelingresaranio.Click += new System.EventHandler(this.label1_Click);
            // 
            // textAño
            // 
            this.textAño.Location = new System.Drawing.Point(176, 63);
            this.textAño.MaxLength = 4;
            this.textAño.Name = "textAño";
            this.textAño.Size = new System.Drawing.Size(62, 20);
            this.textAño.TabIndex = 2;
            this.textAño.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // labeltrimestre
            // 
            this.labeltrimestre.AutoSize = true;
            this.labeltrimestre.Location = new System.Drawing.Point(376, 66);
            this.labeltrimestre.Name = "labeltrimestre";
            this.labeltrimestre.Size = new System.Drawing.Size(108, 13);
            this.labeltrimestre.TabIndex = 3;
            this.labeltrimestre.Text = "Seleccionar trimestre:";
            // 
            // listadotrimestre
            // 
            this.listadotrimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listadotrimestre.FormattingEnabled = true;
            this.listadotrimestre.Location = new System.Drawing.Point(490, 63);
            this.listadotrimestre.Name = "listadotrimestre";
            this.listadotrimestre.Size = new System.Drawing.Size(171, 21);
            this.listadotrimestre.TabIndex = 4;
            this.listadotrimestre.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labellistado
            // 
            this.labellistado.AutoSize = true;
            this.labellistado.Location = new System.Drawing.Point(116, 106);
            this.labellistado.Name = "labellistado";
            this.labellistado.Size = new System.Drawing.Size(189, 13);
            this.labellistado.TabIndex = 5;
            this.labellistado.Text = "Seleccionar tipo de listado a visualizar:";
            // 
            // listadoMostrar
            // 
            this.listadoMostrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listadoMostrar.FormattingEnabled = true;
            this.listadoMostrar.Location = new System.Drawing.Point(311, 103);
            this.listadoMostrar.Name = "listadoMostrar";
            this.listadoMostrar.Size = new System.Drawing.Size(300, 21);
            this.listadoMostrar.TabIndex = 6;
            this.listadoMostrar.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 41);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listados Estadísticos";
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 485);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listadoMostrar);
            this.Controls.Add(this.labellistado);
            this.Controls.Add(this.listadotrimestre);
            this.Controls.Add(this.labeltrimestre);
            this.Controls.Add(this.textAño);
            this.Controls.Add(this.labelingresaranio);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListadoEstadistico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listado Estadistico";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelingresaranio;
        private System.Windows.Forms.TextBox textAño;
        private System.Windows.Forms.Label labeltrimestre;
        private System.Windows.Forms.ComboBox listadotrimestre;
        private System.Windows.Forms.Label labellistado;
        private System.Windows.Forms.ComboBox listadoMostrar;
        private System.Windows.Forms.GroupBox groupBox1;
       
    }
}