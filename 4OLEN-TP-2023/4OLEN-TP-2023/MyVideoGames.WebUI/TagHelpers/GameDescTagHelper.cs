using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Configuration;
using MyVideoGames.Model.Configuration;
using MyVideoGames.WebUI.Models; 

namespace MyVideoGames.WebUI.TagHelpers;

public class GameDescTagHelper(IConfiguration config) : TagHelper
{
    private readonly int _rows = config.GetSection("Game").Get<GameConfiguration>()!.DescMaxRow;

    [HtmlAttributeName("readonly")]
    public bool Readonly { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "textarea";

        if (Readonly)
        {
            output.Attributes.Add("readonly", "readonly");
        }

        output.Attributes.Add("rows", _rows);
    }
}