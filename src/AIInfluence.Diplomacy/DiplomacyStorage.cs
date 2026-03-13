using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AIInfluence.DynamicEvents;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Diplomacy;

public class DiplomacyStorage
{
	private readonly string _saveDataPath;

	private readonly string _alliancesFileName = "alliances.json";

	private readonly string _warStatsFileName = "war_statistics.json";

	private readonly string _diplomaticEventsFileName = "diplomatic_events.json";

	private readonly string _pendingPlayerStatementsFileName = "pending_player_statements.json";

	private readonly string _tradeAgreementsFileName = "trade_agreements.json";

	private readonly string _territoryTransfersFileName = "territory_transfers.json";

	private readonly string _tributesFileName = "tributes.json";

	private readonly string _reparationsFileName = "reparations.json";

	private readonly string _expelledClansFileName = "expelled_clans.json";

	private string _cachedSaveFolder;

	private string _cachedUniqueGameId;

	public DiplomacyStorage()
	{
		string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
		_saveDataPath = Path.Combine(fullName, "save_data");
		if (!Directory.Exists(_saveDataPath))
		{
			Directory.CreateDirectory(_saveDataPath);
			LogMessage("[DIPLOMACY_STORAGE] Created save_data directory: " + _saveDataPath);
		}
	}

	private string GetCurrentSaveFolder()
	{
		Campaign current = Campaign.Current;
		string text = ((current != null) ? current.UniqueGameId : null) ?? "NULL";
		string path = ((text != "NULL") ? text : "default_save");
		string text2 = Path.Combine(_saveDataPath, path);
		if (_cachedUniqueGameId != text)
		{
			LogMessage("[DIPLOMACY_STORAGE] Current campaign UniqueGameId: " + text);
			LogMessage("[DIPLOMACY_STORAGE] Using save folder: " + text2);
			_cachedUniqueGameId = text;
			_cachedSaveFolder = text2;
		}
		if (!Directory.Exists(text2))
		{
			Directory.CreateDirectory(text2);
			LogMessage("[DIPLOMACY_STORAGE] Created save folder: " + text2);
		}
		return text2;
	}

