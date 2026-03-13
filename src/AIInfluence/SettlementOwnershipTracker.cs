using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.ObjectSystem;

namespace AIInfluence;

public class SettlementOwnershipTracker
{
	private static SettlementOwnershipTracker _instance;

	private Dictionary<string, SettlementOwnershipHistory> _ownershipHistory = new Dictionary<string, SettlementOwnershipHistory>();

	private Dictionary<string, KingdomCapitalInfo> _kingdomCapitals = new Dictionary<string, KingdomCapitalInfo>();

	private bool _isInitialized = false;

	public static SettlementOwnershipTracker Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new SettlementOwnershipTracker();
			}
			return _instance;
		}
	}

	private SettlementOwnershipTracker()
	{
	}

	public void RegisterEvents()
	{
		CampaignEvents.OnSettlementOwnerChangedEvent.AddNonSerializedListener((object)this, (Action<Settlement, bool, Hero, Hero, Hero, ChangeOwnerOfSettlementDetail>)OnSettlementOwnerChanged);
		CampaignEvents.KingdomCreatedEvent.AddNonSerializedListener((object)this, (Action<Kingdom>)OnKingdomCreated);
		CampaignEvents.RulingClanChanged.AddNonSerializedListener((object)this, (Action<Kingdom, Clan>)OnRulingClanChanged);
	}

	public void SaveData()
	{
		try
		{
			SettlementOwnershipTrackerData settlementOwnershipTrackerData = new SettlementOwnershipTrackerData
			{
				ownershipHistory = _ownershipHistory,
				isInitialized = _isInitialized,
				kingdomCapitals = _kingdomCapitals
			};
			string contents = JsonConvert.SerializeObject((object)settlementOwnershipTrackerData, (Formatting)1);
			string saveFilePath = GetSaveFilePath();
			Directory.CreateDirectory(Path.GetDirectoryName(saveFilePath));
			File.WriteAllText(saveFilePath, contents);
			AIInfluenceBehavior.Instance?.LogMessage("[OWNERSHIP_TRACKER] Data saved to " + saveFilePath);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[OWNERSHIP_TRACKER] Error saving data: " + ex.Message);
		}
	}

	public void LoadData()
	{
		try
		{
			string saveFilePath = GetSaveFilePath();
			if (File.Exists(saveFilePath))
			{
				string text = File.ReadAllText(saveFilePath);
				SettlementOwnershipTrackerData settlementOwnershipTrackerData = JsonConvert.DeserializeObject<SettlementOwnershipTrackerData>(text);
				if (settlementOwnershipTrackerData != null)
				{
					_ownershipHistory = settlementOwnershipTrackerData.ownershipHistory ?? new Dictionary<string, SettlementOwnershipHistory>();
					_isInitialized = settlementOwnershipTrackerData.isInitialized;
					_kingdomCapitals = settlementOwnershipTrackerData.kingdomCapitals ?? new Dictionary<string, KingdomCapitalInfo>();
					AIInfluenceBehavior.Instance?.LogMessage($"[OWNERSHIP_TRACKER] Data loaded from {saveFilePath}. Histories: {_ownershipHistory.Count}, Capitals: {_kingdomCapitals.Count}, Initialized: {_isInitialized}");
				}
			}
			else
			{
				_isInitialized = false;
				_ownershipHistory.Clear();
				_kingdomCapitals.Clear();
				AIInfluenceBehavior.Instance?.LogMessage("[OWNERSHIP_TRACKER] No save file found at " + saveFilePath + ". Will initialize on first use.");
			}
		}
		catch (Exception ex)
		{
			_isInitialized = false;
			_ownershipHistory.Clear();
			_kingdomCapitals.Clear();
			AIInfluenceBehavior.Instance?.LogMessage("[OWNERSHIP_TRACKER] Error loading data: " + ex.Message + ". Will initialize on first use.");
		}
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
			AIInfluenceBehavior.Instance?.LogMessage("[OWNERSHIP_TRACKER] Created save folder: " + text);
		}
		return text;
	}

	private string GetSaveFilePath()
	{
		return Path.Combine(GetCurrentSaveFolder(), "settlement_ownership_history.json");
	}

	public void InitializeStartingOwnership()
	{
		if (_isInitialized)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[OWNERSHIP_TRACKER] System already initialized, skipping initialization");
			return;
		}
		_ownershipHistory.Clear();
		foreach (Settlement item in (List<Settlement>)(object)Settlement.All)
		{
			Clan ownerClan = item.OwnerClan;
			if (((ownerClan != null) ? ownerClan.Kingdom : null) != null)
			{
				SettlementOwnershipHistory value = new SettlementOwnershipHistory
				{
					SettlementId = ((MBObjectBase)item).StringId,
					SettlementName = ((object)item.Name).ToString(),
					OriginalOwnerKingdomId = ((MBObjectBase)item.OwnerClan.Kingdom).StringId,
					OriginalOwnerKingdomName = ((object)item.OwnerClan.Kingdom.Name).ToString(),
					CurrentOwnerKingdomId = ((MBObjectBase)item.OwnerClan.Kingdom).StringId,
					CurrentOwnerKingdomName = ((object)item.OwnerClan.Kingdom.Name).ToString(),
					OwnershipChanges = new List<OwnershipChange>()
				};
				_ownershipHistory[((MBObjectBase)item).StringId] = value;
			}
		}
		_isInitialized = true;
		InitializeCapitals();
		AIInfluenceBehavior.Instance?.LogMessage($"[OWNERSHIP_TRACKER] Initialized ownership for {_ownershipHistory.Count} settlements, {_kingdomCapitals.Count} capitals");
	}

	public void InitializeCapitals()
	{
		foreach (Kingdom item in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated))
		{
			if (!_kingdomCapitals.ContainsKey(((MBObjectBase)item).StringId))
			{
				Settlement val = DetermineCapital(item);
				if (val != null)
				{
					_kingdomCapitals[((MBObjectBase)item).StringId] = new KingdomCapitalInfo
					{
						KingdomId = ((MBObjectBase)item).StringId,
						KingdomName = ((object)item.Name).ToString(),
						CapitalSettlementId = ((MBObjectBase)val).StringId,
						CapitalSettlementName = ((object)val.Name).ToString(),
						IsCity = val.IsTown
					};
					AIInfluenceBehavior.Instance?.LogMessage(string.Format("[OWNERSHIP_TRACKER] Capital of {0}: {1} ({2})", item.Name, val.Name, val.IsTown ? "town" : "castle"));
				}
			}
		}
	}

	private Settlement DetermineCapital(Kingdom kingdom)
	{
		if (kingdom == null || kingdom.IsEliminated)
		{
			return null;
		}
		Clan rulingClan = kingdom.RulingClan;
		if (rulingClan != null)
		{
			Settlement val = ((IEnumerable<Settlement>)rulingClan.Settlements).Where((Settlement s) => s.IsTown).OrderByDescending(delegate(Settlement s)
			{
				Town town = s.Town;
				return (town != null) ? town.Prosperity : 0f;
			}).FirstOrDefault();
			if (val != null)
			{
				return val;
			}
		}
		Settlement val2 = ((IEnumerable<Settlement>)kingdom.Settlements).Where((Settlement s) => s.IsTown).OrderByDescending(delegate(Settlement s)
		{
			Town town = s.Town;
			return (town != null) ? town.Prosperity : 0f;
		}).FirstOrDefault();
		if (val2 != null)
		{
			return val2;
		}
		if (rulingClan != null)
		{
			Settlement val3 = ((IEnumerable<Settlement>)rulingClan.Settlements).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => s.IsCastle));
			if (val3 != null)
			{
				return val3;
			}
		}
		return ((IEnumerable<Settlement>)kingdom.Settlements).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => s.IsCastle));
	}

	private void OnSettlementOwnerChanged(Settlement settlement, bool openToClaim, Hero newOwner, Hero oldOwner, Hero capturer, ChangeOwnerOfSettlementDetail detail)
	{
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		Clan ownerClan = settlement.OwnerClan;
		if (((ownerClan != null) ? ownerClan.Kingdom : null) == null)
		{
			return;
		}
		string stringId = ((MBObjectBase)settlement).StringId;
		string stringId2 = ((MBObjectBase)settlement.OwnerClan.Kingdom).StringId;
		string text = ((object)settlement.OwnerClan.Kingdom.Name).ToString();
		Kingdom val = null;
		object obj;
		if (oldOwner == null)
		{
			obj = null;
		}
		else
		{
			Clan clan = oldOwner.Clan;
			obj = ((clan != null) ? clan.Kingdom : null);
		}
		if (obj != null)
		{
			val = oldOwner.Clan.Kingdom;
		}
		if (!_ownershipHistory.ContainsKey(stringId))
		{
			_ownershipHistory[stringId] = new SettlementOwnershipHistory
			{
				SettlementId = stringId,
				SettlementName = ((object)settlement.Name).ToString(),
				OriginalOwnerKingdomId = stringId2,
				OriginalOwnerKingdomName = text,
				CurrentOwnerKingdomId = stringId2,
				CurrentOwnerKingdomName = text,
				OwnershipChanges = new List<OwnershipChange>()
			};
		}
		else
		{
			SettlementOwnershipHistory settlementOwnershipHistory = _ownershipHistory[stringId];
			if (val != null && ((MBObjectBase)val).StringId != stringId2)
			{
				AIInfluenceBehavior.Instance?.LogMessage($"[OWNERSHIP_TRACKER] {val.Name} lost settlement {settlement.Name} to {text}");
			}
			settlementOwnershipHistory.CurrentOwnerKingdomId = stringId2;
			settlementOwnershipHistory.CurrentOwnerKingdomName = text;
			OwnershipChange ownershipChange = new OwnershipChange
			{
				FromKingdomId = settlementOwnershipHistory.CurrentOwnerKingdomId,
				FromKingdomName = settlementOwnershipHistory.CurrentOwnerKingdomName,
				ToKingdomId = stringId2,
				ToKingdomName = text,
				ChangeDate = CampaignTime.Now,
				ChangeReason = GetChangeReason(detail)
			};
			if (capturer != null)
			{
				ownershipChange.CapturerHeroId = ((MBObjectBase)capturer).StringId;
				ownershipChange.CapturerHeroName = ((object)capturer.Name)?.ToString() ?? "Unknown";
				if (capturer.Clan != null)
				{
					ownershipChange.CapturerClanId = ((MBObjectBase)capturer.Clan).StringId;
					ownershipChange.CapturerClanName = ((object)capturer.Clan.Name)?.ToString() ?? "Unknown";
				}
			}
			else if (newOwner != null)
			{
				ownershipChange.CapturerHeroId = ((MBObjectBase)newOwner).StringId;
				ownershipChange.CapturerHeroName = ((object)newOwner.Name)?.ToString() ?? "Unknown";
				if (newOwner.Clan != null)
				{
					ownershipChange.CapturerClanId = ((MBObjectBase)newOwner.Clan).StringId;
					ownershipChange.CapturerClanName = ((object)newOwner.Clan.Name)?.ToString() ?? "Unknown";
				}
			}
			settlementOwnershipHistory.OwnershipChanges.Add(ownershipChange);
		}
		AIInfluenceBehavior.Instance?.LogMessage($"[OWNERSHIP_TRACKER] {settlement.Name}: {_ownershipHistory[stringId].GetOwnershipDescription()}");
		Clan ownerClan2 = settlement.OwnerClan;
		CheckCapitalAfterOwnershipChange(settlement, (ownerClan2 != null) ? ownerClan2.Kingdom : null, val);
		SaveData();
	}

	private void OnKingdomCreated(Kingdom kingdom)
	{
		if (kingdom != null && !kingdom.IsEliminated)
		{
			Settlement val = DetermineCapital(kingdom);
			if (val != null)
			{
				_kingdomCapitals[((MBObjectBase)kingdom).StringId] = new KingdomCapitalInfo
				{
					KingdomId = ((MBObjectBase)kingdom).StringId,
					KingdomName = ((object)kingdom.Name).ToString(),
					CapitalSettlementId = ((MBObjectBase)val).StringId,
					CapitalSettlementName = ((object)val.Name).ToString(),
					IsCity = val.IsTown
				};
				AIInfluenceBehavior.Instance?.LogMessage(string.Format("[OWNERSHIP_TRACKER] New kingdom {0} capital: {1} ({2})", kingdom.Name, val.Name, val.IsTown ? "town" : "castle"));
				SaveData();
			}
		}
	}

	private void OnRulingClanChanged(Kingdom kingdom, Clan newRulingClan)
	{
		if (kingdom != null && !kingdom.IsEliminated)
		{
			RecalculateCapital(kingdom, "ruling clan changed");
		}
	}

	private void CheckCapitalAfterOwnershipChange(Settlement settlement, Kingdom newKingdom, Kingdom oldKingdom)
	{
		if (oldKingdom != null && !oldKingdom.IsEliminated && _kingdomCapitals.ContainsKey(((MBObjectBase)oldKingdom).StringId) && _kingdomCapitals[((MBObjectBase)oldKingdom).StringId].CapitalSettlementId == ((MBObjectBase)settlement).StringId)
		{
			RecalculateCapital(oldKingdom, "capital lost to enemy");
		}
		if (newKingdom != null && !newKingdom.IsEliminated && settlement.IsTown)
		{
			if (_kingdomCapitals.ContainsKey(((MBObjectBase)newKingdom).StringId))
			{
				KingdomCapitalInfo kingdomCapitalInfo = _kingdomCapitals[((MBObjectBase)newKingdom).StringId];
				if (!kingdomCapitalInfo.IsCity)
				{
					RecalculateCapital(newKingdom, "acquired town, upgrading from castle capital");
				}
			}
			else
			{
				RecalculateCapital(newKingdom, "first settlement acquired");
			}
		}
		if (newKingdom != null && !newKingdom.IsEliminated && !_kingdomCapitals.ContainsKey(((MBObjectBase)newKingdom).StringId))
		{
			RecalculateCapital(newKingdom, "no capital set yet");
		}
	}

	private void RecalculateCapital(Kingdom kingdom, string reason)
	{
		Settlement val = DetermineCapital(kingdom);
		if (val != null)
		{
			string text = (_kingdomCapitals.ContainsKey(((MBObjectBase)kingdom).StringId) ? _kingdomCapitals[((MBObjectBase)kingdom).StringId].CapitalSettlementName : "none");
			_kingdomCapitals[((MBObjectBase)kingdom).StringId] = new KingdomCapitalInfo
			{
				KingdomId = ((MBObjectBase)kingdom).StringId,
				KingdomName = ((object)kingdom.Name).ToString(),
				CapitalSettlementId = ((MBObjectBase)val).StringId,
				CapitalSettlementName = ((object)val.Name).ToString(),
				IsCity = val.IsTown
			};
			AIInfluenceBehavior.Instance?.LogMessage($"[OWNERSHIP_TRACKER] {kingdom.Name} capital: {text} → {val.Name} ({reason})");
			SaveData();
		}
		else
		{
			_kingdomCapitals.Remove(((MBObjectBase)kingdom).StringId);
			AIInfluenceBehavior.Instance?.LogMessage($"[OWNERSHIP_TRACKER] {kingdom.Name} has no capital ({reason})");
			SaveData();
		}
	}

	public string GetCapitalSettlementId(string kingdomId)
	{
		return _kingdomCapitals.ContainsKey(kingdomId) ? _kingdomCapitals[kingdomId].CapitalSettlementId : null;
	}

	public KingdomCapitalInfo GetCapitalInfo(string kingdomId)
	{
		return _kingdomCapitals.ContainsKey(kingdomId) ? _kingdomCapitals[kingdomId] : null;
	}

	public string GetCapitalForAI(Kingdom kingdom)
	{
		if (kingdom == null)
		{
			return "";
		}
		if (!_kingdomCapitals.ContainsKey(((MBObjectBase)kingdom).StringId))
		{
			return "";
		}
		KingdomCapitalInfo kingdomCapitalInfo = _kingdomCapitals[((MBObjectBase)kingdom).StringId];
		return "Capital: " + kingdomCapitalInfo.CapitalSettlementName + " (string_id:" + kingdomCapitalInfo.CapitalSettlementId + ", " + (kingdomCapitalInfo.IsCity ? "town" : "castle") + ")";
	}

	public bool IsCapital(string settlementId)
	{
		return _kingdomCapitals.Values.Any((KingdomCapitalInfo c) => c.CapitalSettlementId == settlementId);
	}

	public SettlementOwnershipHistory GetOwnershipHistory(string settlementId)
	{
		if (!_ownershipHistory.ContainsKey(settlementId))
		{
			return null;
		}
		return _ownershipHistory[settlementId];
	}

	public string GetOwnershipDescription(string settlementId)
	{
		if (!_ownershipHistory.ContainsKey(settlementId))
		{
			return "Unknown ownership history";
		}
		return _ownershipHistory[settlementId].GetOwnershipDescription();
	}

	public string GetOwnershipContextForAI(string settlementId)
	{
		if (!_ownershipHistory.ContainsKey(settlementId))
		{
			return "";
		}
		SettlementOwnershipHistory settlementOwnershipHistory = _ownershipHistory[settlementId];
		if (settlementOwnershipHistory.OriginalOwnerKingdomId == settlementOwnershipHistory.CurrentOwnerKingdomId)
		{
			return "Historical " + settlementOwnershipHistory.OriginalOwnerKingdomName + " settlement";
		}
		return settlementOwnershipHistory.GetOwnershipDescription();
	}

	public bool IsInitialized()
	{
		return _isInitialized;
	}

	public void ResetInitialization()
	{
		_isInitialized = false;
		AIInfluenceBehavior.Instance?.LogMessage("[OWNERSHIP_TRACKER] Initialization flag reset");
	}

	private string GetChangeReason(ChangeOwnerOfSettlementDetail detail)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Invalid comparison between Unknown and I4
		if ((int)detail != 1)
		{
			if ((int)detail != 2)
			{
				if ((int)detail == 6)
				{
					return "rebellion";
				}
				return "other";
			}
			return "diplomacy";
		}
		return "conquest";
	}
}
