using TaleWorlds.Library;

namespace AIInfluence;

public class TextItemVM : ViewModel
{
    [DataSourceProperty] public string Text { get; set; } = "";
    [DataSourceProperty] public string Color { get; set; } = "#C6AC8DFF";

    public TextItemVM(string text, string color = "#C6AC8DFF")
    {
        Text = text;
        Color = color;
    }
}
