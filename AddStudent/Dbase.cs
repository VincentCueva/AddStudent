using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AddStudent
{
    internal class Dbase
    {
        private string server = Properties.Settings.Default.server;
        private string port = Properties.Settings.Default.port;
        private string username = Properties.Settings.Default.username;
        private string password = Properties.Settings.Default.password;
        private string dbase = Properties.Settings.Default.Dbase;

        public MySqlConnection con = new MySqlConnection();

        public void Connect()
        {
            string constring = "server=" + server + "; port=" + port + "; username=" + username + "; password=" + password + "; database=" + dbase + "; charset=utf8";
            con = new MySqlConnection(constring);
            con.Open();
        }

        public void Disconnect()
        {
            con.Close();
            con.Dispose();
        }
    }
}
