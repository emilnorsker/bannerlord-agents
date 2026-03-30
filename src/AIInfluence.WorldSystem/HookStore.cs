using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class HookStore
{
    [JsonProperty("hooks")]
    private List<Hook> _hooks = new List<Hook>();

    public void Add(Hook hook)
    {
        _hooks.Add(hook);
    }

    public IReadOnlyList<Hook> GetByTarget(string targetHeroStringId)
    {
        return _hooks.Where(h => h.TargetHeroStringId == targetHeroStringId).ToList();
    }

    public IReadOnlyList<Hook> GetByOwner(string owner)
    {
        return _hooks.Where(h => h.Owner == owner).ToList();
    }

    public string Serialize()
    {
        return JsonConvert.SerializeObject(this);
    }

    public static HookStore Deserialize(string json)
    {
        if (string.IsNullOrEmpty(json))
            return new HookStore();

        return JsonConvert.DeserializeObject<HookStore>(json) ?? new HookStore();
    }
}
