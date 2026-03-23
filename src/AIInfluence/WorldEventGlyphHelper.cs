using System;
using TaleWorlds.Core;

namespace AIInfluence;

/// <summary>
/// World event info rows: <see cref="DynamicEvent.Type"/> → skill icon; <see cref="DynamicEvent.Importance"/> → subtle text color nudge (base encyclopedia tan).
/// </summary>
internal static class WorldEventGlyphHelper
{
    /// <summary>Minor ARGB shift from default <c>#C6AC8DFF</c> so rows read slightly different by severity (gradient stays untinted).</summary>
    public static string GetWorldEventTextColor(int importance)
    {
        float t = (Math.Max(1, Math.Min(10, importance)) - 1) / 9f;
        const int baseR = 0xC6, baseG = 0xAC, baseB = 0x8D;
        int r = Math.Min(255, Math.Max(0, baseR + (int)(t * 8)));
        int g = Math.Min(255, Math.Max(0, baseG - (int)(t * 6)));
        int b = Math.Min(255, Math.Max(0, baseB - (int)(t * 5)));
        return $"#{r:X2}{g:X2}{b:X2}FF";
    }

    /// <summary>Maps event type string (AI JSON) to a Bannerlord skill id.</summary>
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
            default:
                return DefaultSkills.Scouting.StringId;
        }
    }
}
