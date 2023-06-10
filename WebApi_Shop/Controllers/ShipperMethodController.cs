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
    public class ShipperMethodController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ShipperMethodController(MyDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var shippermethod = _context.ShipperMethods.ToList();
            return Ok(shippermethod);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var shippermethod = _context.ShipperMethods.SingleOrDefault(h => h.Id == Guid.Parse(id));
            if(shippermethod != null) {
                return Ok(shippermethod);
            }
            else
                return BadRequest();
        }

        [HttpPost]
        public IActionResult CreateNew(ShipperMethodModel model) 
        {
            try
            {
                var shippermethod = new ShipperMethod
                {
                    MethodName = model.MethodName,
                    ShipperPrice = model.ShipperPrice,
                };
                _context.Add(shippermethod);
                _context.SaveChanges();
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Update(string id, ShipperMethodVM SMUpdate)
        {
            var shippermethod = _context.ShipperMethods.SingleOrDefault(h => h.Id == Guid.Parse(id));
            if(id == null)
            {
                return NotFound();
            }
            if(id != shippermethod.Id.ToString())
            {
                return BadRequest();
            }
            shippermethod.MethodName = SMUpdate.MethodName;
            shippermethod.ShipperPrice = SMUpdate.ShipperPrice;
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var shippermethod = _context.ShipperMethods.SingleOrDefault(h => h.Id == Guid.Parse(id));
            if(id == null)
            {
                return NotFound();
            }
            if(id != shippermethod.Id.ToString())
            {
                return BadRequest();
            }
            _context.Remove(shippermethod);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
