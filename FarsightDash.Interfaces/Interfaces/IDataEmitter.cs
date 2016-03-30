namespace FarsightDash.Common.Interfaces
{
    public interface IDataEmitter : IFarsightDashModule
    {
        /// <summary>
        /// This event will be raised when the IDataEmitter wants to pass out information
        /// which can be consumed by other modules.
        /// </summary>
        event EmitDataHandler EmitData;
        void Initialize();
    }
}
