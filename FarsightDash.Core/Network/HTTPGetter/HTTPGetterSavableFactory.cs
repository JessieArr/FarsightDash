using System;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.Network.HTTPGetter
{
    public class HTTPGetterSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(HTTPGetter); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            var splitString = savedString.Split(new [] {' '});
            if (splitString.Length != 6)
            {
                throw new Exception($"Unable to load {nameof(HTTPGetter)} from saved string: {savedString}");
            }
            var url = splitString[0];
            var interval = Int32.Parse(splitString[1]);
            var includeURL = Boolean.Parse(splitString[2]);
            var includeStatus = Boolean.Parse(splitString[3]);
            var includeHeaders = Boolean.Parse(splitString[4]);
            var includeBody = Boolean.Parse(splitString[5]);

            return new HTTPGetter(url, interval, new WebResponseHelper(), includeURL, includeStatus, includeHeaders, includeBody);
        }
    }
}
