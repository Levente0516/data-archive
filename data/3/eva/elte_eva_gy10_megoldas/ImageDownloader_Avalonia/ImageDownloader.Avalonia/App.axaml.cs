using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using ELTE.ImageDownloader.Avalonia.ViewModels;
using ELTE.ImageDownloader.Avalonia.Views;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using System;

namespace ELTE.ImageDownloader.Avalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var mainViewModel = new MainViewModel();

        mainViewModel.ImageSelected += OnImageSelected;

        mainViewModel.ErrorOccured += OnErrorOccured;

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Line below is needed to remove Avalonia data validation.
            // Without this line you will get duplicate validations from both Avalonia and CT
            BindingPlugins.DataValidators.RemoveAt(0);
            desktop.MainWindow = new MainWindow
            {
                DataContext = mainViewModel
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = mainViewModel
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void OnImageSelected(object? sender, Bitmap e)
    {
        ImageViewModel viewModel = new ImageViewModel(e);
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime)
        {
            
        }
        if (ApplicationLifetime is ISingleViewApplicationLifetime)
        {

        }
    }

    private async void OnErrorOccured(object? sender, string e)
    {
        await MessageBoxManager.GetMessageBoxStandard("Image Downloader", e, ButtonEnum.Ok, Icon.Error).ShowAsync();
    }

    private TopLevel? TopLevel
    {
        get
        {
            return ApplicationLifetime switch
            {
                IClassicDesktopStyleApplicationLifetime desktop =>
                TopLevel.GetTopLevel(desktop.MainWindow),
                ISingleViewApplicationLifetime singleViewPlatform =>
                TopLevel.GetTopLevel(singleViewPlatform.MainView),
                _ => null
            };
        }
    }
}