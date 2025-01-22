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
            get { return id; }
            set
            {
                if (value >= 0 && value <= 9999)
                {
                    id = value;
                }
            }
        }

        public string ReceptNev
        {
            get { return receptNev; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length > 1)
                {
                    receptNev = value;
                }
            }
        }

        public string Hozzavalok
        {
            get { return hozzavalok; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length > 1)
                {
                    hozzavalok = value;
                }
            }
        }

        public string Leiras
        {
            get { return leiras; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length > 1)
                {
                    leiras = value;
                }
            }
        }

        public int ElokeszitesiIdo
        {
            get { return elokeszitesiIdo; }
            set
            {
                if (value >= 0 && value <= 9999)
                {
                    elokeszitesiIdo = value;
                }
            }
        }

        public int FozesiIdo
        {
            get { return fozesiIdo; }
            set
            {
                if (value >= 0 && value <= 9999)
                {
                    fozesiIdo = value;
                }
            }
        }

        public int OsszesIdo
        {
            get { return osszesIdo; }
            set
            {
                if (value >= 0 && value <= 9999)
                {
                    osszesIdo = value;
                }
            }
        }

        public int Keszito_id
        {
            get { return keszito_id; }
            set
            {
                if (value >= 0 && value <= 9999)
                {
                    keszito_id = value;
                }
            }
        }

        public int Forras_id
        {
            get { return forras_id; }
            set
            {
                if (value >= 0 && value <= 9999)
                {
                    forras_id = value;
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

        public override string ToString()
        {
            return $"Recept neve: {ReceptNev}, \n Hozzávalók: {Hozzavalok}";
        }
    }
}
