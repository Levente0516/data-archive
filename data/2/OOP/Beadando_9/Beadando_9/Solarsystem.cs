using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_9
{
    public class Solarsystem
    {
        public List<Planet> planets;
        public Solarsystem()
        {
            planets = new List<Planet>();
        }

        public (bool,Starship) MaxFireP()
        {
            bool l = false;
            if (planets == null || planets.Count() == 0)
            {
                return (false, null);
            }

            (_,double max,Starship s) = planets[0].MaxFireP();

            foreach(var e in planets)
            {
                (bool y,double temp,Starship d) = e.MaxFireP();
                if (y && temp > max)
                {
                    max = temp;
                    s = d;
                    l = true;
                }
            }

            return (l, s);
        }

        public List<Planet> Defenseless()
        {
            List<Planet> s = new List<Planet>();
            if (planets != null)
            {
                foreach(var e in planets)
                {
                    if (e.ShipCount() == 0)
                    {
                        s.Add(e);
                    }
                }
            }

            return s;
        }
    }
}
