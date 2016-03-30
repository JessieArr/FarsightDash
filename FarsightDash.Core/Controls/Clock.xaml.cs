using System.Windows.Controls;
using FarsightDash.BaseModules.DataEmitters;
using FarsightDash.BaseModules.Transforms;
using FarsightDash.BaseModules.Views;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Controls
{
    /// <summary>
    /// Interaction logic for Clock.xaml
    /// </summary>
    public partial class Clock : UserControl, IFarsightDashModule
    {
        private IDataEmitter _DataEmitter;
        private ITransform _Transform;
        private LabelView _View;

        public Clock()
        {
            InitializeComponent();

            _DataEmitter = new CurrentTimeDataEmitter(1);
            _Transform = new GetTimeFromDateTime();
            _View = new LabelView();

            _DataEmitter.EmitData += _Transform.DataHandler;
            _Transform.EmitData += _View.DataHandler;
            _DataEmitter.Initialize();

            Content = _View;
        }

        public string ModuleName { get; set; }

        public string ModuleTypeName
        {
            get { return nameof(Clock); }
        }
    }
}
