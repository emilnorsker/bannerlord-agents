using System;
using System.Reflection;
using AIInfluence.UI;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Core.ImageIdentifiers;
using TaleWorlds.Engine;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ScreenSystem;

namespace AIInfluence;

public class NpcChatWindowLayer : GauntletLayer
{
    private object _movie;
    private NpcChatWindowVM _viewModel;
    private MatrixFrame? _savedCameraEntityFrame;
    /// <summary>
    /// Horizontal conversation-camera offset (scene units), tuned so the NPC
    /// appears centered inside the left chat panel in ChatInterface.xml.
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
        ApplyConversationCameraOffset(ConversationCameraOffsetX);
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
        ApplyConversationCameraOffset(0f);
        base.OnFinalize();
    }

    private void ApplyConversationCameraOffset(float offsetX)
    {
        try
        {
            if (Mission.Current != null)
            {
                Mission.Current.SetCustomCameraGlobalOffset(new Vec3(offsetX, 0f, 0f, -1f));
                if (offsetX != 0f)
                    InformationManager.DisplayMessage(new InformationMessage($"[NpcChatWindow] Mission camera offset: {offsetX}"));
                return;
            }

            GameEntity cam = FindTableauCameraEntity();
            if (cam == null)
            {
                if (offsetX != 0f)
                    InformationManager.DisplayMessage(new InformationMessage("[NpcChatWindow] No Mission and no tableau camera entity found"));
                return;
            }

            if (offsetX != 0f)
            {
                _savedCameraEntityFrame = cam.GetFrame();
                MatrixFrame frame = _savedCameraEntityFrame.Value;
                frame.origin.x += offsetX;
                cam.SetFrame(ref frame);
                InformationManager.DisplayMessage(new InformationMessage($"[NpcChatWindow] Tableau camera offset: {offsetX}"));
            }
            else if (_savedCameraEntityFrame.HasValue)
            {
                MatrixFrame frame = _savedCameraEntityFrame.Value;
                cam.SetFrame(ref frame);
                _savedCameraEntityFrame = null;
            }
        }
        catch (Exception ex)
        {
            InformationManager.DisplayMessage(new InformationMessage("[NpcChatWindow] Camera offset failed: " + ex.Message));
        }
    }

    private static GameEntity FindTableauCameraEntity()
    {
        try
        {
            object handler = Campaign.Current?.ConversationManager?.Handler;
            if (handler == null) return null;

            FieldInfo missionField = handler.GetType().GetField("ConversationMission",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
            object convMission = missionField?.GetValue(handler);
            if (convMission == null) return null;

            PropertyInfo tableauProp = convMission.GetType().GetProperty("ConversationTableau",
                BindingFlags.Instance | BindingFlags.Public);
            object tableau = tableauProp?.GetValue(convMission);
            if (tableau == null) return null;

            FieldInfo camField = tableau.GetType().GetField("_cameraEntity",
                BindingFlags.Instance | BindingFlags.NonPublic);
            return camField?.GetValue(tableau) as GameEntity;
        }
        catch { return null; }
    }
}
