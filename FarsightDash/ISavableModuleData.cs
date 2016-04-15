namespace FarsightDash
{
    public interface ISavableModuleData
    {
        string ModuleName { get; }
        string ModuleTypeName { get; }
        string ModuleSaveString { get; }
    }
}