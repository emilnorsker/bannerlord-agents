using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class PlotLifecycleTests
{
    [Test]
    public void Cap_RejectsWhenAtMax()
    {
        var store = new IntrigueStore();
        var lifecycle = new PlotLifecycleManager(store, maxConcurrentPlots: 2);

        Assert.That(lifecycle.TryAddPlot(MakePlot("p1")), Is.True);
        Assert.That(lifecycle.TryAddPlot(MakePlot("p2")), Is.True);
        Assert.That(lifecycle.TryAddPlot(MakePlot("p3")), Is.False);

        Assert.That(store.GetAllPlots(), Has.Count.EqualTo(2));
    }

    [Test]
    public void Cap_AllowsAfterExpiry()
    {
        var store = new IntrigueStore();
        var lifecycle = new PlotLifecycleManager(store, maxConcurrentPlots: 1);

        lifecycle.TryAddPlot(MakePlot("p1", deadline: 5));
        lifecycle.CleanupExpired(currentCampaignDay: 10);

        Assert.That(store.GetAllPlots().Count(p => p.Status == PlotStatus.Active), Is.EqualTo(0));
        Assert.That(lifecycle.TryAddPlot(MakePlot("p2")), Is.True);
    }

    [Test]
    public void CleanupExpired_SetsStatusToExpired()
    {
        var store = new IntrigueStore();
        var lifecycle = new PlotLifecycleManager(store, maxConcurrentPlots: 10);

        lifecycle.TryAddPlot(MakePlot("p1", deadline: 5));
        lifecycle.TryAddPlot(MakePlot("p2", deadline: 20));

        lifecycle.CleanupExpired(currentCampaignDay: 10);

        Assert.That(store.GetPlotById("p1").Status, Is.EqualTo(PlotStatus.Expired));
        Assert.That(store.GetPlotById("p2").Status, Is.EqualTo(PlotStatus.Active));
    }

    [Test]
    public void CleanupExpired_NoDeadline_NotExpired()
    {
        var store = new IntrigueStore();
        var lifecycle = new PlotLifecycleManager(store, maxConcurrentPlots: 10);

        lifecycle.TryAddPlot(MakePlot("p1"));

        lifecycle.CleanupExpired(currentCampaignDay: 999);

        Assert.That(store.GetPlotById("p1").Status, Is.EqualTo(PlotStatus.Active));
    }

    private static PlotInstance MakePlot(string id, int? deadline = null)
    {
        return new PlotInstance
        {
            Id = id,
            TemplateId = "tmpl_test",
            Status = PlotStatus.Active,
            Phase = "init",
            StartedCampaignDay = 1,
            DeadlineCampaignDay = deadline
        };
    }
}
