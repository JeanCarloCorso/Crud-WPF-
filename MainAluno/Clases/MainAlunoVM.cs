using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MainAluno
{
    public class MainAlunoVM : INotifyPropertyChanged
    {
        public ObservableCollection<Aluno> alunos { get; set; }
        public ICommand comando { get; private set; }
        public Aluno aluno { get; set; }
        public MainAlunoVM()
        {
            alunos = new ObservableCollection<Aluno>();
            aluno = new Aluno();
            
            comando = new RelayCommand((object paran) =>
            {
                alunos.Add(aluno);
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;  
        private void Notifica(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
