using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AIInfluence;
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
		int removedInvalid = envelope.Events.RemoveAll(e => e == null || string.IsNullOrEmpty(e?.Id));
		if (removedInvalid > 0)
		{
			LogMessage($"[DYNAMIC_EVENTS_STORAGE] Removed {removedInvalid} event(s) with null or empty Id from loaded envelope");
		}
		foreach (DynamicEvent e in envelope.Events)
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
				if (update == null)
				{
					continue;
				}
				string updateDescription = update.Description ?? "";
				if (!target.EventHistory.Any((EventUpdate u) => string.Equals(u?.Description ?? "", updateDescription, StringComparison.Ordinal) && Math.Abs(u.CampaignDays - update.CampaignDays) < 0.01f))
				{
					target.EventHistory.Add(update);
				}
			}
			target.EventHistory = target.EventHistory.Where(u => u != null).OrderByDescending((EventUpdate u) => u.CampaignDays).ToList();
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

	/// <returns><c>false</c> if the envelope was null or the file write failed (in-memory catalog unchanged on disk).</returns>
	public bool SaveUnifiedEnvelope(UnifiedDynamicEventsEnvelope envelope)
	{
		if (envelope == null)
		{
			LogMessage("[DYNAMIC_EVENTS_STORAGE] SaveUnifiedEnvelope: null envelope");
			return false;
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
			return true;
		}
		catch (Exception ex)
		{
			LogMessage("[DYNAMIC_EVENTS_STORAGE] Error saving unified envelope: " + ex.Message + "\n" + ex.StackTrace);
			return false;
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
		int skippedNullEvents = 0;
		int skippedEmptyIdEvents = 0;
		int duplicateEnvelopeIds = 0;
		foreach (DynamicEvent e in envelope.Events)
		{
			if (e == null)
			{
				skippedNullEvents++;
				continue;
			}
			if (string.IsNullOrEmpty(e.Id))
			{
				skippedEmptyIdEvents++;
				continue;
			}
			bool hasDiplo = HasTag(e, DynamicEventStorageTags.Diplomatic);
			bool hasDyn = HasTag(e, DynamicEventStorageTags.Dynamic);
			if (hasDiplo && !hasDyn && !dIds.Contains(e.Id))
			{
				continue;
			}
			if (byId.ContainsKey(e.Id))
			{
				duplicateEnvelopeIds++;
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
		if (skippedNullEvents > 0 || skippedEmptyIdEvents > 0 || duplicateEnvelopeIds > 0)
		{
			LogMessage($"[DYNAMIC_EVENTS_STORAGE] SaveDiplomaticSliceInto: dropped {skippedNullEvents} null, {skippedEmptyIdEvents} empty-id; duplicate Ids in envelope (last wins): {duplicateEnvelopeIds}");
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
		Dictionary<string, float> relativeDaysByEventId = new Dictionary<string, float>();
		int duplicateStatementScheduleKeys = 0;
		foreach (KeyValuePair<string, CampaignTime> pair in statementSchedules)
		{
			if (string.IsNullOrEmpty(pair.Key))
			{
				continue;
			}
			float relativeDays = (float)pair.Value.ToDays - currentCampaignDays;
			if (relativeDaysByEventId.ContainsKey(pair.Key))
			{
				duplicateStatementScheduleKeys++;
			}
			relativeDaysByEventId[pair.Key] = relativeDays;
		}
		if (duplicateStatementScheduleKeys > 0)
		{
			LogStorageStatic("[DYNAMIC_EVENTS_STORAGE] SerializeStatementSchedules: duplicate keys (last wins): " + duplicateStatementScheduleKeys);
		}
		return relativeDaysByEventId.Count == 0 ? null : relativeDaysByEventId;
	}

	private static Dictionary<string, float> SerializeAnalysisSchedules(Dictionary<string, CampaignTime> analysisSchedules)
	{
		if (analysisSchedules == null || !analysisSchedules.Any())
		{
			return null;
		}
		CampaignTime now = CampaignTime.Now;
		float currentCampaignDays = (float)now.ToDays;
		Dictionary<string, float> relativeDaysByEventId = new Dictionary<string, float>();
		int duplicateAnalysisScheduleKeys = 0;
		foreach (KeyValuePair<string, CampaignTime> pair in analysisSchedules)
		{
			if (string.IsNullOrEmpty(pair.Key))
			{
				continue;
			}
			float relativeDays = (float)pair.Value.ToDays - currentCampaignDays;
			if (relativeDaysByEventId.ContainsKey(pair.Key))
			{
				duplicateAnalysisScheduleKeys++;
			}
			relativeDaysByEventId[pair.Key] = relativeDays;
		}
		if (duplicateAnalysisScheduleKeys > 0)
		{
			LogStorageStatic("[DYNAMIC_EVENTS_STORAGE] SerializeAnalysisSchedules: duplicate keys (last wins): " + duplicateAnalysisScheduleKeys);
		}
		return relativeDaysByEventId.Count == 0 ? null : relativeDaysByEventId;
	}

	private static Dictionary<string, List<QueuedStatementData>> SerializeStatementQueues(Dictionary<string, Queue<(Kingdom kingdom, CampaignTime scheduledTime)>> statementQueues)
	{
		if (statementQueues == null || !statementQueues.Any())
		{
			return null;
		}
		CampaignTime now = CampaignTime.Now;
		float currentCampaignDays = (float)now.ToDays;
		Dictionary<string, List<QueuedStatementData>> serializedQueuesByEventId = new Dictionary<string, List<QueuedStatementData>>();
		int duplicateQueueKeys = 0;
		foreach (KeyValuePair<string, Queue<(Kingdom, CampaignTime)>> queueByEventId in statementQueues)
		{
			if (string.IsNullOrEmpty(queueByEventId.Key))
			{
				continue;
			}
			List<QueuedStatementData> serializedItems = new List<QueuedStatementData>();
			foreach ((Kingdom kingdom, CampaignTime scheduledTime) kingdomAndTime in queueByEventId.Value)
			{
				if (kingdomAndTime.kingdom == null)
				{
					continue;
				}
				QueuedStatementData row = new QueuedStatementData
				{
					KingdomId = ((MBObjectBase)kingdomAndTime.kingdom).StringId,
					ScheduledTimeDays = (float)kingdomAndTime.scheduledTime.ToDays - currentCampaignDays
				};
				serializedItems.Add(row);
			}
			if (serializedQueuesByEventId.ContainsKey(queueByEventId.Key))
			{
				duplicateQueueKeys++;
			}
			serializedQueuesByEventId[queueByEventId.Key] = serializedItems;
		}
		if (duplicateQueueKeys > 0)
		{
			LogStorageStatic("[DYNAMIC_EVENTS_STORAGE] SerializeStatementQueues: duplicate keys (last wins): " + duplicateQueueKeys);
		}
		return serializedQueuesByEventId.Count == 0 ? null : serializedQueuesByEventId;
	}

	private static Dictionary<string, string> SerializePendingStatements(Dictionary<string, Kingdom> pendingStatements)
	{
		if (pendingStatements == null || !pendingStatements.Any())
		{
			return null;
		}
		Dictionary<string, string> kingdomIdByStatementKey = new Dictionary<string, string>();
		int duplicatePendingKeys = 0;
		foreach (KeyValuePair<string, Kingdom> pair in pendingStatements)
		{
			if (string.IsNullOrEmpty(pair.Key) || pair.Value == null)
			{
				continue;
			}
			string kingdomStringId = ((MBObjectBase)pair.Value).StringId;
			if (kingdomIdByStatementKey.ContainsKey(pair.Key))
			{
				duplicatePendingKeys++;
			}
			kingdomIdByStatementKey[pair.Key] = kingdomStringId;
		}
		if (duplicatePendingKeys > 0)
		{
			LogStorageStatic("[DYNAMIC_EVENTS_STORAGE] SerializePendingStatements: duplicate keys (last wins): " + duplicatePendingKeys);
		}
		return kingdomIdByStatementKey.Count == 0 ? null : kingdomIdByStatementKey;
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
			float currentCampaignDays = (float)now.ToDays;
			float savedEnvelopeCampaignDays = envelope.CampaignDays;
			float daysDriftSinceSave = currentCampaignDays - savedEnvelopeCampaignDays;
			Dictionary<string, CampaignTime> restoredStatementSchedules = new Dictionary<string, CampaignTime>();
			if (envelope.StatementSchedules != null)
			{
				foreach (KeyValuePair<string, float> statementSchedule in envelope.StatementSchedules)
				{
					float adjustedStatementDays = statementSchedule.Value - daysDriftSinceSave;
					restoredStatementSchedules[statementSchedule.Key] = CampaignTime.DaysFromNow(adjustedStatementDays);
				}
			}
			Dictionary<string, CampaignTime> restoredAnalysisSchedules = new Dictionary<string, CampaignTime>();
			if (envelope.AnalysisSchedules != null)
			{
				foreach (KeyValuePair<string, float> analysisSchedule in envelope.AnalysisSchedules)
				{
					float adjustedAnalysisDays = analysisSchedule.Value - daysDriftSinceSave;
					restoredAnalysisSchedules[analysisSchedule.Key] = CampaignTime.DaysFromNow(adjustedAnalysisDays);
				}
			}
			Dictionary<string, Queue<(Kingdom, CampaignTime)>> restoredStatementQueues = new Dictionary<string, Queue<(Kingdom, CampaignTime)>>();
			if (envelope.StatementQueues != null)
			{
				foreach (KeyValuePair<string, List<QueuedStatementData>> statementQueue in envelope.StatementQueues)
				{
					Queue<(Kingdom, CampaignTime)> queue = new Queue<(Kingdom, CampaignTime)>();
					foreach (QueuedStatementData queuedStatement in statementQueue.Value ?? Enumerable.Empty<QueuedStatementData>())
					{
						Kingdom matchedKingdom = Kingdom.All.FirstOrDefault((Kingdom k) => ((MBObjectBase)k).StringId == queuedStatement.KingdomId);
						if (matchedKingdom != null)
						{
							float adjustedQueueItemDays = queuedStatement.ScheduledTimeDays - daysDriftSinceSave;
							CampaignTime restoredScheduledTime = CampaignTime.DaysFromNow(adjustedQueueItemDays);
							queue.Enqueue((matchedKingdom, restoredScheduledTime));
						}
					}
					if (queue.Count > 0)
					{
						restoredStatementQueues[statementQueue.Key] = queue;
					}
				}
			}
			Dictionary<string, Kingdom> restoredPendingStatements = new Dictionary<string, Kingdom>();
			if (envelope.PendingStatements != null)
			{
				foreach (KeyValuePair<string, string> pending in envelope.PendingStatements)
				{
					Kingdom pendingKingdom = Kingdom.All.FirstOrDefault((Kingdom k) => ((MBObjectBase)k).StringId == pending.Value);
					if (pendingKingdom != null)
					{
						restoredPendingStatements[pending.Key] = pendingKingdom;
					}
				}
			}
			return new DiplomaticEventsLoadResult
			{
				Events = diplomaticEvents,
				StatementSchedules = restoredStatementSchedules,
				AnalysisSchedules = restoredAnalysisSchedules,
				StatementQueues = restoredStatementQueues,
				PendingStatements = restoredPendingStatements
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
		LogStorageStatic(message);
	}

	private static void LogStorageStatic(string message)
	{
		AIInfluenceBehavior.Instance?.LogMessage(message);
	}
}
