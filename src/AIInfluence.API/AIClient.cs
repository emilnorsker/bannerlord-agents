using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AIInfluence.ChatTools;
using AIInfluence.Services;
using AIInfluence.Util;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace AIInfluence.API;

public static class AIClient
{
	private static readonly HttpClient httpClient = new HttpClient();

	/// <summary>Fetches the assistant <b>message</b> for NPC chat (or tools loop). When set, <paramref name="notifyMessageChunk"/> is invoked for each fragment of the message draft as it arrives (incremental delivery).</summary>
	/// <param name="notifyMessageChunk">Optional; called with each new text fragment to append to the message draft (drives message preview in chat).</param>
	public static async Task<string> GetAIResponse(string npcName, string faction, string prompt, Action<string> notifyMessageChunk = null, Func<string, string, Task<string>> onToolCall = null)
	{
		try
		{
			if (onToolCall != null)
				return await GetOpenRouterResponseWithTools(npcName, faction, prompt, notifyMessageChunk, onToolCall);
			return await GetOpenRouterResponse(npcName, faction, prompt, notifyMessageChunk);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] AI request failed for OpenRouter: " + ex.Message);
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
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Raw AI request failed for OpenRouter: " + ex.Message);
			return "Error: AI request failed: " + ex.Message;
		}
	}

	/// <summary>Uses OpenRouter; <paramref name="backend"/> is ignored (kept for call-site compatibility).</summary>
	public static async Task<string> GetRawTextResponseWithBackend(string prompt, string backend, int cachePrefixLength = 0)
	{
		try
		{
			return await GetOpenRouterRawResponse(prompt, cachePrefixLength);
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Raw AI request failed for OpenRouter: " + ex2.Message);
			return "Error: AI request failed: " + ex2.Message;
		}
	}

	private static (string systemPrompt, string userMessage, bool extracted) ExtractLastPlayerMessage(string prompt)
	{
		string item = prompt;
		string item2 = "Respond to the player's latest message in character, following the instructions provided.";
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
					item2 = "Player: " + text + "\n\nRespond to this message in character, following all instructions in the system message above.";
					AIInfluenceBehavior.Instance?.LogMessage($"[AI_CLIENT] Extracted last player message to user role ({text.Length} chars): {text.Substring(0, Math.Min(100, text.Length))}...");
					return (systemPrompt: item, userMessage: item2, extracted: true);
				}
			}
		}
		return (systemPrompt: item, userMessage: item2, extracted: false);
	}

	/// <summary>OpenRouter chat completion (always SSE). Assistant text is delivered incrementally when <paramref name="notifyMessageChunk"/> is set.</summary>
	private static async Task<string> GetOpenRouterResponse(string npcName, string faction, string prompt, Action<string> notifyMessageChunk = null)
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
		val["stream"] = true;
		// No response_format here: json_schema + stream can buffer on some providers and break token-by-token preview (notifyMessageChunk).
		JObject requestBody = val;
		string json = ((JToken)requestBody).ToString((Formatting)0, Array.Empty<JsonConverter>());
		StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
		httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSettings<ModSettings>.Instance.ApiKey);
		try
		{
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://openrouter.ai/api/v1/chat/completions");
			request.Content = (HttpContent)(object)content;
			using (HttpResponseMessage response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
			{
				response.EnsureSuccessStatusCode();
				StringBuilder debugStreamBuffer = (GlobalSettings<ModSettings>.Instance?.DebugStreamToGameLog ?? false) ? new StringBuilder() : null;
				void NotifyAndDebug(string chunk)
				{
					notifyMessageChunk?.Invoke(chunk);
					if (debugStreamBuffer != null)
					{
						debugStreamBuffer.Append(chunk);
						if (debugStreamBuffer.Length >= 120)
						{
							string batchedChunk = debugStreamBuffer.ToString().Replace("\n", "\\n");
							debugStreamBuffer.Clear();
							MainThreadDispatcher.Queue.Enqueue(() => InformationManager.DisplayMessage(new InformationMessage("[LLM STREAM] " + batchedChunk)));
						}
					}
				}
				using (Stream stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
				{
					(JObject assistantMessage, _) = await ReadOpenRouterChatCompletionStreamAsync(stream, NotifyAndDebug, collectToolCallDeltas: false).ConfigureAwait(false);
					if (debugStreamBuffer != null && debugStreamBuffer.Length > 0)
					{
						string remainingChunk = debugStreamBuffer.ToString().Replace("\n", "\\n");
						MainThreadDispatcher.Queue.Enqueue(() => InformationManager.DisplayMessage(new InformationMessage("[LLM STREAM] " + remainingChunk)));
					}
					if (assistantMessage["tool_calls"] != null)
						LogWarning("OpenRouter returned tool_calls without tools in request; using content only.");
					string text5 = assistantMessage["content"]?.ToString() ?? "";
					if (!text5.TrimStart(Array.Empty<char>()).StartsWith("{", StringComparison.Ordinal))
						LogWarning("OpenRouter streaming completed without JSON object output. Falling back to plain-text preview mode.");
					return text5;
				}
			}
		}
		catch (Exception ex)
		{
			LogError("OpenRouter request failed: " + ex.Message);
			return GenerateErrorResponse("I am unable to respond right now. Try again later.");
		}
	}

	private static async Task<string> GetOpenRouterResponseWithTools(string npcName, string faction, string prompt, Action<string> notifyMessageChunk, Func<string, string, Task<string>> onToolCall)
	{
		if (string.IsNullOrEmpty(GlobalSettings<ModSettings>.Instance?.ApiKey))
		{
			InformationManager.DisplayMessage(new InformationMessage("Please set your OpenRouter API key in Mod Settings (AI Influence).", TaleWorlds.Library.Colors.Red));
			return GenerateErrorResponse("I cannot respond right now. Something is amiss.");
		}
		if (!GlobalSettings<ModSettings>.Instance.EnableModification)
		{
			InformationManager.DisplayMessage(new InformationMessage("AI Influence mod is disabled in Mod Settings. Enable it to use chat.", TaleWorlds.Library.Colors.Red));
			return GenerateErrorResponse("I am not inclined to speak at this moment.");
		}
		var (systemPrompt, userMessage, _) = ExtractLastPlayerMessage(prompt);
		var messages = new JArray
		{
			new JObject { ["role"] = "system", ["content"] = systemPrompt + "\n\n**TOOLS:** Prefer tools over stuffing fields into JSON. **Dialogue:** `npc_say` (line, tone?), `suspected_lie`, `dialogue_decision`, `romance_intent`, `escalation_update`, `allows_letters`. **World:** transfers, quests, kingdom, workshops, travel, search, character_death. **Map:** prefer `map_command` with action + optional payload; `technical_action` is legacy. Final assistant JSON may be `{}` if you used tools for everything.\n" },
			new JObject { ["role"] = "user", ["content"] = userMessage }
		};
		var tools = ChatTools.ToolCatalog.GetToolsForApi();

		// Agent loop: call model until it returns final text (not tool calls).
		// Guard against model looping over tools forever – abort after 50 rounds.
		for (int round = 0; round < 50; round++)
		{
			JToken assistantMessage = await SendToolRequest(messages, tools, notifyMessageChunk).ConfigureAwait(false);
			if (assistantMessage == null)
				return GenerateErrorResponse("Invalid response.");

			JArray toolCalls = assistantMessage["tool_calls"] as JArray;
			if (toolCalls != null && toolCalls.Count > 0)
			{
				messages.Add(assistantMessage);
				foreach (JToken toolCall in toolCalls)
				{
					string toolName = toolCall["function"]?["name"]?.ToString() ?? "";
					string toolArgs = toolCall["function"]?["arguments"]?.ToString() ?? "{}";
					string result = await onToolCall(toolName, toolArgs).ConfigureAwait(false);
					messages.Add(new JObject
					{
						["role"] = "tool",
						["tool_call_id"] = toolCall["id"]?.ToString() ?? "",
						["content"] = result ?? ""
					});
				}
				continue;
			}

			string content = assistantMessage["content"]?.ToString() ?? "";
			if (!string.IsNullOrWhiteSpace(content))
				return content;
			// Tool-only turn: npc_say and other tools may carry all player-visible speech; merge fills AIResponse downstream.
			return "{}";
		}

		return GenerateErrorResponse("Too many tool turns.");
	}

	private static async Task<JToken> SendToolRequest(JArray messages, JArray tools, Action<string> notifyMessageChunk)
	{
		// OpenRouter: tools on every request; tool_choice / parallel_tool_calls per https://openrouter.ai/docs/guides/features/tool-calling
		JObject body = new JObject
		{
			["model"] = GlobalSettings<ModSettings>.Instance.AIModel,
			["messages"] = messages,
			["tools"] = tools,
			["tool_choice"] = "auto",
			["parallel_tool_calls"] = true,
			["stream"] = true,
			["response_format"] = OpenRouterNpcResponseSchema.GetResponseFormat()
		};
		using StringContent content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
		httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSettings<ModSettings>.Instance.ApiKey);
		using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://openrouter.ai/api/v1/chat/completions");
		request.Content = content;
		using HttpResponseMessage response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
		using Stream stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		(JObject assistantMessage, _) = await ReadOpenRouterChatCompletionStreamAsync(stream, notifyMessageChunk, collectToolCallDeltas: true).ConfigureAwait(false);
		return assistantMessage;
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
			["messages"] = (JToken)(object)messages,
			["stream"] = true
		};
		string json = ((JToken)requestBody).ToString((Formatting)0, Array.Empty<JsonConverter>());
		StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
		httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSettings<ModSettings>.Instance.ApiKey);
		try
		{
			using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://openrouter.ai/api/v1/chat/completions");
			request.Content = (HttpContent)(object)content;
			using (HttpResponseMessage response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
			{
				response.EnsureSuccessStatusCode();
				using (Stream stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
				{
					(JObject assistantMessage, _) = await ReadOpenRouterChatCompletionStreamAsync(stream, null, collectToolCallDeltas: false).ConfigureAwait(false);
					return assistantMessage["content"]?.ToString().Trim() ?? "";
				}
			}
		}
		catch (Exception ex)
		{
			LogError("OpenRouter raw response failed: " + ex.Message);
			return "Error: " + ex.Message;
		}
	}

	private sealed class ToolCallPart
	{
		public string Id;

		public string Type = "function";

		public string Name;

		public readonly StringBuilder Arguments = new StringBuilder();
	}

	private static void MergeToolCallDeltas(JArray deltaToolCalls, Dictionary<int, ToolCallPart> toolByIndex)
	{
		foreach (JToken token in deltaToolCalls)
		{
			JObject tc = (JObject)token;
			int index = tc["index"]?.Value<int>() ?? 0;
			if (!toolByIndex.TryGetValue(index, out ToolCallPart part))
			{
				part = new ToolCallPart();
				toolByIndex[index] = part;
			}
			if (tc["id"] != null)
				part.Id = tc["id"].ToString();
			if (tc["type"] != null)
				part.Type = tc["type"].ToString();
			JObject fn = tc["function"] as JObject;
			if (fn == null)
				continue;
			if (fn["name"] != null)
				part.Name = fn["name"].ToString();
			if (fn["arguments"] != null)
				part.Arguments.Append(fn["arguments"].ToString());
		}
	}

	private static JObject BuildAssistantMessageFromStream(StringBuilder content, Dictionary<int, ToolCallPart> toolByIndex)
	{
		if (toolByIndex.Count > 0)
		{
			JArray arr = new JArray();
			foreach (KeyValuePair<int, ToolCallPart> kv in toolByIndex.OrderBy(k => k.Key))
			{
				ToolCallPart t = kv.Value;
				arr.Add(new JObject
				{
					["id"] = t.Id ?? "",
					["type"] = t.Type ?? "function",
					["function"] = new JObject
					{
						["name"] = t.Name ?? "",
						["arguments"] = t.Arguments.ToString()
					}
				});
			}
			return new JObject
			{
				["role"] = "assistant",
				["content"] = JValue.CreateNull(),
				["tool_calls"] = arr
			};
		}
		return new JObject
		{
			["role"] = "assistant",
			["content"] = content.ToString()
		};
	}

	private static async Task<(JObject assistantMessage, string finishReason)> ReadOpenRouterChatCompletionStreamAsync(Stream stream, Action<string> notifyContentDelta, bool collectToolCallDeltas)
	{
		StringBuilder content = new StringBuilder();
		Dictionary<int, ToolCallPart> toolByIndex = new Dictionary<int, ToolCallPart>();
		string finishReason = null;
		using (StreamReader reader = new StreamReader(stream))
		{
			while (!reader.EndOfStream)
			{
				string line = await reader.ReadLineAsync().ConfigureAwait(false);
				if (string.IsNullOrWhiteSpace(line) || !line.StartsWith("data:", StringComparison.Ordinal))
					continue;
				string data = line.Substring(5).Trim();
				if (data == "[DONE]")
					break;
				JObject chunk;
				try
				{
					chunk = JObject.Parse(data);
				}
				catch (JsonException ex)
				{
					LogWarning("OpenRouter SSE: skipped malformed JSON line: " + ex.Message);
					continue;
				}
				string err = chunk["error"]?["message"]?.ToString();
				if (!string.IsNullOrEmpty(err))
					throw new InvalidOperationException("OpenRouter stream error: " + err);
				JToken choice0 = chunk["choices"]?[0];
				if (choice0 == null)
					continue;
				string fr = choice0["finish_reason"]?.ToString();
				if (!string.IsNullOrEmpty(fr))
					finishReason = fr;
				if (string.Equals(fr, "error", StringComparison.OrdinalIgnoreCase))
					throw new InvalidOperationException("OpenRouter stream terminated with finish_reason=error.");
				JObject delta = choice0["delta"] as JObject;
				if (delta == null)
					continue;
				string text = delta["content"]?.ToString();
				if (!string.IsNullOrEmpty(text))
				{
					content.Append(text);
					notifyContentDelta?.Invoke(text);
				}
				if (collectToolCallDeltas && delta["tool_calls"] is JArray tca)
					MergeToolCallDeltas(tca, toolByIndex);
			}
		}
		if (collectToolCallDeltas && toolByIndex.Count > 0 && !string.IsNullOrEmpty(finishReason) && !string.Equals(finishReason, "tool_calls", StringComparison.OrdinalIgnoreCase))
			LogWarning("OpenRouter SSE: assembled tool_calls but finish_reason='" + finishReason + "' (docs: expect tool_calls when the model returns tools).");
		return (BuildAssistantMessageFromStream(content, toolByIndex), finishReason);
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
			JObject val = new JObject { ["model"] = (JToken)(GlobalSettings<ModSettings>.Instance.AIModel) };
			JArray val2 = new JArray();
			val2.Add((JToken)new JObject
			{
				["role"] = (JToken)("user"),
				["content"] = (JToken)("Hello")
			});
			val["messages"] = (JToken)val2;
			val["stream"] = true;
			JObject requestBody = val;
			string json = ((JToken)requestBody).ToString((Formatting)0, Array.Empty<JsonConverter>());
			StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSettings<ModSettings>.Instance.ApiKey);
			using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "https://openrouter.ai/api/v1/chat/completions");
			request.Content = (HttpContent)(object)content;
			using (HttpResponseMessage response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
			{
				if (response.IsSuccessStatusCode)
				{
					using (Stream stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
					{
						(JObject assistantMessage, _) = await ReadOpenRouterChatCompletionStreamAsync(stream, null, collectToolCallDeltas: false).ConfigureAwait(false);
						if (assistantMessage["content"] != null || assistantMessage["tool_calls"] != null)
						{
							InformationManager.DisplayMessage(new InformationMessage("OpenRouter: Connection test successful", ExtraColors.GreenAIInfluence));
							return true;
						}
					}
					InformationManager.DisplayMessage(new InformationMessage("OpenRouter: Test request returned empty body", ExtraColors.RedAIInfluence));
					return false;
				}
				InformationManager.DisplayMessage(new InformationMessage(string.Format(arg1: await response.Content.ReadAsStringAsync(), format: "OpenRouter: Test request failed: {0} - {1}", arg0: response.StatusCode), ExtraColors.RedAIInfluence));
			}
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
