using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.Network.WifiNetworks
{
    public class WifiNetworksSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(WifiNetworks); } }

        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            return new WifiNetworks();
        }
    }
}
