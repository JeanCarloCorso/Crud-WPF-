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
    public class AlunoDAO : IDAO<Aluno>
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

        public bool Delete(Aluno t)
        {
            try
            {
                conn.Open();
                Comando = conn.Comandos();
                Comando.CommandText = $"DELETE FROM Alunos WHERE id=\"{t.Id}\"";

                Comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Comando.Dispose();
                conn.Close();
            }
        }

        public bool Insert(Aluno t)
        {
            try
            {
                conn.Open();
                Comando = conn.Comandos();
                Comando.CommandText = $"INSERT INTO Alunos (nome, sexo, nascimento, naturalidade, cpf, email) VALUES (\"{t.Nome}\",\"{t.Sexo}\",\"{t.Nascimento.ToString("yyyy/MM/dd h:mm:ss")}\",\"{t.Naturalidade}\",\"{t.Cpf}\",\"{t.Email}\")";

                Comando.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
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

        public bool Update(Aluno t)
        {
            try
            {
                conn.Open();
                Comando = conn.Comandos();
                Comando.CommandText = $"UPDATE Alunos SET nome = \"{t.Nome}\", sexo = \"{t.Sexo}\", nascimento = \"{t.Nascimento.ToString("yyyy/MM/dd h:mm:ss")}\", naturalidade = \"{t.Naturalidade}\", cpf = \"{t.Cpf}\", email = \"{t.Email}\" WHERE id = \"{t.Id}\";";

                Comando.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Comando.Dispose();
                conn.Close();
            }
        }
    }
}
