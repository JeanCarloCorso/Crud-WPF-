using MainAluno.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MainAluno
{
    public class MainWindowVM : BaseNotify
    {
        public ObservableCollection<Aluno> Alunos { get; set; }
        public Aluno aluno { get; set; }
        public Aluno AlunoSelecionado { get; set; }
        public bool EstadoBotao { get; set; }
        public ICommand Adicionar { get; private set; }
        public ICommand Remover { get; private set; }
        public ICommand Editar { get; private set; }
        //private Conexao conexao;
        private AlunoDAO conexao;
        public MainWindowVM()
        {
            try
            {
                //conexao = new Conexao();
                conexao = new AlunoDAO(0);
                Alunos = new ObservableCollection<Aluno>(conexao.Select());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Comandos();
        }

        private void Comandos()
        {
            Adicionar = new RelayCommand((object paran) =>
            {
                aluno = new Aluno();

                TelaAluno cadastro = new TelaAluno
                {
                    DataContext = aluno
                };
                cadastro.ShowDialog();

                if(cadastro.DialogResult == true)
                {
                    try
                    {
                        conexao.Insert(aluno);
                        Alunos.Add(aluno);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            });
        
            Remover = new RelayCommand((object paran) =>
            {
                if (AlunoSelecionado != null)
                {
                    AvisoRemocao confirma = new AvisoRemocao();
                    confirma.ShowDialog();
                    if (confirma.DialogResult == true)
                    {
                        try
                        {
                            conexao.Delete(AlunoSelecionado);
                            Alunos.Remove(AlunoSelecionado);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                }
                else
                {
                    AvisoSelecao aviso = new AvisoSelecao();
                    aviso.ShowDialog();
                }
            },(object paran) =>
            {
                return Alunos.Count > 0;
            });

            Editar = new RelayCommand((object paran) =>
            {
                if(AlunoSelecionado != null)
                {
                    Aluno alunoTemp = new Aluno
                    {
                        Id = AlunoSelecionado.Id,
                        Nome = AlunoSelecionado.Nome,
                        Sexo = AlunoSelecionado.Sexo,
                        Nascimento = AlunoSelecionado.Nascimento,
                        Naturalidade = AlunoSelecionado.Naturalidade,
                        Cpf = AlunoSelecionado.Cpf,
                        Email = AlunoSelecionado.Email,

                    };
                    TelaAluno cadastro = new TelaAluno
                    {
                        DataContext = alunoTemp
                    };
                    if (cadastro.ShowDialog() == true)
                    {
                        try
                        {
                            conexao.Update(alunoTemp);
                            AlunoSelecionado.Nome = alunoTemp.Nome;
                            AlunoSelecionado.Sexo = alunoTemp.Sexo;
                            AlunoSelecionado.Nascimento = alunoTemp.Nascimento;
                            AlunoSelecionado.Naturalidade = alunoTemp.Naturalidade;
                            AlunoSelecionado.Cpf = alunoTemp.Cpf;
                            AlunoSelecionado.Email = alunoTemp.Email;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                {
                    AvisoSelecao aviso = new AvisoSelecao();
                    aviso.ShowDialog();
                }

            },(object paran) =>{
                return AlunoSelecionado != null;
            });
        }
    }
}
