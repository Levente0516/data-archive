using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Model
{
    public class GameOverEventArgs : EventArgs
    {
        public int SurvivalTime { get; }

        public GameOverEventArgs(int survivalTime)
        {
            SurvivalTime = survivalTime;
        }
    }
}
