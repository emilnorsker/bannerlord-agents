using System.Collections.Generic;
using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class BeliefService
{
    [JsonProperty("matrices")]
    private Dictionary<string, Dictionary<string, Dictionary<string, double>>> _matrices
        = new Dictionary<string, Dictionary<string, Dictionary<string, double>>>();

    public void SetConfidence(string beliefKey, string fromHero, string aboutHero, double value)
    {
        if (!_matrices.TryGetValue(beliefKey, out var matrix))
        {
            matrix = new Dictionary<string, Dictionary<string, double>>();
            _matrices[beliefKey] = matrix;
        }

        if (!matrix.TryGetValue(fromHero, out var row))
        {
            row = new Dictionary<string, double>();
            matrix[fromHero] = row;
        }

        row[aboutHero] = value;
    }

    public double GetConfidence(string beliefKey, string fromHero, string aboutHero)
    {
        if (_matrices.TryGetValue(beliefKey, out var matrix)
            && matrix.TryGetValue(fromHero, out var row)
            && row.TryGetValue(aboutHero, out var value))
        {
            return value;
        }
        return 0.0;
    }

    public void Propagate(string beliefKey, string sourceHero, string targetHero, double confidence)
    {
        SetConfidence(beliefKey, targetHero, targetHero, confidence);
        SetConfidence(beliefKey, sourceHero, targetHero, confidence);
    }

    public string Serialize()
    {
        return JsonConvert.SerializeObject(this);
    }

    public static BeliefService Deserialize(string json)
    {
        if (string.IsNullOrEmpty(json))
            return new BeliefService();

        return JsonConvert.DeserializeObject<BeliefService>(json) ?? new BeliefService();
    }
}
