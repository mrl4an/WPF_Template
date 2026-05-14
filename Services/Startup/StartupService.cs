using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_Template.Core.Orchestrator;
using WPF_Template.Services.Configuration;
using WPF_Template.Services.Lifecycle;
using WPF_Template.ViewModel;

namespace WPF_Template.Services.Startup
{
    public class StartupService : IStartupService
    {
        public async void Run()
        {
            //1 Core
            ISystemOrchestrator orchestrator = new SystemOrchestrator();
            IConfigService configService = new ConfigService();

            //2 Lifecycle
            ILifecycleService lifecycleService = new LifecycleService(orchestrator, configService);

            //3 Load config
            await configService.LoadAsync();

            //4 MVVM
            var settingsViewModel = new SettingsViewModel(orchestrator, configService);
            //4.1 View
            var mainWindow = new MainWindow();
            mainWindow.DataContext = settingsViewModel;
            //4.2 Calculate geometry window
            mainWindow.WindowStartupLocation = WindowStartupLocation.Manual;

            mainWindow.Width = configService.Current.WindowWidth;
            mainWindow.Height = configService.Current.WindowHeight;

            mainWindow.Top = configService.Current.WindowTop;
            mainWindow.Left = configService.Current.WindowLeft;

            if (configService.Current.IsMaximized)
            {
                mainWindow.WindowState = WindowState.Maximized;
            }

            //Close windiw service
            mainWindow.Closing += lifecycleService.OnWindowClosing;

            // Start programm
            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
        }
    }
}
