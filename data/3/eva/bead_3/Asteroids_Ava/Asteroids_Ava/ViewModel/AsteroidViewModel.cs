using Asteroids_Model.ViewModel;
using Asteroids_Model.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Media;

namespace Asteroids_Model.ViewModel
{
    public class AsteroidViewModel : ViewModelBase
    {
        private readonly AsteroidGameModel _model;
        private int _gameTime;
        private double _spawnChance;
        private int _rows;
        private int _columns;
        private bool _isPaused;
        private string _pauseButtonText;

        public event EventHandler<string>? SaveRequested;
        public event EventHandler<string>? LoadRequested;
        public event EventHandler<int>? GameOverOccurred;

        public DelegateCommand PauseResumeGame { get; private set; }
        public DelegateCommand NewGame { get; private set; }
        public DelegateCommand SaveGame { get; private set; }
        public DelegateCommand LoadGame { get; private set; }

        public ObservableCollection<AsteroidsField> Cells { get; set; }

        public AsteroidViewModel()
        {
            _pauseButtonText = "Pause";
            _isPaused = false;

            _model = new AsteroidGameModel(new TimerModel());

            _model.CellChanged += Model_CellChanged;
            _model.GameTimeChanged += Model_GameTimeChanged;
            _model.SpawnChanceChanged += Model_SpawnChanceChanged;
            _model.GameOver += Model_GameOver;

            PauseResumeGame = new DelegateCommand(param => OnPauseResumeGame());
            NewGame = new DelegateCommand(param => OnNewGame());
            SaveGame = new DelegateCommand(param => IsPaused, param => OnSaveGame());
            LoadGame = new DelegateCommand(param => IsPaused, param => OnLoadGame());

            Cells = new ObservableCollection<AsteroidsField>();

            InitializeGrid(12, 12);

            _model.StartGame();
        }

        private void Model_CellChanged(object? sender, CellChangedEventArgs e)
        {
            UpdateCell(e.X, e.Y, e.State);
        }

        private void Model_GameTimeChanged(object? sender, EventArgs e)
        {
            GameTime = _model.GameTime;
        }

        private void Model_SpawnChanceChanged(object? sender, EventArgs e)
        {
            SpawnChance = _model.SpawnChance;
        }

        private void Model_GameOver(object? sender, GameOverEventArgs e)
        {
            IsPaused = true;
            GameOverOccurred?.Invoke(this, e.SurvivalTime);
        }

        public void MoveShipLeft()
        {
            _model.MoveShipLeft();
        }

        public void MoveShipRight()
        {
            _model.MoveShipRight();
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

        private IBrush GetBrushForState(CellState state)
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
                _model.StartGame();
                IsPaused = false;
            }
            else
            {
                _model.StopGame();
                IsPaused = true;
            }
        }

        private void OnNewGame()
        {
            _model.NewGame();
            IsPaused = false;
        }

        private void OnSaveGame()
        {
            if (!IsPaused) { return; }
            SaveRequested?.Invoke(this, string.Empty);
        }

        private void OnLoadGame()
        {
            if (!IsPaused) { return; }
            LoadRequested?.Invoke(this, string.Empty);
        }

        public async System.Threading.Tasks.Task SaveGameAsync(string filePath)
        {
            await _model.SaveGameAsync(filePath);
        }

        public async System.Threading.Tasks.Task LoadGameAsync(string filePath)
        {
            await _model.LoadGameAsync(filePath);
            _model.RefreshDisplay();
        }
    }
}