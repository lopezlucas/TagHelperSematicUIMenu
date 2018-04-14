using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelperSematicUIMenu.TagHelpers
{
    public class MenuLinkTagHelper : TagHelper
    {

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";    // Replaces <menu-link> with <a> tag

            string page = ViewContext.RouteData.Values["page"].ToString();
            string href = context.AllAttributes["href"].Value.ToString();

            if (page.Equals(href, StringComparison.OrdinalIgnoreCase))
            {
                var classes = output.Attributes.FirstOrDefault(a => a.Name == "class")?.Value;
                output.Attributes.SetAttribute("class", $"{classes} active ");
            }

        }
    }
}
