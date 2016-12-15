using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ERPWeb.ViewModels;

namespace ERPWeb.Api.Controllers
{
    public class ProductsController : ApiController
    {
        [HttpGet]
        [Route("api/Products")]
        public HttpResponseMessage GetAll()
        {
            List<ProductViewModel> productList = new List<ProductViewModel>();
            productList.Add(new ProductViewModel() { Id = 1, Name = "Product1", Size = 50, Count = 1000 });
            productList.Add(new ProductViewModel() { Id = 2, Name = "Product2", Size = 57, Count = 1000 });
           // return Request.CreateErrorResponse(HttpStatusCode.NotFound,"not found");
            return Request.CreateResponse(HttpStatusCode.OK, productList);
        }

        [HttpGet]
        [Route("api/Products/{Id}")]
        public HttpResponseMessage Get(int Id)
        {
            ProductViewModel pvm = new ProductViewModel() { Id = 2, Name = "Product2", Size = 57, Count = 1000 };
            return Request.CreateResponse(HttpStatusCode.OK, pvm);
        }

        [HttpPatch]
        [HttpPut]
        [Route("api/Products/{Id}")]
        public HttpResponseMessage Put(int Id,[FromBody] ProductViewModel updatedProduct)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotFound,"errror");
            //updatedProduct.Name = "OK";
            //return Request.CreateResponse(HttpStatusCode.OK, updatedProduct);
        }

        [HttpPost]
        [Route("api/Products")]
        public HttpResponseMessage Post([FromBody] ProductViewModel pvm)
        {
            pvm.Id = 3;
            pvm.Name = "Ok";
            return Request.CreateResponse(HttpStatusCode.OK, pvm);
        }

        [HttpDelete]
        [Route("api/Products/{Id}",Name ="test")]
        public HttpResponseMessage Delete(int Id)
        {
            if(Id==1)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "error");
            }
        }
    }
}
