
namespace FarsightDash.Common.Saving
{
    public interface ISavableModuleFactory<T> where T : ISavableModule
    {
        T GetSavableModuleFromString(string savedString);
    }
}
