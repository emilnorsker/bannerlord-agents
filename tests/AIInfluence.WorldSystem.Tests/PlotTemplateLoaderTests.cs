using System.Collections.Generic;
using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class PlotTemplateLoaderTests
{
    [Test]
    public void LoadFromJson_ParsesTemplates()
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(new List<PlotTemplate>
        {
            new PlotTemplate
            {
                TemplateId = "tmpl_a",
                Steps = new List<PlotStep>
                {
                    new PlotStep
                    {
                        StepId = "s1",
                        Triggers = new List<string> { "on_daily" },
                        Effects = new List<PlotEffect>
                        {
                            new PlotEffect { EffectType = PlotEffectType.EmitPlotPoint, TargetId = "pp_1" }
                        }
                    }
                },
                Version = "1.0"
            }
        });

        var logs = new List<string>();
        var result = PlotTemplateLoader.LoadFromJson(json, msg => logs.Add(msg));

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result.ContainsKey("tmpl_a"), Is.True);
        Assert.That(result["tmpl_a"].Steps, Has.Count.EqualTo(1));
    }

    [Test]
    public void LoadFromJson_SkipsEmptyTemplateId()
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(new List<PlotTemplate>
        {
            new PlotTemplate { TemplateId = "", Version = "1.0" },
            new PlotTemplate { TemplateId = "tmpl_ok", Version = "1.0" }
        });

        var logs = new List<string>();
        var result = PlotTemplateLoader.LoadFromJson(json, msg => logs.Add(msg));

        Assert.That(result, Has.Count.EqualTo(1));
        Assert.That(result.ContainsKey("tmpl_ok"), Is.True);
    }

    [Test]
    public void LoadFromFile_MissingFile_ReturnsEmpty()
    {
        var logs = new List<string>();
        var result = PlotTemplateLoader.LoadFromFile("/nonexistent/path.json", msg => logs.Add(msg));

        Assert.That(result, Is.Empty);
        Assert.That(logs, Has.Some.Contain("not found"));
    }
}
