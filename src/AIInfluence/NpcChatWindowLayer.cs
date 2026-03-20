using System;
using System.Reflection;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.InputSystem;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ScreenSystem;

namespace AIInfluence;

public class NpcChatWindowLayer : GauntletLayer
{
    private object _movie;
    private NpcChatWindowVM _viewModel;

    internal NpcChatWindowVM ViewModel => _viewModel;

    /// <summary>Call from <see cref="NpcChatWindowManager.Tick"/> when Enter should send while the chat input has focus.</summary>
    internal void TickEnterToSend()
    {
        if (_viewModel == null || _movie == null)
            return;
        try
        {
            var input = ((ScreenLayer)this).Input;
            if (!input.IsKeyReleased(InputKey.Enter) && !input.IsKeyReleased(InputKey.NumpadEnter))
                return;
            object focused = TryGetFocusedWidget(_movie);
            if (!IsUnderEditableTextWidget(focused))
                return;
            _viewModel.ExecuteSendMessage();
        }
        catch (Exception ex)
        {
            InformationManager.DisplayMessage(new InformationMessage("[NpcChatWindow] TickEnterToSend: " + ex.Message));
        }
    }

    private static object TryGetFocusedWidget(object movie)
    {
        if (movie == null)
            return null;
        PropertyInfo rootProp = movie.GetType().GetProperty("RootWidget", BindingFlags.Public | BindingFlags.Instance);
        object root = rootProp?.GetValue(movie);
        if (root == null)
            return null;
        PropertyInfo ctxProp = root.GetType().GetProperty("Context", BindingFlags.Public | BindingFlags.Instance);
        object ctx = ctxProp?.GetValue(root);
        if (ctx == null)
            return null;
        Type ctxType = ctx.GetType();
        object em = ctxType.GetProperty("EventManager")?.GetValue(ctx);
        if (em == null)
            em = ctxType.GetProperty("UIEventManager")?.GetValue(ctx);
        if (em == null)
            return null;
        PropertyInfo fwProp = em.GetType().GetProperty("FocusedWidget", BindingFlags.Public | BindingFlags.Instance);
        return fwProp?.GetValue(em);
    }

    private static bool IsUnderEditableTextWidget(object w)
    {
        if (w == null)
            return false;
        const string name = "EditableTextWidget";
        object x = w;
        while (x != null)
        {
            if (x.GetType().Name == name)
                return true;
            PropertyInfo parentProp = x.GetType().GetProperty("ParentWidget", BindingFlags.Public | BindingFlags.Instance);
            x = parentProp?.GetValue(x);
        }
        return false;
    }
    /// <summary>
    /// Reads the mission camera offset from MCM settings. Map conversations
    /// use a separate tableau camera with its own MCM setting, applied via
    /// a per-frame Harmony postfix (MapConversationCameraOffsetPatch).
    /// </summary>
    private static float MissionOffsetX => GlobalSettings<ModSettings>.Instance?.MissionCameraOffsetX ?? 0.9f;

    public NpcChatWindowLayer(Hero npc, NPCContext context, Action onReturn)
        : base("NpcChatWindowLayer", 500, false)
    {
        _viewModel = new NpcChatWindowVM(npc, context, onReturn);
        _movie = base.LoadMovie("ChatInterface", (ViewModel)(object)_viewModel);
        ((ScreenLayer)this).InputRestrictions.SetInputRestrictions(true, (InputUsageMask)7);
        ApplyMissionCameraOffset(MissionOffsetX);
    }

    protected override void OnFinalize()
    {
        try
        {
            _viewModel?.FinalizeEncyclopediaHeroStrip();
        }
        catch (Exception ex)
        {
            InformationManager.DisplayMessage(new InformationMessage("[NpcChatWindow] FinalizeEncyclopediaHeroStrip failed: " + ex.Message));
        }
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
