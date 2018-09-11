using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models.PageModels
{
     public class RegisterModel
     {
          [Required]
          public string Login { get; set; }

          [Required]
          [DataType(DataType.EmailAddress)]
          [RegularExpression(@"^[A-Za-z0-9]([_.-]?[a-zA-Z0-9]+)\@([A-Za-z0-9]{2,})\.([A-Za-z]{2,})$", 
               ErrorMessage = "Недопустимый адрес электронной почты")]
          public string Email { get; set; }

          [Required]
          [DataType(DataType.Password)]
          public string Password { get; set; }

          [Required]
          [DataType(DataType.Password)]
          [Compare("Password", ErrorMessage ="Пароли не совпадают")]
          public string PasswordConfirm { get; set; }

     }
}