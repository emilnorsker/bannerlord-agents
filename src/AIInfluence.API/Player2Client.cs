using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using AIInfluence.Services;
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

	[Obfuscation(Exclude = true)]
	private const string URL_HEALTH = "/v1/health";

	[Obfuscation(Exclude = true)]
	private const string URL_CHAT_COMPLETIONS = "/v1/chat/completions";

	[Obfuscation(Exclude = true)]
	private const string URL_TTS_SPEAK = "/v1/tts/speak";

	private static DateTime _lastHeartbeat = DateTime.MinValue;

	private static bool _isHealthy = false;

	private static Timer _heartbeatTimer;

	private static bool _timerStarted = false;

	private static Dictionary<string, VoiceInfo> _availableVoices = null;

	private static readonly object _voicesInitLock = new object();

	private static Dictionary<string, Queue<string>> _recentVoicesByGender = new Dictionary<string, Queue<string>>(StringComparer.OrdinalIgnoreCase);

	private const int VOICE_REUSE_COOLDOWN = 10;

	private static void InitializeStaticVoices()
	{
		if (_availableVoices != null)
		{
			return;
		}
		lock (_voicesInitLock)
		{
			if (_availableVoices == null)
			{
				_availableVoices = new Dictionary<string, VoiceInfo>(StringComparer.OrdinalIgnoreCase);
				AddVoice("01955d76-ed5b-768f-9e5b-8bcc89ba8f3d", "Arjun", "male", "hi_IN");
				AddVoice("01955d76-ed5b-74ba-89e5-2b4b45e632cd", "Benjamin", "male", "en_US");
				AddVoice("01955d76-ed5b-74de-83e5-800a44fee0d1", "Caleb", "male", "en_US");
				AddVoice("01955d76-ed5b-7566-9c0e-bce4d88ceba0", "Charles", "male", "en_US");
				AddVoice("01955d76-ed5b-748c-8d98-0fb708ef0fbd", "Ethan", "male", "en_US");
				AddVoice("01955d76-ed5b-76d2-8f05-b9a34b5f9011", "Gabriel", "male", "pt_BR");
				AddVoice("01955d76-ed5b-761e-abac-1956f66ac089", "Hao", "male", "zh_CN");
				AddVoice("01955d76-ed5b-754f-a070-a570ddfed516", "Harry", "male", "en_US");
				AddVoice("01955d76-ed5b-74d2-a33c-b2b8e998658f", "Jackson", "male", "en_US");
				AddVoice("01955d76-ed5b-7655-98bb-fd7578af9617", "Javier", "male", "es_ES");
				AddVoice("01955d76-ed5b-7606-9e21-8b236fbe12a8", "Liang", "male", "zh_CN");
				AddVoice("01955d76-ed5b-74af-a2be-9302077075b8", "Logan", "male", "en_US");
				AddVoice("01955d76-ed5b-74c6-ac15-ab68ee19d560", "Lucas", "male", "en_US");
				AddVoice("01955d76-ed5b-76ba-898e-c65bd579a334", "Marco", "male", "it_IT");
				AddVoice("01955d76-ed5b-74a3-9129-c3253d01f690", "Mason", "male", "en_US");
				AddVoice("01955d76-ed5b-7649-ac1e-c56a13c3302f", "Miguel", "male", "es_ES");
				AddVoice("01955d76-ed5b-7612-bf44-f7bdcc808356", "Ming", "male", "zh_CN");
				AddVoice("01955d76-ed5b-74e9-9fea-1f8cad1cd9c5", "Nicholas", "male", "en_US");
				AddVoice("01955d76-ed5b-7497-9f8e-0e7448515bf3", "Noah", "male", "en_US");
				AddVoice("01955d76-ed5b-753f-9f74-c0674216f0f5", "Oliver", "male", "en_US");
				AddVoice("01955d76-ed5b-76dd-bef6-37119ea2f99f", "Rafael", "male", "pt_BR");
				AddVoice("01955d76-ed5b-75b8-b70f-dfaf400b7c42", "Takashi", "male", "ja_JP");
				AddVoice("01955d76-ed5b-769b-bd00-002a8e88dc65", "Vikram", "male", "hi_IN");
				AddVoice("01955d76-ed5b-75fb-87dd-ebbed25d2585", "Wei", "male", "zh_CN");
				AddVoice("01955d76-ed5b-755b-9b43-890d73586908", "William", "male", "en_US");
				AddVoice("01955d76-ed5b-7468-83a7-bfc267cf4849", "Abigail", "female", "en_US");
				AddVoice("01955d76-ed5b-7683-a79d-253390189fdb", "Aditi", "female", "hi_IN");
				AddVoice("01955d76-ed5b-7591-9d3f-f919ac645bb6", "Akari", "female", "ja_JP");
				AddVoice("01955d76-ed5b-7441-a184-5f5ee015e4fe", "Amelia", "female", "en_US");
				AddVoice("01955d76-ed5b-7534-b7a6-028adcfb4e7d", "Amelia", "female", "en_US");
				AddVoice("01955d76-ed5b-7436-a182-c4d21aaca9fc", "Ava", "female", "en_US");
				AddVoice("01955d76-ed5b-76ab-bc6b-57cc5dfeaf01", "Bianca", "female", "it_IT");
				AddVoice("01955d76-ed5b-762a-9a2a-0fec3b7ace8b", "Carmen", "female", "es_ES");
				AddVoice("01955d76-ed5b-7451-92d6-5ef579d3ed28", "Charlotte", "female", "en_US");
				AddVoice("01955d76-ed5b-7480-951c-af1dd9873e34", "Chloe", "female", "en_US");
				AddVoice("01955d76-ed5b-74f9-b54a-2d051890468d", "Eleanor", "female", "en_US");
				AddVoice("01955d76-ed5b-745d-add1-b755d440192d", "Evelyn", "female", "en_US");
				AddVoice("01955d76-ed5b-7528-86ee-3348a642af7e", "Florence", "female", "en_US");
				AddVoice("01955d76-ed5b-75ad-afe3-ac5eb3d0a16e", "Hana", "female", "ja_JP");
				AddVoice("01955d76-ed5b-7416-82d8-5fc486e2f676", "Harper", "female", "en_US");
				AddVoice("01955d76-ed5b-76c6-8b9e-b713d3f0b866", "Isabela", "female", "pt_BR");
				AddVoice("01955d76-ed5b-75df-8ca5-a6f84acaff76", "Jingyi", "female", "zh_CN");
				AddVoice("01955d76-ed5b-75d4-8338-3d7108137cd1", "Ling", "female", "zh_CN");
				AddVoice("01955d76-ed5b-7407-a03c-cdd993439ba4", "Madison", "female", "en_US");
				AddVoice("01955d76-ed5b-75c8-8386-b83ff9c45856", "Mei", "female", "zh_CN");
				AddVoice("01955d76-ed5b-7474-86b2-a41b310c2a2d", "Mia", "female", "en_US");
				AddVoice("01955d76-ed5b-7426-8748-4b0e5aea1974", "Olivia", "female", "en_US");
				AddVoice("01955d76-ed5b-751c-b341-0ee85dbefd92", "Poppy", "female", "en_US");
				AddVoice("01955d76-ed5b-7678-b678-3ddc5ec8b5c4", "Priya", "female", "hi_IN");
				AddVoice("01955d76-ed5b-75eb-b509-e7bf29b3b530", "Qiuyue", "female", "zh_CN");
				AddVoice("01955d76-ed5b-757a-9bdb-94fa0a2b7893", "Sakura", "female", "ja_JP");
				AddVoice("01955d76-ed5b-73e0-a88d-cbeb3c5b499d", "Sophia", "female", "en_US");
				AddVoice("01955d76-ed5b-7668-877b-2fa240c1d5ee", "Sophie", "female", "fr_FR");
				AddVoice("01955d76-ed5b-75a1-96f8-7a82e767e2c4", "Yuki", "female", "ja_JP");
			}
		}
	}

	private static void AddVoice(string id, string name, string gender, string language)
	{
		_availableVoices[id] = new VoiceInfo
		{
			Id = id,
			Name = name,
			Gender = gender,
			Language = language
		};
	}

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
				["role"] = JToken.op_Implicit("system"),
				["content"] = JToken.op_Implicit(systemPrompt)
			});
			val2.Add((JToken)new JObject
			{
				["role"] = JToken.op_Implicit("user"),
				["content"] = JToken.op_Implicit(prompt)
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

	private static string ConvertLanguageToISO(string apiLanguage)
	{
		if (string.IsNullOrEmpty(apiLanguage))
		{
			return "en_US";
		}
		string text = apiLanguage.Trim();
		switch (text.ToLower())
		{
		case "american_english":
		case "british_english":
			return "en_US";
		case "japanese":
			return "ja_JP";
		case "mandarin_chinese":
			return "zh_CN";
		case "spanish":
			return "es_ES";
		case "french":
			return "fr_FR";
		case "italian":
			return "it_IT";
		case "brazilian_portuguese":
			return "pt_BR";
		case "hindi":
			return "hi_IN";
		default:
			if (text.Contains("_"))
			{
				return text;
			}
			AIInfluenceBehavior.Instance?.LogMessage("[TTS_WARNING] Unknown language format: " + apiLanguage + ", using en_US");
			return "en_US";
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
				["role"] = JToken.op_Implicit("user"),
				["content"] = JToken.op_Implicit("Hello")
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

	private static string RemoveAsteriskText(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return text;
		}
		string pattern = "\\*+[^*]*\\*+";
		string input = Regex.Replace(text, pattern, "", RegexOptions.Multiline);
		input = Regex.Replace(input, "\\s+", " ", RegexOptions.Multiline);
		return input.Trim();
	}

	public static Dictionary<string, VoiceInfo> GetAvailableVoices()
	{
		InitializeStaticVoices();
		return _availableVoices ?? new Dictionary<string, VoiceInfo>();
	}

	public static async Task<List<string>> GetAvailableVoicesAsync()
	{
		InitializeStaticVoices();
		return new List<string>(_availableVoices.Keys);
	}

	public static async Task<VoiceInfo> GetVoiceInfoAsync(string voiceId)
	{
		InitializeStaticVoices();
		if (string.IsNullOrEmpty(voiceId))
		{
			return null;
		}
		_availableVoices.TryGetValue(voiceId, out var voiceInfo);
		return voiceInfo;
	}

	public static bool VoiceExists(string voiceId)
	{
		if (string.IsNullOrEmpty(voiceId))
		{
			return false;
		}
		InitializeStaticVoices();
		return _availableVoices != null && _availableVoices.ContainsKey(voiceId);
	}

	public static async Task<bool> VoiceExistsAsync(string voiceId)
	{
		if (string.IsNullOrEmpty(voiceId))
		{
			return false;
		}
		InitializeStaticVoices();
		return _availableVoices != null && _availableVoices.ContainsKey(voiceId);
	}

	public static async Task<string> GetRandomVoiceAsync(string gender)
	{
		InitializeStaticVoices();
		if (_availableVoices == null || _availableVoices.Count == 0)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[TTS_ERROR] No available voices for assignment (gender: " + gender + ")");
			return null;
		}
		string normalizedGender = (gender?.ToLower() ?? "").Trim();
		if (string.IsNullOrEmpty(normalizedGender))
		{
			AIInfluenceBehavior.Instance?.LogMessage("[TTS_ERROR] Gender not specified for voice assignment");
			return null;
		}
		List<string> allVoicesForGender = (from v in _availableVoices.Values
			where v.Gender.Equals(normalizedGender, StringComparison.OrdinalIgnoreCase)
			select v.Id).ToList();
		if (allVoicesForGender.Count == 0)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[TTS_ERROR] No voices found for gender: " + gender);
			return null;
		}
		if (!_recentVoicesByGender.ContainsKey(normalizedGender))
		{
			_recentVoicesByGender[normalizedGender] = new Queue<string>();
		}
		Queue<string> recentVoices = _recentVoicesByGender[normalizedGender];
		List<string> availableVoices = allVoicesForGender.Where((string voiceId) => !recentVoices.Contains(voiceId)).ToList();
		if (availableVoices.Count == 0)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[TTS] All voices for gender " + gender + " were recently used, resetting list");
			recentVoices.Clear();
			availableVoices = allVoicesForGender;
		}
		Random random = new Random();
		string selectedVoice = availableVoices[random.Next(availableVoices.Count)];
		recentVoices.Enqueue(selectedVoice);
		while (recentVoices.Count > 10)
		{
			recentVoices.Dequeue();
		}
		return selectedVoice;
	}

	public static string GetRandomVoice(string gender)
	{
		InitializeStaticVoices();
		if (_availableVoices == null || _availableVoices.Count == 0)
		{
			return null;
		}
		string normalizedGender = (gender?.ToLower() ?? "").Trim();
		if (string.IsNullOrEmpty(normalizedGender))
		{
			AIInfluenceBehavior.Instance?.LogMessage("[TTS_ERROR] Gender not specified for voice assignment");
			return null;
		}
		List<string> list = (from v in _availableVoices.Values
			where v.Gender.Equals(normalizedGender, StringComparison.OrdinalIgnoreCase)
			select v.Id).ToList();
		if (list.Count == 0)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[TTS_ERROR] No voices found for gender: " + gender);
			return null;
		}
		if (!_recentVoicesByGender.ContainsKey(normalizedGender))
		{
			_recentVoicesByGender[normalizedGender] = new Queue<string>();
		}
		Queue<string> recentVoices = _recentVoicesByGender[normalizedGender];
		List<string> list2 = list.Where((string voiceId) => !recentVoices.Contains(voiceId)).ToList();
		if (list2.Count == 0)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[TTS] All voices for gender " + gender + " were recently used, resetting list");
			recentVoices.Clear();
			list2 = list;
		}
		Random random = new Random();
		string text = list2[random.Next(list2.Count)];
		recentVoices.Enqueue(text);
		while (recentVoices.Count > 10)
		{
			recentVoices.Dequeue();
		}
		return text;
	}

	public static async Task<byte[]> GenerateTTSAudioBytesAsync(string text, string assignedVoice, string npcName = "", string ttsInstructions = null)
	{
		try
		{
			if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(assignedVoice))
			{
				return null;
			}
			InitializeStaticVoices();
			string filteredText = RemoveAsteriskText(text);
			if (string.IsNullOrWhiteSpace(filteredText))
			{
				return null;
			}
			string baseUrl = GlobalSettings<ModSettings>.Instance?.Player2ApiUrl ?? "http://127.0.0.1:4315";
			string url = baseUrl + "/v1/tts/speak";
			float speed = GlobalSettings<ModSettings>.Instance?.TTSSpeed ?? 1f;
			VoiceInfo voiceInfo = await GetVoiceInfoAsync(assignedVoice);
			string voiceGender = voiceInfo?.Gender ?? "male";
			string voiceLanguage = ConvertLanguageToISO(voiceInfo?.Language ?? "en_US");
			JObject val = new JObject { ["text"] = JToken.op_Implicit(filteredText) };
			JArray val2 = new JArray();
			val2.Add(JToken.op_Implicit(assignedVoice));
			val["voice_ids"] = (JToken)val2;
			val["speed"] = JToken.op_Implicit(speed);
			val["play_in_app"] = JToken.op_Implicit(false);
			val["audio_format"] = JToken.op_Implicit("pcm");
			val["voice_gender"] = JToken.op_Implicit(voiceGender);
			val["voice_language"] = JToken.op_Implicit(voiceLanguage);
			JObject requestBody = val;
			if (!string.IsNullOrWhiteSpace(ttsInstructions))
			{
				requestBody["advanced_voice"] = (JToken)new JObject { ["instructions"] = JToken.op_Implicit(ttsInstructions) };
			}
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
			request.Content = (HttpContent)new StringContent(((JToken)requestBody).ToString((Formatting)0, Array.Empty<JsonConverter>()), Encoding.UTF8, "application/json");
			((HttpHeaders)request.Headers).Add("player2-game-key", "0199bcdd-3f9f-7a67-947e-ca10021b94ce");
			AIInfluenceBehavior.Instance?.LogMessage("[TTS] Requesting audio bytes for " + npcName + " (voice=" + assignedVoice + ")");
			HttpResponseMessage response = await httpClient.SendAsync(request);
			string body = await response.Content.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode)
			{
				AIInfluenceBehavior.Instance?.LogMessage($"[TTS_ERROR] Audio bytes request failed: HTTP {response.StatusCode} — {body}");
				return null;
			}
			string base64 = ((object)JObject.Parse(body)["data"])?.ToString();
			if (string.IsNullOrEmpty(base64))
			{
				AIInfluenceBehavior.Instance?.LogMessage("[TTS_ERROR] Response 'data' field is empty or missing");
				return null;
			}
			base64 = base64.Replace("\r", "").Replace("\n", "").Replace(" ", "")
				.Replace("\t", "")
				.Trim();
			int commaIdx = base64.IndexOf(',');
			if (commaIdx >= 0 && base64.IndexOf("base64", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				base64 = base64.Substring(commaIdx + 1);
			}
			byte[] audioBytes;
			try
			{
				audioBytes = Convert.FromBase64String(base64);
			}
			catch (FormatException)
			{
				AIInfluenceBehavior.Instance?.LogMessage("[TTS_ERROR] Invalid base64 in 'data'. First 80 chars: " + ((base64.Length > 80) ? (base64.Substring(0, 80) + "...") : base64));
				return null;
			}
			AIInfluenceBehavior.Instance?.LogMessage($"[TTS] Received {audioBytes.Length} bytes for {npcName}");
			return audioBytes;
		}
		catch (Exception ex2)
		{
			Exception ex3 = ex2;
			AIInfluenceBehavior.Instance?.LogMessage("[TTS_ERROR] GenerateTTSAudioBytesAsync: " + ex3.Message);
			return null;
		}
	}

	public static async Task<bool> GenerateAndPlayTTS(string text, string assignedVoice, string npcName = "", string ttsInstructions = null, string escalationState = "neutral")
	{
		try
		{
			if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(assignedVoice))
			{
				AIInfluenceBehavior.Instance?.LogMessage("[TTS] Skipping TTS: text or voice is empty (voice: " + assignedVoice + ")");
				return false;
			}
			InitializeStaticVoices();
			string binDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";
			string rhubarbPath = Path.Combine(binDir, "rhubarb.exe");
			if (File.Exists(rhubarbPath))
			{
				AIInfluenceBehavior.Instance?.LogMessage("[TTS] LipSync mode active (rhubarb.exe found). Routing to TtsLipSyncService.");
				return await TtsLipSyncService.PlayAsync(text, assignedVoice, npcName, ttsInstructions, escalationState);
			}
			string filteredText = RemoveAsteriskText(text);
			if (string.IsNullOrWhiteSpace(filteredText))
			{
				AIInfluenceBehavior.Instance?.LogMessage("[TTS] Skipping TTS: text is empty after filtering asterisks");
				return false;
			}
			string baseUrl = GlobalSettings<ModSettings>.Instance?.Player2ApiUrl ?? "http://127.0.0.1:4315";
			string url = baseUrl + "/v1/tts/speak";
			float speed = GlobalSettings<ModSettings>.Instance?.TTSSpeed ?? 1f;
			VoiceInfo voiceInfo = await GetVoiceInfoAsync(assignedVoice);
			string voiceGender = voiceInfo?.Gender ?? "male";
			string voiceLanguageRaw = voiceInfo?.Language ?? "en_US";
			string voiceLanguage = ConvertLanguageToISO(voiceLanguageRaw);
			JObject val = new JObject { ["text"] = JToken.op_Implicit(filteredText) };
			JArray val2 = new JArray();
			val2.Add(JToken.op_Implicit(assignedVoice));
			val["voice_ids"] = (JToken)val2;
			val["speed"] = JToken.op_Implicit(speed);
			val["play_in_app"] = JToken.op_Implicit(true);
			val["audio_format"] = JToken.op_Implicit("mp3");
			val["voice_gender"] = JToken.op_Implicit(voiceGender);
			val["voice_language"] = JToken.op_Implicit(voiceLanguage);
			JObject requestBody = val;
			if (!string.IsNullOrWhiteSpace(ttsInstructions))
			{
				requestBody["advanced_voice"] = (JToken)new JObject { ["instructions"] = JToken.op_Implicit(ttsInstructions) };
			}
			string json = ((JToken)requestBody).ToString((Formatting)0, Array.Empty<JsonConverter>());
			StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
			request.Content = (HttpContent)(object)content;
			((HttpHeaders)request.Headers).Add("player2-game-key", "0199bcdd-3f9f-7a67-947e-ca10021b94ce");
			AIInfluenceBehavior.Instance?.LogMessage($"[TTS] Generating TTS for {npcName} with voice {assignedVoice} (speed: {speed})");
			AIInfluenceBehavior.Instance?.LogMessage($"[TTS] Original text length: {text.Length}, Filtered text length: {filteredText.Length}");
			HttpResponseMessage response = await httpClient.SendAsync(request);
			string responseText = await response.Content.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode)
			{
				AIInfluenceBehavior.Instance?.LogMessage($"[TTS_ERROR] Failed to generate TTS: HTTP {response.StatusCode} - {responseText}");
				return false;
			}
			AIInfluenceBehavior.Instance?.LogMessage("[TTS] TTS request successful, audio playing in Player2 app for " + npcName);
			return true;
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			AIInfluenceBehavior.Instance?.LogMessage("[TTS_ERROR] Exception in GenerateAndPlayTTS: " + ex2.Message + "\n" + ex2.StackTrace);
			return false;
		}
	}
}
