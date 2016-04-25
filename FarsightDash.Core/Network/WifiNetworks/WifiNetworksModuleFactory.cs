using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Network.WifiNetworks
{
    public class WifiNetworksModuleFactory : IModuleFactory
    {
        public string ModuleTypeName { get { return nameof(WifiNetworks); } }
        public IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry)
        {
            return new WifiNetworksSetupView();
        }
    }

    
}
