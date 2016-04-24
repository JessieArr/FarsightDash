using FarsightDash.BaseModules.Views.TextBox;
using FarsightDash.Common.Saving;
using Newtonsoft.Json;

namespace FarsightDash.BaseModules.Views.LineHighlight
{
    public class LineHighlightSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(LineHighlight); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            var model = JsonConvert.DeserializeObject<LineHighlightSaveModel>(savedString);
            return new LineHighlight(model);
        }
    }
}
