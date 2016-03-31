using System.Windows.Controls;
using FarsightDash.BaseModules.DataEmitters;
using FarsightDash.BaseModules.Views;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.Controls
{
    /// <summary>
    /// Interaction logic for RefreshImage.xaml
    /// </summary>
    public partial class RefreshImage : UserControl, IFarsightDashModule, ISavableModule
    {
        private IDataEmitter _DataEmitter;
        private ImageView _View;
        private string _URL;
        private int _IntervalInSeconds;

        public RefreshImage(string url, int intervalInSeconds)
        {
            InitializeComponent();

            _URL = url;
            _IntervalInSeconds = intervalInSeconds;

            _DataEmitter = new URLImageSource(url, intervalInSeconds);
            _View = new ImageView();

            _DataEmitter.EmitData += _View.DataHandler;
            _DataEmitter.Initialize();

            Content = _View;
        }

        public string ModuleName { get; set; }

        public string ModuleTypeName
        {
            get { return nameof(RefreshImage); }
        }

        public string GetSaveString()
        {
            return _URL + " " + _IntervalInSeconds;
        }
    }
}
