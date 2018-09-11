using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Concrete.Identity
{
     public class ApplicationUser:IdentityUser
     {
          public virtual UserProfile UserProfile { get; set; }

          public virtual List<Order> Orders { get; set; }
    }
}
