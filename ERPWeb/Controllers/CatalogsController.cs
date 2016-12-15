using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERPWeb.Controllers
{
    public class CatalogsController : Controller
    {
        // GET: CustomerTypes
        public ActionResult Index()
        {
            return View();
        }
        [Route("Catalogs/GetCatalogs")]
        public ActionResult GetCatalogs()
        {
            return View("CatalogsView");
        }
    }
}