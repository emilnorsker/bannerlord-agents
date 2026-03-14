using System;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

namespace AIInfluence;

public class NpcChatWindowVM : ViewModel
{
    private readonly Hero _npc;
    private readonly Action _onReturn;

    private string _inputText = "";
    private bool _isSending;

    [DataSourceProperty]
    public MBBindingList<ChatMessageItemVM> MessageList { get; } = new MBBindingList<ChatMessageItemVM>();

    [DataSourceProperty]
    public string InputText
    {
        get => _inputText;
        set
        {
            if (value != _inputText)
            {
                _inputText = value;
                ((ViewModel)this).OnPropertyChangedWithValue<string>(value, "InputText");
            }
        }
    }

    public NpcChatWindowVM(Hero npc, NPCContext context, Action onReturn)
    {
        _npc = npc;
        _onReturn = onReturn;
        LoadHistory(context);
    }

    private void LoadHistory(NPCContext context)
    {
        if (context?.ConversationHistory == null)
            return;

        foreach (string line in context.ConversationHistory)
            MessageList.Add(ParseHistoryLine(line));
    }

    private ChatMessageItemVM ParseHistoryLine(string line)
    {
        string npcName = ((object)_npc?.Name)?.ToString() ?? "NPC";
        bool isPlayer = !line.StartsWith(npcName + ": ", StringComparison.OrdinalIgnoreCase);
        string senderColor = isPlayer ? "#C6AC8DFF" : "#8EC6C5FF";
        string messageColor = isPlayer ? "#00000044" : "#00000033";
        int colonIdx = line.IndexOf(": ", StringComparison.Ordinal);
        string sender = colonIdx > 0 ? line.Substring(0, colonIdx) : (isPlayer ? "Player" : npcName);
        string text = colonIdx > 0 ? line.Substring(colonIdx + 2) : line;
        return new ChatMessageItemVM(sender, senderColor, text, messageColor);
    }

    public void OnTextChanged(string newText)
    {
        _inputText = newText;
    }

    public async void ExecuteSendMessage()
    {
        string message = _inputText?.Trim();
        if (string.IsNullOrEmpty(message) || _isSending)
            return;

        _isSending = true;
        InputText = "";

        string playerName = ((object)Hero.MainHero?.Name)?.ToString() ?? "Player";
        MessageList.Add(new ChatMessageItemVM(playerName, "#C6AC8DFF", message, "#00000044"));

        try
        {
            string reply = await AIInfluenceBehavior.Instance.ProcessChatInput(_npc, message);
            if (!string.IsNullOrEmpty(reply))
            {
                string npcName = ((object)_npc?.Name)?.ToString() ?? "NPC";
                MessageList.Add(new ChatMessageItemVM(npcName, "#8EC6C5FF", reply, "#00000033"));
            }
        }
        finally
        {
            _isSending = false;
        }
    }

    public void ExecuteReturn()
    {
        _onReturn?.Invoke();
    }
}
