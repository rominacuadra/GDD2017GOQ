using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba
{
    public partial class PantallaPrincipal : Form
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        private void cerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void administraciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //PagoAgilFrba.AbmCliente();

            AbmCliente.ABMCliente p = new AbmCliente.ABMCliente();
            p.ShowDialog();
        }

        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {
            if (PagoAgilFrba.ModuloGlobal.usuarioLogueado =="ADMIN")
            {
                rolToolStripMenuItem.Enabled = true;
            }
            else
            {
                rolToolStripMenuItem.Enabled = false;
            }
        }

        private void rolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbmRol.Roles p = new AbmRol.Roles();
            p.ShowDialog();
        }

    }
}
