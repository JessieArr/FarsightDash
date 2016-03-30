﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.BaseModules.ModuleSetupViews;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.ModuleFactories
{
    public class ChromiumBrowserModuleFactory : IModuleFactory
    {
        public string ModuleTypeName
        {
            get { return "Chromium Browser"; }
        }

        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new ChromiumBrowserSetupView();
        }
    }
}
