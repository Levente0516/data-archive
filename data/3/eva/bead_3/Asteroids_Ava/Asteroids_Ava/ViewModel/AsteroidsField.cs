using Asteroids_Model.ViewModel;
using Avalonia.Media;

namespace Asteroids_Model.ViewModel
{
    public class AsteroidsField : ViewModelBase
    {
        private IBrush _cellColor = Brushes.White;

        public int X { get; set; }
        public int Y { get; set; }

        public IBrush CellColor
        {
            get { return _cellColor; }
            set
            {
                if (_cellColor != value)
                {
                    _cellColor = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}