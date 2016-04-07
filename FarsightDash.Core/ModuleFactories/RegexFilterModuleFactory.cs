using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.BaseModules.ModuleSetupViews;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.ModuleFactories
{
    public class RegexFilterModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return "Regex Filter"; }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new RegexFilterSetupView();
        }
    }
}
