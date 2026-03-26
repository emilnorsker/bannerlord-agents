using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class IntrigueStoreSecretsTests
{
    [Test]
    public void RuntimeSecrets_RoundTrip_ThroughIntrigueStore()
    {
        var store = new IntrigueStore();
        store.RuntimeSecrets.Add(new RuntimeSecretRecord
        {
            Id = "secret_runtime_01",
            Description = "A hidden passage behind the throne",
            AccessLevel = "restricted",
            Status = "active"
        });

        string json = store.Serialize();
        var restored = IntrigueStore.Deserialize(json);

        var secret = restored.RuntimeSecrets.GetById("secret_runtime_01");
        Assert.That(secret, Is.Not.Null);
        Assert.That(secret.Description, Is.EqualTo("A hidden passage behind the throne"));
    }
}
