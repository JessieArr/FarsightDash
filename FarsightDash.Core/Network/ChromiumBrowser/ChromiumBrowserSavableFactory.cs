using FarsightDash.Common.Saving;
using ChromiumBrowserPane = FarsightDash.BaseModules.Network.ChromiumBrowser.ChromiumBrowserPane;

namespace FarsightDash.BaseModules.Network.ChromiumBrowser
{
    public class ChromiumBrowserSavableFactory : ISavableModuleFactory
    {
        public string ModuleTypeName { get { return nameof(ChromiumBrowserPane); } }
        public ISavableModule GetSavableModuleFromString(string savedString)
        {
            return new ChromiumBrowserPane(savedString);
        }
    }
}
