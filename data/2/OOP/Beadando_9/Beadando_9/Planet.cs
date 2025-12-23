using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_9
{
    public class Planet
    {
        public class AlreadyIn : Exception { };
        public class NotIn : Exception { };

        public string name;
        private List<Starship> ships;

        public Planet(string name)
        {
            this.name = name;
            ships = new List<Starship>();
        }

        public void Defends(Starship s)
        {
            if (ships.Contains(s))
            {
                throw new AlreadyIn();
            }
            ships.Add(s);
        }

        public void Leaves(Starship s)
        {
            if (!ships.Contains(s))
            {
                throw new NotIn();
            }
            else
            {
                ships.Remove(s);
            }
        }

        public int ShipCount()
        {
            return ships.Count;
        }

        public int ShieldSum()
        {
            int osszeg = 0;
            foreach(var e in ships)
            {
                osszeg += e.GetShield();
            }

            return osszeg;
        }

        public (bool,double,Starship) MaxFireP()
        {
            if (ships.Count == 0)
            {
                return (false, 0, null);
            }
            Starship s = ships[0];
            double max = s.FireP();
            foreach(var e in ships)
            {
                if (e.FireP() > max)
                {
                    s = e;
                    max = e.FireP();
                }
            }

            return (true, max, s);
        }
    }
}
