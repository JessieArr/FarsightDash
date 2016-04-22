using FarsightDash.Common.Interfaces;
using TextBoxSetupView = FarsightDash.BaseModules.Views.TextBox.TextBoxSetupView;
using TextBoxView = FarsightDash.BaseModules.Views.TextBox.TextBoxView;

namespace FarsightDash.BaseModules.Views.TextBox
{
    public class TextBoxModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return nameof(TextBoxView); }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new TextBoxSetupView();
        }
    }
}
