using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.Write(item);
            }



            List<Receptek> BeolvasasReceptek(List<string> receptek)
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
                        Receptek.ReceptBeolvasas(sor);
                        sor = "";
                        szamlalo = 0;
                    }
                }

                foreach (Receptek recept in osszesLocal)
                {
                    Console.WriteLine(recept);
                }

                return osszesLocal;
            }
        }
    }
}
