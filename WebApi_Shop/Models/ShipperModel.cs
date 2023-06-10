using System;

namespace WebApi_Shop.Models
{
    public class ShipperModel
    {
        public string ShipperName { get; set; }

        public int Phone { get; set; }

        public string ShipperImg { get; set; }

        public DateTime Bithday { get; set; }

        public int Rating { get; set; }
    }
    public class ShipperVM : ShipperModel {
        public Guid Id { get; set; }
    }
}
