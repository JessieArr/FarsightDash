using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.Transforms.RegexFilter
{
    public class RegexFilterSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(RegexFilter); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            return new RegexFilter(savedString);
        }
    }
}
