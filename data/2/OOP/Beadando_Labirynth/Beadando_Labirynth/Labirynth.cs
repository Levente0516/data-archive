using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_Labirynth
{
    public class Labirynth
    {
        public class NewError : Exception { };
        public class NoTresure : Exception { };
        public enum Content
        {
            EMPTY,
            WALL,
            GHOST,
            TREASURE
        }

        private int n;
        private int m;
        private Content[,] map;
        public class Direction
        {
            public int x;
            public int y;

            public Direction(int a, int b)
            {
                x = a;
                y = b;
            }
        }
        public Labirynth(Content[,] map) 
        {
            this.n = map.GetLength(0);
            this.m = map.GetLength(1);
            this.map = map;
        }
        public Content LookAt(int x, int y, Direction dir)
        {
            if (!((x + dir.x >= 0 & x + dir.x <= n) || (y + dir.y >= 0 & y + dir.y <= m))) throw new NewError();
            return this.map[x + dir.x, y + dir.y];
        }
        
        public void Collect(int x, int y)
        {
            if (this.map[x, y] != Content.TREASURE) throw new NoTresure();
            this.map[x,y] = Content.EMPTY;
        }

    }
}
