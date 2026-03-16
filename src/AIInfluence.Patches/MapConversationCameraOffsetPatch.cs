using System;
using System.Reflection;
using HarmonyLib;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace AIInfluence.Patches;

/// <summary>
/// Shifts the map-conversation tableau camera each render frame so the NPC
/// appears centered in the left chat panel when the NPC chat window is open.
/// </summary>
[HarmonyPatch]
public static class MapConversationCameraOffsetPatch
{
    private const float OffsetX = -0.18f;

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

    [HarmonyPostfix]
    public static void Postfix(object __instance)
    {
        if (!NpcChatWindowManager.IsOpen) return;
        try
        {
            FieldInfo camField = __instance.GetType().GetField("_continuousRenderCamera",
                BindingFlags.Instance | BindingFlags.NonPublic);
            Camera cam = camField?.GetValue(__instance) as Camera;
            if (cam == null) return;
            MatrixFrame frame = cam.Frame;
            frame.origin.x += OffsetX;
            cam.Frame = frame;
        }
        catch { }
    }
}
