using Asteroids.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Model
{

    public enum CellState
    {
        Empty,
        Asteroid,
        Ship
    }

    public class AsteroidGameModel
    {
        private AsteroidTabel _tabel;
        private ITimer _timer;
        private List<IAsteroids> _asteroids;
        private IShip _ship  = null!;
        private int _gameTime;
        private double _spawnChance;
        private bool _isGameOver;

        public event EventHandler<CellChangedEventArgs>? CellChanged;
        public event EventHandler? GameTimeChanged;
        public event EventHandler? SpawnChanceChanged;
        public event EventHandler<GameOverEventArgs>? GameOver;

        public AsteroidGameModel(ITimer timer)
        {

            _asteroids = new List<IAsteroids>();
            _tabel = new AsteroidTabel();
            _gameTime = 0;
            _isGameOver = false;
            _timer = timer;
            _timer.Interval = 1000;
            _timer.Elapsed += new EventHandler(Timer_Elapsed);
            GenerateShip();
        }

        private void Timer_Elapsed(object? sender, EventArgs e)
        {
            if (_isGameOver)
            {
                _timer.Stop();
                return;
            }

            _gameTime++;
            GameTimeChanged?.Invoke(this, EventArgs.Empty);

            GenerateAsteroids();
            MoveAsteroids();
            CheckCollisions();
        }

        private void MoveAsteroids()
        {
            List<IAsteroids> asteroidsToRemove = new List<IAsteroids>();

            foreach (var asteroid in _asteroids)
            {
                CellChanged?.Invoke(this, new CellChangedEventArgs(asteroid.x, asteroid.y, CellState.Empty));

                asteroid.MoveDown();

                if (!asteroid.IsStillOnMap())
                {
                    asteroidsToRemove.Add(asteroid);
                }
                else
                {
                    CellChanged?.Invoke(this, new CellChangedEventArgs(asteroid.x, asteroid.y, CellState.Asteroid));
                }
            }

            foreach (var asteroid in asteroidsToRemove)
            {
                _asteroids.Remove(asteroid);
            }
        }

        private void CheckCollisions()
        {
            if (_isGameOver) return;

            foreach (var asteroid in _asteroids)
            {
                if (asteroid.IsCollided(_ship.x, _ship.y))
                {
                    _isGameOver = true;
                    StopGame();  

                    GameOver?.Invoke(this, new GameOverEventArgs(_gameTime));
                }
            }
        }

        private void GenerateAsteroids()
        {
            Random _rng = new Random();

            _spawnChance = Math.Min(0.5 + _gameTime / 5 * 0.01, 5.0);
            SpawnChanceChanged?.Invoke(this, EventArgs.Empty);

            if (_rng.NextDouble() < _spawnChance)
            {
                var newAsteroid = new AsteroidsModel(_rng.Next(0, _tabel.GetTabelWidth), -1);
                _asteroids.Add(newAsteroid);

                CellChanged?.Invoke(this, new CellChangedEventArgs(newAsteroid.x, newAsteroid.y, CellState.Asteroid));
            }

            if (_spawnChance > 1.0)
            {
                int n = (int)_spawnChance;
                for (int i = 0; i < n; i++)
                {
                    var newAsteroid = new AsteroidsModel(_rng.Next(0, _tabel.GetTabelWidth), -1);
                    _asteroids.Add(newAsteroid);

                    CellChanged?.Invoke(this, new CellChangedEventArgs(newAsteroid.x, newAsteroid.y, CellState.Asteroid));
                }
            }
        }

        private void GenerateShip()
        {
            _ship = new Ship(_tabel.GetTabelWidth / 2, _tabel.GetTabelHeight - 1);

            CellChanged?.Invoke(this, new CellChangedEventArgs(_ship.x, _ship.y, CellState.Ship));
        }

        public void MoveShipLeft()
        {
            if (!_timer.Enabled || _isGameOver) { return; }

            CellChanged?.Invoke(this, new CellChangedEventArgs(_ship.x, _ship.y, CellState.Empty));
            _ship.MoveLeft();
            CellChanged?.Invoke(this, new CellChangedEventArgs(_ship.x, _ship.y, CellState.Ship));

            CheckCollisions();
        }

        public void MoveShipRight()
        {
            if (!_timer.Enabled || _isGameOver) { return; }

            CellChanged?.Invoke(this, new CellChangedEventArgs(_ship.x, _ship.y, CellState.Empty));
            _ship.MoveRight();
            CellChanged?.Invoke(this, new CellChangedEventArgs(_ship.x, _ship.y, CellState.Ship));

            CheckCollisions();
        }

        public void RefreshDisplay()
        {
            CellChanged?.Invoke(this, new CellChangedEventArgs(_ship.x, _ship.y, CellState.Ship));

            foreach (var asteroid in _asteroids)
            {
                CellChanged?.Invoke(this, new CellChangedEventArgs(asteroid.x, asteroid.y, CellState.Asteroid));
            }
        }

        public void StopGame()
        {
            _timer.Stop();
        }

        public void StartGame()
        {
            _timer.Start();
        }

        public async Task SaveGameAsync(string filePath)
        {
            StopGame();

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write game state
                    await writer.WriteLineAsync($"GameTime:{_gameTime}");
                    await writer.WriteLineAsync($"SpawnChance:{_spawnChance}");

                    // Write ship position
                    await writer.WriteLineAsync($"ShipX:{_ship.x}");
                    await writer.WriteLineAsync($"ShipY:{_ship.y}");

                    // Write number of asteroids
                    await writer.WriteLineAsync($"AsteroidCount:{_asteroids.Count}");

                    // Write each asteroid position
                    foreach (var asteroid in _asteroids)
                    {
                        await writer.WriteLineAsync($"Asteroid:{asteroid.x},{asteroid.y}");
                    }
                }
            }
            finally
            {
            }
        }

        public async Task LoadGameAsync(string filePath)
        {
            StopGame();

            // Clear current game state
            _asteroids.Clear();
            _isGameOver = false; // Reset game over state

            // Clear all cells 
            for (int y = 0; y < _tabel.GetTabelHeight; y++)
            {
                for (int x = 0; x < _tabel.GetTabelWidth; x++)
                {
                    CellChanged?.Invoke(this, new CellChangedEventArgs(x, y, CellState.Empty));
                }
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    var parts = line.Split(':');
                    if (parts.Length != 2) continue;

                    string key = parts[0];
                    string value = parts[1];

                    switch (key)
                    {
                        case "GameTime":
                            _gameTime = int.Parse(value);
                            GameTimeChanged?.Invoke(this, EventArgs.Empty);
                            break;

                        case "SpawnChance":
                            _spawnChance = double.Parse(value);
                            SpawnChanceChanged?.Invoke(this, EventArgs.Empty);
                            break;

                        case "ShipX":
                            CellChanged?.Invoke(this, new CellChangedEventArgs(_ship.x, _ship.y, CellState.Empty));
                            _ship.x = int.Parse(value);
                            break;

                        case "ShipY":
                            _ship.y = int.Parse(value);
                            CellChanged?.Invoke(this, new CellChangedEventArgs(_ship.x, _ship.y, CellState.Ship));
                            break;

                        case "AsteroidCount":
                            break;

                        case "Asteroid":
                            var coords = value.Split(',');
                            int x = int.Parse(coords[0]);
                            int y = int.Parse(coords[1]);
                            var asteroid = new AsteroidsModel(x, y);
                            _asteroids.Add(asteroid);
                            CellChanged?.Invoke(this, new CellChangedEventArgs(x, y, CellState.Asteroid));
                            break;
                    }
                }
            }
        }

        public void NewGame()
        {
            _timer.Stop();
            _asteroids.Clear();
            _gameTime = 0;
            _spawnChance = 0;

            for (int y = 0; y < _tabel.GetTabelHeight; y++)
            {
                for (int x = 0; x < _tabel.GetTabelWidth; x++)
                {
                    CellChanged?.Invoke(this, new CellChangedEventArgs(x, y, CellState.Empty));
                }
            }

            GenerateShip();
            _timer.Start();
            _isGameOver = false; 
        }

        public int GameTime
        {
            get { return _gameTime; }
        }

        public double SpawnChance
        {
            get { return _spawnChance; }
        }
    }
}
