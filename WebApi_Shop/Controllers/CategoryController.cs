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
    public class CategoryController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CategoryController(MyDbContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var category = _context.Categories.ToList();
            return Ok(category);
        }

        [HttpPost]
        public IActionResult CreatNew(CategoryModel model)
        {
            try
            {
                var category = new Category
                {
                    CategoryName = model.CategoryName
                };
                if(category.CategoryName == "")
                {
                    return BadRequest();
                }
                else
                    _context.Add(category);
                    _context.SaveChanges();
                    return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Update(string id, CategoryModel categoyUpdate)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == Guid.Parse(id));
            if(id == null)
            {
                return NotFound();
            }
            if(id != category.Id.ToString())
            {
                return BadRequest();
            }
            category.CategoryName = categoyUpdate.CategoryName;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == Guid.Parse(id));
            if(id == null)
            {
                return NotFound();
            }
            if(id == category.Id.ToString())
            {
                return BadRequest();
            }
            _context.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
