using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Concrete.ProductEntities;
using WebUI.Models.PageModels;

namespace WebUI.Models.ModelBinders
{
     public class ProductModelBinder:IModelBinder
     {
          string key = "ProductModel";

          public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
          {
               ProductViewModel model = BinderConfig<ProductViewModel>.Create(controllerContext, key);

               model.IsAdministrator = controllerContext.HttpContext.User.IsInRole("Admin") ? true : false;

               return model;
          }
     }
}