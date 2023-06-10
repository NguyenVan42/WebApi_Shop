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
    public class ShipperController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ShipperController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var shipper = _context.Shippers.ToList();
            return Ok(shipper);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var shipper = _context.Shippers.SingleOrDefault(h => h.Id == Guid.Parse(id));
            if(shipper != null)
            {
                return Ok(shipper);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public IActionResult CreateNew(ShipperModel model)
        {
            try
            {
                var shipper = new Shipper
                {
                    ShipperName = model.ShipperName,
                    Phone = model.Phone,
                    ShipperImg = model.ShipperImg,
                    Bithday = model.Bithday,
                    Rating = model.Rating,
                };
                _context.Add(shipper);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult Update(string id, ShipperVM ShipperUpdate)
        {
            try
            {
                var shipper = _context.Shippers.SingleOrDefault(h => h.Id == Guid.Parse(id));
                if (shipper == null)
                {
                    return NotFound();
                }
                if (id != shipper.Id.ToString())
                {
                    return BadRequest();
                }
                shipper.ShipperName = ShipperUpdate.ShipperName;
                shipper.Phone = ShipperUpdate.Phone;
                shipper.ShipperImg = ShipperUpdate.ShipperImg;
                shipper.Bithday = ShipperUpdate.Bithday;
                shipper.Rating = ShipperUpdate.Rating;
                _context.SaveChanges();
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public IActionResult Delete(string id) 
        {
            var shipper = _context.Shippers.SingleOrDefault(h => h.Id == Guid.Parse(id));
            if(id == null)
            {
                return NotFound();
            }
            if (id != shipper.Id.ToString()) 
            {
                return BadRequest();
            }
            _context.Remove(shipper);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
