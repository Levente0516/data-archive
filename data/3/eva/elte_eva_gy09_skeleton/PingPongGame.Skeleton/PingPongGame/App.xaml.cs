using PingPongGame.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace PingPongGame;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private MainWindow? _mainWindow;
    private MainViewModel? _mainViewModel;

    public App()
    {
        BallNextPosition += OnBallLayoutChanged;
    }

    private void OnBallLayoutChanged
}

