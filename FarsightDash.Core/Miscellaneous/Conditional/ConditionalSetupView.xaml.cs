using System;
using System.Collections.Generic;
using System.Windows.Controls;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Miscellaneous.Conditional
{
    /// <summary>
    /// Interaction logic for ConditionalSetupView.xaml
    /// </summary>
    public partial class ConditionalSetupView : UserControl, IModuleSetupView
    {
        public ConditionalSetupView()
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
            var filter = new Conditional(RegexFilterTextBox.Text);
            return new List<IFarsightDashModule>()
            {
                filter
            };
        }
    }
}
