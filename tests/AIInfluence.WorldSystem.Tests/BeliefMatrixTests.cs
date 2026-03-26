using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class BeliefMatrixTests
{
    [Test]
    public void SetAndGet_DiagonalConfidence()
    {
        var service = new BeliefService();
        service.SetConfidence("secret_01", "lord_a", "lord_a", 0.9);

        double value = service.GetConfidence("secret_01", "lord_a", "lord_a");
        Assert.That(value, Is.EqualTo(0.9).Within(0.001));
    }

    [Test]
    public void SetAndGet_OffDiagonal()
    {
        var service = new BeliefService();
        service.SetConfidence("secret_01", "lord_a", "lord_b", 0.5);

        Assert.That(service.GetConfidence("secret_01", "lord_a", "lord_b"), Is.EqualTo(0.5).Within(0.001));
        Assert.That(service.GetConfidence("secret_01", "lord_b", "lord_a"), Is.EqualTo(0.0).Within(0.001));
    }

    [Test]
    public void UnknownKey_ReturnsZero()
    {
        var service = new BeliefService();
        Assert.That(service.GetConfidence("unknown", "a", "b"), Is.EqualTo(0.0));
    }

    [Test]
    public void Propagation_UpdatesMatrix()
    {
        var service = new BeliefService();
        service.SetConfidence("secret_01", "lord_a", "lord_a", 1.0);

        service.Propagate("secret_01", "lord_a", "lord_b", 0.8);

        Assert.That(service.GetConfidence("secret_01", "lord_b", "lord_b"), Is.EqualTo(0.8).Within(0.001));
        Assert.That(service.GetConfidence("secret_01", "lord_a", "lord_b"), Is.EqualTo(0.8).Within(0.001));
    }

    [Test]
    public void RoundTrip_Serialization()
    {
        var service = new BeliefService();
        service.SetConfidence("secret_01", "lord_a", "lord_a", 0.95);
        service.SetConfidence("secret_01", "lord_a", "lord_b", 0.6);

        string json = service.Serialize();
        var restored = BeliefService.Deserialize(json);

        Assert.That(restored.GetConfidence("secret_01", "lord_a", "lord_a"), Is.EqualTo(0.95).Within(0.001));
        Assert.That(restored.GetConfidence("secret_01", "lord_a", "lord_b"), Is.EqualTo(0.6).Within(0.001));
    }

    [Test]
    public void NoCrash_OnPartialParticipantLists()
    {
        var service = new BeliefService();
        service.SetConfidence("key_1", "hero_x", "hero_y", 0.3);

        Assert.That(service.GetConfidence("key_1", "hero_z", "hero_y"), Is.EqualTo(0.0));
    }
}
