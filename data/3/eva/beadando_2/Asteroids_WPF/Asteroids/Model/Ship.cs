using Asteroids.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Model
{
    public class Ship : IShip
    {
        public int x { get; set; }
        public int y { get; set; }

        private AsteroidTabel _tabel;

        public Ship(int x, int y)
        {
            _tabel = new AsteroidTabel();

            this.x = x;
            this.y = y;
        }

        public void MoveLeft()
        {
            if (x > 0)
            {
                x--;
            }
        }

        public void MoveRight()
        {
            if (x < _tabel.GetTabelWidth - 1)
            {
                x++;
            }
        }
    }
}
