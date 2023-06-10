using System;
using System.Collections.Generic;

namespace WebApi_Shop.Data
{
    public class ShipperMethod
    {
        public Guid Id { get; set; }

        public string MethodName { get; set; }

        public double ShipperPrice { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
