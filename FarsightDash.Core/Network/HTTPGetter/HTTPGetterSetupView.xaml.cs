using System;
using System.Collections.Generic;
using System.Windows.Controls;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Network.HTTPGetter
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
