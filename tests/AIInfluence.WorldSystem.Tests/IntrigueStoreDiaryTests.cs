using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class IntrigueStoreDiaryTests
{
    [Test]
    public void EventDiary_RoundTrip_ThroughIntrigueStore()
    {
        var store = new IntrigueStore();
        store.EventDiary.Append(new EventDiaryEntry
        {
            EventId = "ev_1",
            CampaignDay = 5,
            EventCode = "battle_end",
            PlotId = "plot_01"
        });

        string json = store.Serialize();
        var restored = IntrigueStore.Deserialize(json);

        Assert.That(restored.EventDiary.GetAll(), Has.Count.EqualTo(1));
        Assert.That(restored.EventDiary.GetAll()[0].EventCode, Is.EqualTo("battle_end"));
        Assert.That(restored.EventDiary.GetAll()[0].PlotId, Is.EqualTo("plot_01"));
    }
}
