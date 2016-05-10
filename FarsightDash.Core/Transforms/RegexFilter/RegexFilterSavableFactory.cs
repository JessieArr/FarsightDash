using System;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.Transforms.RegexFilter
{
    public class RegexFilterSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(RegexFilter); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            var stringParts = savedString.Split(' ');
            if (stringParts.Length < 3)
            {
                throw new Exception($"Unable to load {nameof(RegexFilter)} from saved string!");
            }
            var regexPattern = stringParts[0];
            var returnType = (RegexReturnTypeEnum)Enum.Parse(typeof(RegexReturnTypeEnum), stringParts[1]);
            var separator = stringParts[2];
            return new RegexFilter(regexPattern, returnType, separator);
        }
    }
}
