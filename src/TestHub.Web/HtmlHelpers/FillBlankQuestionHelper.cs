using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestHub.Web.HtmlHelpers
{
    public static class FillBlankQuestionHelper
    {
        public static HtmlString Format(this IHtmlHelper html, string context)
        {
            string result = "";
            return new HtmlString(result);
        }
    }
}
