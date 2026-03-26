using System.Collections.Generic;
using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class PatternMatcherTests
{
    [Test]
    public void Single_MatchesOneEvent()
    {
        var diary = MakeDiary("battle_end", "peace_declared", "settlement_enter");
        var pattern = new EventPattern
        {
            PatternId = "p1",
            MatchType = PatternMatchType.Single,
            Events = new List<EventTemplate> { new EventTemplate { EventCode = "peace_declared" } }
        };

        Assert.That(PatternMatcher.Matches(pattern, diary.GetAll()), Is.True);
    }

    [Test]
    public void Single_NoMatch()
    {
        var diary = MakeDiary("battle_end", "settlement_enter");
        var pattern = new EventPattern
        {
            PatternId = "p1",
            MatchType = PatternMatchType.Single,
            Events = new List<EventTemplate> { new EventTemplate { EventCode = "peace_declared" } }
        };

        Assert.That(PatternMatcher.Matches(pattern, diary.GetAll()), Is.False);
    }

    [Test]
    public void Consecutive_MatchesAdjacentPair()
    {
        var diary = MakeDiary("battle_end", "hero_killed", "peace_declared");
        var pattern = new EventPattern
        {
            PatternId = "p2",
            MatchType = PatternMatchType.Consecutive,
            Events = new List<EventTemplate>
            {
                new EventTemplate { EventCode = "battle_end" },
                new EventTemplate { EventCode = "hero_killed" }
            }
        };

        Assert.That(PatternMatcher.Matches(pattern, diary.GetAll()), Is.True);
    }

    [Test]
    public void Consecutive_FailsWhenNotAdjacent()
    {
        var diary = MakeDiary("battle_end", "settlement_enter", "hero_killed");
        var pattern = new EventPattern
        {
            PatternId = "p2",
            MatchType = PatternMatchType.Consecutive,
            Events = new List<EventTemplate>
            {
                new EventTemplate { EventCode = "battle_end" },
                new EventTemplate { EventCode = "hero_killed" }
            }
        };

        Assert.That(PatternMatcher.Matches(pattern, diary.GetAll()), Is.False);
    }

    [Test]
    public void NonConsecutive_MatchesWithGap()
    {
        var diary = MakeDiary("battle_end", "settlement_enter", "hero_killed");
        var pattern = new EventPattern
        {
            PatternId = "p3",
            MatchType = PatternMatchType.NonConsecutive,
            Events = new List<EventTemplate>
            {
                new EventTemplate { EventCode = "battle_end" },
                new EventTemplate { EventCode = "hero_killed" }
            }
        };

        Assert.That(PatternMatcher.Matches(pattern, diary.GetAll()), Is.True);
    }

    [Test]
    public void NonConsecutive_FailsWhenOrderWrong()
    {
        var diary = MakeDiary("hero_killed", "settlement_enter", "battle_end");
        var pattern = new EventPattern
        {
            PatternId = "p3",
            MatchType = PatternMatchType.NonConsecutive,
            Events = new List<EventTemplate>
            {
                new EventTemplate { EventCode = "battle_end" },
                new EventTemplate { EventCode = "hero_killed" }
            }
        };

        Assert.That(PatternMatcher.Matches(pattern, diary.GetAll()), Is.False);
    }

    [Test]
    public void Wildcard_MatchesAnyEventCode()
    {
        var diary = MakeDiary("battle_end", "hero_killed");
        var pattern = new EventPattern
        {
            PatternId = "p4",
            MatchType = PatternMatchType.Consecutive,
            Events = new List<EventTemplate>
            {
                new EventTemplate { EventCode = "*" },
                new EventTemplate { EventCode = "hero_killed" }
            }
        };

        Assert.That(PatternMatcher.Matches(pattern, diary.GetAll()), Is.True);
    }

    [Test]
    public void Negated_TrueWhenPatternDoesNotMatch()
    {
        var diary = MakeDiary("battle_end", "settlement_enter");
        var pattern = new EventPattern
        {
            PatternId = "p5",
            MatchType = PatternMatchType.Single,
            Negated = true,
            Events = new List<EventTemplate> { new EventTemplate { EventCode = "peace_declared" } }
        };

        Assert.That(PatternMatcher.Matches(pattern, diary.GetAll()), Is.True);
    }

    [Test]
    public void Negated_FalseWhenPatternMatches()
    {
        var diary = MakeDiary("battle_end", "peace_declared");
        var pattern = new EventPattern
        {
            PatternId = "p5",
            MatchType = PatternMatchType.Single,
            Negated = true,
            Events = new List<EventTemplate> { new EventTemplate { EventCode = "peace_declared" } }
        };

        Assert.That(PatternMatcher.Matches(pattern, diary.GetAll()), Is.False);
    }

    [Test]
    public void EmptyDiary_NeverMatches()
    {
        var diary = new EventDiary();
        var pattern = new EventPattern
        {
            PatternId = "p6",
            MatchType = PatternMatchType.Single,
            Events = new List<EventTemplate> { new EventTemplate { EventCode = "battle_end" } }
        };

        Assert.That(PatternMatcher.Matches(pattern, diary.GetAll()), Is.False);
    }

    [Test]
    public void EmptyPattern_AlwaysMatches()
    {
        var diary = MakeDiary("battle_end");
        var pattern = new EventPattern
        {
            PatternId = "p7",
            MatchType = PatternMatchType.Single,
            Events = new List<EventTemplate>()
        };

        Assert.That(PatternMatcher.Matches(pattern, diary.GetAll()), Is.True);
    }

    private static EventDiary MakeDiary(params string[] codes)
    {
        var diary = new EventDiary();
        int index = 0;
        foreach (var code in codes)
        {
            diary.Append(new EventDiaryEntry
            {
                EventId = "ev_" + index++,
                CampaignDay = 10,
                EventCode = code
            });
        }
        return diary;
    }
}
