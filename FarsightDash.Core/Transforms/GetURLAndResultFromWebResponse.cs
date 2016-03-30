using FarsightDash.BaseModules.Models;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;
using Newtonsoft.Json;

namespace FarsightDash.BaseModules.Transforms
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

        public string ModuleName { get; set; }

        public string ModuleTypeName
        {
            get { return nameof(GetURLAndResultFromWebResponse); }
        }
    }
}
