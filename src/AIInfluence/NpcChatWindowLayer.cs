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
    /// <summary>
    /// Horizontal conversation-camera offset (scene units), tuned so the NPC
    /// appears centered inside the left chat panel in ChatInterface.xml.
    /// Map conversations are handled by MapConversationCameraOffsetPatch instead.
    /// </summary>
    private const float ConversationCameraOffsetX = -18f;

    public NpcChatWindowLayer(Hero npc, NPCContext context, Action onReturn)
        : base("NpcChatWindowLayer", 300, false)
    {
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
        ApplyMissionCameraOffset(ConversationCameraOffsetX);
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
        ApplyMissionCameraOffset(0f);
        base.OnFinalize();
    }

    private static void ApplyMissionCameraOffset(float offsetX)
    {
        try
        {
            Mission mission = Mission.Current;
            if (mission == null) return;
            mission.SetCustomCameraGlobalOffset(new Vec3(offsetX, 0f, 0f, -1f));
        }
        catch (Exception ex)
        {
            InformationManager.DisplayMessage(new InformationMessage("[NpcChatWindow] Camera offset failed: " + ex.Message));
        }
    }
}
