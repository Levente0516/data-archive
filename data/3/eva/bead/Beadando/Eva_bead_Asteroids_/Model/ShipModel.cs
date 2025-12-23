using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Eva_bead_Asteroids_;

namespace Eva_bead_Asteroids.Model
{
    public class ShipModel : IShip
    {
        public int X { get; set; }
        public int maxX { get; set; }
        public int Y { get; set; }
        public int maxY { get; set; }

        public event EventHandler? ArrayMoved;
        public event EventHandler? Clearing;

        public ShipModel(int x, int y, int maxx, int maxy)
        {
            this.X = x;
            this.Y = y;
            this.maxX = maxx;
            this.maxY= maxy;
        }
        public void MoveLeft()
        {
            Clearing?.Invoke(this, EventArgs.Empty);
            if (X > 0)
            {
                X--;
            }
            ArrayMoved?.Invoke(this, EventArgs.Empty);
        }

        public void MoveRight()
        {
            Clearing?.Invoke(this, EventArgs.Empty);
            if (X < maxX - 1)
            {
                X++;
            }
            ArrayMoved?.Invoke(this, EventArgs.Empty);      
        }
    }
}
