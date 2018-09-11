using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Domain.Concrete.Identity
{
     public class ApplicationRoleManager : RoleManager<ApplicationRole>
     {
          public ApplicationRoleManager(RoleStore<ApplicationRole> store) : base(store)
          {
          }

          public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager>oprions,
               IOwinContext owinContext)
          {
               ShopDBContext context = owinContext.Get<ShopDBContext>();
               return new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));
          }
     }
}
