using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolokwium
{
    class Produkt:ICloneable
    {
        public string Nazwa {get; set;}
        public double cenaJednostkowa { get; set; }
        public int Ilosc { get; set; }
        public Produkt() { }
        public Produkt(string Nazwa, double cenaJednostkowa,int Ilosc)
        {
            this.Nazwa = Nazwa;
            this.cenaJednostkowa = cenaJednostkowa;
            this.Ilosc = Ilosc;
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
        public override string ToString()
        {
            return Nazwa + "," + Ilosc.ToString()+"*"+ cenaJednostkowa.ToString()+"="+PodajCeneLaczna().ToString();
        }
        public double PodajCeneLaczna()
        {
            return Math.Round(cenaJednostkowa*Ilosc);
        }
    }
}
