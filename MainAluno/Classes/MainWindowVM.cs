using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MainAluno
{
    public class MainWindowVM : INotifyPropertyChanged
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
            
            Alunos = new ObservableCollection<Aluno>();
            EstadoBotao = ControlaBotao(Alunos);
            Notifica("EstadoBotao");
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
                    Alunos.Add(aluno);
                    EstadoBotao = ControlaBotao(Alunos);
                    Notifica("EstadoBotao");
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
                        Alunos.Remove(AlunoSelecionado);
                        EstadoBotao = ControlaBotao(Alunos);
                        Notifica("EstadoBotao");
                    }

                }
                else
                {
                    AvisoSelecao aviso = new AvisoSelecao();
                    aviso.ShowDialog();
                }
            });

            Editar = new RelayCommand((object paran) =>
            {
                if(AlunoSelecionado != null)
                {
                    Aluno alunoTemp = new Aluno
                    {
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
                        Alunos.Remove(AlunoSelecionado);
                        Alunos.Add(alunoTemp);
                    }
                }
                else
                {
                    AvisoSelecao aviso = new AvisoSelecao();
                    aviso.ShowDialog();
                }

            });
        }

        private bool ControlaBotao(ObservableCollection<Aluno> Alunos)
        {
            if (Alunos.Count == 0) {return false;}
            return true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void Notifica(String propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
