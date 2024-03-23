using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission11.Models.ViewModels;

namespace Mission11.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory; //build instance of iurlhelperfactory

        public PaginationTagHelper (IUrlHelperFactory temp) //set the short term instance of iurlhelperfactory
        {
            urlHelperFactory = temp;
        }

        [ViewContext]
        [HtmlAttributeNotBound] 
        public ViewContext? ViewContext { get; set; }
        public string? PageAction {  get; set; }
        public PaginationInfo PageModel { get; set; }

        public bool PageClassEnabled { get; set; } = false;
        public string PageClass {  get; set; } = string.Empty;
        public string PageClassNormal {  get; set; } = string.Empty;
        public string PageClassSelected { get; set; } = string.Empty;
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext != null && PageModel != null) 
            { 
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

                TagBuilder result = new TagBuilder("div");

                for (int i = 1; i <= PageModel.TotalNumPages ; i++) 
                {
                    TagBuilder tag = new TagBuilder("a");

                    tag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNum = i });

                    if (PageClassEnabled) 
                    { 
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }

                    tag.InnerHtml.Append(i.ToString());

                    result.InnerHtml.AppendHtml(tag);
                }

                output.Content.AppendHtml(result.InnerHtml);
            }
        }
    }
}
