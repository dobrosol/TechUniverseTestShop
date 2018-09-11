using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;

namespace Domain.Concrete.Identity
{
     public class ApplicationUserManager : UserManager<ApplicationUser>
     {
          public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
          {
          }
          public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager>options,
               IOwinContext owinContext)
          {
               ShopDBContext context = owinContext.Get<ShopDBContext>();

               var provider = new DpapiDataProtectionProvider("WebUI");
               var userNamager = new ApplicationUserManager(new UserStore<ApplicationUser>(context))
               {
                    EmailService = new EmailService(),
                    UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser, string>(provider.Create("UserToken"))
               };

               return userNamager;
          }
     }
}
