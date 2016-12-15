using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWeb.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string Description { get; set; }
        public string ExpressId { get; set; }
        public string DestinationAddress { get; set; }
        public string CreatedTime { get; set; }
        public string SentTime { get; set; }
        public bool IsPayed { get; set; }
        public double TotalPrice { get; set; }
        public double Count { get; set; }
        public ProductViewModel Product { get; set; }
        public CustomerViewModel Customer { get; set; }
        public ContacterViewModel Contacter { get; set; }
    }
}