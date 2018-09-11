using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Domain.Concrete;
using Domain.Concrete.Identity;
using Domain.Concrete.ProductEntities;
using WebUI.Models.PageModels;

namespace WebUI.Models
{
     public static class InformationConverter
     {
          public static UserProfile StringToUserProfile(string customerInformation)
          {
               var userProfile = new UserProfile();

               var inform = customerInformation.Split('|');

               userProfile.Name = inform[0];
               userProfile.Surname = inform[1];
               userProfile.Email = inform[2];
               userProfile.Age = inform[3];
               userProfile.Country = inform[4];
               userProfile.City = inform[5];
               userProfile.Street = inform[6];
               userProfile.House = inform[7];
               userProfile.Apartment = inform[8];
               userProfile.PhoneNumber = inform[9];

               return userProfile;
          }

          public static List<Description> StringToDescription(string description)
          {
               var result = new List<Description>();

               foreach (var descr in description.Split('|'))
               {
                    if (descr != "")
                    {
                         var items = descr.Split('^');

                         Description descriptionTemp = new Description();

                         descriptionTemp.Name = items[0];
                         descriptionTemp.Company = items[1];
                         descriptionTemp.Category = items[2];
                         descriptionTemp.Price = Convert.ToDecimal(items[3]);
                         descriptionTemp.Count = Convert.ToInt32(items[4]);
                         descriptionTemp.Cost = Convert.ToDecimal(items[5]);

                         result.Add(descriptionTemp);
                    }
               }

               return result;
          }

          public static string UserProfileToString(UserProfile customerInformation)
          {
               string result;
               result = String.Format(
                              "{0}|" +
                              "{1}|" +
                              "{2}|" +
                              "{3}|" +
                              "{4}|" +
                              "{5}|" +
                              "{6}|" +
                              "{7}|" +
                              "{8}|" +
                              "{9}|",
                              customerInformation.Name,
                              customerInformation.Surname,
                              customerInformation.Email,
                              customerInformation.Age,
                              customerInformation.Country,
                              customerInformation.City,
                              customerInformation.Street,
                              customerInformation.House,
                              customerInformation.Apartment,
                              customerInformation.PhoneNumber
                              );

               return result;
          }

          public static string DescriptionToString(IEnumerable<CartLine> cartLines)
          {
               StringBuilder result = new StringBuilder() ;

               foreach (var line in cartLines)
               {
                    var str = String.Format("{0}^{1}^{2}^{3}^{4}^{5}|", line.Product.Name,line.Product.Company,line.Product.Category, line.Product.Price, line.Quantity, (line.Product.Price * line.Quantity));

                    result.Append(str);
               }

               return result.ToString();
          }
     }
}