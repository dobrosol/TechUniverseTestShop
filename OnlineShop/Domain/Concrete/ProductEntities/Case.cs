using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete.ProductEntities
{
     public class Case:Product
     {
          [Display(Name = "Форм-фактор материнской платы")]
          [Required]
          public string FormFactor { get; set; }

          [Display(Name = "Мощность БП")]
          [Required]
          public string PSU { get; set; }
     }
}
