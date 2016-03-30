namespace FarsightDash.Common.Interfaces
{
    public interface IFarsightModuleRegistry
    {
        void RegisterModule(IFarsightDashModule newModule);
        void RegisterDataConsumer(string dataEmitterName, IDataConsumer consumer);
    }
}