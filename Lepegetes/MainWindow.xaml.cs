using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lepegetes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int indexJatekos = 0;
        public MainWindow()
        {
            InitializeComponent();
            TablaGeneralas();
        }





        private void TablaGeneralas()
        {
            ugTabla.Rows = 8;
            ugTabla.Columns = 30;
            ugTabla.Children.Clear();
            Random lyuk = new Random();



            for (int index = 0; index < ugTabla.Rows * ugTabla.Columns; index++)
            {
                                                                                                                                              
                Button hely = new Button();
                hely.Height = 40;
                hely.Width = 35;
                hely.Background = Brushes.LightGreen;
                hely.Name = $"Hely{index}";
                if (lyuk.Next(0,4) == 1 )
                {
                    hely.Background = Brushes.Orange;
                }
                
                if (indexJatekos != 20)
                {
                    if (lyuk.Next(0,8) == 0)
                    {
                        hely.Background = Brushes.GreenYellow;
                        hely.FontSize = 10;
                        hely.Content = $"{indexJatekos+1}";
                        indexJatekos++;
                    }
                }
                //Border kor = new Border();
                //kor.CornerRadius = new CornerRadius(200);
                //kor.BorderBrush = Brushes.Orange;
                //kor.BorderThickness = new Thickness(3);
                //kor.Child = hely;

                ugTabla.Children.Add(hely);
                


            }
        }
        private void btnLepkedes_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button hely in ugTabla.Children)
            {
                if (hely.Content != null || hely.Content != "")
                {
                    ugTabla(ugTabla.Children.IndexOf(hely));
                    
                }
            }
        }
    }



}
