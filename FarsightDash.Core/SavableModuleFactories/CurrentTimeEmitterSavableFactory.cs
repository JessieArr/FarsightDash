using System;
using FarsightDash.BaseModules.Controls;
using FarsightDash.BaseModules.DataEmitters;
using FarsightDash.BaseModules.Views;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.SavableModuleFactories
{
    public class CurrentTimeEmitterSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(LabelView); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            return new CurrentTimeDataEmitter(Int32.Parse(savedString));
        }
    }
}
