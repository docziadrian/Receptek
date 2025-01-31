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
            /*Adatbazis.TableInsertKeszitok(); Insert a készítők táblába
            Adatbazis.TableInsertReceptek();    Insert a receptek táblába
            Adatbazis.TableInsertForrasokba(); Insert a források táblába*/
            KeszitoKereses();
            foreach (var item in beolvasottReceptek)
            {
                Console.WriteLine(item);
            }

        }

        private static void KeszitoKereses()
        {
            int osszesID = 0;//osszesKeszitok.length;
            Console.WriteLine($"Adj meg egy azonosítot a készítőhöz, a következő intervallumba (1-{osszesID+1})!");
        bekeres:
            int keresettID = Convert.ToInt32(Console.ReadLine());
            if (keresettID <= 0 || keresettID < osszesID + 1)
            {
                Console.WriteLine($"Hibás adat! Adj meg egy azonosítot a készítőhöz, a következő intervallumba (1-{osszesID + 1})!");
                goto bekeres;
            }
            else { 
                KeszitoKereso(keresettID, out string nev);
            }
        }

        private static void KeszitoKereso(int keresettID, out string nev)
        {
            Console.WriteLine("Keressük a készítőt...");
            nev = Console.ReadLine();
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
