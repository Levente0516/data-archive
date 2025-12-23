using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids_Model.Model
{
    public interface IAsteroids
    {
        int x { get; set; }
        int y { get; set; }

        bool IsStillOnMap();
        bool IsCollided(int x, int y);
        void MoveDown();
    }
}
