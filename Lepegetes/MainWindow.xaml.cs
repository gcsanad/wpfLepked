using Microsoft.VisualBasic;
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
        const int TABLA_SOROK = 10;
        const int TABLA_OSZLOPOK = 30;
        const int LEKEK_SZAMA = 10;
        const int BABUK_SZAMA = 100;

        List<Point> lyukakLista = new List<Point>();
        List<Point> babukHelye = new List<Point>();
        List<Babu> babukListaja = new List<Babu>();
        Random rand = new Random();
        int indexJatekos = 0;
        public MainWindow()
        {
            InitializeComponent();
            TablaGeneralas();
        }





        private List<Point> OsszesHely()
        {
            List<Point> pontok = new List<Point>();
            for (int sorok = 0; sorok < TABLA_SOROK; sorok++)
            {
                for (int oszlopok = 0; oszlopok < TABLA_OSZLOPOK; oszlopok++)
                {
                    pontok.Add(new Point(oszlopok, sorok));
                }
            }
            return pontok;
        }

        private void TablaGeneralas()
        {
            for (int sorIndex = 0; sorIndex < TABLA_SOROK; sorIndex++)
            {
                gridTabla.RowDefinitions.Add(new RowDefinition());
                
            }

            for (int oszlopIndex = 0; oszlopIndex < TABLA_OSZLOPOK; oszlopIndex++)
            {
                gridTabla.ColumnDefinitions.Add(new ColumnDefinition());
            }
            gridTabla.Background = Brushes.LightBlue;
            
            
            //Lékek elhelyezése

            List<Point> szabadTerek = OsszesHely();
            for (int i = 0; i < LEKEK_SZAMA; i++)
            {
                Ellipse ujLek = new();
                ujLek.Width = 20;
                ujLek.Height = 20;
                ujLek.Fill = Brushes.Chocolate;
                int randomHely = rand.Next(szabadTerek.Count());
                Grid.SetColumn(ujLek, (int)szabadTerek[randomHely].X);
                Grid.SetRow(ujLek, (int)szabadTerek[randomHely].Y);
                lyukakLista.Add(szabadTerek[randomHely]);
                szabadTerek.RemoveAt(randomHely);
                gridTabla.Children.Add(ujLek);
            }

            //Bábuk elhelyezése
            szabadTerek = OsszesHely().Except(lyukakLista).ToList();
            for (int i = 0; i < BABUK_SZAMA; i++)
            {
                Button ujBabu = new Button();
                ujBabu.Background = Brushes.DarkBlue;
                ujBabu.Content = i + 1;
                ujBabu.Foreground = Brushes.White;
                ujBabu.FontSize = 10;
                int randomHely = rand.Next(szabadTerek.Count());
                Grid.SetColumn(ujBabu, (int)szabadTerek[randomHely].X);
                Grid.SetRow(ujBabu, (int)szabadTerek[randomHely].Y);
                babukListaja.Add(new Babu(i + 1, szabadTerek[randomHely], ujBabu));
                babukHelye.Add(szabadTerek[randomHely]);
                szabadTerek.RemoveAt(randomHely);
                gridTabla.Children.Add(ujBabu);
            }

        }
        private void btnLepkedes_Click(object sender, RoutedEventArgs e)
        {
            foreach (var babu in gridTabla.Children)
            {
                if (babu is Button)
                {
                 Point babuHelye = new Point(Grid.GetColumn(babu as Button),Grid.GetRow(babu as Button));
                 List<Point> szabadTerek = new();
                    for (int sorok = 0; sorok < TABLA_SOROK; sorok++)
                    {
                        for (int oszlopok = 0; oszlopok < TABLA_OSZLOPOK; oszlopok++)
                        {
                            Point igen = new Point(oszlopok, sorok);
                            if (!babukHelye.Contains(igen) && !lyukakLista.Contains(igen))
                            {
                             szabadTerek.Add(igen);

                            }
                        }
                    }
                    int randomHely = rand.Next(szabadTerek.Count());
                    babukHelye.Remove(babuHelye);
                    Grid.SetColumn(babu as Button, (int)szabadTerek[randomHely].X);
                    Grid.SetRow(babu as Button, (int)szabadTerek[randomHely].Y);
                    babukHelye.Add(new Point(Grid.GetColumn(babu as Button), Grid.GetRow(babu as Button)));
                }
                
                
            }
        }
    }



}
