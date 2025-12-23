using System;
using System.Reactive;
using Avalonia.Media.Imaging;
using ReactiveUI;

namespace ELTE.ImageDownloader.Avalonia.ViewModels;

public class ImageViewModel : ViewModelBase
{
    public Bitmap Image { get; private set; }

    public string AltText { get; private set; }

    private bool _isEnabled;

    public bool IsEnabled
    {
        get => _isEnabled;
        set => this.RaiseAndSetIfChanged(ref _isEnabled, value);
    }

    public ReactiveCommand<Unit, Unit> SaveImageCommand { get; private set; }
    public ReactiveCommand<Unit, Unit> CloseCommand { get; private set; }

    public event EventHandler<Bitmap>? SaveImage;

    public event EventHandler? Close;

    public ImageViewModel(Bitmap image, string altText)
    {
        Image = image;
        AltText = altText;
        _isEnabled = true;


        SaveImageCommand = ReactiveCommand.Create(() =>
        {
            SaveImage?.Invoke(this, Image);
        });

        CloseCommand = ReactiveCommand.Create(() =>
        {
            Close?.Invoke(this, EventArgs.Empty);
        });
    }
}