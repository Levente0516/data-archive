using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PingPongGame;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    public EventHandler<Thickness>? BallLayoutUpdated { get; set; }
    public EventHandler<Thickness>? PadLayoutUpdated { get; set; }



    public MainWindow()
    {
        InitializeComponent();

        Ball.LayoutUpdated += OnBallLayoutUpdated;
        Pad.LayoutUpdated += OnPadLayoutUpdated;
    }

    private void OnPadLayoutUpdated(object? sender, EventArgs e)
    {
        PadLayoutUpdated?.Invoke(this, Pad.Margin);
    }

    private void OnBallLayoutUpdated(object? sender, EventArgs e)
    {
        BallLayoutUpdated?.Invoke(this, Ball.Margin);
    }

    public void StartBallAnimation(Thickness nextPosition)
    {
        ThicknessAnimation animation = new ThicknessAnimation
        {
            From = Ball.Margin,
            To = nextPosition,
            Duration = new Duration(TimeSpan.FromMilliseconds(5)),
            SpeedRatio = 1 / TravelDistance(Ball.Margin, nextPosition)
            // Speed depends on the distance to travel
        };
        Ball.BeginAnimation(Ellipse.MarginProperty, animation,
        HandoffBehavior.SnapshotAndReplace);
    }

    public void StartPadAnimation(Thickness nextPosition)
    {
        ThicknessAnimation animation = new ThicknessAnimation
        {
            From = Pad.Margin,
            To = nextPosition,
            Duration = new Duration(TimeSpan.FromMilliseconds(100)),
        };
        Pad.BeginAnimation(Rectangle.MarginProperty, animation,
        HandoffBehavior.SnapshotAndReplace);

    }

    /// <summary>
    /// Calculate the distance between the current and new target position
    /// </summary>
    private static double TravelDistance(Thickness currentPosition, Thickness nextPosition)
    {
        return Math.Sqrt(Math.Pow(nextPosition.Left - currentPosition.Left, 2) +
                         Math.Pow(nextPosition.Top - currentPosition.Top, 2));
    }
}