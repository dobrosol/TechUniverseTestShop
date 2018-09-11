using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
     public class PageInfo
     {
          int pageSize;
          public PageInfo()
          {
               pageSize = 9;
          }

          public PageInfo(int pageSize)
          {
               this.pageSize = pageSize;
          }

          public int TotalItems { get; set; }

          public int TotalPages
          {
               get
               {
                    int result = TotalItems % pageSize;
                    return result == 0 ? TotalItems / pageSize : TotalItems / pageSize + 1;
               }
          }

          public int CurrentPage { get; set; }

          public int PageSize
          {
               get { return pageSize; }
               set
               {
                    if (value > 0)
                         pageSize = value;
                    else
                         pageSize = 1;
               }
          }
     }
}