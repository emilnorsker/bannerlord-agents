using System;
using System.Collections.Generic;
using System.IO;
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

	private const string GAME_KEY = "0199bcdd-3f9f-7a67-947e-ca10021b94ce";

	/// <summary>Fetches the assistant <b>message</b> for NPC chat (or tools loop). When set, <paramref name="notifyMessageChunk"/> is invoked for each fragment of the message draft as it arrives (incremental delivery).</summary>
	/// <param name="notifyMessageChunk">Optional; called with each new text fragment to append to the message draft (drives message preview in chat).</param>
	public static async Task<string> GetAIResponse(string npcName, string faction, string prompt, Action<string> notifyMessageChunk = null, Func<string, string, Task<string>> onToolCall = null)
	{
		string backend = GlobalSettings<ModSettings>.Instance?.AIBackend?.SelectedValue ?? "Player2";
		try
		{
			if (backend == "OpenRouter" && onToolCall != null)
				return await GetOpenRouterResponseWithTools(npcName, faction, prompt, notifyMessageChunk, onToolCall);
			return backend switch
			{
				"OpenRouter" => await GetOpenRouterResponse(npcName, faction, prompt, notifyMessageChunk), 
				"DeepSeek" => await GetDeepSeekResponse(npcName, faction, prompt), 
				"Player2" => await GetPlayer2Response(npcName, faction, prompt), 
				"Ollama" => await GetOllamaResponse(npcName, faction, prompt), 
				"KoboldCpp" => await GetKoboldCppResponse(npcName, faction, prompt), 
				_ => GenerateErrorResponse("Unknown AI backend selected: " + backend), 
			};
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] AI request failed for " + backend + ": " + ex.Message);
			return GenerateErrorResponse("AI request failed: " + ex.Message);
		}
	}

	public static async Task<string> GetRawTextResponse(string prompt)
	{
		string backend = GlobalSettings<ModSettings>.Instance?.AIBackend?.SelectedValue ?? "Player2";
		try
		{
			return backend switch
			{
				"OpenRouter" => await GetOpenRouterRawResponse(prompt), 
				"DeepSeek" => await GetDeepSeekRawResponse(prompt), 
				"Player2" => await GetPlayer2RawResponse(prompt), 
				"Ollama" => await GetOllamaRawResponse(prompt), 
				"KoboldCpp" => await GetKoboldCppRawResponse(prompt), 
				_ => "Error: Unknown AI backend selected", 
			};
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Raw AI request failed for " + backend + ": " + ex.Message);
			return "Error: AI request failed: " + ex.Message;
		}
	}

	public static async Task<string> GetRawTextResponseWithBackend(string prompt, string backend, int cachePrefixLength = 0)
	{
		try
		{
			return backend switch
			{
				"OpenRouter" => await GetOpenRouterRawResponse(prompt, cachePrefixLength), 
				"DeepSeek" => await GetDeepSeekRawResponse(prompt, cachePrefixLength), 
				"Player2" => await GetPlayer2RawResponse(prompt, cachePrefixLength), 
				"Ollama" => await GetOllamaRawResponse(prompt, cachePrefixLength), 
				"KoboldCpp" => await GetKoboldCppRawResponse(prompt, cachePrefixLength), 
				_ => "Error: Unknown AI backend selected", 
			};
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Raw AI request failed for " + backend + ": " + ex2.Message);
			return "Error: AI request failed: " + ex2.Message;
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

	/// <summary>OpenRouter chat completion. When <paramref name="notifyMessageChunk"/> is set, assistant text is delivered incrementally (message draft fragments).</summary>
	/// <param name="notifyMessageChunk">Optional; invoked for each fragment of the assistant message draft (raw text).</param>
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
		bool isStreaming = notifyMessageChunk != null;
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
			HttpResponseMessage response = ((notifyMessageChunk != null) ? (await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false)) : (await httpClient.SendAsync(request).ConfigureAwait(false)));
			response.EnsureSuccessStatusCode();
			if (notifyMessageChunk != null)
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
								TtsLipSyncService.MainThreadQueue.Enqueue(() => InformationManager.DisplayMessage(new InformationMessage("[LLM STREAM] " + batchedChunk)));
							}
						}
						notifyMessageChunk(text4);
					}
				}
				if (debugStreamBuffer != null && debugStreamBuffer.Length > 0)
				{
					string remainingChunk = debugStreamBuffer.ToString().Replace("\n", "\\n");
					TtsLipSyncService.MainThreadQueue.Enqueue(() => InformationManager.DisplayMessage(new InformationMessage("[LLM STREAM] " + remainingChunk)));
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
			new JObject { ["role"] = "system", ["content"] = systemPrompt + "\n\n**TOOLS:** Use find_settlements/find_parties/find_items for string_ids. Final message = JSON with response, decision, tone, suspected_lie, character_death, marriage, character_personality/backstory/quirks, allows_letters.\n" },
			new JObject { ["role"] = "user", ["content"] = userMessage }
		};
		var tools = ChatTools.ToolCatalog.GetToolsForApi();

		// Agent loop: call model until it returns final text (not tool calls).
		// Guard against model looping over tools forever – abort after 50 rounds.
		for (int round = 0; round < 50; round++)
		{
			JToken assistantMessage = await SendToolRequest(messages, tools);
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
					string result = await onToolCall(toolName, toolArgs);
					messages.Add(new JObject
					{
						["role"] = "tool",
						["tool_call_id"] = toolCall["id"]?.ToString() ?? "",
						["content"] = result ?? ""
					});
				}
				continue;
			}

			string content = assistantMessage["content"]?.ToString();
			if (!string.IsNullOrEmpty(content))
			{
				notifyMessageChunk?.Invoke(content);
				return content;
			}

			return GenerateErrorResponse("Empty response.");
		}

		return GenerateErrorResponse("Too many tool turns.");
	}

	private static async Task<JToken> SendToolRequest(JArray messages, JArray tools)
	{
		var body = new JObject { ["model"] = GlobalSettings<ModSettings>.Instance.AIModel, ["messages"] = messages, ["tools"] = tools };
		using var content = new StringContent(body.ToString(), Encoding.UTF8, "application/json");
		httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSettings<ModSettings>.Instance.ApiKey);
		var response = await httpClient.PostAsync("https://openrouter.ai/api/v1/chat/completions", content);
		response.EnsureSuccessStatusCode();
		return JObject.Parse(await response.Content.ReadAsStringAsync())?["choices"]?[0]?["message"];
	}

	private static async Task<string> GetDeepSeekResponse(string npcName, string faction, string prompt)
	{
		if (string.IsNullOrEmpty(GlobalSettings<ModSettings>.Instance?.DeepSeekApiKey))
		{
			LogError("DeepSeek API Key is not set in Mod Settings.");
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
		DeepSeekChatRequest requestBody = new DeepSeekChatRequest
		{
			Model = GlobalSettings<ModSettings>.Instance.DeepSeekModel,
			Messages = new List<DeepSeekMessage>
			{
				new DeepSeekMessage
				{
					Role = "system",
					Content = systemPrompt
				},
				new DeepSeekMessage
				{
					Role = "user",
					Content = userMessage
				}
			}
		};
		string json = JsonConvert.SerializeObject((object)requestBody);
		StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
		httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSettings<ModSettings>.Instance.DeepSeekApiKey);
		try
		{
			HttpResponseMessage response = await httpClient.PostAsync("https://api.deepseek.com/chat/completions", (HttpContent)(object)content);
			response.EnsureSuccessStatusCode();
			DeepSeekChatResponse responseObject = JsonConvert.DeserializeObject<DeepSeekChatResponse>(await response.Content.ReadAsStringAsync());
			if (responseObject?.Choices != null && responseObject.Choices.Count > 0 && responseObject.Choices[0].Message != null)
			{
				return responseObject.Choices[0].Message.Content ?? GenerateErrorResponse("Empty response from DeepSeek.");
			}
			LogError("DeepSeek response format is invalid or empty.");
			return GenerateErrorResponse("I am unable to respond right now. Try again later.");
		}
		catch (Exception ex)
		{
			LogError("DeepSeek request failed: " + ex.Message);
			return GenerateErrorResponse("I am unable to respond right now. Try again later.");
		}
	}

	private static async Task<string> GetPlayer2Response(string npcName, string faction, string prompt)
	{
		if (!GlobalSettings<ModSettings>.Instance.EnableModification)
		{
			LogError("Mod is disabled in settings.");
			return GeneratePlayer2ErrorResponse("I am not inclined to speak at this moment.");
		}
		string baseUrl = GlobalSettings<ModSettings>.Instance?.Player2ApiUrl ?? "http://127.0.0.1:4315";
		string url = baseUrl + "/v1/chat/completions";
		(string, string, bool) tuple = ExtractLastPlayerMessage(prompt);
		var (systemPrompt, userMessage, _) = tuple;
		_ = tuple.Item3;
		JObject val = new JObject();
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
		JObject requestBody = val;
		string json = ((JToken)requestBody).ToString((Formatting)0, Array.Empty<JsonConverter>());
		StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
		try
		{
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
			request.Content = (HttpContent)(object)content;
			((HttpHeaders)request.Headers).Add("player2-game-key", "0199bcdd-3f9f-7a67-947e-ca10021b94ce");
			HttpResponseMessage response = await httpClient.SendAsync(request);
			if (!response.IsSuccessStatusCode)
			{
				LogError(string.Format(arg1: await response.Content.ReadAsStringAsync(), format: "Player2 HTTP {0}: {1}", arg0: response.StatusCode));
				return GeneratePlayer2ErrorResponse("I am unable to respond right now. Try again later.");
			}
			dynamic responseObject = JsonConvert.DeserializeObject<object>(await response.Content.ReadAsStringAsync());
			if (responseObject?.choices != null && responseObject.choices.Count > 0)
			{
				return responseObject.choices[0].message.content?.ToString() ?? "";
			}
			LogError("Player2 response format is invalid");
			return GeneratePlayer2ErrorResponse("Something troubles me, and I cannot speak now.");
		}
		catch (Exception ex)
		{
			LogError("Player2 request failed: " + ex.Message);
			return GeneratePlayer2ErrorResponse("I am unable to respond right now. Try again later.");
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

	private static async Task<string> GetDeepSeekRawResponse(string prompt, int cachePrefixLength = 0)
	{
		if (string.IsNullOrEmpty(GlobalSettings<ModSettings>.Instance?.DeepSeekApiKey))
		{
			LogError("DeepSeek API Key is not set in Mod Settings.");
			return "API key is missing.";
		}
		List<DeepSeekMessage> messages;
		if (cachePrefixLength > 0 && cachePrefixLength < prompt.Length)
		{
			string systemPrompt = prompt.Substring(0, cachePrefixLength);
			string userMessage = prompt.Substring(cachePrefixLength);
			messages = new List<DeepSeekMessage>
			{
				new DeepSeekMessage
				{
					Role = "system",
					Content = systemPrompt
				},
				new DeepSeekMessage
				{
					Role = "user",
					Content = userMessage
				}
			};
		}
		else
		{
			messages = new List<DeepSeekMessage>
			{
				new DeepSeekMessage
				{
					Role = "user",
					Content = prompt
				}
			};
		}
		DeepSeekChatRequest requestBody = new DeepSeekChatRequest
		{
			Model = GlobalSettings<ModSettings>.Instance.DeepSeekModel,
			Messages = messages
		};
		string json = JsonConvert.SerializeObject((object)requestBody);
		StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
		httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GlobalSettings<ModSettings>.Instance.DeepSeekApiKey);
		try
		{
			HttpResponseMessage response = await httpClient.PostAsync("https://api.deepseek.com/chat/completions", (HttpContent)(object)content);
			response.EnsureSuccessStatusCode();
			DeepSeekChatResponse responseObject = JsonConvert.DeserializeObject<DeepSeekChatResponse>(await response.Content.ReadAsStringAsync());
			if (responseObject?.Choices != null && responseObject.Choices.Count > 0 && responseObject.Choices[0].Message != null)
			{
				return responseObject.Choices[0].Message.Content?.Trim() ?? "Error: Empty content in DeepSeek response";
			}
			LogError("DeepSeek raw response format is invalid or empty.");
			return "Error: Invalid response format";
		}
		catch (Exception ex)
		{
			LogError("DeepSeek raw response failed: " + ex.Message);
			return "Error: " + ex.Message;
		}
	}

	private static async Task<string> GetPlayer2RawResponse(string prompt, int cachePrefixLength = 0)
	{
		string baseUrl = GlobalSettings<ModSettings>.Instance?.Player2ApiUrl ?? "http://127.0.0.1:4315";
		string url = baseUrl + "/v1/chat/completions";
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
		JObject requestBody = new JObject { ["messages"] = (JToken)(object)messages };
		string json = ((JToken)requestBody).ToString((Formatting)0, Array.Empty<JsonConverter>());
		StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
		try
		{
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
			request.Content = (HttpContent)(object)content;
			((HttpHeaders)request.Headers).Add("player2-game-key", "0199bcdd-3f9f-7a67-947e-ca10021b94ce");
			HttpResponseMessage response = await httpClient.SendAsync(request);
			if (!response.IsSuccessStatusCode)
			{
				string errorText = await response.Content.ReadAsStringAsync();
				AIInfluenceBehavior.Instance?.LogMessage($"[PLAYER2_ERROR] Status: {response.StatusCode}");
				AIInfluenceBehavior.Instance?.LogMessage("[PLAYER2_ERROR] Error text: " + errorText);
				AIInfluenceBehavior.Instance?.LogMessage($"[PLAYER2_ERROR] Prompt length: {prompt.Length} characters");
				return $"Error: HTTP {response.StatusCode} - {errorText}";
			}
			dynamic responseObject = JsonConvert.DeserializeObject<object>(await response.Content.ReadAsStringAsync());
			if (responseObject?.choices != null && responseObject.choices.Count > 0)
			{
				return responseObject.choices[0].message.content?.ToString() ?? "Error: No content in response";
			}
			return "Error: Invalid response format";
		}
		catch (Exception ex)
		{
			return "Error: " + ex.Message;
		}
	}

	private static async Task<string> GetOllamaResponse(string npcName, string faction, string prompt)
	{
		string model = GlobalSettings<ModSettings>.Instance?.OllamaModel ?? "llama2";
		string baseUrl = GlobalSettings<ModSettings>.Instance?.OllamaApiUrl ?? "http://localhost:11434";
		(string, string, bool) tuple = ExtractLastPlayerMessage(prompt);
		string systemPrompt = tuple.Item1;
		string userMessage = tuple.Item2;
		bool extracted = tuple.Item3;
		string chatUrl = baseUrl + "/api/chat";
		JObject val = new JObject { ["model"] = (JToken)(model) };
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
		val["stream"] = (JToken)(false);
		val["options"] = (JToken)new JObject
		{
			["temperature"] = (JToken)(0.7),
			["top_p"] = (JToken)(0.9)
		};
		JObject chatRequestBody = val;
		try
		{
			StringContent chatContent = new StringContent(((JToken)chatRequestBody).ToString((Formatting)0, Array.Empty<JsonConverter>()), Encoding.UTF8, "application/json");
			HttpResponseMessage chatResponse = await httpClient.PostAsync(chatUrl, (HttpContent)(object)chatContent);
			if (chatResponse.IsSuccessStatusCode)
			{
				dynamic chatResponseObj = JsonConvert.DeserializeObject<object>(await chatResponse.Content.ReadAsStringAsync());
				if (chatResponseObj?.message?.content != null)
				{
					dynamic responseText = chatResponseObj.message.content.ToString();
					return responseText;
				}
			}
			else
			{
				LogWarning($"Ollama chat endpoint failed with status {chatResponse.StatusCode}, trying generate endpoint");
			}
		}
		catch (Exception ex)
		{
			LogWarning("Ollama chat endpoint failed: " + ex.Message + ", trying generate endpoint");
		}
		string generatePrompt = (extracted ? (systemPrompt + "\n\n### Your Response ###\n" + userMessage) : (prompt + "\n\nRespond to the player's latest message in character, following the instructions provided. Format your response as JSON with all required fields."));
		string generateUrl = baseUrl + "/api/generate";
		JObject generateRequestBody = new JObject
		{
			["model"] = (JToken)(model),
			["prompt"] = (JToken)(generatePrompt),
			["stream"] = (JToken)(false),
			["options"] = (JToken)new JObject
			{
				["temperature"] = (JToken)(0.7),
				["top_p"] = (JToken)(0.9)
			}
		};
		try
		{
			StringContent generateContent = new StringContent(((JToken)generateRequestBody).ToString((Formatting)0, Array.Empty<JsonConverter>()), Encoding.UTF8, "application/json");
			HttpResponseMessage generateResponse = await httpClient.PostAsync(generateUrl, (HttpContent)(object)generateContent);
			if (generateResponse.IsSuccessStatusCode)
			{
				OllamaResponse ollamaResponse = JsonConvert.DeserializeObject<OllamaResponse>(await generateResponse.Content.ReadAsStringAsync());
				if (ollamaResponse?.Response != null)
				{
					return ollamaResponse.Response;
				}
			}
			else
			{
				LogError(string.Format(arg1: await generateResponse.Content.ReadAsStringAsync(), format: "Ollama generate endpoint failed with status {0}: {1}", arg0: generateResponse.StatusCode));
			}
		}
		catch (Exception ex2)
		{
			LogError("Ollama generate endpoint failed: " + ex2.Message);
		}
		return GenerateErrorResponse("Failed to get response from Ollama. Check if Ollama is running and the model is loaded.");
	}

	private static async Task<string> GetOllamaRawResponse(string prompt, int cachePrefixLength = 0)
	{
		string model = GlobalSettings<ModSettings>.Instance?.OllamaModel ?? "llama2";
		string baseUrl = GlobalSettings<ModSettings>.Instance?.OllamaApiUrl ?? "http://localhost:11434";
		JArray chatMessages;
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
			chatMessages = val;
		}
		else
		{
			JArray val2 = new JArray();
			val2.Add((JToken)new JObject
			{
				["role"] = (JToken)("user"),
				["content"] = (JToken)(prompt)
			});
			chatMessages = val2;
		}
		string chatUrl = baseUrl + "/api/chat";
		JObject chatRequestBody = new JObject
		{
			["model"] = (JToken)(model),
			["messages"] = (JToken)(object)chatMessages,
			["stream"] = (JToken)(false),
			["options"] = (JToken)new JObject
			{
				["temperature"] = (JToken)(0.7),
				["top_p"] = (JToken)(0.9)
			}
		};
		try
		{
			StringContent chatContent = new StringContent(((JToken)chatRequestBody).ToString((Formatting)0, Array.Empty<JsonConverter>()), Encoding.UTF8, "application/json");
			HttpResponseMessage chatResponse = await httpClient.PostAsync(chatUrl, (HttpContent)(object)chatContent);
			if (chatResponse.IsSuccessStatusCode)
			{
				dynamic chatResponseObj = JsonConvert.DeserializeObject<object>(await chatResponse.Content.ReadAsStringAsync());
				if (chatResponseObj?.message?.content != null)
				{
					return chatResponseObj.message.content.ToString().Trim();
				}
			}
			else
			{
				LogWarning($"Ollama chat endpoint failed with status {chatResponse.StatusCode}, trying generate endpoint");
			}
		}
		catch (Exception ex)
		{
			LogWarning("Ollama chat endpoint failed: " + ex.Message + ", trying generate endpoint");
		}
		string generateUrl = baseUrl + "/api/generate";
		JObject generateRequestBody = new JObject
		{
			["model"] = (JToken)(model),
			["prompt"] = (JToken)(prompt),
			["stream"] = (JToken)(false),
			["options"] = (JToken)new JObject
			{
				["temperature"] = (JToken)(0.7),
				["top_p"] = (JToken)(0.9)
			}
		};
		try
		{
			StringContent generateContent = new StringContent(((JToken)generateRequestBody).ToString((Formatting)0, Array.Empty<JsonConverter>()), Encoding.UTF8, "application/json");
			HttpResponseMessage generateResponse = await httpClient.PostAsync(generateUrl, (HttpContent)(object)generateContent);
			if (generateResponse.IsSuccessStatusCode)
			{
				return JsonConvert.DeserializeObject<OllamaResponse>(await generateResponse.Content.ReadAsStringAsync())?.Response ?? "No response from Ollama";
			}
			LogError(string.Format(arg1: await generateResponse.Content.ReadAsStringAsync(), format: "Ollama generate endpoint failed with status {0}: {1}", arg0: generateResponse.StatusCode));
		}
		catch (Exception ex2)
		{
			LogError("Ollama generate endpoint failed: " + ex2.Message);
		}
		return "Error: Failed to get response from Ollama. Check if Ollama is running and the model is loaded.";
	}

	private static async Task<string> GetKoboldCppResponse(string npcName, string faction, string prompt)
	{
		string baseUrl = GlobalSettings<ModSettings>.Instance?.KoboldCppApiUrl ?? "http://localhost:5001";
		string url = baseUrl + "/api/v1/generate";
		(string, string, bool) tuple = ExtractLastPlayerMessage(prompt);
		string systemPrompt = tuple.Item1;
		string userMessage = tuple.Item2;
		string koboldPrompt = (tuple.Item3 ? (systemPrompt + "\n\n### Player's Latest Message ###\n" + userMessage + "\n\n### Your Response ###\nRespond as the character in JSON format:") : (prompt + "\n\nRespond to the player's latest message in character, following the instructions provided. Format your response as JSON with all required fields."));
		JObject val = new JObject
		{
			["prompt"] = (JToken)(koboldPrompt),
			["temperature"] = (JToken)(0.7),
			["top_p"] = (JToken)(0.9),
			["stream"] = (JToken)(false)
		};
		JArray val2 = new JArray();
		val2.Add((JToken)("Human:"));
		val2.Add((JToken)("Assistant:"));
		val2.Add((JToken)("\n\nPlayer:"));
		val2.Add((JToken)("### Player's Latest Message ###"));
		val["stop_sequence"] = (JToken)val2;
		JObject requestBody = val;
		try
		{
			StringContent content = new StringContent(((JToken)requestBody).ToString((Formatting)0, Array.Empty<JsonConverter>()), Encoding.UTF8, "application/json");
			HttpResponseMessage response = await httpClient.PostAsync(url, (HttpContent)(object)content);
			if (response.IsSuccessStatusCode)
			{
				KoboldCppResponse koboldResponse = JsonConvert.DeserializeObject<KoboldCppResponse>(await response.Content.ReadAsStringAsync());
				if (koboldResponse != null && koboldResponse.Results?.Length > 0 && !string.IsNullOrEmpty(koboldResponse.Results[0].Text))
				{
					return koboldResponse.Results[0].Text.Trim();
				}
				LogWarning("KoboldCpp returned empty or invalid response");
			}
			else
			{
				LogError(string.Format(arg1: await response.Content.ReadAsStringAsync(), format: "KoboldCpp request failed with status {0}: {1}", arg0: response.StatusCode));
			}
		}
		catch (Exception ex)
		{
			LogError("KoboldCpp request failed: " + ex.Message);
		}
		return GenerateErrorResponse("Failed to get response from KoboldCpp. Check if KoboldCpp is running and accessible.");
	}

	private static async Task<string> GetKoboldCppRawResponse(string prompt, int cachePrefixLength = 0)
	{
		string baseUrl = GlobalSettings<ModSettings>.Instance?.KoboldCppApiUrl ?? "http://localhost:5001";
		string url = baseUrl + "/api/v1/generate";
		JObject val = new JObject
		{
			["prompt"] = (JToken)(prompt),
			["temperature"] = (JToken)(0.7),
			["top_p"] = (JToken)(0.9),
			["stream"] = (JToken)(false)
		};
		JArray val2 = new JArray();
		val2.Add((JToken)("Human:"));
		val2.Add((JToken)("Assistant:"));
		val2.Add((JToken)("\n\n"));
		val["stop_sequence"] = (JToken)val2;
		JObject requestBody = val;
		try
		{
			StringContent content = new StringContent(((JToken)requestBody).ToString((Formatting)0, Array.Empty<JsonConverter>()), Encoding.UTF8, "application/json");
			HttpResponseMessage response = await httpClient.PostAsync(url, (HttpContent)(object)content);
			if (response.IsSuccessStatusCode)
			{
				KoboldCppResponse koboldResponse = JsonConvert.DeserializeObject<KoboldCppResponse>(await response.Content.ReadAsStringAsync());
				if (koboldResponse != null && koboldResponse.Results?.Length > 0 && !string.IsNullOrEmpty(koboldResponse.Results[0].Text))
				{
					return koboldResponse.Results[0].Text.Trim();
				}
				LogWarning("KoboldCpp returned empty or invalid response");
			}
			else
			{
				LogError(string.Format(arg1: await response.Content.ReadAsStringAsync(), format: "KoboldCpp request failed with status {0}: {1}", arg0: response.StatusCode));
			}
		}
		catch (Exception ex)
		{
			LogError("KoboldCpp request failed: " + ex.Message);
		}
		return "Error: Failed to get response from KoboldCpp. Check if KoboldCpp is running and accessible.";
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

	private static string GeneratePlayer2ErrorResponse(string baseMessage)
	{
		string message = baseMessage + " Please check if Player2 application is installed and running, and ensure your device has sufficient battery charge.";
		return GenerateErrorResponse(message);
	}

	private static void LogError(string message)
	{
		AIInfluenceBehavior.Instance?.LogMessage("[ERROR] AIClient: " + message);
	}

	private static void LogWarning(string message)
	{
		AIInfluenceBehavior.Instance?.LogMessage("[WARNING] AIClient: " + message);
	}

	public static async Task<bool> TestOllamaConnection()
	{
		return await OllamaClient.TestConnection();
	}

	public static async Task<bool> TestKoboldCppConnection()
	{
		return await KoboldCppClient.TestConnection();
	}

	public static async Task<bool> TestCurrentBackendConnection()
	{
		return (GlobalSettings<ModSettings>.Instance?.AIBackend?.SelectedValue ?? "Player2") switch
		{
			"Ollama" => await TestOllamaConnection(), 
			"KoboldCpp" => await TestKoboldCppConnection(), 
			"Player2" => await TestPlayer2Connection(), 
			"DeepSeek" => await TestDeepSeekConnection(), 
			"OpenRouter" => await TestOpenRouterConnection(), 
			_ => false, 
		};
	}

	public static async Task<bool> TestPlayer2Connection()
	{
		return await Player2Client.TestConnection();
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

	public static async Task<bool> TestDeepSeekConnection()
	{
		return await DeepSeekClient.TestConnection();
	}

	private static void LogMessage(string message)
	{
		AIInfluenceBehavior.Instance?.LogMessage("[INFO] AIClient: " + message);
	}
}
