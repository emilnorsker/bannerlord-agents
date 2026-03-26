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

    [JsonProperty("event_diary")]
    private EventDiary _eventDiary = new EventDiary();

    [JsonProperty("hooks")]
    private HookStore _hooks = new HookStore();

    [JsonProperty("recall_phrases")]
    private RecallPhraseStore _recallPhrases = new RecallPhraseStore();

    [JsonProperty("beliefs")]
    private BeliefService _beliefs = new BeliefService();

    public RuntimeSecretStore RuntimeSecrets => _runtimeSecrets;

    public EventDiary EventDiary => _eventDiary;

    public HookStore Hooks => _hooks;

    public RecallPhraseStore RecallPhrases => _recallPhrases;

    public BeliefService Beliefs => _beliefs;

    public void AddPlot(PlotInstance plot)
    {
        if (_plots.Any(p => p.Id == plot.Id))
            throw new System.ArgumentException($"Plot with id '{plot.Id}' already exists.");
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
