using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ERPWeb.ViewModels;

namespace ERPWeb.Api.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("{Id}")]
        public HttpResponseMessage Put([FromBody]OrderViewModel ovm)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
