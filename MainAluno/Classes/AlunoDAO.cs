using MainAluno.Databases;
using MainAluno.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAluno.Classes
{
    internal class AlunoDAO : IDAO<Aluno>
    {
        private static IConexao conn;
        private IDbCommand Comando;

        public AlunoDAO(int ops)
        {
            switch (ops)
            {
                case 0: conn = new Mysql(); break;
                case 1: conn = new Postgres(); break;

                default: throw new Exception();
            }
        }

        public void Delete(Aluno t)
        {
            try
            {
                conn.Open();
                Comando = conn.Comandos();
                Comando.CommandText = $"DELETE FROM Alunos WHERE id=\"{t.Id}\"";

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
                Comando = conn.Comandos();
                Comando.CommandText = $"INSERT INTO Alunos (nome, sexo, nascimento, naturalidade, cpf, email) VALUES (\"{t.Nome}\",\"{t.Sexo}\",\"{t.Nascimento}\",\"{t.Naturalidade}\",\"{t.Cpf}\",\"{t.Email}\")";

                Comando.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                Comando.Dispose();
                conn.Close();
            }
        }

        public List<Aluno> Select()
        {
            try
            {
                conn.Open();
                Comando = conn.Comandos();
                Comando.CommandText = "SELECT * FROM Alunos";
                IDataReader dr = Comando.ExecuteReader();

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
                
                return Alunos;

            }catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                Comando.Dispose();
                conn.Close();
            }
        }

        public void Update(Aluno t)
        {
            try
            {
                conn.Open();
                Comando = conn.Comandos();
                Comando.CommandText = $"UPDATE Alunos SET nome = \"{t.Nome}\", sexo = \"{t.Sexo}\", nascimento = \"{t.Nascimento}\", naturalidade = \"{t.Naturalidade}\", cpf = \"{t.Cpf}\", email = \"{t.Email}\" WHERE id = \"{t.Id}\";";

                Comando.ExecuteNonQuery();
                
            }catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                Comando.Dispose();
                conn.Close();
            }
        }
    }
}
