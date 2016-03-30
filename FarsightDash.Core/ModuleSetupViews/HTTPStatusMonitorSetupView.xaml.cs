﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FarsightDash.BaseModules.Controls;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.ModuleSetupViews
{
    /// <summary>
    /// Interaction logic for HTTPStatusMonitorSetupView.xaml
    /// </summary>
    public partial class HTTPStatusMonitorSetupView : UserControl, IModuleSetupView
    {
        public HTTPStatusMonitorSetupView()
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
            var browser = new HTTPStatusMonitor(URLTextBox.Text, 10);
            return new List<IFarsightDashModule>()
            {
                browser
            };
        }
    }
}
