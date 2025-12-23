using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Model
{
    public class TimerModel : ITimer, IDisposable
    {
        private readonly System.Timers.Timer _timer;

        public bool Enabled { get; set; }
        public double Interval { get; set; }

        public event EventHandler? Elapsed;

        public TimerModel()
        {
            _timer = new System.Timers.Timer();
            _timer.Elapsed += (sender, e) =>
            {
                Elapsed?.Invoke(sender, e);
            };
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
