using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Keszitok
    {
        private int Id;
        private string Nev;
        private string Lakcim;
        private int Eletkor;

        public int id { get => Id; set => Id = value; }
        public string nev { get => Nev; set => Nev = value; }
        public string lakcim { get => Lakcim; set => Lakcim = value; }
        public int eletkor { get => Eletkor; set => Eletkor = value; }

        public Keszitok(int id, string nev, string lakcim, int eletkor)
        {
            this.id = id;
            this.nev = nev;
            this.lakcim = lakcim;
            this.eletkor = eletkor;
        }

        public override string ToString()
        {
            return $"Készítő neve: {this.nev}";
        }
    }


}
