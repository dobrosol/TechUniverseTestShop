using System.Web.Mvc;
using WebUI.Models.PageModels.Admin;

namespace WebUI.Models.ModelBinders
{
     public class OrdersModelBinder : IModelBinder
     {
          string key = "AdminOrders";

          public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
          {
               return BinderConfig<OrdersViewModel>.Create(controllerContext, key);
          }
     }
}