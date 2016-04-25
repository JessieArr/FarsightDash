using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using FarsightDash.Common.Interfaces;
using UserControl = System.Windows.Controls.UserControl;

namespace FarsightDash.BaseModules.LocalMachine.ProcessList
{
    /// <summary>
    /// Interaction logic for ProcessListSetupView.xaml
    /// </summary>
    public partial class ProcessListSetupView : UserControl, IModuleSetupView
    {
        public ProcessListSetupView()
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
            var module = new ProcessList();
            return new List<IFarsightDashModule>()
            {
                module
            };
        }
    }
}
