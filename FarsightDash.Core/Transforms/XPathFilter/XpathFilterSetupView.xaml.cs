using System;
using System.Collections.Generic;
using System.Windows.Controls;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Transforms.XPathFilter
{
    /// <summary>
    /// Interaction logic for XpathFilterSetupView.xaml
    /// </summary>
    public partial class XpathFilterSetupView : UserControl, IModuleSetupView
    {
        public XpathFilterSetupView()
        {
            InitializeComponent();
        }

        public UserControl Control
        {
            get { return this; }
        }

        public bool IsEnteredUserDataValid()
        {
            return !String.IsNullOrEmpty(XpathFilterTextBox.Text);
        }

        public List<IFarsightDashModule> CreateModules(IFarsightModuleRegistry moduleRegistry)
        {
            var filter = new XpathFilter(XpathFilterTextBox.Text);
            return new List<IFarsightDashModule>()
            {
                filter
            };
        }
    }
}
