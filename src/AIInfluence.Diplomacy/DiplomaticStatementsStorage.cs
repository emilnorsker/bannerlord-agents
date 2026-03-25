using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using AIInfluence.DynamicEvents;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Diplomacy;

public class DiplomaticStatementsStorage
{
	private static DiplomaticStatementsStorage _instance;

	private List<KingdomStatement> _allStatements = new List<KingdomStatement>();

	private readonly string _saveDataPath;

	private readonly string _statementsFileName = "diplomatic_statements.json";

	private const int MAX_STATEMENTS_TO_SHOW = 15;

	public static DiplomaticStatementsStorage Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new DiplomaticStatementsStorage();
			}
			return _instance;
		}
	}

	private DiplomaticStatementsStorage()
	{
		string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
		_saveDataPath = Path.Combine(fullName, "save_data");
		if (!Directory.Exists(_saveDataPath))
		{
			Directory.CreateDirectory(_saveDataPath);
			DiplomacyLogger.Instance.Log("[DIPLO_STORAGE] Created save_data directory: " + _saveDataPath);
		}
		LoadStatements();
	}

	private string GetCurrentSaveFolder()
	{
		Campaign current = Campaign.Current;
		string path = ((current != null) ? current.UniqueGameId : null) ?? "default_save";
		string text = Path.Combine(_saveDataPath, path);
		DiplomacyLogger instance = DiplomacyLogger.Instance;
		Campaign current2 = Campaign.Current;
		instance.Log("[DIPLO_STORAGE] Current campaign UniqueGameId: " + (((current2 != null) ? current2.UniqueGameId : null) ?? "NULL"));
		DiplomacyLogger.Instance.Log("[DIPLO_STORAGE] Using save folder: " + text);
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
			DiplomacyLogger.Instance.Log("[DIPLO_STORAGE] Created save folder: " + text);
		}
		return text;
	}

	private string GetStatementsFilePath()
	{
		return Path.Combine(GetCurrentSaveFolder(), _statementsFileName);
	}

	public void AddStatement(KingdomStatement statement)
	{
		if (statement != null)
		{
			_allStatements.Add(statement);
			string text = ((statement.Actions != null && statement.Actions.Any()) ? string.Join(",", statement.Actions) : statement.Action.ToString());
			string text2 = ((statement.TargetKingdomIds != null && statement.TargetKingdomIds.Any()) ? string.Join(",", statement.TargetKingdomIds) : (statement.TargetKingdomId ?? "none"));
			DiplomacyLogger.Instance.Log("[DIPLO_STORAGE] Added statement to storage: " + statement.KingdomId + " -> " + text2 + ", action=" + text + ", eventId=" + statement.EventId);
			DiplomacyLogger.Instance.Log($"[DIPLO_STORAGE] Added statement from {statement.KingdomId}. Total statements: {_allStatements.Count}");
			CleanupOldStatements();
			SaveStatements();
		}
	}

	public void RemoveStatement(KingdomStatement statement)
	{
		if (statement != null && _allStatements.Remove(statement))
		{
			DiplomacyLogger.Instance.Log($"[DIPLO_STORAGE] Removed statement from {statement.KingdomId}. Total statements: {_allStatements.Count}");
			SaveStatements();
		}
	}

	public List<KingdomStatement> GetRecentStatements(int maxDays = -1, int maxCount = 15)
	{
		CleanupOldStatements();
		if (maxDays == -1)
		{
			maxDays = GlobalSettings<ModSettings>.Instance.DynamicEventsLifespan;
		}
		return (from s in _allStatements.Where(delegate(KingdomStatement s)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0019: Unknown result type (might be due to invalid IL or missing references)
				//IL_001e: Unknown result type (might be due to invalid IL or missing references)
				_ = CampaignTime.Now;
				if (s.CampaignDays > 0f)
				{
					CampaignTime now = CampaignTime.Now;
					float num = (float)(now).ToDays;
					int num2 = Math.Max(0, (int)(num - s.CampaignDays));
					return num2 <= maxDays;
				}
				return false;
			})
			orderby s.CampaignDays descending
			select s).Take(maxCount).ToList();
	}

	public List<KingdomStatement> GetStatementsForNPC(Hero npc)
	{
		if (npc == null || npc.Clan == null)
		{
			return new List<KingdomStatement>();
		}
		if (npc.Clan.Kingdom == null)
		{
			return GetRecentStatements().Where(delegate(KingdomStatement s)
			{
				if (s.Action != DiplomaticAction.None)
				{
					return true;
				}
				return !string.IsNullOrEmpty(s.EventId);
			}).ToList();
		}
		string npcKingdomId = ((MBObjectBase)npc.Clan.Kingdom).StringId;
		return GetRecentStatements().Where(delegate(KingdomStatement s)
		{
			if (s.KingdomId == npcKingdomId)
			{
				return true;
			}
			if (s.TargetKingdomId == npcKingdomId)
			{
				return true;
			}
			if (s.TargetKingdomIds != null && s.TargetKingdomIds.Contains(npcKingdomId))
			{
				return true;
			}
			if (!string.IsNullOrEmpty(s.EventId))
			{
				List<DynamicEvent> allEvents = DynamicEventsManager.Instance.GetAllEvents();
				DynamicEvent dynamicEvent = allEvents.FirstOrDefault((DynamicEvent e) => e.Id == s.EventId);
				if (dynamicEvent != null && dynamicEvent.ParticipatingKingdoms != null && dynamicEvent.ParticipatingKingdoms.Contains(npcKingdomId))
				{
					return true;
				}
			}
			return false;
		}).ToList();
	}

	private void CleanupOldStatements()
	{
		int count = _allStatements.Count;
		int maxAgeDays = GlobalSettings<ModSettings>.Instance.DynamicEventsLifespan;
		HashSet<string> expiredEventIds = new HashSet<string>();
		try
		{
			DynamicEventsManager instance = DynamicEventsManager.Instance;
			if (instance != null)
			{
				foreach (DynamicEvent item in instance.GetActiveEvents())
				{
					if (item != null && !string.IsNullOrEmpty(item.Id) && item.IsExpired())
					{
						expiredEventIds.Add(item.Id);
					}
				}
			}
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLO_STORAGE] Error checking expired events: " + ex.Message);
		}
		_allStatements.RemoveAll(delegate(KingdomStatement s)
		{
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			if (!string.IsNullOrEmpty(s.EventId) && expiredEventIds.Contains(s.EventId))
			{
				return true;
			}
			_ = CampaignTime.Now;
			if (s.CampaignDays > 0f)
			{
				CampaignTime now = CampaignTime.Now;
				float num2 = (float)(now).ToDays;
				int num3 = Math.Max(0, (int)(num2 - s.CampaignDays));
				return num3 > maxAgeDays;
			}
			return false;
		});
		int num = count - _allStatements.Count;
		if (num > 0)
		{
			DiplomacyLogger.Instance.Log($"[DIPLO_STORAGE] Cleaned up {num} old statements (older than {maxAgeDays} days or for expired events). Remaining: {_allStatements.Count}");
			SaveStatements();
		}
	}

	private void SaveStatements()
	{
		try
		{
			string statementsFilePath = GetStatementsFilePath();
			List<SerializableKingdomStatement> list = _allStatements.Select((KingdomStatement s) => new SerializableKingdomStatement
			{
				KingdomId = s.KingdomId,
				StatementText = s.StatementText,
				Action = s.Action.ToString(),
				Actions = s.Actions?.Select((DiplomaticAction a) => a.ToString()).ToList(),
				TargetKingdomId = s.TargetKingdomId,
				TargetKingdomIds = s.TargetKingdomIds,
				TargetClanId = s.TargetClanId,
				Reason = s.Reason,
				CampaignDays = s.CampaignDays,
				EventId = s.EventId,
				SettlementId = s.SettlementId,
				DailyTributeAmount = s.DailyTributeAmount,
				TributeDurationDays = s.TributeDurationDays,
				ReparationsAmount = s.ReparationsAmount,
				TradeAgreementDurationYears = s.TradeAgreementDurationYears
			}).ToList();
			string contents = JsonConvert.SerializeObject((object)list, (Formatting)1);
			File.WriteAllText(statementsFilePath, contents);
			DiplomacyLogger.Instance.Log($"[DIPLO_STORAGE] Saved {_allStatements.Count} statements to {statementsFilePath}");
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLO_STORAGE] ERROR saving statements: " + ex.Message);
		}
	}

	private void LoadStatements()
	{
		try
		{
			string statementsFilePath = GetStatementsFilePath();
			if (!File.Exists(statementsFilePath))
			{
				DiplomacyLogger.Instance.Log("[DIPLO_STORAGE] Storage file not found at " + statementsFilePath + ", starting fresh");
				_allStatements = new List<KingdomStatement>();
				return;
			}
			string text = File.ReadAllText(statementsFilePath);
			List<SerializableKingdomStatement> list = JsonConvert.DeserializeObject<List<SerializableKingdomStatement>>(text);
			_allStatements = new List<KingdomStatement>();
			if (list == null)
			{
				return;
			}
			foreach (SerializableKingdomStatement item2 in list)
			{
				DiplomaticAction result = DiplomaticAction.None;
				string value = item2.Action ?? "None";
				Enum.TryParse<DiplomaticAction>(value, out result);
				List<DiplomaticAction> list2 = new List<DiplomaticAction>();
				if (item2.Actions != null && item2.Actions.Any())
				{
					foreach (string action in item2.Actions)
					{
						if (Enum.TryParse<DiplomaticAction>(action, out var result2))
						{
							list2.Add(result2);
						}
					}
				}
				KingdomStatement item = new KingdomStatement
				{
					KingdomId = (item2.KingdomId ?? ""),
					StatementText = (item2.StatementText ?? ""),
					Action = result,
					Actions = (list2.Any() ? list2 : null),
					TargetKingdomId = item2.TargetKingdomId,
					TargetKingdomIds = (item2.TargetKingdomIds ?? new List<string>()),
					TargetClanId = item2.TargetClanId,
					Reason = (item2.Reason ?? ""),
					CampaignDays = item2.CampaignDays,
					EventId = (item2.EventId ?? ""),
					SettlementId = item2.SettlementId,
					DailyTributeAmount = item2.DailyTributeAmount,
					TributeDurationDays = item2.TributeDurationDays,
					ReparationsAmount = item2.ReparationsAmount,
					TradeAgreementDurationYears = item2.TradeAgreementDurationYears
				};
				_allStatements.Add(item);
			}
			DiplomacyLogger.Instance.Log($"[DIPLO_STORAGE] Loaded {_allStatements.Count} statements from storage");
			CleanupOldStatements();
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLO_STORAGE] ERROR loading statements: " + ex.Message);
			_allStatements = new List<KingdomStatement>();
		}
	}

	public List<KingdomStatement> GetAllStatements()
	{
		return _allStatements.ToList();
	}

	public List<KingdomStatement> GetStatementsByEventId(string eventId)
	{
		if (string.IsNullOrEmpty(eventId))
		{
			return new List<KingdomStatement>();
		}
		return _allStatements.Where((KingdomStatement s) => s.EventId == eventId).ToList();
	}

	public int RemoveStatementsByEventIds(List<string> eventIds)
	{
		if (eventIds == null || !eventIds.Any())
		{
			return 0;
		}
		int count = _allStatements.Count;
		HashSet<string> eventIdSet = new HashSet<string>(eventIds.Where((string id) => !string.IsNullOrEmpty(id)));
		_allStatements.RemoveAll((KingdomStatement s) => !string.IsNullOrEmpty(s.EventId) && eventIdSet.Contains(s.EventId));
		int num = count - _allStatements.Count;
		if (num > 0)
		{
			DiplomacyLogger.Instance.Log($"[DIPLO_STORAGE] Removed {num} statements for {eventIds.Count} expired events. Remaining: {_allStatements.Count}");
			SaveStatements();
		}
		return num;
	}

	public void ClearAllStatements()
	{
		try
		{
			_allStatements.Clear();
			string statementsFilePath = GetStatementsFilePath();
			if (File.Exists(statementsFilePath))
			{
				File.Delete(statementsFilePath);
				DiplomacyLogger.Instance.Log("[DIPLO_STORAGE] Cleared all statements and deleted file: " + Path.GetFileName(statementsFilePath));
			}
			else
			{
				DiplomacyLogger.Instance.Log("[DIPLO_STORAGE] Cleared all statements (no file to delete)");
			}
		}
		catch (Exception ex)
		{
			DiplomacyLogger.Instance.Log("[DIPLO_STORAGE] Error clearing statements: " + ex.Message);
		}
	}

	private void LogMessage(string message)
	{
		DiplomacyLogger.Instance.Log(message);
	}
}
