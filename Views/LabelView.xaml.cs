using System;
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
using FarsightDash.DataEmitters;
using FarsightDash.FarsightComponents;

namespace FarsightDash.Views
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
    }
}
