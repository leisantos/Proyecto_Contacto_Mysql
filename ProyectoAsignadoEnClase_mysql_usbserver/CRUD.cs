using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ProyectoAsignadoEnClase_mysql_usbserver
{
    class CRUD
    {
        private Connection con = new Connection();

        public MySqlDataReader select(string query)
        {
            MySqlDataReader dataReader;


            con.command = new MySqlCommand(query, con.openConnection());
            dataReader = con.command.ExecuteReader();
            return dataReader;
        }
        public void executeQuery(string query)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            con.command = new MySqlCommand(query, con.openConnection());
            adapter.InsertCommand = con.command;
            adapter.InsertCommand.ExecuteNonQuery();
            con.command.Dispose();
            con.closeConnection();
        }
    }
}
