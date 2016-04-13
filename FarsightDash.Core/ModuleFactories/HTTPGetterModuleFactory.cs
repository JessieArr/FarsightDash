using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.BaseModules.DataEmitters;
using FarsightDash.BaseModules.ModuleSetupViews;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.ModuleFactories
{
    public class HTTPGetterModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return nameof(HTTPGetter); }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new HTTPGetterSetupView();
        }
    }
}
