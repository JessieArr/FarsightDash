using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.FarsightComponents;
using FarsightDash.FarsightComponents.Models;
using Newtonsoft.Json;

namespace FarsightDash.Transforms
{
    public class GetURLAndResultFromWebResponse : ITransform
    {
        public EmitDataHandler DataHandler
        {
            get
            {
                return (sender, args) =>
                {
                    var response = JsonConvert.DeserializeObject<FarsightWebResponse>(args.Data);
                    var resultString = response.ResponseUri + " - " + response.StatusCode;
                    EmitData(this, new EmitDataHandlerArgs(resultString));
                };
            }
        }

        public event EmitDataHandler EmitData;
        public void Initialize()
        {
        }
    }
}
