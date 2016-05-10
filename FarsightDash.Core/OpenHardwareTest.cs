using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHardwareMonitor.Hardware;

namespace FarsightDash.BaseModules
{
    public class OpenHardwareTest
    {
        public OpenHardwareTest()
        {
            var x = new Computer();
            x.CPUEnabled = true;
            x.MainboardEnabled = true;
            x.FanControllerEnabled = true;
            x.GPUEnabled = true;
            x.HDDEnabled = true;
            x.RAMEnabled = true;
            x.Open();
            var report = x.GetReport();

            var tempString = "";
            var y = new OpenHardwareMonitor.Hardware.SensorVisitor(sensor =>
            {
                var z = sensor;
                if (sensor.SensorType == SensorType.Temperature)
                {
                    tempString += $"{sensor.Name} temp: {sensor.Value}{Environment.NewLine}";
                }
            });
            x.Traverse(y);
        }
    }
}
