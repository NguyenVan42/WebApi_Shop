using System.ComponentModel.DataAnnotations.Schema;
using System;
using WebApi_Shop.Data;

namespace WebApi_Shop.Models
{
    public class OrderDetailModel
    {
        public int Quantity { get; set; }

        public double PriceCurrent { get; set; }

        public Guid OrderId { get; set; }

        public Guid ItemId { get; set; }
    }
}
