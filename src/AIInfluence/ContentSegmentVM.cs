using TaleWorlds.Library;

namespace AIInfluence;

/// <summary>
/// One segment within a conversation turn — speech, emote, or action.
/// Body lines use <see cref="Text"/> only (Gauntlet uses <c>Chat.Body.Text</c>).
/// Pills use <see cref="Text"/> + <see cref="TextColor"/> (<c>Brush.FontColor="@TextColor"</c>).
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
    [DataSourceProperty] public bool IsPill { get; set; }
    [DataSourceProperty] public bool IsBody => !IsPill;

    public ContentSegmentVM(string text)
    {
        Text = text;
    }

    public ContentSegmentVM(string text, string pillTextColor)
    {
        Text = text;
        TextColor = pillTextColor;
        IsPill = true;
    }
}
