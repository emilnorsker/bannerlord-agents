namespace AIInfluence.WorldSystem;

public static class ProposalCommitter
{
    public static void Commit(WorldProposal proposal, IntrigueStore store, EventDiary diary, BeliefService beliefService = null)
    {
        foreach (var operation in proposal.Operations)
        {
            switch (operation.OperationType)
            {
                case "emit_plot_point":
                    diary.Append(new EventDiaryEntry
                    {
                        EventId = $"{operation.PlotId}_{operation.TargetId}",
                        EventCode = "plot_point_emitted",
                        PlotPointId = operation.TargetId,
                        PlotId = operation.PlotId,
                        CorrelationId = proposal.CorrelationId
                    });
                    break;

                case "advance_plot_phase":
                    var plot = store.GetPlotById(operation.PlotId);
                    if (plot != null)
                        plot.Phase = operation.TargetId;
                    break;

                case "emit_secret":
                    var description = GetParam(operation, "description", "");
                    var accessLevel = GetParam(operation, "access_level", "restricted");
                    store.RuntimeSecrets.Add(new RuntimeSecretRecord
                    {
                        Id = operation.TargetId,
                        Description = description,
                        AccessLevel = accessLevel,
                        Origin = new SecretOrigin { PlotId = operation.PlotId },
                        Status = "active"
                    });
                    break;

                case "create_hook":
                    store.Hooks.Add(new Hook
                    {
                        Id = operation.TargetId,
                        Owner = GetParam(operation, "owner", "player"),
                        TargetHeroStringId = GetParam(operation, "target", ""),
                        Strength = GetParam(operation, "strength", "weak")
                    });
                    break;

                case "propagate_knowledge":
                    if (beliefService != null)
                    {
                        var source = GetParam(operation, "source_hero", null);
                        var target = GetParam(operation, "target_hero", null);
                        if (source != null && target != null)
                        {
                            double confidence = 0.8;
                            var confStr = GetParam(operation, "confidence", null);
                            if (confStr != null && double.TryParse(confStr, out var parsed))
                                confidence = parsed;
                            beliefService.Propagate(operation.TargetId, source, target, confidence);
                        }
                    }
                    break;

                case "update_belief_matrix":
                    if (beliefService != null)
                    {
                        var from = GetParam(operation, "from_hero", null);
                        var about = GetParam(operation, "about_hero", null);
                        var valStr = GetParam(operation, "value", null);
                        if (from != null && about != null && valStr != null && double.TryParse(valStr, out var val))
                            beliefService.SetConfidence(operation.TargetId, from, about, val);
                    }
                    break;

                case "emit_dynamic_event":
                    diary.Append(new EventDiaryEntry
                    {
                        EventId = $"de_{operation.TargetId}",
                        EventCode = "dynamic_event_emitted",
                        DynamicEventId = operation.TargetId,
                        PlotId = operation.PlotId,
                        CorrelationId = proposal.CorrelationId
                    });
                    break;

                case "apply_bannerlord_effect":
                    diary.Append(new EventDiaryEntry
                    {
                        EventId = $"bl_{operation.TargetId}",
                        EventCode = "bannerlord_effect_applied",
                        PlotId = operation.PlotId,
                        CorrelationId = proposal.CorrelationId
                    });
                    break;
            }
        }
    }

    private static string GetParam(ProposalOperation op, string key, string defaultValue)
    {
        if (op.Parameters != null && op.Parameters.TryGetValue(key, out var value))
            return value;
        return defaultValue;
    }
}
