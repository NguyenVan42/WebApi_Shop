using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApi_Shop.Data;
using WebApi_Shop.Models;

namespace WebApi_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly MyDbContext _context;

        public PaymentMethodController(MyDbContext context) { 
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var paymentMethod = _context.PaymentMethods.ToList();
            return Ok(paymentMethod);
        }

        [HttpPost]
        public IActionResult CreateNew(PaymentMethodModel model) 
        {
            try
            {
                var paymentMethod = new PaymentMethod
                {
                    MethodName = model.MethodName,
                };
                _context.Add(paymentMethod);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult Update(string id, PaymentMethodModel model)
        {
            var paymentMethod = _context.PaymentMethods.SingleOrDefault(p => p.Id == Guid.Parse(id));
            if(id == null)
            {
                return NotFound();
            }
            if(id != paymentMethod.Id.ToString())
            {
                return BadRequest();
            }
            paymentMethod.MethodName = model.MethodName;
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var orderDetail = _context.PaymentMethods.SingleOrDefault(o => o.Id == Guid.Parse(id));
            if(id == null)
            {
                return NotFound();
            }
            if(id != orderDetail.Id.ToString())
            {
                return BadRequest();
            }
            else
            {
                _context.Remove(orderDetail);
                _context.SaveChanges();
                return NoContent();
            }
        }
    }
}
