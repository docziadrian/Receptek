using Mysqlx.Crud;
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
            Adatbazis.KapcsolodasAdatbazishoz();
            List<string> osszesKeszitok = Adatbazis.TableSelect("keszitok");
            List<Keszitok> beolvasottKeszitok = BeolvasasKeszitok(osszesKeszitok);
            
            int menupont = 999;
            while (menupont != 0)
            {
                Console.WriteLine();
                Console.WriteLine("Add meg, hogy mit szeretnél csinálni!\n\t 0 - Kilépés az applikációból!\n\t 1 - Adj hozzá adatot a készítők táblához! \n\t 2 - Adj hozzá adatot a források táblához! \n\t 3 - Adj hozzá adatot a receptek táblához! \n\t 4 - Megadjuk az eddig tárolt receptek darabszámát! \n\t 5 - Megadjuk az összes 35 percen belüli receptet! \n\t 6 - Megkeresi az összes olyan ételt ami tartalmazza a \"chili\" szót! \n\t 7 - Megkeresi az általad beadott azonosítón található séfet! \n\t 8 - Bekéri a készítő IDjét, majd ez alapján visszaadja a legelső receptet!");
                menupont = Convert.ToInt32(Console.ReadLine());
                switch (menupont)
                {
                    case(1):
                        Adatbazis.TableInsertKeszitok(); 
                        break;
                    case(2):
                        Adatbazis.TableInsertReceptek();
                        break;
                    case(3):
                        Adatbazis.TableInsertForrasokba();
                        break;
                    case(4):
                        ReceptDarabszam();
                        break;
                    case(5):
                        ReceptValogatas();
                        break;
                    case(6):
                        SzeretemAChilit();
                        break;
                    case(7):
                        KeszitoKereses(beolvasottKeszitok);
                        break;
                    case(8):
                        RefFeladat(beolvasottReceptek, beolvasottKeszitok);
                        break;
                    default:
                        menupont = 0;
                        Console.WriteLine("Kiléptetünk a programból!");
                        break;

                }
            }


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

            
            
            
            Console.ReadLine();
        }

        private static void RefFeladat(List<Receptek> beolvasottReceptek, List<Keszitok> beolvasottKeszitok)
        {
            Console.WriteLine("Adj meg a készítő ID-jét!");
            int keresettID = Convert.ToInt32(Console.ReadLine());
            ReceptKereso(beolvasottReceptek, beolvasottKeszitok, ref keresettID);
            Console.WriteLine($"{beolvasottReceptek[keresettID].ToString()}");

        }

        private static void ReceptKereso(List<Receptek> beolvasottReceptek, List<Keszitok> beolvasottKeszitok, ref int keresettID)
        {
            foreach (var recept in beolvasottReceptek)
            {
                keresettID = (recept.Keszito_id == keresettID) ? recept.Id : keresettID;
                
            }
        }

        private static void KeszitoKereses(List<Keszitok> beolvasottKeszitok)
        {
            int osszesID = beolvasottKeszitok.Count;
            Console.WriteLine($"Adj meg egy azonosítot a készítőhöz, a következő intervallumba (1-{osszesID})!");
            bekeres:
            int keresettID = Convert.ToInt32(Console.ReadLine());
            if (keresettID <= 0 || keresettID > osszesID + 1)
            {
                Console.WriteLine($"Hibás adat! Adj meg egy azonosítot a készítőhöz, a következő intervallumba (1-{osszesID + 1})!");
                goto bekeres;
            }
            else { 
                string nev = KeszitoKereso(keresettID, out string cim, beolvasottKeszitok);
                Console.WriteLine($"A keresett készítő neve: {nev} | és a lakhelye: {cim}");
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
