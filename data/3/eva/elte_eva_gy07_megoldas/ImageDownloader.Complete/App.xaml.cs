using ELTE.ImageDownloader.View;
using ELTE.ImageDownloader.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ELTE.ImageDownloader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainViewModel? _mainViewModel;
        private MainWindow? _mainWindow;

        public App()
        {
            Startup = OnStartup;
        }
    }
}
