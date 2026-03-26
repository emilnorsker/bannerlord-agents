using Newtonsoft.Json;
using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class IntrigueStoreTests
{
    [Test]
    public void AddPlot_ThenGetById_ReturnsSamePlot()
    {
        var store = new IntrigueStore();
        var plot = new PlotInstance
        {
            Id = "plot_01",
            TemplateId = "tmpl_a",
            Status = PlotStatus.Active,
            Phase = "init",
            StartedCampaignDay = 5
        };

        store.AddPlot(plot);

        var retrieved = store.GetPlotById("plot_01");
        Assert.That(retrieved, Is.Not.Null);
        Assert.That(retrieved.TemplateId, Is.EqualTo("tmpl_a"));
    }

    [Test]
    public void GetPlotById_UnknownId_ReturnsNull()
    {
        var store = new IntrigueStore();
        Assert.That(store.GetPlotById("nonexistent"), Is.Null);
    }

    [Test]
    public void GetAllPlots_ReturnsAllAdded()
    {
        var store = new IntrigueStore();
        store.AddPlot(MakePlot("p1"));
        store.AddPlot(MakePlot("p2"));

        var all = store.GetAllPlots();
        Assert.That(all, Has.Count.EqualTo(2));
    }

    [Test]
    public void Serialize_Deserialize_RoundTrips()
    {
        var store = new IntrigueStore();
        store.AddPlot(MakePlot("p1"));
        store.AddPlot(MakePlot("p2"));

        string json = store.Serialize();
        var restored = IntrigueStore.Deserialize(json);

        Assert.That(restored.GetAllPlots(), Has.Count.EqualTo(2));
        Assert.That(restored.GetPlotById("p1"), Is.Not.Null);
        Assert.That(restored.GetPlotById("p2"), Is.Not.Null);
    }

    [Test]
    public void Deserialize_EmptyJson_ProducesEmptyStore()
    {
        var restored = IntrigueStore.Deserialize("{}");
        Assert.That(restored.GetAllPlots(), Is.Empty);
    }

    [Test]
    public void Deserialize_NullOrBlank_ProducesEmptyStore()
    {
        Assert.That(IntrigueStore.Deserialize(null).GetAllPlots(), Is.Empty);
        Assert.That(IntrigueStore.Deserialize("").GetAllPlots(), Is.Empty);
    }

    private static PlotInstance MakePlot(string id)
    {
        return new PlotInstance
        {
            Id = id,
            TemplateId = "tmpl_test",
            Status = PlotStatus.Active,
            Phase = "init",
            StartedCampaignDay = 1
        };
    }
}
