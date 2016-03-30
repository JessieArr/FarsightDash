namespace FarsightDash.Common.Interfaces
{
    public interface IFarsightLogger
    {
        void LogDebug(string message);
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message);
        void LogFatal(string message); 
    }
}