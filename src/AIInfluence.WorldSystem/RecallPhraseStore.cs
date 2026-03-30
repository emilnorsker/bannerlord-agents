using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class RecallPhraseStore
{
    [JsonProperty("phrases")]
    private List<RecallPhrase> _phrases = new List<RecallPhrase>();

    public void Add(RecallPhrase phrase)
    {
        _phrases.Add(phrase);
    }

    public IReadOnlyList<RecallPhrase> GetVisiblePhrases(Func<RecallPhraseBinding, bool> visibilityPredicate)
    {
        return _phrases.Where(p => visibilityPredicate(p.Binding)).ToList();
    }

    public IReadOnlyList<RecallPhrase> GetAll()
    {
        return _phrases;
    }
}
