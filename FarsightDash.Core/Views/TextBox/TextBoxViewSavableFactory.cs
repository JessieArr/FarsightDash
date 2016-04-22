using FarsightDash.Common.Saving;
using TextBoxView = FarsightDash.BaseModules.Views.TextBox.TextBoxView;

namespace FarsightDash.BaseModules.Views.TextBox
{
    public class TextBoxViewSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(TextBoxView); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            return new TextBoxView();
        }
    }
}
