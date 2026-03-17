using System;
using System.Reflection;
using AIInfluence.UI;
using MCM.Abstractions.Base.Global;
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
    /// Reads the mission camera offset from MCM settings. Map conversations
    /// use a separate tableau camera with its own MCM setting, applied via
    /// a per-frame Harmony postfix (MapConversationCameraOffsetPatch).
    /// </summary>
    private static float MissionOffsetX => GlobalSettings<ModSettings>.Instance?.MissionCameraOffsetX ?? -18f;

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
        ApplyMissionCameraOffset(MissionOffsetX);
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
