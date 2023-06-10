using System;
using System.Collections.Generic;

namespace WebApi_Shop.Data
{
    public class Category
    {
        public Guid Id { get; set; }

        public string CategoryName { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
