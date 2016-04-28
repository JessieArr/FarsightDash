using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.Miscellaneous.Conditional
{
    public class ConditionalSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(Conditional); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            return new Conditional(savedString);
        }
    }
}
