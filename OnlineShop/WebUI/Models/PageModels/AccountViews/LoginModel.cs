﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models.PageModels
{
     public class LoginModel
     {
          [Required]
          [Display(Name ="Логин")]
          public string Login { get; set; }

          [Required]
          [DataType(DataType.Password)]
          [Display(Name = "Пароль")]
          public string Password { get; set; }

          [Display(Name = "Запомнить меня")]
          public bool IsSaveBrowser { get; set; }
     }
}