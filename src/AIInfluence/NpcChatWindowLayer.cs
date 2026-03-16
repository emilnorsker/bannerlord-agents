using System;
using System.Reflection;
using AIInfluence.UI;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Core.ImageIdentifiers;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
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
    private const float ConversationCameraOffsetX = -18f;

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
            string resolvedBy = null;
            object[] targets = new object[] { screen, ScreenManager.TopScreen, Mission.Current, Campaign.Current?.ConversationManager };
            foreach (object target in targets)
                if (TryApplyOffsetOnTarget(target, offsetX, out resolvedBy, 2))
                    return;
            if (offsetX != 0f)
                InformationManager.DisplayMessage(new InformationMessage("[NpcChatWindow] Camera offset: no matching method found on known targets"));
        }
        catch (Exception ex)
        {
            InformationManager.DisplayMessage(new InformationMessage("[NpcChatWindow] Camera offset failed: " + ex.Message));
        }
    }

    private static bool TryApplyOffsetOnTarget(object target, float offsetX, out string resolvedBy, int depth)
    {
        resolvedBy = null;
        if (target == null || depth < 0) return false;
        string[] methodNames = new[] { "SetConversationCameraOffsetX", "SetConversationCameraXOffset", "SetConversationSceneOffsetX", "SetConversationCameraOffset" };
        foreach (string methodName in methodNames)
        {
            MethodInfo method = target.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new[] { typeof(float) }, null);
            if (method != null)
            {
                method.Invoke(target, new object[] { offsetX });
                resolvedBy = target.GetType().Name + "." + methodName;
                if (offsetX != 0f)
                    InformationManager.DisplayMessage(new InformationMessage("[NpcChatWindow] Camera offset applied via " + resolvedBy));
                return true;
            }
        }
        foreach (FieldInfo field in target.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            if (!field.FieldType.IsPrimitive && field.FieldType != typeof(string) && TryApplyOffsetOnTarget(field.GetValue(target), offsetX, out resolvedBy, depth - 1))
                return true;
        return false;
    }
}
