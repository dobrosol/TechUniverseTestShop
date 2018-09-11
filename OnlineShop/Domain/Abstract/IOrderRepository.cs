using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Concrete;
using Domain.Concrete.Identity;

namespace Domain.Abstract
{
     public interface IOrderRepository
     {
          IEnumerable<Order> Orders { get; }

          IEnumerable<UserProfile> Profiles { get; }
     }
}
