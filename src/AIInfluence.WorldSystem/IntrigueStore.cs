using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class IntrigueStore
{
    [JsonProperty("plots")]
    private List<PlotInstance> _plots = new List<PlotInstance>();

    [JsonProperty("runtime_secrets")]
    private RuntimeSecretStore _runtimeSecrets = new RuntimeSecretStore();

    public RuntimeSecretStore RuntimeSecrets => _runtimeSecrets;

    public void AddPlot(PlotInstance plot)
    {
        _plots.Add(plot);
    }

    public PlotInstance GetPlotById(string id)
    {
        return _plots.FirstOrDefault(p => p.Id == id);
    }

    public IReadOnlyList<PlotInstance> GetAllPlots()
    {
        return _plots;
    }

    public string Serialize()
    {
        return JsonConvert.SerializeObject(this);
    }

    public static IntrigueStore Deserialize(string json)
    {
        if (string.IsNullOrEmpty(json))
            return new IntrigueStore();

        var store = JsonConvert.DeserializeObject<IntrigueStore>(json);
        return store ?? new IntrigueStore();
    }
}
