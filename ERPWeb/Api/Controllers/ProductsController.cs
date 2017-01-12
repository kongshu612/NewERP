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
    public class ProductsController : ApiController
    {
        private IViewModelOperator _ivmo;
        public IViewModelOperator IVMO
        {
            get { return _ivmo; }
            set { _ivmo = value; }
        }
        public ProductsController(IViewModelOperator ivmo)
        {
            IVMO = ivmo;
        }


        [HttpGet]
        [Route("api/Products")]
        public HttpResponseMessage GetAll()
        {
           // List<ProductViewModel> productList = new List<ProductViewModel>();
           // productList = IVMO.GetProducts();
           // productList.Add(new ProductViewModel() { Id = 1, Name = "Product1", Size = 50, Count = 1000 });
           // productList.Add(new ProductViewModel() { Id = 2, Name = "Product2", Size = 57, Count = 1000 });
           //// return Request.CreateErrorResponse(HttpStatusCode.NotFound,"not found");
            return Request.CreateResponse(HttpStatusCode.OK, IVMO.GetProducts());
        }

        [HttpGet]
        [Route("api/Products/{Id}")]
        public HttpResponseMessage Get(int Id)
        {
            //ProductViewModel pvm = new ProductViewModel() { Id = 2, Name = "Product2", Size = 57, Count = 1000 };
            return Request.CreateResponse(HttpStatusCode.OK, IVMO.GetProduct(Id));
        }

        [HttpPatch]
        [HttpPut]
        [Route("api/Products/{Id}")]
        public HttpResponseMessage Put(int Id,[FromBody] ProductViewModel updatedProduct)
        {
            if (IVMO.UpdateProduct(Id,ref updatedProduct))
            {
                return Request.CreateResponse(HttpStatusCode.OK, updatedProduct);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "error occur");
            }
        }

        [HttpPost]
        [Route("api/Products")]
        public HttpResponseMessage Post([FromBody] ProductViewModel pvm)
        {
            if(IVMO.InsertProduct(ref pvm))
            {
                return Request.CreateResponse(HttpStatusCode.OK, pvm);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "insert to DB error");
            }
        }

        [HttpDelete]
        [Route("api/Products/{Id}",Name ="test")]
        public HttpResponseMessage Delete(int Id)
        {
            if (IVMO.DeleteProduct(Id))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "server error");
            }
        }
    }
}
