using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyVideoGames.WebUI.TagHelpers;

public class GameDescTagHelper : TagHelper
{
    [HtmlAttributeName("rows")]
    public int Rows { get; set; }

    [HtmlAttributeName("readonly")]
    public bool Readonly { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "textarea";

        if (Readonly)
        {
            output.Attributes.Add("readonly", "readonly");
        }

        output.Attributes.Add("rows", Rows);
    }
        
}