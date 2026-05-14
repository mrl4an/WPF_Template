using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_Template.Core.Orchestrator;
using WPF_Template.Services.Configuration;

namespace WPF_Template.Services.Lifecycle
{
    public class LifecycleService : ILifecycleService
    {
        private readonly ISystemOrchestrator _orchestrator;
        private readonly IConfigService _configService;
        private bool _isShuttingDown = false;
        private bool _canCloseNow = false;

        public LifecycleService(ISystemOrchestrator orchestrator, IConfigService configService)
        {
            _orchestrator = orchestrator;
            _configService = configService;
        }

        public async void OnWindowClosing(object? sender, CancelEventArgs e)
        {
            if (sender is not Window window) return;

            if (_canCloseNow) return;

            e.Cancel = true;
            _isShuttingDown = true;

            _configService.Current.WindowWidth = window.ActualWidth;
            _configService.Current.WindowHeight = window.ActualHeight;
            _configService.Current.WindowTop = window.Top;
            _configService.Current.WindowLeft = window.Left;
            _configService.Current.IsMaximized = window.WindowState == WindowState.Maximized;

            _orchestrator.QueueTask(async () => await _configService.SaveAsync());

            if (_orchestrator is SystemOrchestrator systemOrch)
            {
                await systemOrch.WaitForCompletionAsync();
            }

            _canCloseNow = true;

            window.Close();
        }

        public void Shutdown()
        {
            Application.Current.MainWindow?.Close();
        }
    }
}
