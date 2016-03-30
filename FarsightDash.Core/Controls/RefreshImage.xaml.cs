using System.Windows.Controls;
using FarsightDash.BaseModules.DataEmitters;
using FarsightDash.BaseModules.Views;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;

namespace FarsightDash.BaseModules.Controls
{
    /// <summary>
    /// Interaction logic for RefreshImage.xaml
    /// </summary>
    public partial class RefreshImage : UserControl
    {
        private IDataEmitter _DataEmitter;
        private ImageView _View;

        public RefreshImage(string url, int intervalInSeconds)
        {
            InitializeComponent();

            _DataEmitter = new URLImageSource(url, intervalInSeconds);
            _View = new ImageView();

            _DataEmitter.EmitData += _View.DataHandler;
            _DataEmitter.Initialize();

            Content = _View;
        }
    }
}
