using System;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.Miscellaneous.CurrentTime
{
    public class CurrentTimeEmitterSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(CurrentTimeDataEmitter); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            return new CurrentTimeDataEmitter(Int32.Parse(savedString));
        }
    }
}
