using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FarsightDash.BaseModules
{
    public class HttpWebResponseWrapper : IHttpWebResponseWrapper
    {
        public string RedirectedURL { get; }
        public string Status { get; }
        public string Headers { get; }
        public string Body { get; }


        public HttpWebResponseWrapper(string url)
        {
            var request = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse) request.GetResponse();
                
            }
            catch (WebException we)
            {
                response = (HttpWebResponse) we.Response;
            }

            RedirectedURL = response.ResponseUri.AbsoluteUri;
            Status = $"Status: {(int)response.StatusCode} \"{response.StatusDescription}\"";
            Headers = GetStringFromHeaders(response.Headers);
            using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
            {
                Body = reader.ReadToEnd();
            }
        }

        private string GetStringFromHeaders(WebHeaderCollection headers)
        {
            var returnText = "";

            foreach (string header in headers)
            {
                returnText += header + ": " + headers[header] + Environment.NewLine;
            }

            return returnText;
        }
    }
}
