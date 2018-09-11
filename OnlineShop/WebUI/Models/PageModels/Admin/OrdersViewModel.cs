using System.Collections.Generic;
using System.Linq;
using Domain.Concrete;

namespace WebUI.Models.PageModels.Admin
{
     public class OrdersViewModel
     {
          IEnumerable<Order> orders = null;

          public OrdersViewModel()
          {
               if (PageInfo == null)
                    PageInfo = new PageInfo(15);
          }

          public IEnumerable<Order> Orders
          {
               get
               {
                    var result = orders;

                    PageInfo.TotalItems = result.Count();

                    return result.Skip((PageInfo.CurrentPage - 1) * PageInfo.PageSize).Take(PageInfo.PageSize);
               }
               set
               {
                    orders = value;
               }
          }

          public PageInfo PageInfo { get; set; }
     }
}