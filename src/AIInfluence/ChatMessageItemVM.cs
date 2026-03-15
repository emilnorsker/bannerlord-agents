using TaleWorlds.Library;

namespace AIInfluence;

public class ChatMessageItemVM : ViewModel
{
    [DataSourceProperty]
    public string SenderName { get; set; } = "";

    [DataSourceProperty]
    public string SenderColor { get; set; } = "#FFFFFFFF";

    [DataSourceProperty]
    public string MessageText { get; set; } = "";

    [DataSourceProperty]
    public string MessageColor { get; set; } = "#00000033";

    /// <summary>speech | emote | action | sender</summary>
    [DataSourceProperty]
    public string MessageType { get; set; } = "speech";

    /// <summary>AI tone label shown after sender name, e.g. "Rumor", "Cautious". Empty for player.</summary>
    [DataSourceProperty]
    public string TypeTag { get; set; } = "";

    [DataSourceProperty] public bool IsSender => MessageType == "sender";
    [DataSourceProperty] public bool IsSpeech => MessageType == "speech";
    [DataSourceProperty] public bool IsEmote  => MessageType == "emote";
    [DataSourceProperty] public bool IsAction => MessageType == "action";

    public ChatMessageItemVM(string senderName, string senderColor, string messageText, string messageColor, string messageType = "speech")
    {
        SenderName = senderName;
        SenderColor = senderColor;
        MessageText = messageText;
        MessageColor = messageColor;
        MessageType = messageType;
    }
}
