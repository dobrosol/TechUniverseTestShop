using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Domain.Concrete.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using WebUI.Models;
using WebUI.Models.PageModels;

namespace WebUI.Controllers
{
     public class UserController : Controller
     {
          ApplicationUserManager userManager
          {
               get
               {
                    return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
               }
          }

          IAuthenticationManager authManager
          {
               get
               {
                    return HttpContext.GetOwinContext().Authentication;
               }
          }

          [Authorize(Roles = "User")]
          public async Task<ActionResult> Index()
          {
               UserViewModel model = new UserViewModel();

               ApplicationUser user = await userManager.FindByIdAsync(HttpContext.User.Identity.GetUserId());

               if (user.UserProfile == null)
                    user.UserProfile = new UserProfile();

               model.Profile = user.UserProfile;

               var tempOrders = new List<OrderForModel>();
               foreach (var item in user.Orders)
                    tempOrders.Add(new OrderForModel() { Number = item.Id, Cost = item.TotalCost, DateTime = item.DateTime });

               model.Orders = tempOrders;

               return View(model);
          }

          public async Task<ActionResult> GetOrder(int id)
          {
               ApplicationUser user = await userManager.FindByIdAsync(HttpContext.User.Identity.GetUserId());

               OrderForModel model = new OrderForModel();

               var tempOrder = user.Orders.FirstOrDefault(o => o.Id == id);

               model.Number = tempOrder.Id;
               model.Cost = tempOrder.TotalCost;

               model.Description = InformationConverter.StringToDescription(tempOrder.Description);

               return View(model);
          }

          [HttpPost]
          [Authorize(Roles = "User")]
          public async Task<ActionResult> Edit(UserViewModel model)
          {
               if (ModelState.IsValid)
               {
                    ApplicationUser user = await userManager.FindByIdAsync(HttpContext.User.Identity.GetUserId());

                    if (user != null)
                    {
                         if (user.UserProfile == null)
                              user.UserProfile = new UserProfile();

                         user.UserProfile = model.Profile;

                         await userManager.UpdateAsync(user);                         
                    }
                    return RedirectToAction("Index");
               }
               else
                    return View("Index", model);
          }

          [ChildActionOnly]
          public ActionResult GetLoginRegisterLink()
          {
               AuthViewModel firstModel, secondModel;

               if (HttpContext.User.Identity.IsAuthenticated)
               {
                    bool result = userManager.IsInRole(HttpContext.User.Identity.GetUserId(), "Admin");
                    secondModel = new AuthViewModel("Exit", "User", "Выход");
                    if (result)
                         firstModel = new AuthViewModel("Index", "Admin", HttpContext.User.Identity.Name);
                    else
                         firstModel = new AuthViewModel("Index", "User", HttpContext.User.Identity.Name);
               }
               else
               {
                    firstModel = new AuthViewModel("Login", "Account", "Вход");
                    secondModel = new AuthViewModel("Register", "Account", "Регистрация");
               }

               return PartialView("AuthBar", new AuthViewModel[] { firstModel, secondModel });
          }

          public ActionResult Exit()
          {
               authManager.SignOut();

               return RedirectToAction("Index", "Shop");
          }
     }
}