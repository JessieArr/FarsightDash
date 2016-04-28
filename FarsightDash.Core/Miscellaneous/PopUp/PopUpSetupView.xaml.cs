using System;
using System.Collections.Generic;
using System.Windows.Controls;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Miscellaneous.PopUp
{
    /// <summary>
    /// Interaction logic for PopUpSetupView.xaml
    /// </summary>
    public partial class PopUpSetupView : UserControl, IModuleSetupView
    {
        public PopUpSetupView()
        {
            InitializeComponent();
        }

        public UserControl Control
        {
            get { return this; }
        }

        public bool IsEnteredUserDataValid()
        {
            return !String.IsNullOrEmpty(TitleTextBox.Text);
        }

        public List<IFarsightDashModule> CreateModules(IFarsightModuleRegistry moduleRegistry)
        {
            var isChecked = IncludeTextCheckBox.IsChecked.HasValue && IncludeTextCheckBox.IsChecked.Value;
            var filter = new PopUp(TitleTextBox.Text, BodyTextBox.Text, isChecked);
            return new List<IFarsightDashModule>()
            {
                filter
            };
        }
    }
}
