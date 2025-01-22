using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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

        public static List<Receptek> ReceptBeolvasas(string sor)
        {
            List<Receptek> osszesRecept = new List<Receptek>();

            int id = Convert.ToInt32(sor.Split(';')[0]);
            string receptNev = sor.Split(';')[1];
            string hozzavalok = sor.Split(';')[2];
            string leiras = sor.Split(';')[3];
            int elokeszitesiIdo = Convert.ToInt32(sor.Split(';')[4]);
            int fozesiIdo = Convert.ToInt32(sor.Split(';')[5]);
            int osszesIdo = Convert.ToInt32(sor.Split(';')[6]);
            int keszitoId = Convert.ToInt32(sor.Split(';')[7]);
            int forrasId = Convert.ToInt32(sor.Split(';')[8]);

            Receptek recept = new Receptek(id, receptNev, hozzavalok, leiras, elokeszitesiIdo, fozesiIdo, osszesIdo, keszitoId, forrasId);
            Console.Write(recept.receptNev);
            osszesRecept.Add(recept);
            return osszesRecept;
        }

        public override string ToString()
        {
            return $"Recept neve: {receptNev}";
        }


    }
}
