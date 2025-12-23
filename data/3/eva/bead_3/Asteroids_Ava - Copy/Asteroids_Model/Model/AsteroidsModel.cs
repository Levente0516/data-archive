using Asteroids_Model.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids_Model.Model
{
    public class AsteroidsModel : IAsteroids
    {
        public int x { get; set; }
        public int y { get; set; }

        private AsteroidTabel _tabel;

        public AsteroidsModel(int x, int y)
        {
            this.x = x;
            this.y = y;
            _tabel = new AsteroidTabel();
        }

        public bool IsStillOnMap()
        {
            if (y < _tabel.GetTabelHeight)
            {
                return true;
            }

            return false;
        }

        public bool IsCollided(int x, int y)
        {
            if (this.y == y && this.x == x)
            {
                return true;
            }

            return false;
        }

        public void MoveDown()
        {
            y++;
        }
    }
}