	public void SaveAlliances(AllianceSystem allianceSystem)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		if (allianceSystem == null)
		{
			LogMessage("[DIPLOMACY_STORAGE] Attempted to save null alliance system");
			return;
		}
		try
		{
			string text = Path.Combine(GetCurrentSaveFolder(), _alliancesFileName);
			AllianceData obj = new AllianceData
			{
				Alliances = allianceSystem.Alliances,
				AllianceTimes = allianceSystem.AllianceTimes,
				SaveTime = DateTime.Now
			};
			CampaignTime now = CampaignTime.Now;
			double num = ((CampaignTime)(ref now)).ToYears * 336.0;
			now = CampaignTime.Now;
			obj.CampaignDays = (float)(num + (double)((CampaignTime)(ref now)).GetDayOfYear);
			AllianceData allianceData = obj;
			JsonSerializerSettings val = new JsonSerializerSettings
			{
				Formatting = (Formatting)1,
				NullValueHandling = (NullValueHandling)1
			};
			string contents = JsonConvert.SerializeObject((object)allianceData, val);
			File.WriteAllText(text, contents);
			LogMessage($"[DIPLOMACY_STORAGE] Saved {allianceSystem.Alliances.Count} alliance groups to {text}");
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_STORAGE] Error saving alliances: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	public void LoadAlliances(AllianceSystem allianceSystem)
	{
		if (allianceSystem == null)
		{
			LogMessage("[DIPLOMACY_STORAGE] Cannot load alliances: alliance system is null");
			return;
		}
		try
		{
			string text = Path.Combine(GetCurrentSaveFolder(), _alliancesFileName);
			if (!File.Exists(text))
			{
				LogMessage("[DIPLOMACY_STORAGE] No alliances file found at " + text);
				return;
			}
			string text2 = File.ReadAllText(text);
			if (string.IsNullOrWhiteSpace(text2))
			{
				LogMessage("[DIPLOMACY_STORAGE] Alliances file is empty");
				return;
			}
			AllianceData allianceData = JsonConvert.DeserializeObject<AllianceData>(text2);
			if (allianceData == null)
			{
				LogMessage("[DIPLOMACY_STORAGE] Failed to deserialize alliance data");
				return;
			}
			allianceSystem.Alliances = allianceData.Alliances ?? new Dictionary<string, List<string>>();
			allianceSystem.AllianceTimes = allianceData.AllianceTimes ?? new Dictionary<string, CampaignTime>();
			LogMessage($"[DIPLOMACY_STORAGE] Loaded {allianceSystem.Alliances.Count} alliance groups from {text}");
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_STORAGE] Error loading alliances: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	public void SaveWarStatistics(WarStatisticsTracker warTracker)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		if (warTracker == null)
		{
			LogMessage("[DIPLOMACY_STORAGE] Attempted to save null war tracker");
			return;
		}
		try
		{
			string text = Path.Combine(GetCurrentSaveFolder(), _warStatsFileName);
			WarStatisticsData obj = new WarStatisticsData
			{
				KingdomStats = warTracker.KingdomStats,
				SaveTime = DateTime.Now
			};
			CampaignTime now = CampaignTime.Now;
			double num = ((CampaignTime)(ref now)).ToYears * 336.0;
			now = CampaignTime.Now;
			obj.CampaignDays = (float)(num + (double)((CampaignTime)(ref now)).GetDayOfYear);
			WarStatisticsData warStatisticsData = obj;
			JsonSerializerSettings val = new JsonSerializerSettings
			{
				Formatting = (Formatting)1,
				NullValueHandling = (NullValueHandling)1
			};
			string contents = JsonConvert.SerializeObject((object)warStatisticsData, val);
			File.WriteAllText(text, contents);
			LogMessage($"[DIPLOMACY_STORAGE] Saved war statistics for {warTracker.KingdomStats.Count} kingdoms to {text}");
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_STORAGE] Error saving war statistics: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	public void LoadWarStatistics(WarStatisticsTracker warTracker)
	{
		if (warTracker == null)
		{
			LogMessage("[DIPLOMACY_STORAGE] Cannot load war statistics: war tracker is null");
			return;
		}
		try
		{
			string text = Path.Combine(GetCurrentSaveFolder(), _warStatsFileName);
			if (!File.Exists(text))
			{
				LogMessage("[DIPLOMACY_STORAGE] No war statistics file found at " + text);
				return;
			}
			string text2 = File.ReadAllText(text);
			if (string.IsNullOrWhiteSpace(text2))
			{
				LogMessage("[DIPLOMACY_STORAGE] War statistics file is empty");
				return;
			}
			WarStatisticsData warStatisticsData = JsonConvert.DeserializeObject<WarStatisticsData>(text2);
			if (warStatisticsData == null)
			{
				LogMessage("[DIPLOMACY_STORAGE] Failed to deserialize war statistics data");
				return;
			}
			warTracker.KingdomStats = warStatisticsData.KingdomStats ?? new Dictionary<string, KingdomWarStats>();
			LogMessage($"[DIPLOMACY_STORAGE] Loaded war statistics for {warTracker.KingdomStats.Count} kingdoms from {text}");
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_STORAGE] Error loading war statistics: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	public void SaveDiplomaticEvents(List<DynamicEvent> diplomaticEvents)
	{
		SaveDiplomaticEvents(diplomaticEvents, null, null, null, null);
	}

	public void SaveDiplomaticEvents(List<DynamicEvent> diplomaticEvents, Dictionary<string, CampaignTime> statementSchedules, Dictionary<string, CampaignTime> analysisSchedules, Dictionary<string, Queue<(Kingdom kingdom, CampaignTime scheduledTime)>> statementQueues, Dictionary<string, Kingdom> pendingStatements)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Unknown result type (might be due to invalid IL or missing references)
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Expected O, but got Unknown
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		if (diplomaticEvents == null)
		{
			LogMessage("[DIPLOMACY_STORAGE] Attempted to save null diplomatic events list");
			return;
		}
		try
		{
			string text = Path.Combine(GetCurrentSaveFolder(), _diplomaticEventsFileName);
			CampaignTime val = CampaignTime.Now;
			float currentCampaignDays = (float)((CampaignTime)(ref val)).ToDays;
			Dictionary<string, float> statementSchedules2 = null;
			if (statementSchedules != null)
			{
				statementSchedules2 = statementSchedules.ToDictionary((KeyValuePair<string, CampaignTime> kvp) => kvp.Key, delegate(KeyValuePair<string, CampaignTime> kvp)
				{
					//IL_0002: Unknown result type (might be due to invalid IL or missing references)
					//IL_0007: Unknown result type (might be due to invalid IL or missing references)
					CampaignTime value = kvp.Value;
					return (float)((CampaignTime)(ref value)).ToDays - currentCampaignDays;
				});
			}
			Dictionary<string, float> analysisSchedules2 = null;
			if (analysisSchedules != null)
			{
				analysisSchedules2 = analysisSchedules.ToDictionary((KeyValuePair<string, CampaignTime> kvp) => kvp.Key, delegate(KeyValuePair<string, CampaignTime> kvp)
				{
					//IL_0002: Unknown result type (might be due to invalid IL or missing references)
					//IL_0007: Unknown result type (might be due to invalid IL or missing references)
					CampaignTime value = kvp.Value;
					return (float)((CampaignTime)(ref value)).ToDays - currentCampaignDays;
				});
			}
			Dictionary<string, List<QueuedStatementData>> dictionary = null;
			if (statementQueues != null)
			{
				dictionary = new Dictionary<string, List<QueuedStatementData>>();
				foreach (KeyValuePair<string, Queue<(Kingdom, CampaignTime)>> statementQueue in statementQueues)
				{
					List<QueuedStatementData> list = new List<QueuedStatementData>();
					foreach (var item in statementQueue.Value)
					{
						QueuedStatementData obj = new QueuedStatementData
						{
							KingdomId = ((MBObjectBase)item.Item1).StringId
						};
						val = item.Item2;
						obj.ScheduledTimeDays = (float)((CampaignTime)(ref val)).ToDays - currentCampaignDays;
						list.Add(obj);
					}
					dictionary[statementQueue.Key] = list;
				}
			}
			Dictionary<string, string> pendingStatements2 = null;
			if (pendingStatements != null)
			{
				pendingStatements2 = pendingStatements.ToDictionary((KeyValuePair<string, Kingdom> kvp) => kvp.Key, (KeyValuePair<string, Kingdom> kvp) => ((MBObjectBase)kvp.Value).StringId);
			}
			DiplomaticEventsData obj2 = new DiplomaticEventsData
			{
				DiplomaticEvents = diplomaticEvents,
				SaveTime = DateTime.Now
			};
			val = CampaignTime.Now;
			obj2.CampaignDays = (float)((CampaignTime)(ref val)).ToDays;
			obj2.StatementSchedules = statementSchedules2;
			obj2.AnalysisSchedules = analysisSchedules2;
			obj2.StatementQueues = dictionary;
			obj2.PendingStatements = pendingStatements2;
			DiplomaticEventsData diplomaticEventsData = obj2;
			JsonSerializerSettings val2 = new JsonSerializerSettings
			{
				Formatting = (Formatting)1,
				NullValueHandling = (NullValueHandling)1
			};
			string contents = JsonConvert.SerializeObject((object)diplomaticEventsData, val2);
			File.WriteAllText(text, contents);
			LogMessage($"[DIPLOMACY_STORAGE] Saved {diplomaticEvents.Count} diplomatic events to {text}");
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_STORAGE] Error saving diplomatic events: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	public List<DynamicEvent> LoadDiplomaticEvents()
	{
		DiplomaticEventsLoadResult diplomaticEventsLoadResult = LoadDiplomaticEventsWithSchedules();
		return diplomaticEventsLoadResult.Events;
	}

	public DiplomaticEventsLoadResult LoadDiplomaticEventsWithSchedules()
	{
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			string text = Path.Combine(GetCurrentSaveFolder(), _diplomaticEventsFileName);
			if (!File.Exists(text))
			{
				LogMessage("[DIPLOMACY_STORAGE] No diplomatic events file found at " + text);
				return new DiplomaticEventsLoadResult
				{
					Events = new List<DynamicEvent>(),
					StatementSchedules = new Dictionary<string, CampaignTime>(),
					AnalysisSchedules = new Dictionary<string, CampaignTime>(),
					StatementQueues = new Dictionary<string, Queue<(Kingdom, CampaignTime)>>(),
					PendingStatements = new Dictionary<string, Kingdom>()
				};
			}
			string text2 = File.ReadAllText(text);
			if (string.IsNullOrWhiteSpace(text2))
			{
				LogMessage("[DIPLOMACY_STORAGE] Diplomatic events file is empty");
				return new DiplomaticEventsLoadResult
				{
					Events = new List<DynamicEvent>(),
					StatementSchedules = new Dictionary<string, CampaignTime>(),
					AnalysisSchedules = new Dictionary<string, CampaignTime>(),
					StatementQueues = new Dictionary<string, Queue<(Kingdom, CampaignTime)>>(),
					PendingStatements = new Dictionary<string, Kingdom>()
				};
			}
			DiplomaticEventsData diplomaticEventsData = JsonConvert.DeserializeObject<DiplomaticEventsData>(text2);
			if (diplomaticEventsData == null)
			{
				LogMessage("[DIPLOMACY_STORAGE] Failed to deserialize diplomatic events data");
				return new DiplomaticEventsLoadResult
				{
					Events = new List<DynamicEvent>(),
					StatementSchedules = new Dictionary<string, CampaignTime>(),
					AnalysisSchedules = new Dictionary<string, CampaignTime>(),
					StatementQueues = new Dictionary<string, Queue<(Kingdom, CampaignTime)>>(),
					PendingStatements = new Dictionary<string, Kingdom>()
				};
			}
			CampaignTime now = CampaignTime.Now;
			float num = (float)((CampaignTime)(ref now)).ToDays;
			float campaignDays = diplomaticEventsData.CampaignDays;
			float num2 = num - campaignDays;
			Dictionary<string, CampaignTime> dictionary = new Dictionary<string, CampaignTime>();
			if (diplomaticEventsData.StatementSchedules != null)
			{
				foreach (KeyValuePair<string, float> statementSchedule in diplomaticEventsData.StatementSchedules)
				{
					float num3 = statementSchedule.Value - num2;
					dictionary[statementSchedule.Key] = CampaignTime.DaysFromNow(num3);
				}
			}
			Dictionary<string, CampaignTime> dictionary2 = new Dictionary<string, CampaignTime>();
			if (diplomaticEventsData.AnalysisSchedules != null)
			{
				foreach (KeyValuePair<string, float> analysisSchedule in diplomaticEventsData.AnalysisSchedules)
				{
					float num4 = analysisSchedule.Value - num2;
					dictionary2[analysisSchedule.Key] = CampaignTime.DaysFromNow(num4);
				}
			}
			Dictionary<string, Queue<(Kingdom, CampaignTime)>> dictionary3 = new Dictionary<string, Queue<(Kingdom, CampaignTime)>>();
			if (diplomaticEventsData.StatementQueues != null)
			{
				foreach (KeyValuePair<string, List<QueuedStatementData>> statementQueue in diplomaticEventsData.StatementQueues)
				{
					Queue<(Kingdom, CampaignTime)> queue = new Queue<(Kingdom, CampaignTime)>();
					foreach (QueuedStatementData item in statementQueue.Value)
					{
						Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == item.KingdomId));
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
			if (diplomaticEventsData.PendingStatements != null)
			{
				foreach (KeyValuePair<string, string> pending in diplomaticEventsData.PendingStatements)
				{
					Kingdom val2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == pending.Value));
					if (val2 != null)
					{
						dictionary4[pending.Key] = val2;
					}
				}
			}
			LogMessage($"[DIPLOMACY_STORAGE] Loaded {diplomaticEventsData.DiplomaticEvents.Count} diplomatic events from {text}");
			if (dictionary.Count > 0)
			{
				LogMessage($"[DIPLOMACY_STORAGE] Restored {dictionary.Count} statement schedules");
			}
			if (dictionary2.Count > 0)
			{
				LogMessage($"[DIPLOMACY_STORAGE] Restored {dictionary2.Count} analysis schedules");
			}
			if (dictionary3.Count > 0)
			{
				LogMessage($"[DIPLOMACY_STORAGE] Restored {dictionary3.Count} statement queues");
			}
			return new DiplomaticEventsLoadResult
			{
				Events = (diplomaticEventsData.DiplomaticEvents ?? new List<DynamicEvent>()),
				StatementSchedules = dictionary,
				AnalysisSchedules = dictionary2,
				StatementQueues = dictionary3,
				PendingStatements = dictionary4
			};
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_STORAGE] Error loading diplomatic events: " + ex.Message + "\n" + ex.StackTrace);
			return new DiplomaticEventsLoadResult
			{
				Events = new List<DynamicEvent>(),
				StatementSchedules = new Dictionary<string, CampaignTime>(),
				AnalysisSchedules = new Dictionary<string, CampaignTime>(),
				StatementQueues = new Dictionary<string, Queue<(Kingdom, CampaignTime)>>(),
				PendingStatements = new Dictionary<string, Kingdom>()
			};
		}
	}

	public void SavePendingPlayerStatements(List<DelayedPlayerStatement> statements)
	{
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		if (statements == null)
		{
			LogMessage("[DIPLOMACY_STORAGE] Attempted to save null pending statements list");
			return;
		}
		try
		{
			string path = Path.Combine(GetCurrentSaveFolder(), _pendingPlayerStatementsFileName);
			List<SerializedPlayerStatement> list = (from s in statements
				select SerializedPlayerStatement.FromDelayed(s) into s
				where s != null
				select s).ToList();
			LogMessage($"[DIPLOMACY_STORAGE] Converting {statements.Count} statements to serialized format");
			foreach (DelayedPlayerStatement statement in statements)
			{
				Kingdom playerKingdom = statement.PlayerKingdom;
				LogMessage($"[DIPLOMACY_STORAGE] Saving statement: Kingdom={((playerKingdom != null) ? playerKingdom.Name : null)}, Action={statement.Action}, PublicationTime={statement.PublicationTime}");
			}
			string text = JsonConvert.SerializeObject((object)list, (Formatting)1);
			LogMessage($"[DIPLOMACY_STORAGE] Generated JSON (length: {text.Length}): {text}");
			File.WriteAllText(path, text);
			LogMessage($"[DIPLOMACY_STORAGE] Saved {list.Count} pending player statements to {_pendingPlayerStatementsFileName}");
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_STORAGE] Error saving pending player statements: " + ex.Message);
			DiplomacyLogger.Instance.LogError("DiplomacyStorage.SavePendingPlayerStatements", "Failed to save pending player statements", ex);
		}
	}

	public List<DelayedPlayerStatement> LoadPendingPlayerStatements()
	{
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			string text = Path.Combine(GetCurrentSaveFolder(), _pendingPlayerStatementsFileName);
			if (!File.Exists(text))
			{
				LogMessage("[DIPLOMACY_STORAGE] No pending player statements file found at " + text);
				return new List<DelayedPlayerStatement>();
			}
			string text2 = File.ReadAllText(text);
			LogMessage($"[DIPLOMACY_STORAGE] Read JSON from file (length: {text2.Length}): {text2}");
			List<SerializedPlayerStatement> list = JsonConvert.DeserializeObject<List<SerializedPlayerStatement>>(text2);
			LogMessage($"[DIPLOMACY_STORAGE] Deserialized {list?.Count ?? 0} serialized statements");
			if (list == null || !list.Any())
			{
				LogMessage("[DIPLOMACY_STORAGE] No serialized statements found");
				return new List<DelayedPlayerStatement>();
			}
			List<DelayedPlayerStatement> list2 = (from s in list
				select s.ToDelayed() into s
				where s != null
				select s).ToList();
			LogMessage($"[DIPLOMACY_STORAGE] Loaded {list2.Count} pending player statements from {_pendingPlayerStatementsFileName}");
			foreach (DelayedPlayerStatement item in list2)
			{
				Kingdom playerKingdom = item.PlayerKingdom;
				LogMessage($"[DIPLOMACY_STORAGE] Loaded statement: Kingdom={((playerKingdom != null) ? playerKingdom.Name : null)}, Action={item.Action}, PublicationTime={item.PublicationTime}");
			}
			return list2;
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_STORAGE] Error loading pending player statements: " + ex.Message + "\n" + ex.StackTrace);
			return new List<DelayedPlayerStatement>();
		}
	}

	public void DeleteDiplomacyFiles()
	{
		try
		{
			string currentSaveFolder = GetCurrentSaveFolder();
			string[] array = new string[4]
			{
				Path.Combine(currentSaveFolder, _alliancesFileName),
				Path.Combine(currentSaveFolder, _warStatsFileName),
				Path.Combine(currentSaveFolder, _diplomaticEventsFileName),
				Path.Combine(currentSaveFolder, _pendingPlayerStatementsFileName)
			};
			string[] array2 = array;
			foreach (string path in array2)
			{
				if (File.Exists(path))
				{
					File.Delete(path);
					LogMessage("[DIPLOMACY_STORAGE] Deleted file: " + Path.GetFileName(path));
				}
			}
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_STORAGE] Error deleting diplomacy files: " + ex.Message);
		}
	}

	public bool DiplomacyFilesExist()
	{
		string currentSaveFolder = GetCurrentSaveFolder();
		return File.Exists(Path.Combine(currentSaveFolder, _alliancesFileName)) || File.Exists(Path.Combine(currentSaveFolder, _warStatsFileName)) || File.Exists(Path.Combine(currentSaveFolder, _diplomaticEventsFileName)) || File.Exists(Path.Combine(currentSaveFolder, _pendingPlayerStatementsFileName));
	}

	public void ClearCurrentSaveData()
	{
		try
		{
			string currentSaveFolder = GetCurrentSaveFolder();
			LogMessage("[DIPLOMACY_STORAGE] Clearing all diplomacy data for current save: " + currentSaveFolder);
			string[] array = new string[10]
			{
				Path.Combine(currentSaveFolder, _alliancesFileName),
				Path.Combine(currentSaveFolder, _warStatsFileName),
				Path.Combine(currentSaveFolder, _diplomaticEventsFileName),
				Path.Combine(currentSaveFolder, _pendingPlayerStatementsFileName),
				Path.Combine(currentSaveFolder, "diplomatic_statements.json"),
				Path.Combine(currentSaveFolder, _tradeAgreementsFileName),
				Path.Combine(currentSaveFolder, _territoryTransfersFileName),
				Path.Combine(currentSaveFolder, _tributesFileName),
				Path.Combine(currentSaveFolder, _reparationsFileName),
				Path.Combine(currentSaveFolder, _expelledClansFileName)
			};
			string[] array2 = array;
			foreach (string path in array2)
			{
				if (File.Exists(path))
				{
					File.Delete(path);
					LogMessage("[DIPLOMACY_STORAGE] Deleted file: " + Path.GetFileName(path));
				}
			}
			LogMessage("[DIPLOMACY_STORAGE] All diplomacy data cleared for current save");
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_STORAGE] Error clearing diplomacy data: " + ex.Message);
		}
	}

	public void SaveTradeAgreements(TradeAgreementSystem system)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		if (system == null)
		{
			return;
		}
		try
		{
			string path = Path.Combine(GetCurrentSaveFolder(), _tradeAgreementsFileName);
			JsonSerializerSettings val = new JsonSerializerSettings
			{
				Formatting = (Formatting)1,
				NullValueHandling = (NullValueHandling)1
			};
			string contents = JsonConvert.SerializeObject((object)system.TradeAgreements, val);
			File.WriteAllText(path, contents);
			LogMessage($"[DIPLOMACY_STORAGE] Saved {system.TradeAgreements.Count} trade agreements");
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_STORAGE] ERROR saving trade agreements: " + ex.Message);
		}
	}

	public void LoadTradeAgreements(TradeAgreementSystem system)
	{
		if (system == null)
		{
			return;
		}
		try
		{
			string path = Path.Combine(GetCurrentSaveFolder(), _tradeAgreementsFileName);
			if (File.Exists(path))
			{
				string text = File.ReadAllText(path);
				if (!string.IsNullOrWhiteSpace(text))
				{
					Dictionary<string, TradeAgreementInfo> dictionary = JsonConvert.DeserializeObject<Dictionary<string, TradeAgreementInfo>>(text);
					if (dictionary != null)
					{
						system.TradeAgreements = dictionary;
						LogMessage($"[DIPLOMACY_STORAGE] Loaded {dictionary.Count} trade agreements");
					}
					else
					{
						LogMessage("[DIPLOMACY_STORAGE] Trade agreements file is empty or invalid, starting with empty dictionary");
						system.TradeAgreements.Clear();
					}
				}
				else
				{
					LogMessage("[DIPLOMACY_STORAGE] Trade agreements file is empty, starting with empty dictionary");
					system.TradeAgreements.Clear();
				}
			}
			else
			{
				LogMessage("[DIPLOMACY_STORAGE] Trade agreements file does not exist, starting with empty dictionary");
			}
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_STORAGE] ERROR loading trade agreements: " + ex.Message);
		}
	}

	public void SaveTerritoryTransfers(TerritoryTransferSystem system)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		if (system == null)
		{
			return;
		}
		try
		{
			string path = Path.Combine(GetCurrentSaveFolder(), _territoryTransfersFileName);
			JsonSerializerSettings val = new JsonSerializerSettings
			{
				Formatting = (Formatting)1,
				NullValueHandling = (NullValueHandling)1
			};
			string contents = JsonConvert.SerializeObject((object)system.TransferHistory, val);
			File.WriteAllText(path, contents);
			LogMessage($"[DIPLOMACY_STORAGE] Saved {system.TransferHistory.Count} territory transfer records");
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_STORAGE] ERROR saving territory transfers: " + ex.Message);
		}
	}

	public void LoadTerritoryTransfers(TerritoryTransferSystem system)
	{
		if (system == null)
		{
			return;
		}
		try
		{
			string path = Path.Combine(GetCurrentSaveFolder(), _territoryTransfersFileName);
			if (File.Exists(path))
			{
				string text = File.ReadAllText(path);
				List<TerritoryTransferRecord> list = JsonConvert.DeserializeObject<List<TerritoryTransferRecord>>(text);
				if (list != null)
				{
					system.TransferHistory = list;
					LogMessage($"[DIPLOMACY_STORAGE] Loaded {list.Count} territory transfer records");
				}
			}
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_STORAGE] ERROR loading territory transfers: " + ex.Message);
		}
	}

	public void SaveTributes(TributeSystem system)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		if (system == null)
		{
			return;
		}
		try
		{
			string path = Path.Combine(GetCurrentSaveFolder(), _tributesFileName);
			JsonSerializerSettings val = new JsonSerializerSettings
			{
				Formatting = (Formatting)1,
				NullValueHandling = (NullValueHandling)1
			};
			var anon = new
			{
				tributes = system.Tributes,
				tribute_history = system.TributeHistory
			};
			string contents = JsonConvert.SerializeObject((object)anon, val);
			File.WriteAllText(path, contents);
			LogMessage($"[DIPLOMACY_STORAGE] Saved {system.Tributes.Count} tribute agreements and {system.TributeHistory.Count} historical records");
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_STORAGE] ERROR saving tributes: " + ex.Message);
		}
	}

	public void LoadTributes(TributeSystem system)
	{
		if (system == null)
		{
			return;
		}
		try
		{
			string path = Path.Combine(GetCurrentSaveFolder(), _tributesFileName);
			if (!File.Exists(path))
			{
				return;
			}
			string text = File.ReadAllText(path);
			try
			{
				dynamic val = JsonConvert.DeserializeObject<object>(text);
				if (val != null)
				{
					if (val.tributes != null)
					{
						system.Tributes = JsonConvert.DeserializeObject<Dictionary<string, TributeAgreement>>(val.tributes.ToString());
					}
					if (val.tribute_history != null)
					{
						system.TributeHistory = JsonConvert.DeserializeObject<List<TributeRecord>>(val.tribute_history.ToString());
					}
					LogMessage($"[DIPLOMACY_STORAGE] Loaded {system.Tributes.Count} tribute agreements and {system.TributeHistory.Count} historical records");
					return;
				}
			}
			catch
			{
			}
			Dictionary<string, TributeAgreement> dictionary = JsonConvert.DeserializeObject<Dictionary<string, TributeAgreement>>(text);
			if (dictionary != null)
			{
				system.Tributes = dictionary;
				LogMessage($"[DIPLOMACY_STORAGE] Loaded {dictionary.Count} tribute agreements (old format, no history)");
			}
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_STORAGE] ERROR loading tributes: " + ex.Message);
		}
	}

	public void SaveReparations(ReparationsSystem system)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		if (system == null)
		{
			return;
		}
		try
		{
			string path = Path.Combine(GetCurrentSaveFolder(), _reparationsFileName);
			ReparationsData reparationsData = new ReparationsData
			{
				history = system.ReparationsHistory,
				pending_demands = system.PendingDemands
			};
			JsonSerializerSettings val = new JsonSerializerSettings
			{
				Formatting = (Formatting)1,
				NullValueHandling = (NullValueHandling)1
			};
			string contents = JsonConvert.SerializeObject((object)reparationsData, val);
			File.WriteAllText(path, contents);
			LogMessage($"[DIPLOMACY_STORAGE] Saved {system.ReparationsHistory.Count} reparation records and {system.PendingDemands.Count} pending demands");
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_STORAGE] ERROR saving reparations: " + ex.Message);
		}
	}

	public void LoadReparations(ReparationsSystem system)
	{
		if (system == null)
		{
			return;
		}
		try
		{
			string path = Path.Combine(GetCurrentSaveFolder(), _reparationsFileName);
			if (!File.Exists(path))
			{
				return;
			}
			string text = File.ReadAllText(path);
			ReparationsData reparationsData = JsonConvert.DeserializeObject<ReparationsData>(text);
			if (reparationsData != null)
			{
				if (reparationsData.history != null)
				{
					system.ReparationsHistory = reparationsData.history;
				}
				if (reparationsData.pending_demands != null)
				{
					system.PendingDemands = reparationsData.pending_demands;
				}
				LogMessage($"[DIPLOMACY_STORAGE] Loaded {system.ReparationsHistory.Count} reparation records and {system.PendingDemands.Count} pending demands");
			}
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_STORAGE] ERROR loading reparations: " + ex.Message);
		}
	}

	public void SaveExpelledClans(Dictionary<string, List<ExpulsionRecord>> expelledClans)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		if (expelledClans == null)
		{
			return;
		}
		try
		{
			string path = Path.Combine(GetCurrentSaveFolder(), _expelledClansFileName);
			JsonSerializerSettings val = new JsonSerializerSettings
			{
				Formatting = (Formatting)1,
				NullValueHandling = (NullValueHandling)1
			};
			string contents = JsonConvert.SerializeObject((object)expelledClans, val);
			File.WriteAllText(path, contents);
			LogMessage($"[DIPLOMACY_STORAGE] Saved expelled clans records for {expelledClans.Count} kingdoms");
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_STORAGE] ERROR saving expelled clans: " + ex.Message);
		}
	}

	public Dictionary<string, List<ExpulsionRecord>> LoadExpelledClans()
	{
		try
		{
			string path = Path.Combine(GetCurrentSaveFolder(), _expelledClansFileName);
			if (File.Exists(path))
			{
				string text = File.ReadAllText(path);
				Dictionary<string, List<ExpulsionRecord>> dictionary = JsonConvert.DeserializeObject<Dictionary<string, List<ExpulsionRecord>>>(text);
				if (dictionary != null)
				{
					int num = dictionary.Sum((KeyValuePair<string, List<ExpulsionRecord>> kv) => kv.Value.Count);
					LogMessage($"[DIPLOMACY_STORAGE] Loaded {num} expulsion records for {dictionary.Count} kingdoms");
					return dictionary;
				}
			}
		}
		catch (Exception ex)
		{
			LogMessage("[DIPLOMACY_STORAGE] ERROR loading expelled clans: " + ex.Message);
		}
		return new Dictionary<string, List<ExpulsionRecord>>();
	}

	private void LogMessage(string message)
	{
		DiplomacyLogger.Instance?.Log(message);
	}
}
