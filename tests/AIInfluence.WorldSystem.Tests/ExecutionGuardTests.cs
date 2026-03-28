using System.Collections.Generic;
using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class ExecutionGuardTests
{
    [Test]
    public void EffectPreconditionHolds_EffectExecuted()
    {
        var store = new IntrigueStore();
        AddPlot(store, "plot_01");
        var diary = new EventDiary();
        var executor = new StepExecutor(store, diary, _ => true);

        var step = new PlotStep
        {
            StepId = "step_guarded",
            Effects = new List<PlotEffect>
            {
                new PlotEffect
                {
                    EffectType = PlotEffectType.EmitPlotPoint,
                    TargetId = "pp_1",
                    Parameters = new Dictionary<string, string> { ["precondition"] = "hero_alive:lord_a" }
                }
            }
        };

        var result = executor.Execute(step, "plot_01", "corr_01");

        Assert.That(result.Success, Is.True);
        Assert.That(diary.GetAll(), Has.Count.EqualTo(1));
    }

    [Test]
    public void EffectPreconditionFails_EffectBlocked_ReplanLogged()
    {
        var store = new IntrigueStore();
        AddPlot(store, "plot_01");
        var diary = new EventDiary();
        var executor = new StepExecutor(store, diary, _ => false);

        var step = new PlotStep
        {
            StepId = "step_guarded",
            Effects = new List<PlotEffect>
            {
                new PlotEffect
                {
                    EffectType = PlotEffectType.EmitPlotPoint,
                    TargetId = "pp_1",
                    Parameters = new Dictionary<string, string> { ["precondition"] = "hero_alive:lord_a" }
                }
            }
        };

        var result = executor.Execute(step, "plot_01", "corr_01");

        Assert.That(result.Success, Is.False);
        Assert.That(result.Reason, Does.Contain("replan"));
        Assert.That(diary.GetAll(), Is.Empty);
    }

    [Test]
    public void NoPreconditionParam_EffectExecutedNormally()
    {
        var store = new IntrigueStore();
        AddPlot(store, "plot_01");
        var diary = new EventDiary();
        var executor = new StepExecutor(store, diary, _ => false);

        var step = new PlotStep
        {
            StepId = "step_no_precond",
            Effects = new List<PlotEffect>
            {
                new PlotEffect { EffectType = PlotEffectType.EmitPlotPoint, TargetId = "pp_1" }
            }
        };

        var result = executor.Execute(step, "plot_01", "corr_01");

        Assert.That(result.Success, Is.True);
        Assert.That(diary.GetAll(), Has.Count.EqualTo(1));
    }

    private static void AddPlot(IntrigueStore store, string id)
    {
        store.AddPlot(new PlotInstance
        {
            Id = id, TemplateId = "tmpl_test",
            Status = PlotStatus.Active, Phase = "init", StartedCampaignDay = 1
        });
    }
}
