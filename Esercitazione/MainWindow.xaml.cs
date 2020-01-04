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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Esercitazione
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_stampa_Click(object sender, RoutedEventArgs e)
        {
            string nome = (txt_nome.Text);
            int voto = int.Parse(txt_voto.Text);
            if (voto < 0 || voto > 10)
            {
                lbl_ex.Content = "Il valore inserito non è valido";                
            }else
            {
                lbl_ex.Content = "Stampato correttamente";
            }

        }
    }
}
