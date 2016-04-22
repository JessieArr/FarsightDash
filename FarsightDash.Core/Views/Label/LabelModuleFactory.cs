using FarsightDash.Common.Interfaces;
using LabelSetupView = FarsightDash.BaseModules.Views.Label.LabelSetupView;

namespace FarsightDash.BaseModules.Views.Label
{
    public class LabelModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return "Label"; }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new LabelSetupView();
        }
    }
}
