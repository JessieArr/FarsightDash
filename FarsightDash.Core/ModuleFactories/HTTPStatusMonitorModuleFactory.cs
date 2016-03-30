using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.BaseModules.ModuleSetupViews;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.ModuleFactories
{
    public class HTTPStatusMonitorModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return "HTTP Status Monitor"; }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new HTTPStatusMonitorSetupView();
        }
    }
}
