using System;
using System.Collections.Generic;

namespace AIInfluence.WorldSystem;

public class ExecutionGuard
{
    private readonly Func<string, bool> _preconditionChecker;
    private readonly Action<string> _log;
    private readonly StepExecutor _executor;

    public ExecutionGuard(Func<string, bool> preconditionChecker, Action<string> log)
        : this(preconditionChecker, log, null) { }

    public ExecutionGuard(Func<string, bool> preconditionChecker, Action<string> log, StepExecutor executor)
    {
        _preconditionChecker = preconditionChecker;
        _log = log;
        _executor = executor;
    }

    public bool TryExecuteEffect(PlotEffect effect, IntrigueStore store, EventDiary diary, string plotId, string correlationId)
    {
        var preconditions = GetPreconditions(effect);
        foreach (var precondition in preconditions)
        {
            if (!_preconditionChecker(precondition))
            {
                _log($"[WorldSystem] replan: precondition '{precondition}' failed for effect {effect.EffectType}:{effect.TargetId} on plot {plotId} (corr={correlationId})");
                return false;
            }
        }

        if (_executor != null)
        {
            var step = new PlotStep
            {
                StepId = $"guard_{effect.TargetId}",
                Effects = new List<PlotEffect> { effect }
            };
            _executor.Execute(step, plotId, correlationId);
        }
        else
        {
            ApplyEffectFallback(effect, store, diary, plotId, correlationId);
        }
        return true;
    }

    private static List<string> GetPreconditions(PlotEffect effect)
    {
        if (effect.Parameters != null && effect.Parameters.TryGetValue("precondition", out var precondition))
            return new List<string> { precondition };

        return new List<string>();
    }

    private static void ApplyEffectFallback(PlotEffect effect, IntrigueStore store, EventDiary diary, string plotId, string correlationId)
    {
        switch (effect.EffectType)
        {
            case PlotEffectType.EmitPlotPoint:
                diary.Append(new EventDiaryEntry
                {
                    EventId = $"{plotId}_{effect.TargetId}",
                    EventCode = "plot_point_emitted",
                    PlotPointId = effect.TargetId,
                    PlotId = plotId,
                    CorrelationId = correlationId
                });
                break;

            case PlotEffectType.AdvancePlotPhase:
                var plot = store.GetPlotById(plotId);
                if (plot != null)
                    plot.Phase = effect.TargetId;
                break;

            case PlotEffectType.EmitSecret:
                var desc = effect.Parameters != null && effect.Parameters.ContainsKey("description")
                    ? effect.Parameters["description"] : "";
                var access = effect.Parameters != null && effect.Parameters.ContainsKey("access_level")
                    ? effect.Parameters["access_level"] : "restricted";
                store.RuntimeSecrets.Add(new RuntimeSecretRecord
                {
                    Id = effect.TargetId,
                    Description = desc,
                    AccessLevel = access,
                    Origin = new SecretOrigin { PlotId = plotId },
                    Status = "active"
                });
                break;

            case PlotEffectType.EmitDynamicEvent:
                diary.Append(new EventDiaryEntry
                {
                    EventId = $"de_{effect.TargetId}",
                    EventCode = "dynamic_event_emitted",
                    DynamicEventId = effect.TargetId,
                    PlotId = plotId,
                    CorrelationId = correlationId
                });
                break;

            case PlotEffectType.PropagateKnowledge:
                break;
        }
    }
}
