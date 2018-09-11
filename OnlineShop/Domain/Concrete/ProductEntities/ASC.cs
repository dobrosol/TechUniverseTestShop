using System.ComponentModel.DataAnnotations;

namespace Domain.Concrete.ProductEntities
{
     public class ASC: Product
     {
          [Display(Name = "Диаметр вентилятора, мм")]
          [Required]
          [Range(1,1000,ErrorMessage ="Значение Диаметр за границами диапазона допустимых значений")]
          public int FanDiameter { get; set; }

          [Display(Name = "Тип системы охлаждения")]
          public string Type { get; set; }
     }
}
