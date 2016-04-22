using System;
using System.Timers;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.Miscellaneous.CurrentTime
{
    public class CurrentTimeDataEmitter : IDataEmitter, ISavableModule
    {
        public event EmitDataHandler EmitData;
        public void Initialize()
        {
            TryEmitData();
        }

        private int _IntervalInSeconds;
        private const int _MillisecondsPerSecond = 1000;
        private Timer _Timer;

        public CurrentTimeDataEmitter(int intervalInSeconds)
        {
            _IntervalInSeconds = intervalInSeconds;

            _Timer = new Timer(intervalInSeconds * _MillisecondsPerSecond);
            _Timer.Elapsed += (sender, args) =>
            {
                TryEmitData();
            };
            _Timer.Enabled = true;
        }

        private void TryEmitData()
        {
            if (EmitData != null)
            {
                EmitData(this, new EmitDataHandlerArgs(DateTime.Now.ToString()));
            }
        }

        public string ModuleName { get; set; }
        public string ModuleTypeName
        {
            get { return nameof(CurrentTimeDataEmitter); }
        }

        public string GetSaveString()
        {
            return _IntervalInSeconds.ToString();
        }
    }
}