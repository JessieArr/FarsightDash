﻿using System.Windows.Controls;
using FarsightDash.BaseModules.DataEmitters;
using FarsightDash.BaseModules.Transforms;
using FarsightDash.BaseModules.Views;
using FarsightDash.Common;

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
