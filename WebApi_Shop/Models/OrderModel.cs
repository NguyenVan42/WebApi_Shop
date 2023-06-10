using System;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi_Shop.Data;

namespace WebApi_Shop.Models
{
    public class OrderModel
    {
        public DateTime OrderDate { get; set; }

        public string DeliveryAddress { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public string ReferenceCode { get; set; }

        public DateTime? PaymentTime { get; set; }

        public Guid PaymentMethodId { get; set; }

        public Guid ShipperMethodId { get; set; }

        public Guid ShipperId { get; set; }

        public Guid CustomerId { get; set; }
    }
}
