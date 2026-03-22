using TaleWorlds.Core;

namespace AIInfluence;

/// <summary>
/// World event info rows: <see cref="DynamicEvent.Type"/> → skill icon for <c>SkillIconVisualWidget</c>.
/// </summary>
internal static class WorldEventGlyphHelper
{
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
