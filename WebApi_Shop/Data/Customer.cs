using System;
using System.Collections;
using System.Collections.Generic;

namespace WebApi_Shop.Data
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string CustomerName { get; set; }

        public string CustomerFullname { get; set; }

        public string Usename { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }

        public DateTime Bithday { get; set; }

        public string Gender { get; set; }

        // lay ra cac danh sanh Order
        public virtual ICollection<Order> orders { get; set; }

    }
}
