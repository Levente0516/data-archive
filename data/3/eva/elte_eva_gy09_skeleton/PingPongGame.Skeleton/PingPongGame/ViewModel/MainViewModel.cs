using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ELTE.PingPongGame.Model;

namespace PingPongGame.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        private PingPongModel? _model;
        private bool _isCollision;

        public Thickness BallStartPosition { get; private set; }
        public Thickness PadStartPosition { get; private set; }

        public Size GridSize { get; private set; }
        public Size BallSize { get; private set; }
        public Size PadSize { get; private set; }

        public bool IsCollision
        {
            get { return _isCollision; }
            set { _isCollision = value;}
        }
        public EventHandler<Thickness>? BallNextPosition;
        public EventHandler<Thickness>? PadNextPosition;

        public EventHandler? GameOver;

        public DelegateCommand? MovePadCommand { get; set; }
        public DelegateCommand? StartGameCommand { get; set; }
        public object OnBallMoveToNextPostition { get; }

        public MainViewModel()
        {
            GridSize = new Size(800, 400);
            BallSize = new Size(40, 40);
            PadSize = new Size(120, 10);

            BallStartPosition = new Thickness((GridSize.Width / 2) - (BallSize.Width /2),
                (GridSize.Height / 2) - (BallSize.Height / 2), 0, 0);

            PadStartPosition = new Thickness((GridSize.Width / 2) - (PadSize.Width / 2), 
                GridSize.Height - 100, 0, 0);

            _model = new PingPongModel(GridSize.Width, GridSize.Height, 
                new Element(BallStartPosition.Left, BallStartPosition.Top,
                BallSize.Height, BallSize.Width), 
                new Element(PadStartPosition.Left, PadStartPosition.Top, PadSize.Height, PadSize.Width));

            StartGameCommand = new DelegateCommand(_ => _model.StartGame());

            MovePadCommand = new DelegateCommand(param => { 
                if (param is string stringParam)
                {
                    Enum.TryParse(stringParam, out Direction direction);

                    _model.MovePadToDirection(direction);
                }
            });

            _model.PadMoveToNextPosition += OnPadMoveToNextPostition;
            _model.BallMoveToNextPosition += OnBallMoveToNextPosition;
            _model.GameOver += OnGameOver;
        }


        public void MoveBall(double left, double top)
        {
            _model?.MoveBall(left, top);
        }

        public void MovePad(double left, double top)
        {
            _model?.MovePad(left, top);
        }

        private void OnGameOver(object? sender, EventArgs e)
        {
            GameOver?.Invoke(this, EventArgs.Empty);
        }
        private void OnBallMoveToNextPosition(object? sender, NextPositionEventArgs e)
        {
            var thickness = new Thickness(e.Left, e.Top, 0, 0);
            BallNextPosition?.Invoke(this, thickness);
        }

        private void OnPadMoveToNextPostition(object? sender, NextPositionEventArgs e)
        {
            var thickness = new Thickness(e.Left, e.Top, 0, 0);
            PadNextPosition?.Invoke(this, thickness);
        }
    }
}
