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
    public class OrderDetailController : ControllerBase
    {
        private readonly MyDbContext _context;

        public OrderDetailController(MyDbContext context) {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var orderDetail = _context.OrderDetails.ToList();
            return Ok(orderDetail);
        }

        [HttpPost]
        public IActionResult CreateNew(OrderDetailModel model) 
        {
            try
            {
                var orderDetail = new OrderDetail
                {
                    Quantity = model.Quantity,
                    PriceCurrent = model.PriceCurrent,
                    ItemId = model.ItemId,
                    OrderId = model.OrderId,
                };
                _context.Add(orderDetail);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult Update(string id, OrderDetailModel orderDetailUpdate)
        {
            var orderdetail = _context.OrderDetails.SingleOrDefault(o => o.ItemId == Guid.Parse(id));
            if(id == null)
            {
                return NotFound();
            }
            if(id != orderdetail.ItemId.ToString())
            {
                return BadRequest();
            }
            else
            {
                orderdetail.PriceCurrent = orderDetailUpdate.PriceCurrent;
                orderdetail.Quantity = orderDetailUpdate.Quantity;
                orderdetail.OrderId = orderDetailUpdate.OrderId;
                orderdetail.ItemId = orderDetailUpdate.ItemId;
                _context.SaveChanges();
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var orderDetail = _context.OrderDetails.SingleOrDefault(o => o.ItemId == Guid.Parse(id));
            if(id == null)
            {
                return NotFound();
            }
            if(id != orderDetail.ItemId.ToString())
            {
                return BadRequest();
            }
            else
            {
                _context.OrderDetails.Remove(orderDetail);
                _context.SaveChanges();
                return NoContent();
            }
        }
    }
}
