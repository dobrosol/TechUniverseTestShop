using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Concrete.ProductEntities;

namespace WebUI.Models.PageModels
{
     public class CaseViewModel:AbstractViewModel<Case>
     {
          public CaseViewModel()
          {
               PageInfo.PageSize = 9;

               if (FormFactor == null)
                    FormFactor = new HashSet<string>();

               if (PSU == null)
                    PSU = new HashSet<string>();
          }

          public override HashSet<string> Filters
          {
               get
               {
                    HashSet<string> result = base.Filters;

                    foreach (var item in FormFactor)
                         result.Add(item.ToString());

                    foreach (var item in PSU)
                         result.Add(item.ToString());

                    return result;
               }
          }
          public HashSet<string> FormFactor { get; set; }
          public HashSet<string> PSU { get; set; }

          protected override IEnumerable<Case> Filter()
          {
               IEnumerable<Case> company = base.Filter(), Psu = null, Formfactor =null;

               if (PSU.Count == 0)
                    return company;
               else
               {
                    foreach (var psu in PSU)
                    {
                         if (Psu == null)
                              Psu = company.Where(a => a.PSU == psu).ToList();
                         else
                         {
                              var temp = company.Where(a => a.PSU == psu).ToList();
                              Psu = Psu.Concat(temp);
                         }
                    }
               }

               if (FormFactor.Count == 0)
                    return Psu;
               else
               {
                    foreach (var ff in FormFactor)
                    {
                         if (Formfactor == null)
                              Formfactor = Psu.Where(a => a.FormFactor == ff).ToList();
                         else
                         {
                              var temp = Psu.Where(a => a.FormFactor == ff).ToList();
                              Formfactor = Formfactor.Concat(temp);
                         }
                    }
               }

               return Formfactor;
          }          
     }
}