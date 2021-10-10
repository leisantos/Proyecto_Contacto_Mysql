using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoAsignadoEnClase_mysql_usbserver
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTestBD formtestBD = new FormTestBD();

            formtestBD.MdiParent = this;

            formtestBD.Show();
        }

        private void nuevoContactoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormContacto formcontacto = new FormContacto();

            formcontacto.Show();
        }
    }
}
