
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApi_Shop.Data;
using WebApi_Shop.Models;

namespace WebApi_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ShopController(MyDbContext context) { 
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var shop = _context.Shops.ToList();
            return Ok(shop);
        }
        [HttpPost]
        public IActionResult createnew(ShopModel model) {
            try
            {
                var shop = new Shop { 
                    ShopName = model.ShopName,
                    Address = model.Address,
                    Phone = model.Phone,
                    Rating = model.Rating,
                    product = model.product,
                    ShopLink = model.ShopLink,
                };
                _context.Add(shop);
                _context.SaveChanges();
                return Ok(shop);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
