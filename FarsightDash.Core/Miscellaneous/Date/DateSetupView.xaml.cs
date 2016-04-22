using System.Collections.Generic;
using FarsightDash.Common.Interfaces;
using Date = FarsightDash.BaseModules.Miscellaneous.Date.Date;
using UserControl = System.Windows.Controls.UserControl;

namespace FarsightDash.BaseModules.Miscellaneous.Date
{
    /// <summary>
    /// Interaction logic for ClockSetupView.xaml
    /// </summary>
    public partial class DateSetupView : UserControl, IModuleSetupView
    {
        public DateSetupView()
        {
            InitializeComponent();
        }

        public UserControl Control
        {
            get { return this; }
        }

        public bool IsEnteredUserDataValid()
        {
            return true;
        }

        public List<IFarsightDashModule> CreateModules(IFarsightModuleRegistry moduleRegistry)
        {
            var module = new Date();
            return new List<IFarsightDashModule>()
            {
                module
            };
        }
    }
}
