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

    public ChatMessageItemVM(string senderName, string senderColor, string messageText, string messageColor)
    {
        SenderName = senderName;
        SenderColor = senderColor;
        MessageText = messageText;
        MessageColor = messageColor;
    }
}
