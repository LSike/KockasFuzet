using KockasFuzet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KockasFuzet.Views
{
    internal class SzolgaltatoView
    {
        public SzolgaltatoView() { }

        public Szolgaltato CreateView()
        {
            Szolgaltato szolgaltato = new Szolgaltato()
            {
                RovidNev = "",
                Nev = "",
                Ugyfelszolgalat = ""
            };
            int valasztott = 0;
            bool kilep = false;
            while (!kilep)
            {
                ShowSzolgaltatoHighlight(szolgaltato, valasztott);
                ConsoleKey valasz = Console.ReadKey().Key;
                switch (valasz)
                {
                    case ConsoleKey.Tab:
                        valasztott = (valasztott+1) % 5;
                        break;
                    case ConsoleKey.Enter:
                        switch (valasztott)
                        {
                            case 0:
                                Console.Write($"{szolgaltato.RovidNev} új érték: ");
                                szolgaltato.RovidNev = Console.ReadLine();
                                break;
                            case 1:
                                Console.Write($"{szolgaltato.Nev} új érték: ");
                                szolgaltato.Nev = Console.ReadLine();
                                break;
                            case 2:
                                Console.Write($"{szolgaltato.Ugyfelszolgalat} új érték: ");
                                szolgaltato.Ugyfelszolgalat = Console.ReadLine();
                                break;
                            case 3:
                                return szolgaltato;                                
                            case 4:
                                kilep = true;
                                break;
                        }
                        break;
                }
            }
            return null;
        }

        private static void ShowSzolgaltatoHighlight(Szolgaltato szolgaltato, int kiemeles)
        {
            Console.Clear();
            ConsoleColor bgcolor = Console.BackgroundColor;
            ConsoleColor fgcolor = Console.ForegroundColor;
            SetInverse(kiemeles, 0, bgcolor, fgcolor);
            Console.WriteLine($"Rövid név: {szolgaltato.RovidNev}");
            SetInverse(kiemeles, 1, bgcolor, fgcolor);
            Console.WriteLine($"Név: {szolgaltato.Nev}");
            SetInverse(kiemeles, 2, bgcolor, fgcolor);
            Console.WriteLine("Ügyfélszolgálat");
            Console.WriteLine($"Cím: {szolgaltato.Ugyfelszolgalat}");
            Console.WriteLine("Telefon:");
            Console.WriteLine("---------------");
            SetInverse(kiemeles, 3, bgcolor, fgcolor);
            Console.Write("Mentés ");
            SetInverse(kiemeles, 4, bgcolor, fgcolor);
            Console.WriteLine("Mégsem");
            Console.WriteLine("Tab: léptet, Enter: választott szerkesztése, ");
        }

        private static void SetInverse(int kiemeles, int aktual, ConsoleColor bgcolor, ConsoleColor fgcolor)
        {
            if (kiemeles == aktual)
            {
                Console.ForegroundColor = bgcolor;
                Console.BackgroundColor = fgcolor;
            }
            else
            {
                Console.ForegroundColor = fgcolor;
                Console.BackgroundColor = bgcolor;
            }
        }

        public void ShowSzolgaltato(Szolgaltato szolgaltato)
        {
            Console.WriteLine($"Rövid név: {szolgaltato.RovidNev}");
            Console.WriteLine($"Név: {szolgaltato.Nev}");
            Console.WriteLine("Ügyfélszolgálat");
            Console.WriteLine($"Cím: {szolgaltato.Ugyfelszolgalat}");
            Console.WriteLine("Telefon:");
        }

        public void ShowSzolgaltatoList(List<Szolgaltato> szolgaltatoLista) 
        {
            //120*30 a méret ĺôöĽá¬ ┤│┼└┴┬├
            Console.WriteLine("|--------┬-------------------------------┬-------------------------------------------¬");
            Console.WriteLine("| RövNev |              Név              |                Űgyfélszolgálat             |");
            Console.WriteLine("|        |                               |        Cím                    |   Telefon  |");
            foreach (Szolgaltato szolgaltato in szolgaltatoLista)
            {
                Console.WriteLine(SzolgaltatoToRow(szolgaltato));
            }

            Console.WriteLine("|--------┼-------------------------------┼--------------------------------------------|");
        }

        private static string SzolgaltatoToRow(Szolgaltato szolgaltato)
        {
            string row = "|";
            row += szolgaltato.RovidNev;
            row += new string(' ', 8 - szolgaltato.RovidNev.Length) + "|";
            row += szolgaltato.Nev.Length < 30 ? szolgaltato.Nev + new string(' ', 30 - szolgaltato.Nev.Length+1) +"|": szolgaltato.Nev.Substring(0,28) + "...|";
            row += szolgaltato.Ugyfelszolgalat.Length < 30 ? szolgaltato.Ugyfelszolgalat + new string(' ', 30 - szolgaltato.Ugyfelszolgalat.Length+1)+ "|            |" : szolgaltato.Ugyfelszolgalat.Substring(0,28) + "...|            |";
            return row;
        }
    }
}
