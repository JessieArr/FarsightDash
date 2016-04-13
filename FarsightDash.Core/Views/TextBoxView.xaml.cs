using System.Windows.Controls;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.Views
{
    /// <summary>
    /// Interaction logic for TextBoxView.xaml
    /// </summary>
    public partial class TextBoxView : UserControl, IDataConsumer, IDashboardView, ISavableModule
    {
        public TextBoxView()
        {
            InitializeComponent();
        }

        public EmitDataHandler DataHandler
        {
            get
            {
                return (sender, args) =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        ContentTextBox.Text = args.Data;
                    });
                };
            }
        }

        public string ModuleName { get; set; }
        public string ModuleTypeName
        {
            get { return nameof(TextBoxView); }
        }

        public string GetSaveString()
        {
            return "";
        }

        public UserControl Control { get { return this; } }
    }
}
