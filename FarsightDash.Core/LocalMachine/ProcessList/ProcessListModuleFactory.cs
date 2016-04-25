using FarsightDash.Common.Interfaces;
using FileTailSetupView = FarsightDash.BaseModules.FileSystem.FileTail.FileTailSetupView;

namespace FarsightDash.BaseModules.LocalMachine.ProcessList
{
    public class ProcessListModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return nameof(ProcessList); }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new ProcessListSetupView();
        }
    }
}
