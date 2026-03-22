using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AIInfluence.Services;
using AIInfluence.Util;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TaleWorlds.Library;

namespace AIInfluence.API;

public static class AIClient
{
	private static readonly HttpClient httpClient = new HttpClient();

	public static async Task<string> GetAIResponse(string npcName, string faction, string prompt, Action<string> onOpenRouterStreamUpdate = null)
	{
		try
		{
			return await GetOpenRouterResponse(npcName, faction, prompt, onOpenRouterStreamUpdate);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] AI request failed for OpenRouter: " + ex.Message);
			return GenerateErrorResponse("AI request failed: " + ex.Message);
		}
	}

	public static async Task<string> GetRawTextResponse(string prompt, int cachePrefixLength = 0)
	{
		try
		{
			return await GetOpenRouterRawResponse(prompt, cachePrefixLength);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Raw AI request failed for OpenRouter: " + ex.Message);
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

	private static async Task<string> GetOpenRouterResponse(string npcName, string faction, string prompt, Action<string> onOpenRouterStreamUpdate = null)
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
		JObject val = new JObject { ["model"] = (JToken)(GlobalSettings<ModSettings>.Instance.AIModel) };
		JArray val2 = new JArray();
		val2.Add((JToken)new JObject
		{
			["role"] = (JToken)("system"),
			["content"] = (JToken)(systemPrompt)
		});
		val2.Add((JToken)new JObject
		{
			["role"] = (JToken)("user"),
			["content"] = (JToken)(userMessage)
		});
		val["messages"] = (JToken)val2;
		bool isStreaming = onOpenRouterStreamUpdate != null;
		// Do not force json_object while streaming: some providers buffer until
		// the object is complete, which collapses visible token-by-token updates.
		if (!isStreaming)
			val["response_format"] = (JToken)new JObject { ["type"] = (JToken)("json_object") };
		val["stream"] = (JToken)isStreaming;
		JObject requestBody = val;
		string json = ((JToken)requestBody).ToString((Formatting)0, Array.Empty<JsonConverter>());
		StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
		httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSettings<ModSettings>.Instance.ApiKey);
		try
		{
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://openrouter.ai/api/v1/chat/completions");
			request.Content = (HttpContent)(object)content;
			HttpResponseMessage response = ((onOpenRouterStreamUpdate != null) ? (await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false)) : (await httpClient.SendAsync(request).ConfigureAwait(false)));
			response.EnsureSuccessStatusCode();
			if (onOpenRouterStreamUpdate != null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				StringBuilder debugStreamBuffer = (GlobalSettings<ModSettings>.Instance?.DebugStreamToGameLog ?? false) ? new StringBuilder() : null;
				using (Stream stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
				{
					using StreamReader streamReader = new StreamReader(stream);
					while (!streamReader.EndOfStream)
					{
						string text = await streamReader.ReadLineAsync().ConfigureAwait(false);
						if (string.IsNullOrWhiteSpace(text) || !text.StartsWith("data:", StringComparison.Ordinal))
						{
							continue;
						}
						string text2 = text.Substring(5).Trim();
						if (text2 == "[DONE]")
						{
							break;
						}
						JObject val3 = JObject.Parse(text2);
						string text3 = val3?["error"]?["message"]?.ToString();
						if (!string.IsNullOrEmpty(text3))
						{
							throw new InvalidOperationException("OpenRouter stream error: " + text3);
						}
						JToken val4 = val3?["choices"]?[0];
						if (string.Equals(val4?["finish_reason"]?.ToString(), "error", StringComparison.OrdinalIgnoreCase))
						{
							throw new InvalidOperationException("OpenRouter stream terminated with finish_reason=error.");
						}
						string text4 = val4?["delta"]?["content"]?.ToString();
						if (string.IsNullOrEmpty(text4))
						{
							continue;
						}
						stringBuilder.Append(text4);
						if (debugStreamBuffer != null)
						{
							debugStreamBuffer.Append(text4);
							if (debugStreamBuffer.Length >= 120)
							{
								string batchedChunk = debugStreamBuffer.ToString().Replace("\n", "\\n");
								debugStreamBuffer.Clear();
								MainThreadDispatch.MainThreadQueue.Enqueue(() => InformationManager.DisplayMessage(new InformationMessage("[LLM STREAM] " + batchedChunk)));
							}
						}
						onOpenRouterStreamUpdate(text4);
					}
				}
				if (debugStreamBuffer != null && debugStreamBuffer.Length > 0)
				{
					string remainingChunk = debugStreamBuffer.ToString().Replace("\n", "\\n");
					MainThreadDispatch.MainThreadQueue.Enqueue(() => InformationManager.DisplayMessage(new InformationMessage("[LLM STREAM] " + remainingChunk)));
				}
				string text5 = stringBuilder.ToString();
				if (!text5.TrimStart(Array.Empty<char>()).StartsWith("{", StringComparison.Ordinal))
				{
					LogWarning("OpenRouter streaming completed without JSON object output. Falling back to plain-text preview mode.");
				}
				return text5;
			}
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
				["role"] = (JToken)("system"),
				["content"] = (JToken)(systemPrompt)
			});
			val.Add((JToken)new JObject
			{
				["role"] = (JToken)("user"),
				["content"] = (JToken)(userMessage)
			});
			messages = val;
		}
		else
		{
			JArray val2 = new JArray();
			val2.Add((JToken)new JObject
			{
				["role"] = (JToken)("user"),
				["content"] = (JToken)(prompt)
			});
			messages = val2;
		}
		JObject requestBody = new JObject
		{
			["model"] = (JToken)(GlobalSettings<ModSettings>.Instance.AIModel),
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
			AiError = true,
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

	/// <summary>True for dialogue-path failures: empty, <c>Error:</c> prefix, or JSON error envelope from <see cref="GenerateErrorResponse"/>.</summary>
	public static bool IsDialogueFailureResponse(string response)
	{
		if (string.IsNullOrEmpty(response))
		{
			return true;
		}
		if (response.StartsWith("Error:", StringComparison.Ordinal))
		{
			return true;
		}
		if (response[0] != '{')
		{
			return false;
		}
		try
		{
			JObject o = JObject.Parse(response);
			if (o["ai_error"]?.Type == JTokenType.Boolean && o["ai_error"].Value<bool>())
			{
				return true;
			}
			string r = o["response"]?.Value<string>();
			if (r == null)
			{
				return false;
			}
			if (r.StartsWith("AI request failed:", StringComparison.Ordinal))
			{
				return true;
			}
			if (r == "I cannot respond right now. Something is amiss." || r == "I am not inclined to speak at this moment." || r == "I am unable to respond right now. Try again later.")
			{
				return true;
			}
		}
		catch
		{
		}
		return false;
	}

	/// <summary>True for <see cref="GetRawTextResponse"/> failures (plain <c>Error:</c>, missing key message, empty).</summary>
	public static bool IsRawTextFailureResponse(string response)
	{
		if (string.IsNullOrEmpty(response))
		{
			return true;
		}
		if (response.StartsWith("Error:", StringComparison.Ordinal))
		{
			return true;
		}
		return string.Equals(response, "API key is missing.", StringComparison.Ordinal);
	}

	/// <summary>Unified check for <c>SendAIRequest</c> results: null/empty, dialogue error JSON, exception <c>Error:</c> strings, or raw-path failures.</summary>
	public static bool IsSendAIRequestResultFailure(string response)
	{
		if (string.IsNullOrEmpty(response))
		{
			return true;
		}
		string trimmed = response.TrimStart();
		if (trimmed.Length == 0)
		{
			return true;
		}
		if (IsDialogueFailureResponse(trimmed))
		{
			return true;
		}
		if (trimmed[0] != '{')
		{
			return IsRawTextFailureResponse(response);
		}
		return false;
	}

	private static void LogError(string message)
	{
		AIInfluenceBehavior.Instance?.LogMessage("[ERROR] AIClient: " + message);
	}

	private static void LogWarning(string message)
	{
		AIInfluenceBehavior.Instance?.LogMessage("[WARNING] AIClient: " + message);
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
			JObject val = new JObject { ["model"] = (JToken)(GlobalSettings<ModSettings>.Instance.AIModel) };
			JArray val2 = new JArray();
			val2.Add((JToken)new JObject
			{
				["role"] = (JToken)("user"),
				["content"] = (JToken)("Hello")
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
}
