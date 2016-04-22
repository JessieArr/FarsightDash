using System.Text.RegularExpressions;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.Transforms.RegexFilter
{
    public class RegexFilter : ITransform, ISavableModule
    {
        private readonly string _RegexString;
        public RegexFilter(string regexString)
        {
            _RegexString = regexString;
        }

        public string ModuleName { get; set; }
        public string ModuleTypeName { get { return nameof(RegexFilter); } }
        public string GetSaveString()
        {
            return _RegexString;
        }

        public EmitDataHandler DataHandler
        {
            get
            {
                return (sender, args) =>
                {
                    if (EmitData != null)
                    {
                        var data = args.Data;
                        var regex = new Regex(_RegexString);
                        var result = regex.Match(data);
                        EmitData(this, new EmitDataHandlerArgs(result.Value));
                    }
                };
            }
        }


        public event EmitDataHandler EmitData;

        public void Initialize()
        {
            return;
        }
    }
}
