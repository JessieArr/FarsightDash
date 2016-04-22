using System;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.Network.HTTPStatusMonitor
{
    public class HTTPStatusMonitorSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(HTTPStatusMonitor); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            var splitString = savedString.Split(new [] {' '});
            if (splitString.Length != 2)
            {
                throw new Exception($"Unable to load {nameof(HTTPStatusMonitor)} from saved string: {savedString}");
            }
            var url = splitString[0];
            var interval = Int32.Parse(splitString[1]);
            return new HTTPStatusMonitor(url, interval);
        }
    }
}
