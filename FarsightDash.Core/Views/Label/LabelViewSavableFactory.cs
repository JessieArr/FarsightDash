using FarsightDash.Common.Saving;
using LabelView = FarsightDash.BaseModules.Views.Label.LabelView;

namespace FarsightDash.BaseModules.Views.Label
{
    public class LabelViewSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(LabelView); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            return new LabelView();
        }
    }
}
