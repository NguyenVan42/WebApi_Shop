using System;
using System.Collections.Generic;

namespace WebApi_Shop.Data
{
    public class Shop
    {
        public Guid Id { get; set; }

        public string ShopName { get; set; }

        public string Address { get; set; }

        public int Phone { get; set; }

        public int Rating { get; set; }

        public int product { get; set; }

        public string ShopLink { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
