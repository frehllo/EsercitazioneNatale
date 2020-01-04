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
        string nomi = @"prova.txt";
        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(filei))
                //divisione voti
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
                                writernumeri.WriteLine("{0}", linei.Substring(found + 1));
                            }
                        }
                    }
                }
            //voto max
            using (StreamReader readernumeri = new StreamReader(voti))
            {
                string linen = readernumeri.ReadLine();
                double max = 0;
                while ((linen = readernumeri.ReadLine()) != null)
                {
                    double n = double.Parse(linen);
                    if (n > 0 && n <= 10 && n > max)
                    {
                        max = n;
                    }
                }
                lbl_max.Content = $"Il voto più alto è stato {max}";
            }


            //divisione nomi
            using (StreamWriter writervalidi = new StreamWriter(nomi))
            {
                using (StreamReader readerin = new StreamReader(filei))
                {
                    writervalidi.WriteLine("NOMI");
                    string linev = readerin.ReadLine();
                    while ((linev = readerin.ReadLine()) != null)
                    {
                        Console.WriteLine(linev);
                        {
                            int pos = linev.IndexOf(",");
                            if (pos >= 0)
                            {
                                string afterFounder = linev.Remove(pos);
                                writervalidi.WriteLine(afterFounder);
                            }
                        }
                    }
                }
            }


            //lettura solo dei validi
            using (StreamReader readervoti = new StreamReader(voti))
            {
                string vline = readervoti.ReadLine();

                using (StreamReader readernomi = new StreamReader(nomi))
                {
                    string nline = readernomi.ReadLine();

                    using (StreamWriter writervalidi = new StreamWriter(filev))
                    {
                        writervalidi.WriteLine("VALIDI");
                        while ((vline = readervoti.ReadLine()) != null)
                        {
                            while ((nline = readernomi.ReadLine()) != null)
                            {
                                string nome = nline;
                                string virgola = ",";
                                double n;
                                n = double.Parse(vline);
                                if (n < 0 || n > 10)
                                {
                                    writervalidi.WriteLine("");
                                }
                                else
                                {
                                    writervalidi.WriteLine($"{nome}{virgola}{n}");
                                }
                                break;
                            }

                        }
                    }
                }
            }


            //scrittura nella listbox
            using (StreamReader readervalidi = new StreamReader(filev))
            {                
                string line = readervalidi.ReadLine();
                while ((line = readervalidi.ReadLine()) != null)
                {
                    lbx_cronologia.Items.Add(line.ToString());
                }
            }
        }
    }
}
