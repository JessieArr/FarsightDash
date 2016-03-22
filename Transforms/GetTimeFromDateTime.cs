using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.FarsightComponents;

namespace FarsightDash.Transforms
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
    }
}
