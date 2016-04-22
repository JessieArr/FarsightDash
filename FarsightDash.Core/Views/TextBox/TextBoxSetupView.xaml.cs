using System.Collections.Generic;
using FarsightDash.Common.Interfaces;
using TextBoxView = FarsightDash.BaseModules.Views.TextBox.TextBoxView;
using UserControl = System.Windows.Controls.UserControl;

namespace FarsightDash.BaseModules.Views.TextBox
{
    /// <summary>
    /// Interaction logic for TextBoxSetupView.xaml
    /// </summary>
    public partial class TextBoxSetupView : UserControl, IModuleSetupView
    {
        public TextBoxSetupView()
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
            var module = new TextBoxView();
            return new List<IFarsightDashModule>()
            {
                module
            };
        }
    }
}
