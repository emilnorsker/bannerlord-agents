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

    public static void Show(Hero npc, NPCContext context, Action onReturn)
    {
        Close();
        ScreenBase topScreen = ScreenManager.TopScreen;
        if (topScreen == null)
            return;
        try
        {
            _ownerScreen = topScreen;
            _layer = new NpcChatWindowLayer(npc, context, () => { Close(); onReturn?.Invoke(); });
            topScreen.AddLayer((ScreenLayer)(object)_layer);
            ScreenManager.TrySetFocus((ScreenLayer)(object)_layer);
        }
        catch (Exception)
        {
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
        catch (Exception) { }
        _layer = null;
        _ownerScreen = null;

        // End the underlying conversation so the game returns to the map/mission screen
        try
        {
            Campaign.Current?.ConversationManager?.EndConversation();
        }
        catch (Exception) { }
    }
}
