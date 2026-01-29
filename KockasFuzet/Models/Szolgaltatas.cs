using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KockasFuzet.Models
{
    internal class Szolgaltatas
    {
        int id;
        string nev;
        public int Id { get { return id; } set { id = value; } }
        public string Nev { get { return nev; } set { nev = value; } }
        public Szolgaltatas() { }

        public Szolgaltatas(int id, string nev)
        {
            this.id = id;
            this.nev = nev;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Név: {Nev}";
        }
    }
}
