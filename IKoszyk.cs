using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium
{
    interface IKoszyk
    {
        void DodajProdukt(string Nazwa, double cenaJednostkowa, int Ilosc);
        void SkopiujOstatni();
        void Skasuj(int Nr);
        void Wydrukuj();
        void Wyczysc();
      
    }
}
