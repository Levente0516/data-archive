using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teniszklub
{
    public class Palya
    {
        public int sorszam;
        public Enums.Palya_tipus tipus;
        public bool fedett;
        public bool foglalt;

        public Palya(int sorszam, Enums.Palya_tipus tipus, bool fedett, bool foglalt) 
        {
            this.sorszam = sorszam;
            this.tipus = tipus;
            this.fedett = fedett;
            this.foglalt = foglalt;
        }
    }
}
