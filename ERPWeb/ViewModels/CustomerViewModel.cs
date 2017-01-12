using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWeb.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public  CatalogsViewModel Catalog { get; set; }
        public  string Credit { get; set; }
        public List<ContacterViewModel> Contacters { get; set; }

        public CustomerViewModel()
        {
            Contacters = new List<ContacterViewModel>();
        }
    }
}