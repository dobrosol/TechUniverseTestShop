using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models.PageModels;

namespace WebUI.Models.ModelBinders
{
     public class ConfirmModelBinder : IModelBinder
     {
          string key = "Confirm";

          public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
          {
               return BinderConfig<CartViewModel>.Create(controllerContext, key);
          }

     }
}