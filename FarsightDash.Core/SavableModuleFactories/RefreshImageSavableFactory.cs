using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.BaseModules.Controls;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.SavableModuleFactories
{
    public class RefreshImageSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(RefreshImage); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            var splitString = savedString.Split(new [] {' '});
            if (splitString.Length != 2)
            {
                throw new Exception($"Unable to load {nameof(RefreshImage)} from saved string: {savedString}");
            }
            var url = splitString[0];
            var interval = Int32.Parse(splitString[1]);
            return new RefreshImage(url, interval);
        }
    }
}
