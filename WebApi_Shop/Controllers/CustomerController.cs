using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApi_Shop.Data;
using WebApi_Shop.Models;
//using CustomerVM = WebApi_Shop.Data.CustomerVM;

namespace WebApi_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CustomerController(MyDbContext context) {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var customer = _context.Customers.ToList();
            return Ok(customer);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var customer = _context.Customers.SingleOrDefault(cus => cus.Id == Guid.Parse(id));
            if (customer != null) {
                return Ok(customer);
            }
            else
                return NotFound();
        }
        [HttpPost]
        public IActionResult Createnew(CustomerModel model) 
        {
            try
            {
                var customer = new Customer
                {
                    CustomerName = model.CustomerName,
                    CustomerFullname = model.CustomerFullname,
                    Usename = model.Usename,
                    Password = model.Password,
                    Address = model.Address,
                    Phone = model.Phone,
                    Email = model.Email,
                    Bithday = model.Bithday,
                    Gender = model.Gender
                };
                _context.Add(customer);
                _context.SaveChanges();
                return Ok(customer);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(string id, CustomerVM CustomerUpdate)
        {
            try
            {
                var customer = _context.Customers.SingleOrDefault(cus => cus.Id == Guid.Parse(id));
                if(customer == null)
                {
                    return NotFound();
                }
                if(id != customer.Id.ToString())
                {
                    return BadRequest();
                }
                customer.CustomerName = CustomerUpdate.CustomerName;
                customer.CustomerFullname = CustomerUpdate.CustomerFullname;
                customer.Usename = CustomerUpdate.Usename;
                customer.Password = CustomerUpdate.Password;
                customer.Address = CustomerUpdate.Address;
                customer.Phone = CustomerUpdate.Phone;
                customer.Email = CustomerUpdate.Email;
                customer.Bithday = CustomerUpdate.Bithday;
                customer.Gender = CustomerUpdate.Gender;
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
            var customer = _context.Customers.SingleOrDefault(cus => cus.Id == Guid.Parse(id));
            if(customer == null)
            {
                return NotFound();
            }
            if(id != customer.Id.ToString())
            {
                return BadRequest();
            }
            _context.Remove(customer);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
