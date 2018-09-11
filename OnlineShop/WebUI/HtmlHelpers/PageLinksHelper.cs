using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebUI.Models.PageModels;

namespace WebUI.HtmlHelpers
{
     public static class PageLinksHelper
     {
          public static MvcHtmlString GetLinks(this HtmlHelper html, int totalPages, string updateId, Func<int,string> url)
          {
               StringBuilder resultString = new StringBuilder();
                            
               for(int i=1; i<=totalPages;i++)
               {
                    TagBuilder tag = new TagBuilder("a");

                    tag.MergeAttribute("href", url(i));
                    tag.MergeAttribute("data-ajax", "true");
                    tag.MergeAttribute("data-ajax-update", string.Format("#{0}", updateId));
                    tag.MergeAttribute("class", "page-link");

                    tag.InnerHtml = i.ToString();

                    resultString.Append(tag);
               }

               return MvcHtmlString.Create(resultString.ToString());
          }
     }
}