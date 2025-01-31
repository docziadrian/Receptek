using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Adatbazis.KapcsolodasAdatbazishoz();
            List<string> osszesRecept = Adatbazis.TableSelect("receptek");
            List<Receptek> beolvasottReceptek = BeolvasasReceptek(osszesRecept);
            List<string> osszesKeszitok = Adatbazis.TableSelect("keszitok");
            List<Keszitok> beolvasottKeszitok = BeolvasasKeszitok(osszesKeszitok);
            /*Adatbazis.TableInsertKeszitok(); Insert a készítők táblába
            Adatbazis.TableInsertReceptek();    Insert a receptek táblába
            Adatbazis.TableInsertForrasokba(); Insert a források táblába*/
            KeszitoKereses(beolvasottKeszitok);


            void ReceptDarabszam()
            {
                Console.WriteLine("\nEnnyi recept van az adatbázisban: " + beolvasottReceptek.Count);
            }

            void ReceptValogatas()
            {
                Console.WriteLine("\nEzeknek az ételek 'gyors', azaz 35 percen belül elkészíthetők: ");
                int ossz = 0;
                foreach (Receptek item in beolvasottReceptek)
                {
                    if (item.OsszesIdo <= 35)
                    {
                        ossz++;
                        Console.WriteLine("- " + item.ReceptNev);
                    }
                }
                Console.WriteLine($"\t(Összesen: {ossz})");
            }

            void SzeretemAChilit()
            {
                //Meg kell keresni az összes olyan ételt, amely recept nevében szerepel a "chili" szó!
                Console.WriteLine("\nEzekben az ételek csípősek: ");
                var items = beolvasottReceptek.Where(item => item.ReceptNev.Contains("Chili"));
                var count = beolvasottReceptek.Count(item => item.ReceptNev.Contains("Chili"));
                foreach (var item in items)
                {
                    Console.WriteLine("-" + " " + item.ReceptNev);
                }
                Console.WriteLine($"\t(Összesen: {count})");
                Console.WriteLine(count > 3 ? "\tÚgy látszik, sok csípős ételünk van jelenleg" : "\tJelenleg nincs sok csípős ételünk");
            }

            ReceptDarabszam();
            ReceptValogatas();
            SzeretemAChilit();
            Console.ReadLine();
        }
        

        private static void KeszitoKereses(List<Keszitok> beolvasottKeszitok)
        {
            int osszesID = beolvasottKeszitok.Count;
            Console.WriteLine($"Adj meg egy azonosítot a készítőhöz, a következő intervallumba (1-{osszesID+1})!");
            bekeres:
            int keresettID = Convert.ToInt32(Console.ReadLine());
            if (keresettID <= 0 || keresettID < osszesID + 1)
            {
                Console.WriteLine($"Hibás adat! Adj meg egy azonosítot a készítőhöz, a következő intervallumba (1-{osszesID + 1})!");
                goto bekeres;
            }
            else { 
                string nev = KeszitoKereso(keresettID, out string cim, beolvasottKeszitok);
            }
        }

        private static string KeszitoKereso(int keresettID, out string cim, List<Keszitok> beolvasottKeszitok)
        {
            Console.WriteLine("Keressük a készítőt...");
            foreach (var keszito in beolvasottKeszitok)
            {
                if(keszito.id == keresettID)
                {
                    cim = keszito.lakcim;
                    return keszito.nev;
                }
            }
            cim = "Nincs lakhely";
            return "Helytelen ID!";
        }
        static List<Keszitok> BeolvasasKeszitok(List<string> keszitok)
        {
            List<Keszitok> osszesLocal = new List<Keszitok>();
            int szamlalo = 0;
            string sor = "";

            foreach (string keszito in keszitok)
            {
                szamlalo++;
                sor += keszito + ";";

                if (szamlalo == 4)
                {
                    int id = Convert.ToInt32(sor.Split(';')[0]);
                    string nev = sor.Split(';')[1];
                    string cim = sor.Split(';')[2];
                    int eletkor = Convert.ToInt32(sor.Split(';')[3]);

                    Keszitok egyKeszito = new Keszitok(id, nev, cim, eletkor);
                    osszesLocal.Add(egyKeszito);

                    sor = "";
                    szamlalo = 0;
                }
            }

            return osszesLocal;
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
