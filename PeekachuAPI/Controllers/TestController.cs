using Peekachu.WF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace PeekachuAPI.Controllers
{
    [RoutePrefix("Test")]
    public class TestController : ApiController
    {
        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }

        [HttpGet]
        [ActionName("GetCounters")]
        public HttpResponseMessage GetCounters()
        {
            Random random = new Random();
            List<Queue> result = new List<Queue>()
            {
                new Queue() { Type = "DI", Count = random.Next(1000) },
                new Queue() { Type = "BL", Count = random.Next(1000) }
            };
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        [ActionName("CollectDiMesseges")]
        public HttpResponseMessage CollectDiMesseges(CancellationToken cancellationToken)
        {
            bool result = PeekachuWF.CollectDiMesseges(cancellationToken);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
