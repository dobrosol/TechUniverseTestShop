using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
     public class MenuDictionary
     {
          static Dictionary<string, string> groups = new Dictionary<string, string>();

          static MenuDictionary()
          {
               groups.Add("Системы охлаждения", "ASC");
               groups.Add("Корпуса", "Case");
               groups.Add("Процессоры", "Processor");
               groups.Add("Материнские платы", "MotherBoard");
               groups.Add("Видеокарты", "VideoCard");
               groups.Add("Оперативная память", "RAM");
               groups.Add("Другое", "Other");
          }
          public static Dictionary<string, string> GetGroups()
          {
               return groups;
          }
     }
}