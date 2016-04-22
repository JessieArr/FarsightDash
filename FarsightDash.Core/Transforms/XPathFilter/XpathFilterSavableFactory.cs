using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.Transforms.XPathFilter
{
    public class XpathFilterSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(XpathFilter); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            return new XpathFilter(savedString);
        }
    }
}
