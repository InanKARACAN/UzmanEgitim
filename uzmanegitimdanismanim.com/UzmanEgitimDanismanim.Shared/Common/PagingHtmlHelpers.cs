using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;


namespace UzmanEgitimDanismanim.Shared.Common
{
    public static class PagingHtmlHelpers
    {
        public static IHtmlContent PageLinks(this IHtmlHelper htmlHelper, PageInfo pageInfo, Func<int, string> PageUrl)
        {
            StringBuilder pagingTags = new StringBuilder();

            var path = htmlHelper.ViewContext.HttpContext.Request.Path.Value.ToString();

            if (path.Substring(path.Length - 1, 1) == "/")
                path = path.Remove(path.Length - 1, 1);


            //var queryString = HttpUtility.ParseQueryString(htmlHelper.ViewContext.HttpContext.Request.QueryString.Value);
            //queryString.Remove("page");

            //var newQueryString = queryString.ToString();

            //if (queryString.Count > 0)
            //    newQueryString = "&" + newQueryString;


            //Prev Page

            if (pageInfo.CurrentPage == 1)
            {
                pagingTags.Append("<li class=\"paginate_button page-item previous disabled\">");
                pagingTags.Append("<a href=\"#\" class=\"page-link\">← Geri</a>");
                pagingTags.Append("</li>");
            }
            else
            {
                //pagingTags.Append(GetTagString("Prev", PageUrl(pageInfo.CurrentPage - 1)));
                pagingTags.Append("<li class=\"paginate_button page-item previous\">");
                pagingTags.Append(GetTagString("← Geri", (pageInfo.CurrentPage - 1).ToString()));
                pagingTags.Append("</li>");
            }

            //Page Numbers
            for (int i = 1; i <= pageInfo.LastPage; i++)
            {
                if (i == pageInfo.CurrentPage)
                {
                    pagingTags.Append("<li class=\"paginate_button page-item active\">");
                    pagingTags.Append("<a class=\"page-link\">" + i.ToString() + "</a>");
                    pagingTags.Append("</li>");
                }
                else
                {
                    //pagingTags.Append(GetTagString(i.ToString(), PageUrl(i)));
                    pagingTags.Append("<li class=\"paginate_button page-item\">");
                    pagingTags.Append(GetTagString(i.ToString(), (i).ToString()));
                    pagingTags.Append("</li>");
                }
            }


            //Next Page
            if (pageInfo.CurrentPage == pageInfo.LastPage)
            {
                pagingTags.Append("<li class=\"paginate_button page-item next disabled\">");
                pagingTags.Append("<a class=\"page-link\">İleri →</a>");
                pagingTags.Append("</li>");
            }
            else
            {
                //pagingTags.Append(GetTagString("Next", PageUrl(pageInfo.CurrentPage + 1)));
                pagingTags.Append("<li class=\"paginate_button page-item next\">");
                pagingTags.Append(GetTagString("İleri →", (pageInfo.CurrentPage + 1).ToString()));
                pagingTags.Append("</li>");
            }
            //paging tags
            return new HtmlString(pagingTags.ToString());
        }

        private static string GetTagString(string innerHtml, string hrefValue)
        {
            TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag
            tag.MergeAttribute("class", "page-link");
            //tag.MergeAttribute("href", hrefValue);
            tag.MergeAttribute("href", "javascript:PagerClick(" + hrefValue + ");");
            tag.InnerHtml.Append(" " + innerHtml + "  ");
            using (var sw = new System.IO.StringWriter())
            {
                tag.WriteTo(sw, System.Text.Encodings.Web.HtmlEncoder.Default);
                return sw.ToString();
            }
        }
    }
}