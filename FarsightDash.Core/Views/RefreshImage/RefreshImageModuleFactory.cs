using FarsightDash.Common.Interfaces;
using RefreshImageSetupView = FarsightDash.BaseModules.Views.RefreshImage.RefreshImageSetupView;

namespace FarsightDash.BaseModules.Views.RefreshImage
{
    public class RefreshImageModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return "Refresh Image"; }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new RefreshImageSetupView();
        }
    }
}
