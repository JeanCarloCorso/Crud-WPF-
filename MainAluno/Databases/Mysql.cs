using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;

namespace MainAluno.Databases
{
    internal class Mysql
    {
        private static string host = "localhost";
        private static string port = "3307";
        private static string username = "root";
        private static string password = "root";
        private static string dbname = "Crud-Luz";

        private static MySqlConnection connection;
        private static MySqlCommand command;
        public Mysql()
        {
            try
            {
                connection = new MySqlConnection($"server={host};database={dbname};port={port};user={username};password={password}");
                connection.Open();
            }catch (Exception ex)
            {
                MessageBox.Show("Coneção com o banco MySql não realizada, " + ex);
                throw;
            }
        }

        public void Close()
        {
            connection.Close();
        }

        public MySqlCommand Comandos()
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandType = CommandType.Text;

                return command;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
