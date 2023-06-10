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
    public class ItemController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ItemController(MyDbContext context) {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var item = _context.Items.ToList();
            return Ok(item);
        }
        [HttpPost]
        public IActionResult CreateNew(ItemModel model)
        {
            try
            {
                var item = new Item
                {
                    ItemName = model.ItemName,
                    Price = model.Price,
                    Stock = model.Stock,
                    ItemImg = model.ItemImg,
                    Description = model.Description,
                    CountryOfOrigin = model.CountryOfOrigin,
                    ShopId = model.ShopId,
                    CategoryId = model.CategoryId,
                };
                _context.Add(item);
                _context.SaveChanges();
                return NoContent();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult Update(string id, ItemModel itemUpdate)
        {
            var item = _context.Items.SingleOrDefault(i => i.Id == Guid.Parse(id));
            if(id == null)
            {
                return NotFound();
            }
            if(id != item.Id.ToString())
            {
                return BadRequest();
            }
            item.ItemName = itemUpdate.ItemName;
            item.Price = itemUpdate.Price;
            item.Stock = itemUpdate.Stock;
            item.ItemImg = itemUpdate.ItemImg;
            item.Description = itemUpdate.Description;
            item.CountryOfOrigin = itemUpdate.CountryOfOrigin;
            item.ShopId = itemUpdate.ShopId;
            item.CategoryId = itemUpdate.CategoryId;
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var item = _context.Items.SingleOrDefault(i => i.Id == Guid.Parse(id));
            if(id == null)
            {
                return NotFound();
            }
            if(id != item.Id.ToString())
            {
                return BadRequest();
            }
            else
            {
                _context.Remove(item);
                _context.SaveChanges();
                return NoContent();
            }
        }
    }
}
