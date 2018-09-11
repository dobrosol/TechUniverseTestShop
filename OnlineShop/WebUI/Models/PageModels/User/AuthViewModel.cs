using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web;

namespace WebUI.Models.PageModels
{
     public class AuthViewModel
     {
          public AuthViewModel(string action, string controller, string text)
          {
               Url = String.Format("/{0}/{1}",controller, action);
               Text = text == null ? action : text;
          }

          public string Url
          {
               get;
               private set;
          }

          public string Text
          {
               get;
               private set;
          }
     }
}