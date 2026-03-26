using System.Linq;

namespace AIInfluence.WorldSystem;

public class PlotLifecycleManager
{
    private readonly IntrigueStore _store;
    private readonly int _maxConcurrentPlots;

    public PlotLifecycleManager(IntrigueStore store, int maxConcurrentPlots)
    {
        _store = store;
        _maxConcurrentPlots = maxConcurrentPlots;
    }

    public bool TryAddPlot(PlotInstance plot)
    {
        int activeCount = _store.GetAllPlots().Count(p => p.Status == PlotStatus.Active);
        if (activeCount >= _maxConcurrentPlots)
            return false;

        _store.AddPlot(plot);
        return true;
    }

    public void CleanupExpired(int currentCampaignDay)
    {
        foreach (var plot in _store.GetAllPlots())
        {
            if (plot.Status != PlotStatus.Active)
                continue;
            if (plot.DeadlineCampaignDay.HasValue && currentCampaignDay > plot.DeadlineCampaignDay.Value)
                plot.Status = PlotStatus.Expired;
        }
    }
}
