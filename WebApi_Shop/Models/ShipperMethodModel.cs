using System;

namespace WebApi_Shop.Models
{
    public class ShipperMethodModel
    {
        public string MethodName { get; set; }

        public double ShipperPrice { get; set; }
    }
    public class ShipperMethodVM : ShipperMethodModel
    {
        public Guid Id { get; set; }
    }
}
