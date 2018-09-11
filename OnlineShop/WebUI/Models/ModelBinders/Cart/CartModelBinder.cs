using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Concrete;

namespace WebUI.Models.ModelBinders
{
     public class CartModelBinder:IModelBinder
     {
          string key = "Cart";

          public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
          {
               return BinderConfig<Cart>.Create(controllerContext, key);
          }         
     }
}