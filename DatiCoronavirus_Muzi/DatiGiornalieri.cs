using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatiCoronavirus_Muzi
{
    class DatiGiornalieri
    {
        public DateTime Data { get; set; }
        public int TotPositivi { get; set; }
        public int NuoviPositivi { get; set; }
        public int DimessiGuariti { get; set; }
        public int Deceduti { get; set; }
        public int TotCasi { get; set; }

        public override string ToString()
        {
            return $"{Data.ToShortDateString()}: positivi:{TotPositivi}, nuovi:{NuoviPositivi}, dimessi:{DimessiGuariti}, deceduti:{Deceduti}, casi totali:{TotCasi}";
        }
    }
}
