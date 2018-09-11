using System;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Concrete;
using Domain.Concrete.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebUI.Models;
using WebUI.Models.PageModels;

namespace WebUI.Controllers
{
     public class CartController : Controller
    {
          ApplicationUserManager userManager
          {
               get
               {
                    return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
               }
          }

          ICartRepository repository;

          public CartController(ICartRepository repository)
          {
               this.repository = repository;
          }

          public ActionResult Index(Cart cart, string returnUrl)
          {
               return View(new CartViewModel()
               {
                    Cart = cart,
                    ReturnUrl = returnUrl
               });
          }

          public ActionResult Remove(Cart cart, string name, string Url)
          {
               cart.RemoveLine(name);

               return RedirectToAction("Index", new { returnUrl = Url });
          }

          public ActionResult Summary(Cart cart)
          {
               return PartialView(cart);
          }

          public async Task<ActionResult> Confirm(Cart cart, string returnUrl)
          {
               CartViewModel model = new CartViewModel();

               model.ReturnUrl = returnUrl;

               model.Cart= cart;

               if (HttpContext.User.Identity.IsAuthenticated)
               {
                    ApplicationUser user = await userManager.FindByIdAsync(HttpContext.User.Identity.GetUserId());
                    model.CustomerInformation = user.UserProfile;
               }
               else
                    model.CustomerInformation = new UserProfile();

               return View(model);
          }

          [HttpPost]
          public async Task<ActionResult> Confirm(Cart cart, CartViewModel model)
          {
               if (ModelState.IsValid)
               {
                    StringBuilder resultDescription = new StringBuilder();

                    Order order = new Order();

                    order.Description = InformationConverter.DescriptionToString(cart.Lines);

                    order.TotalCost = cart.CalcTotalPrice();

                    order.CustomerInfrom = InformationConverter.UserProfileToString(model.CustomerInformation);

                    order.DateTime = DateTime.Now;

                    if (HttpContext.User.Identity.IsAuthenticated)
                         order.UserId = HttpContext.User.Identity.GetUserId();
                                        
                    repository.SaveOrder(order);

                    cart.Clear();

                    EmailMessenger emailMessenger = new EmailMessenger(model.CustomerInformation.Email);
                    await emailMessenger.SendMessageAsync("Оформление заказа TechUniverse",
                         string.Format("Добрый день, {2}!<br/><br>" +
                         "Ваша заказ #{0} - {1} грн принят!<br/><br>" +
                         "Ожидайте звонка оператора для подтверждения необходимой информации", order.Id, order.TotalCost, model.CustomerInformation.Name));

                    return View("ConfirmSuccess");
               }
               else
               {
                    model.Cart = cart;
                    return View(model);
               }                
          }
     }
}