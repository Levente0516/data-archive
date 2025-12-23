using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using ELTE.ImageDownloader.Model;
using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace ELTE.ImageDownloader.Avalonia.ViewModels;

public partial class MainViewModel : ViewModelBase, IDisposable
{
    private WebPage? _model;
    private static readonly List<string> SupportedExtensions = [".jpg", ".jpeg", ".png", ".gif"];

    private bool _isDownloading;

    public bool IsDownloading
    {
        get => _isDownloading;
        set
        {
            this.RaiseAndSetIfChanged(ref _isDownloading, value);
            this.RaisePropertyChanged(nameof(DownloadButtonLabel));
        }
    }

    [Reactive]
    private float _progress;

    [Reactive]
    private string _searchContent = "";

    private IObservable<string> _searchContentObservable;

    public string DownloadButtonLabel => IsDownloading ? "Letöltés megszakítása" : "Képek betöltése";

    public ObservableCollection<ImageViewModel> Images { get; set; }

    public ReactiveCommand<string, Unit> DownloadCommand { get; private set; }

    public event EventHandler<Bitmap>? ImageSelected;
    public event EventHandler<string>? ErrorOccured;

    private async Task Download(string param)
    {
        if (!IsDownloading)
        {
            await LoadAsync(new Uri(param));
        }
        else
        {
            _model?.CancelLoad();
        }
    }

    [ReactiveCommand]
    private void ImageSelect(Bitmap param)
    {
        ImageSelected?.Invoke(this, param);
    }

    public MainViewModel()
    {
        Images = new ObservableCollection<ImageViewModel>();

        DownloadCommand = ReactiveCommand.CreateFromTask<string, Unit>(async param =>
        {
            await Download(param);
            return Unit.Default;
        }, Observable.Return(true));

        _searchContentObservable = this
            .WhenAnyValue<MainViewModel, string>(x => x.SearchContent)
            .Throttle(TimeSpan.FromSeconds(0.5))
            .Select(query => query.Trim())
            .DistinctUntilChanged()
            .ObserveOn(RxApp.MainThreadScheduler);
    }

    public void Dispose()
    {
        _model?.Dispose();
        _model = null;
    }

    private async Task LoadAsync(Uri url)
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
        catch (HttpRequestException e)
        {
            ErrorOccured?.Invoke(this, e.Message);
        }

        IsDownloading = false;
    }

    private void OnLoadProgress(object? sender, int e)
    {
        Progress = e;
    }

    private void OnImageLoaded(object? sender, WebImage webImage)
    {
        if (!IsSupportedExtension(webImage.Url.LocalPath))
            return;

        var bitmap = new Bitmap(new MemoryStream(webImage.Data));
        var imageViewModel = new ImageViewModel(bitmap, webImage.AltText);
        _searchContentObservable
            .Select(s => imageViewModel.AltText.Contains(s) || s == string.Empty)
            .Subscribe(s => imageViewModel.IsEnabled = s);

        Images.Add(imageViewModel);
    }

    private bool IsSupportedExtension(string path)
    {
        return SupportedExtensions.Contains(Path.GetExtension(path));
    }
}