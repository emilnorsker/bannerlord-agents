using System.Collections.Generic;
using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class DialoguePathAuditTests
{
    [Test]
    public void ProseText_CannotAddSecretWithoutValidatedCommit()
    {
        var store = new IntrigueStore();
        int initialCount = store.RuntimeSecrets.GetAll().Count;

        Assert.That(initialCount, Is.EqualTo(0));
        Assert.That(store.RuntimeSecrets.GetAll(), Has.Count.EqualTo(0));
    }

    [Test]
    public void InvalidProposal_DoesNotMutateHookStore()
    {
        var store = new IntrigueStore();
        var result = ProposalValidator.TryParseAndValidate("not json", store);

        Assert.That(result.Valid, Is.False);
        Assert.That(store.Hooks.GetByTarget("anyone"), Is.Empty);
    }

    [Test]
    public void InvalidProposal_DoesNotMutateBeliefService()
    {
        var store = new IntrigueStore();
        var beliefs = new BeliefService();

        var result = ProposalValidator.TryParseAndValidate("{ broken }", store);

        Assert.That(result.Valid, Is.False);
        Assert.That(beliefs.GetConfidence("any", "a", "b"), Is.EqualTo(0.0));
    }

    [Test]
    public void ProposalWithUnknownPlot_DoesNotAdvancePhase()
    {
        var store = new IntrigueStore();
        store.AddPlot(new PlotInstance
        {
            Id = "plot_01", TemplateId = "tmpl_a",
            Status = PlotStatus.Active, Phase = "phase_1", StartedCampaignDay = 1
        });

        var proposal = new WorldProposal
        {
            CorrelationId = "corr_1",
            Operations = new List<ProposalOperation>
            {
                new ProposalOperation
                {
                    OperationType = "advance_plot_phase",
                    TargetId = "phase_2",
                    PlotId = "nonexistent"
                }
            }
        };

        var result = ProposalValidator.Validate(proposal, store);
        Assert.That(result.Valid, Is.False);
        Assert.That(store.GetPlotById("plot_01").Phase, Is.EqualTo("phase_1"));
    }
}
