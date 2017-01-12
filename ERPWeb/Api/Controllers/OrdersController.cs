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
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        #region Members and Constructor
        private IViewModelOperator _ivmo;
        public IViewModelOperator IVMO
        {
            get { return _ivmo; }
            set { _ivmo = value; }
        }
        public OrdersController(IViewModelOperator ivmo)
        {
            IVMO = ivmo;
        }
        #endregion

        [HttpGet]
        public HttpResponseMessage Get()
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

            //List<OrderViewModel> ovmList = new List<OrderViewModel>();
            //OrderViewModel ovm1 = new OrderViewModel()
            //{
            //    OrderId = 1,
            //    Description = "OrderListAdded1",
            //    ExpressId = "express",
            //    DestinationAddress = "DestinationAdd",
            //    CreatedTime = DateTime.Today,
            //    SentTime = null,
            //    IsPayed = false,
            //    TotalPrice = 10000,
            //    Count = 100,
            //    Product = new ProductViewModel() { Id = 1, Name = "Product1", Size = 50, Count = 1000 },
            //    Customer = cusvm1,
            //    Contacter = convm1
            //};
            //OrderViewModel ovm2 = new OrderViewModel()
            //{
            //    OrderId = 2,
            //    Description = "OrderListAdded2",
            //    ExpressId = "express",
            //    DestinationAddress = "DestinationAdd",
            //    CreatedTime = DateTime.Today,
            //    SentTime = null,
            //    IsPayed = false,
            //    TotalPrice = 10000,
            //    Count = 100,
            //    Product = new ProductViewModel() { Id = 2, Name = "Product2", Size = 50, Count = 1000 },
            //    Customer = cusvm2,
            //    Contacter = convm3
            //};
            //ovmList.Add(ovm1);
            //ovmList.Add(ovm2);
            return Request.CreateResponse(HttpStatusCode.OK,IVMO.GetOrders());
        }

        [HttpPut]
        [Route("{Id}")]
        public HttpResponseMessage Put(int Id,[FromBody]OrderViewModel ovm)
        {
            if (IVMO.UpdateOrder(Id, ref ovm))
            {
                return Request.CreateResponse(HttpStatusCode.OK, ovm);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "");
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        public HttpResponseMessage Delete([FromUri]int Id)
        {
            if (IVMO.DeleteOrder(Id))
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "");
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]OrderViewModel ovm)
        {
            //OrderViewModel ovm = new OrderViewModel()
            //{
            //    OrderId = 3,
            //    Description = "",
            //    ExpressId = "",
            //    DestinationAddress = "",
            //    CreatedTime = DateTime.Today,
            //    SentTime = null,
            //    IsPayed = false,
            //    TotalPrice = 0,
            //    Count = 0,
            //    Product = new ProductViewModel(),
            //    Customer = new CustomerViewModel(),
            //    Contacter = new ContacterViewModel()
            //};
            if(IVMO.InsertOrder(ref ovm))
            {
                return Request.CreateResponse(HttpStatusCode.OK, ovm);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "");
            }
        }
    }
}
