using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Concrete;
using Domain.Concrete.ProductEntities;

namespace Domain.Abstract
{
     public interface IShopRepository
     {
         ShopDBContext Products { get; }
     }
}
