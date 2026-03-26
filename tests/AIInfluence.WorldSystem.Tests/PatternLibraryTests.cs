using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class PatternLibraryTests
{
    [Test]
    public void LoadFromJson_RegistersPatterns()
    {
        var json = JsonConvert.SerializeObject(new PatternLibrary
        {
            LibraryId = "lib_v1",
            TemplateId = "tmpl_assassination",
            Patterns = new List<EventPattern>
            {
                new EventPattern
                {
                    PatternId = "p_guard_killed",
                    MatchType = PatternMatchType.Single,
                    Events = new List<EventTemplate>
                    {
                        new EventTemplate { EventCode = "guard_killed" }
                    }
                }
            }
        });

        var loaded = PatternLibrary.FromJson(json);

        Assert.That(loaded.LibraryId, Is.EqualTo("lib_v1"));
        Assert.That(loaded.TemplateId, Is.EqualTo("tmpl_assassination"));
        Assert.That(loaded.Patterns, Has.Count.EqualTo(1));
        Assert.That(loaded.Patterns[0].PatternId, Is.EqualTo("p_guard_killed"));
    }

    [Test]
    public void PatternLibraryRegistry_GetByTemplateId()
    {
        var registry = new PatternLibraryRegistry();
        var library = new PatternLibrary
        {
            LibraryId = "lib_v1",
            TemplateId = "tmpl_a",
            Patterns = new List<EventPattern>()
        };

        registry.Register(library);
        var retrieved = registry.GetByTemplateId("tmpl_a");

        Assert.That(retrieved, Is.Not.Null);
        Assert.That(retrieved.LibraryId, Is.EqualTo("lib_v1"));
    }

    [Test]
    public void PatternLibraryRegistry_UnknownTemplate_ReturnsNull()
    {
        var registry = new PatternLibraryRegistry();
        Assert.That(registry.GetByTemplateId("tmpl_nonexistent"), Is.Null);
    }

    [Test]
    public void PatternLibrary_RoundTrip()
    {
        var library = new PatternLibrary
        {
            LibraryId = "lib_v2",
            TemplateId = "tmpl_b",
            Patterns = new List<EventPattern>
            {
                new EventPattern
                {
                    PatternId = "p1",
                    MatchType = PatternMatchType.Consecutive,
                    Events = new List<EventTemplate>
                    {
                        new EventTemplate { EventCode = "a" },
                        new EventTemplate { EventCode = "b" }
                    }
                }
            }
        };

        string json = JsonConvert.SerializeObject(library);
        var restored = JsonConvert.DeserializeObject<PatternLibrary>(json);

        Assert.That(restored.Patterns[0].Events, Has.Count.EqualTo(2));
    }
}
