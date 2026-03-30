using System.Collections.Generic;
using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class IntrigueStoreFullRoundTripTests
{
    [Test]
    public void FullStore_RoundTrip_AllSubsystems()
    {
        var store = new IntrigueStore();

        store.AddPlot(new PlotInstance
        {
            Id = "plot_01", TemplateId = "tmpl_a",
            Status = PlotStatus.Active, Phase = "infiltration",
            StartedCampaignDay = 10, DeadlineCampaignDay = 50,
            CompletedStepIds = { "step_1" },
            LinkedSecretIds = { "secret_01" }
        });

        store.RuntimeSecrets.Add(new RuntimeSecretRecord
        {
            Id = "secret_01", Description = "Guard rotation",
            AccessLevel = "restricted", Status = "active",
            Origin = new SecretOrigin { PlotId = "plot_01", StepId = "step_1" }
        });

        store.EventDiary.Append(new EventDiaryEntry
        {
            EventId = "ev_1", CampaignDay = 10,
            EventCode = "plot_point_emitted", PlotId = "plot_01"
        });

        store.Hooks.Add(new Hook
        {
            Id = "hook_01", Owner = "player",
            TargetHeroStringId = "lord_derthert",
            Description = "owes favor", Strength = "strong",
            Basis = new HookBasis { Kind = "secret", Id = "secret_01" }
        });

        store.RecallPhrases.Add(new RecallPhrase
        {
            PhraseId = "rp_01", Text = "since the ambush at Pen Cannoc",
            Binding = new RecallPhraseBinding { Kind = "diary_event", Id = "ev_1" }
        });

        store.Beliefs.SetConfidence("secret_01", "lord_a", "lord_a", 0.95);
        store.Beliefs.SetConfidence("secret_01", "lord_a", "lord_b", 0.3);

        string json = store.Serialize();
        var restored = IntrigueStore.Deserialize(json);

        Assert.That(restored.GetPlotById("plot_01").Phase, Is.EqualTo("infiltration"));
        Assert.That(restored.GetPlotById("plot_01").CompletedStepIds, Contains.Item("step_1"));
        Assert.That(restored.RuntimeSecrets.GetById("secret_01").Description, Is.EqualTo("Guard rotation"));
        Assert.That(restored.EventDiary.GetAll(), Has.Count.EqualTo(1));
        Assert.That(restored.Hooks.GetByTarget("lord_derthert"), Has.Count.EqualTo(1));
        Assert.That(restored.RecallPhrases.GetAll(), Has.Count.EqualTo(1));
        Assert.That(restored.Beliefs.GetConfidence("secret_01", "lord_a", "lord_a"), Is.EqualTo(0.95).Within(0.001));
        Assert.That(restored.Beliefs.GetConfidence("secret_01", "lord_a", "lord_b"), Is.EqualTo(0.3).Within(0.001));
    }

    [Test]
    public void EmptyStore_RoundTrip()
    {
        var store = new IntrigueStore();
        string json = store.Serialize();
        var restored = IntrigueStore.Deserialize(json);

        Assert.That(restored.GetAllPlots(), Is.Empty);
        Assert.That(restored.RuntimeSecrets.GetAll(), Is.Empty);
        Assert.That(restored.EventDiary.GetAll(), Is.Empty);
        Assert.That(restored.Hooks.GetByTarget("anyone"), Is.Empty);
        Assert.That(restored.RecallPhrases.GetAll(), Is.Empty);
        Assert.That(restored.Beliefs.GetConfidence("any", "a", "b"), Is.EqualTo(0.0));
    }

    [Test]
    public void Scheduler_Produces_DiaryEntries_That_Persist()
    {
        var store = new IntrigueStore();
        store.AddPlot(new PlotInstance
        {
            Id = "plot_01", TemplateId = "tmpl_a",
            Status = PlotStatus.Active, Phase = "init", StartedCampaignDay = 1
        });

        var template = new PlotTemplate
        {
            TemplateId = "tmpl_a",
            Steps = new List<PlotStep>
            {
                new PlotStep
                {
                    StepId = "step_1",
                    Triggers = new List<string> { "on_daily" },
                    Effects = new List<PlotEffect>
                    {
                        new PlotEffect { EffectType = PlotEffectType.EmitPlotPoint, TargetId = "pp_1" }
                    }
                }
            }
        };

        var scheduler = new PlotScheduler(
            store, store.EventDiary,
            new Dictionary<string, PlotTemplate> { ["tmpl_a"] = template });

        scheduler.OnTrigger("on_daily");

        Assert.That(store.EventDiary.GetAll(), Has.Count.EqualTo(1));

        string json = store.Serialize();
        var restored = IntrigueStore.Deserialize(json);

        Assert.That(restored.EventDiary.GetAll(), Has.Count.EqualTo(1));
        Assert.That(restored.EventDiary.GetAll()[0].PlotPointId, Is.EqualTo("pp_1"));
        Assert.That(restored.GetPlotById("plot_01").CompletedStepIds, Contains.Item("step_1"));
    }

    [Test]
    public void Proposal_Commit_Results_Persist()
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
                },
                new ProposalOperation
                {
                    OperationType = "create_hook",
                    TargetId = "hook_new",
                    Parameters = new Dictionary<string, string>
                    {
                        ["owner"] = "player",
                        ["target"] = "lord_x",
                        ["strength"] = "strong"
                    }
                }
            }
        };

        ProposalCommitter.Commit(proposal, store, store.EventDiary, store.Beliefs);

        string json = store.Serialize();
        var restored = IntrigueStore.Deserialize(json);

        Assert.That(restored.GetPlotById("plot_01").Phase, Is.EqualTo("phase_2"));
        Assert.That(restored.Hooks.GetByTarget("lord_x"), Has.Count.EqualTo(1));
        Assert.That(restored.Hooks.GetByTarget("lord_x")[0].Strength, Is.EqualTo("strong"));
    }
}
