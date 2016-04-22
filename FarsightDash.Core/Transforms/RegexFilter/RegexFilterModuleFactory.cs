using FarsightDash.Common.Interfaces;
using RegexFilterSetupView = FarsightDash.BaseModules.Transforms.RegexFilter.RegexFilterSetupView;

namespace FarsightDash.BaseModules.Transforms.RegexFilter
{
    public class RegexFilterModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return "Regex Filter"; }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new RegexFilterSetupView();
        }
    }
}
