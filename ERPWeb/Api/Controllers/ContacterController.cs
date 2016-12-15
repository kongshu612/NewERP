using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ERPWeb.ViewModels;

namespace ERPWeb.Api.Controllers
{
    [RoutePrefix("api/Contacters")]
    public class ContacterController : ApiController
    {
        [Route("~/api/customers/{customerId:int}/contacters/{contacterId:int}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int customerId, int contacterId)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("{contacterId:int}/")]
        [HttpPut]
        public HttpResponseMessage Put(int contacterId,[FromBody] ContacterViewModel cvm)
        {
            cvm.Name += "ok";
            return Request.CreateResponse(HttpStatusCode.OK,cvm);
        }

        [Route("~/api/customers/{customerId:int}/contacters")]
        [HttpPost]
        public HttpResponseMessage Post(int customerId,[FromBody] ContacterViewModel cvm)
        {
            cvm.Id = 1;
            return Request.CreateResponse(HttpStatusCode.OK,cvm);
        }
    }
}
