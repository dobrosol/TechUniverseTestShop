using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Concrete.ProductEntities;

namespace WebUI.Models.PageModels
{
     public class ASCViewModel : AbstractViewModel<ASC>
     {
          public ASCViewModel()
          {
               PageInfo.PageSize = 9;

               if (FanDiameter == null)
                    FanDiameter = new HashSet<int>();
          }

          public override HashSet<string> Filters
          {
               get
               {
                    HashSet<string> result = base.Filters;

                    foreach (var item in FanDiameter)
                         result.Add(item.ToString());

                    return result;
               }
          }
          public HashSet<int> FanDiameter { get; set; }

          protected override IEnumerable<ASC> Filter()
          {
               IEnumerable<ASC> company = base.Filter();

               if (FanDiameter.Count == 0)
                    return company;
               else
               {
                    IEnumerable<ASC> result = null;

                    foreach (var fan in FanDiameter)
                    {
                         if (result == null)
                              result = company.Where(a => a.FanDiameter == fan).ToList();
                         else
                         {
                              var temp = company.Where(a => a.FanDiameter == fan).ToList();
                              result = result.Concat(temp);
                         }
                    }
                    return result;
               }                
          }          
     }
}