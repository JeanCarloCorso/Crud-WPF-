using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;

namespace MainAluno.Classes
{
    internal class Conexao
    {
        private static string host = "localhost";
        private static string port = "3307";
        private static string username = "root";
        private static string password = "root";
        public static string dbname = "Crud-Luz";

        private static MySqlConnection connection;

        public ObservableCollection<Aluno> Alunos { get; set; }
        public Aluno aluno { get; set; }

        public Conexao()
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
            catch (Exception e)
            {
                MessageBox.Show("Não foi possivel conectar ao banco!");
                throw;
            }
        }

        public ObservableCollection<Aluno> Select()
        {
            Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM Alunos", connection);
            MySqlDataReader dr = cmd.ExecuteReader();

            Alunos = new ObservableCollection<Aluno>();
            
            while (dr.Read())
            {
                aluno = new Aluno();
                aluno.Id = (int)dr[0];
                aluno.Nome = (string)dr[1];
                aluno.Sexo = (string)dr[2];
                aluno.Nascimento = (DateTime)dr[3];
                aluno.Naturalidade = (string)dr[4];
                aluno.Cpf = (string)dr[5];
                aluno.Email = (string)dr[6];

                Alunos.Add(aluno);
            }
            Close();
            return Alunos;
        }

        public bool Insert(Aluno aluno)
        {
            Open();
            using (MySqlCommand command = new MySqlCommand("INSERT INTO Alunos " +
                "(nome, sexo, nascimento, naturalidade, cpf, email) VALUES " +
                "(@nome,@sexo,@nascimento,@naturalidade,@cpf,@email)", connection))
            {
                command.Parameters.AddWithValue("nome", aluno.Nome);
                command.Parameters.AddWithValue("sexo", aluno.Sexo);
                command.Parameters.AddWithValue("nascimento", aluno.Nascimento);
                command.Parameters.AddWithValue("naturalidade", aluno.Naturalidade);
                command.Parameters.AddWithValue("cpf", aluno.Cpf);
                command.Parameters.AddWithValue("email", aluno.Email);

                if (command.ExecuteNonQuery() > 0)
                {
                    Close();
                    return true;
                }
            }
            Close();
            return false;
        }


        public bool Delet(int id)
        {
            Open();
            using (MySqlCommand command = new MySqlCommand("DELETE FROM Alunos WHERE id=@id", connection))
            {
                command.Parameters.AddWithValue("id", id);
                if (command.ExecuteNonQuery() > 0)
                {
                    Close();
                    return true;
                }
            }
            Close();
            return false;
        }

        public bool Update(Aluno aluno)
        {
            Open();
            using (MySqlCommand command = new MySqlCommand("UPDATE Alunos SET " +
                "nome = @nome, " +
                "sexo = @sexo, " +
                "nascimento = @nascimento," +
                "naturalidade = @naturalidade," +
                "cpf = @cpf," +
                "email = @email" +
                "WHERE id = @id; ", connection))
            {
                command.Parameters.AddWithValue("nome", aluno.Nome);
                command.Parameters.AddWithValue("sexo", aluno.Sexo);
                command.Parameters.AddWithValue("nascimento", aluno.Nascimento);
                command.Parameters.AddWithValue("naturalidade", aluno.Naturalidade);
                command.Parameters.AddWithValue("cpf", aluno.Cpf);
                command.Parameters.AddWithValue("email", aluno.Email);
                command.Parameters.AddWithValue("id", aluno.Id);
                if (command.ExecuteNonQuery() > 0)
                {
                    Close();
                    return true;
                }
            }
            Close();
            return false;
        }

    }
}
