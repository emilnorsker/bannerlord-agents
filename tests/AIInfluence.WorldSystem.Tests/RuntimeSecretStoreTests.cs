using Newtonsoft.Json;
using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class RuntimeSecretStoreTests
{
    [Test]
    public void Add_ThenGetById_ReturnsSameRecord()
    {
        var store = new RuntimeSecretStore();
        var secret = new RuntimeSecretRecord
        {
            Id = "secret_01",
            Description = "The guard schedule rotates at midnight",
            AccessLevel = "restricted",
            Origin = new SecretOrigin { PlotId = "plot_01", StepId = "step_01", Cause = "investigation" },
            CreatedCampaignDay = 42,
            Status = "active"
        };

        store.Add(secret);
        var retrieved = store.GetById("secret_01");

        Assert.That(retrieved, Is.Not.Null);
        Assert.That(retrieved.Description, Is.EqualTo("The guard schedule rotates at midnight"));
    }

    [Test]
    public void GetById_UnknownId_ReturnsNull()
    {
        var store = new RuntimeSecretStore();
        Assert.That(store.GetById("nonexistent"), Is.Null);
    }

    [Test]
    public void Serialize_Deserialize_RoundTrips()
    {
        var store = new RuntimeSecretStore();
        store.Add(new RuntimeSecretRecord
        {
            Id = "s1",
            Description = "desc1",
            AccessLevel = "open",
            CreatedCampaignDay = 1,
            Status = "active"
        });

        string json = store.Serialize();
        var restored = RuntimeSecretStore.Deserialize(json);

        Assert.That(restored.GetById("s1"), Is.Not.Null);
        Assert.That(restored.GetById("s1").Description, Is.EqualTo("desc1"));
    }

    [Test]
    public void Add_DuplicateId_Throws()
    {
        var store = new RuntimeSecretStore();
        store.Add(new RuntimeSecretRecord { Id = "s1", Description = "d", AccessLevel = "a", Status = "active" });

        Assert.Throws<System.ArgumentException>(() =>
            store.Add(new RuntimeSecretRecord { Id = "s1", Description = "d2", AccessLevel = "a", Status = "active" }));
    }
}
