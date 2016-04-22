using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Miscellaneous.CurrentTime
{
    public class CurrentTimeModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return "Current Time Emitter"; }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new CurrentTimeSetupView();
        }
    }
}
