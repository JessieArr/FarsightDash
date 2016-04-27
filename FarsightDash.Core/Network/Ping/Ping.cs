using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.Network.Ping
{
    public class Ping : IDataEmitter, ISavableModule
    {
        public string ModuleName { get; set; }
        public string ModuleTypeName { get { return nameof(Ping); } }

        private int _IntervalInSeconds;
        private Timer _Timer;
        private string _URL;

        public Ping(string url)
        {
            _URL = url;
            _IntervalInSeconds = 1;
            var millisecondsPerSecond = 1000;

            _Timer = new Timer(_IntervalInSeconds * millisecondsPerSecond);
            _Timer.Elapsed += (sender, args) =>
            {
                EmitFreshData();
            };
            _Timer.Enabled = true;
        }

        public string GetSaveString()
        {
            return _URL;
        }

        private void EmitFreshData()
        {
            if (EmitData != null)
            {
                try
                {
                    var ping = new System.Net.NetworkInformation.Ping();
                    var pingResult = ping.Send(_URL);
                    var outString = $"Ping: {pingResult.Address} {pingResult.RoundtripTime}";

                    EmitData(this, new EmitDataHandlerArgs(outString));
                }
                catch (Exception ex)
                {
                    EmitData(this, new EmitDataHandlerArgs("ERROR: " + ex.Message));
                }
            }
        }

        public event EmitDataHandler EmitData;
        public void Initialize()
        {
            EmitFreshData();
        }
    }
}
