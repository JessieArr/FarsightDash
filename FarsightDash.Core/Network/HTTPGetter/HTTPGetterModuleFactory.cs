using FarsightDash.Common.Interfaces;
using HTTPGetterSetupView = FarsightDash.BaseModules.Network.HTTPGetter.HTTPGetterSetupView;

namespace FarsightDash.BaseModules.Network.HTTPGetter
{
    public class HTTPGetterModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return nameof(HTTPGetter); }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new HTTPGetterSetupView();
        }
    }
}
