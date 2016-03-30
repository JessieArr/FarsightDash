using System.Windows.Controls;
using CefSharp;

namespace FarsightDash.BaseModules.Controls
{
    /// <summary>
    /// Interaction logic for ChromiumBrowserPane.xaml
    /// </summary>
    public partial class ChromiumBrowserPane : UserControl
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
    }
}
