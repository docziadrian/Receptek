using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Adatbazis.KapcsolodasAdatbazishoz();
            List<string> osszesRecept = Adatbazis.TableSelect("receptek");
            List<Receptek> beolvasottReceptek = BeolvasasReceptek(osszesRecept);

            foreach (var item in beolvasottReceptek)
            {
                Console.WriteLine(item);
            }

        }

        static List<Receptek> BeolvasasReceptek(List<string> receptek)
        {
            List<Receptek> osszesLocal = new List<Receptek>();
            int szamlalo = 0;
            string sor = "";

            foreach (string recept in receptek)
            {
                szamlalo++;
                sor += recept + ";";

                if (szamlalo == 9)
                {
                    int id = Convert.ToInt32(sor.Split(';')[0]);
                    string receptNev = sor.Split(';')[1];
                    string hozzavalok = sor.Split(';')[2];
                    string leiras = sor.Split(';')[3];
                    int elokeszitesiIdo = Convert.ToInt32(sor.Split(';')[4]);
                    int fozesiIdo = Convert.ToInt32(sor.Split(';')[5]);
                    int osszesIdo = Convert.ToInt32(sor.Split(';')[6]);
                    int keszitoId = Convert.ToInt32(sor.Split(';')[7]);
                    int forrasId = Convert.ToInt32(sor.Split(';')[8]);

                    Receptek egyRecept = new Receptek(id, receptNev, hozzavalok, leiras, elokeszitesiIdo, fozesiIdo, osszesIdo, keszitoId, forrasId);
                    osszesLocal.Add(egyRecept);

                    sor = "";
                    szamlalo = 0;
                }
            }

            return osszesLocal;
        }
    }
}
