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
using System.IO;

namespace Esercitazione
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string filei = @"invalidi.txt";
        string filev = @"validi.txt";
        string voti = @"voti.txt";
        string prova = @"prova.txt";
        public MainWindow()
        {
            InitializeComponent();
            if(File.Exists(filei))
                using (StreamReader readerinvalido = new StreamReader(filei))
                {
                    using (StreamWriter writernumeri = new StreamWriter(voti))
                    {
                        writernumeri.WriteLine("VOTI");
                        string linei = readerinvalido.ReadLine();
                        while ((linei = readerinvalido.ReadLine()) != null)
                        {
                            int found = 0;                                                        
                                Console.WriteLine(linei);
                            {
                                found = linei.IndexOf(",");
                                writernumeri.WriteLine("{0}", linei.Substring(found+1));
                            }
                        }
                    }


                    using (StreamReader readernumeri = new StreamReader(voti))
                    {
                        string linen = readernumeri.ReadLine();
                        double max = 0;
                        while ((linen = readernumeri.ReadLine()) != null)
                        {                            
                            double n = double.Parse(linen);                            
                            if (n>max)
                            {
                                max = n;
                            }                            
                        }
                        lbl_max.Content = $"Il voto più alto è stato {max}";
                    }


                    
                }                            
        }   
    }
}
