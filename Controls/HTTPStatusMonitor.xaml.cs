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
using FarsightDash.Transforms;
using FarsightDash.Views;

namespace FarsightDash.Controls
{
    /// <summary>
    /// Interaction logic for HTTPStatusMonitor.xaml
    /// </summary>
    public partial class HTTPStatusMonitor : UserControl
    {
        private IDataEmitter _DataEmitter;
        private ITransform _Transform;
        private LabelView _View;

        public HTTPStatusMonitor(string url, int intervalInSeconds)
        {
            InitializeComponent();

            _DataEmitter = new HTTPGetPoller(url, intervalInSeconds);
            _Transform = new GetURLAndResultFromWebResponse();
            _View = new LabelView();

            _DataEmitter.EmitData += _Transform.DataHandler;
            _Transform.EmitData += _View.DataHandler;
            _DataEmitter.Initialize();

            Content = _View;
        }
    }
}
