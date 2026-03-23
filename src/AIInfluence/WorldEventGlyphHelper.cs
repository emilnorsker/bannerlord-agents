using System;
using TaleWorlds.Core;

namespace AIInfluence;

/// <summary>
/// World event info rows: <see cref="DynamicEvent.Type"/> → skill icon; <see cref="DynamicEvent.Importance"/> → tint for vanilla gradient sprite.
/// </summary>
internal static class WorldEventGlyphHelper
{
    /// <summary>
    /// ARGB tint for <c>scrollable_field_gradient_9</c> (Native; same as SandBox Crafting scroll field underlay).
    /// </summary>
    public static string GetSeverityTintColor(int importance)
    {
        float t = (Math.Max(1, Math.Min(10, importance)) - 1) / 9f;
        byte r = (byte)(40 + t * 140);
        byte g = (byte)(55 - t * 20);
        byte b = (byte)(45 - t * 15);
        // Opacity comes from ChatInterface DimensionSync AlphaFactor (~10%); keep Color alpha at FF so tint is visible.
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
            case "disease_outbreak":
                return DefaultSkills.Medicine.StringId;
            default:
                return DefaultSkills.Scouting.StringId;
        }
    }
}
