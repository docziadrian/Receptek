using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Forrasok
    {
        private int Id;
        private string Nev;

        public int id { get => Id; set => Id = value; }
        public string nev { get => Nev; set => Nev = value; }

        public Forrasok(int id, string nev)
        {
            this.id = id;
            this.nev = nev;
        }
    }
}
