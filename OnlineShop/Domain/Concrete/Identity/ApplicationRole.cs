using Microsoft.AspNet.Identity.EntityFramework;

namespace Domain.Concrete.Identity
{
     public class ApplicationRole:IdentityRole
     {
          public string Description { get; set; }
     }
}
