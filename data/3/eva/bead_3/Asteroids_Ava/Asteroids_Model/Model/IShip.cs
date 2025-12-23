using Asteroids_Model.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids_Model.Model
{
    interface IShip
    {
        int x { get; set; }
        int y { get; set; }

        void MoveRight();
        void MoveLeft();
    }
}
