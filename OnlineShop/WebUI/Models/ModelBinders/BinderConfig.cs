using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Domain.Concrete.ProductEntities;
using WebUI.Models.PageModels;

namespace WebUI.Models.ModelBinders
{
     public static class BinderConfig<T> where T:new()
     {
          public static T Create(ControllerContext controllerContext, string key)
          {
               T model = default(T);

               if (controllerContext.HttpContext.Session != null)
                    model = (T)controllerContext.HttpContext.Session[key];

               if (model == null)
               {
                    model = new T();

                    if (controllerContext.HttpContext.Session != null)
                         controllerContext.HttpContext.Session[key] = model;
               }
               return model;
          }
     }
}
