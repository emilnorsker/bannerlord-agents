using System.Collections.Generic;
using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class DialoguePathAuditTests
{
    [Test]
    public void ValidProposal_ThenCommit_MutatesState()
    {
        var store = new IntrigueStore();
        store.AddPlot(new PlotInstance
        {
            Id = "plot_01", TemplateId = "tmpl_a",
            Status = PlotStatus.Active, Phase = "phase_1", StartedCampaignDay = 1
        });

        var json = Newtonsoft.Json.JsonConvert.SerializeObject(new WorldProposal
        {
            CorrelationId = "corr_1",
            Operations = new List<ProposalOperation>
            {
                new ProposalOperation
                {
                    OperationType = "emit_secret",
                    TargetId = "secret_new",
                    PlotId = "plot_01",
                    Parameters = new Dictionary<string, string>
                    {
                        ["description"] = "test secret",
                        ["access_level"] = "restricted"
                    }
                }
            }
        });

        var result = ProposalValidator.TryParseAndValidate(json, store);
        Assert.That(result.Valid, Is.True);

        var proposal = Newtonsoft.Json.JsonConvert.DeserializeObject<WorldProposal>(json);
        ProposalCommitter.Commit(proposal, store, store.EventDiary, store.Beliefs);

        Assert.That(store.RuntimeSecrets.GetById("secret_new"), Is.Not.Null);
    }

    [Test]
    public void InvalidJson_NeverMutatesAnyStore()
    {
        var store = new IntrigueStore();
        store.AddPlot(new PlotInstance
        {
            Id = "plot_01", TemplateId = "tmpl_a",
            Status = PlotStatus.Active, Phase = "phase_1", StartedCampaignDay = 1
        });

        var result = ProposalValidator.TryParseAndValidate("{ this is not valid json !!!", store);

        Assert.That(result.Valid, Is.False);
        Assert.That(store.RuntimeSecrets.GetAll(), Is.Empty);
        Assert.That(store.Hooks.GetByTarget("anyone"), Is.Empty);
        Assert.That(store.EventDiary.GetAll(), Is.Empty);
        Assert.That(store.GetPlotById("plot_01").Phase, Is.EqualTo("phase_1"));
    }

    [Test]
    public void RejectedProposal_NeverCommitted()
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

        Assert.That(store.GetAllPlots(), Is.Empty);
        Assert.That(store.EventDiary.GetAll(), Is.Empty);
    }

    [Test]
    public void ValidatedCommit_IsOnlyPathToMutation()
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
                    PlotId = "plot_01"
                }
            }
        };

        var validationResult = ProposalValidator.Validate(proposal, store);
        Assert.That(validationResult.Valid, Is.True);
        Assert.That(store.GetPlotById("plot_01").Phase, Is.EqualTo("phase_1"));

        ProposalCommitter.Commit(proposal, store, store.EventDiary, store.Beliefs);
        Assert.That(store.GetPlotById("plot_01").Phase, Is.EqualTo("phase_2"));
    }
}
