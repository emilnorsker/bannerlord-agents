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
            return ("Well fed", "#D4AC0DFF");
        return ("Supply abundance", "#27AE60FF");
    }

    /// <summary>Narrative food condition for a leader who has a party on the map. Only call when <c>Hero.PartyBelongedTo</c> is non-null.</summary>
    public static string FormatNarrative(float days, string leaderName)
    {
        string leader = string.IsNullOrWhiteSpace(leaderName) ? "This leader" : leaderName.Trim();
        if (float.IsNaN(days) || float.IsInfinity(days) || days > 1e9f)
        {
            return $"{leader}'s men look comfortable—some even a little soft around the edges; they clearly have no shortage of rations or supplies.";
        }
        float d = Math.Max(0f, days);
        if (d < 0.25f)
        {
            return $"Their party looks starving: hollow-eyed troops, empty sacks, and no fat left on anyone. At this pace, they may not last another day.";
        }
        if (d < 2f)
        {
            return $"Their party looks malnourished—thin, irritable, and scraping by on scraps. You guess they could hold out only a few days on what they carry.";
        }
        if (d < 7f)
        {
            return $"Their party looks adequately fed for now, though not lavish. Rations seem solid enough to last a little while without worry.";
        }
        return $"{leader}'s men look rested and well fed; packs and wagons seem full, and there is no sign of hunger in the ranks. They must have plenty of spare supplies.";
    }
}
