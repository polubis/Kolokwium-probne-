using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Kolokwium
{
    class Koszyk:IKoszyk
    {
        public List<Produkt>Zakupy;
        public Koszyk() 
        {
            Zakupy = new List<Produkt>();
        }
        public void DodajProdukt(string Nazwa,double cenaJednostkowa,int Ilosc)
        {
            Zakupy.Add(new Produkt(Nazwa, cenaJednostkowa, Ilosc));
           
        }
        public void Skasuj(int Nr)
        {
            if(Nr!=-1)
            {
                Zakupy.RemoveAt(Nr);
            }
        }
        public void Wyczysc()
        {
            Zakupy.Clear();
        }
        public void Wydrukuj()
        {
            string Sciezka = (DateTime.Today.Year + " " + DateTime.Today.Month + " " + DateTime.Today.Day + " " + DateTime.Today.Hour + " " + DateTime.Today.Second + ".txt").ToString();
            TextWriter Zapis = new StreamWriter(Sciezka,true);
            using(Zapis)
            {
               if(File.Exists(Sciezka))
               {
                   Zapis.WriteLine("Data  : " + Sciezka);
                   foreach (var element in Zakupy)
                   {
                       Zapis.WriteLine("Nazwa : " + element.Nazwa + "Cena : " + element.cenaJednostkowa.ToString() + "Ilosc : " + element.Ilosc.ToString());
                   }
               }
               if(!File.Exists(Sciezka))
               {
                   Zapis.WriteLine("Data : " + Sciezka);
                   foreach (var element in Zakupy)
                   {
                       Zapis.WriteLine("Nazwa : " + element.Nazwa + "Cena : " + element.cenaJednostkowa.ToString() + "Ilosc : " + element.Ilosc.ToString());
                   }
               }
            }

        }
        public void SkopiujOstatni()
        {
            int IleProduktow = Zakupy.Count;
            Produkt OstatniProdukt = (Produkt)Zakupy[IleProduktow - 1];
            Produkt kopia = new Produkt();
            kopia = (Produkt)OstatniProdukt.Clone();
            Zakupy.Add(new Produkt(kopia.Nazwa, kopia.cenaJednostkowa, kopia.Ilosc));
            

        }
        public double ObliczSume()
        {
            double suma = 0;
            foreach(var element in Zakupy)
            {
                suma = suma + element.PodajCeneLaczna();
            }
            return suma;
        }
        public string SumaPoKasowaniu(Produkt obiekt,double Suma)
        {
            Suma = Suma - obiekt.cenaJednostkowa * obiekt.Ilosc;
            return Suma.ToString();
        }

    }
}
