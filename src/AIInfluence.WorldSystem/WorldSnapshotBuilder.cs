using System.Collections.Generic;
using System.Linq;

namespace AIInfluence.WorldSystem;

public static class WorldSnapshotBuilder
{
    private const int DefaultRecentEventCount = 20;

    public static CampaignSnapshot BuildCampaignSnapshot(IntrigueStore store, int recentEventCount = DefaultRecentEventCount)
    {
        var activePlots = store.GetAllPlots()
            .Where(p => p.Status == PlotStatus.Active)
            .ToList();

        var recentEvents = store.EventDiary.GetTail(recentEventCount);

        return new CampaignSnapshot
        {
            ActivePlots = activePlots,
            RecentDiaryEvents = new List<EventDiaryEntry>(recentEvents),
            RuntimeSecretCount = store.RuntimeSecrets.GetAll().Count
        };
    }
}
