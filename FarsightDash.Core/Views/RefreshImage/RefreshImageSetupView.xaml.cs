using System;
using System.Collections.Generic;
using System.Windows.Controls;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Views.RefreshImage
{
    /// <summary>
    /// Interaction logic for RefreshImageSetupView.xaml
    /// </summary>
    public partial class RefreshImageSetupView : UserControl, IModuleSetupView
    {
        public RefreshImageSetupView()
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
            var browser = new RefreshImage(URLTextBox.Text, 10);
            return new List<IFarsightDashModule>()
            {
                browser
            };
        }
    }
}
