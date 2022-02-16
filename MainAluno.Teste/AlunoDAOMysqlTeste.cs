using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MainAluno.Classes;
using System.Collections.Generic;

namespace MainAluno.Teste
{
    [TestClass]
    public class AlunoDAOMysqlTeste
    {
        Aluno aluno = new Aluno();
        AlunoDAO alunoDAO = new AlunoDAO(0);

        [TestMethod]
        public void TestaInsertMysql()
        {
            aluno.Nome = "João";
            aluno.Sexo = "Masculino";
            aluno.Nascimento = DateTime.Now;
            aluno.Naturalidade = "Caçador";
            aluno.Cpf = "234.476.040-77";
            aluno.Email = "jao@gmail.com";

            var resultado = alunoDAO.Insert(aluno);
            Assert.AreEqual(true, resultado);
        }

        [TestMethod]
        public void TestaSelectMysql()
        {
            List<Aluno> alunos = new List<Aluno>();
            alunos = alunoDAO.Select();
            Assert.IsNotNull(alunos);
        }

        [TestMethod]
        public void TestaUpdateMysql()
        {
            List<Aluno> alunos = alunoDAO.Select();
            aluno = alunos[alunos.Count - 1];
            aluno.Nome = "Gabrielly";
            aluno.Sexo = "Feminino";
            aluno.Nascimento = DateTime.Now;
            aluno.Naturalidade = "Videira";
            aluno.Cpf = "234.476.040-14";
            aluno.Email = "gaby@gmail.com";
            Assert.AreEqual(true,alunoDAO.Update(aluno));
        }

        [TestMethod]
        public void TestaDeleteMySql()
        {
            List<Aluno> alunos = alunoDAO.Select();
            aluno = alunos[alunos.Count - 1];
            Assert.AreEqual(true, alunoDAO.Delete(aluno));
        }
    }
}
