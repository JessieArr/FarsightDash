using System.Windows.Controls;
using FarsightDash.BaseModules.Views;
using FarsightDash.Common.Interfaces;
using FarsightDash.Common.Saving;
using LabelView = FarsightDash.BaseModules.Views.Label.LabelView;

namespace FarsightDash.BaseModules.Network.HTTPStatusMonitor
{
    /// <summary>
    /// Interaction logic for HTTPStatusMonitor.xaml
    /// </summary>
    public partial class HTTPStatusMonitor : UserControl, ISavableModule, IDashboardView
    {
        private IDataEmitter _DataEmitter;
        private LabelView _View;
        private string _URL;
        private int _IntervalInSeconds;

        public HTTPStatusMonitor(string url, int intervalInSeconds)
        {
            InitializeComponent();

            _URL = url;
            _IntervalInSeconds = intervalInSeconds;

            _DataEmitter = new HTTPGetter.HTTPGetter(url, intervalInSeconds, new WebResponseHelper(), true, true, false, false);
            _View = new LabelView();

            _DataEmitter.EmitData += _View.DataHandler;
            _DataEmitter.Initialize();

            Content = _View;
        }

        public string ModuleName { get; set; }

        public string ModuleTypeName
        {
            get { return nameof(HTTPStatusMonitor); }
        }

        public string GetSaveString()
        {
            return _URL + " " + _IntervalInSeconds;
        }

        public UserControl Control { get { return this; } }
    }
}
