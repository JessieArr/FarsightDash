using FarsightDash.Common.Interfaces;
using RegexFilterSetupView = FarsightDash.BaseModules.Transforms.RegexFilter.RegexFilterSetupView;

namespace FarsightDash.BaseModules.Miscellaneous.PopUp
{
    public class PopUpModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return nameof(PopUp); }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new PopUpSetupView();
        }
    }
}
