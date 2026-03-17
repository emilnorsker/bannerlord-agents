using System;
using System.Reflection;
using HarmonyLib;
using MCM.Abstractions.Base.Global;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;

namespace AIInfluence.Patches;

/// <summary>
/// Shifts the map-conversation tableau camera so the NPC appears centered in
/// the left chat panel when the NPC chat window is open.
/// Prefix-only: the offset is baked into Camera.Frame BEFORE the function
/// reads it and calls SetCamera, so the render uses the shifted position.
/// Each frame the previous offset is undone first to prevent accumulation.
/// </summary>
[HarmonyPatch]
public static class MapConversationCameraOffsetPatch
{
    private static float _appliedOffset;
    private static FieldInfo _camFieldCache;

    private static float OffsetX => GlobalSettings<ModSettings>.Instance?.ChatCameraOffsetX ?? 0.9f;

    [HarmonyPrepare]
    public static bool Prepare()
    {
        Type type = AccessTools.TypeByName("SandBox.View.Map.MapConversationTableau");
        if (type == null || AccessTools.Method(type, "CharacterTableauContinuousRenderFunction") == null)
            return false;
        _camFieldCache = type.GetField("_continuousRenderCamera", BindingFlags.Instance | BindingFlags.NonPublic);
        return _camFieldCache != null;
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
        return _camFieldCache.GetValue(instance) as Camera;
    }

    [HarmonyPrefix]
    public static void Prefix(object __instance)
    {
        try
        {
            Camera cam = GetCamera(__instance);
            if (cam == null) return;

            MatrixFrame frame = cam.Frame;
            frame.origin.x -= _appliedOffset;

            if (NpcChatWindowManager.IsOpen)
            {
                float offset = OffsetX;
                frame.origin.x += offset;
                _appliedOffset = offset;
            }
            else
            {
                _appliedOffset = 0f;
            }

            cam.Frame = frame;
        }
        catch (Exception ex)
        {
            InformationManager.DisplayMessage(new InformationMessage("[NpcChatWindow] Tableau camera prefix failed: " + ex.Message));
        }
    }
}
