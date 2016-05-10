using System;
using System.Text.RegularExpressions;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.Transforms.RegexFilter
{
    public class RegexFilter : ITransform, ISavableModule
    {
        private readonly string _RegexString;
        private readonly RegexReturnTypeEnum _ReturnType;
        private readonly string _SeparatorString;

        public RegexFilter(string regexString, RegexReturnTypeEnum returnType, string separator)
        {
            _RegexString = regexString;
            _ReturnType = returnType;
            _SeparatorString = separator;
        }

        public string ModuleName { get; set; }
        public string ModuleTypeName { get { return nameof(RegexFilter); } }
        public string GetSaveString()
        {
            return $"{_RegexString} {_ReturnType} {_SeparatorString}";
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
                        if (_ReturnType == RegexReturnTypeEnum.FirstMatch)
                        {
                            var result = regex.Match(data);
                            EmitData(this, new EmitDataHandlerArgs(result.Value));
                            return;
                        }
                        if (_ReturnType == RegexReturnTypeEnum.LastMatch)
                        {
                            var result = regex.Matches(data);
                            if (result.Count == 0)
                            {
                                EmitData(this, new EmitDataHandlerArgs(""));
                                return;
                            }
                            else
                            {
                                var lastResult = result[result.Count - 1];
                                EmitData(this, new EmitDataHandlerArgs(lastResult.Value));
                                return;
                            }
                        }
                        if (_ReturnType == RegexReturnTypeEnum.AllMatches)
                        {
                            var result = regex.Matches(data);
                            string returnString = "";
                            for(var i = 0; i < result.Count; i++)
                            {
                                returnString += result[i].Value + _SeparatorString;
                            }
                            EmitData(this, new EmitDataHandlerArgs(returnString));
                            return;
                        }
                        throw new Exception("Regex Return Type not correctly matched!");
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
