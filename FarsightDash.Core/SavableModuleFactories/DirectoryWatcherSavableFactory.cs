using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.BaseModules.Controls;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.SavableModuleFactories
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
