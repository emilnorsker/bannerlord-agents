using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AIInfluence.NpcInteraction;

public sealed class NpcInteractionInferenceClient
{
	public const string SayTool = "say";
	public const string EmoteTool = "emote";

	private readonly HttpClient _httpClient;
	private readonly string _apiKey;
	private readonly string _model;

	public NpcInteractionInferenceClient(string apiKey, string model, HttpClient httpClient = null)
	{
		_apiKey = apiKey;
		_model = model;
		_httpClient = httpClient;
		if (_httpClient == null)
		{
			_httpClient = new HttpClient();
		}
	}

	public async Task<List<NpcToolCall>> RequestNpcToolCallsAsync(string systemPrompt, string userPrompt)
	{
		var body = new JObject
		{
			["model"] = _model,
			["stream"] = false,
			["tool_choice"] = "auto",
			["tools"] = new JArray
			{
				new JObject
				{
					["type"] = "function",
					["function"] = new JObject
					{
						["name"] = SayTool,
						["description"] = "Say dialogue to the player.",
						["parameters"] = new JObject
						{
							["type"] = "object",
							["properties"] = new JObject { ["text"] = new JObject { ["type"] = "string" } },
							["required"] = new JArray("text")
						}
					}
				},
				new JObject
				{
					["type"] = "function",
					["function"] = new JObject
					{
						["name"] = EmoteTool,
						["description"] = "Render an emote action in chat.",
						["parameters"] = new JObject
						{
							["type"] = "object",
							["properties"] = new JObject { ["text"] = new JObject { ["type"] = "string" } },
							["required"] = new JArray("text")
						}
					}
				}
			},
			["messages"] = new JArray
			{
				new JObject { ["role"] = "system", ["content"] = systemPrompt },
				new JObject { ["role"] = "user", ["content"] = userPrompt }
			}
		};
		var request = new HttpRequestMessage(HttpMethod.Post, "https://openrouter.ai/api/v1/chat/completions");
		request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
		request.Content = new StringContent(body.ToString(Formatting.None), Encoding.UTF8, "application/json");
		var response = await _httpClient.SendAsync(request).ConfigureAwait(false);
		response.EnsureSuccessStatusCode();
		var json = JObject.Parse(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
		var calls = (JArray)json["choices"]?[0]?["message"]?["tool_calls"];
		var output = new List<NpcToolCall>();
		if (calls == null)
		{
			return output;
		}
		foreach (JToken call in calls)
		{
			string name = call["function"]?["name"]?.ToString();
			string args = call["function"]?["arguments"]?.ToString();
			output.Add(new NpcToolCall { ToolName = name, ToolArguments = JObject.Parse(args) });
		}
		return output;
	}
}
