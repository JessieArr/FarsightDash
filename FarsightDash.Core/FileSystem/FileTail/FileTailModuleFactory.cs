using FarsightDash.Common.Interfaces;
using FileTailSetupView = FarsightDash.BaseModules.FileSystem.FileTail.FileTailSetupView;

namespace FarsightDash.BaseModules.FileSystem.FileTail
{
    public class FileTailModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return nameof(FileTail); }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new FileTailSetupView();
        }
    }
}
