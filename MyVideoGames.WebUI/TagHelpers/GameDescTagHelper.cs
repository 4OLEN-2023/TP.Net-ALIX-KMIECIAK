using Microsoft.AspNetCore.Razor.TagHelpers;
using MyVideoGames.Model.Configuration;

namespace MyVideoGames.WebUI.TagHelpers;


public class GameDescTagHelper : TagHelper
{
    private int maxRow;

    public GameDescTagHelper(IConfiguration config)
    {
        maxRow = config.GetSection("Game").Get<GameConfiguration>()!.DescMaxRow;
    }
    
    [HtmlAttributeName("readonly")]
    public bool Readonly { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "textarea";

        if (Readonly)
        {
            output.Attributes.Add("readonly", "readonly");
        }

        output.Attributes.Add("rows", maxRow);
    }
}
