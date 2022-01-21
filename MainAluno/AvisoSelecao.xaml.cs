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
    /// Lógica interna para AvisoSelecao.xaml
    /// </summary>
    public partial class AvisoSelecao : Window
    {
        public AvisoSelecao()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
