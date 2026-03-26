using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class EpisodeTests
{
    [Test]
    public void Resolution_RoundTrip()
    {
        var resolution = new Resolution
        {
            RStateLiterals = new List<string> { "+war_declared", "-truce_active" },
            RGoals = new List<ResolutionGoal>
            {
                new ResolutionGoal { HeroId = "lord_a", GoalId = "flee_kingdom" }
            }
        };

        string json = JsonConvert.SerializeObject(resolution);
        var restored = JsonConvert.DeserializeObject<Resolution>(json);

        Assert.That(restored.RStateLiterals, Has.Count.EqualTo(2));
        Assert.That(restored.RStateLiterals, Contains.Item("+war_declared"));
        Assert.That(restored.RGoals, Has.Count.EqualTo(1));
        Assert.That(restored.RGoals[0].GoalId, Is.EqualTo("flee_kingdom"));
    }

    [Test]
    public void Episode_RoundTrip()
    {
        var episode = new Episode
        {
            EpisodeId = "ep_betrayal",
            Name = "The Betrayal",
            Patterns = new List<EventPattern>
            {
                new EventPattern
                {
                    PatternId = "p_kill",
                    MatchType = PatternMatchType.Single,
                    Events = new List<EventTemplate>
                    {
                        new EventTemplate { EventCode = "hero_killed" }
                    }
                }
            },
            Resolution = new Resolution
            {
                RStateLiterals = new List<string> { "+betrayal_revealed" },
                RGoals = new List<ResolutionGoal>()
            }
        };

        string json = JsonConvert.SerializeObject(episode);
        var restored = JsonConvert.DeserializeObject<Episode>(json);

        Assert.That(restored.EpisodeId, Is.EqualTo("ep_betrayal"));
        Assert.That(restored.Patterns, Has.Count.EqualTo(1));
        Assert.That(restored.Resolution.RStateLiterals, Contains.Item("+betrayal_revealed"));
    }

    [Test]
    public void Episode_EvaluateAgainstDiary_MatchingPattern()
    {
        var diary = new EventDiary();
        diary.Append(new EventDiaryEntry { EventId = "e1", CampaignDay = 1, EventCode = "hero_killed" });

        var episode = new Episode
        {
            EpisodeId = "ep_1",
            Name = "Kill Episode",
            Patterns = new List<EventPattern>
            {
                new EventPattern
                {
                    PatternId = "p1",
                    MatchType = PatternMatchType.Single,
                    Events = new List<EventTemplate>
                    {
                        new EventTemplate { EventCode = "hero_killed" }
                    }
                }
            },
            Resolution = new Resolution
            {
                RStateLiterals = new List<string> { "+killed" },
                RGoals = new List<ResolutionGoal>()
            }
        };

        var result = episode.Evaluate(diary.GetAll());
        Assert.That(result.Fired, Is.True);
        Assert.That(result.MatchedPatternId, Is.EqualTo("p1"));
    }

    [Test]
    public void Episode_EvaluateAgainstDiary_NoMatch()
    {
        var diary = new EventDiary();
        diary.Append(new EventDiaryEntry { EventId = "e1", CampaignDay = 1, EventCode = "battle_end" });

        var episode = new Episode
        {
            EpisodeId = "ep_1",
            Name = "Kill Episode",
            Patterns = new List<EventPattern>
            {
                new EventPattern
                {
                    PatternId = "p1",
                    MatchType = PatternMatchType.Single,
                    Events = new List<EventTemplate>
                    {
                        new EventTemplate { EventCode = "hero_killed" }
                    }
                }
            },
            Resolution = new Resolution
            {
                RStateLiterals = new List<string> { "+killed" },
                RGoals = new List<ResolutionGoal>()
            }
        };

        var result = episode.Evaluate(diary.GetAll());
        Assert.That(result.Fired, Is.False);
        Assert.That(result.MatchedPatternId, Is.Null);
    }
}
