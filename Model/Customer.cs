using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int CatalogId { get; set; }
        public Catalog Catalog { get; set; }
        public ICollection<Contacter> Contacters { get; set; }
        public Credit Credit { get; set; }

        public Customer()
        {
            Contacters = new List<Contacter>();
            Catalog = new Catalog();
            Credit = new Credit();
        }
    }
}
