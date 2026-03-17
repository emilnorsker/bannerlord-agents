using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AIInfluence;

[JsonSerializable]
public class SpawnNpcEquipment
{
	[JsonProperty("weapon")]
	public string Weapon { get; set; }

	[JsonProperty("shield")]
	public string Shield { get; set; }

	[JsonProperty("head")]
	public string Head { get; set; }

	[JsonProperty("body")]
	public string Body { get; set; }

	[JsonProperty("cape")]
	public string Cape { get; set; }

	[JsonProperty("gloves")]
	public string Gloves { get; set; }

	[JsonProperty("legs")]
	public string Legs { get; set; }

	[JsonProperty("horse")]
	public string Horse { get; set; }

	[JsonProperty("tier")]
	[JsonConverter(typeof(LenientIntConverter))]
	public int? Tier { get; set; }
}

[JsonSerializable]
public class SpawnNpcData
{
	[JsonProperty("name")]
	public string Name { get; set; }

	[JsonProperty("culture")]
	public string Culture { get; set; }

	[JsonProperty("is_female")]
	[JsonConverter(typeof(LenientBoolConverter))]
	public bool? IsFemale { get; set; }

	[JsonProperty("age")]
	[JsonConverter(typeof(LenientIntConverter))]
	public int? Age { get; set; }

	[JsonProperty("occupation")]
	public string Occupation { get; set; }

	[JsonProperty("backstory")]
	public string Backstory { get; set; }

	[JsonProperty("personality")]
	public string Personality { get; set; }

	[JsonProperty("alignment")]
	public string Alignment { get; set; }

	[JsonProperty("faction")]
	public string Faction { get; set; }

	[JsonProperty("settlement")]
	public string Settlement { get; set; }

	[JsonProperty("equipment")]
	public SpawnNpcEquipment Equipment { get; set; }

	[JsonProperty("party_name")]
	public string PartyName { get; set; }

	[JsonProperty("party_troops")]
	[JsonConverter(typeof(StringOrArrayConverter))]
	public List<string> PartyTroops { get; set; }

	[JsonProperty("party_size")]
	[JsonConverter(typeof(LenientIntConverter))]
	public int? PartySize { get; set; }
}

public class StringOrArrayConverter : JsonConverter<List<string>>
{
	public override List<string> ReadJson(JsonReader reader, Type objectType, List<string> existingValue, bool hasExistingValue, JsonSerializer serializer)
	{
		JToken token = JToken.Load(reader);
		if (token.Type == JTokenType.String)
			return new List<string> { token.ToString() };
		if (token.Type == JTokenType.Array)
			return token.ToObject<List<string>>();
		return new List<string>();
	}

	public override void WriteJson(JsonWriter writer, List<string> value, JsonSerializer serializer)
	{
		serializer.Serialize(writer, value);
	}
}

public class LenientBoolConverter : JsonConverter<bool?>
{
	public override bool? ReadJson(JsonReader reader, Type objectType, bool? existingValue, bool hasExistingValue, JsonSerializer serializer)
	{
		JToken token = JToken.Load(reader);
		if (token.Type == JTokenType.Boolean)
			return token.Value<bool>();
		if (token.Type == JTokenType.String)
		{
			string s = token.ToString().Trim().ToLowerInvariant();
			if (s == "true" || s == "yes" || s == "female" || s == "f" || s == "1")
				return true;
			if (s == "false" || s == "no" || s == "male" || s == "m" || s == "0")
				return false;
		}
		if (token.Type == JTokenType.Integer)
			return token.Value<int>() != 0;
		return null;
	}

	public override void WriteJson(JsonWriter writer, bool? value, JsonSerializer serializer)
	{
		serializer.Serialize(writer, value);
	}
}

public class LenientIntConverter : JsonConverter<int?>
{
	public override int? ReadJson(JsonReader reader, Type objectType, int? existingValue, bool hasExistingValue, JsonSerializer serializer)
	{
		JToken token = JToken.Load(reader);
		if (token.Type == JTokenType.Integer)
			return token.Value<int>();
		if (token.Type == JTokenType.Float)
			return (int)Math.Round(token.Value<float>());
		if (token.Type == JTokenType.String && int.TryParse(token.ToString().Trim(), out int result))
			return result;
		return null;
	}

	public override void WriteJson(JsonWriter writer, int? value, JsonSerializer serializer)
	{
		serializer.Serialize(writer, value);
	}
}
