using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models.PageModels.ProductViews
{
     public class SortMenuViewModel
     {
          public string Category { get; set; }

          public string CategoryName { get; set; }

          public int Page { get; set; }

          public string UpdateTargetId { get; set; }
     }
}