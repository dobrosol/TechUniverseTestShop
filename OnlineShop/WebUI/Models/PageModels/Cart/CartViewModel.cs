using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Concrete;
using Domain.Concrete.Identity;

namespace WebUI.Models.PageModels
{
     public class CartViewModel
     {
          public Cart Cart { get; set; }

          public UserProfile CustomerInformation { get; set; }

          public string ReturnUrl { get; set; }
     }
}