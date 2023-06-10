using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApi_Shop.Data;
using WebApi_Shop.Models;

namespace WebApi_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly MyDbContext _context;

        public OrderController(MyDbContext context) { 
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var order = _context.Orders.ToList();
            return Ok(order);
        }
        [HttpPost]
        public IActionResult CreateNew(OrderModel model)
        {
            try
            {
                var order = new Order
                {
                    OrderDate = model.OrderDate,
                    DeliveryAddress = model.DeliveryAddress,
                    OrderStatus = model.OrderStatus,
                    PaymentStatus = model.PaymentStatus,
                    ReferenceCode = model.ReferenceCode,
                    PaymentTime = model.PaymentTime,
                    PaymentMethodId = model.PaymentMethodId,
                    ShipperMethodId = model.ShipperMethodId,
                    ShipperId = model.ShipperId,
                    CustomerId = model.CustomerId,
                };
                _context.Add(order);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult Update(string id, OrderModel orderUpdate)
        {
            var order = _context.Orders.SingleOrDefault(c => c.Id == Guid.Parse(id));
            if(id == null)
            {
                return NotFound();
            }
            if(id != order.Id.ToString())
            {
                return BadRequest();
            }
            else
            {
                order.OrderDate = orderUpdate.OrderDate;
                order.DeliveryAddress = orderUpdate.DeliveryAddress;
                order.OrderStatus = orderUpdate.OrderStatus;
                order.PaymentStatus = orderUpdate.PaymentStatus;
                order.ReferenceCode = orderUpdate.ReferenceCode;
                order.PaymentTime = orderUpdate.PaymentTime;
                order.PaymentMethodId = orderUpdate.PaymentMethodId;
                order.ShipperMethodId = orderUpdate.ShipperMethodId;
                order.ShipperId = orderUpdate.ShipperId;
                order.CustomerId = orderUpdate.CustomerId;
                _context.SaveChanges();
                return NoContent();
            }
        }
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var order = _context.Orders.SingleOrDefault(o => o.Id == Guid.Parse(id));
            if(id == null)
            {
                return NotFound();
            }
            if(id != order.Id.ToString())
            {
                return BadRequest();
            }
            else
            {
                _context.Remove(order);
                _context.SaveChanges();
                return NoContent();
            }
        }
    }
}
