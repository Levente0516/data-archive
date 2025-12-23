using Asteroids.Model;
using Asteroids.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace Asteroids_WPF.ViewModel
{
    public class AsteroidViewModel : ViewModelBase
    {
        private int _gameTime;
        private double _spawnChance;
        private int _rows;
        private int _columns;
        private bool _isPaused;
        private string _pauseButtonText;

        public event EventHandler? Pause;
        public event EventHandler? Resume;
        public event EventHandler? New;
        public event EventHandler? Save;
        public event EventHandler? Load;

        public DelegateCommand PauseResumeGame { get; private set; }
        public DelegateCommand NewGame { get; private set; }
        public DelegateCommand SaveGame { get; private set; }
        public DelegateCommand LoadGame { get; private set; }

        public ObservableCollection<AsteroidsField> Cells { get; set; }
        public AsteroidViewModel()
        {
            _pauseButtonText = "Pause";
            _isPaused = false;

            PauseResumeGame = new DelegateCommand(param => OnPauseResumeGame());
            NewGame = new DelegateCommand(param => OnNewGame());
            SaveGame = new DelegateCommand(param => OnSaveGame());
            LoadGame = new DelegateCommand(param => OnLoadGame());

            Cells = new ObservableCollection<AsteroidsField>();
        }

        public bool IsPaused
        {
            get { return _isPaused; }
            set
            {
                if (_isPaused != value)
                {
                    _isPaused = value;
                    OnPropertyChanged();

                    PauseButtonText = _isPaused ? "Resume" : "Pause";

                    SaveGame.RaiseCanExecuteChanged();
                    LoadGame.RaiseCanExecuteChanged();
                }
            }
        }

        public string PauseButtonText
        {
            get { return _pauseButtonText; }
            set
            {
                if (_pauseButtonText != value)
                {
                    _pauseButtonText = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Rows
        {
            get { return _rows; }
            set
            {
                if (_rows != value)
                {
                    _rows = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Columns
        {
            get { return _columns; }
            set
            {
                if (_columns != value)
                {
                    _columns = value;
                    OnPropertyChanged();
                }
            }
        }

        public int GameTime
        {
            get { return _gameTime; }
            set
            {
                if (_gameTime != value)
                {
                    _gameTime = value;
                    OnPropertyChanged();
                }
            }
        }

        public double SpawnChance
        {
            get { return _spawnChance; }
            set
            {
                _spawnChance = value;
                OnPropertyChanged();
                
            }
        }

        public void InitializeGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Cells.Clear();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Cells.Add(new AsteroidsField
                    {
                        X = col,
                        Y = row,
                        CellColor = Brushes.White
                    });
                }
            }
        }

        public void UpdateCell(int x, int y, CellState state)
        {
            var cell = Cells.FirstOrDefault(c => c.X == x && c.Y == y);
            if (cell != null)
            {
                cell.CellColor = GetBrushForState(state);
            }
        }

        private Brush GetBrushForState(CellState state)
        {
            return state switch
            {
                CellState.Empty => Brushes.White,
                CellState.Asteroid => Brushes.Gray,
                CellState.Ship => Brushes.Blue,
                _ => Brushes.White
            };
        }

        private void OnPauseResumeGame()
        {
            if (IsPaused)
            {
                Resume?.Invoke(this, EventArgs.Empty);
                IsPaused = false;
            }
            else
            {
                Pause?.Invoke(this, EventArgs.Empty);
                IsPaused = true;
            }
        }

        private void OnNewGame()
        {
            IsPaused = false; 
            New?.Invoke(this, EventArgs.Empty);
        }

        private void OnSaveGame()
        {
            if (!IsPaused) { return; }
            Save?.Invoke(this, EventArgs.Empty);
        }

        private void OnLoadGame()
        {
            if (!IsPaused) { return; }
            Load?.Invoke(this, EventArgs.Empty);
        }
    }
}
