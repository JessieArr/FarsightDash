using System;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Transforms
{
    public class GetDateFromDateTime : ITransform
    {
        public EmitDataHandler DataHandler
        {
            get
            {
                return (sender, args) =>
                {
                    var dateTime = DateTime.Parse(args.Data);
                    EmitData(this, new EmitDataHandlerArgs(dateTime.Date.ToString("MM/dd/yyyy")));
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
            get { return nameof(GetDateFromDateTime); }
        }
    }
}
