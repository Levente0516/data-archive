using Asteroids.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Asteroids_WPF.ViewModel
{
    public class AsteroidsField : ViewModelBase
    {
        private Brush _cellColor = Brushes.White;

        public int X { get; set; }
        public int Y { get; set; }

        public Brush CellColor
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
