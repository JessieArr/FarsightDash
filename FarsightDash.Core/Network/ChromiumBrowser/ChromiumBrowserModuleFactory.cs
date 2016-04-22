using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Network.ChromiumBrowser
{
    public class ChromiumBrowserModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return "Chromium Browser"; }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new ChromiumBrowserSetupView();
        }
    }
}
