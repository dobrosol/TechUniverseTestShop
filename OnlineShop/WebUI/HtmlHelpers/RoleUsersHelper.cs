using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Concrete.Identity;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using System.Text;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebUI.HtmlHelpers
{
     public static class RoleUsersHelper
     {
          public static MvcHtmlString GetUsers(this HtmlHelper html, ICollection<IdentityUserRole> users)
          {
               var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    
               StringBuilder result = new StringBuilder();
               TagBuilder tag = new TagBuilder("li");
               foreach (var item in users)
               {
                    tag.InnerHtml = userManager.Users.First(u => u.Id == item.UserId).UserName;
                    result.Append(tag);
               }
               return MvcHtmlString.Create(result.ToString());
          }
     }
}