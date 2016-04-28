using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.Miscellaneous.PopUp
{
    public class PopUpSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(PopUp); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            return new PopUp("Title", "Body", true);
        }
    }
}
