using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class ProposalValidatorTests
{
    [Test]
    public void ValidProposal_PassesValidation()
    {
        var store = new IntrigueStore();
        store.AddPlot(new PlotInstance
        {
            Id = "plot_01", TemplateId = "tmpl_a",
            Status = PlotStatus.Active, Phase = "init", StartedCampaignDay = 1
        });

        var proposal = new WorldProposal
        {
            CorrelationId = "corr_1",
            Operations = new List<ProposalOperation>
            {
                new ProposalOperation
                {
                    OperationType = "emit_plot_point",
                    TargetId = "pp_01",
                    PlotId = "plot_01"
                }
            }
        };

        var result = ProposalValidator.Validate(proposal, store);
        Assert.That(result.Valid, Is.True);
        Assert.That(result.Errors, Is.Empty);
    }

    [Test]
    public void InvalidJson_NeverMutatesSave()
    {
        var result = ProposalValidator.TryParseAndValidate("{ invalid json !!!", new IntrigueStore());
        Assert.That(result.Valid, Is.False);
        Assert.That(result.Errors, Has.Some.Contain("parse"));
    }

    [Test]
    public void UnknownPlotId_Rejected()
    {
        var store = new IntrigueStore();
        var proposal = new WorldProposal
        {
            CorrelationId = "corr_1",
            Operations = new List<ProposalOperation>
            {
                new ProposalOperation
                {
                    OperationType = "advance_plot_phase",
                    TargetId = "phase_2",
                    PlotId = "nonexistent_plot"
                }
            }
        };

        var result = ProposalValidator.Validate(proposal, store);
        Assert.That(result.Valid, Is.False);
        Assert.That(result.Errors, Has.Some.Contain("nonexistent_plot"));
    }

    [Test]
    public void UnknownOperationType_Rejected()
    {
        var store = new IntrigueStore();
        var proposal = new WorldProposal
        {
            CorrelationId = "corr_1",
            Operations = new List<ProposalOperation>
            {
                new ProposalOperation
                {
                    OperationType = "destroy_universe",
                    TargetId = "everything"
                }
            }
        };

        var result = ProposalValidator.Validate(proposal, store);
        Assert.That(result.Valid, Is.False);
        Assert.That(result.Errors, Has.Some.Contain("destroy_universe"));
    }

    [Test]
    public void ValidProposal_Commit_MutatesStore()
    {
        var store = new IntrigueStore();
        store.AddPlot(new PlotInstance
        {
            Id = "plot_01", TemplateId = "tmpl_a",
            Status = PlotStatus.Active, Phase = "init", StartedCampaignDay = 1
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
                    PlotId = "plot_01"
                }
            }
        };

        var result = ProposalValidator.Validate(proposal, store);
        Assert.That(result.Valid, Is.True);

        ProposalCommitter.Commit(proposal, store, store.EventDiary);
        Assert.That(store.GetPlotById("plot_01").Phase, Is.EqualTo("phase_2"));
    }
}
