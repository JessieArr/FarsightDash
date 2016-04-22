using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Miscellaneous.Date
{
    public class DateModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return "Date"; }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new DateSetupView();
        }
    }
}
