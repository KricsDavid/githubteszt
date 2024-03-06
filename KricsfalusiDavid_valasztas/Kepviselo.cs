using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KricsfalusiDavid_valasztas
{
    internal class Kepviselo
    {
        public int Valasztokerulet { get; set; }
        public int Szavazatok { get; set; }
        public string Vezeteknev { get; set; }
        public string Utonev { get; set; }
        public string Part { get; set; }

        public Kepviselo(int valasztokerulet, int szavazatok, string vezeteknev, string utonev, string part)
        {
            Valasztokerulet = valasztokerulet;
            Szavazatok = szavazatok;
            Vezeteknev = vezeteknev;
            Utonev = utonev;
            Part = part;
        }
    }
}
