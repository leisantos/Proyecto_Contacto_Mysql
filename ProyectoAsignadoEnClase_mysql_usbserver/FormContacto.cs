using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProyectoAsignadoEnClase_mysql_usbserver
{
    public partial class FormContacto : Form
    {
        private string action = "";

        public FormContacto()
        {
            InitializeComponent();
        }

        public void extraerBD_DataGridView()
        {
            Contacto contacto = new Contacto();

            vaciarRegistrosDataGridView();

            dgContacto.Columns.Add("contactoId", "ID");
            dgContacto.Columns.Add("nombre", "Nombre");
            dgContacto.Columns.Add("apellido", "Apellido");
            dgContacto.Columns.Add("numeroTelefono", "Telefono");
            dgContacto.Columns.Add("direccion", "Direccion");

            MySqlDataReader dataReader = contacto.ContactosRegistrados();

            while (dataReader.Read())
            {
                dgContacto.Rows.Add(
               dataReader.GetValue(0),
               dataReader.GetValue(1),
               dataReader.GetValue(2),
               dataReader.GetValue(3),
               dataReader.GetValue(4));
            }
        }

        public void vaciarControles()
        {
            txtcontactoId.Text = "";
            txtnombre.Text = "";
            txtapellido.Text = "";
            txtnumeroTelefono.Text = "";
            txtdireccion.Text = "";
        }

        private void vaciarRegistrosDataGridView()
        {
            dgContacto.Columns.Clear();
            dgContacto.Rows.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            txtcontactoId.ReadOnly = true;
            txtcontactoId.Enabled = false;
            txtnombre.Focus();

            dgContacto.Columns.Add("contactoId", "ID");
            dgContacto.Columns.Add("nombre", "Nombre");
            dgContacto.Columns.Add("apellido", "Apellido");
            dgContacto.Columns.Add("numeroTelefono", "Telefono");
            dgContacto.Columns.Add("direccion", "Direccion");

            extraerBD_DataGridView();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            action = "new";
            if (txtnombre.Text == "")
            {

                MetroFramework.MetroMessageBox.Show(this, "Debe ingresa un Nombre, para realizar un registro valido.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtnombre.Focus();
            }
            else if (txtapellido.Text == "")
            {

                MetroFramework.MetroMessageBox.Show(this, "Debe ingresa un Apellido, para realizar un registro valido.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtapellido.Focus();
            }
            else if (txtnumeroTelefono.Text == "")
            {

                MetroFramework.MetroMessageBox.Show(this, "Debe ingresa un Numero de Telefono, para realizar un registro valido.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtnumeroTelefono.Focus();
            }
            else if (txtdireccion.Text == "")
            {

                MetroFramework.MetroMessageBox.Show(this, "Debe ingresa una Dirreccion, para realizar un registro valido.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdireccion.Focus();
            }
            else
            {

                Contacto contacto = new Contacto();

                contacto.nombreContacto = txtnombre.Text;
                contacto.apellidoContacto = txtapellido.Text;
                contacto.telefonoContacto = txtnumeroTelefono.Text;
                contacto.direccionContacto = txtdireccion.Text;

                string aviso = "¿Desea continuar y registrar el contacto?";
                if (MetroFramework.MetroMessageBox.Show(this, aviso, "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Llamar al metodo Guardar
                    if (contacto.FuncionMultipleAcciones(action))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "El contacto se guardo de manera satisfactoria.", "CONFIRMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "El contacto no se guardo de manera correcta, hubo un problema.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    vaciarControles();
                    vaciarRegistrosDataGridView();
                    extraerBD_DataGridView();

                }

            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Contacto contacto = new Contacto();

            action = "edit";

            if (txtnombre.Text == "")
            {

                MetroFramework.MetroMessageBox.Show(this, "Debe ingresa un Nombre, para realizar un registro valido.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtnombre.Focus();
            }
            else if (txtapellido.Text == "")
            {

                MetroFramework.MetroMessageBox.Show(this, "Debe ingresa un Apellido, para realizar un registro valido.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtapellido.Focus();
            }
            else if (txtnumeroTelefono.Text == "")
            {

                MetroFramework.MetroMessageBox.Show(this, "Debe ingresa un Numero de Telefono, para realizar un registro valido.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtnumeroTelefono.Focus();
            }
            else if (txtdireccion.Text == "")
            {

                MetroFramework.MetroMessageBox.Show(this, "Debe ingresa una Dirreccion, para realizar un registro valido.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtdireccion.Focus();
            }
            else
            {
                contacto.idContacto = Convert.ToInt32(txtcontactoId.Text);
                contacto.nombreContacto = txtnombre.Text;
                contacto.apellidoContacto = txtapellido.Text;
                contacto.telefonoContacto = txtnumeroTelefono.Text;
                contacto.direccionContacto = txtdireccion.Text;

                string aviso = "¿Desea continuar y actualizar el contacto?";
                if (MetroFramework.MetroMessageBox.Show(this, aviso, "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Llamar al metodo Guardar
                    if (contacto.FuncionMultipleAcciones(action))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "El contacto se actualizo de manera satisfactoria.", "CONFIRMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "El contacto no se guardo de manera correcta, hubo un problema.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    vaciarControles();
                    vaciarRegistrosDataGridView();
                    extraerBD_DataGridView();

                }

            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            txtcontactoId.Text = dgContacto.CurrentRow.Cells[0].Value.ToString();
            txtnombre.Text = dgContacto.CurrentRow.Cells[1].Value.ToString();
            txtapellido.Text = dgContacto.CurrentRow.Cells[2].Value.ToString();
            txtnumeroTelefono.Text = dgContacto.CurrentRow.Cells[3].Value.ToString();
            txtdireccion.Text = dgContacto.CurrentRow.Cells[4].Value.ToString();

            action = "edit";

            txtnombre.Focus();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            string aviso = "¿Deseas eliminar el contacto seleccionado?";
            if (MetroFramework.MetroMessageBox.Show(this, aviso, "CONFIRMACION", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Contacto contacto = new Contacto();
                contacto.idContacto = (int)dgContacto.CurrentRow.Cells[0].Value;


                if (contacto.Eliminar())
                {
                    MetroFramework.MetroMessageBox.Show(this, "El contacto se ha eliminado correctamente de la libreta", "CONFIRMACION", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    extraerBD_DataGridView();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "El contacto no se ha eliminado correctamente de la libreta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}