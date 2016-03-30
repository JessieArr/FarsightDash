using System.Collections.Generic;

namespace FarsightDash.Common.Interfaces
{
    public interface IDataConsumer : IFarsightDashModule
    {
        /// <summary>
        /// This is the event handler that will process events raised by the IDataEmitters
        /// to which this IDataConsumer is listening.
        /// </summary>
        EmitDataHandler DataHandler { get; }
    }
}
