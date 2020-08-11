using log4net;
using log4net.Config;
using System.IO;
using System.Reflection;
using System.Windows;

namespace CivModTool
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var repository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
            base.OnStartup(e);
        }
    }
}