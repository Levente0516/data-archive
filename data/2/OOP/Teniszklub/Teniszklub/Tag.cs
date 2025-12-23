using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teniszklub
{
    public class Tag
    {
        public string name;
        public Enums.Jatekos_tipus tipus;

        public Tag(string name, Enums.Jatekos_tipus tipus) 
        {
            this.name = name;
            this.tipus = tipus;
        }

        public void Palya_foglalas(Teniszklub klub, Palya palya, DateTime date, int ido)
        {
            klub.foglalas_palya(palya, this, date, ido);
        }

        public void Palya_lemondas(Teniszklub klub, Palya palya, DateTime date, int ido, DateTime currdate)
        {
            klub.lemondas(palya, this, date, ido, currdate);
        }
    }
}
