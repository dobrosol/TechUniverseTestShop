using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models.PageModels.ProductViews
{
     public class FilterEditViewModel
     {
          public FilterEditViewModel(string updateTargetId, bool isAdministrator, string category)
          {
               UpdateTargetId = updateTargetId;
               IsAdministrator = isAdministrator;
               Category = category;
          }

          public string Category { get; set; }

          public bool IsAdministrator { get; set; }

          public string UpdateTargetId { get; set; }
     }
}