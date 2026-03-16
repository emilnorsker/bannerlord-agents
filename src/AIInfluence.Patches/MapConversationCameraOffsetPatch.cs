using System;
using System.Reflection;
using HarmonyLib;
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
    private const float OffsetX = -0.18f;
    private static bool _isOffset;
    private static FieldInfo _camFieldCache;

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
        if (!_isOffset) return;
        try
        {
            Camera cam = GetCamera(__instance);
            if (cam == null) return;
            MatrixFrame frame = cam.Frame;
            frame.origin.x -= OffsetX;
            cam.Frame = frame;
            _isOffset = false;
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
            Camera cam = GetCamera(__instance);
            if (cam == null) return;
            MatrixFrame frame = cam.Frame;
            frame.origin.x += OffsetX;
            cam.Frame = frame;
            _isOffset = true;
        }
        catch (Exception ex)
        {
            InformationManager.DisplayMessage(new InformationMessage("[NpcChatWindow] Tableau camera postfix failed: " + ex.Message));
        }
    }
}
