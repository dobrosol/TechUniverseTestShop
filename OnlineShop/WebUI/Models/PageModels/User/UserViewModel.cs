using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Domain.Concrete;
using Domain.Concrete.Identity;
using Domain.Concrete.ProductEntities;

namespace WebUI.Models.PageModels
{
     public class UserViewModel
     {
          IEnumerable<OrderForModel> orders;

          UserProfile profile;          

          public IEnumerable<OrderForModel> Orders
          {
               get { return orders; }
               set { orders = value; }
          }

          public UserProfile Profile
          {
               get
               {
                    return profile;
               }
               set
               {
                    profile = value;
               }
          }
     }

     public class OrderForModel
     {
          IEnumerable<Description> description;
                   
          public IEnumerable<Description> Description
          {
               get
               {
                    return description;
               }
               set
               {
                    description = value;
               }
          }

          public int Number { get; set; }

          public decimal Cost { get; set; }

          public DateTime DateTime { get; set; }
     }

     public class Description:Product
     {
          public int Count { get; set; }

          public decimal Cost { get; set; }
     }
}