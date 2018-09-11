using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Domain.Concrete.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using WebUI.Models.PageModels;

namespace WebUI.Controllers
{
    public class AccountController : Controller
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

          ApplicationRoleManager roleManager
          {
               get { return HttpContext.GetOwinContext().GetUserManager<ApplicationRoleManager>(); }
          }

          public ActionResult Register()
          {
               return View();
          }

          [HttpPost]
          public async Task<ActionResult> Register(RegisterModel model)
          {
               if(ModelState.IsValid)
               {
                    ApplicationUser user = new ApplicationUser()
                    {
                         UserName = model.Login,
                         Email = model.Email                         
                    };

                    IdentityResult result = await userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                         if (!await roleManager.RoleExistsAsync("User"))
                              await roleManager.CreateAsync(new ApplicationRole() { Name = "User", Description = "Can not access admin panel" });

                         await userManager.AddToRoleAsync(user.Id, "User");

                         if (user.UserName == "Admin")
                         {
                              if (!await roleManager.RoleExistsAsync("Admin"))
                                   await roleManager.CreateAsync(new ApplicationRole() { Name = "Admin", Description = "Unlimited access" });
                              
                                   await userManager.AddToRoleAsync(user.Id, "Admin");
                         }                         

                         await userManager.SendEmailAsync(user.Id, "Регистрация на сайте TechUniverse", string.Format("Добрый день, {0}!<br/><br/> Благодарим за регистрацию на нашем сайте!", user.UserName));
                         
                         return RedirectToAction("Index","Shop");
                    }                         
                    else
                         ModelState.AddModelError("", "Произошла ошибка");
               }
               return View();
          }

          public ActionResult Login()
          {
               return View();
          }

          [HttpPost]
          public async Task<ActionResult> Login(LoginModel model)
          {
               if(ModelState.IsValid)
               {
                    ApplicationUser user = await userManager.FindAsync(model.Login, model.Password);

                    if (user == null)
                         ModelState.AddModelError("", "Неверный логин или пароль");
                    else
                    {                         
                         ClaimsIdentity claims = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

                         authManager.SignOut();

                         if(model.IsSaveBrowser)
                              authManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, claims);
                         else
                              authManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, claims);

                         //if (await userManager.IsInRoleAsync(claims.GetUserId(), "Admin"))
                         //     return RedirectToAction("Index", "Admin", new { area = "AdminPanel" });                            
                         //else
                              return RedirectToAction("Index", "Shop");
                    }
               }

               return View();
          }          
     }
}