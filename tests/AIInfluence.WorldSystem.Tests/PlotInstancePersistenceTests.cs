using Newtonsoft.Json;
using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class PlotInstancePersistenceTests
{
    [Test]
    public void RoundTrip_PreservesAllFields()
    {
        var original = new PlotInstance
        {
            Id = "plot_assassination_01",
            TemplateId = "tmpl_assassination",
            Status = PlotStatus.Active,
            Phase = "infiltration",
            StartedCampaignDay = 42,
            DeadlineCampaignDay = 100,
            PatternLibraryId = "lib_assassination_v1",
            CompletedStepIds = { "step_gather_intel" },
            LinkedPlotPointIds = { "pp_target_identified" },
            LinkedSecretIds = { "secret_guard_schedule" },
            Context =
            {
                ["target_hero"] = "lord_derthert",
                ["kingdom"] = "vlandia"
            }
        };

        string json = JsonConvert.SerializeObject(original);
        var deserialized = JsonConvert.DeserializeObject<PlotInstance>(json);

        Assert.That(deserialized, Is.Not.Null);
        Assert.That(deserialized.Id, Is.EqualTo(original.Id));
        Assert.That(deserialized.TemplateId, Is.EqualTo(original.TemplateId));
        Assert.That(deserialized.Status, Is.EqualTo(PlotStatus.Active));
        Assert.That(deserialized.Phase, Is.EqualTo(original.Phase));
        Assert.That(deserialized.StartedCampaignDay, Is.EqualTo(42));
        Assert.That(deserialized.DeadlineCampaignDay, Is.EqualTo(100));
        Assert.That(deserialized.PatternLibraryId, Is.EqualTo("lib_assassination_v1"));
        Assert.That(deserialized.CompletedStepIds, Contains.Item("step_gather_intel"));
        Assert.That(deserialized.LinkedPlotPointIds, Contains.Item("pp_target_identified"));
        Assert.That(deserialized.LinkedSecretIds, Contains.Item("secret_guard_schedule"));
        Assert.That(deserialized.Context["target_hero"], Is.EqualTo("lord_derthert"));
        Assert.That(deserialized.Context["kingdom"], Is.EqualTo("vlandia"));
    }

    [Test]
    public void RoundTrip_NullOptionalFields_DeserializesWithoutCorruption()
    {
        var original = new PlotInstance
        {
            Id = "plot_minimal",
            TemplateId = "tmpl_minimal",
            Status = PlotStatus.Pending,
            Phase = "setup",
            StartedCampaignDay = 1
        };

        string json = JsonConvert.SerializeObject(original);
        var deserialized = JsonConvert.DeserializeObject<PlotInstance>(json);

        Assert.That(deserialized, Is.Not.Null);
        Assert.That(deserialized.Id, Is.EqualTo("plot_minimal"));
        Assert.That(deserialized.DeadlineCampaignDay, Is.Null);
        Assert.That(deserialized.PatternLibraryId, Is.Null);
        Assert.That(deserialized.CompletedStepIds, Is.Empty);
        Assert.That(deserialized.LinkedPlotPointIds, Is.Empty);
        Assert.That(deserialized.LinkedSecretIds, Is.Empty);
        Assert.That(deserialized.Context, Is.Empty);
    }

    [Test]
    public void IdAndPhase_AreStableStrings()
    {
        var instance = new PlotInstance
        {
            Id = "plot_stable_01",
            TemplateId = "tmpl_stable",
            Status = PlotStatus.Active,
            Phase = "escalation",
            StartedCampaignDay = 10
        };

        string json = JsonConvert.SerializeObject(instance);

        Assert.That(json, Does.Contain("\"plot_stable_01\""));
        Assert.That(json, Does.Contain("\"escalation\""));
    }
}
