using System;
using System.Collections.Generic;

namespace AIInfluence.WorldSystem;

public class StepExecutor
{
    private readonly IntrigueStore _store;
    private readonly EventDiary _diary;
    private readonly Func<string, bool> _requiresPredicate;
    private readonly BeliefService _beliefService;

    public StepExecutor(IntrigueStore store, EventDiary diary)
        : this(store, diary, _ => true, null) { }

    public StepExecutor(IntrigueStore store, EventDiary diary, Func<string, bool> requiresPredicate)
        : this(store, diary, requiresPredicate, null) { }

    public StepExecutor(IntrigueStore store, EventDiary diary, Func<string, bool> requiresPredicate, BeliefService beliefService)
    {
        _store = store;
        _diary = diary;
        _requiresPredicate = requiresPredicate;
        _beliefService = beliefService;
    }

    public StepExecutionResult Execute(PlotStep step, string plotId, string correlationId)
    {
        var plot = _store.GetPlotById(plotId);
        if (plot == null)
        {
            return new StepExecutionResult
            {
                Success = false,
                Reason = $"Plot '{plotId}' not found in intrigue store."
            };
        }

        if (plot.CompletedStepIds.Contains(step.StepId))
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

        plot.CompletedStepIds.Add(step.StepId);

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
                PropagateKnowledge(effect);
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

    private void PropagateKnowledge(PlotEffect effect)
    {
        if (_beliefService == null)
            return;

        var sourceHero = effect.Parameters != null && effect.Parameters.ContainsKey("source_hero")
            ? effect.Parameters["source_hero"] : null;
        var targetHero = effect.Parameters != null && effect.Parameters.ContainsKey("target_hero")
            ? effect.Parameters["target_hero"] : null;

        if (sourceHero == null || targetHero == null)
            return;

        var confidence = 0.8;
        if (effect.Parameters.ContainsKey("confidence") && double.TryParse(effect.Parameters["confidence"], out var parsed))
            confidence = parsed;

        _beliefService.Propagate(effect.TargetId, sourceHero, targetHero, confidence);
    }
}
