using System;
using System.Net;

namespace FarsightDash.BaseModules.Models
{
    public class FarsightWebResponse
    {
        public Uri ResponseUri { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public FarsightWebResponse()
        {
        }

            public FarsightWebResponse(HttpWebResponse response)
        {
            ResponseUri = response.ResponseUri;
            StatusCode = response.StatusCode;
        }
    }
}
