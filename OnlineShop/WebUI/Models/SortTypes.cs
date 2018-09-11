using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
     public class SortTypes
     {
          static Dictionary<int, string> types = new Dictionary<int, string>();

          static SortTypes()
          {
               types.Add(1, "А->Я");
               types.Add(2, "Я->А");
               types.Add(3, "Сначала дешевые");
               types.Add(4, "Сначала дорогие");
          }

          public static Dictionary<int,string> Types
          {
               get { return types; }
          } 
     }
}