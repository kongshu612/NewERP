using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPWeb.Controllers
{
    public class OrderListController : Controller
    {
        // GET: OrderList
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetOrderList()
        {
            return View("OrderListView");
        }
    }
}