﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Description { get; set; }
   //     public DateTime CreatedTime { get; set; }
  //      public DateTime SendedTime { get; set; }
        public string ExpressId { get; set; }
        public string DestinationAddress { get; set; }
        public bool IsPayed { get; set; }
   //     public int CustomerId { get; set; }
   //     public Customer Customer { get; set; }
        public int ContacterId { get; set; }
        public Contacter Contacter { get; set; }
        public double TotalPrice { get; set; }
        public double Count { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}