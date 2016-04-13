using System;
using FarsightDash.BaseModules.Controls;
using FarsightDash.BaseModules.Views;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.SavableModuleFactories
{
    public class TextBoxViewSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(TextBoxView); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            return new TextBoxView();
        }
    }
}
