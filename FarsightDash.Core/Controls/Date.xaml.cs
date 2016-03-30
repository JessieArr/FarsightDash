using System.Windows.Controls;
using FarsightDash.BaseModules.DataEmitters;
using FarsightDash.BaseModules.Transforms;
using FarsightDash.BaseModules.Views;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Controls
{
    /// <summary>
    /// Interaction logic for Date.xaml
    /// </summary>
    public partial class Date : UserControl
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
    }
}
