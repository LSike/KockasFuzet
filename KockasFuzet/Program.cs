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
                    List<Szolgaltato> szolgaltatokListaja = new List<Szolgaltato>()
                    {
                        new Szolgaltato(){
                            RovidNev = "ABC",
                            Nev = "Helyi kis abc",
                            Ugyfelszolgalat = "Miskolc, Kamra köz 3"},
                        new Szolgaltato(){
                            RovidNev = "DEF",
                            Nev = "Dávid Esti Falatozója",
                            Ugyfelszolgalat = "Miskolc, Bendőtömő utca 4"},
                        new Szolgaltato(){
                            RovidNev = "GHI",
                            Nev = "Gazdagság Halmozó Intézet",
                            Ugyfelszolgalat = "Brüsszel, Tulip str. 3"},
                    };
                    List<Szolgaltato> listaAdatbazisbol = new SzolgaltatoController().GetSzolgaltatoList();
                    new SzolgaltatoView().ShowSzolgaltatoList(listaAdatbazisbol);
                    break;
                case "3":
                    Szolgaltato ujSzolgaltato = new SzolgaltatoView().CreateView();
                    if(ujSzolgaltato != null)
                        Console.WriteLine(new SzolgaltatoController().CreateSzolgaltato(ujSzolgaltato));
                    break;
                default:
                    break;
            }
            
        }
    }
}
