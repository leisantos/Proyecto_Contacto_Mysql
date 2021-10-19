using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProyectoAsignadoEnClase_mysql_usbserver
{
    class Contacto
    {
        public int idContacto { get; set; }
        public string nombreContacto { get; set; }
        public string apellidoContacto { get; set; }
        public string telefonoContacto { get; set; }
        public string direccionContacto { get; set; }


        private CRUD crud = new CRUD();


        public MySqlDataReader ContactosRegistrados()
        {
            string query = "SELECT idContacto, nombreContacto, apellidoContacto, telefonoContacto, direccionContacto FROM contacto";


            return crud.select(query);
        }

        public bool FuncionMultipleAcciones(string action)
        {
            if (action == "new")
            {
                string query = "INSERT INTO contacto(idContacto, nombreContacto, apellidoContacto, telefonoContacto,direccionContacto)" +
                    "VALUES ('" + idContacto + "', '" + nombreContacto + "','" + apellidoContacto + "','" + telefonoContacto + "','" + direccionContacto + "')";

                crud.executeQuery(query);
                return true;
            }
            else if (action == "edit")
            {

                string query = "UPDATE contacto SET "
                    + "idContacto='" + idContacto + "',"
                    + "nombreContacto='" + nombreContacto + "',"
                    + "apellidoContacto='" + apellidoContacto + "',"
                    + "telefonoContacto='" + telefonoContacto + "',"
                    + "direccionContacto='" + direccionContacto + "'"
                    + "WHERE "
                    + "idContacto='" + idContacto + "'";

                crud.executeQuery(query);
                return true;
            }
            return false;
        }


        public Boolean Eliminar()
        {
            string query = "DELETE FROM contacto WHERE idContacto='" + idContacto + "'";
            crud.executeQuery(query);
            return true;
        }
    }
}
