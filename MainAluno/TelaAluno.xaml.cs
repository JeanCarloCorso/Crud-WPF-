using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MainAluno
{
    /// <summary>
    /// Lógica interna para TelaAluno.xaml
    /// </summary>
    public partial class TelaAluno : Window
    {
        public TelaAluno()
        {
            InitializeComponent();
            valorsexo.ItemsSource = Enum.GetValues(typeof(Classes.Sexo)).Cast<Classes.Sexo>();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            DialogResult= false;
        }
    }
}
