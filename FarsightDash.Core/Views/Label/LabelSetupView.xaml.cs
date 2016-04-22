using System.Collections.Generic;
using FarsightDash.Common.Interfaces;
using LabelView = FarsightDash.BaseModules.Views.Label.LabelView;
using UserControl = System.Windows.Controls.UserControl;

namespace FarsightDash.BaseModules.Views.Label
{
    /// <summary>
    /// Interaction logic for LabelSetupView.xaml
    /// </summary>
    public partial class LabelSetupView : UserControl, IModuleSetupView
    {
        public LabelSetupView()
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
            var module = new LabelView();
            return new List<IFarsightDashModule>()
            {
                module
            };
        }
    }
}
