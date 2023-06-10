using System.Collections.Generic;
using WebApi_Shop.Data;

namespace WebApi_Shop.Models
{
    public class ShopModel
    {
        public string ShopName { get; set; }

        public string Address { get; set; }

        public int Phone { get; set; }

        public int Rating { get; set; }

        public int product { get; set; }

        public string ShopLink { get; set; }
    }
}
