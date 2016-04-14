using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.BaseModules.ModuleSetupViews;
using FarsightDash.BaseModules.Transforms;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.ModuleFactories
{
    public class XpathFilterModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return nameof(XpathFilter); }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new XpathFilterSetupView();
        }
    }
}
