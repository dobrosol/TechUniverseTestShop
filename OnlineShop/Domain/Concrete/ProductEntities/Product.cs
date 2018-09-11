using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Concrete.ProductEntities
{
     abstract public class Product
     {
          [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }

          [Display(Name = "Название")]
          [MaxLength(length: 30)]
          [Required]
          [Index(IsUnique = true)]
          public string Name { get; set; }

          [Display(Name = "Категория")]
          [MaxLength(length: 30)]
          public string Category { get; set; }

          [Display(Name = "Производитель")]
          [MaxLength(length: 30)]
          public string Company { get; set; }

          [Display(Name = "Описание")]
          [MaxLength(length: 1000)]
          public string Description { get; set; }

          [Display(Name = "Цена, грн")]
          [Range(0.01, Double.MaxValue, ErrorMessage = "Значение Цена за границами диапазона допустимых значений")]
          [Required]
          public decimal Price { get; set; }

          public byte[] ImageData  {get; set;}

          public string ImageType { get; set; }
     }
}
