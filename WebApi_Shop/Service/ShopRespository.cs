using System.Collections.Generic;
using WebApi_Shop.Data;
using WebApi_Shop.Models;

namespace WebApi_Shop.Service
{
    public class ShopRespository : IShopRespository
    {
        private readonly MyDbContext _context;

        public ShopRespository(MyDbContext context) 
        { 
            _context = context;
        }
        List<ShopModel> IShopRespository.GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
