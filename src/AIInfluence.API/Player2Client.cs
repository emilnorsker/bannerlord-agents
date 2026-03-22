using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AIInfluence.Util;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TaleWorlds.Library;

namespace AIInfluence.API;

public static class Player2Client
{
	private static readonly HttpClient httpClient = new HttpClient();

	private const string GAME_KEY = "0199bcdd-3f9f-7a67-947e-ca10021b94ce";

	private const string URL_HEALTH = "/v1/health";

	private const string URL_CHAT_COMPLETIONS = "/v1/chat/completions";

	private static DateTime _lastHeartbeat = DateTime.MinValue;

	private static bool _isHealthy = false;

	private static Timer _heartbeatTimer;

	private static bool _timerStarted = false;

	public static void StartHeartbeatTimer()
	{
		if (_timerStarted && _heartbeatTimer != null)
		{
			return;
		}
		if (_heartbeatTimer != null)
		{
			try
			{
				_heartbeatTimer.Dispose();
			}
			catch
			{
			}
			_heartbeatTimer = null;
		}
		_heartbeatTimer = new Timer(async delegate
		{
			try
			{
				await SendHeartbeatAsync();
			}
			catch (Exception ex)
			{
				Exception ex2 = ex;
				AIInfluenceBehavior.Instance?.LogMessage("[Player2] Timer heartbeat error: " + ex2.Message);
			}
		}, null, TimeSpan.Zero, TimeSpan.FromSeconds(60.0));
		_timerStarted = true;
		AIInfluenceBehavior.Instance?.LogMessage("[Player2] Heartbeat timer started (every 60 seconds)");
	}

	public static void StopHeartbeatTimer()
	{
		AIInfluenceBehavior.Instance?.LogMessage("[Player2] StopHeartbeatTimer called - but timer continues to work (like StatisticsTracker)");
	}

	private static async Task<bool> SendHeartbeatAsync()
	{
		try
		{
			string baseUrl = GlobalSettings<ModSettings>.Instance?.Player2ApiUrl ?? "http://127.0.0.1:4315";
			string healthUrl = baseUrl + "/v1/health";
			AIInfluenceBehavior.Instance?.LogMessage("[Player2] Sending heartbeat to " + healthUrl);
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, healthUrl);
			((HttpHeaders)request.Headers).Add("player2-game-key", "0199bcdd-3f9f-7a67-947e-ca10021b94ce");
			HttpResponseMessage response = await httpClient.SendAsync(request);
			string responseText = await response.Content.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode)
			{
				AIInfluenceBehavior.Instance?.LogMessage($"[Player2] Heartbeat failed: HTTP {response.StatusCode} - {responseText}");
				_isHealthy = false;
				_lastHeartbeat = DateTime.Now;
				return false;
			}
			try
			{
				_isHealthy = ((dynamic)JsonConvert.DeserializeObject<object>(responseText))?.client_version != null;
				if (_isHealthy)
				{
					AIInfluenceBehavior.Instance?.LogMessage("[Player2] Heartbeat successful");
				}
				else
				{
					AIInfluenceBehavior.Instance?.LogMessage("[Player2] Heartbeat failed: missing client_version in response");
				}
			}
			catch (Exception ex)
			{
				AIInfluenceBehavior.Instance?.LogMessage("[Player2] Heartbeat failed: unable to parse response - " + ex.Message);
				_isHealthy = false;
			}
			_lastHeartbeat = DateTime.Now;
			return _isHealthy;
		}
		catch (Exception ex2)
		{
			Exception ex3 = ex2;
			AIInfluenceBehavior.Instance?.LogMessage("[Player2] Exception during heartbeat: " + ex3.Message);
			_isHealthy = false;
			_lastHeartbeat = DateTime.Now;
			return false;
		}
	}

	public static async Task<bool> CheckHealthAsync()
	{
		if (!_timerStarted)
		{
			try
			{
				AIInfluenceBehavior.Instance?.LogMessage("[Player2] Auto-recovering heartbeat timer - timer was stopped but application is still running");
				StartHeartbeatTimer();
			}
			catch (Exception ex)
			{
				Exception ex2 = ex;
				AIInfluenceBehavior.Instance?.LogMessage("[Player2] Error auto-recovering timer: " + ex2.Message);
			}
		}
		if ((DateTime.Now - _lastHeartbeat).TotalSeconds < 30.0 && _lastHeartbeat != DateTime.MinValue)
		{
			return _isHealthy;
		}
		return await SendHeartbeatAsync();
	}

	public static async Task<string> GetAIResponse(string prompt, string systemPrompt = "")
	{
		try
		{
			if (!_timerStarted)
			{
				try
				{
					AIInfluenceBehavior.Instance?.LogMessage("[Player2] Auto-recovering heartbeat timer in GetAIResponse");
					StartHeartbeatTimer();
				}
				catch (Exception ex)
				{
					Exception ex2 = ex;
					AIInfluenceBehavior.Instance?.LogMessage("[Player2] Error auto-recovering timer: " + ex2.Message);
				}
			}
			if (!(await CheckHealthAsync()))
			{
				return "Error: Player2 API is not healthy";
			}
			string baseUrl = GlobalSettings<ModSettings>.Instance?.Player2ApiUrl ?? "http://127.0.0.1:4315";
			string url = baseUrl + "/v1/chat/completions";
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
				["content"] = (JToken)(prompt)
			});
			val["messages"] = (JToken)val2;
			JObject requestBody = val;
			string json = ((JToken)requestBody).ToString((Formatting)0, Array.Empty<JsonConverter>());
			StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
			request.Content = (HttpContent)(object)content;
			((HttpHeaders)request.Headers).Add("player2-game-key", "0199bcdd-3f9f-7a67-947e-ca10021b94ce");
			HttpResponseMessage response = await httpClient.SendAsync(request);
			string responseText = await response.Content.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode)
			{
				return $"Error: HTTP {response.StatusCode} - {responseText}";
			}
			dynamic responseData = JsonConvert.DeserializeObject<object>(responseText);
			if (responseData?.choices != null && responseData.choices.Count > 0)
			{
				return responseData.choices[0].message.content?.ToString() ?? "Error: No content in response";
			}
			return "Error: Invalid response format";
		}
		catch (Exception ex)
		{
			Exception ex3 = ex;
			return "Error: " + ex3.Message;
		}
	}

	public static async Task<bool> TestConnection()
	{
		try
		{
			string baseUrl = GlobalSettings<ModSettings>.Instance?.Player2ApiUrl ?? "http://127.0.0.1:4315";
			string url = baseUrl + "/v1/chat/completions";
			JObject val = new JObject();
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
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
			request.Content = (HttpContent)(object)content;
			((HttpHeaders)request.Headers).Add("player2-game-key", "0199bcdd-3f9f-7a67-947e-ca10021b94ce");
			HttpResponseMessage response = await httpClient.SendAsync(request);
			if (response.IsSuccessStatusCode)
			{
				InformationManager.DisplayMessage(new InformationMessage("Player2: Connection test successful", ExtraColors.GreenAIInfluence));
				return true;
			}
			InformationManager.DisplayMessage(new InformationMessage(string.Format(arg1: await response.Content.ReadAsStringAsync(), format: "Player2: Connection test failed: {0} - {1}", arg0: response.StatusCode), ExtraColors.RedAIInfluence));
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			InformationManager.DisplayMessage(new InformationMessage("Player2: Connection test failed: " + ex2.Message, ExtraColors.RedAIInfluence));
		}
		return false;
	}
}
