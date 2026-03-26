namespace AIInfluence.WorldSystem;

public static class ProposalCommitter
{
    public static void Commit(WorldProposal proposal, IntrigueStore store, EventDiary diary)
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
                    var description = operation.Parameters != null && operation.Parameters.ContainsKey("description")
                        ? operation.Parameters["description"] : "";
                    var accessLevel = operation.Parameters != null && operation.Parameters.ContainsKey("access_level")
                        ? operation.Parameters["access_level"] : "restricted";
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
                        Owner = operation.Parameters != null && operation.Parameters.ContainsKey("owner")
                            ? operation.Parameters["owner"] : "player",
                        TargetHeroStringId = operation.Parameters != null && operation.Parameters.ContainsKey("target")
                            ? operation.Parameters["target"] : "",
                        Strength = operation.Parameters != null && operation.Parameters.ContainsKey("strength")
                            ? operation.Parameters["strength"] : "weak"
                    });
                    break;
            }
        }
    }
}
