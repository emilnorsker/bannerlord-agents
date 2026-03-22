using System;
using TaleWorlds.Core;

namespace AIInfluence;

/// <summary>
/// World event info rows: <see cref="DynamicEvent.Type"/> → skill icon; <see cref="DynamicEvent.Importance"/> → two-tone split tint (two half-width quads, not a blended gradient).
/// </summary>
internal static class WorldEventGlyphHelper
{
    /// <summary>Maps event type string (AI JSON) to a Bannerlord skill id for <see cref="GUI.Prefabs.ChatInterface"/> SkillIconVisualWidget.</summary>
    public static string GetSkillIdForEventType(string? type)
    {
        if (string.IsNullOrWhiteSpace(type))
            return DefaultSkills.Scouting.StringId;
        switch (type.Trim().ToLowerInvariant())
        {
            case "political":
                return DefaultSkills.Leadership.StringId;
            case "military":
                return DefaultSkills.Tactics.StringId;
            case "economic":
                return DefaultSkills.Trade.StringId;
            case "local":
                return DefaultSkills.Steward.StringId;
            case "rumor":
                return DefaultSkills.Roguery.StringId;
            case "news":
                return DefaultSkills.Scouting.StringId;
            case "social":
                return DefaultSkills.Charm.StringId;
            case "disease_outbreak":
                return DefaultSkills.Medicine.StringId;
            default:
                return DefaultSkills.Scouting.StringId;
        }
    }

    /// <summary>Left/right tint colors for a 50/50 split row underlay; <paramref name="importance"/> is typically 1–10 (clamped).</summary>
    public static void GetSeveritySplitTintColors(int importance, out string left, out string right)
    {
        float t = (Math.Max(1, Math.Min(10, importance)) - 1) / 9f;
        // Low importance: cooler/dimmer greens; high: warmer reds (left slightly darker than right).
        byte rL = (byte)(22 + t * 165);
        byte gL = (byte)(58 + t * (28 - 58));
        byte bL = (byte)(48 + t * (32 - 48));
        // ~10% opacity (255 * 0.1 ≈ 26)
        const byte a = 0x1A;
        left = $"#{rL:X2}{gL:X2}{bL:X2}{a:X2}";
        byte rR = (byte)Math.Min(255, rL + 40);
        byte gR = (byte)Math.Max(0, gL - 22);
        byte bR = (byte)Math.Min(255, bL + 28);
        right = $"#{rR:X2}{gR:X2}{bR:X2}{a:X2}";
    }
}
