using FarsightDash.Common.Interfaces;

namespace FarsightDash.Common.Saving
{
    public interface ISavableModule : IFarsightDashModule
    {
        string GetSaveString();
    }
}
