using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using AIInfluence.API;
using Helpers;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;

namespace AIInfluence.Services;

public static class TtsLipSyncService
{
	private static readonly string _binDir;

	private static readonly string _ttsDir;

	private static readonly string _tempDir;

	private static readonly string _rhubarbExe;

	private static CancellationTokenSource _lipSyncCts;

	public static readonly ConcurrentQueue<Action> MainThreadQueue;

	private static readonly HashSet<string> _restrictedPoses;

	private static readonly string[] _friendlyActions;

	private static readonly string[] _hostileActions;

	private static readonly string[] _tenseActions;

	private static readonly string[] _friendlyFaces;

	private static readonly string[] _hostileFaces;

	private static readonly string[] _tenseFaces;

	private const float SkipAnimationChanceWhenNeutral = 0.35f;

	static TtsLipSyncService()
	{
		MainThreadQueue = new ConcurrentQueue<Action>();
		_restrictedPoses = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "naval", "sit", "sit_floor", "sit_throne", "horserider", "horse", "camel", "camelrider" };
		_friendlyActions = new string[8] { "normal", "normal2", "confident", "confident2", "demure", "demure2", "hip", "hip2" };
		_hostileActions = new string[6] { "aggressive", "aggressive2", "warrior", "warrior2", "closed", "closed2" };
		_tenseActions = new string[4] { "warrior", "warrior2", "closed", "closed2" };
		_friendlyFaces = new string[5] { "convo_normal", "convo_approving", "convo_excited", "convo_thinking", "convo_confused_normal" };
		_hostileFaces = new string[5] { "convo_predatory", "convo_furious", "convo_insulted", "convo_grave", "convo_bared_teeth" };
		_tenseFaces = new string[4] { "convo_grave", "convo_confused_annoyed", "convo_nervous", "convo_nervous2" };
		_binDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? AppDomain.CurrentDomain.BaseDirectory;
		_ttsDir = GetModuleDataTtsDir();
		_tempDir = Path.Combine(Path.GetTempPath(), "AIInfluence_tts");
		_rhubarbExe = ResolveRhubarbPath();
		Directory.CreateDirectory(_ttsDir);
		Directory.CreateDirectory(_tempDir);
		CleanOldTtsFiles();
	}

	private static string ResolveRhubarbPath()
	{
		string text = Path.Combine(_binDir, "rhubarb.exe");
		if (File.Exists(text))
		{
			return text;
		}
		string directoryName = Path.GetDirectoryName(_binDir);
		if (!string.IsNullOrEmpty(directoryName))
		{
			string text2 = Path.Combine(directoryName, "rhubarb.exe");
			if (File.Exists(text2))
			{
				return text2;
			}
		}
		return text;
	}

	private static string GetModuleDataTtsDir()
	{
		string text = _binDir;
		while (!string.IsNullOrEmpty(text))
		{
			string text2 = Path.Combine(text, "ModuleData");
			if (Directory.Exists(text2))
			{
				return Path.Combine(text2, "TTS");
			}
			text = Path.GetDirectoryName(text);
		}
		return Path.Combine(Path.GetTempPath(), "AIInfluence_tts");
	}

	public static async Task<TtsPreparedData> PrepareAsync(string text, string voiceId, string npcName, string ttsInstructions, string escalationState)
	{
		try
		{
			byte[] audioBytes = await Player2Client.GenerateTTSAudioBytesAsync(text, voiceId, npcName, ttsInstructions);
			if (audioBytes == null || audioBytes.Length == 0)
			{
				Log("[LipSync] Failed to get audio from Player2");
				return null;
			}
			string id = Guid.NewGuid().ToString("N").Substring(0, 8);
			string oggPath = Path.Combine(_ttsDir, "tts_" + id + ".ogg");
			string xmlPath = Path.Combine(_ttsDir, "tts_" + id + ".xml");
			if (!ConvertPcmToOgg(audioBytes, oggPath))
			{
				Log("[LipSync] PCM→OGG conversion failed.");
				return null;
			}
			Log("[LipSync] OGG saved → " + oggPath);
			bool useAnimations = GlobalSettings<ModSettings>.Instance?.EnableTTSAnimations ?? true;
			if (useAnimations)
			{
				string tempOgg = Path.Combine(_tempDir, "tts_" + id + ".ogg");
				string tempXml = Path.Combine(_tempDir, "tts_" + id + ".xml");
				try
				{
					File.Copy(oggPath, tempOgg, overwrite: true);
				}
				catch
				{
					tempOgg = oggPath;
					tempXml = xmlPath;
				}
				bool flag = File.Exists(_rhubarbExe);
				bool flag2 = flag;
				if (flag2)
				{
					flag2 = await RunRhubarbAsync(tempOgg, tempXml);
				}
				bool hasXml = flag2;
				if (hasXml && tempXml != xmlPath && File.Exists(tempXml))
				{
					try
					{
						File.Copy(tempXml, xmlPath, overwrite: true);
					}
					catch
					{
						hasXml = false;
					}
				}
				DeleteSafe(tempOgg);
				DeleteSafe(tempXml);
				if (!hasXml)
				{
					Log("[LipSync] No rhubarb.exe or failed — will play without lip-sync");
				}
			}
			else
			{
				Log("[LipSync] Animations disabled — TTS prepared for playback only");
			}
			string playPath = TryGetPathForNativeAudio(oggPath);
			Log("[LipSync] TTS prepared: " + playPath);
			return new TtsPreparedData
			{
				PlayPath = playPath,
				EscalationState = escalationState,
				UseAnimations = useAnimations,
				ResponseText = text,
				TtsInstructions = ttsInstructions
			};
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			Log("[LipSync] PrepareAsync: " + ex2.Message);
			return null;
		}
	}

	public static void PlayPrepared(TtsPreparedData data)
	{
		if (data == null || string.IsNullOrEmpty(data.PlayPath))
		{
			return;
		}
		MainThreadQueue.Enqueue(delegate
		{
			try
			{
				bool flag = data.UseAnimations;
				if (flag && IsNeutralEscalation(data.EscalationState) && MBRandom.RandomFloat < 0.35f)
				{
					flag = false;
				}
				string text = (flag ? GetContextAwareIdleAction(data.EscalationState) : string.Empty);
				string text2 = (flag ? IdleFaceForEscalation(data.EscalationState) : string.Empty);
				if (CampaignMission.Current != null)
				{
					CampaignMission.Current.OnConversationPlay(text, text2, string.Empty, string.Empty, data.PlayPath);
				}
				Log("[LipSync] PlayPrepared anim='" + text + "' face='" + text2 + "' sound=" + data.PlayPath);
			}
			catch (Exception ex)
			{
				Log("[LipSync] PlayPrepared error: " + ex.Message);
			}
		});
	}

	public static async Task<bool> PlayAsync(string text, string voiceId, string npcName, string ttsInstructions, string escalationState)
	{
		TtsPreparedData prepared = await PrepareAsync(text, voiceId, npcName, ttsInstructions, escalationState);
		if (prepared == null)
		{
			return false;
		}
		PlayPrepared(prepared);
		return true;
	}

	public static void StopCurrent()
	{
		_lipSyncCts?.Cancel();
		_lipSyncCts = null;
	}

	private static bool ConvertPcmToOgg(byte[] pcmBytes, string oggPath)
	{
		try
		{
			float gain = GlobalSettings<ModSettings>.Instance?.TTSVolume ?? 1.5f;
			byte[] array = OggEncoder.PcmToOgg(pcmBytes, 24000, 1, gain);
			if (array == null || array.Length == 0)
			{
				return false;
			}
			File.WriteAllBytes(oggPath, array);
			return true;
		}
		catch (Exception ex)
		{
			Log($"[LipSync] PCM→OGG: {ex.Message} (pcmLen={((pcmBytes != null) ? pcmBytes.Length : 0)})");
			return false;
		}
	}

	private static async Task<bool> RunRhubarbAsync(string audioPath, string xmlPath)
	{
		try
		{
			if (!File.Exists(_rhubarbExe))
			{
				Log("[LipSync] rhubarb.exe not found at " + _rhubarbExe);
				return false;
			}
			ProcessStartInfo psi = new ProcessStartInfo
			{
				FileName = _rhubarbExe,
				Arguments = "-o \"" + xmlPath + "\" -f xml -r phonetic --machineReadable \"" + audioPath + "\"",
				UseShellExecute = false,
				CreateNoWindow = true,
				RedirectStandardError = true
			};
			Process proc = Process.Start(psi);
			try
			{
				if (proc == null)
				{
					return false;
				}
				string stderr = await proc.StandardError.ReadToEndAsync();
				await Task.Run(() => proc.WaitForExit(30000));
				bool ok = proc.ExitCode == 0 && File.Exists(xmlPath);
				if (ok)
				{
					Log("[LipSync] Rhubarb OK");
				}
				else
				{
					Log(string.Format("[LipSync] Rhubarb failed (exit={0}){1}", proc.ExitCode, string.IsNullOrEmpty(stderr) ? "" : (": " + stderr.Trim())));
				}
				return ok;
			}
			finally
			{
				if (proc != null)
				{
					((IDisposable)proc).Dispose();
				}
			}
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			Log("[LipSync] Rhubarb: " + ex2.Message);
			return false;
		}
	}

	private static async Task DriveLipSyncFromXmlAsync(string xmlPath)
	{
		_lipSyncCts = new CancellationTokenSource();
		CancellationToken token = _lipSyncCts.Token;
		try
		{
			List<(double time, string shape)> cues = ParseRhubarbXml(xmlPath);
			if (cues.Count == 0)
			{
				return;
			}
			DateTime start = DateTime.UtcNow;
			foreach (var item in cues)
			{
				double timeSec = item.time;
				string shape = item.shape;
				if (token.IsCancellationRequested)
				{
					break;
				}
				double waitMs = (start.AddSeconds(timeSec) - DateTime.UtcNow).TotalMilliseconds;
				if (waitMs > 0.0)
				{
					await Task.Delay((int)Math.Min(waitMs, 500.0), token);
				}
				string faceAnim = RhubarbShapeToFaceAnim(shape);
				if (!string.IsNullOrEmpty(faceAnim))
				{
					MainThreadQueue.Enqueue(delegate
					{
						ApplyFaceAnim(faceAnim);
					});
				}
			}
		}
		catch (OperationCanceledException)
		{
		}
		catch (Exception ex2)
		{
			Exception ex3 = ex2;
			Log("[LipSync] DriveLipSync: " + ex3.Message);
		}
	}

	private static List<(double time, string shape)> ParseRhubarbXml(string path)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		List<(double, string)> list = new List<(double, string)>();
		try
		{
			XmlDocument val = new XmlDocument();
			val.Load(path);
			XmlNodeList val2 = ((XmlNode)val).SelectNodes("//mouthCue");
			if (val2 == null)
			{
				return list;
			}
			foreach (XmlNode item2 in val2)
			{
				XmlNode val3 = item2;
				XmlAttributeCollection attributes = val3.Attributes;
				object obj;
				if (attributes == null)
				{
					obj = null;
				}
				else
				{
					XmlAttribute obj2 = attributes["start"];
					obj = ((obj2 != null) ? ((XmlNode)obj2).Value : null);
				}
				if (obj == null)
				{
					obj = "0";
				}
				string s = (string)obj;
				XmlAttributeCollection attributes2 = val3.Attributes;
				object obj3;
				if (attributes2 == null)
				{
					obj3 = null;
				}
				else
				{
					XmlAttribute obj4 = attributes2["value"];
					obj3 = ((obj4 != null) ? ((XmlNode)obj4).Value : null);
				}
				if (obj3 == null)
				{
					obj3 = "X";
				}
				string item = (string)obj3;
				if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
				{
					list.Add((result, item));
				}
			}
		}
		catch
		{
		}
		return list;
	}

	private static string RhubarbShapeToFaceAnim(string shape)
	{
		switch (shape)
		{
		case "X":
			return "convo_normal";
		case "A":
			return "convo_normal";
		case "B":
			return "convo_undecided_closed";
		case "C":
		case "F":
			return "convo_thinking";
		case "D":
			return "convo_approving";
		case "E":
		case "H":
			return "convo_bared_teeth";
		case "G":
			return "convo_grave";
		default:
			return null;
		}
	}

	private static void ApplyFaceAnim(string faceAnim)
	{
		try
		{
			if (CampaignMission.Current != null)
			{
				CampaignMission.Current.OnConversationPlay(string.Empty, string.Empty, string.Empty, faceAnim, string.Empty);
			}
		}
		catch
		{
		}
	}

	private static string PickRandom(string[] arr)
	{
		return arr[(int)(MBRandom.RandomFloat * (float)arr.Length) % arr.Length];
	}

	private static string GetContextAwareIdleAction(string escalationState)
	{
		try
		{
			Hero oneToOneConversationHero = Hero.OneToOneConversationHero;
			if (oneToOneConversationHero == null)
			{
				return IdleActionForEscalation(escalationState);
			}
			CharacterObject characterObject = oneToOneConversationHero.CharacterObject;
			MobileParty partyBelongedTo = oneToOneConversationHero.PartyBelongedTo;
			PartyBase val = ((partyBelongedTo != null) ? partyBelongedTo.Party : null);
			string standingBodyIdle = CharacterHelper.GetStandingBodyIdle(characterObject, val);
			if (string.IsNullOrEmpty(standingBodyIdle))
			{
				return IdleActionForEscalation(escalationState);
			}
			if (_restrictedPoses.Contains(standingBodyIdle))
			{
				Campaign current = Campaign.Current;
				object obj;
				if (current == null)
				{
					obj = null;
				}
				else
				{
					ConversationManager conversationManager = current.ConversationManager;
					if (conversationManager == null)
					{
						obj = null;
					}
					else
					{
						ConversationAnimationManager conversationAnimationManager = conversationManager.ConversationAnimationManager;
						obj = ((conversationAnimationManager != null) ? conversationAnimationManager.ConversationAnims : null);
					}
				}
				Dictionary<string, ConversationAnimData> dictionary = (Dictionary<string, ConversationAnimData>)obj;
				if (dictionary != null && dictionary.ContainsKey(standingBodyIdle))
				{
					return standingBodyIdle;
				}
				return string.Empty;
			}
			return IdleActionForEscalation(escalationState);
		}
		catch
		{
			return IdleActionForEscalation(escalationState);
		}
	}

	private static bool IsNeutralEscalation(string state)
	{
		string text = state?.Trim().ToLowerInvariant();
		return string.IsNullOrEmpty(text) || text == "neutral";
	}

	private static string IdleActionForEscalation(string state)
	{
		string text = state?.ToLowerInvariant();
		if (text == "critical")
		{
			return PickRandom(_hostileActions);
		}
		if (text == "tense")
		{
			return PickRandom(_tenseActions);
		}
		return PickRandom(_friendlyActions);
	}

	private static string IdleFaceForEscalation(string state)
	{
		string text = state?.ToLowerInvariant();
		if (text == "critical")
		{
			return PickRandom(_hostileFaces);
		}
		if (text == "tense")
		{
			return PickRandom(_tenseFaces);
		}
		return PickRandom(_friendlyFaces);
	}

	private static async Task<bool> EnsureFileReadyAsync(string path, long expectedSize)
	{
		for (int i = 0; i < 10; i++)
		{
			if (File.Exists(path))
			{
				FileInfo fi = new FileInfo(path);
				if (fi.Length >= expectedSize)
				{
					return true;
				}
			}
			await Task.Delay(50).ConfigureAwait(continueOnCapturedContext: false);
		}
		return false;
	}

	private static string TryGetPathForNativeAudio(string path)
	{
		if (string.IsNullOrEmpty(path) || !File.Exists(path))
		{
			return path ?? "";
		}
		if (path.IndexOf('&') < 0)
		{
			return path;
		}
		try
		{
			int shortPathNameW = GetShortPathNameW(path, null, 0);
			if (shortPathNameW <= 0)
			{
				return path;
			}
			StringBuilder stringBuilder = new StringBuilder(shortPathNameW + 1);
			if (GetShortPathNameW(path, stringBuilder, stringBuilder.Capacity) > 0)
			{
				return stringBuilder.ToString();
			}
		}
		catch
		{
		}
		return path;
	}

	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern int GetShortPathNameW(string lpszLongPath, StringBuilder lpszShortPath, int cchBuffer);

	private static void DeleteSafe(string path)
	{
		if (string.IsNullOrEmpty(path))
		{
			return;
		}
		try
		{
			if (File.Exists(path))
			{
				File.Delete(path);
			}
		}
		catch
		{
		}
	}

	private static void CleanOldTtsFiles()
	{
		try
		{
			string[] files = Directory.GetFiles(_ttsDir, "tts_*.*");
			foreach (string text in files)
			{
				if ((DateTime.Now - new FileInfo(text).LastWriteTime).TotalMinutes > 30.0)
				{
					DeleteSafe(text);
				}
			}
		}
		catch
		{
		}
	}

	private static void Log(string msg)
	{
		AIInfluenceBehavior.Instance?.LogMessage(msg);
	}
}
