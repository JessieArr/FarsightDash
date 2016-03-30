using FarsightDash.Common.Interfaces;

namespace FarsightDash.Common
{
    public class EmitDataHandlerArgs : IEmitDataHandlerArgs
    {
        public EmitDataHandlerArgs(string data)
        {
            Data = data;
        }

        public string Data { get; }
    }
}