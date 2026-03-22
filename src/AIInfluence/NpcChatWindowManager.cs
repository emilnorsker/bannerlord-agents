using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.ScreenSystem;

namespace AIInfluence;

public static class NpcChatWindowManager
{
    private static NpcChatWindowLayer _layer;
    private static ScreenBase _ownerScreen;

    public static bool IsOpen => _layer != null;

    internal static NpcChatWindowVM GetCurrentViewModel() => _layer?.ViewModel;

    /// <summary>Enter / numpad-Enter to send while the chat text input (EditableTextWidget) has UI focus.</summary>
    public static void Tick()
    {
        _layer?.TickEnterToSend();
    }

    public static void Show(Hero npc, NPCContext context, Action onReturn)
    {
        if (npc == null)
        {
            AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] Show called with null npc.");
            return;
        }
        Close();
        ScreenBase topScreen = ScreenManager.TopScreen;
        if (topScreen == null)
        {
            AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] No top screen, cannot show.");
            return;
        }
        try
        {
            _ownerScreen = topScreen;
            _layer = new NpcChatWindowLayer(npc, context, () => { Close(); onReturn?.Invoke(); });
            topScreen.AddLayer((ScreenLayer)(object)_layer);
            ScreenManager.TrySetFocus((ScreenLayer)(object)_layer);
        }
        catch (Exception ex)
        {
            AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] Show failed: " + ex.Message);
            Close();
        }
    }

    public static void Close()
    {
        if (_layer == null)
            return;
        try
        {
            ((ScreenLayer)_layer).InputRestrictions.ResetInputRestrictions();
            _ownerScreen?.RemoveLayer((ScreenLayer)(object)_layer);
        }
        catch (Exception ex)
        {
            AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] Close failed: " + ex.Message);
        }
        _layer = null;
        _ownerScreen = null;

        // Only end the conversation if one is actually active — prevents spurious
        // OnConversationEnd events when the window is closed from outside a dialog.
        try
        {
            var cm = Campaign.Current?.ConversationManager;
            if (cm != null && cm.IsConversationInProgress)
                cm.EndConversation();
        }
        catch (Exception ex)
        {
            AIInfluenceBehavior.Instance?.LogMessage("[NpcChatWindow] EndConversation on close failed: " + ex.Message);
        }
    }
}
