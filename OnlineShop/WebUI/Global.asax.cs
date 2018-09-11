using System.Web.Mvc;
using System.Web.Routing;
using Domain.Concrete;
using WebUI.Models.ModelBinders;
using WebUI.Models.ModelBinders.ProductViews;
using WebUI.Models.PageModels;
using WebUI.Models.PageModels.Admin;

namespace WebUI
{
     public class MvcApplication : System.Web.HttpApplication
     {
          protected void Application_Start()
          {
               AreaRegistration.RegisterAllAreas();
               RouteConfig.RegisterRoutes(RouteTable.Routes);

               ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());

               ModelBinders.Binders.Add(typeof(ASCViewModel), new ASCModelBinder());
               ModelBinders.Binders.Add(typeof(CaseViewModel), new CaseModelBinder());
               ModelBinders.Binders.Add(typeof(ProductViewModel), new ProductModelBinder());

               ModelBinders.Binders.Add(typeof(OrdersViewModel), new OrdersModelBinder());
          }
     }
}
