using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KockasFuzet.Models
{
    internal class Szolgaltato
    {
        string rovidNev;
        string nev;
        string ugyfelszolgalat;

        public Szolgaltato(string rovidNev, string nev, string ugyfelszolgalat)
        {
            this.rovidNev = rovidNev;
            this.nev = nev;
            this.ugyfelszolgalat = ugyfelszolgalat;
        }

        public string RovidNev { get => rovidNev; set => rovidNev = value; }
        public string Nev { get => nev; set => nev = value; }
        public string Ugyfelszolgalat { get => ugyfelszolgalat; set => ugyfelszolgalat = value; }

        public Szolgaltato() { }

        public override string ToString()
        {
            return $"Rövid név: {RovidNev}, Név{Nev}, Ügyfélszolgálat: {Ugyfelszolgalat}";
        }
    }
}
