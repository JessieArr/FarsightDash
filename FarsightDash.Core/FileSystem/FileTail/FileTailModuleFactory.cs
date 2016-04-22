using FarsightDash.Common.Interfaces;
using FileTailSetupView = FarsightDash.BaseModules.FileSystem.FileTail.FileTailSetupView;

namespace FarsightDash.BaseModules.FileSystem.FileTail
{
    public class FileTailModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return "File Tail"; }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new FileTailSetupView();
        }
    }
}
