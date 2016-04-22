using System.Windows.Controls;
using FarsightDash.BaseModules.Miscellaneous.CurrentTime;
using FarsightDash.BaseModules.Transforms.TimeParser;
using FarsightDash.Common.Interfaces;
using LabelView = FarsightDash.BaseModules.Views.Label.LabelView;

namespace FarsightDash.BaseModules.Miscellaneous.Date
{
    /// <summary>
    /// Interaction logic for Date.xaml
    /// </summary>
    public partial class Date : UserControl, IFarsightDashModule
    {
        private IDataEmitter _DataEmitter;
        private ITransform _Transform;
        private LabelView _View;

        public Date()
        {
            InitializeComponent();

            _DataEmitter = new CurrentTimeDataEmitter(60);
            _Transform = new GetDateFromDateTime();
            _View = new LabelView();

            _DataEmitter.EmitData += _Transform.DataHandler;
            _Transform.EmitData += _View.DataHandler;
            _DataEmitter.Initialize();

            Content = _View;
        }

        public string ModuleName { get; set; }

        public string ModuleTypeName
        {
            get { return nameof(Date); }
        }
    }
}
