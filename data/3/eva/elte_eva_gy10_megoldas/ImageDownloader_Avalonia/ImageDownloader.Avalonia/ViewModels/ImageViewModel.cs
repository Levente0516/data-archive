using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELTE.ImageDownloader.Avalonia.ViewModels
{
    public class ImageViewModel
    {
        public Bitmap Image { get; private set; }
        public event EventHandler<Bitmap> SaveImage;
        public DelegateCommand SaveImageCommand { get; private set; }

        public event EventHandler? Close;
        public DelegateCommand CloseCommand { get; private set; }

        public ImageViewModel(Bitmap _image)
        {
            Image = _image;

            SaveImageCommand = new DelegateCommand(_ =>
            {
                SaveImage?.Invoke(this, Image);
            });

            CloseCommand = new DelegateCommand(_ =>
            {
                Close?.Invoke(this, EventArgs.Empty);
            });
        }
    }
}
