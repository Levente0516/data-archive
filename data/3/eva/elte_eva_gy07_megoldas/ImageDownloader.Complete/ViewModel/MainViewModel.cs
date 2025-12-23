using ELTE.ImageDownloader.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ELTE.ImageDownloader.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private float _progress;
        private bool _isDownloading;
        private WebPage _model;

        public float Progress
        {
            get => _progress;
            private set
            {
                _progress = value;
                OnPropertyChanged();
            }
        }

        public bool IsDownloading
        {
            get => _isDownloading;
            private set
            {
                _isDownloading = value;
                OnPropertyChanged();
                DownloadCommand.RaiseCanExecuteChanged();
            }
        }

        public ObservableCollection<BitmapImage> Images { get; set; }
        
        public DelegateCommand DownloadCommand { get; set; }

        public MainViewModel()
        {
            Images = new ObservableCollection<BitmapImage>();
            DownloadCommand = new DelegateCommand(async param => 
            {
                await LoadAsync(new Uri(param.ToString()));
            });
        }

        private async Task LoadAsync(Uri uri)
        {
            IsDownloading = true;
            Images.Clear();

            _model = new WebPage(uri);

            _model.ImageLoaded += OnImageLoaded;
            _model.LoadProgress += OnLoadProgress;

            await _model.LoadImagesAsync();

            IsDownloading = false;
        }

        private void OnLoadProgress(object? sender, int e)
        {
            Progress = e;
        }

        private void OnImageLoaded(object? sender, WebImage e)
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.StreamSource = new MemoryStream(e.Data);
            bitmap.EndInit();

            Images.Add(bitmap);
        }
    }
}
