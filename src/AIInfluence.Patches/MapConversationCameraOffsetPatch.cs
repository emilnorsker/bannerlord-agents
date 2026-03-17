using System;
using System.Reflection;
using HarmonyLib;
using MCM.Abstractions.Base.Global;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace AIInfluence.Patches;

/// <summary>
/// Shifts the map-conversation tableau camera each render frame so the NPC
/// appears centered in the left chat panel when the NPC chat window is open.
/// Uses a prefix/postfix pair to prevent per-frame offset accumulation:
/// the prefix undoes the prior frame's offset so the original function sees
/// clean camera state, then the postfix re-applies the offset.
/// </summary>
[HarmonyPatch]
public static class MapConversationCameraOffsetPatch
{
    private static float _appliedOffset;
    private static FieldInfo _camFieldCache;

    private static float OffsetX => GlobalSettings<ModSettings>.Instance?.ChatCameraOffsetX ?? -0.18f;

    [HarmonyPrepare]
    public static bool Prepare()
    {
        Type type = AccessTools.TypeByName("SandBox.View.Map.MapConversationTableau");
        return type != null && AccessTools.Method(type, "CharacterTableauContinuousRenderFunction") != null;
    }

    [HarmonyTargetMethod]
    public static MethodInfo TargetMethod()
    {
        return AccessTools.Method(
            AccessTools.TypeByName("SandBox.View.Map.MapConversationTableau"),
            "CharacterTableauContinuousRenderFunction");
    }

    private static Camera GetCamera(object instance)
    {
        _camFieldCache ??= instance.GetType().GetField("_continuousRenderCamera",
            BindingFlags.Instance | BindingFlags.NonPublic);
        return _camFieldCache?.GetValue(instance) as Camera;
    }

    [HarmonyPrefix]
    public static void Prefix(object __instance)
    {
        if (_appliedOffset == 0f) return;
        try
        {
            Camera cam = GetCamera(__instance);
            if (cam == null) return;
            MatrixFrame frame = cam.Frame;
            frame.origin.x -= _appliedOffset;
            cam.Frame = frame;
            _appliedOffset = 0f;
        }
        catch (Exception ex)
        {
            InformationManager.DisplayMessage(new InformationMessage("[NpcChatWindow] Tableau camera prefix failed: " + ex.Message));
        }
    }

    [HarmonyPostfix]
    public static void Postfix(object __instance)
    {
        if (!NpcChatWindowManager.IsOpen) return;
        try
        {
            float offset = OffsetX;
            if (offset == 0f) return;
            Camera cam = GetCamera(__instance);
            if (cam == null) return;
            MatrixFrame frame = cam.Frame;
            frame.origin.x += offset;
            cam.Frame = frame;
            _appliedOffset = offset;
        }
        catch (Exception ex)
        {
            InformationManager.DisplayMessage(new InformationMessage("[NpcChatWindow] Tableau camera postfix failed: " + ex.Message));
        }
    }
}
