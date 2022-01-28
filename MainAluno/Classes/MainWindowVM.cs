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
        public MainWindowVM()
        {
            try
            {
                Conexao conexao = new Conexao();
                Alunos = conexao.Select();
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
                        Conexao conexao = new Conexao();
                        conexao.Insert(aluno);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    Alunos.Add(aluno);
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
                            Conexao conexao = new Conexao();
                            conexao.Delet(AlunoSelecionado.Id);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        Alunos.Remove(AlunoSelecionado);
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
                            Conexao conexao = new Conexao();
                            conexao.Update(alunoTemp);
                            Alunos.Clear();
                            Alunos = conexao.Select();
                            Notifica("Alunos");

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
