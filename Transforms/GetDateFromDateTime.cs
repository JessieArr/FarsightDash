using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.FarsightComponents;

namespace FarsightDash.Transforms
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
    }
}
