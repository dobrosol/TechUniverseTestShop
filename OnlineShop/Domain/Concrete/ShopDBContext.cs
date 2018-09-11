using System.Data.Entity;
using Domain.Concrete.Identity;
using Domain.Concrete.ProductEntities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Concrete
{
     public class ShopDBContext: IdentityDbContext<ApplicationUser>
     {
          public ShopDBContext():base("ShopDBContext",throwIfV1Schema:false)
          {
          }
          public DbSet<ASC> ASCs { get; set; }

          public DbSet<Case> Cases { get; set; }

          public DbSet<Order> Orders { get; set; }

          public DbSet<UserProfile> Profiles { get; set; }
     }
}
