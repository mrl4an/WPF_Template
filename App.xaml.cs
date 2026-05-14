using System.Configuration;
using System.Data;
using System.Windows;
using WPF_Template.Services.Startup;

namespace WPF_Template
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            IStartupService startupService = new StartupService();

            startupService.Run();
        }
    }

}
