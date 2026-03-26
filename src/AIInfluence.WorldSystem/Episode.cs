using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class Episode
{
    [JsonProperty("episode_id")]
    public string EpisodeId { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("patterns")]
    public List<EventPattern> Patterns { get; set; } = new List<EventPattern>();

    [JsonProperty("resolution")]
    public Resolution Resolution { get; set; }

    public EpisodeEvalResult Evaluate(IReadOnlyList<EventDiaryEntry> entries)
    {
        foreach (var pattern in Patterns)
        {
            if (PatternMatcher.Matches(pattern, entries))
            {
                return new EpisodeEvalResult
                {
                    Fired = true,
                    MatchedPatternId = pattern.PatternId,
                    Resolution = Resolution
                };
            }
        }

        return new EpisodeEvalResult { Fired = false };
    }
}
