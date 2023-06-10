using System;
using System.Collections;
using System.Collections.Generic;

namespace WebApi_Shop.Data
{
    public class PaymentMethod
    {
        public Guid Id { get; set; }

        public string MethodName { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
