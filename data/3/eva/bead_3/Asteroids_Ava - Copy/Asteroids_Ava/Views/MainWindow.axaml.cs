using Avalonia.Controls;
using Avalonia.Input;
using Asteroids_Model.ViewModel;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Threading;
using Avalonia;

namespace Asteroids_Ava.Views;

public partial class MainWindow : Window
{
    private Border? _gameBorder;

    public MainWindow()
    {
        InitializeComponent();

        this.AddHandler(KeyDownEvent, MainWindow_KeyDown, handledEventsToo: true);

        this.DataContextChanged += MainWindow_DataContextChanged;
        this.Opened += (s, e) =>
        {
            _gameBorder = this.FindControl<Border>("GameBorder");
            if (_gameBorder != null)
            {
                _gameBorder.Focus();
            }
        };
    }

    private void MainWindow_DataContextChanged(object? sender, EventArgs e)
    {
        if (DataContext is AsteroidViewModel viewModel)
        {
            viewModel.GameOverOccurred += ViewModel_GameOverOccurred;
            viewModel.SaveRequested += ViewModel_SaveRequested;
            viewModel.LoadRequested += ViewModel_LoadRequested;
        }
    }

    private async void ViewModel_SaveRequested(object? sender, string e)
    {
        if (DataContext is not AsteroidViewModel viewModel) return;

        var file = await StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
        {
            Title = "Save Game",
            DefaultExtension = "sav",
            SuggestedFileName = "asteroids_save",
            FileTypeChoices = new List<FilePickerFileType>
            {
                new("Asteroids Save File") { Patterns = new[] { "*.sav" } },
                new("All Files") { Patterns = new[] { "*" } }
            }
        });

        if (file != null)
        {
            try
            {
                await viewModel.SaveGameAsync(file.Path.LocalPath);
                await ShowMessageBox("Success", "Game saved successfully!");
            }
            catch (Exception ex)
            {
                await ShowMessageBox("Error", $"Failed to save game:\n{ex.Message}");
            }
        }
    }

    private async void ViewModel_LoadRequested(object? sender, string e)
    {
        if (DataContext is not AsteroidViewModel viewModel) return;

        var files = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Load Game",
            AllowMultiple = false,
            FileTypeFilter = new List<FilePickerFileType>
            {
                new("Asteroids Save File") { Patterns = new[] { "*.sav" } },
                new("All Files") { Patterns = new[] { "*" } }
            }
        });

        if (files != null && files.Count > 0)
        {
            try
            {
                await viewModel.LoadGameAsync(files[0].Path.LocalPath);
                await ShowMessageBox("Success", "Game loaded successfully!");
            }
            catch (Exception ex)
            {
                await ShowMessageBox("Error", $"Failed to load game:\n{ex.Message}");
            }
        }
    }

    private async System.Threading.Tasks.Task ShowMessageBox(string title, string message)
    {
        var messageBox = new Window
        {
            Title = title,
            Width = 350,
            Height = 150,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            CanResize = false
        };

        var stackPanel = new StackPanel
        {
            Margin = new Avalonia.Thickness(20),
            Spacing = 20
        };

        stackPanel.Children.Add(new TextBlock
        {
            Text = message,
            TextAlignment = Avalonia.Media.TextAlignment.Center,
            TextWrapping = Avalonia.Media.TextWrapping.Wrap,
            FontSize = 14
        });

        var okButton = new Button
        {
            Content = "OK",
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
            MinWidth = 80
        };
        okButton.Click += (s, e) => messageBox.Close();
        stackPanel.Children.Add(okButton);

        messageBox.Content = stackPanel;

        await messageBox.ShowDialog(this);
    }

    private async void ViewModel_GameOverOccurred(object? sender, int survivalTime)
    {
        await Dispatcher.UIThread.InvokeAsync(() =>
        {
            var messageBox = new Window
            {
                Title = "Game Over",
                Width = 300,
                Height = 150,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                CanResize = false
            };

            var stackPanel = new StackPanel
            {
                Margin = new Thickness(20),
                Spacing = 20
            };

            stackPanel.Children.Add(new TextBlock
            {
                Text = $"Game Over!\n\nYou survived for {survivalTime} seconds.",
                TextAlignment = Avalonia.Media.TextAlignment.Center,
                FontSize = 16
            });

            var okButton = new Button
            {
                Content = "OK",
                HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
                MinWidth = 80
            };

            okButton.Click += (_, __) => messageBox.Close();
            stackPanel.Children.Add(okButton);

            messageBox.Content = stackPanel;

            messageBox.ShowDialog(this);
        });
    }

    private void MainWindow_KeyDown(object? sender, KeyEventArgs e)
    {
        if (DataContext is AsteroidViewModel viewModel)
        {
            if (e.Key == Key.Left || e.Key == Key.A)
            {
                viewModel.MoveShipLeft();
                e.Handled = true;
            }
            else if (e.Key == Key.Right || e.Key == Key.D)
            {
                viewModel.MoveShipRight();
                e.Handled = true;
            }
        }
    }
}