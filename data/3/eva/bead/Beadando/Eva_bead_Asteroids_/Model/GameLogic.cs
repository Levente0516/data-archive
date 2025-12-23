using Eva_bead_Asteroids.Persistence;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Eva_bead_Asteroids.Model
{
    public class GameLogic : IDisposable
    {
        private List<IAsteroid> asteroids = new List<IAsteroid>();
        private Random rng = new Random();
        private ShipModel? ship;
        private AsteroidTabel? tabel;
        private System.Timers.Timer timer;

        private int seconds = 0;
        private double spawnChance = 0;

        public event EventHandler? GameOver;

        public event Action<int, int>? ColorGray;
        public event Action<int, int>? ColorWhite;



        public GameLogic(AsteroidTabel tabel, ShipModel ship)
        {
            this.tabel = tabel;
            this.ship = ship;

            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Game_Tick;
            timer.Start();
        }

        public void Dispose()
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Elapsed -= Game_Tick;
                timer.Dispose();
                timer = null!;
            }
        }

        private void Game_Tick(object? sender, EventArgs e)
        {
            seconds++;
            GameLoop();
        }

        public void SpawnAsteroids()
        {
            spawnChance = Math.Min(0.5 + seconds / 5 * 0.01, 5.0);

            if (rng.NextDouble() < spawnChance)
            {
                asteroids.Add(new AsteroidModel(rng.Next(0, tabel!.X), -1));
            }

            if (spawnChance > 1.0) 
            { int n = 1 + 1 * (int)spawnChance; 
                for (int i = 0; i < n; i++) 
                { 
                    int col = rng.Next(0, tabel!.X);
                    asteroids.Add(new AsteroidModel(rng.Next(0, tabel.X), -1));
                } 
            }
        }

        public void Update_Ship(int x, int y)
        {
            ship!.X = x;
            ship!.Y = y;
        }

        public void GameLoop()
        {
            SpawnAsteroids();

            for (int i = asteroids.Count - 1; i >= 0; i--)
            {
                var a = asteroids[i];

                a.MoveDown();


                if (a.Y >= 1 && a.Y < tabel!.Y)
                {
                    ColorWhite?.Invoke(a.Y, a.X);
                }

                if (a.Y >= 0 && a.Y < tabel!.Y)
                {
                    ColorGray?.Invoke(a.Y, a.X);
                }

                if (a.IsCollided(a.Y, ship!.Y, a.X, ship.X))
                {
                    timer.Stop();
                    GameOver?.Invoke(this, EventArgs.Empty);
                }

                if (!a.IsStillOnTheMap(a.Y, tabel!.Y))
                {
                    asteroids.RemoveAt(i);
                    ColorWhite?.Invoke(a.Y,a.X);
                }
            }
        }

        public double GetSpawnChance()
        {
            return spawnChance;
        }

        public string GetFormattedTime()
        {
            var ts = TimeSpan.FromSeconds(seconds);
            return ts.ToString(@"hh\:mm\:ss");
        }

        public void emptyList()
        {
            asteroids.Clear();
        }

        public void ResetTime()
        {
            seconds = 0;
        }

        public int GetTime()
        {
            return seconds;
        }

        public List<IAsteroid> GetAsteroids()
        {
            return new List<IAsteroid>(asteroids);

        }

        public void Pause_Game()
        {
            timer.Stop();
        }

        public void Start_Game()
        {
            timer.Start();
        }

        public void Set_Time(int t)
        {
            seconds = t;
        }

        public void Set_Asteroids(List<IAsteroid> newAsteroids)
        {
            emptyList();
            asteroids.AddRange(newAsteroids);
        }
    }
}
