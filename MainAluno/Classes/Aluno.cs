using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAluno
{
    public class Aluno
    {
        private string nome;
        private string sexo;
        private DateTime nascimento = new DateTime(1990, 01, 01);
        private string naturalidade;
        private string cpf;
        private string email;

        public Aluno()
        {

        }

        public Aluno(string nome, string sexo, DateTime nascimento, string naturalidade, string cpf, string email)
        {
            this.nome = nome;
            this.sexo = sexo;
            this.nascimento = nascimento;
            this.naturalidade = naturalidade;
            this.cpf = cpf;
            this.email = email;
        }

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public DateTime Nascimento
        {
            get { return nascimento; }
            set { nascimento = value; }
        }

        public string Naturalidade
        {
            get { return naturalidade; }
            set { naturalidade = value; }
        }

        public string Cpf
        {
            get { return cpf; }
            set { cpf = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
