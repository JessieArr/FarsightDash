using System.Collections.Generic;
using FarsightDash.Common.Interfaces;
using UserControl = System.Windows.Controls.UserControl;

namespace FarsightDash.BaseModules.Miscellaneous.CurrentTime
{
    /// <summary>
    /// Interaction logic for CurrentTimeSetupView.xaml
    /// </summary>
    public partial class CurrentTimeSetupView : UserControl, IModuleSetupView
    {
        public CurrentTimeSetupView()
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
            var module = new CurrentTimeDataEmitter(1);
            return new List<IFarsightDashModule>()
            {
                module
            };
        }
    }
}
