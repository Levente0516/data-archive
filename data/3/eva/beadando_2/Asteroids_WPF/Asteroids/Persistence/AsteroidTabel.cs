using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Persistence
{
    public class AsteroidTabel
    {
        private int _tabelHeight, _tabelWidth, _cellSize;
        
        public AsteroidTabel(int tabelHeight, int tabelWidth, int cellSize)
        {
            if (tabelHeight <= 0 || tabelWidth <=0 || cellSize <= 0)
            {
                throw new ArgumentOutOfRangeException("Invalid mesurments");
            }

            _tabelHeight = tabelHeight;
            _tabelWidth = tabelWidth;
            _cellSize = cellSize;
        }

        public AsteroidTabel() : this(12,12,6)
        {

        }

        public int GetTabelHeight
        {
            get { return _tabelHeight; }
        }
        public int GetTabelWidth
        {
            get { return _tabelWidth; }
        }
        public int GetCellSize
        {
            get { return _cellSize; }
        }

    }
}
