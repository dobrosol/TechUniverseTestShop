using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Concrete;
using Domain.Concrete.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(WebUI.App_Start.Startup))]

namespace WebUI.App_Start
{
     public class Startup
     {
          public void Configuration(IAppBuilder app)
          {
               app.CreatePerOwinContext<ShopDBContext>(ShopRepository.Shop);
               app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
               app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

               app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
               app.UseCookieAuthentication(new CookieAuthenticationOptions()
               {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Account/Login"),
                    LogoutPath = new PathString("/Shop/Index")
               });
          }
     }
}