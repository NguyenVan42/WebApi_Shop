using System;

namespace WebApi_Shop.Models
{
    public class CategoryModel
    {
        public string CategoryName { get; set; }
    }
    public class CategoryVM : CategoryModel
    {
        public Guid Id { get; set; }
    }
}
