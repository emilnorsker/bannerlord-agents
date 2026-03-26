using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

public static class ProposalValidator
{
    private static readonly HashSet<string> AllowedOperations = new HashSet<string>
    {
        "emit_plot_point",
        "emit_secret",
        "advance_plot_phase",
        "propagate_knowledge",
        "update_belief_matrix",
        "create_hook",
        "apply_bannerlord_effect",
        "emit_dynamic_event"
    };

    public static ValidationResult TryParseAndValidate(string json, IntrigueStore store)
    {
        WorldProposal proposal;
        try
        {
            proposal = JsonConvert.DeserializeObject<WorldProposal>(json);
            if (proposal == null)
                return new ValidationResult { Valid = false, Errors = { "Failed to parse proposal JSON." } };
        }
        catch (Exception)
        {
            return new ValidationResult { Valid = false, Errors = { "Failed to parse proposal JSON." } };
        }

        return Validate(proposal, store);
    }

    public static ValidationResult Validate(WorldProposal proposal, IntrigueStore store)
    {
        var result = new ValidationResult { Valid = true };

        foreach (var operation in proposal.Operations)
        {
            if (!AllowedOperations.Contains(operation.OperationType))
            {
                result.Valid = false;
                result.Errors.Add($"Unknown operation type: '{operation.OperationType}'.");
            }

            if (!string.IsNullOrEmpty(operation.PlotId) && store.GetPlotById(operation.PlotId) == null)
            {
                result.Valid = false;
                result.Errors.Add($"Plot '{operation.PlotId}' not found in intrigue store.");
            }
        }

        return result;
    }
}
