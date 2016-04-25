using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;
using FarsightDash.Common.Saving;
using NativeWifi;

namespace FarsightDash.BaseModules.Network.WifiNetworks
{
    public class WifiNetworks : IDataEmitter, ISavableModule
    {
        public string ModuleName { get; set; }
        public string ModuleTypeName {get { return nameof(WifiNetworks);} }

        private WlanClient _WlanClient;
        private int _IntervalInSeconds;
        private Timer _Timer;

        public WifiNetworks()
        {
            _WlanClient = new WlanClient();

            _IntervalInSeconds = 5;
            var millisecondsPerSecond = 1000;

            _Timer = new Timer(_IntervalInSeconds * millisecondsPerSecond);
            _Timer.Elapsed += (sender, args) =>
            {
                EmitNetworks();
            };
            _Timer.Enabled = true;
        }

        public string GetSaveString()
        {
            return "";
        }

        private void EmitNetworks()
        {
            var wlanInterfaces = _WlanClient.Interfaces;
            foreach (var wlanInterface in wlanInterfaces)
            {
                wlanInterface.Scan();
                var outString = "";

                var networks = wlanInterface.GetAvailableNetworkList(
                    Wlan.WlanGetAvailableNetworkFlags.IncludeAllAdhocProfiles);
                var sortedNetworks = networks.OrderBy(x => GetStringForSSID(x.dot11Ssid));
                foreach (var network in sortedNetworks)
                {
                    outString += $"SSID: {GetStringForSSID(network.dot11Ssid)}, Signal Strength: {network.wlanSignalQuality}{Environment.NewLine}";
                }

                if (EmitData != null)
                {
                    EmitData(this, new EmitDataHandlerArgs(outString));
                }
            }
        }

        private string GetStringForSSID(Wlan.Dot11Ssid ssid)
        {
            return Encoding.ASCII.GetString(ssid.SSID, 0, (int) ssid.SSIDLength);
        }

        public event EmitDataHandler EmitData;
        public void Initialize()
        {
            EmitNetworks();
        }
    }
}
