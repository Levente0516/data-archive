using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eva_bead_Asteroids.Persistence
{
    public class AsteroidTabel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Cellsize { get; set; }

        public AsteroidTabel(int x, int y, int cellsize)
        {
            this.X = x;
            this.Y = y;
            this.Cellsize = cellsize;
        }

    }
}
