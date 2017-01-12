using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Contacter
    {
        public int ContacterId { get; set; }
        public string Name { get; set; }
        public string Telephones { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Contacter()
        {
            Orders = new List<Order>();
            Customer = new Customer();
        }
    }
}
