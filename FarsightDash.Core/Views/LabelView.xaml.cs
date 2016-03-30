using System.Windows.Controls;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Views
{
    /// <summary>
    /// Interaction logic for LabelView.xaml
    /// </summary>
    public partial class LabelView : UserControl, IDataConsumer
    {
        public LabelView()
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
                        ContentLabel.Content = args.Data;
                    });
                };
            } 
        }

        public string ModuleName { get; set; }
        public string ModuleTypeName
        {
            get { return nameof(LabelView); }
        }
    }
}
