using System;
using System.Collections.Generic;
using System.Windows.Controls;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Miscellaneous.DebugModule
{
    /// <summary>
    /// Interaction logic for DebugModuleSetupView.xaml
    /// </summary>
    public partial class DebugModuleSetupView : UserControl, IModuleSetupView
    {
        public DebugModuleSetupView()
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
            var filter = new DebugModule();
            return new List<IFarsightDashModule>()
            {
                filter
            };
        }
    }
}
