using System;
using System.Collections.Generic;
using System.Windows.Controls;
using FarsightDash.Common.Interfaces;
using ChromiumBrowserPane = FarsightDash.BaseModules.Network.ChromiumBrowser.ChromiumBrowserPane;

namespace FarsightDash.BaseModules.Network.ChromiumBrowser
{
    /// <summary>
    /// Interaction logic for ChromiumBrowserSetupView.xaml
    /// </summary>
    public partial class ChromiumBrowserSetupView : UserControl, IModuleSetupView
    {
        public ChromiumBrowserSetupView()
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
            var browser = new ChromiumBrowserPane(URLTextBox.Text);
            return new List<IFarsightDashModule>()
            {
                browser
            };
        }
    }
}
