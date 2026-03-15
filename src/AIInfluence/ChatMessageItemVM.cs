using TaleWorlds.Library;

namespace AIInfluence;

/// <summary>
/// One item per conversation turn (not per segment).
/// SpeechText and EmoteText are shown via IsVisible so neither takes space when empty.
/// IsVisible collapsing confirmed in native SPConversation.xml (@IsPersuading pattern).
/// </summary>
public class ChatMessageItemVM : ViewModel
{
    // ── Sender row ──────────────────────────────────────────────────────────
    [DataSourceProperty] public string SenderName  { get; set; } = "";
    [DataSourceProperty] public string SenderColor { get; set; } = "#C6AC8DFF";
    [DataSourceProperty] public string TypeTag     { get; set; } = "";

    // ── Speech bubble ────────────────────────────────────────────────────────
    [DataSourceProperty] public string SpeechText  { get; set; } = "";
    [DataSourceProperty] public string SpeechColor { get; set; } = "#E8DCC8FF";
    [DataSourceProperty] public string BubbleColor { get; set; } = "#00000000";
    [DataSourceProperty] public bool   HasSpeech   => !string.IsNullOrEmpty(SpeechText);

    // ── Emote row (red, no bubble) ───────────────────────────────────────────
    [DataSourceProperty] public string EmoteText   { get; set; } = "";
    [DataSourceProperty] public bool   HasEmote    => !string.IsNullOrEmpty(EmoteText);

    // ── Action row (purple, no bubble) ──────────────────────────────────────
    [DataSourceProperty] public string ActionText  { get; set; } = "";
    [DataSourceProperty] public bool   HasAction   => !string.IsNullOrEmpty(ActionText);

    public ChatMessageItemVM() { }

    public ChatMessageItemVM(
        string senderName, string senderColor, string typeTag,
        string speechText, string speechColor, string bubbleColor,
        string emoteText, string actionText)
    {
        SenderName  = senderName;
        SenderColor = senderColor;
        TypeTag     = typeTag;
        SpeechText  = speechText;
        SpeechColor = speechColor;
        BubbleColor = bubbleColor;
        EmoteText   = emoteText;
        ActionText  = actionText;
    }
}
