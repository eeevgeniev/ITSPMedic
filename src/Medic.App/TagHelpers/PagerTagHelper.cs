using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;

namespace Medic.App.TagHelpers
{
    public class PagerTagHelper : TagHelper
    {
        private readonly IHtmlGenerator Generator;

        public PagerTagHelper(IHtmlGenerator generator)
        {
            Generator = generator ?? throw new ArgumentNullException(nameof(generator));
        }

        public int PageCount { get; set; }

        public int CurrentPage { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string NavClassNames { get; set; }

        public string UlClassNames { get; set; }

        public string LiClassNames { get; set; }

        public string AnchorClassNames { get; set; }

        public string LiSelectedClassNames { get; set; }

        public Dictionary<string, string> AdditionalProperties { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            StringBuilder stringBuilder = new StringBuilder();

            output.TagName = "nav";

            if (!string.IsNullOrWhiteSpace(NavClassNames))
            {
                output.Attributes.Add("class", NavClassNames);
            }

            string ulClass = string.IsNullOrWhiteSpace(UlClassNames) ? string.Empty : $" class=\"{UlClassNames}\"";

            stringBuilder.Append($"<ul{ulClass}>");

            if (PageCount > 0)
            {
                if (CurrentPage - 3 >= 1)
                {
                    stringBuilder.Append(GeneratePageItem(1, LiClassNames));
                }

                if (CurrentPage - 2 >= 1)
                {
                    stringBuilder.Append(GeneratePageItem(CurrentPage - 2, LiClassNames));
                }

                if (CurrentPage - 1 >= 1)
                {
                    stringBuilder.Append(GeneratePageItem(CurrentPage - 1, LiClassNames));
                }

                stringBuilder.Append(GeneratePageItem(CurrentPage, LiSelectedClassNames));

                if (CurrentPage + 1 <= PageCount)
                {
                    stringBuilder.Append(GeneratePageItem(CurrentPage + 1, LiClassNames));
                }

                if (CurrentPage + 2 <= PageCount)
                {
                    stringBuilder.Append(GeneratePageItem(CurrentPage + 2, LiClassNames));
                }

                if (CurrentPage + 3 <= PageCount)
                {
                    stringBuilder.Append(GeneratePageItem(PageCount, LiClassNames));
                }
            }

            stringBuilder.Append("</ul>");

            output.Content.SetHtmlContent(stringBuilder.ToString());
            output.TagMode = TagMode.StartTagAndEndTag;

            base.Process(context, output);
        }

        private string GeneratePageItem(int page, string className)
        {
            string pageNumber = page.ToString();

            TagBuilder anchor = Generator.GenerateActionLink(
                ViewContext,
                pageNumber,
                ActionName,
                ControllerName,
                default,
                default,
                default,
                AdditionalProperties != default ?
                new Dictionary<string, string>(AdditionalProperties) { { nameof(page), pageNumber } } :
                new Dictionary<string, string>() { { nameof(page), pageNumber } },
                new { @class = string.IsNullOrWhiteSpace(AnchorClassNames) ? string.Empty : AnchorClassNames });

            string liClass = string.IsNullOrWhiteSpace(className) ? string.Empty : $" class=\"{className}\"";

            using StringWriter stringWriter = new StringWriter();
            anchor.WriteTo(stringWriter, HtmlEncoder.Default);

            return $"<li{liClass}>{stringWriter}</li>";
        }
    }
}
