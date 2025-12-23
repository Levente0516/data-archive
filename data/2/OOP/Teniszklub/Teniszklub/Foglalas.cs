using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teniszklub
{
    public class Foglalas
    {
        public Palya palya;
        public Tag tag;
        public DateTime date;
        public int ido;
        public Foglalas(Palya palya, Tag tag, DateTime date, int ido)
        {
            this.palya = palya;
            this.tag = tag;
            this.date = date;
            this.ido = ido;
        }
    }
}
