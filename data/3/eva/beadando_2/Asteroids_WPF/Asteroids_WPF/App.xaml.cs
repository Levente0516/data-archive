using Asteroids_WPF.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;
using Asteroids.Model;
using Asteroids.Persistence;
using Asteroids_WPF.View;

namespace Asteroids_WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private AsteroidViewModel _viewModel = null!;
    private AsteroidGameModel _model = null!;
    private MainWindow _view = null!;

    private AsteroidTabel _tabel = null!;
    public App()
    {
        Startup += new StartupEventHandler(App_Startup);
    }
    private void App_Startup(object? sender, StartupEventArgs e)
    {
        _model = new AsteroidGameModel(new TimerInheritance());
        _viewModel = new AsteroidViewModel();
        _tabel = new AsteroidTabel();

        _viewModel.InitializeGrid(_tabel.GetTabelHeight, _tabel.GetTabelWidth);

        _viewModel.Pause += (s, args) => _model.StopGame();
        _viewModel.Resume += (s, args) => _model.StartGame();
        _viewModel.New += (s, args) => _model.NewGame();
        _viewModel.Save += async (s, args) => await Model_SaveGameAsync();
        _viewModel.Load += async (s, args) => await Model_LoadGameAsync();

        _model.CellChanged += (s, args) => _viewModel.UpdateCell(args.X, args.Y, args.State);
        _model.GameTimeChanged += (s, args) => _viewModel.GameTime = _model.GameTime;
        _model.SpawnChanceChanged += (s, args) => _viewModel.SpawnChance = _model.SpawnChance;
        _model.GameOver += Model_GameOver;

        _model.RefreshDisplay();

        _view = new MainWindow();
        _view.DataContext = _viewModel;
        _view.KeyDown += (s, args) =>
        {
            if (args.Key == System.Windows.Input.Key.Left)
            {
                _model.MoveShipLeft();
            }
            else if (args.Key == System.Windows.Input.Key.Right)
            {
                _model.MoveShipRight();
            }
        };

        _view.Show();

        _model.StartGame();
    }

    private void Model_GameOver(object? sender, GameOverEventArgs e)
    {
        _model.StopGame();
        //_viewModel.IsPaused = true; 

        Dispatcher.BeginInvoke(new Action(() =>
        {
            MessageBox.Show(
                $"Game Over!\n\nYou survived for {e.SurvivalTime} seconds.",
                "Game Over",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }), System.Windows.Threading.DispatcherPriority.Normal);
    }

    private async Task Model_SaveGameAsync()
    {
        try
        {
            _model.StopGame();
            var dialog = new Microsoft.Win32.SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                DefaultExt = ".txt",
                FileName = "asteroids_save.txt"
            };

            if (dialog.ShowDialog() == true)
            {
                await _model.SaveGameAsync(dialog.FileName);
                MessageBox.Show("Game saved successfully!", "Save Game", MessageBoxButton.OK, MessageBoxImage.Information);

                _viewModel.IsPaused = false;
                _model.StartGame();
            }

            
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error saving game: {ex.Message}", "Save Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    private async Task Model_LoadGameAsync()
    {
        try
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                DefaultExt = ".txt"
            };

            if (dialog.ShowDialog() == true)
            {
                await _model.LoadGameAsync(dialog.FileName);
                _viewModel.GameTime = _model.GameTime;
                _viewModel.SpawnChance = _model.SpawnChance;
                MessageBox.Show("Game loaded successfully!", "Load Game", MessageBoxButton.OK, MessageBoxImage.Information);
                _viewModel.IsPaused = false;
                _model.StartGame();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading game: {ex.Message}", "Load Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}

