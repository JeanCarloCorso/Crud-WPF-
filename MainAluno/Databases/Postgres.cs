using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;

namespace MainAluno.Databases
{
    internal class Postgres
    {
        static string serverName = "127.0.0.1";      //localhost
        static string port = "5430";                //porta default
        static string userName = "postgres";       //nome do administrador
        static string password = "root";          //senha do administrador
        static string databaseName = "Crud-Luz";    //nome do banco de dados
        NpgsqlConnection pgsqlConnection = null;
        NpgsqlCommand pgsqlCommand = null;
        string connString = null;

        public Postgres()
        {
            connString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                serverName, port, userName, password, databaseName);
            pgsqlConnection = new NpgsqlConnection(connString);
        }

        public NpgsqlCommand Comandos()
        {
            try
            {
                pgsqlCommand = pgsqlConnection.CreateCommand();
                pgsqlCommand.CommandType = CommandType.Text;

                return pgsqlCommand;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public void Close()
        {
            pgsqlConnection.Close();
        }

        public void Open()
        {
            try
            {
                pgsqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Coneção com o banco postgres não realizada, " + ex.Message);
            }
        }

    }
}
