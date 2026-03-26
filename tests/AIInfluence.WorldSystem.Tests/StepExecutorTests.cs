using System.Collections.Generic;
using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class StepExecutorTests
{
    [Test]
    public void Execute_EmitSecret_AddsToRuntimeStore()
    {
        var store = new IntrigueStore();
        var diary = new EventDiary();
        var executor = new StepExecutor(store, diary);

        var step = new PlotStep
        {
            StepId = "step_1",
            Effects = new List<PlotEffect>
            {
                new PlotEffect
                {
                    EffectType = PlotEffectType.EmitSecret,
                    TargetId = "secret_new",
                    Parameters = new Dictionary<string, string>
                    {
                        ["description"] = "A hidden truth",
                        ["access_level"] = "restricted"
                    }
                }
            }
        };

        var result = executor.Execute(step, "plot_01", "corr_01");

        Assert.That(result.Success, Is.True);
        Assert.That(store.RuntimeSecrets.GetById("secret_new"), Is.Not.Null);
        Assert.That(store.RuntimeSecrets.GetById("secret_new").Description,
            Is.EqualTo("A hidden truth"));
    }

    [Test]
    public void Execute_EmitPlotPoint_AppendsToDiary()
    {
        var store = new IntrigueStore();
        var diary = new EventDiary();
        var executor = new StepExecutor(store, diary);

        var step = new PlotStep
        {
            StepId = "step_2",
            Effects = new List<PlotEffect>
            {
                new PlotEffect
                {
                    EffectType = PlotEffectType.EmitPlotPoint,
                    TargetId = "pp_discovery"
                }
            }
        };

        var result = executor.Execute(step, "plot_01", "corr_01");

        Assert.That(result.Success, Is.True);
        var entries = diary.GetAll();
        Assert.That(entries, Has.Count.EqualTo(1));
        Assert.That(entries[0].EventCode, Is.EqualTo("plot_point_emitted"));
        Assert.That(entries[0].PlotPointId, Is.EqualTo("pp_discovery"));
        Assert.That(entries[0].CorrelationId, Is.EqualTo("corr_01"));
    }

    [Test]
    public void Execute_AdvancePlotPhase_UpdatesPlotInstance()
    {
        var store = new IntrigueStore();
        store.AddPlot(new PlotInstance
        {
            Id = "plot_01",
            TemplateId = "tmpl_test",
            Status = PlotStatus.Active,
            Phase = "phase_1",
            StartedCampaignDay = 1
        });
        var diary = new EventDiary();
        var executor = new StepExecutor(store, diary);

        var step = new PlotStep
        {
            StepId = "step_advance",
            Effects = new List<PlotEffect>
            {
                new PlotEffect
                {
                    EffectType = PlotEffectType.AdvancePlotPhase,
                    TargetId = "phase_2"
                }
            }
        };

        var result = executor.Execute(step, "plot_01", "corr_01");

        Assert.That(result.Success, Is.True);
        Assert.That(store.GetPlotById("plot_01").Phase, Is.EqualTo("phase_2"));
    }

    [Test]
    public void Execute_FailedRequires_WritesNothing()
    {
        var store = new IntrigueStore();
        var diary = new EventDiary();
        var predicates = new Dictionary<string, bool> { ["hero_alive:lord_a"] = false };
        var executor = new StepExecutor(store, diary, pred => predicates.ContainsKey(pred) && predicates[pred]);

        var step = new PlotStep
        {
            StepId = "step_blocked",
            Requires = new List<string> { "hero_alive:lord_a" },
            Effects = new List<PlotEffect>
            {
                new PlotEffect { EffectType = PlotEffectType.EmitPlotPoint, TargetId = "pp_x" }
            }
        };

        var result = executor.Execute(step, "plot_01", "corr_01");

        Assert.That(result.Success, Is.False);
        Assert.That(diary.GetAll(), Is.Empty);
    }

    [Test]
    public void Execute_IdempotencyGuard_DoesNotReRunCompletedStep()
    {
        var store = new IntrigueStore();
        store.AddPlot(new PlotInstance
        {
            Id = "plot_01",
            TemplateId = "tmpl_test",
            Status = PlotStatus.Active,
            Phase = "init",
            StartedCampaignDay = 1,
            CompletedStepIds = { "step_already_done" }
        });
        var diary = new EventDiary();
        var executor = new StepExecutor(store, diary);

        var step = new PlotStep
        {
            StepId = "step_already_done",
            Effects = new List<PlotEffect>
            {
                new PlotEffect { EffectType = PlotEffectType.EmitPlotPoint, TargetId = "pp_x" }
            }
        };

        var result = executor.Execute(step, "plot_01", "corr_01");

        Assert.That(result.Success, Is.False);
        Assert.That(result.Reason, Does.Contain("already completed"));
        Assert.That(diary.GetAll(), Is.Empty);
    }

    [Test]
    public void Execute_MarksStepAsCompleted()
    {
        var store = new IntrigueStore();
        store.AddPlot(new PlotInstance
        {
            Id = "plot_01",
            TemplateId = "tmpl_test",
            Status = PlotStatus.Active,
            Phase = "init",
            StartedCampaignDay = 1
        });
        var diary = new EventDiary();
        var executor = new StepExecutor(store, diary);

        var step = new PlotStep
        {
            StepId = "step_new",
            Effects = new List<PlotEffect>
            {
                new PlotEffect { EffectType = PlotEffectType.EmitPlotPoint, TargetId = "pp_y" }
            }
        };

        executor.Execute(step, "plot_01", "corr_01");

        Assert.That(store.GetPlotById("plot_01").CompletedStepIds,
            Contains.Item("step_new"));
    }

    [Test]
    public void Execute_MultipleEffects_AllApplied()
    {
        var store = new IntrigueStore();
        store.AddPlot(new PlotInstance
        {
            Id = "plot_01",
            TemplateId = "tmpl_test",
            Status = PlotStatus.Active,
            Phase = "init",
            StartedCampaignDay = 1
        });
        var diary = new EventDiary();
        var executor = new StepExecutor(store, diary);

        var step = new PlotStep
        {
            StepId = "step_multi",
            Effects = new List<PlotEffect>
            {
                new PlotEffect { EffectType = PlotEffectType.EmitPlotPoint, TargetId = "pp_a" },
                new PlotEffect
                {
                    EffectType = PlotEffectType.EmitSecret,
                    TargetId = "secret_b",
                    Parameters = new Dictionary<string, string>
                    {
                        ["description"] = "b desc",
                        ["access_level"] = "open"
                    }
                },
                new PlotEffect { EffectType = PlotEffectType.AdvancePlotPhase, TargetId = "phase_2" }
            }
        };

        var result = executor.Execute(step, "plot_01", "corr_01");

        Assert.That(result.Success, Is.True);
        Assert.That(diary.GetAll(), Has.Count.EqualTo(1));
        Assert.That(store.RuntimeSecrets.GetById("secret_b"), Is.Not.Null);
        Assert.That(store.GetPlotById("plot_01").Phase, Is.EqualTo("phase_2"));
    }
}
