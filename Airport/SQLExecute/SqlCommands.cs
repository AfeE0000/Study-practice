using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace Airport.SQLExecute
{
    //Проверка
    class SqlCommands
    {
        //Id входа на сервер
        private static string id;
        public static string Id
        { get { return id; }
            set { id = value; }
        }

        //Пароль входа на сервер
        private static string password;
        public static string Password
        {
            get { return password; }
            set { password = value; }
        }

        //ip сервера
        private static string server;
        public static string Server
        {
            set { server = value; }
        }

        //Название базы
        private static string dbName;
        public static string DbName
        {
            set { dbName = value; }
        }

        //Порт
        private static uint port;
        public static uint Port
        {
            set { port = value; }
        }

        //Подключение
        private string Connection()
        {
            MySqlConnectionStringBuilder csb = new MySqlConnectionStringBuilder()
            {
                UserID = id,
                Password = password,
                Server = server,
                Database = dbName,
                Port = port
            };
            return csb.ToString();
        }

        //Выполнение команды
        private DataTable ExecuteCommand(MySqlCommand cmd)
        {
            DataTable dt = new DataTable();
            MySqlConnection conn = new MySqlConnection(Connection());
            try
            {
                conn.Open();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    dt.Load(dr);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при подключении к серверу. \n{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return dt;
        }

        //Команда с 1 параметром
        public DataTable FillCommand(string querry)
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand(querry);
            dt = ExecuteCommand(cmd);
            return dt;
        }

        //Команда с 2 параметрами
        public DataTable FillCommand(string querry, string param1, string param2)
        {
            DataTable dt = new DataTable();
            MySqlCommand cmd = new MySqlCommand(querry);
            cmd.Parameters.AddWithValue("@Param1", param1);
            cmd.Parameters.AddWithValue("@Param2", param2);
            dt = ExecuteCommand(cmd);
            return dt;
        }
    }
}
