using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_Shop.Data
{
    public class OrderDetail
    {
        public int Quantity { get; set; }

        public double PriceCurrent { get; set; }

        public Guid OrderId { get; set; }
        [ForeignKey("OrderId")]

        public Guid ItemId { get; set; }
        [ForeignKey("ItemId")]

        public Order order { get; set; }

        public Item item { get; set; }
    }
}

