using TaleWorlds.Library;

namespace AIInfluence;

/// <summary>One selectable native <see cref="TaleWorlds.CampaignSystem.Conversation.ConversationSentenceOption"/> row in the NPC chat UI.</summary>
public sealed class NativeDialogueOptionVM : ViewModel
{
    private readonly int _index;

    [DataSourceProperty] public string Label { get; }

    public NativeDialogueOptionVM(int index, string label)
    {
        _index = index;
        Label = label ?? "";
    }

    public void ExecuteSelect()
    {
        NativeConversationMenuBridge.ExecuteOption(_index);
    }
}
