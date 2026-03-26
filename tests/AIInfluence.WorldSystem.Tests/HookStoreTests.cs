using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;
using AIInfluence.WorldSystem;

namespace AIInfluence.WorldSystem.Tests;

[TestFixture]
public class HookStoreTests
{
    [Test]
    public void Add_ThenGetByTarget_ReturnsHook()
    {
        var store = new HookStore();
        store.Add(new Hook
        {
            Id = "hook_01",
            Owner = "player",
            TargetHeroStringId = "lord_a",
            Description = "owes a favor",
            Basis = new HookBasis { Kind = "secret", Id = "secret_01" },
            Strength = "strong"
        });

        var hooks = store.GetByTarget("lord_a");
        Assert.That(hooks, Has.Count.EqualTo(1));
        Assert.That(hooks[0].Description, Is.EqualTo("owes a favor"));
    }

    [Test]
    public void GetByTarget_NoMatch_ReturnsEmpty()
    {
        var store = new HookStore();
        Assert.That(store.GetByTarget("nobody"), Is.Empty);
    }

    [Test]
    public void RoundTrip_Serialization()
    {
        var store = new HookStore();
        store.Add(new Hook
        {
            Id = "hook_01",
            Owner = "player",
            TargetHeroStringId = "lord_a",
            Description = "favor owed",
            Basis = new HookBasis { Kind = "event", Id = "ev_01" },
            Strength = "weak"
        });

        string json = store.Serialize();
        var restored = HookStore.Deserialize(json);

        Assert.That(restored.GetByTarget("lord_a"), Has.Count.EqualTo(1));
        Assert.That(restored.GetByTarget("lord_a")[0].Basis.Kind, Is.EqualTo("event"));
    }

    [Test]
    public void GetByOwner_FiltersCorrectly()
    {
        var store = new HookStore();
        store.Add(new Hook
        {
            Id = "h1", Owner = "player", TargetHeroStringId = "lord_a",
            Strength = "weak"
        });
        store.Add(new Hook
        {
            Id = "h2", Owner = "lord_b", TargetHeroStringId = "lord_a",
            Strength = "strong"
        });

        var playerHooks = store.GetByOwner("player");
        Assert.That(playerHooks, Has.Count.EqualTo(1));
        Assert.That(playerHooks[0].Id, Is.EqualTo("h1"));
    }
}

[TestFixture]
public class RecallPhraseTests
{
    [Test]
    public void RoundTrip_Serialization()
    {
        var phrase = new RecallPhrase
        {
            PhraseId = "rp_01",
            Text = "since the fire at Odokh",
            Binding = new RecallPhraseBinding { Kind = "diary_event", Id = "ev_fire_01" }
        };

        string json = JsonConvert.SerializeObject(phrase);
        var restored = JsonConvert.DeserializeObject<RecallPhrase>(json);

        Assert.That(restored.PhraseId, Is.EqualTo("rp_01"));
        Assert.That(restored.Text, Is.EqualTo("since the fire at Odokh"));
        Assert.That(restored.Binding.Kind, Is.EqualTo("diary_event"));
    }

    [Test]
    public void RecallPhraseStore_GetVisiblePhrases()
    {
        var phraseStore = new RecallPhraseStore();
        phraseStore.Add(new RecallPhrase
        {
            PhraseId = "rp_01",
            Text = "since you spared him",
            Binding = new RecallPhraseBinding { Kind = "plot_point", Id = "pp_01" }
        });
        phraseStore.Add(new RecallPhrase
        {
            PhraseId = "rp_02",
            Text = "the hidden passage",
            Binding = new RecallPhraseBinding { Kind = "secret", Id = "secret_01" }
        });

        var visibleBindingIds = new HashSet<string> { "pp_01" };
        var visible = phraseStore.GetVisiblePhrases(
            binding => visibleBindingIds.Contains(binding.Id));

        Assert.That(visible, Has.Count.EqualTo(1));
        Assert.That(visible[0].PhraseId, Is.EqualTo("rp_01"));
    }
}
