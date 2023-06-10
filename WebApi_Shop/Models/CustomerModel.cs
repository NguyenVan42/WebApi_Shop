using System;

namespace WebApi_Shop.Models
{
    public class CustomerModel  
    {
        public string CustomerName { get; set; }

        public string CustomerFullname { get; set; }

        public string Usename { get; set; }

        public string Password { get; set; }

        public string Address { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }

        public DateTime Bithday { get; set; }

        public string Gender { get; set; }
    }
    public class CustomerVM : CustomerModel { 
        public Guid Id { get; set; }
    }
}
