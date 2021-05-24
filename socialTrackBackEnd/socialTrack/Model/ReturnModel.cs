using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace socialTrack.Model
{
    public class ReturnModel
    {
        public string Message { get; set; }
        public dynamic ResponseData { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
