using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.LocalMachine.ProcessList
{
    public class ProcessListSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(ProcessList); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            return new ProcessList();
        }
    }
}
