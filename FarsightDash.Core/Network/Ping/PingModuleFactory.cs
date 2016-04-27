using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Network.Ping
{
    public class PingModuleFactory : IModuleFactory
    {
        public string ModuleTypeName { get { return nameof(Ping); } }
        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new PingModuleSetupView();
        }
    }
}
