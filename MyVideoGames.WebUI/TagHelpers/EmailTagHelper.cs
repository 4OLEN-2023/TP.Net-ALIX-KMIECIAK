using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyVideoGames.WebUI.TagHelpers;


public class EmailTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "a";
        output.Attributes.Add("href", $"mailto:{output.Content}");
    }
}
