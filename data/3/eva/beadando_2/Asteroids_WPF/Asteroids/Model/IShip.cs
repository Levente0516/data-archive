using Asteroids.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Model
{
    interface IShip
    {
        int x { get; set; }
        int y { get; set; }

        void MoveRight();
        void MoveLeft();
    }
}
