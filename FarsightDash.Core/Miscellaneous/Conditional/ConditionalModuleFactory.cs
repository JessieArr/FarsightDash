using FarsightDash.Common.Interfaces;
using RegexFilterSetupView = FarsightDash.BaseModules.Transforms.RegexFilter.RegexFilterSetupView;

namespace FarsightDash.BaseModules.Miscellaneous.Conditional
{
    public class ConditionalModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return nameof(Conditional); }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new ConditionalSetupView();
        }
    }
}
