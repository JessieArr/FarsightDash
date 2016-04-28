using FarsightDash.Common.Interfaces;
using RegexFilterSetupView = FarsightDash.BaseModules.Transforms.RegexFilter.RegexFilterSetupView;

namespace FarsightDash.BaseModules.Miscellaneous.DebugModule
{
    public class DebugModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return nameof(DebugModule); }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new DebugModuleSetupView();
        }
    }
}
