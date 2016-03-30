using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using FarsightDash.Common;

namespace FarsightDash
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            FarsightLogger.DefaultLogger = new FarsightLogger("FarsightDash.log");
            FarsightLogger.DefaultLogger.LogInfo("Farsight Dash starting up!");

            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                var exception = (Exception)args.ExceptionObject;
                FarsightLogger.DefaultLogger.LogFatal(exception.Message);

                Application.Current.Shutdown(-1);
            };

            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                FarsightLogger.DefaultLogger.LogWarning("Unable to find assembly: " + args.RequestingAssembly);
                return null;
            };

            AppDomain.CurrentDomain.AssemblyLoad += (sender, args) =>
            {
                FarsightLogger.DefaultLogger.LogInfo("Loading assembly: " + args.LoadedAssembly.FullName);
            };

            Bootstrapper.InitializeApplication();
        }
    }
}
