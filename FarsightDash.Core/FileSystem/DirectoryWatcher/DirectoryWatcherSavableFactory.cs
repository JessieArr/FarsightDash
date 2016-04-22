using FarsightDash.Common.Saving;
using DirectoryWatcher = FarsightDash.BaseModules.FileSystem.DirectoryWatcher.DirectoryWatcher;

namespace FarsightDash.BaseModules.FileSystem.DirectoryWatcher
{
    public class DirectoryWatcherSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(DirectoryWatcher); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            return new DirectoryWatcher(savedString);
        }
    }
}
