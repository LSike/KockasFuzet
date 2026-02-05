using KockasFuzet.Controllers;
using KockasFuzet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KockasFuzet.Views
{
    internal class SzamlaView
    {
        public void CreateSzamlaView()
        {
            List<int> szolgaltatasIds = new SzolgaltatasController().GetSzolgaltatasIdList();
            List<string> szolgaltatoAzons = new SzolgaltatoController().GetSzolgaltatoRovidList();

            int szolgazon = -1;
            do
            {
                Console.Write("SzolgaltatasAzon");
                szolgazon = int.Parse(Console.ReadLine());
                if (!szolgaltatasIds.Contains(szolgazon))
                {
                    Console.WriteLine("Nincs ilyen szolgáltatás azonosító. A következőket használhatja:");
                    Console.WriteLine(string.Join(" ",szolgaltatasIds));
                    Console.WriteLine("Kérem, adja meg újra: ");
                }
            }
            while (!szolgaltatasIds.Contains(szolgazon));

            string szolgRov = "";
            do
            {
                Console.Write("SzolgaltatoRovidn");
                szolgRov = Console.ReadLine();
                if (!szolgaltatoAzons.Contains(szolgRov)) { 
                    Console.WriteLine("Nincs ilyen szolgáltató azonosító. A következőket használhatja:");
                    Console.WriteLine(string.Join(" ", szolgaltatoAzons));
                    Console.WriteLine("Kérem, adja meg újra: ");
                }
            }
            while (!szolgaltatoAzons.Contains(szolgRov));

            Console.WriteLine("Mettől: ");
            DateTime tol = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Meddig: ");
            DateTime ig = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Összeg: ");
            int osszeg = int.Parse(Console.ReadLine());

            Console.WriteLine("Határidő: ");
            DateTime hatarido = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Befizetve: ");
            string befizetString = Console.ReadLine();
            DateTime befizetve = befizetString == "" ? DateTime.MinValue : DateTime.Parse(befizetString);

            Console.WriteLine("Megjegyzés: ");
            string megjegyzes = Console.ReadLine();

            Szamla ujSzamla = new Szamla() {
                Id = -1,
                SzolgaltatasAzon = szolgazon,
                SzolgaltatoRovid = szolgRov,
                Tol = tol,
                Ig = ig,
                Osszeg = osszeg,
                Hatarido = hatarido,
                Befizetve = befizetve,
                Megjegyzes = megjegyzes            
            };
            Console.WriteLine(new SzamlaController().CreateSzamla(ujSzamla));
        }
    }
}
