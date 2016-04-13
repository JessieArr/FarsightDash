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
using FarsightDash.BaseModules.Controls;
using FarsightDash.BaseModules.DataEmitters;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.ModuleSetupViews
{
    /// <summary>
    /// Interaction logic for HTTPGetterSetupView.xaml
    /// </summary>
    public partial class HTTPGetterSetupView : UserControl, IModuleSetupView
    {
        public HTTPGetterSetupView()
        {
            InitializeComponent();
        }

        public UserControl Control
        {
            get { return this; }
        }

        public bool IsEnteredUserDataValid()
        {
            return !String.IsNullOrEmpty(URLTextBox.Text);
        }

        public List<IFarsightDashModule> CreateModules(IFarsightModuleRegistry moduleRegistry)
        {
            var url = URLTextBox.Text;
            var interval = Int32.Parse(RefreshTextBox.Text);
            var includeResponseUrl = IncludeURLCheckBox.IsChecked.HasValue && IncludeURLCheckBox.IsChecked.Value;
            var includeResponseStatus = IncludeStatusCheckBox.IsChecked.HasValue && IncludeStatusCheckBox.IsChecked.Value;
            var includeResponseHeaders = IncludeHeadersCheckBox.IsChecked.HasValue && IncludeHeadersCheckBox.IsChecked.Value;
            var includeResponseBody = IncludeBodyCheckBox.IsChecked.HasValue && IncludeBodyCheckBox.IsChecked.Value;

            var browser = new HTTPGetter(url, interval, new WebResponseHelper(), includeResponseUrl, 
                includeResponseStatus, includeResponseHeaders, includeResponseBody);

            return new List<IFarsightDashModule>()
            {
                browser
            };
        }
    }
}
