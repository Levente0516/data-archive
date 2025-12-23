using Avalonia.Media.Imaging;
using ImageDownloader.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
//using System.Windows.Media.Imaging;

namespace ImageDownloader.Avalonia.ViewModels
{
    public class MainViewModel : ViewModelBase, IDisposable
    {
        private WebPage? _model;
        private bool _isDownloading;
        private float _progress;
        private static readonly List<string> _supportedExtensions = new List<string>() { ".jpg", ".png", ".jpeg", ".gif" };

        public bool IsDownloading
        {
            get => _isDownloading;
            private set
            {
                _isDownloading = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(DownloadButtonLabel));
            }
        }

        public string DownloadButtonLabel
        {
            get => _isDownloading ? "Letöltés megszakítása" : "Képek betöltése";
        }

        public float Progress
        {
            get => _progress;
            private set
            {
                _progress = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Bitmap> Images { get; set; }

        public DelegateCommand DownloadCommand { get; set; }
        public DelegateCommand ImageSelectedCommand { get; set; }

        public event EventHandler<Bitmap>? ImageSelected;
        public event EventHandler<string> ErrorOccured;

        public MainViewModel()
        {
            Images = new ObservableCollection<Bitmap>();

            DownloadCommand = new DelegateCommand(async param =>
            {
                if (!_isDownloading)
                {
                    await LoadAsync(new Uri(param?.ToString() ?? string.Empty));
                }
                else
                {
                    CancelLoad();
                }
            });

            ImageSelectedCommand = new DelegateCommand(param =>
            {
                if (param is Bitmap bitmap)
                    ImageSelected?.Invoke(this, bitmap);
            });
        }

        public void Dispose()
        {
            _model?.Dispose();
            _model = null;
        }

        public async Task LoadAsync(Uri url)
        {
            IsDownloading = true;
            Images.Clear();

            _model = new WebPage(url);
            _model.ImageLoaded += OnImageLoaded;
            _model.LoadProgress += OnLoadProgress;

            try
            {
                await _model.LoadImagesAsync();

            }
            catch (Exception exp)
            {
                ErrorOccured?.Invoke(this, exp.Message);
            }

            IsDownloading = false;
        }

        private void OnImageLoaded(object? sender, WebImage e)
        {
            if (!_supportedExtensions.Contains(Path.GetExtension(e.Url.LocalPath))) { return; }

            var bitmapImage = new Bitmap(new MemoryStream(e.Data));

            Images.Add(bitmapImage);
        }

        private void OnLoadProgress(object? sender, int e)
        {
            Progress = e;
        }

        private void CancelLoad()
        {
            if (IsDownloading)
            {
                _model?.CancelLoad();
            }
        }
    }
}
