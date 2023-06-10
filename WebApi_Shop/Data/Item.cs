using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_Shop.Data
{
    public class Item
    {
        public Guid Id { get; set; }

        public string ItemName { get; set; }

        public double Price { get; set; }

        public int Stock { get; set; }

        public string ItemImg { get; set; }

        public string Description { get; set; }

        public string CountryOfOrigin { get; set; }

        public Guid ShopId { get; set; }
        [ForeignKey("ShopId")]

        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]

        public Shop shop { get; set; }

        public Category category { get; set; }

        public ICollection<OrderDetail> OrderDetails
        {
            get; set;

        }
    }
}
