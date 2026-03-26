using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class EventDiary
{
    [JsonProperty("entries")]
    private List<EventDiaryEntry> _entries = new List<EventDiaryEntry>();

    [JsonProperty("next_sequence")]
    private long _nextSequence = 1;

    public void Append(EventDiaryEntry entry)
    {
        entry.Sequence = _nextSequence++;
        _entries.Add(entry);
    }

    public IReadOnlyList<EventDiaryEntry> GetAll()
    {
        return _entries;
    }

    public IReadOnlyList<EventDiaryEntry> GetTail(int count)
    {
        if (count >= _entries.Count)
            return _entries;

        return _entries.GetRange(_entries.Count - count, count);
    }

    public string Serialize()
    {
        return JsonConvert.SerializeObject(this);
    }

    public static EventDiary Deserialize(string json)
    {
        if (string.IsNullOrEmpty(json))
            return new EventDiary();

        return JsonConvert.DeserializeObject<EventDiary>(json) ?? new EventDiary();
    }
}
