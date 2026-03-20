using System;

namespace AIInfluence;

internal static class NpcPartyFoodSupply
{
    /// <summary>Days of food from <c>MobileParty.GetNumDaysForFoodToLast()</c> (stock / daily use).</summary>
    public static (string Label, string Color) Classify(float days)
    {
        if (float.IsNaN(days) || float.IsInfinity(days) || days > 1e9f)
            return ("Supply abundance", "#27AE60FF");
        if (days < 0.25f)
            return ("Starving", "#E74C3CFF");
        if (days < 2f)
            return ("Malnourished", "#E67E22FF");
        if (days < 7f)
            return ("Well supplied", "#D4AC0DFF");
        return ("Supply abundance", "#27AE60FF");
    }

    public static string FormatLine(float days)
    {
        var (label, _) = Classify(days);
        if (float.IsNaN(days) || float.IsInfinity(days) || days > 1e9f)
            return $"Food: {label}";
        return $"Food: {label} ({Math.Max(0f, days):F1} d)";
    }
}
