using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace AIInfluence.WorldSystem;

[JsonObject(MemberSerialization.OptIn)]
public class RuntimeSecretStore
{
    [JsonProperty("secrets")]
    private List<RuntimeSecretRecord> _secrets = new List<RuntimeSecretRecord>();

    public void Add(RuntimeSecretRecord secret)
    {
        if (_secrets.Any(s => s.Id == secret.Id))
            throw new System.ArgumentException($"Runtime secret with id '{secret.Id}' already exists.");
        _secrets.Add(secret);
    }

    public RuntimeSecretRecord GetById(string id)
    {
        return _secrets.FirstOrDefault(s => s.Id == id);
    }

    public IReadOnlyList<RuntimeSecretRecord> GetAll()
    {
        return _secrets;
    }

    public string Serialize()
    {
        return JsonConvert.SerializeObject(this);
    }

    public static RuntimeSecretStore Deserialize(string json)
    {
        if (string.IsNullOrEmpty(json))
            return new RuntimeSecretStore();

        return JsonConvert.DeserializeObject<RuntimeSecretStore>(json) ?? new RuntimeSecretStore();
    }
}
