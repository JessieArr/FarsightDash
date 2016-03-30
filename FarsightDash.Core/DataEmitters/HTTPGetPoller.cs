using System.Net;
using System.Timers;
using FarsightDash.BaseModules.Models;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;
using Newtonsoft.Json;

namespace FarsightDash.BaseModules.DataEmitters
{
    public class HTTPGetPoller : IDataEmitter
    {
        public event EmitDataHandler EmitData;

        private string _URL;
        private int _IntervalInSeconds;
        private const int _MillisecondsPerSecond = 1000;
        private Timer _Timer;

        public HTTPGetPoller(string url, int intervalInSeconds)
        {
            _URL = url;

            _IntervalInSeconds = intervalInSeconds;

            _Timer = new Timer(intervalInSeconds * _MillisecondsPerSecond);
            _Timer.Elapsed += (sender, args) =>
            {
                var response = GetResponseFromURL();
                var serializedResponse = JsonConvert.SerializeObject(response);
                EmitData(this, new EmitDataHandlerArgs(serializedResponse));
            };
            _Timer.Enabled = true;
        }

        private FarsightWebResponse GetResponseFromURL()
        {
            var request = (HttpWebRequest)WebRequest.Create(_URL);

            // Set some reasonable limits on resources used by this request
            request.MaximumAutomaticRedirections = 4;
            request.MaximumResponseHeadersLength = 4;

            request.Credentials = CredentialCache.DefaultCredentials;

            WebResponse response;
            try
            {
                response = request.GetResponse();
                response.Close();
            }
            catch (WebException ex)
            {
                response = ex.Response;
                if (response == null)
                {
                    throw ex;
                }
            }

            return new FarsightWebResponse((HttpWebResponse)response);
        }

        public void Initialize()
        {
            var response = GetResponseFromURL();
            var serializedResponse = JsonConvert.SerializeObject(response);
            EmitData(this, new EmitDataHandlerArgs(serializedResponse));
        }

        public string ModuleName { get; set; }
        public string ModuleTypeName
        {
            get { return nameof(HTTPGetPoller); }
        }
    }
}
