using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.BaseModules.FileSystem.DirectoryWatcher;
using FarsightDash.BaseModules.FileSystem.FileTail;
using FarsightDash.BaseModules.LocalMachine.ProcessList;
using FarsightDash.BaseModules.Miscellaneous.Clock;
using FarsightDash.BaseModules.Miscellaneous.Conditional;
using FarsightDash.BaseModules.Miscellaneous.CurrentTime;
using FarsightDash.BaseModules.Miscellaneous.Date;
using FarsightDash.BaseModules.Network;
using FarsightDash.BaseModules.Network.ChromiumBrowser;
using FarsightDash.BaseModules.Network.HTTPGetter;
using FarsightDash.BaseModules.Network.HTTPStatusMonitor;
using FarsightDash.BaseModules.Network.Ping;
using FarsightDash.BaseModules.Network.WifiNetworks;
using FarsightDash.BaseModules.Transforms.RegexFilter;
using FarsightDash.BaseModules.Transforms.XPathFilter;
using FarsightDash.BaseModules.Views.Label;
using FarsightDash.BaseModules.Views.LineHighlight;
using FarsightDash.BaseModules.Views.RefreshImage;
using FarsightDash.BaseModules.Views.TextBox;

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
            registry.RegisterModuleFactory(new XpathFilterModuleFactory());
            registry.RegisterModuleFactory(new HTTPGetterModuleFactory());
            registry.RegisterModuleFactory(new TextBoxModuleFactory());
            registry.RegisterModuleFactory(new LineHighlightModuleFactory());
            registry.RegisterModuleFactory(new ProcessListModuleFactory());
            registry.RegisterModuleFactory(new WifiNetworksModuleFactory());
            registry.RegisterModuleFactory(new PingModuleFactory());
            registry.RegisterModuleFactory(new ConditionalModuleFactory());
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
            registry.RegisterSavableModuleFactory(new XpathFilterSavableFactory());
            registry.RegisterSavableModuleFactory(new HTTPGetterSavableFactory());
            registry.RegisterSavableModuleFactory(new TextBoxViewSavableFactory());
            registry.RegisterSavableModuleFactory(new LineHighlightSavableFactory());
            registry.RegisterSavableModuleFactory(new ProcessListSavableFactory());
            registry.RegisterSavableModuleFactory(new WifiNetworksSavableFactory());
            registry.RegisterSavableModuleFactory(new PingModuleSavableFactory());
            registry.RegisterSavableModuleFactory(new ConditionalSavableFactory());
        }
    }
}
