using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Odbc;

namespace WebApi_Shop.Data
{
    public enum OrderStatus
    {
        New = 0, Complete = 1, Cancel = -1
    }
    public enum PaymentStatus
    {
        Unpaid = 0, Complete = 1
    }
    public class Order
    {

        public Guid Id { get; set; }

        public DateTime OrderDate { get; set; }

        public string DeliveryAddress { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public string ReferenceCode { get; set; }

        public DateTime? PaymentTime { get; set; }

        public Guid PaymentMethodId { get; set; }
        [ForeignKey("PaymentMethodId")]

        public Guid ShipperMethodId { get; set; }
        [ForeignKey("ShipperMethodId")]

        public Guid ShipperId { get; set; }
        [ForeignKey("ShipperId")]

        public Guid CustomerId { get; set; }
        [ForeignKey("CustomerId")]

        //Relationship
        public PaymentMethod PaymentMethod { get; set; }

        public ShipperMethod ShipperMethod { get; set; }

        public Shipper Shipper { get; set; }

        public Customer Customer { get; set; }

        public ICollection<OrderDetail> oderdetails { get; set; }

    }
}
