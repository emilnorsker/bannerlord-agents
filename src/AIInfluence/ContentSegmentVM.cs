using TaleWorlds.Library;

namespace AIInfluence;

/// <summary>
/// One segment within a conversation turn — speech, emote, or action.
/// Ordered correctly because the list preserves insertion order.
/// </summary>
public class ContentSegmentVM : ViewModel
{
    [DataSourceProperty] public string Text      { get; set; } = "";
    [DataSourceProperty] public string TextColor { get; set; } = "#E8DCC8FF";
    [DataSourceProperty] public string BackColor { get; set; } = "#00000000";
    [DataSourceProperty] public bool IsPill      { get; set; } = false;
    [DataSourceProperty] public bool IsBody      => !IsPill;
    // Note: IsPill/IsBody are set only in the constructor — do not mutate after construction.

    public ContentSegmentVM(string text, string textColor, string backColor, bool isPill = false)
    {
        Text      = text;
        TextColor = textColor;
        BackColor = backColor;
        IsPill    = isPill;
    }
}
