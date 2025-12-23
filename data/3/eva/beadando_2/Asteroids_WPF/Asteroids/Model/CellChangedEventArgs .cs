using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Model
{
    public class CellChangedEventArgs : EventArgs
    {
        public int X { get; }
        public int Y { get; }
        public CellState State { get; }

        public CellChangedEventArgs(int x, int y, CellState state)
        {
            X = x;
            Y = y;
            State = state;
        }
    }
}
