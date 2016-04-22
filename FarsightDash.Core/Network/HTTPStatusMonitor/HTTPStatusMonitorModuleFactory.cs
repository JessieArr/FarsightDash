using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Network.HTTPStatusMonitor
{
    public class HTTPStatusMonitorModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return "HTTP Status Monitor"; }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new HTTPStatusMonitorSetupView();
        }
    }
}
