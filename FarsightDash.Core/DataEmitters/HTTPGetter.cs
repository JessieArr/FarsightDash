using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;
using FarsightDash.Common.Saving;

namespace FarsightDash.BaseModules.DataEmitters
{
    public class HTTPGetter : IDataEmitter, ISavableModule
    {
        public string ModuleName { get; set; }
        public string ModuleTypeName { get { return nameof(HTTPGetter); } }

        public string GetSaveString()
        {
            return $"{_URL} {_IntervalInSeconds} {_IncludeURL} {_IncludeStatus} {_IncludeHeaders} {_IncludeBody}";
        }

        public event EmitDataHandler EmitData;

        private string _URL;
        private int _IntervalInSeconds;
        private const int _MillisecondsPerSecond = 1000;
        private Timer _Timer;
        private IWebResponseHelper _WebHelper;
        private bool _IncludeURL;
        private bool _IncludeStatus;
        private bool _IncludeHeaders;
        private bool _IncludeBody;

        public HTTPGetter(string url, int refreshIntervalInSeconds, IWebResponseHelper webHelper, 
            bool includeUrl, bool includeStatus, bool includeHeaders, bool includeBody)
        {
            _URL = url;
            _IntervalInSeconds = refreshIntervalInSeconds;
            _WebHelper = webHelper;
            _IncludeURL = includeUrl;
            _IncludeStatus = includeStatus;
            _IncludeHeaders = includeHeaders;
            _IncludeBody = includeBody;

            _Timer = new Timer(refreshIntervalInSeconds * _MillisecondsPerSecond);
            _Timer.Elapsed += (sender, args) =>
            {
                EmitFreshData();
            };
            _Timer.Enabled = true;
        }

        public void Initialize()
        {
            EmitFreshData();
        }

        private string GetStringFromURL()
        {
            var returnText = "";

            var response = _WebHelper.GetResponseFromURL(_URL);

            if (_IncludeURL)
            {
                returnText += response.RedirectedURL + Environment.NewLine;
            }
            if (_IncludeStatus)
            {
                returnText += response.Status + Environment.NewLine;
            }
            if (_IncludeHeaders)
            {
                returnText += response.Headers + Environment.NewLine;
            }
            if (_IncludeBody)
            {
                returnText += response.Body;
            }

            return returnText;
        }

        private void EmitFreshData()
        {
            if (EmitData != null)
            {
                var response = GetStringFromURL();
                EmitData(this, new EmitDataHandlerArgs(response));
            }
        }
    }
}
