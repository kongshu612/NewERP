using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataRepository;
using DBContext;
using ERPWeb.ViewModels;
using ERPWeb.Utility;

namespace ERPWeb.Api.Controllers
{
    [RoutePrefix("api/Customers")]
    public class CustomerController : ApiController
    {
        #region Members and Constructor
        private IViewModelOperator _ivmo;
        public IViewModelOperator IVMO
        {
            get { return _ivmo; }
            set { _ivmo = value; }
        }
        public CustomerController(IViewModelOperator ivmo)
        {
            IVMO = ivmo;
        }
        #endregion

        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            //ContacterViewModel convm1 = new ContacterViewModel() { Id = 1, Name = "contacter1", Telephones = "aaaa1111" };
            //ContacterViewModel convm2 = new ContacterViewModel() { Id = 2, Name = "contacter2", Telephones = "bbbb2222" };
            //ContacterViewModel convm3 = new ContacterViewModel() { Id = 3, Name = "contacter3", Telephones = "cccc3333" };
            //ContacterViewModel convm4 = new ContacterViewModel() { Id = 4, Name = "contacter4", Telephones = "dddd2222" };

            //List<ContacterViewModel> conlist1 = new List<ContacterViewModel>();
            //List<ContacterViewModel> conlist2 = new List<ContacterViewModel>();
            //conlist1.Add(convm1);
            //conlist1.Add(convm2);
            //conlist2.Add(convm3);
            //conlist2.Add(convm4);

            //CatalogsViewModel catvm1 = new CatalogsViewModel() { Id = 1, Name = "catalog1", Description = "des1" };
            //CatalogsViewModel catvm2 = new CatalogsViewModel() { Id = 2, Name = "catalog2", Description = "des2" };

            //CustomerViewModel cusvm1 = new CustomerViewModel() { Id = 1, Name = "customer1", Address = "address1", Description = "des1", Catalog = catvm1, Contacters = conlist1, Credit = "ok" };
            //CustomerViewModel cusvm2 = new CustomerViewModel() { Id = 2, Name = "customer2", Address = "address2", Description = "des2", Catalog = catvm2, Contacters = conlist2, Credit = "normal" };

            //List<CustomerViewModel> cuslist = new List<CustomerViewModel>();
            //cuslist.Add(cusvm1);
            //cuslist.Add(cusvm2);

            return Request.CreateResponse(HttpStatusCode.OK, IVMO.GetCustomers());
        }

        [Route("{Id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int Id)
        {
            if (IVMO.DeleteCustomer(Id))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "");
            }
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] CustomerViewModel cvm)
        {
            if(IVMO.InsertCustomer(ref cvm))
            {
                return Request.CreateResponse(HttpStatusCode.OK, cvm);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "");
            }
        }

        [Route("{Id:int}")]
        [HttpPut]
        public HttpResponseMessage Put(int Id, [FromBody] CustomerViewModel cvm)
        {
            if (IVMO.UpdateCustomer(Id, ref cvm))
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
