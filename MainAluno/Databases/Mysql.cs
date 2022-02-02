using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using MainAluno.Interfaces;

namespace MainAluno.Databases
{
    internal class Mysql : IConexao
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
             connection = new MySqlConnection($"server={host};database={dbname};port={port};user={username};password={password}");
        }

        public void Close()
        {
            connection.Close();
        }

        public void Open()
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Coneção com o banco MySql não realizada, " + ex);
                throw;
            }
        }

        public IDbCommand Comandos()
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
