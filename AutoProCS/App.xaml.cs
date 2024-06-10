using AutoProCS.IO.Devices;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace AutoProCS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider Services { get; private set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var serviceColection = new ServiceCollection();

            serviceColection.AddSingleton<IDeviceManager, DeviceManager>();

            Services = serviceColection.BuildServiceProvider();
        }

        [STAThread]
        public static void Main()
        {
            var application = new App();
            application.InitializeComponent();
            application.Run();
        }
    }

}
