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
    

    [RoutePrefix("api/Contacters")]
    public class ContacterController : ApiController
    {
        #region Members and Constructor
        private IViewModelOperator _ivmo;
        public IViewModelOperator IVMO
        {
            get { return _ivmo; }
            set { _ivmo = value; }
        }

        public ContacterController(IViewModelOperator _ivmo)
        {
            IVMO = _ivmo;
        }
        #endregion

        [Route("~/api/customers/{customerId:int}/contacters/{contacterId:int}")]
        [HttpDelete]
        public HttpResponseMessage Delete( int contacterId)
        {
            if (IVMO.DeleteContacter(contacterId))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error");
            }
        }

        [Route("{contacterId:int}/")]
        [HttpPut]
        public HttpResponseMessage Put(int contacterId,[FromBody] ContacterViewModel cvm)
        {
            if (IVMO.UpdateContacter(contacterId, ref cvm))
            {
                return Request.CreateResponse(HttpStatusCode.OK, cvm);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "");
            }
        }

        [Route("~/api/customers/{customerId:int}/contacters")]
        [HttpPost]
        public HttpResponseMessage Post(int customerId,[FromBody] ContacterViewModel cvm)
        {
            if (IVMO.InsertContacter(ref cvm))
            {
                return Request.CreateResponse(HttpStatusCode.OK, cvm);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "");
            }
        }
    }
}
