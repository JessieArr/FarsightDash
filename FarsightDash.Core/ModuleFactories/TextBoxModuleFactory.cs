using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.BaseModules.ModuleSetupViews;
using FarsightDash.BaseModules.Views;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.ModuleFactories
{
    public class TextBoxModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return nameof(TextBoxView); }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new TextBoxSetupView();
        }
    }
}
