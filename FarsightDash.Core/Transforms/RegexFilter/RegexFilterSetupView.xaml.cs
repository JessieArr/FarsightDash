using System;
using System.Collections.Generic;
using System.Windows.Controls;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Transforms.RegexFilter
{
    /// <summary>
    /// Interaction logic for RegexFilterSetupView.xaml
    /// </summary>
    public partial class RegexFilterSetupView : UserControl, IModuleSetupView
    {
        public RegexFilterSetupView()
        {
            InitializeComponent();
        }

        public UserControl Control
        {
            get { return this; }
        }

        public bool IsEnteredUserDataValid()
        {
            return !String.IsNullOrEmpty(RegexFilterTextBox.Text);
        }

        public List<IFarsightDashModule> CreateModules(IFarsightModuleRegistry moduleRegistry)
        {
            var filter = new RegexFilter(RegexFilterTextBox.Text);
            return new List<IFarsightDashModule>()
            {
                filter
            };
        }
    }
}
