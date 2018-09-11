using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Concrete.ProductEntities;

namespace WebUI.Models
{
     public abstract class AbstractViewModel<T> where T: Product
     {
          protected IEnumerable<T> products;

          public AbstractViewModel()
          {
               if (PageInfo == null)
                    PageInfo = new PageInfo();
               if (Company == null)
                    Company =new HashSet<string>();
          }

          public IEnumerable<T> Products
          {
               get
               {
                    if (products != null)
                    {
                         products = Filter();

                         Sort();

                         PageInfo.TotalItems = products.Count();

                         return products.Skip((PageInfo.CurrentPage - 1) * PageInfo.PageSize).Take(PageInfo.PageSize);
                    }
                    else
                         return null;
               }
               set
               {
                    products = value;
               }
          }
          public virtual HashSet<string> Filters
          {
               get
               {
                    HashSet<string> result = new HashSet<string>();

                    foreach (var item in Company)
                         result.Add(item);

                    return result;
               }
          }
          public PageInfo PageInfo { get; set; }
          public HashSet<string> Company { get; set; }
          public int SortTypeChange { get; set; }

          public bool IsAdministrator { get; set; }

          protected virtual IEnumerable<T> Filter()
          {             
               if (Company.Count == 0)
                    return products;
               else
               {
                    IEnumerable<T> result = null;

                    foreach (var company in Company)
                    {
                         if (result == null)
                              result = products.Where(a => a.Company == company).ToList();
                         else
                         {
                              var temp = products.Where(a => a.Company == company).ToList();
                              result = result.Concat(temp);
                         }
                    }
                    return result;
               }                    
          }
          protected void Sort()
          {
               switch (SortTypeChange)
               {
                    case 1:
                         products = products.OrderBy(r => r.Name);
                         break;
                    case 2:
                         products = products.OrderByDescending(r => r.Name);
                         break;
                    case 3:
                         products = products.OrderBy(r => r.Price);
                         break;
                    case 4:
                         products = products.OrderByDescending(r => r.Price);
                         break;
               }
          }
     }
}