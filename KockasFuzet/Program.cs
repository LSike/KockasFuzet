using KockasFuzet.Controllers;
using KockasFuzet.Models;
using KockasFuzet.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KockasFuzet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool kilep = false;
            while (!kilep)
            {
                Console.Clear();
                Console.WriteLine("1. Adott szolgáltató kiírása");
                Console.WriteLine("2. Szolgáltatók kiírása");
                Console.WriteLine("3. Szolgáltató felvitele");
                Console.WriteLine("4. Kilépés");
                string valasz = Console.ReadLine();

                switch (valasz)
                {
                    case "1":
                        Szolgaltato probaSzolgaltato = new Szolgaltato()
                        {
                            RovidNev = "ABC",
                            Nev = "Helyi kis abc",
                            Ugyfelszolgalat = "Miskolc, Kamra köz 3"
                        };
                        new SzolgaltatoView().ShowSzolgaltato(probaSzolgaltato);
                        break;
                    case "2":
                        List<Szolgaltato> listaAdatbazisbol = new SzolgaltatoController().GetSzolgaltatoList();
                        new SzolgaltatoView().ShowSzolgaltatoList(listaAdatbazisbol);
                        Console.WriteLine("Nyomj meg egy gombot a visszatéréshez...");
                        Console.ReadKey();
                        break;
                    case "3":
                        new SzolgaltatoView().CreateView();
                        break;
                    case "4":
                        kilep = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
