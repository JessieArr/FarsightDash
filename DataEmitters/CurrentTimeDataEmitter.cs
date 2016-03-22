using System;
using System.Timers;
using FarsightDash.FarsightComponents;

namespace FarsightDash.DataEmitters
{
    public class CurrentTimeDataEmitter : IDataEmitter
    {
        public event EmitDataHandler EmitData;

        private int _IntervalInSeconds;
        private const int _MillisecondsPerSecond = 1000;
        private Timer _Timer;

        public CurrentTimeDataEmitter(int intervalInSeconds)
        {
            _IntervalInSeconds = intervalInSeconds;

            _Timer = new Timer(intervalInSeconds * _MillisecondsPerSecond);
            _Timer.Elapsed += (sender, args) =>
            {
                EmitData(this, new EmitDataHandlerArgs(DateTime.Now.ToString()));
            };
            _Timer.Enabled = true;
        }
    }
}