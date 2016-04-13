using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FarsightDash.BaseModules.Controls;
using FarsightDash.BaseModules.Views;
using FarsightDash.Common.Interfaces;
using UserControl = System.Windows.Controls.UserControl;

namespace FarsightDash.BaseModules.ModuleSetupViews
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
