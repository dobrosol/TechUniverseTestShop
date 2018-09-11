using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Concrete.Identity;
using Domain.Concrete.ProductEntities;
using WebUI.Models.PageModels;

namespace WebUI.Models.PageModels.Admin
{
     public class AdminOrder
     {
          UserProfile customerInformation = new UserProfile();

          List<Description> description = new List<Description>();

          public int Number { get; set; }

          public decimal Cost { get; set; }

          public UserProfile CustomerInformation
          {
               get { return customerInformation; }
               set { customerInformation = value; }
          }

          public List<Description> Description
          {
               get { return description; }
               set { description = value; }
          }
     }
}