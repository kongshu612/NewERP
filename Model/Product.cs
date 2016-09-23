using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }
        public int Count { get; set; }
        public ICollection<Order> Orders { get; set; }

        public Product()
        {
            Orders = new List<Order>();
        }
    }
}
