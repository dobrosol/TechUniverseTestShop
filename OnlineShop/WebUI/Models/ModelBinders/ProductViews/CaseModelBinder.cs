using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Concrete.ProductEntities;
using WebUI.Models.PageModels;

namespace WebUI.Models.ModelBinders.ProductViews
{
     public class CaseModelBinder : IModelBinder
     {
          string key = "CaseModel";

          public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
          {
               CaseViewModel model = BinderConfig<CaseViewModel>.Create(controllerContext, key);

               model.IsAdministrator = controllerContext.HttpContext.User.IsInRole("Admin") ? true : false;

               return model;
          }
     }
}