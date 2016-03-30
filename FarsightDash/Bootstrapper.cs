using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.BaseModules.ModuleFactories;

namespace FarsightDash
{
    public static class Bootstrapper
    {
        public static void InitializeApplication()
        {
            var registry = ModuleFactoryRegistry.DefaultRegistry;
            registry.RegisterModuleFactory(new ChromiumBrowserModuleFactory());
            registry.RegisterModuleFactory(new DirectoryWatcherModuleFactory());
        }
    }
}
