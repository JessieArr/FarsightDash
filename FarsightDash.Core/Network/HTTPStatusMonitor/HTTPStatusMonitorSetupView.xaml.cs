using System;
using System.Collections.Generic;
using System.Windows.Controls;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Network.HTTPStatusMonitor
{
    /// <summary>
    /// Interaction logic for HTTPStatusMonitorSetupView.xaml
    /// </summary>
    public partial class HTTPStatusMonitorSetupView : UserControl, IModuleSetupView
    {
        public HTTPStatusMonitorSetupView()
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
            var browser = new HTTPStatusMonitor(URLTextBox.Text, 10);
            return new List<IFarsightDashModule>()
            {
                browser
            };
        }
    }
}
