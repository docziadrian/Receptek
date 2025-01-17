using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Receptek
    {
        private int id;
        private string receptNev;
        private string hozzavalok;
        private string leiras;
        private int elokeszitesiIdo;
        private int fozesiIdo;
        private int osszesIdo;
        private int keszito_id;
        private int forras_id;

        

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if(this.id >= 0 && this.id <= 9999)
                {
                    this.id = value;
                }
                
            }
        }

        public string ReceptNev
        {
            get
            {
                return this.receptNev;
            }
            set
            {
                if (this.receptNev != null && this.receptNev.Length > 1)
                {
                    this.receptNev = value;
                }

            }
        }

        public string Hozzavalok
        {
            get
            {
                return this.hozzavalok;
            }
            set
            {
                if (this.hozzavalok != null && this.hozzavalok.Length > 1)
                {
                    this.hozzavalok = value;
                }

            }
        }
        public string Leiras
        {
            get
            {
                return this.leiras;
            }
            set
            {
                if (this.leiras != null && this.leiras.Length > 1)
                {
                    this.leiras = value;
                }

            }
        }
        public int ElokeszitesiIdo
        {
            get
            {
                return this.elokeszitesiIdo;
            }
            set
            {
                if (this.elokeszitesiIdo >= 0 && this.elokeszitesiIdo <= 9999)
                {
                    this.elokeszitesiIdo = value;
                }

            }
        }
        public int FozesiIdo
        {
            get
            {
                return this.fozesiIdo;
            }
            set
            {
                if (this.fozesiIdo >= 0 && this.fozesiIdo <= 9999)
                {
                    this.fozesiIdo = value;
                }

            }
        }
        public int OsszesIdo
        {
            get
            {
                return this.osszesIdo;
            }
            set
            {
                if (this.osszesIdo >= 0 && this.osszesIdo <= 9999)
                {
                    this.osszesIdo = value;
                }

            }
        }
        public int Keszito_id
        {
            get
            {
                return this.keszito_id;
            }
            set
            {
                if (this.keszito_id >= 0 && this.keszito_id <= 9999)
                {
                    this.keszito_id = value;
                }

            }
        }
        public int Forras_id
        {
            get
            {
                return this.forras_id;
            }
            set
            {
                if (this.forras_id >= 0 && this.forras_id <= 9999)
                {
                    this.forras_id = value;
                }

            }
        }


        public Receptek(int id, string receptNev, string hozzavalok, string leiras, int elokeszitesiIdo, int fozesiIdo, int osszesIdo, int keszito_id, int forras_id)
        {
            Id = id;
            ReceptNev = receptNev;
            Hozzavalok = hozzavalok;
            Leiras = leiras;
            ElokeszitesiIdo = elokeszitesiIdo;
            FozesiIdo = fozesiIdo;
            OsszesIdo = osszesIdo;
            Keszito_id = keszito_id;
            Forras_id = forras_id;
        }

        public static void ReceptBeolvasas(string sor)
        {
            var id = sor.Split(';')[0];
            Console.WriteLine(id);
            
        }

        public override string ToString()
        {
            return $"Recept neve: {receptNev}";
        }


    }
}
