using System;
using FarsightDash.BaseModules.Controls;
using FarsightDash.BaseModules.Views;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.SavableModuleFactories
{
    public class LabelViewSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(LabelView); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            return new LabelView();
        }
    }
}
