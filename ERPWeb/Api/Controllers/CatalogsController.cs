using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ERPWeb.ViewModels;

namespace ERPWeb.Api.Controllers
{
    [RoutePrefix("api/Catalogs")]
    public class CatalogsController : ApiController
    {
        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            List<CatalogsViewModel> catalogsList = new List<CatalogsViewModel>();
            catalogsList.Add(new CatalogsViewModel() { Id = 1, Name = "catalog1", Description = "des1" });
            catalogsList.Add(new CatalogsViewModel() { Id = 2, Name = "catalog2", Description = "des2" });
            return Request.CreateResponse(HttpStatusCode.OK,catalogsList);
        }

        [Route("{Id:int}")]
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] CatalogsViewModel cvm)
        {
            cvm.Id = 3;
            cvm.Name += "ok";
            return Request.CreateResponse(HttpStatusCode.OK,cvm);
        }

        [Route("{Id}")]
        [HttpPut]
        public HttpResponseMessage Put(int Id, [FromBody] CatalogsViewModel cvm)
        {
            cvm.Name += "ok";
            // return Request.CreateResponse(HttpStatusCode.OK, cvm);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound,"Error");
        }

        [Route("{Id}")]
    //    [HttpDelete]
        public HttpResponseMessage Delete(int Id)
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
