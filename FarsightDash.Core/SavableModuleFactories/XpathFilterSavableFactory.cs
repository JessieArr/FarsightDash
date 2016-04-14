using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.BaseModules.Controls;
using FarsightDash.BaseModules.Transforms;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.SavableModuleFactories
{
    public class XpathFilterSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(XpathFilter); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            return new XpathFilter(savedString);
        }
    }
}
