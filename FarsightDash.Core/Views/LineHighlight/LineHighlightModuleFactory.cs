using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Views.LineHighlight
{
    public class LineHighlightModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return nameof(LineHighlight); }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new LineHighlightSetupView();
        }
    }
}
