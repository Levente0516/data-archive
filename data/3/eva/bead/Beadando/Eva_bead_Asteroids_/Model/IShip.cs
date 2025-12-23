using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eva_bead_Asteroids.Model
{
    public interface IShip
    {
        int X { get; set; }
        int Y { get; set; }
        int maxX { get; }
        int maxY { get; }
        event EventHandler? ArrayMoved;


        void MoveLeft();
        void MoveRight();
    }
}
