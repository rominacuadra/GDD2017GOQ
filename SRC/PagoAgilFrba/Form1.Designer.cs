namespace PagoAgilFrba
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cbRol = new System.Windows.Forms.ComboBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblClave = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbSuc = new System.Windows.Forms.ComboBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblSuc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbRol
            // 
            this.cbRol.Enabled = false;
            this.cbRol.FormattingEnabled = true;
            this.cbRol.Location = new System.Drawing.Point(99, 177);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(135, 21);
            this.cbRol.TabIndex = 35;
            this.cbRol.Visible = false;
            this.cbRol.SelectedIndexChanged += new System.EventHandler(this.cbRol_SelectedIndexChanged);
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(41, 235);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(106, 26);
            this.btnIngresar.TabIndex = 32;
            this.btnIngresar.Text = "ACEPTAR";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(177, 235);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 26);
            this.btnCancelar.TabIndex = 33;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(91, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 36);
            this.label3.TabIndex = 28;
            this.label3.Text = "PagoAgil";
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.BackColor = System.Drawing.Color.Transparent;
            this.lblClave.Font = new System.Drawing.Font("Arial", 12F);
            this.lblClave.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblClave.Location = new System.Drawing.Point(35, 144);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(48, 18);
            this.lblClave.TabIndex = 29;
            this.lblClave.Text = "Clave";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8F);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(83, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 14);
            this.label4.TabIndex = 30;
            this.label4.Text = "Ingresando al sistema bobby";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Arial", 12F);
            this.lblUsuario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblUsuario.Location = new System.Drawing.Point(26, 112);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(62, 18);
            this.lblUsuario.TabIndex = 31;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(99, 145);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(135, 20);
            this.txtClave.TabIndex = 27;
            // 
            // txtUsuario
            // 
            this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsuario.Location = new System.Drawing.Point(99, 113);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(135, 20);
            this.txtUsuario.TabIndex = 26;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(240, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 139);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // cbSuc
            // 
            this.cbSuc.Enabled = false;
            this.cbSuc.FormattingEnabled = true;
            this.cbSuc.Location = new System.Drawing.Point(99, 204);
            this.cbSuc.Name = "cbSuc";
            this.cbSuc.Size = new System.Drawing.Size(135, 21);
            this.cbSuc.TabIndex = 36;
            this.cbSuc.Visible = false;
            this.cbSuc.SelectedIndexChanged += new System.EventHandler(this.cbSuc_SelectedIndexChanged);
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.BackColor = System.Drawing.Color.Transparent;
            this.lblRol.Enabled = false;
            this.lblRol.Font = new System.Drawing.Font("Arial", 12F);
            this.lblRol.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRol.Location = new System.Drawing.Point(43, 177);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(31, 18);
            this.lblRol.TabIndex = 37;
            this.lblRol.Text = "Rol";
            // 
            // lblSuc
            // 
            this.lblSuc.AutoSize = true;
            this.lblSuc.BackColor = System.Drawing.Color.Transparent;
            this.lblSuc.Enabled = false;
            this.lblSuc.Font = new System.Drawing.Font("Arial", 12F);
            this.lblSuc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSuc.Location = new System.Drawing.Point(26, 207);
            this.lblSuc.Name = "lblSuc";
            this.lblSuc.Size = new System.Drawing.Size(68, 18);
            this.lblSuc.TabIndex = 38;
            this.lblSuc.Text = "Sucursal";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 300);
            this.Controls.Add(this.lblSuc);
            this.Controls.Add(this.lblRol);
            this.Controls.Add(this.cbSuc);
            this.Controls.Add(this.cbRol);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso al Sistema";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbRol;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbSuc;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Label lblSuc;
    }
}