using System.Collections.Generic;
using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class PlotSchedulerTests
{
    [Test]
    public void Tick_RunsEligibleStep_OnMatchingTrigger()
    {
        var store = new IntrigueStore();
        store.AddPlot(new PlotInstance
        {
            Id = "plot_01",
            TemplateId = "tmpl_a",
            Status = PlotStatus.Active,
            Phase = "init",
            StartedCampaignDay = 1
        });
        var diary = new EventDiary();
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
        var templates = new Dictionary<string, PlotTemplate> { ["tmpl_a"] = template };
        var logs = new List<string>();
        var scheduler = new PlotScheduler(store, diary, templates, msg => logs.Add(msg));

        scheduler.OnTrigger("on_daily");

        Assert.That(diary.GetAll(), Has.Count.EqualTo(1));
        Assert.That(store.GetPlotById("plot_01").CompletedStepIds, Contains.Item("step_1"));
    }

    [Test]
    public void Tick_SkipsStep_WhenTriggerDoesNotMatch()
    {
        var store = new IntrigueStore();
        store.AddPlot(new PlotInstance
        {
            Id = "plot_01",
            TemplateId = "tmpl_a",
            Status = PlotStatus.Active,
            Phase = "init",
            StartedCampaignDay = 1
        });
        var diary = new EventDiary();
        var template = new PlotTemplate
        {
            TemplateId = "tmpl_a",
            Steps = new List<PlotStep>
            {
                new PlotStep
                {
                    StepId = "step_1",
                    Triggers = new List<string> { "on_battle_end" },
                    Effects = new List<PlotEffect>
                    {
                        new PlotEffect { EffectType = PlotEffectType.EmitPlotPoint, TargetId = "pp_1" }
                    }
                }
            }
        };
        var templates = new Dictionary<string, PlotTemplate> { ["tmpl_a"] = template };
        var scheduler = new PlotScheduler(store, diary, templates);

        scheduler.OnTrigger("on_daily");

        Assert.That(diary.GetAll(), Is.Empty);
    }

    [Test]
    public void Tick_DoesNotDoubleRun_AlreadyCompletedStep()
    {
        var store = new IntrigueStore();
        store.AddPlot(new PlotInstance
        {
            Id = "plot_01",
            TemplateId = "tmpl_a",
            Status = PlotStatus.Active,
            Phase = "init",
            StartedCampaignDay = 1,
            CompletedStepIds = { "step_1" }
        });
        var diary = new EventDiary();
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
        var templates = new Dictionary<string, PlotTemplate> { ["tmpl_a"] = template };
        var scheduler = new PlotScheduler(store, diary, templates);

        scheduler.OnTrigger("on_daily");

        Assert.That(diary.GetAll(), Is.Empty);
    }

    [Test]
    public void CorrelationId_InLogOutput()
    {
        var store = new IntrigueStore();
        store.AddPlot(new PlotInstance
        {
            Id = "plot_01",
            TemplateId = "tmpl_a",
            Status = PlotStatus.Active,
            Phase = "init",
            StartedCampaignDay = 1
        });
        var diary = new EventDiary();
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
        var templates = new Dictionary<string, PlotTemplate> { ["tmpl_a"] = template };
        var logs = new List<string>();
        var scheduler = new PlotScheduler(store, diary, templates, msg => logs.Add(msg));

        scheduler.OnTrigger("on_daily");

        Assert.That(logs, Has.Some.Contain("corr="));
        Assert.That(logs, Has.Some.Contain("plot_01"));
        Assert.That(logs, Has.Some.Contain("step_1"));
    }

    [Test]
    public void SkipsInactivePlots()
    {
        var store = new IntrigueStore();
        store.AddPlot(new PlotInstance
        {
            Id = "plot_done",
            TemplateId = "tmpl_a",
            Status = PlotStatus.Completed,
            Phase = "done",
            StartedCampaignDay = 1
        });
        var diary = new EventDiary();
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
        var templates = new Dictionary<string, PlotTemplate> { ["tmpl_a"] = template };
        var scheduler = new PlotScheduler(store, diary, templates);

        scheduler.OnTrigger("on_daily");

        Assert.That(diary.GetAll(), Is.Empty);
    }
}
