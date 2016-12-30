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

namespace Kolokwium
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Koszyk koszyk = new Koszyk();
        public MainWindow()
        {
            InitializeComponent();
            GetIlosc.Text = "1";
            GetCena.Text = "0";
            Suma.Text = "0";
        }

        private void DodajClick(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(GetNazwa.Text) || string.IsNullOrEmpty(GetIlosc.Text)||string.IsNullOrEmpty(GetCena.Text))
            {
                MessageBox.Show("Uzupelnij pola wartosciami!");
            }
            try
            {
                koszyk.DodajProdukt(GetNazwa.Text.ToString(), double.Parse(GetCena.Text), Convert.ToInt32(GetIlosc.Text));
                ListaZakupow.ItemsSource = koszyk.Zakupy;
                CollectionViewSource.GetDefaultView(ListaZakupow.ItemsSource).Refresh();
                Suma.Text = koszyk.ObliczSume().ToString();

            }
            catch(Exception k)
            {
                MessageBox.Show(k.Message);
            }
         
        }

        private void SkasujClick(object sender, RoutedEventArgs e)
        {
            int wybranyWiersz = ListaZakupow.SelectedIndex;
            try
            {
                koszyk.Skasuj(wybranyWiersz);
                Produkt trash = (Produkt)ListaZakupow.SelectedItem;
                Suma.Text = koszyk.SumaPoKasowaniu(trash, double.Parse(Suma.Text));
                CollectionViewSource.GetDefaultView(ListaZakupow.ItemsSource).Refresh();
            }
            catch(Exception s)
            {
                MessageBox.Show(s.Message);
            }
           
        }

        private void ZamknijClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void WyczyscClick(object sender, RoutedEventArgs e)
        {
            try
            {
                koszyk.Wyczysc();
                CollectionViewSource.GetDefaultView(ListaZakupow.ItemsSource).Refresh();
            }
            catch(Exception g)
            {
                MessageBox.Show(g.Message);
            }
            Suma.Text = "0";
            GetNazwa.Text = "";
            GetIlosc.Text = "1";
            GetCena.Text = "0";

        }

        private void WydrukujClick(object sender, RoutedEventArgs e)
        {
            koszyk.Wydrukuj();
        }

        private void SkopiujClick(object sender, RoutedEventArgs e)
        {
            koszyk.SkopiujOstatni();
            int Liczba = koszyk.Zakupy.Count;
            Produkt trashy = (Produkt)koszyk.Zakupy[Liczba - 1];
            double Ostatecznie = trashy.cenaJednostkowa*trashy.Ilosc + double.Parse(Suma.Text);
            Suma.Text = Ostatecznie.ToString();
          
            CollectionViewSource.GetDefaultView(ListaZakupow.ItemsSource).Refresh();
            
        }

    }
}
