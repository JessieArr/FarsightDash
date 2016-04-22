using System.Windows.Controls;
using CefSharp;
using FarsightDash.Common.Interfaces;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.Network.ChromiumBrowser
{
    /// <summary>
    /// Interaction logic for ChromiumBrowserPane.xaml
    /// </summary>
    public partial class ChromiumBrowserPane : UserControl, ISavableModule, IDashboardView
    {
        public ChromiumBrowserPane(string initialURL)
        {
            InitializeComponent();

            WebBrowser.BrowserSettings.FileAccessFromFileUrls = CefState.Enabled;
            WebBrowser.BrowserSettings.UniversalAccessFromFileUrls = CefState.Enabled;
            WebBrowser.BrowserSettings.MinimumFontSize = 5;

            WebBrowser.Address = initialURL;
            WebBrowser.Load(initialURL);
        }

        public string ModuleName { get; set; }

        public string ModuleTypeName
        {
            get { return nameof(ChromiumBrowserPane); }
        }

        public string GetSaveString()
        {
            return WebBrowser.Address;
        }

        public UserControl Control { get { return this; } }
    }
}
