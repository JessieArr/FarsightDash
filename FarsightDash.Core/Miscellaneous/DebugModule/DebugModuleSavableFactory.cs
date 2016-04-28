using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.Miscellaneous.DebugModule
{
    public class DebugModuleSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(DebugModule); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            return new DebugModule(savedString);
        }
    }
}
