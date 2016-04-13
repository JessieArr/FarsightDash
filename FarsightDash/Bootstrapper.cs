using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.BaseModules.ModuleFactories;
using FarsightDash.BaseModules.SavableModuleFactories;

namespace FarsightDash
{
    public static class Bootstrapper
    {
        public static void InitializeApplication()
        {
            var registry = ModuleFactoryRegistry.DefaultRegistry;
            RegisterModuleFactories(registry);
            RegisterSavableModuleFactories(registry);
        }

        private static void RegisterModuleFactories(IModuleFactoryRegistry registry)
        {
            registry.RegisterModuleFactory(new ChromiumBrowserModuleFactory());
            registry.RegisterModuleFactory(new DirectoryWatcherModuleFactory());
            registry.RegisterModuleFactory(new FileTailModuleFactory());
            registry.RegisterModuleFactory(new RefreshImageModuleFactory());
            registry.RegisterModuleFactory(new HTTPStatusMonitorModuleFactory());
            registry.RegisterModuleFactory(new ClockModuleFactory());
            registry.RegisterModuleFactory(new DateModuleFactory());
            registry.RegisterModuleFactory(new CurrentTimeModuleFactory());
            registry.RegisterModuleFactory(new LabelModuleFactory());
            registry.RegisterModuleFactory(new RegexFilterModuleFactory());
            registry.RegisterModuleFactory(new HTTPGetterModuleFactory());
            registry.RegisterModuleFactory(new TextBoxModuleFactory());
        }

        private static void RegisterSavableModuleFactories(IModuleFactoryRegistry registry)
        {
            registry.RegisterSavableModuleFactory(new ChromiumBrowserSavableFactory());
            registry.RegisterSavableModuleFactory(new FileTailSavableFactory());
            registry.RegisterSavableModuleFactory(new DirectoryWatcherSavableFactory());
            registry.RegisterSavableModuleFactory(new HTTPStatusMonitorSavableFactory());
            registry.RegisterSavableModuleFactory(new RefreshImageSavableFactory());
            registry.RegisterSavableModuleFactory(new LabelViewSavableFactory());
            registry.RegisterSavableModuleFactory(new CurrentTimeEmitterSavableFactory());
            registry.RegisterSavableModuleFactory(new RegexFilterSavableFactory());
            registry.RegisterSavableModuleFactory(new HTTPGetterSavableFactory());
            registry.RegisterSavableModuleFactory(new TextBoxViewSavableFactory());
        }
    }
}
