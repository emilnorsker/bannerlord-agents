using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AIInfluence.NpcInteraction;

public sealed class OpenRouterClient
{
	public const string SayTool = "say";
	public const string EmoteTool = "emote";
	private readonly HttpClient _httpClient;
	private readonly string _apiKey;
	private readonly string _model;

	public OpenRouterClient(string apiKey, string model, HttpClient httpClient = null)
	{
		_apiKey = apiKey;
		_model = model;
		if (httpClient == null)
		{
			_httpClient = new HttpClient();
		}
		else
		{
			_httpClient = httpClient;
		}
	}

	public async Task<string> GenerateNpcReplyAsync(string systemPrompt, string userPrompt, Action<string> onTextDelta = null)
	{
		var body = new JObject
		{
			["model"] = _model,
			["stream"] = true,
			["tool_choice"] = "auto",
			["tools"] = new JArray(),
			["messages"] = new JArray
			{
				new JObject { ["role"] = "system", ["content"] = systemPrompt },
				new JObject { ["role"] = "user", ["content"] = userPrompt }
			}
		};
		var request = new HttpRequestMessage(HttpMethod.Post, "https://openrouter.ai/api/v1/chat/completions");
		request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
		request.Content = new StringContent(body.ToString(Formatting.None), Encoding.UTF8, "application/json");
		var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
		StringBuilder text = new StringBuilder();
		using var stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		using StreamReader reader = new StreamReader(stream);
		while (!reader.EndOfStream)
		{
			string line = await reader.ReadLineAsync().ConfigureAwait(false);
			if (string.IsNullOrWhiteSpace(line) || !line.StartsWith("data:", StringComparison.Ordinal)) continue;
			string payload = line.Substring(5).Trim();
			if (payload == "[DONE]") break;
			string delta = JObject.Parse(payload)["choices"]?[0]?["delta"]?["content"]?.ToString();
			if (string.IsNullOrEmpty(delta)) continue;
			text.Append(delta);
			onTextDelta?.Invoke(delta);
		}
		return text.ToString();
	}
}
