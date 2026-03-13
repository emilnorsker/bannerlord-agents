using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.ObjectSystem;

namespace AIInfluence;

public class KingdomLeadershipTracker
{
	private static KingdomLeadershipTracker _instance;

	private Dictionary<string, KingdomLeadershipHistory> _leadershipHistory = new Dictionary<string, KingdomLeadershipHistory>();

	private bool _isInitialized = false;

	private DateTime _lastLoadTime = DateTime.MinValue;

	public static KingdomLeadershipTracker Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new KingdomLeadershipTracker();
			}
			return _instance;
		}
	}

	private KingdomLeadershipTracker()
	{
	}

	public void RegisterEvents()
	{
		CampaignEvents.RulingClanChanged.AddNonSerializedListener((object)this, (Action<Kingdom, Clan>)OnRulingClanChanged);
	}

	public void SaveData()
	{
		try
		{
			KingdomLeadershipTrackerData kingdomLeadershipTrackerData = new KingdomLeadershipTrackerData
			{
				leadershipHistory = _leadershipHistory,
				isInitialized = _isInitialized
			};
			string contents = JsonConvert.SerializeObject((object)kingdomLeadershipTrackerData, (Formatting)1);
			string saveFilePath = GetSaveFilePath();
			Directory.CreateDirectory(Path.GetDirectoryName(saveFilePath));
			File.WriteAllText(saveFilePath, contents);
			_lastLoadTime = File.GetLastWriteTime(saveFilePath);
			AIInfluenceBehavior.Instance?.LogMessage("[LEADERSHIP_TRACKER] Data saved to " + saveFilePath);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[LEADERSHIP_TRACKER] Error saving data: " + ex.Message);
		}
	}

	public void LoadData()
	{
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			string saveFilePath = GetSaveFilePath();
			if (File.Exists(saveFilePath))
			{
				string text = File.ReadAllText(saveFilePath);
				KingdomLeadershipTrackerData kingdomLeadershipTrackerData = JsonConvert.DeserializeObject<KingdomLeadershipTrackerData>(text);
				if (kingdomLeadershipTrackerData == null)
				{
					return;
				}
				_leadershipHistory = kingdomLeadershipTrackerData.leadershipHistory ?? new Dictionary<string, KingdomLeadershipHistory>();
				_isInitialized = kingdomLeadershipTrackerData.isInitialized;
				foreach (KingdomLeadershipHistory value in _leadershipHistory.Values)
				{
					if (value.LeadershipChanges == null)
					{
						continue;
					}
					foreach (LeadershipChange leadershipChange in value.LeadershipChanges)
					{
						leadershipChange.ChangeDate = CampaignTime.Now;
					}
				}
				_lastLoadTime = File.GetLastWriteTime(saveFilePath);
				AIInfluenceBehavior.Instance?.LogMessage($"[LEADERSHIP_TRACKER] Data loaded from {saveFilePath}. Histories: {_leadershipHistory.Count}, Initialized: {_isInitialized}");
			}
			else
			{
				_isInitialized = false;
				_leadershipHistory.Clear();
				_lastLoadTime = DateTime.MinValue;
				AIInfluenceBehavior.Instance?.LogMessage("[LEADERSHIP_TRACKER] No save file found at " + saveFilePath + ". Will initialize on first use.");
			}
		}
		catch (Exception ex)
		{
			_isInitialized = false;
			_leadershipHistory.Clear();
			_lastLoadTime = DateTime.MinValue;
			AIInfluenceBehavior.Instance?.LogMessage("[LEADERSHIP_TRACKER] Error loading data: " + ex.Message + ". Will initialize on first use.");
		}
	}

	public void ReloadData()
	{
		AIInfluenceBehavior.Instance?.LogMessage("[LEADERSHIP_TRACKER] Reloading data from file...");
		LoadData();
	}

	private bool IsFileModified()
	{
		try
		{
			string saveFilePath = GetSaveFilePath();
			if (File.Exists(saveFilePath))
			{
				DateTime lastWriteTime = File.GetLastWriteTime(saveFilePath);
				return lastWriteTime > _lastLoadTime;
			}
		}
		catch
		{
		}
		return false;
	}

	private string GetCurrentSaveFolder()
	{
		string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		string fullName = Directory.GetParent(Directory.GetParent(directoryName).FullName).FullName;
		string path = Path.Combine(fullName, "save_data");
		Campaign current = Campaign.Current;
		string path2 = ((current != null) ? current.UniqueGameId : null) ?? "default_save";
		string text = Path.Combine(path, path2);
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
			AIInfluenceBehavior.Instance?.LogMessage("[LEADERSHIP_TRACKER] Created save folder: " + text);
		}
		return text;
	}

	private string GetSaveFilePath()
	{
		return Path.Combine(GetCurrentSaveFolder(), "kingdom_leadership_history.json");
	}

	public void InitializeStartingLeaders()
	{
		if (_isInitialized)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[LEADERSHIP_TRACKER] System already initialized, skipping initialization");
			return;
		}
		_leadershipHistory.Clear();
		foreach (Kingdom item in (List<Kingdom>)(object)Kingdom.All)
		{
			Clan rulingClan = item.RulingClan;
			if (((rulingClan != null) ? rulingClan.Leader : null) != null)
			{
				KingdomLeadershipHistory value = new KingdomLeadershipHistory
				{
					KingdomId = ((MBObjectBase)item).StringId,
					KingdomName = ((object)item.Name).ToString(),
					CurrentLeaderId = ((MBObjectBase)item.RulingClan.Leader).StringId,
					CurrentLeaderName = ((object)item.RulingClan.Leader.Name).ToString(),
					CurrentLeaderClanId = ((MBObjectBase)item.RulingClan).StringId,
					CurrentLeaderClanName = ((object)item.RulingClan.Name).ToString(),
					LeadershipChanges = new List<LeadershipChange>()
				};
				_leadershipHistory[((MBObjectBase)item).StringId] = value;
			}
		}
		_isInitialized = true;
		AIInfluenceBehavior.Instance?.LogMessage($"[LEADERSHIP_TRACKER] Initialized leadership for {_leadershipHistory.Count} kingdoms");
	}

	private void OnRulingClanChanged(Kingdom kingdom, Clan newRulingClan)
	{
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		if (((newRulingClan != null) ? newRulingClan.Leader : null) == null)
		{
			return;
		}
		string stringId = ((MBObjectBase)kingdom).StringId;
		Hero leader = newRulingClan.Leader;
		if (!_leadershipHistory.ContainsKey(stringId))
		{
			_leadershipHistory[stringId] = new KingdomLeadershipHistory
			{
				KingdomId = stringId,
				KingdomName = ((object)kingdom.Name).ToString(),
				CurrentLeaderId = ((MBObjectBase)leader).StringId,
				CurrentLeaderName = ((object)leader.Name).ToString(),
				CurrentLeaderClanId = ((MBObjectBase)newRulingClan).StringId,
				CurrentLeaderClanName = ((object)newRulingClan.Name).ToString(),
				LeadershipChanges = new List<LeadershipChange>()
			};
		}
		else
		{
			KingdomLeadershipHistory kingdomLeadershipHistory = _leadershipHistory[stringId];
			if (kingdomLeadershipHistory.CurrentLeaderId == ((MBObjectBase)leader).StringId)
			{
				AIInfluenceBehavior.Instance?.LogMessage($"[LEADERSHIP_TRACKER] Skipping duplicate change: {leader.Name} is already the leader");
				return;
			}
			(string reason, Hero killer) tuple = DetermineChangeReasonAndKiller(kingdomLeadershipHistory.CurrentLeaderId);
			string item = tuple.reason;
			Hero item2 = tuple.killer;
			LeadershipChange leadershipChange = new LeadershipChange
			{
				PreviousLeaderId = kingdomLeadershipHistory.CurrentLeaderId,
				PreviousLeaderName = kingdomLeadershipHistory.CurrentLeaderName,
				PreviousLeaderClanId = kingdomLeadershipHistory.CurrentLeaderClanId,
				PreviousLeaderClanName = kingdomLeadershipHistory.CurrentLeaderClanName,
				NewLeaderId = ((MBObjectBase)leader).StringId,
				NewLeaderName = ((object)leader.Name).ToString(),
				NewLeaderClanId = ((MBObjectBase)newRulingClan).StringId,
				NewLeaderClanName = ((object)newRulingClan.Name).ToString(),
				ChangeDate = CampaignTime.Now,
				ChangeReason = item,
				KillerId = ((item2 != null) ? ((MBObjectBase)item2).StringId : null),
				KillerName = ((item2 == null) ? null : ((object)item2.Name)?.ToString())
			};
			leadershipChange.UpdateChangeDateString();
			kingdomLeadershipHistory.LeadershipChanges.Add(leadershipChange);
			kingdomLeadershipHistory.CurrentLeaderId = ((MBObjectBase)leader).StringId;
			kingdomLeadershipHistory.CurrentLeaderName = ((object)leader.Name).ToString();
			kingdomLeadershipHistory.CurrentLeaderClanId = ((MBObjectBase)newRulingClan).StringId;
			kingdomLeadershipHistory.CurrentLeaderClanName = ((object)newRulingClan.Name).ToString();
		}
		AIInfluenceBehavior.Instance?.LogMessage($"[LEADERSHIP_TRACKER] {kingdom.Name}: New leader {leader.Name}");
		SaveData();
	}

	private (string reason, Hero killer) DetermineChangeReasonAndKiller(string previousLeaderId)
	{
		Hero val = ((IEnumerable<Hero>)Hero.AllAliveHeroes).FirstOrDefault((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == previousLeaderId));
		if (val == null)
		{
			val = ((IEnumerable<Hero>)Hero.DeadOrDisabledHeroes).FirstOrDefault((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == previousLeaderId));
			if (val != null)
			{
				WorldInfoManager.DeathRecord deathRecordForHero = WorldInfoManager.Instance.GetDeathRecordForHero(val);
				if (deathRecordForHero != null)
				{
					return (reason: "death", killer: deathRecordForHero.Killer);
				}
				return (reason: "death", killer: null);
			}
			return (reason: "unknown", killer: null);
		}
		return (reason: "succession", killer: null);
	}

	public string GetPreviousLeaderInfo(string kingdomId, Hero newLeader)
	{
		try
		{
			if (IsFileModified())
			{
				AIInfluenceBehavior.Instance?.LogMessage("[LEADERSHIP_TRACKER] File was modified, reloading data...");
				ReloadData();
			}
			if (newLeader == null)
			{
				AIInfluenceBehavior.Instance?.LogMessage("[LEADERSHIP_TRACKER] GetPreviousLeaderInfo: newLeader is null for kingdom " + kingdomId);
				return null;
			}
			if (!_leadershipHistory.ContainsKey(kingdomId))
			{
				AIInfluenceBehavior.Instance?.LogMessage("[LEADERSHIP_TRACKER] GetPreviousLeaderInfo: No history found for kingdom " + kingdomId);
				return null;
			}
			KingdomLeadershipHistory kingdomLeadershipHistory = _leadershipHistory[kingdomId];
			if (kingdomLeadershipHistory.LeadershipChanges == null || kingdomLeadershipHistory.LeadershipChanges.Count == 0)
			{
				AIInfluenceBehavior.Instance?.LogMessage("[LEADERSHIP_TRACKER] GetPreviousLeaderInfo: No leadership changes for kingdom " + kingdomId);
				return null;
			}
			AIInfluenceBehavior.Instance?.LogMessage($"[LEADERSHIP_TRACKER] GetPreviousLeaderInfo: Looking for changes for {newLeader.Name} (id:{((MBObjectBase)newLeader).StringId}) in kingdom {kingdomId}. Total changes: {kingdomLeadershipHistory.LeadershipChanges.Count}");
			LeadershipChange leadershipChange = (from c in kingdomLeadershipHistory.LeadershipChanges
				where c.NewLeaderId == ((MBObjectBase)newLeader).StringId && c.PreviousLeaderId != c.NewLeaderId
				orderby c.ChangeDateString ?? "" descending
				select c).FirstOrDefault();
			if (leadershipChange == null)
			{
				AIInfluenceBehavior.Instance?.LogMessage("[LEADERSHIP_TRACKER] GetPreviousLeaderInfo: No exact match found, looking for any valid change");
				leadershipChange = (from c in kingdomLeadershipHistory.LeadershipChanges
					where c.PreviousLeaderId != c.NewLeaderId
					orderby c.ChangeDateString ?? "" descending
					select c).FirstOrDefault();
			}
			if (leadershipChange == null)
			{
				AIInfluenceBehavior.Instance?.LogMessage("[LEADERSHIP_TRACKER] GetPreviousLeaderInfo: Only duplicates found, using last change");
				leadershipChange = kingdomLeadershipHistory.LeadershipChanges.Last();
			}
			if (leadershipChange == null)
			{
				AIInfluenceBehavior.Instance?.LogMessage("[LEADERSHIP_TRACKER] GetPreviousLeaderInfo: No valid change found");
				return null;
			}
			LeadershipChange lastChange = leadershipChange;
			AIInfluenceBehavior.Instance?.LogMessage("[LEADERSHIP_TRACKER] GetPreviousLeaderInfo: Found change: " + lastChange.PreviousLeaderName + " -> " + lastChange.NewLeaderName + ", reason: " + lastChange.ChangeReason);
			string text = lastChange.PreviousLeaderName + " (id:" + lastChange.PreviousLeaderId + ") of " + lastChange.PreviousLeaderClanName + " (clan_id:" + lastChange.PreviousLeaderClanId + ")";
			string text2 = "";
			if (lastChange.ChangeReason == "death")
			{
				text2 = (string.IsNullOrEmpty(lastChange.KillerName) ? " died" : (" was killed by " + lastChange.KillerName + " (id:" + lastChange.KillerId + ")"));
			}
			else if (lastChange.ChangeReason == "succession")
			{
				text2 = " was succeeded";
			}
			Hero val = ((IEnumerable<Hero>)Hero.AllAliveHeroes).FirstOrDefault((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == lastChange.PreviousLeaderId));
			if (val == null)
			{
				val = ((IEnumerable<Hero>)Hero.DeadOrDisabledHeroes).FirstOrDefault((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == lastChange.PreviousLeaderId));
			}
			string text3 = "";
			if (val != null && newLeader != null)
			{
				text3 = WorldInfoManager.GetRelationshipText(newLeader, val);
				if (!string.IsNullOrEmpty(text3))
				{
					text3 = " " + text3;
				}
			}
			return text + text2 + "." + text3;
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[LEADERSHIP_TRACKER] Error getting previous leader info: " + ex.Message);
			return null;
		}
	}

	public bool IsInitialized()
	{
		return _isInitialized;
	}

	public void ResetInitialization()
	{
		_isInitialized = false;
		AIInfluenceBehavior.Instance?.LogMessage("[LEADERSHIP_TRACKER] Initialization flag reset");
	}
}
