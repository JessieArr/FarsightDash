using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.FileSystem.FileTail
{
    public class FileTailSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(FileTail); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            return new FileTail(savedString);
        }
    }
}
