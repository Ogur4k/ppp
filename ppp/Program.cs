using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ppp
{
    static class Program
    {
        public class Connect
        {
            string strConnect;
            MySqlConnection Conn;
            public MySqlConnection Connection()
            {
                Conn = new MySqlConnection(strConnect);
                return Conn;
            }
            public string RCon()
            {
                return strConnect;
            }
            public Connect(string connect)
            {
                strConnect = connect;
            }
        }
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
