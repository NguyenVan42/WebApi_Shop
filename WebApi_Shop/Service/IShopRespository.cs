using System.Collections.Generic;
using WebApi_Shop.Models;

namespace WebApi_Shop.Service
{
    public interface IShopRespository
    {
        List<ShopModel> GetAll();
    }
}
