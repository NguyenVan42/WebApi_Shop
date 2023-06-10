using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace WebApi_Shop.Models
{
    public class ItemModel
    {
        public string ItemName { get; set; }

        public double Price { get; set; }

        public int Stock { get; set; }

        public string ItemImg { get; set; }

        public string Description { get; set; }

        public string CountryOfOrigin { get; set; }

        public Guid ShopId { get; set; }

        public Guid CategoryId { get; set; }
    }
}
