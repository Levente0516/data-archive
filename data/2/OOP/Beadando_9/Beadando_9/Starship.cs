using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_9
{
    public class Starship
    {
        public class AlreadyLeaved : Exception { };

        private string name;
        public readonly int shield;
        public readonly int armor;
        public readonly int guardian;
        private Planet planet;

        public Starship(string name, int shield, int armor, int guardian)
        {
            this.name = name;
            this.shield = shield;
            this.armor = armor;
            this.guardian = guardian;
        }

        public int GetShield()
        {
            return shield;
        }

        public void StaysAtPlanet(Planet p)
        {
            if (planet != null)
            {
                planet.Leaves(this);
            }

            planet = p;
            planet.Defends(this);
        }

        public void LeavesPlanet()
        {
            if (planet == null)
            {
                throw new AlreadyLeaved();
            }
            planet.Leaves(this);
            planet = null;
        }

        public virtual double FireP()
        {
            throw new NotImplementedException();
        }
    }

    class Wallbreaker : Starship
    {
        public Wallbreaker(string name, int shield, int armor, int guardian) : base(name, shield, armor, guardian) { }
        public override double FireP()
        {
            return armor / 2;
        }
    }

    class Landingship : Starship
    {
        public Landingship(string name, int shield, int armor, int guardian) : base(name, shield, armor, guardian) { }
        public override double FireP()
        {
            return guardian;
        }
    }

    class Lasership : Starship
    {
        public Lasership(string name, int shield, int armor, int guardian) : base(name, shield, armor, guardian) { }
        public override double FireP()
        {
            return shield;    
        }
    }
}
