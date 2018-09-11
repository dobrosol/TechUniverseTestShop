using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Concrete.Identity;

namespace Domain.Concrete
{
     public class Order
     {
          [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }

          public string Description { get; set; }

          public string CustomerInfrom { get; set; }

          public decimal TotalCost { get; set; }

          public DateTime DateTime { get; set; }

          [ForeignKey("User")]
          public string UserId { get; set; }

          public virtual ApplicationUser User { get; set; }
     }
}
