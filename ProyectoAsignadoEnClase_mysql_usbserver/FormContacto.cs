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
    public partial class FormContacto : Form
    {
        public FormContacto()
        {
            InitializeComponent();

            dgContacto.Columns.Add("contactoId", "ID");
            dgContacto.Columns.Add("nombre", "Nombre");
            dgContacto.Columns.Add("apellido", "Apellido");
            dgContacto.Columns.Add("numeroTelefono", "Telefono");
            dgContacto.Columns.Add("direccion", "Direccion");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
