using TaleWorlds.Library;

namespace AIInfluence;

/// <summary>
/// One segment within a conversation turn — speech, emote, or action.
/// Ordered correctly because the list preserves insertion order.
/// </summary>
public class ContentSegmentVM : ViewModel
{
    private string _text = "";

    [DataSourceProperty]
    public string Text
    {
        get => _text;
        set
        {
            if (value != _text)
            {
                _text = value;
                ((ViewModel)this).OnPropertyChangedWithValue<string>(value, "Text");
            }
        }
    }

    [DataSourceProperty] public string TextColor { get; set; } = "#E8DCC8FF";
    [DataSourceProperty] public string BackColor { get; set; } = "#00000000";

    public ContentSegmentVM(string text, string textColor, string backColor)
    {
        Text      = text;
        TextColor = textColor;
        BackColor = backColor;
    }
}
