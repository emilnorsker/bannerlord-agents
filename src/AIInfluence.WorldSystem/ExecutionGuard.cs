using System;
using System.Collections.Generic;

namespace AIInfluence.WorldSystem;

public class ExecutionGuard
{
    private readonly Func<string, bool> _preconditionChecker;
    private readonly Action<string> _log;

    public ExecutionGuard(Func<string, bool> preconditionChecker, Action<string> log)
    {
        _preconditionChecker = preconditionChecker;
        _log = log;
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

        ApplyEffect(effect, store, diary, plotId, correlationId);
        return true;
    }

    private static List<string> GetPreconditions(PlotEffect effect)
    {
        if (effect.Parameters != null && effect.Parameters.TryGetValue("precondition", out var precondition))
            return new List<string> { precondition };

        return new List<string>();
    }

    private static void ApplyEffect(PlotEffect effect, IntrigueStore store, EventDiary diary, string plotId, string correlationId)
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
        }
    }
}
