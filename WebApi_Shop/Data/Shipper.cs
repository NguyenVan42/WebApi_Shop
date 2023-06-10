using System;
using System.Collections.Generic;

namespace WebApi_Shop.Data
{
    public class Shipper
    {
        public Guid Id { get; set; }

        public string ShipperName { get; set; }

        public int Phone { get; set; }

        public string ShipperImg { get; set; }

        public DateTime Bithday { get; set; }

        public int Rating { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
