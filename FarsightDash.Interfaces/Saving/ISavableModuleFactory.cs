
using FarsightDash.Common.Interfaces;

namespace FarsightDash.Common.Saving
{
    public interface ISavableModuleFactory
    {
        string ModuleTypeName { get; }
        ISavableModule GetSavableModuleFromString(string savedString);
    }
}
