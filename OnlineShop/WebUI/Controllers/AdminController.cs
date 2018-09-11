using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Concrete;
using Domain.Concrete.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebUI.Models;
using WebUI.Models.PageModels;
using WebUI.Models.PageModels.Admin;

namespace WebUI.Controllers
{
     public class AdminController : Controller
    {
          IOrderRepository repository;

          ApplicationUserManager userManager
          {
               get
               {
                    return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
               }
          }

          public AdminController(IOrderRepository repository)
          {
               this.repository = repository;
          }

          // GET: AdminPanel/Order
          public ActionResult Index()
          {
               return View();
          }

          public ActionResult GetList(OrdersViewModel model, int page = 1)
          {
               model.Orders = repository.Orders.ToList();
               model.PageInfo.CurrentPage = page;

               return PartialView("ListPartialView", model);
          }

          public ActionResult GetOrder(int id)
          {
               Order order = repository.Orders.FirstOrDefault(o => o.Id == id);

               AdminOrder model = new AdminOrder();

               if (order != null)
               {
                    model.Number = order.Id;
                    model.Cost = order.TotalCost;
                    model.CustomerInformation = InformationConverter.StringToUserProfile(order.CustomerInfrom);
                    model.Description = InformationConverter.StringToDescription(order.Description);
               }

               return View(model);
          }

          public async Task<ActionResult> GetUser(string id)
          {
               ApplicationUser user = await userManager.FindByIdAsync(id);

               UserViewModel model = new UserViewModel();

               if (user.UserProfile != null)
                    model.Profile = user.UserProfile;
               else
                    model.Profile = new UserProfile() { Id = user.Id };

               var tempOrders = new List<OrderForModel>();
               foreach (var item in user.Orders)
                    tempOrders.Add(new OrderForModel() { Number = item.Id, Cost = item.TotalCost, DateTime = item.DateTime });

               model.Orders = tempOrders;

               return View(model);
          }
     }
}