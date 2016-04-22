using FarsightDash.Common.Interfaces;
using ClockSetupView = FarsightDash.BaseModules.Miscellaneous.Clock.ClockSetupView;

namespace FarsightDash.BaseModules.Miscellaneous.Clock
{
    public class ClockModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return "Clock"; }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new ClockSetupView();
        }
    }
}
