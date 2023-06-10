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
    public class CommentController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CommentController(MyDbContext context) { 
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var comment = _context.Comments.ToList();
            return Ok(comment);
        }

        [HttpPost]
        public IActionResult CreateNew(CommentModel model)
        {
            try
            {
                var comment = new Comment
                {
                    Rating = model.Rating,
                    Comments = model.Comments,
                    ItemId = model.ItemId,
                };
                _context.Add(comment);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult Update(string id, CommentModel commentUpdate)
        {
            var comment = _context.Comments.SingleOrDefault(c => c.Id == Guid.Parse(id));
            if(id== null)
            {
                return NotFound();
            }
            if(id != comment.Id.ToString())
            {
                return BadRequest();
            }
            else
            {
                comment.Rating = commentUpdate.Rating;
                comment.Comments = commentUpdate.Comments;
                comment.ItemId = commentUpdate.ItemId;
                _context.SaveChanges();
                return NoContent();
            }
        }
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var comment = _context.Comments.SingleOrDefault(c => c.Id == Guid.Parse(id));
            if(id == null) 
            {
                return NotFound();
            }
            if(id != comment.Id.ToString())
            {
                return BadRequest();
            }
            else
            {
                _context.Remove(comment);
                _context.SaveChanges();
                return NoContent();
            }
        }
    }
}
