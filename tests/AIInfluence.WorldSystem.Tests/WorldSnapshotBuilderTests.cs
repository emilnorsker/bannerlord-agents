using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class WorldSnapshotBuilderTests
{
    [Test]
    public void BuildCampaignSnapshot_IncludesActivePlots()
    {
        var store = new IntrigueStore();
        store.AddPlot(new PlotInstance
        {
            Id = "plot_01",
            TemplateId = "tmpl_a",
            Status = PlotStatus.Active,
            Phase = "init",
            StartedCampaignDay = 1
        });
        store.AddPlot(new PlotInstance
        {
            Id = "plot_02",
            TemplateId = "tmpl_b",
            Status = PlotStatus.Completed,
            Phase = "done",
            StartedCampaignDay = 1
        });

        var snapshot = WorldSnapshotBuilder.BuildCampaignSnapshot(store);

        Assert.That(snapshot.ActivePlots, Has.Count.EqualTo(1));
        Assert.That(snapshot.ActivePlots[0].Id, Is.EqualTo("plot_01"));
    }

    [Test]
    public void BuildCampaignSnapshot_IncludesRecentDiaryEvents()
    {
        var store = new IntrigueStore();
        for (int i = 0; i < 25; i++)
        {
            store.EventDiary.Append(new EventDiaryEntry
            {
                EventId = $"ev_{i}",
                CampaignDay = i,
                EventCode = "test_event"
            });
        }

        var snapshot = WorldSnapshotBuilder.BuildCampaignSnapshot(store, recentEventCount: 10);

        Assert.That(snapshot.RecentDiaryEvents, Has.Count.EqualTo(10));
        Assert.That(snapshot.RecentDiaryEvents[0].EventId, Is.EqualTo("ev_15"));
    }

    [Test]
    public void BuildCampaignSnapshot_IncludesRuntimeSecretCount()
    {
        var store = new IntrigueStore();
        store.RuntimeSecrets.Add(new RuntimeSecretRecord
        {
            Id = "s1", Description = "d", AccessLevel = "a", Status = "active"
        });

        var snapshot = WorldSnapshotBuilder.BuildCampaignSnapshot(store);

        Assert.That(snapshot.RuntimeSecretCount, Is.EqualTo(1));
    }

    [Test]
    public void CampaignSnapshot_Serializes()
    {
        var store = new IntrigueStore();
        store.AddPlot(new PlotInstance
        {
            Id = "plot_01",
            TemplateId = "tmpl_a",
            Status = PlotStatus.Active,
            Phase = "init",
            StartedCampaignDay = 1
        });

        var snapshot = WorldSnapshotBuilder.BuildCampaignSnapshot(store);
        string json = JsonConvert.SerializeObject(snapshot);

        Assert.That(json, Does.Contain("plot_01"));
    }
}
