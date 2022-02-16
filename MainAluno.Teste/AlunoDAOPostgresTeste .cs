using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MainAluno.Classes;
using System.Collections.Generic;

namespace MainAluno.Teste
{
    [TestClass]
    public class AlunoDAOPostgresTeste
    {
        Aluno aluno = new Aluno();
        AlunoDAO alunoDAO = new AlunoDAO(1);

        [TestMethod]
        public void TestaInsertPostgres()
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
        public void TestaSelectPostgres()
        {
            List<Aluno> alunos = new List<Aluno>();
            alunos = alunoDAO.Select();
            Assert.IsNotNull(alunos);
        }

        [TestMethod]
        public void TestaUpdatePostgres()
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
        public void TestaDeletePostgres()
        {
            List<Aluno> alunos = alunoDAO.Select();
            aluno = alunos[alunos.Count - 1];
            Assert.AreEqual(true, alunoDAO.Delete(aluno));
        }
    }
}
