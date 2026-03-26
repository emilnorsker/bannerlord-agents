using System;
using System.Collections.Generic;

namespace AIInfluence.WorldSystem;

public class StepExecutor
{
    private readonly IntrigueStore _store;
    private readonly EventDiary _diary;
    private readonly Func<string, bool> _requiresPredicate;

    public StepExecutor(IntrigueStore store, EventDiary diary)
        : this(store, diary, _ => true) { }

    public StepExecutor(IntrigueStore store, EventDiary diary, Func<string, bool> requiresPredicate)
    {
        _store = store;
        _diary = diary;
        _requiresPredicate = requiresPredicate;
    }

    public StepExecutionResult Execute(PlotStep step, string plotId, string correlationId)
    {
        var plot = _store.GetPlotById(plotId);
        if (plot != null && plot.CompletedStepIds.Contains(step.StepId))
        {
            return new StepExecutionResult
            {
                Success = false,
                Reason = $"Step '{step.StepId}' already completed for plot '{plotId}'."
            };
        }

        foreach (var requirement in step.Requires)
        {
            if (!_requiresPredicate(requirement))
            {
                return new StepExecutionResult
                {
                    Success = false,
                    Reason = $"Requirement '{requirement}' not met for step '{step.StepId}'."
                };
            }
        }

        foreach (var effect in step.Effects)
        {
            ApplyEffect(effect, plotId, step.StepId, correlationId);
        }

        if (plot != null)
        {
            plot.CompletedStepIds.Add(step.StepId);
        }

        return new StepExecutionResult { Success = true };
    }

    private void ApplyEffect(PlotEffect effect, string plotId, string stepId, string correlationId)
    {
        switch (effect.EffectType)
        {
            case PlotEffectType.EmitSecret:
                EmitSecret(effect, plotId, stepId);
                break;
            case PlotEffectType.EmitPlotPoint:
                EmitPlotPoint(effect, plotId, correlationId);
                break;
            case PlotEffectType.AdvancePlotPhase:
                AdvancePlotPhase(effect, plotId);
                break;
            case PlotEffectType.PropagateKnowledge:
                break;
            case PlotEffectType.EmitDynamicEvent:
                EmitPlotPoint(effect, plotId, correlationId);
                break;
        }
    }

    private void EmitSecret(PlotEffect effect, string plotId, string stepId)
    {
        var description = effect.Parameters != null && effect.Parameters.ContainsKey("description")
            ? effect.Parameters["description"] : "";
        var accessLevel = effect.Parameters != null && effect.Parameters.ContainsKey("access_level")
            ? effect.Parameters["access_level"] : "restricted";

        _store.RuntimeSecrets.Add(new RuntimeSecretRecord
        {
            Id = effect.TargetId,
            Description = description,
            AccessLevel = accessLevel,
            Origin = new SecretOrigin { PlotId = plotId, StepId = stepId },
            Status = "active"
        });
    }

    private void EmitPlotPoint(PlotEffect effect, string plotId, string correlationId)
    {
        _diary.Append(new EventDiaryEntry
        {
            EventId = $"{plotId}_{effect.TargetId}",
            EventCode = "plot_point_emitted",
            PlotPointId = effect.TargetId,
            PlotId = plotId,
            CorrelationId = correlationId
        });
    }

    private void AdvancePlotPhase(PlotEffect effect, string plotId)
    {
        var plot = _store.GetPlotById(plotId);
        if (plot != null)
        {
            plot.Phase = effect.TargetId;
        }
    }
}
