using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
     public interface IProductRepository<T>
     {
          IEnumerable<T> Product { get; }

          void Save(T product);

          T Delete(int id);
     }
}
