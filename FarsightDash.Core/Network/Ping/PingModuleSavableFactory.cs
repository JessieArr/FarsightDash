using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.Network.Ping
{
    public class PingModuleSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(Ping); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            return new Ping(savedString);
        }
    }
}
