using MainAluno.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainAluno
{
    public class Aluno : BaseNotify
    {
        private string nome;
        private string sexo;
        private string nascimento = DateTime.Today.ToString("dd-MM-yyyy");
        private string naturalidade;
        private string cpf;
        private string email;

        public Aluno()
        {

        }

        public Aluno(string nome, string sexo, string nascimento, string naturalidade, string cpf, string email)
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
            set 
            { 
                nome = value;
                Notifica("Nome");
            }
        }

        public string Sexo
        {
            get { return sexo; }
            set 
            { 
                sexo = value;
                Notifica("Sexo");
            }
        }

        public string Nascimento
        {
            get { return nascimento; }
            set 
            { 
                nascimento = value;
                Notifica("Nascimento");
            }
        }

        public string Naturalidade
        {
            get { return naturalidade; }
            set 
            { 
                naturalidade = value;
                Notifica("Naturalidade");
            }
        }

        public string Cpf
        {
            get { return cpf; }
            set 
            { 
                cpf = value;
                Notifica("Cpf");
            }
        }

        public string Email
        {
            get { return email; }
            set 
            { 
                email = value;
                Notifica("Email");
            }
        }
    }
}
