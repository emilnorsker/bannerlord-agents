using System.Collections.Generic;
using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class ExecutionGuardTests
{
    [Test]
    public void PreconditionsHold_EffectExecuted()
    {
        var store = new IntrigueStore();
        var diary = new EventDiary();
        var logs = new List<string>();
        var guard = new ExecutionGuard(
            precondition => true,
            msg => logs.Add(msg));

        var effect = new PlotEffect { EffectType = PlotEffectType.EmitPlotPoint, TargetId = "pp_1" };
        var result = guard.TryExecuteEffect(effect, store, diary, "plot_01", "corr_01");

        Assert.That(result, Is.True);
        Assert.That(diary.GetAll(), Has.Count.EqualTo(1));
    }

    [Test]
    public void PreconditionsFail_EffectBlocked_LogsReplan()
    {
        var store = new IntrigueStore();
        var diary = new EventDiary();
        var logs = new List<string>();
        var guard = new ExecutionGuard(
            precondition => false,
            msg => logs.Add(msg));

        var effect = new PlotEffect
        {
            EffectType = PlotEffectType.EmitPlotPoint,
            TargetId = "pp_1",
            Parameters = new Dictionary<string, string> { ["precondition"] = "hero_alive:lord_a" }
        };
        var result = guard.TryExecuteEffect(effect, store, diary, "plot_01", "corr_01");

        Assert.That(result, Is.False);
        Assert.That(diary.GetAll(), Is.Empty);
        Assert.That(logs, Has.Some.Contain("replan"));
    }

    [Test]
    public void NoPrecondition_EffectExecutedNormally()
    {
        var store = new IntrigueStore();
        var diary = new EventDiary();
        var guard = new ExecutionGuard(
            precondition => false,
            msg => { });

        var effect = new PlotEffect { EffectType = PlotEffectType.EmitPlotPoint, TargetId = "pp_1" };
        var result = guard.TryExecuteEffect(effect, store, diary, "plot_01", "corr_01");

        Assert.That(result, Is.True);
    }
}
