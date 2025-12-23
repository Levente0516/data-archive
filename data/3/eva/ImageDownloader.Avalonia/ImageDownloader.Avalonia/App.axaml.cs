using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;

using ImageDownloader.Avalonia.ViewModels;
using ImageDownloader.Avalonia.Views;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace ImageDownloader.Avalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var mainViewModel = new MainViewModel();
        mainViewModel.ErrorOccured += OnErrorOccured;
        // Line below is needed to remove Avalonia data validation.
        // Without this line you will get duplicate validations from both Avalonia and CT
        BindingPlugins.DataValidators.RemoveAt(0);

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private async void OnErrorOccured(object? sender, string e)
    {
        await MessageBoxManager.GetMessageBoxStandard("Cím", "Üzenet", ButtonEnum.Ok, Icon.Error).ShowAsync();
    }
}
