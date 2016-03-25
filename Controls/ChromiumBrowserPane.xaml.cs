using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CefSharp;

namespace FarsightDash.Controls
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

            WebBrowser.Address = initialURL;
            WebBrowser.Load(initialURL);
        }
    }
}
