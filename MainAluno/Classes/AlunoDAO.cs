using MainAluno.Databases;
using MainAluno.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAluno.Classes
{
    internal class AlunoDAO : IDAO<Aluno>
    {
        private static Postgres conn;

        public AlunoDAO()
        {
            conn = new Postgres();
        }
        public void Delete(Aluno t)
        {
            try
            {
                conn.Open();
                var Comando = conn.Comandos();
                Comando.CommandText = "DELETE FROM Alunos WHERE id=@id";

                Comando.Parameters.AddWithValue("id", t.Id);
                Comando.ExecuteNonQuery();
                Comando.Dispose();
                conn.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Insert(Aluno t)
        {
            try
            {
                conn.Open();
                var Comando = conn.Comandos();
                Comando.CommandText = "INSERT INTO Alunos (nome, sexo, nascimento, naturalidade, cpf, email) VALUES (@nome,@sexo,@nascimento,@naturalidade,@cpf,@email)";

                Comando.Parameters.AddWithValue("nome", t.Nome);
                Comando.Parameters.AddWithValue("sexo", t.Sexo);
                Comando.Parameters.AddWithValue("nascimento", t.Nascimento);
                Comando.Parameters.AddWithValue("naturalidade", t.Naturalidade);
                Comando.Parameters.AddWithValue("cpf", t.Cpf);
                Comando.Parameters.AddWithValue("email", t.Email);

                Comando.ExecuteNonQuery();
                Comando.Dispose();
                conn.Close();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Aluno> Select()
        {
            try
            {
                conn.Open();
                var Comando = conn.Comandos();
                Comando.CommandText = "SELECT * FROM Alunos";
                var dr = Comando.ExecuteReader();

                List<Aluno> Alunos = new List<Aluno>();
                Aluno aluno;

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
                Comando.Dispose();
                conn.Close();
                return Alunos;

            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Aluno t)
        {
            try
            {
                conn.Open();
                var Comando = conn.Comandos();
                Comando.CommandText = "UPDATE Alunos SET " +
                    "nome = @nome, " +
                    "sexo = @sexo, " +
                    "nascimento = @nascimento, " +
                    "naturalidade = @naturalidade, " +
                    "cpf = @cpf, " +
                    "email = @email " +
                    "WHERE id = @id; ";

                Comando.Parameters.AddWithValue("nome", t.Nome);
                Comando.Parameters.AddWithValue("sexo", t.Sexo);
                Comando.Parameters.AddWithValue("nascimento", t.Nascimento);
                Comando.Parameters.AddWithValue("naturalidade", t.Naturalidade);
                Comando.Parameters.AddWithValue("cpf", t.Cpf);
                Comando.Parameters.AddWithValue("email", t.Email);
                Comando.Parameters.AddWithValue("id", t.Id);
                Comando.ExecuteNonQuery();
                Comando.Dispose();
                conn.Close();
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
