using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Eva_bead_Asteroids.Model
{
    public class AsteroidModel : IAsteroid
    {
        public int Y { get; set; }
        public int X { get; set; }

        public AsteroidModel(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void MoveDown()
        {
                Y++;
        }

        public bool IsCollided(int asteroidY, int shipY, int asteroidX, int shipX)
        {
            if (asteroidY == shipY && asteroidX == shipX)
            {
                return true;
            }

            return false;
        }

        public bool IsStillOnTheMap(int asteroidY, int tabely)
        {
            if (asteroidY < tabely)
            {
                return true;
            }

            return false;
        }
    }
}
