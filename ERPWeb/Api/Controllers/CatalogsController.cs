using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ERPWeb.ViewModels;
using ERPWeb.Utility;

namespace ERPWeb.Api.Controllers
{
    [RoutePrefix("api/Catalogs")]
    public class CatalogsController : ApiController
    {
        #region Members and Constructors
        private IViewModelOperator _ivmo;
        public IViewModelOperator IVMO
        {
            get { return _ivmo; }
            set { _ivmo = value; }
        }
        public CatalogsController(IViewModelOperator ivmo)
        {
            IVMO = ivmo;
        }
        #endregion
        
        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            //List<CatalogsViewModel> catalogsList = new List<CatalogsViewModel>();
            //catalogsList.Add(new CatalogsViewModel() { Id = 1, Name = "catalog1", Description = "des1" });
            //catalogsList.Add(new CatalogsViewModel() { Id = 2, Name = "catalog2", Description = "des2" });

            return Request.CreateResponse(HttpStatusCode.OK,IVMO.GetCatalogs());
        }

        [Route("{Id:int}")]
        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            return Request.CreateResponse(HttpStatusCode.OK,IVMO.GetCatalog(Id));
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] CatalogsViewModel cvm)
        {
            if (IVMO.InsertCatalog(ref cvm))
            {
                return Request.CreateResponse(HttpStatusCode.OK, cvm);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "inserted error");
            }
        }

        [Route("{Id}")]
        [HttpPut]
        public HttpResponseMessage Put(int Id, [FromBody] CatalogsViewModel cvm)
        {
            if(IVMO.UpdateCatalog(Id,ref cvm))
            {
                return Request.CreateResponse(HttpStatusCode.OK, cvm);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,"Error");
            }
        }

        [Route("{Id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int Id)
        {
            if (IVMO.DeleteCatalog(Id))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error");
            }
        }
    }
}
