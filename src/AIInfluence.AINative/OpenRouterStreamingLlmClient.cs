using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AIInfluence.NpcInteraction;

public sealed class OpenRouterModelClient
{
	private readonly HttpClient _httpClient;

	private readonly string _apiKey;

	private readonly string _model;

	public OpenRouterModelClient(string apiKey, string model, HttpClient httpClient = null)
	{
		_apiKey = apiKey;
		_model = model;
		_httpClient = httpClient ?? new HttpClient();
	}

	public async Task<ModelTurnResult> StreamTurnAsync(string systemPrompt, string userPrompt, Action<string> onTextDelta = null)
	{
		var requestBody = new JObject
		{
			["model"] = _model,
			["stream"] = true,
			["tool_choice"] = "auto",
			["tools"] = new JArray()
		};
		var messages = new JArray();
		messages.Add(new JObject
		{
			["role"] = "system",
			["content"] = systemPrompt
		});
		messages.Add(new JObject
		{
			["role"] = "user",
			["content"] = userPrompt
		});
		requestBody["messages"] = messages;
		var request = new HttpRequestMessage(HttpMethod.Post, "https://openrouter.ai/api/v1/chat/completions");
		request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
		request.Content = new StringContent(requestBody.ToString(Formatting.None), Encoding.UTF8, "application/json");
		var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
		var textBuilder = new StringBuilder();
		using (var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
		{
			using StreamReader streamReader = new StreamReader(stream);
			while (!streamReader.EndOfStream)
			{
				string line = await streamReader.ReadLineAsync().ConfigureAwait(false);
				if (string.IsNullOrWhiteSpace(line) || !line.StartsWith("data:", StringComparison.Ordinal))
				{
					continue;
				}
				string payload = line.Substring(5).Trim();
				if (payload == "[DONE]")
				{
					break;
				}
				var chunk = JObject.Parse(payload);
				string deltaText = chunk["choices"]?[0]?["delta"]?["content"]?.ToString();
				if (string.IsNullOrEmpty(deltaText))
				{
					continue;
				}
				textBuilder.Append(deltaText);
				onTextDelta?.Invoke(deltaText);
			}
		}
		return new ModelTurnResult(textBuilder.ToString(), new List<ModelToolCall>());
	}
}

