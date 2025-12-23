using System;

namespace Asteroids_Model.Model
{
    public class TimerModel : ITimer, IDisposable
    {
        private readonly System.Timers.Timer _timer;

        public bool Enabled
        {
            get => _timer.Enabled;
            set => _timer.Enabled = value;
        }

        public double Interval
        {
            get => _timer.Interval;
            set => _timer.Interval = value;
        }

        public event EventHandler? Elapsed;

        public TimerModel()
        {
            _timer = new System.Timers.Timer();
            _timer.Interval = 1000; // Default 1 second
            _timer.Elapsed += (sender, e) =>
            {
                Elapsed?.Invoke(sender, EventArgs.Empty);
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