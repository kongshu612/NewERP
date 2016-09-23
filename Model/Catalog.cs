using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Catalog
    {
        public int CatalogId { get; set; }
        public string CatalogName { get; set; }
        public string Description { get; set; }
        public ICollection<Customer> Customers { get; set; }

        public Catalog()
        {
            Customers = new List<Customer>();
        }
    }
}
