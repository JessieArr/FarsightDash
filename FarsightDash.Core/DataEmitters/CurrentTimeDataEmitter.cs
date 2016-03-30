﻿using System;
using System.Timers;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.DataEmitters
{
    public class CurrentTimeDataEmitter : IDataEmitter
    {
        public event EmitDataHandler EmitData;
        public void Initialize()
        {
            EmitData(this, new EmitDataHandlerArgs(DateTime.Now.ToString()));
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
                EmitData(this, new EmitDataHandlerArgs(DateTime.Now.ToString()));
            };
            _Timer.Enabled = true;
        }

        public string ModuleName { get; set; }
        public string ModuleTypeName
        {
            get { return nameof(CurrentTimeDataEmitter); }
        }
    }
}