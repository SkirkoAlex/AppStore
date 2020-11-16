using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppStore.Models;
using System.Web.Mvc;
using System.Text;

namespace AppStore.Helpers
{
    public static class PagHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingModel pagingModel, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingModel.PageNumber)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}