using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AIInfluence.Util;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TaleWorlds.Library;

namespace AIInfluence.API;

public static class AIClient
{
	private static readonly HttpClient httpClient = new HttpClient();

	public static async Task<string> GetAIResponse(string npcName, string faction, string prompt)
	{
		try
		{
			return await GetOpenRouterResponse(npcName, faction, prompt);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] AI request failed: " + ex.Message);
			return GenerateErrorResponse("AI request failed: " + ex.Message);
		}
	}

	public static async Task<string> GetRawTextResponse(string prompt)
	{
		try
		{
			return await GetOpenRouterRawResponse(prompt);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Raw AI request failed: " + ex.Message);
			return "Error: AI request failed: " + ex.Message;
		}
	}

	public static async Task<string> GetRawTextResponseWithBackend(string prompt, int cachePrefixLength = 0)
	{
		try
		{
			return await GetOpenRouterRawResponse(prompt, cachePrefixLength);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Raw AI request failed: " + ex.Message);
			return "Error: AI request failed: " + ex.Message;
		}
	}

	private static (string systemPrompt, string userMessage, bool extracted) ExtractLastPlayerMessage(string prompt)
	{
		string item = prompt;
		string item2 = "Respond to the player's latest message in character, following the instructions provided. Format your response as JSON with all required fields.";
		int num = prompt.LastIndexOf("\nPlayer: ");
		if (num >= 0)
		{
			string text = prompt.Substring(num + "\nPlayer: ".Length).Trim();
			if (!string.IsNullOrEmpty(text))
			{
				string text2 = prompt.Substring(num + "\nPlayer: ".Length + text.Length).Trim();
				if (string.IsNullOrEmpty(text2) || text2.StartsWith("Last Interaction:", StringComparison.OrdinalIgnoreCase))
				{
					item = prompt.Substring(0, num).TrimEnd(Array.Empty<char>());
					item2 = "Player: " + text + "\n\nRespond to this message in character, following all instructions in the system message above. Format your response as JSON with all required fields.";
					AIInfluenceBehavior.Instance?.LogMessage($"[AI_CLIENT] Extracted last player message to user role ({text.Length} chars): {text.Substring(0, Math.Min(100, text.Length))}...");
					return (systemPrompt: item, userMessage: item2, extracted: true);
				}
			}
		}
		return (systemPrompt: item, userMessage: item2, extracted: false);
	}

	private static async Task<string> GetOpenRouterResponse(string npcName, string faction, string prompt)
	{
		if (string.IsNullOrEmpty(GlobalSettings<ModSettings>.Instance?.ApiKey))
		{
			LogError("OpenRouter API Key is not set in Mod Settings.");
			return GenerateErrorResponse("I cannot respond right now. Something is amiss.");
		}
		if (!GlobalSettings<ModSettings>.Instance.EnableModification)
		{
			LogError("Mod is disabled in settings.");
			return GenerateErrorResponse("I am not inclined to speak at this moment.");
		}
		(string, string, bool) tuple = ExtractLastPlayerMessage(prompt);
		var (systemPrompt, userMessage, _) = tuple;
		_ = tuple.Item3;
		JObject val = new JObject { ["model"] = JToken.op_Implicit(GlobalSettings<ModSettings>.Instance.AIModel) };
		JArray val2 = new JArray();
		val2.Add((JToken)new JObject
		{
			["role"] = JToken.op_Implicit("system"),
			["content"] = JToken.op_Implicit(systemPrompt)
		});
		val2.Add((JToken)new JObject
		{
			["role"] = JToken.op_Implicit("user"),
			["content"] = JToken.op_Implicit(userMessage)
		});
		val["messages"] = (JToken)val2;
		val["response_format"] = (JToken)new JObject { ["type"] = JToken.op_Implicit("json_object") };
		JObject requestBody = val;
		string json = ((JToken)requestBody).ToString((Formatting)0, Array.Empty<JsonConverter>());
		StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
		httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSettings<ModSettings>.Instance.ApiKey);
		try
		{
			HttpResponseMessage response = await httpClient.PostAsync("https://openrouter.ai/api/v1/chat/completions", (HttpContent)(object)content);
			response.EnsureSuccessStatusCode();
			dynamic responseObject = JsonConvert.DeserializeObject<object>(await response.Content.ReadAsStringAsync());
			return responseObject.choices[0].message.content.ToString();
		}
		catch (Exception ex)
		{
			LogError("OpenRouter request failed: " + ex.Message);
			return GenerateErrorResponse("I am unable to respond right now. Try again later.");
		}
	}

	private static async Task<string> GetOpenRouterRawResponse(string prompt, int cachePrefixLength = 0)
	{
		if (string.IsNullOrEmpty(GlobalSettings<ModSettings>.Instance?.ApiKey))
		{
			LogError("OpenRouter API Key is not set in Mod Settings.");
			return "API key is missing.";
		}
		JArray messages;
		if (cachePrefixLength > 0 && cachePrefixLength < prompt.Length)
		{
			string systemPrompt = prompt.Substring(0, cachePrefixLength);
			string userMessage = prompt.Substring(cachePrefixLength);
			JArray val = new JArray();
			val.Add((JToken)new JObject
			{
				["role"] = JToken.op_Implicit("system"),
				["content"] = JToken.op_Implicit(systemPrompt)
			});
			val.Add((JToken)new JObject
			{
				["role"] = JToken.op_Implicit("user"),
				["content"] = JToken.op_Implicit(userMessage)
			});
			messages = val;
		}
		else
		{
			JArray val2 = new JArray();
			val2.Add((JToken)new JObject
			{
				["role"] = JToken.op_Implicit("user"),
				["content"] = JToken.op_Implicit(prompt)
			});
			messages = val2;
		}
		JObject requestBody = new JObject
		{
			["model"] = JToken.op_Implicit(GlobalSettings<ModSettings>.Instance.AIModel),
			["messages"] = (JToken)(object)messages
		};
		string json = ((JToken)requestBody).ToString((Formatting)0, Array.Empty<JsonConverter>());
		StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
		httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSettings<ModSettings>.Instance.ApiKey);
		try
		{
			HttpResponseMessage response = await httpClient.PostAsync("https://openrouter.ai/api/v1/chat/completions", (HttpContent)(object)content);
			response.EnsureSuccessStatusCode();
			dynamic responseObject = JsonConvert.DeserializeObject<object>(await response.Content.ReadAsStringAsync());
			return responseObject.choices[0].message.content.ToString().Trim();
		}
		catch (Exception ex)
		{
			LogError("OpenRouter raw response failed: " + ex.Message);
			return "Error: " + ex.Message;
		}
	}

	private static string GenerateErrorResponse(string message)
	{
		return JsonConvert.SerializeObject((object)new AIResponse
		{
			Response = message,
			SuspectedLie = false,
			ClaimedName = null,
			ClaimedClan = null,
			ClaimedAge = null,
			Tone = "neutral",
			ThreatLevel = "none",
			EscalationState = "neutral",
			DeescalationAttempt = false
		});
	}

	private static void LogError(string message)
	{
		AIInfluenceBehavior.Instance?.LogMessage("[ERROR] AIClient: " + message);
	}

	private static void LogWarning(string message)
	{
		AIInfluenceBehavior.Instance?.LogMessage("[WARNING] AIClient: " + message);
	}

	public static async Task<bool> TestCurrentBackendConnection()
	{
		return await TestOpenRouterConnection();
	}

	public static async Task<bool> TestOpenRouterConnection()
	{
		try
		{
			if (string.IsNullOrEmpty(GlobalSettings<ModSettings>.Instance?.ApiKey))
			{
				InformationManager.DisplayMessage(new InformationMessage("OpenRouter: API Key is not set", ExtraColors.RedAIInfluence));
				return false;
			}
			JObject val = new JObject { ["model"] = JToken.op_Implicit(GlobalSettings<ModSettings>.Instance.AIModel) };
			JArray val2 = new JArray();
			val2.Add((JToken)new JObject
			{
				["role"] = JToken.op_Implicit("user"),
				["content"] = JToken.op_Implicit("Hello")
			});
			val["messages"] = (JToken)val2;
			JObject requestBody = val;
			string json = ((JToken)requestBody).ToString((Formatting)0, Array.Empty<JsonConverter>());
			StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSettings<ModSettings>.Instance.ApiKey);
			HttpResponseMessage response = await httpClient.PostAsync("https://openrouter.ai/api/v1/chat/completions", (HttpContent)(object)content);
			if (response.IsSuccessStatusCode)
			{
				InformationManager.DisplayMessage(new InformationMessage("OpenRouter: Connection test successful", ExtraColors.GreenAIInfluence));
				return true;
			}
			InformationManager.DisplayMessage(new InformationMessage(string.Format(arg1: await response.Content.ReadAsStringAsync(), format: "OpenRouter: Test request failed: {0} - {1}", arg0: response.StatusCode), ExtraColors.RedAIInfluence));
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			InformationManager.DisplayMessage(new InformationMessage("OpenRouter: Connection test failed: " + ex2.Message, ExtraColors.RedAIInfluence));
		}
		return false;
	}

	private static void LogMessage(string message)
	{
		AIInfluenceBehavior.Instance?.LogMessage("[INFO] AIClient: " + message);
	}
}
