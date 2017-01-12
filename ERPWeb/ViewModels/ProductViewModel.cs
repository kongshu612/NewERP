using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWeb.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }
        public int Count { get; set; }
    }
}