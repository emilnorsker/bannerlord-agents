#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AIInfluence;

public static class JsonCleaner
{
	public static string CleanJsonGeneric(string rawResponse)
	{
		//IL_00d9: Expected O, but got Unknown
		if (string.IsNullOrWhiteSpace(rawResponse))
		{
			return null;
		}
		string text = rawResponse.Trim();
		string[] source = text.Split(new char[2] { '\r', '\n' }, StringSplitOptions.None);
		List<string> values = source.Where((string line) => !line.Trim().StartsWith("```")).ToList();
		text = string.Join("\n", values);
		text = text.Trim();
		int num = text.IndexOf('{');
		if (num > 0)
		{
			text = text.Substring(num);
		}
		int num2 = text.LastIndexOf('}');
		if (num2 >= 0 && num2 < text.Length - 1)
		{
			text = text.Substring(0, num2 + 1);
		}
		text = text.Trim();
		try
		{
			JObject val = JObject.Parse(text);
			return text;
		}
		catch (JsonException ex)
		{
			JsonException ex2 = ex;
			return TryAggressiveCleanup(text);
		}
	}

	private static string TryAggressiveCleanup(string json)
	{
		try
		{
			int num = json.IndexOf('{');
			int num2 = json.LastIndexOf('}');
			if (num >= 0 && num2 > num)
			{
				string text = json.Substring(num, num2 - num + 1);
				int num3 = text.Count((char c) => c == '[');
				int num4 = text.Count((char c) => c == ']');
				if (num3 > num4)
				{
					for (int num5 = 0; num5 < num3 - num4; num5++)
					{
						int num6 = text.LastIndexOf(',');
						int num7 = text.LastIndexOf('}');
						if (num6 > 0 && num6 < num7)
						{
							text = text.Insert(num7, "]");
						}
					}
				}
				text = Regex.Replace(text, "\\}\\s*\\]", "}");
				JObject val = JObject.Parse(text);
				return text;
			}
		}
		catch (JsonException)
		{
		}
		return null;
	}

	public static string CleanJsonResponse(string rawResponse)
	{
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Invalid comparison between Unknown and I4
		if (string.IsNullOrWhiteSpace(rawResponse))
		{
			return CreateFallbackJson();
		}
		string input = rawResponse.Trim();
		input = Regex.Replace(input, "^```json\\s*|\\s*```$", "");
		int num = input.IndexOf('{');
		if (num > 0)
		{
			input = input.Substring(num);
		}
		int num2 = input.LastIndexOf('}');
		if (num2 >= 0 && num2 < input.Length - 1)
		{
			input = input.Substring(0, num2 + 1);
		}
		input = Regex.Replace(input, "^\\s*#.*?(?=\\n|$)", "");
		input = Regex.Replace(input, "^\\s*[\\r\\n]+", "");
		input = input.Trim().TrimEnd(new char[1] { ']' }).TrimStart(new char[1] { '[' });
		try
		{
			JObject val = JObject.Parse(input);
			if (val["Response"] != null && (int)val["Response"].Type == 8)
			{
				string input2 = ((object)val["Response"]).ToString();
				input2 = Regex.Replace(input2, "^json\\s*\\njson\\s*\\n", "");
				input2 = input2.Trim();
				try
				{
					JObject jsonObject = JObject.Parse(input2);
					string text = ValidateAndNormalizeJson(jsonObject);
					if (!string.IsNullOrEmpty(text))
					{
						return text;
					}
				}
				catch (JsonException)
				{
					input2 = FixCommonJsonIssues(input2);
					try
					{
						JObject jsonObject2 = JObject.Parse(input2);
						string text2 = ValidateAndNormalizeJson(jsonObject2);
						if (!string.IsNullOrEmpty(text2))
						{
							return text2;
						}
					}
					catch (JsonException)
					{
					}
				}
			}
			if (IsValidJson(input))
			{
				JObject jsonObject3 = JObject.Parse(input);
				string text3 = ValidateAndNormalizeJson(jsonObject3);
				if (!string.IsNullOrEmpty(text3))
				{
					return text3;
				}
			}
		}
		catch (JsonException)
		{
			Match match = Regex.Match(input, "\\{[^{}]*(?:\\{[^{}]*\\}[^{}]*)*\\}");
			if (match.Success)
			{
				string value = match.Value;
				try
				{
					JObject jsonObject4 = JObject.Parse(value);
					string text4 = ValidateAndNormalizeJson(jsonObject4);
					if (!string.IsNullOrEmpty(text4))
					{
						return text4;
					}
				}
				catch (JsonException)
				{
				}
			}
			Match match2 = Regex.Match(input, "\\{.*\\}", RegexOptions.Singleline);
			if (match2.Success)
			{
				string value2 = match2.Value;
				try
				{
					JObject jsonObject5 = JObject.Parse(value2);
					string text5 = ValidateAndNormalizeJson(jsonObject5);
					if (!string.IsNullOrEmpty(text5))
					{
						return text5;
					}
				}
				catch (JsonException)
				{
				}
			}
		}
		string responseText = ExtractFallbackResponse(rawResponse, "");
		return CreateFallbackJson(responseText);
	}

