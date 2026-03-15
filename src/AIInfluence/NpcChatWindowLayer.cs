using System;
using System.Reflection;
using AIInfluence.UI;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Core.ImageIdentifiers;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Library;
using TaleWorlds.ScreenSystem;

namespace AIInfluence;

public class NpcChatWindowLayer : GauntletLayer
{
    private object _movie;
    private NpcChatWindowVM _viewModel;
    private ScreenBase _conversationScreen;
    /// <summary>
    /// Horizontal conversation-camera offset (scene units), tuned so the NPC
    /// appears centered inside the left chat panel in ChatInterface.xml.
    /// </summary>
    private const float ConversationCameraOffsetX = -0.18f;

    public NpcChatWindowLayer(Hero npc, NPCContext context, Action onReturn)
        : base("NpcChatWindowLayer", 300, false)
    {
        // Must be set before LoadMovie so AIInfluencePortraitWidget reads it on activation
        try
        {
            if (npc?.CharacterObject != null)
            {
                var code = CampaignUIHelper.GetCharacterCode(npc.CharacterObject, false);
                AIInfluencePortraitWidget.PendingCharacterCode = code?.Code;
            }
        }
        catch (Exception)
        {
            AIInfluencePortraitWidget.PendingCharacterCode = null;
        }

        _viewModel = new NpcChatWindowVM(npc, context, onReturn);
        _movie = base.LoadMovie("ChatInterface", (ViewModel)(object)_viewModel);
        ((ScreenLayer)this).InputRestrictions.SetInputRestrictions(true, (InputUsageMask)7);
        _conversationScreen = ScreenManager.TopScreen;
        ApplyConversationCameraOffset(_conversationScreen, ConversationCameraOffsetX);
    }

    protected override void OnFinalize()
    {
        if (_movie != null)
        {
            try
            {
                MethodInfo method = base.GetType().BaseType?.GetMethod(
                    "ReleaseMovie", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (method == null)
                    InformationManager.DisplayMessage(new InformationMessage("[NpcChatWindow] ReleaseMovie not found – possible resource leak"));
                else
                    method.Invoke(this, new object[] { _movie });
            }
            catch (Exception ex)
            {
                InformationManager.DisplayMessage(new InformationMessage("[NpcChatWindow] ReleaseMovie failed: " + ex.Message));
            }
            _movie = null;
        }
        _viewModel = null;
        ApplyConversationCameraOffset(_conversationScreen, 0f);
        _conversationScreen = null;
        base.OnFinalize();
    }

    private static void ApplyConversationCameraOffset(object screen, float offsetX)
    {
        try
        {
            if (screen == null) return;
            foreach (string methodName in new[] { "SetConversationCameraOffsetX", "SetConversationCameraXOffset", "SetConversationSceneOffsetX" })
            {
                MethodInfo method = screen.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new[] { typeof(float) }, null);
                if (method != null) { method.Invoke(screen, new object[] { offsetX }); return; }
            }
            if (offsetX != 0f)
                InformationManager.DisplayMessage(new InformationMessage("[NpcChatWindow] Camera offset: no matching method found on " + screen.GetType().Name));
        }
        catch (Exception ex)
        {
            InformationManager.DisplayMessage(new InformationMessage("[NpcChatWindow] Camera offset failed: " + ex.Message));
        }
    }
}
