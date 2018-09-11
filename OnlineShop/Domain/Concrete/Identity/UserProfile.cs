using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Concrete.Identity
{
     public class UserProfile
     {
          [Key]
          [ForeignKey("ApplicationUser")]
          public string Id { get; set; }

          [Required(ErrorMessage = "Введите имя")]
          [Display(Name = "Имя")]
          public string Name { get; set; }

          [Required(ErrorMessage = "Введите фамилию")]
          [Display(Name = "Фамилия")]
          public string Surname { get; set; }

          [Required(ErrorMessage ="Введите электронную почту")]
          [RegularExpression(@"^[A-Za-z0-9]([_.-]?[a-zA-Z0-9]+)\@([A-Za-z0-9]{2,})\.([A-Za-z]{2,})$",ErrorMessage ="Недопустимый адрес электронной почты")]
          [Display(Name = "Электронный адрес")]
          public string Email { get; set; }

          [Display(Name = "Возраст")]
          public string Age { get; set; }

          [Display(Name = "Страна")]
          public string Country { get; set; }

          [Display(Name = "Город")]
          public string City { get; set; }

          [Display(Name = "Улица")]
          public string Street { get; set; }

          [Display(Name = "Дом")]
          public string House { get; set; }

          [Display(Name = "Квартира")]
          public string Apartment { get; set; }

          [Required(ErrorMessage ="Введите номер телефона")]
          [Display(Name = "Номер телефона")]
          [RegularExpression(@"^\+38\(0\d{2}\)-\d{2}-\d{2}-\d{3}$", ErrorMessage = "Недопустимый номер телефона")]
          public string PhoneNumber { get; set; }

          public virtual ApplicationUser ApplicationUser { get; set; }
     }
}
