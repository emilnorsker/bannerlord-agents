using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class EventDiaryTests
{
    [Test]
    public void Append_AssignsMonotonicSequence()
    {
        var diary = new EventDiary();
        diary.Append(MakeEntry("ev_1", "battle_end"));
        diary.Append(MakeEntry("ev_2", "settlement_enter"));

        var entries = diary.GetAll();
        Assert.That(entries, Has.Count.EqualTo(2));
        Assert.That(entries[0].Sequence, Is.LessThan(entries[1].Sequence));
    }

    [Test]
    public void Append_PreservesEventCode()
    {
        var diary = new EventDiary();
        diary.Append(MakeEntry("ev_1", "battle_end"));

        Assert.That(diary.GetAll()[0].EventCode, Is.EqualTo("battle_end"));
    }

    [Test]
    public void GetTail_ReturnsLastNEntries()
    {
        var diary = new EventDiary();
        diary.Append(MakeEntry("ev_1", "a"));
        diary.Append(MakeEntry("ev_2", "b"));
        diary.Append(MakeEntry("ev_3", "c"));

        var tail = diary.GetTail(2);
        Assert.That(tail, Has.Count.EqualTo(2));
        Assert.That(tail[0].EventId, Is.EqualTo("ev_2"));
        Assert.That(tail[1].EventId, Is.EqualTo("ev_3"));
    }

    [Test]
    public void GetTail_MoreThanCount_ReturnsAll()
    {
        var diary = new EventDiary();
        diary.Append(MakeEntry("ev_1", "a"));

        var tail = diary.GetTail(100);
        Assert.That(tail, Has.Count.EqualTo(1));
    }

    [Test]
    public void RoundTrip_Serialization()
    {
        var diary = new EventDiary();
        diary.Append(MakeEntry("ev_1", "battle_end"));
        diary.Append(MakeEntry("ev_2", "peace_declared"));

        string json = diary.Serialize();
        var restored = EventDiary.Deserialize(json);

        Assert.That(restored.GetAll(), Has.Count.EqualTo(2));
        Assert.That(restored.GetAll()[0].EventId, Is.EqualTo("ev_1"));
        Assert.That(restored.GetAll()[1].Sequence,
            Is.GreaterThan(restored.GetAll()[0].Sequence));
    }

    [Test]
    public void Entries_AreImmutableAfterAppend()
    {
        var diary = new EventDiary();
        var entry = MakeEntry("ev_1", "battle_end");
        diary.Append(entry);

        var retrieved = diary.GetAll()[0];
        Assert.That(retrieved.EventId, Is.EqualTo("ev_1"));
        Assert.That(retrieved.EventCode, Is.EqualTo("battle_end"));
    }

    [Test]
    public void Refs_RoundTrip()
    {
        var diary = new EventDiary();
        var entry = new EventDiaryEntry
        {
            EventId = "ev_refs",
            CampaignDay = 10,
            EventCode = "hero_killed",
            HeroIds = new List<string> { "lord_a", "lord_b" },
            PlotId = "plot_01",
            PlotPointId = "pp_01",
            DynamicEventId = "de_01",
            CorrelationId = "corr_01"
        };
        diary.Append(entry);

        string json = diary.Serialize();
        var restored = EventDiary.Deserialize(json);
        var restored_entry = restored.GetAll()[0];

        Assert.That(restored_entry.HeroIds, Contains.Item("lord_a"));
        Assert.That(restored_entry.HeroIds, Contains.Item("lord_b"));
        Assert.That(restored_entry.PlotId, Is.EqualTo("plot_01"));
        Assert.That(restored_entry.PlotPointId, Is.EqualTo("pp_01"));
        Assert.That(restored_entry.DynamicEventId, Is.EqualTo("de_01"));
        Assert.That(restored_entry.CorrelationId, Is.EqualTo("corr_01"));
    }

    private static EventDiaryEntry MakeEntry(string eventId, string eventCode)
    {
        return new EventDiaryEntry
        {
            EventId = eventId,
            CampaignDay = 10,
            EventCode = eventCode
        };
    }
}
