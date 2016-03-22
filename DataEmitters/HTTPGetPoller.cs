using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using FarsightDash.FarsightComponents;
using FarsightDash.FarsightComponents.Models;
using Newtonsoft.Json;

namespace FarsightDash.DataEmitters
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
            var test = JsonConvert.DeserializeObject<FarsightWebResponse>(serializedResponse);
            EmitData(this, new EmitDataHandlerArgs(serializedResponse));
        }
    }
}
