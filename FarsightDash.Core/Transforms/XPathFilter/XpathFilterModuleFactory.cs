using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Transforms.XPathFilter
{
    public class XpathFilterModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return nameof(XpathFilter); }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new XpathFilterSetupView();
        }
    }
}
