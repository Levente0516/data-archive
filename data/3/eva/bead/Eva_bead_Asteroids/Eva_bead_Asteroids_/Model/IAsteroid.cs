using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eva_bead_Asteroids.Model
{
    public interface IAsteroid
    {
        int X { get; set; }
        int Y { get; set; }

        void MoveDown();
        bool IsCollided(int asteroidY, int shipY, int asteroidX, int shipX);
        bool IsStillOnTheMap(int asteroidY, int tabelY);
    }
}
