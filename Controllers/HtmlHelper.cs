
using System.Linq.Expressions;

namespace System.Web.Mvc
{
    public static class MyHelpler
    {   //图片链接，动作名，控制器名
        public static MvcHtmlString ActionLinkWithImage(this HtmlHelper html, string imgSrc,string actionName,string controllerName)
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            string imgUrl = urlHelper.Content(imgSrc);
            TagBuilder imgTagBuilder = new TagBuilder("img");
            imgTagBuilder.MergeAttribute("src", imgUrl);
            
            string img = imgTagBuilder.ToString(TagRenderMode.SelfClosing);
            string url = urlHelper.Action(actionName,controllerName);
        
            TagBuilder tagBuilder = new TagBuilder("a")
            {
                InnerHtml = img
            };
            tagBuilder.MergeAttribute("href", url);
            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.Normal));
        }
        //图片链接，动作名，控制器名，传递参数
       
      
        public static MvcHtmlString ActionLinkWithImage(this HtmlHelper html, string imgSrc,  string actionName, string controllerName, object routeValue = null)
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            string imgUrl = urlHelper.Content(imgSrc);
            TagBuilder imgTagBuilder = new TagBuilder("img");
            imgTagBuilder.MergeAttribute("src", imgUrl);
            
           
            string img = imgTagBuilder.ToString(TagRenderMode.SelfClosing);
      
            string url = urlHelper.Action(actionName, controllerName, routeValue);
            TagBuilder tagBuilder = new TagBuilder("a")
            {
                InnerHtml = img
            };
            tagBuilder.MergeAttribute("href", url);
            return new MvcHtmlString(tagBuilder.ToString(TagRenderMode.Normal));
        }
        //图片链接，动作名，控制器名，传递参数


    }
}