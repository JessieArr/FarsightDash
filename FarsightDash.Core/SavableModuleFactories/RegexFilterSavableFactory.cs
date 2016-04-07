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
    public class RegexFilterSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(RegexFilter); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            return new RegexFilter(savedString);
        }
    }
}
