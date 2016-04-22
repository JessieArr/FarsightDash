using FarsightDash.Common;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Transforms.TimestampTransform
{
    public class TimestampTransform : ITransform
    {
        public EmitDataHandler DataHandler { get; }
        public event EmitDataHandler EmitData;
        public void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public string ModuleName { get; set; }
        public string ModuleTypeName
        {
            get { return nameof(TimestampTransform); }
        }
    }
}
