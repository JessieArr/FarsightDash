namespace FarsightDash.FarsightComponents
{
    class EmitDataHandlerArgs : IEmitDataHandlerArgs
    {
        public EmitDataHandlerArgs(string data)
        {
            Data = data;
        }

        public string Data { get; }
    }
}