using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class PlotTemplateTests
{
    [Test]
    public void PlotStep_RoundTrip()
    {
        var step = new PlotStep
        {
            StepId = "step_gather",
            Requires = new List<string> { "hero_alive:lord_a", "at_settlement:pen_cannoc" },
            Effects = new List<PlotEffect>
            {
                new PlotEffect { EffectType = PlotEffectType.EmitSecret, TargetId = "secret_01" },
                new PlotEffect { EffectType = PlotEffectType.EmitPlotPoint, TargetId = "pp_01" }
            },
            Triggers = new List<string> { "on_daily", "on_enter_settlement" }
        };

        string json = JsonConvert.SerializeObject(step);
        var restored = JsonConvert.DeserializeObject<PlotStep>(json);

        Assert.That(restored.StepId, Is.EqualTo("step_gather"));
        Assert.That(restored.Requires, Has.Count.EqualTo(2));
        Assert.That(restored.Effects, Has.Count.EqualTo(2));
        Assert.That(restored.Effects[0].EffectType, Is.EqualTo(PlotEffectType.EmitSecret));
        Assert.That(restored.Triggers, Contains.Item("on_daily"));
    }

    [Test]
    public void PlotTemplate_RoundTrip()
    {
        var template = new PlotTemplate
        {
            TemplateId = "tmpl_assassination",
            Steps = new List<PlotStep>
            {
                new PlotStep
                {
                    StepId = "step_1",
                    Requires = new List<string>(),
                    Effects = new List<PlotEffect>
                    {
                        new PlotEffect { EffectType = PlotEffectType.PropagateKnowledge, TargetId = "secret_x" }
                    },
                    Triggers = new List<string> { "on_daily" }
                }
            },
            Episodes = new List<Episode>
            {
                new Episode
                {
                    EpisodeId = "ep_1",
                    Name = "Discovery",
                    Patterns = new List<EventPattern>(),
                    Resolution = new Resolution()
                }
            },
            PatternLibraryId = "lib_assassination_v1",
            Version = "1.0"
        };

        string json = JsonConvert.SerializeObject(template);
        var restored = JsonConvert.DeserializeObject<PlotTemplate>(json);

        Assert.That(restored.TemplateId, Is.EqualTo("tmpl_assassination"));
        Assert.That(restored.Steps, Has.Count.EqualTo(1));
        Assert.That(restored.Episodes, Has.Count.EqualTo(1));
        Assert.That(restored.PatternLibraryId, Is.EqualTo("lib_assassination_v1"));
        Assert.That(restored.Version, Is.EqualTo("1.0"));
    }

    [Test]
    public void PlotEffect_AllTypes_Serialize()
    {
        var effects = new List<PlotEffect>
        {
            new PlotEffect { EffectType = PlotEffectType.EmitPlotPoint, TargetId = "pp_1" },
            new PlotEffect { EffectType = PlotEffectType.EmitSecret, TargetId = "s_1" },
            new PlotEffect { EffectType = PlotEffectType.PropagateKnowledge, TargetId = "s_2" },
            new PlotEffect { EffectType = PlotEffectType.AdvancePlotPhase, TargetId = "phase_2" },
            new PlotEffect { EffectType = PlotEffectType.EmitDynamicEvent, TargetId = "de_1" }
        };

        string json = JsonConvert.SerializeObject(effects);
        var restored = JsonConvert.DeserializeObject<List<PlotEffect>>(json);

        Assert.That(restored, Has.Count.EqualTo(5));
        Assert.That(restored[2].EffectType, Is.EqualTo(PlotEffectType.PropagateKnowledge));
    }
}
