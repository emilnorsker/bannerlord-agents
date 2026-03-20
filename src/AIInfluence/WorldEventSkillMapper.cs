using TaleWorlds.Core;

namespace AIInfluence;

/// <summary>Maps dynamic event <c>Type</c> strings to a representative skill icon (same IDs as encyclopedia / party screen).</summary>
internal static class WorldEventSkillMapper
{
    public static string GetSkillIdForEventType(string type)
    {
        if (string.IsNullOrWhiteSpace(type))
            return DefaultSkills.Scouting.StringId;
        switch (type.Trim().ToLowerInvariant())
        {
            case "military":
                return DefaultSkills.Tactics.StringId;
            case "political":
                return DefaultSkills.Charm.StringId;
            case "economic":
                return DefaultSkills.Trade.StringId;
            case "social":
                return DefaultSkills.Leadership.StringId;
            case "mysterious":
                return DefaultSkills.Roguery.StringId;
            case "disease_outbreak":
                return DefaultSkills.Medicine.StringId;
            case "news":
                return DefaultSkills.Scouting.StringId;
            default:
                return DefaultSkills.Scouting.StringId;
        }
    }
}
