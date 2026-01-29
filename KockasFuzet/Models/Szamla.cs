using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KockasFuzet.Models
{
    internal class Szamla
    {
        int id;
        int szolgaltatasAzon;
        string szolgaltatoRovid;
        DateTime tol;
        DateTime ig;
        int osszeg;
        DateTime hatarido;
        DateTime befizetve;
        string megjegyzes;

        public Szamla(int id, int szolgaltatasAzon, string szolgaltatoRovid, DateTime tol, DateTime ig, int osszeg, DateTime hatarido, DateTime befizetve, string megjegyzes)
        {
            Id = id;
            SzolgaltatasAzon = szolgaltatasAzon;
            SzolgaltatoRovid = szolgaltatoRovid;
            Tol = tol;
            Ig = ig;
            Osszeg = osszeg;
            Hatarido = hatarido;
            Befizetve = befizetve;
            Megjegyzes = megjegyzes;
        }

        public Szamla() { }

        public int Id { get => id; set => id = value; }
        public int SzolgaltatasAzon { get => szolgaltatasAzon; set => szolgaltatasAzon = value; }
        public string SzolgaltatoRovid { get => szolgaltatoRovid; set => szolgaltatoRovid = value; }
        public DateTime Tol { get => tol; set => tol = value; }
        public DateTime Ig { get => ig; set => ig = value; }
        public int Osszeg { get => osszeg; set => osszeg = value; }
        public DateTime Hatarido { get => hatarido; set => hatarido = value; }
        public DateTime Befizetve { get => befizetve; set => befizetve = value; }
        public string Megjegyzes { get => megjegyzes; set => megjegyzes = value; }
    }
}
