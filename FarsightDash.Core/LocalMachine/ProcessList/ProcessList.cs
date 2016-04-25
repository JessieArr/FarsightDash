using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.LocalMachine.ProcessList
{
    public class ProcessList : IDataEmitter, ISavableModule
    {
        public string ModuleName { get; set; }
        public string ModuleTypeName { get { return nameof(ProcessList); } }
        public string GetSaveString()
        {
            return "";
        }

        private int _IntervalInSeconds;
        private Timer _Timer;

        public ProcessList()
        {
            _IntervalInSeconds = 5;
            var millisecondsPerSecond = 1000;

            _Timer = new Timer(_IntervalInSeconds * millisecondsPerSecond);
            _Timer.Elapsed += (sender, args) =>
            {
                EmitProcessData();
            };
            _Timer.Enabled = true;
        }

        private void EmitProcessData()
        {
            var processes = Process.GetProcesses();
            var sortedProcesses = processes.OrderBy(x => x.ProcessName);
            var outString = "";
            foreach (var process in sortedProcesses)
            {
                outString += $"{process.ProcessName}, {GetSizeSuffix(process.WorkingSet64)}, {process.Threads.Count} Threads{Environment.NewLine}";
            }

            if (EmitData != null)
            {
                EmitData(this, new EmitDataHandlerArgs(outString));
            }
        }

        static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        static string GetSizeSuffix(Int64 value)
        {
            if (value < 0) { return "-" + GetSizeSuffix(-value); }
            if (value == 0) { return "0.0 bytes"; }

            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            return string.Format("{0:n1} {1}", adjustedSize, SizeSuffixes[mag]);
        }

        public event EmitDataHandler EmitData;

        public void Initialize()
        {
            EmitProcessData();
        }
    }
}
