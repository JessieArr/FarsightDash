using System.Collections.Generic;
using FarsightDash.Common.Interfaces;
using Clock = FarsightDash.BaseModules.Miscellaneous.Clock.Clock;
using UserControl = System.Windows.Controls.UserControl;

namespace FarsightDash.BaseModules.Miscellaneous.Clock
{
    /// <summary>
    /// Interaction logic for ClockSetupView.xaml
    /// </summary>
    public partial class ClockSetupView : UserControl, IModuleSetupView
    {
        public ClockSetupView()
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
            var module = new Clock();
            return new List<IFarsightDashModule>()
            {
                module
            };
        }
    }
}