	private static string CreateFallbackJson(string responseText = "I have nothing to say right now.")
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		JObject val = new JObject
		{
			["internal_thoughts"] = (JToken)(object)JValue.CreateNull(),
			["response"] = (JToken)(responseText.Replace("\"", "\\\"")),
			["romance_intent"] = (JToken)("none"),
			["decision"] = (JToken)("none"),
			["tone"] = (JToken)("neutral"),
			["threat_level"] = (JToken)("none"),
			["escalation_state"] = (JToken)("neutral"),
			["suspected_lie"] = (JToken)(false),
			["deescalation_attempt"] = (JToken)(false),
			["claimed_name"] = (JToken)(object)JValue.CreateNull(),
			["claimed_clan"] = (JToken)(object)JValue.CreateNull(),
			["claimed_age"] = (JToken)(object)JValue.CreateNull(),
			["claimed_gold"] = (JToken)(0),
			["money_transfer"] = (JToken)(object)JValue.CreateNull(),
			["item_transfers"] = (JToken)(object)JValue.CreateNull(),
			["character_personality"] = (JToken)(object)JValue.CreateNull(),
			["character_backstory"] = (JToken)(object)JValue.CreateNull(),
			["kingdom_action"] = (JToken)("none"),
			["kingdom_action_reason"] = (JToken)(object)JValue.CreateNull(),
			["settlement_id"] = (JToken)(object)JValue.CreateNull(),
			["target_clan_id"] = (JToken)(object)JValue.CreateNull(),
			["daily_tribute_amount"] = (JToken)(0),
			["tribute_duration_days"] = (JToken)(0),
			["reparations_amount"] = (JToken)(0),
			["allows_letters"] = (JToken)(false),
			["trade_agreement_duration_years"] = (JToken)(1f),
			["technical_action"] = (JToken)(object)JValue.CreateNull(),
			["character_death"] = (JToken)(object)JValue.CreateNull(),
			["tts_instructions"] = (JToken)(object)JValue.CreateNull()
		};
		return JsonConvert.SerializeObject((object)val);
	}

	private static string ValidateAndNormalizeJson(JObject jsonObject)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Invalid comparison between Unknown and I4
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Invalid comparison between Unknown and I4
		//IL_02f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Invalid comparison between Unknown and I4
		//IL_0358: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Invalid comparison between Unknown and I4
		try
		{
			JObject val = new JObject();
			foreach (JProperty item in jsonObject.Properties())
			{
				string text = NormalizeFieldName(item.Name);
				val[text] = item.Value.DeepClone();
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>
			{
				["response"] = "I have nothing to say right now.",
				["romance_intent"] = "none",
				["decision"] = "none",
				["tone"] = "neutral",
				["threat_level"] = "none",
				["escalation_state"] = "neutral",
				["kingdom_action"] = "none"
			};
			Dictionary<string, int> dictionary2 = new Dictionary<string, int>
			{
				["claimed_gold"] = 0,
				["daily_tribute_amount"] = 0,
				["tribute_duration_days"] = 0,
				["reparations_amount"] = 0
			};
			Dictionary<string, bool> dictionary3 = new Dictionary<string, bool>
			{
				["suspected_lie"] = false,
				["deescalation_attempt"] = false,
				["allows_letters"] = false
			};
			string[] array = new string[16]
			{
				"internal_thoughts", "claimed_name", "claimed_clan", "claimed_age", "money_transfer", "item_transfers", "character_personality", "character_backstory", "kingdom_action_reason", "settlement_id",
				"target_clan_id", "technical_action", "character_death", "tts_instructions", "workshop_action", "workshop_string_id"
			};
			foreach (KeyValuePair<string, string> item2 in dictionary)
			{
				if (val[item2.Key] == null || (int)val[item2.Key].Type == 10)
				{
					val[item2.Key] = (JToken)(item2.Value);
				}
			}
			foreach (KeyValuePair<string, int> item3 in dictionary2)
			{
				if (val[item3.Key] == null || (int)val[item3.Key].Type == 10)
				{
					val[item3.Key] = (JToken)(item3.Value);
				}
			}
			foreach (KeyValuePair<string, bool> item4 in dictionary3)
			{
				if (val[item4.Key] == null || (int)val[item4.Key].Type == 10)
				{
					val[item4.Key] = (JToken)(item4.Value);
				}
			}
			if (val["trade_agreement_duration_years"] == null || (int)val["trade_agreement_duration_years"].Type == 10)
			{
				val["trade_agreement_duration_years"] = (JToken)(1f);
			}
			string[] array2 = array;
			foreach (string text2 in array2)
			{
				if (!val.ContainsKey(text2))
				{
					val[text2] = (JToken)(object)JValue.CreateNull();
				}
			}
			EnsureArray(val, "witnesses");
			EnsureArrayOrNull(val, "lords");
			EnsureObject(val, "notable_phrases");
			EnsureArrayOrNull(val, "item_transfers");
			ValidateJsonFieldValues(val);
			string text3 = JsonConvert.SerializeObject((object)val);
			if (IsValidJson(text3))
			{
				return text3;
			}
			Debug.WriteLine("[JsonCleaner] ValidateAndNormalizeJson: Result JSON is not valid after normalization");
			return string.Empty;
		}
		catch (Exception ex)
		{
			Debug.WriteLine("[JsonCleaner] ValidateAndNormalizeJson exception: " + ex.Message);
			return string.Empty;
		}
	}

	private static string NormalizeFieldName(string fieldName)
	{
		if (string.IsNullOrEmpty(fieldName))
		{
			return fieldName;
		}
		return fieldName switch
		{
			"InternalThoughts" => "internal_thoughts", 
			"Response" => "response", 
			"SuspectedLie" => "suspected_lie", 
			"Tone" => "tone", 
			"ThreatLevel" => "threat_level", 
			"EscalationState" => "escalation_state", 
			"DeescalationAttempt" => "deescalation_attempt", 
			"Decision" => "decision", 
			"CharacterPersonality" => "character_personality", 
			"CharacterBackstory" => "character_backstory", 
			"CharacterSpeechQuirks" => "character_speech_quirks", 
			"AllowsLettersFromNPC" => "allows_letters", 
			_ => fieldName.ToLower(), 
		};
	}

	private static void ValidateJsonFieldValues(JObject jsonObject)
	{
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_027a: Invalid comparison between Unknown and I4
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Invalid comparison between Unknown and I4
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Invalid comparison between Unknown and I4
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Invalid comparison between Unknown and I4
		if (jsonObject["romance_intent"] != null)
		{
			string value = ((object)jsonObject["romance_intent"]).ToString();
			if (!new string[4] { "none", "flirt", "romance", "proposal" }.Contains(value))
			{
				jsonObject["romance_intent"] = (JToken)("none");
			}
		}
		if (jsonObject["decision"] != null)
		{
			string value2 = ((object)jsonObject["decision"]).ToString();
			if (!new string[9] { "none", "attack", "surrender", "accept_surrender", "release", "propose_marriage", "accept_marriage", "reject_marriage", "intimate" }.Contains(value2))
			{
				jsonObject["decision"] = (JToken)("none");
			}
		}
		if (jsonObject["tone"] != null)
		{
			string value3 = ((object)jsonObject["tone"]).ToString();
			if (!new string[3] { "positive", "negative", "neutral" }.Contains(value3))
			{
				jsonObject["tone"] = (JToken)("neutral");
			}
		}
		if (jsonObject["threat_level"] != null)
		{
			string value4 = ((object)jsonObject["threat_level"]).ToString();
			if (!new string[3] { "high", "low", "none" }.Contains(value4))
			{
				jsonObject["threat_level"] = (JToken)("none");
			}
		}
		if (jsonObject["escalation_state"] != null)
		{
			string value5 = ((object)jsonObject["escalation_state"]).ToString();
			if (!new string[3] { "neutral", "tense", "critical" }.Contains(value5))
			{
				jsonObject["escalation_state"] = (JToken)("neutral");
			}
		}
		if (jsonObject["suspected_lie"] != null && (int)jsonObject["suspected_lie"].Type != 9)
		{
			jsonObject["suspected_lie"] = (JToken)(false);
		}
		if (jsonObject["deescalation_attempt"] != null && (int)jsonObject["deescalation_attempt"].Type != 9)
		{
			jsonObject["deescalation_attempt"] = (JToken)(false);
		}
		if (jsonObject["allows_letters"] != null && (int)jsonObject["allows_letters"].Type != 9)
		{
			jsonObject["allows_letters"] = (JToken)(false);
		}
		if (jsonObject["claimed_gold"] != null && (!int.TryParse(((object)jsonObject["claimed_gold"]).ToString(), out var result) || result < 0))
		{
			jsonObject["claimed_gold"] = (JToken)(0);
		}
		if (jsonObject["claimed_age"] != null && (int)jsonObject["claimed_age"].Type != 10 && (!int.TryParse(((object)jsonObject["claimed_age"]).ToString(), out var result2) || result2 < 0 || result2 > 100))
		{
			jsonObject["claimed_age"] = null;
		}
	}

	private static string FixCommonJsonIssues(string json)
	{
		json = Regex.Replace(json, "\"claimed_name\":\\s*\"([^\"]+?)\"claimed \"claimed_clan\"[^,]+,", "\"claimed_name\": \"$1\",");
		json = Regex.Replace(json, "\"([^\"]*?)\"([^\"]*?)\"", "\"$1$2\"");
		json = Regex.Replace(json, ",\\s*}", "}");
		json = Regex.Replace(json, ",\\s*]", "]");
		json = Regex.Replace(json, "\"([^\"]+)\"\\s*\"([^\"]+)\"", "\"$1\", \"$2\"");
		return json;
	}

	public static string ExtractFallbackResponse(string rawResponse, string npcName)
	{
		string input = rawResponse.Trim();
		input = Regex.Replace(input, "^```json\\s*|\\s*```$", "").Trim();
		int num = input.IndexOf('{');
		if (num > 0)
		{
			input = input.Substring(num);
		}
		input = Regex.Replace(input, "^\\s*#.*?(?=\\n|$)", "").Trim();
		Match match = Regex.Match(input, "\"response\":\\s*\"(.*?)\"", RegexOptions.Singleline);
		if (match.Success)
		{
			string value = match.Groups[1].Value;
			return DecodeJsonStringValue(value);
		}
		if (!string.IsNullOrEmpty(npcName) && input.Contains(npcName + ":"))
		{
			input = input.Substring(input.IndexOf(npcName + ":") + npcName.Length + 2).Trim();
			int num2 = input.IndexOf("```json");
			if (num2 >= 0)
			{
				input = input.Substring(0, num2).Trim();
			}
			return input;
		}
		if (!string.IsNullOrWhiteSpace(input))
		{
			return input;
		}
		return "I have nothing to say right now.";
	}

	private static string DecodeJsonStringValue(string value)
	{
		try
		{
			return JsonConvert.DeserializeObject<string>("\"" + value + "\"") ?? value;
		}
		catch
		{
			return value.Replace("\\\"", "\"");
		}
	}

	public static bool IsValidJson(string json)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(json))
			{
				return false;
			}
			json = json.Trim();
			if (!json.StartsWith("{") || !json.EndsWith("}"))
			{
				return false;
			}
			JsonConvert.DeserializeObject(json);
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static void EnsureArray(JObject obj, string fieldName)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Invalid comparison between Unknown and I4
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		if (obj[fieldName] == null)
		{
			obj[fieldName] = (JToken)new JArray();
		}
		else if ((int)obj[fieldName].Type != 2)
		{
			obj[fieldName] = (JToken)new JArray();
		}
	}

	private static void EnsureArrayOrNull(JObject obj, string fieldName)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Invalid comparison between Unknown and I4
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		if (obj[fieldName] != null && (int)obj[fieldName].Type != 10 && (int)obj[fieldName].Type != 2)
		{
			obj[fieldName] = (JToken)new JArray();
		}
	}

	private static void EnsureObject(JObject obj, string fieldName)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Invalid comparison between Unknown and I4
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Invalid comparison between Unknown and I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		if (obj[fieldName] == null)
		{
			obj[fieldName] = (JToken)new JObject();
		}
		else if ((int)obj[fieldName].Type == 10)
		{
			obj[fieldName] = (JToken)new JObject();
		}
		else if ((int)obj[fieldName].Type != 1)
		{
			obj[fieldName] = (JToken)new JObject();
		}
	}
}
