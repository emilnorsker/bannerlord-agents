using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AIInfluence.Diplomacy;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.DynamicEvents;

public class DynamicEventsStorage
{
	private readonly string _saveDataPath;

	private readonly string _eventsFileName = "dynamic_events.json";

	public DynamicEventsStorage()
	{
		string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
		_saveDataPath = Path.Combine(fullName, "save_data");
		if (!Directory.Exists(_saveDataPath))
		{
			Directory.CreateDirectory(_saveDataPath);
			LogMessage("[DYNAMIC_EVENTS_STORAGE] Created save_data directory: " + _saveDataPath);
		}
	}

	private string GetCurrentSaveFolder()
	{
		Campaign current = Campaign.Current;
		string path = ((current != null) ? current.UniqueGameId : null) ?? "default_save";
		string text = Path.Combine(_saveDataPath, path);
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
			LogMessage("[DYNAMIC_EVENTS_STORAGE] Created save folder: " + text);
		}
		return text;
	}

	private string GetEventsFilePath() => Path.Combine(GetCurrentSaveFolder(), _eventsFileName);

	private static void EnsureTag(DynamicEvent e, string tag)
	{
		if (e == null || string.IsNullOrEmpty(tag))
		{
			return;
		}
		if (e.StorageTags == null)
		{
			e.StorageTags = new List<string>();
		}
		if (!e.StorageTags.Contains(tag))
		{
			e.StorageTags.Add(tag);
		}
	}

	private static bool HasTag(DynamicEvent e, string tag)
	{
		return e?.StorageTags != null && e.StorageTags.Contains(tag);
	}

	/// <summary>Load unified envelope (v2). Pre-v5 shapes (bare array, separate diplomatic file, format_version 1) are not loaded — starts empty.</summary>
	public UnifiedDynamicEventsEnvelope LoadUnifiedEnvelope()
	{
		string path = GetEventsFilePath();
		if (!File.Exists(path))
		{
			return NewEmptyEnvelope();
		}
		string text = File.ReadAllText(path);
		if (string.IsNullOrWhiteSpace(text))
		{
			LogMessage("[DYNAMIC_EVENTS_STORAGE] Events file is empty");
			return NewEmptyEnvelope();
		}
		JToken root;
		try
		{
			root = JToken.Parse(text);
		}
		catch (Exception ex)
		{
			LogMessage("[DYNAMIC_EVENTS_STORAGE] Invalid JSON in dynamic_events.json: " + ex.Message);
			return NewEmptyEnvelope();
		}
		if (root is JArray)
		{
			LogMessage("[DYNAMIC_EVENTS_STORAGE] Ignoring pre-v5 bare-array dynamic_events.json (not save-compatible); using empty catalog");
			return NewEmptyEnvelope();
		}
		UnifiedDynamicEventsEnvelope envelope = root.ToObject<UnifiedDynamicEventsEnvelope>();
		if (envelope == null || envelope.Events == null)
		{
			LogMessage("[DYNAMIC_EVENTS_STORAGE] Failed to deserialize unified envelope");
			return NewEmptyEnvelope();
		}
		if (envelope.FormatVersion != UnifiedDynamicEventsEnvelope.CurrentFormatVersion)
		{
			LogMessage($"[DYNAMIC_EVENTS_STORAGE] Unsupported format_version {envelope.FormatVersion} (expected {UnifiedDynamicEventsEnvelope.CurrentFormatVersion}); using empty catalog");
			return NewEmptyEnvelope();
		}
		foreach (DynamicEvent e in envelope.Events.Where(e => e != null))
		{
			if (e.StorageTags == null || !e.StorageTags.Any())
			{
				EnsureTag(e, DynamicEventStorageTags.Dynamic);
			}
		}
		LogMessage($"[DYNAMIC_EVENTS_STORAGE] Loaded {envelope.Events.Count} events from unified {path}");
		return envelope;
	}

	private static void MergeDiplomaticIntoExisting(DynamicEvent target, DynamicEvent source)
	{
		if (target == null || source == null)
		{
			return;
		}
		if (!string.IsNullOrWhiteSpace(source.Description))
		{
			target.Description = source.Description;
		}
		if (source.ParticipatingKingdoms != null && source.ParticipatingKingdoms.Any())
		{
			target.ParticipatingKingdoms = new List<string>(source.ParticipatingKingdoms);
		}
		if (source.EventHistory != null && source.EventHistory.Any())
		{
			if (target.EventHistory == null)
			{
				target.EventHistory = new List<EventUpdate>();
			}
			foreach (EventUpdate update in source.EventHistory)
			{
				if (!target.EventHistory.Any((EventUpdate u) => u.Description == update.Description && Math.Abs(u.CampaignDays - update.CampaignDays) < 0.01f))
				{
					target.EventHistory.Add(update);
				}
			}
			target.EventHistory = target.EventHistory.OrderByDescending((EventUpdate u) => u.CampaignDays).ToList();
		}
	}

	private static UnifiedDynamicEventsEnvelope NewEmptyEnvelope()
	{
		CampaignTime now = CampaignTime.Now;
		return new UnifiedDynamicEventsEnvelope
		{
			FormatVersion = UnifiedDynamicEventsEnvelope.CurrentFormatVersion,
			Events = new List<DynamicEvent>(),
			SaveTime = DateTime.Now,
			CampaignDays = (float)now.ToDays
		};
	}

	public void SaveUnifiedEnvelope(UnifiedDynamicEventsEnvelope envelope)
	{
		if (envelope == null)
		{
			LogMessage("[DYNAMIC_EVENTS_STORAGE] SaveUnifiedEnvelope: null envelope");
			return;
		}
		envelope.FormatVersion = UnifiedDynamicEventsEnvelope.CurrentFormatVersion;
		CampaignTime now = CampaignTime.Now;
		envelope.CampaignDays = (float)now.ToDays;
		envelope.SaveTime = DateTime.Now;
		try
		{
			string path = GetEventsFilePath();
			JsonSerializerSettings settings = new JsonSerializerSettings
			{
				Formatting = Formatting.Indented,
				NullValueHandling = NullValueHandling.Ignore
			};
			string contents = JsonConvert.SerializeObject(envelope, settings);
			File.WriteAllText(path, contents);
			LogMessage($"[DYNAMIC_EVENTS_STORAGE] Saved {envelope.Events?.Count ?? 0} events to unified {path}");
		}
		catch (Exception ex)
		{
			LogMessage("[DYNAMIC_EVENTS_STORAGE] Error saving unified envelope: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	/// <summary>Merge diplomatic slice into an existing envelope and persist (single file).</summary>
	public void SaveDiplomaticSliceInto(UnifiedDynamicEventsEnvelope envelope, List<DynamicEvent> diplomaticEvents, Dictionary<string, CampaignTime> statementSchedules, Dictionary<string, CampaignTime> analysisSchedules, Dictionary<string, Queue<(Kingdom kingdom, CampaignTime scheduledTime)>> statementQueues, Dictionary<string, Kingdom> pendingStatements)
	{
		if (diplomaticEvents == null)
		{
			LogMessage("[DYNAMIC_EVENTS_STORAGE] SaveDiplomaticSliceInto: null list");
			return;
		}
		if (envelope == null)
		{
			LogMessage("[DYNAMIC_EVENTS_STORAGE] SaveDiplomaticSliceInto: null envelope");
			return;
		}
		if (envelope.Events == null)
		{
			envelope.Events = new List<DynamicEvent>();
		}
		HashSet<string> dIds = new HashSet<string>(diplomaticEvents.Where(e => e != null && !string.IsNullOrEmpty(e.Id)).Select(e => e.Id));
		Dictionary<string, DynamicEvent> byId = new Dictionary<string, DynamicEvent>();
		foreach (DynamicEvent e in envelope.Events)
		{
			if (e == null || string.IsNullOrEmpty(e.Id))
			{
				continue;
			}
			bool hasDiplo = HasTag(e, DynamicEventStorageTags.Diplomatic);
			bool hasDyn = HasTag(e, DynamicEventStorageTags.Dynamic);
			if (hasDiplo && !hasDyn && !dIds.Contains(e.Id))
			{
				continue;
			}
			byId[e.Id] = e;
		}
		foreach (DynamicEvent d in diplomaticEvents.Where(x => x != null && !string.IsNullOrEmpty(x.Id)))
		{
			if (byId.TryGetValue(d.Id, out DynamicEvent existing))
			{
				MergeDiplomaticIntoExisting(existing, d);
				EnsureTag(existing, DynamicEventStorageTags.Diplomatic);
			}
			else
			{
				EnsureTag(d, DynamicEventStorageTags.Diplomatic);
				byId[d.Id] = d;
			}
		}
		envelope.Events = byId.Values.ToList();
		envelope.StatementSchedules = SerializeStatementSchedules(statementSchedules);
		envelope.AnalysisSchedules = SerializeAnalysisSchedules(analysisSchedules);
		envelope.StatementQueues = SerializeStatementQueues(statementQueues);
		envelope.PendingStatements = SerializePendingStatements(pendingStatements);
		SaveUnifiedEnvelope(envelope);
	}

	private static Dictionary<string, float> SerializeStatementSchedules(Dictionary<string, CampaignTime> statementSchedules)
	{
		if (statementSchedules == null || !statementSchedules.Any())
		{
			return null;
		}
		CampaignTime now = CampaignTime.Now;
		float currentCampaignDays = (float)now.ToDays;
		return statementSchedules.ToDictionary(kvp => kvp.Key, kvp => (float)kvp.Value.ToDays - currentCampaignDays);
	}

	private static Dictionary<string, float> SerializeAnalysisSchedules(Dictionary<string, CampaignTime> analysisSchedules)
	{
		if (analysisSchedules == null || !analysisSchedules.Any())
		{
			return null;
		}
		CampaignTime now = CampaignTime.Now;
		float currentCampaignDays = (float)now.ToDays;
		return analysisSchedules.ToDictionary(kvp => kvp.Key, kvp => (float)kvp.Value.ToDays - currentCampaignDays);
	}

	private static Dictionary<string, List<QueuedStatementData>> SerializeStatementQueues(Dictionary<string, Queue<(Kingdom kingdom, CampaignTime scheduledTime)>> statementQueues)
	{
		if (statementQueues == null || !statementQueues.Any())
		{
			return null;
		}
		CampaignTime now = CampaignTime.Now;
		float currentCampaignDays = (float)now.ToDays;
		Dictionary<string, List<QueuedStatementData>> dictionary = new Dictionary<string, List<QueuedStatementData>>();
		foreach (KeyValuePair<string, Queue<(Kingdom, CampaignTime)>> statementQueue in statementQueues)
		{
			List<QueuedStatementData> list = new List<QueuedStatementData>();
			foreach (var item in statementQueue.Value)
			{
				QueuedStatementData obj = new QueuedStatementData
				{
					KingdomId = ((MBObjectBase)item.Item1).StringId,
					ScheduledTimeDays = (float)item.Item2.ToDays - currentCampaignDays
				};
				list.Add(obj);
			}
			dictionary[statementQueue.Key] = list;
		}
		return dictionary;
	}

	private static Dictionary<string, string> SerializePendingStatements(Dictionary<string, Kingdom> pendingStatements)
	{
		if (pendingStatements == null || !pendingStatements.Any())
		{
			return null;
		}
		return pendingStatements.ToDictionary(kvp => kvp.Key, kvp => ((MBObjectBase)kvp.Value).StringId);
	}

	public DiplomaticEventsLoadResult LoadDiplomaticSliceFromEnvelope(UnifiedDynamicEventsEnvelope envelope)
	{
		if (envelope == null)
		{
			return EmptyDiplomaticResult();
		}
		List<DynamicEvent> diplomatic = (envelope.Events ?? new List<DynamicEvent>()).Where(e => e != null && HasTag(e, DynamicEventStorageTags.Diplomatic)).ToList();
		return BuildLoadResultFromEnvelope(envelope, diplomatic);
	}

	private DiplomaticEventsLoadResult BuildLoadResultFromEnvelope(UnifiedDynamicEventsEnvelope envelope, List<DynamicEvent> diplomaticEvents)
	{
		try
		{
			CampaignTime now = CampaignTime.Now;
			float num = (float)now.ToDays;
			float campaignDays = envelope.CampaignDays;
			float num2 = num - campaignDays;
			Dictionary<string, CampaignTime> dictionary = new Dictionary<string, CampaignTime>();
			if (envelope.StatementSchedules != null)
			{
				foreach (KeyValuePair<string, float> statementSchedule in envelope.StatementSchedules)
				{
					float num3 = statementSchedule.Value - num2;
					dictionary[statementSchedule.Key] = CampaignTime.DaysFromNow(num3);
				}
			}
			Dictionary<string, CampaignTime> dictionary2 = new Dictionary<string, CampaignTime>();
			if (envelope.AnalysisSchedules != null)
			{
				foreach (KeyValuePair<string, float> analysisSchedule in envelope.AnalysisSchedules)
				{
					float num4 = analysisSchedule.Value - num2;
					dictionary2[analysisSchedule.Key] = CampaignTime.DaysFromNow(num4);
				}
			}
			Dictionary<string, Queue<(Kingdom, CampaignTime)>> dictionary3 = new Dictionary<string, Queue<(Kingdom, CampaignTime)>>();
			if (envelope.StatementQueues != null)
			{
				foreach (KeyValuePair<string, List<QueuedStatementData>> statementQueue in envelope.StatementQueues)
				{
					Queue<(Kingdom, CampaignTime)> queue = new Queue<(Kingdom, CampaignTime)>();
					foreach (QueuedStatementData item in statementQueue.Value ?? Enumerable.Empty<QueuedStatementData>())
					{
						Kingdom val = Kingdom.All.FirstOrDefault((Kingdom k) => ((MBObjectBase)k).StringId == item.KingdomId);
						if (val != null)
						{
							float num5 = item.ScheduledTimeDays - num2;
							CampaignTime item2 = CampaignTime.DaysFromNow(num5);
							queue.Enqueue((val, item2));
						}
					}
					if (queue.Count > 0)
					{
						dictionary3[statementQueue.Key] = queue;
					}
				}
			}
			Dictionary<string, Kingdom> dictionary4 = new Dictionary<string, Kingdom>();
			if (envelope.PendingStatements != null)
			{
				foreach (KeyValuePair<string, string> pending in envelope.PendingStatements)
				{
					Kingdom val2 = Kingdom.All.FirstOrDefault((Kingdom k) => ((MBObjectBase)k).StringId == pending.Value);
					if (val2 != null)
					{
						dictionary4[pending.Key] = val2;
					}
				}
			}
			return new DiplomaticEventsLoadResult
			{
				Events = diplomaticEvents,
				StatementSchedules = dictionary,
				AnalysisSchedules = dictionary2,
				StatementQueues = dictionary3,
				PendingStatements = dictionary4
			};
		}
		catch (Exception ex)
		{
			LogMessage("[DYNAMIC_EVENTS_STORAGE] BuildLoadResultFromEnvelope failed: " + ex.Message);
			return EmptyDiplomaticResult();
		}
	}

	private static DiplomaticEventsLoadResult EmptyDiplomaticResult()
	{
		return new DiplomaticEventsLoadResult
		{
			Events = new List<DynamicEvent>(),
			StatementSchedules = new Dictionary<string, CampaignTime>(),
			AnalysisSchedules = new Dictionary<string, CampaignTime>(),
			StatementQueues = new Dictionary<string, Queue<(Kingdom, CampaignTime)>>(),
			PendingStatements = new Dictionary<string, Kingdom>()
		};
	}

	public void DeleteEventsFile()
	{
		try
		{
			string eventsFilePath = GetEventsFilePath();
			if (File.Exists(eventsFilePath))
			{
				File.Delete(eventsFilePath);
				LogMessage("[DYNAMIC_EVENTS_STORAGE] Deleted events file: " + eventsFilePath);
			}
		}
		catch (Exception ex)
		{
			LogMessage("[DYNAMIC_EVENTS_STORAGE] Error deleting events file: " + ex.Message);
		}
	}

	public bool EventsFileExists()
	{
		return File.Exists(GetEventsFilePath());
	}

	private void LogMessage(string message)
	{
		AIInfluenceBehavior.Instance?.LogMessage(message);
	}
}
