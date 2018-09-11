using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Concrete.ProductEntities;

namespace WebUI.Models.PageModels
{
     public class ProductViewModel:AbstractViewModel<Product>
     {
          public ProductViewModel()
          {
               PageInfo.PageSize = 12;
          }

          public string FindExpression { get; set; }
     }
}