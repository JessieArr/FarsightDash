using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.FileSystem.DirectoryWatcher
{
    public class DirectoryWatcherModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return "Directory Watcher"; }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new DirectoryWatcherSetupView();
        }
    }
}
