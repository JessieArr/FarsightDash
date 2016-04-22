using System;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Transforms.TimeParser
{
    public class GetTimeFromDateTime : ITransform
    {
        public EmitDataHandler DataHandler
        {
            get
            {
                return (sender, args) =>
                {
                    var dateTime = DateTime.Parse(args.Data);
                    EmitData(this, new EmitDataHandlerArgs(dateTime.TimeOfDay.ToString()));
                };
            }
        }

        public event EmitDataHandler EmitData;

        public void Initialize()
        {
        }

        public string ModuleName { get; set; }
        public string ModuleTypeName
        {
            get { return nameof(GetTimeFromDateTime); }
        }
    }
}
