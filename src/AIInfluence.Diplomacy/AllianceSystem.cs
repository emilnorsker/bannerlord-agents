using System;
using System.Collections.Generic;
using System.Linq;
using AIInfluence.Util;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Diplomacy;

public class AllianceSystem
{
	private static AllianceSystem _instance;

	private readonly DiplomacyStorage _storage;

	public static AllianceSystem Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new AllianceSystem();
			}
			return _instance;
		}
	}

	[JsonProperty("alliances")]
	public Dictionary<string, List<string>> Alliances { get; set; } = new Dictionary<string, List<string>>();

	[JsonProperty("alliance_times")]
	public Dictionary<string, CampaignTime> AllianceTimes { get; set; } = new Dictionary<string, CampaignTime>();

	private AllianceSystem()
	{
		_storage = new DiplomacyStorage();
	}

	public static void Reset()
	{
		if (_instance != null)
		{
			_instance.Alliances.Clear();
			_instance.AllianceTimes.Clear();
			AIInfluenceBehavior.Instance?.LogMessage("[ALLIANCE] Alliance system state reset for new campaign");
		}
		_instance = null;
	}

	public void Initialize()
	{
		LogMessage("[ALLIANCE] Initializing alliance system...");
		Alliances.Clear();
		AllianceTimes.Clear();
		_storage.LoadAlliances(this);
		SynchronizeAlliances();
		LogMessage($"[ALLIANCE] Alliance system initialized with {Alliances.Count} alliance groups");
	}

	public void SynchronizeAlliances()
	{
		LogMessage("[ALLIANCE] Synchronizing alliances with game state...");
		HashSet<string> hashSet = new HashSet<string>();
		int num = 0;
		int num2 = 0;
		foreach (Kingdom kingdom1 in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated))
		{
			foreach (Kingdom item in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated && k != kingdom1))
			{
				string allianceKey = GetAllianceKey(((MBObjectBase)kingdom1).StringId, ((MBObjectBase)item).StringId);
				if (hashSet.Contains(allianceKey))
				{
					continue;
				}
				hashSet.Add(allianceKey);
				bool flag = Alliances.ContainsKey(((MBObjectBase)kingdom1).StringId) && Alliances[((MBObjectBase)kingdom1).StringId].Contains(((MBObjectBase)item).StringId);
				bool flag2 = GameVersionCompatibility.IsAlliedWithFaction((IFaction)(object)kingdom1, (IFaction)(object)item);
				bool flag3 = FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom1, (IFaction)(object)item);
				if (flag && !flag2)
				{
					if (flag3)
					{
						LogMessage($"[ALLIANCE] Synchronizing: Cannot create alliance {kingdom1.Name} ↔ {item.Name} - they are at war. Removing from file.");
						if (Alliances.ContainsKey(((MBObjectBase)kingdom1).StringId))
						{
							Alliances[((MBObjectBase)kingdom1).StringId].Remove(((MBObjectBase)item).StringId);
						}
						if (Alliances.ContainsKey(((MBObjectBase)item).StringId))
						{
							Alliances[((MBObjectBase)item).StringId].Remove(((MBObjectBase)kingdom1).StringId);
						}
						SaveData();
						num2++;
					}
					else
					{
						LogMessage($"[ALLIANCE] Synchronizing: Creating missing alliance {kingdom1.Name} ↔ {item.Name}");
						CreateAllianceInGame(kingdom1, item);
						num++;
					}
				}
				else if (!flag && flag2)
				{
					if (flag3)
					{
						LogMessage($"[ALLIANCE] Synchronizing: Breaking unexpected alliance {kingdom1.Name} ↔ {item.Name} - they are at war");
						BreakAllianceInGame(kingdom1, item);
						num2++;
					}
					else
					{
						LogMessage($"[ALLIANCE] Synchronizing: Breaking unexpected alliance {kingdom1.Name} ↔ {item.Name}");
						BreakAllianceInGame(kingdom1, item);
						num2++;
					}
				}
				else if (flag && flag2 && flag3)
				{
					LogMessage($"[ALLIANCE] Synchronizing: Breaking conflicting alliance {kingdom1.Name} ↔ {item.Name} - they are at war");
					BreakAllianceInGame(kingdom1, item);
					if (Alliances.ContainsKey(((MBObjectBase)kingdom1).StringId))
					{
						Alliances[((MBObjectBase)kingdom1).StringId].Remove(((MBObjectBase)item).StringId);
					}
					if (Alliances.ContainsKey(((MBObjectBase)item).StringId))
					{
						Alliances[((MBObjectBase)item).StringId].Remove(((MBObjectBase)kingdom1).StringId);
					}
					SaveData();
					num2++;
				}
			}
		}
		LogMessage($"[ALLIANCE] Synchronization complete: {num} created, {num2} broken");
	}

	public void SaveData()
	{
		_storage.SaveAlliances(this);
	}

	public bool AreAllied(Kingdom kingdom1, Kingdom kingdom2)
	{
		if (kingdom1 == null || kingdom2 == null)
		{
			return false;
		}
		if (kingdom1 == kingdom2)
		{
			return false;
		}
		if (GameVersionCompatibility.IsAlliedWithFaction((IFaction)(object)kingdom1, (IFaction)(object)kingdom2))
		{
			return true;
		}
		string stringId = ((MBObjectBase)kingdom1).StringId;
		string stringId2 = ((MBObjectBase)kingdom2).StringId;
		return Alliances.ContainsKey(stringId) && Alliances[stringId].Contains(stringId2);
	}

	public void CreateAlliance(Kingdom kingdom1, Kingdom kingdom2)
	{
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		if (kingdom1 == null || kingdom2 == null)
		{
			LogMessage("[ALLIANCE] Cannot create alliance: one or both kingdoms are null");
			return;
		}
		if (kingdom1 == kingdom2)
		{
			LogMessage("[ALLIANCE] Cannot create alliance: kingdoms are the same");
			return;
		}
		if (AreAllied(kingdom1, kingdom2))
		{
			LogMessage($"[ALLIANCE] {kingdom1.Name} and {kingdom2.Name} are already allied");
			return;
		}
		string stringId = ((MBObjectBase)kingdom1).StringId;
		string stringId2 = ((MBObjectBase)kingdom2).StringId;
		if (!Alliances.ContainsKey(stringId))
		{
			Alliances[stringId] = new List<string>();
		}
		if (!Alliances.ContainsKey(stringId2))
		{
			Alliances[stringId2] = new List<string>();
		}
		Alliances[stringId].Add(stringId2);
		Alliances[stringId2].Add(stringId);
		string allianceKey = GetAllianceKey(stringId, stringId2);
		AllianceTimes[allianceKey] = CampaignTime.Now;
		DiplomacyPatches.WithBypass(delegate
		{
			GameVersionCompatibility.DeclareAlliance((IFaction)(object)kingdom1, (IFaction)(object)kingdom2);
		});
		bool flag = GameVersionCompatibility.IsAlliedWithFaction((IFaction)(object)kingdom1, (IFaction)(object)kingdom2);
		LogMessage($"[ALLIANCE] Alliance formed: {kingdom1.Name} ↔ {kingdom2.Name}, verified: {flag}");
		DiplomacyLogger.Instance.LogDiplomaticAction("alliance_formed", stringId, stringId2, "AI-driven diplomatic alliance");
		SaveData();
	}

	private void CreateAllianceInGame(Kingdom kingdom1, Kingdom kingdom2)
	{
		if (kingdom1 == null || kingdom2 == null || kingdom1 == kingdom2)
		{
			return;
		}
		if (GameVersionCompatibility.IsAlliedWithFaction((IFaction)(object)kingdom1, (IFaction)(object)kingdom2))
		{
			LogMessage($"[ALLIANCE] {kingdom1.Name} and {kingdom2.Name} are already allied in game");
			return;
		}
		DiplomacyPatches.WithBypass(delegate
		{
			GameVersionCompatibility.DeclareAlliance((IFaction)(object)kingdom1, (IFaction)(object)kingdom2);
		});
		bool flag = GameVersionCompatibility.IsAlliedWithFaction((IFaction)(object)kingdom1, (IFaction)(object)kingdom2);
		LogMessage($"[ALLIANCE] Alliance synchronized in game: {kingdom1.Name} ↔ {kingdom2.Name}, verified: {flag}");
	}

	public void BreakAlliance(Kingdom kingdom1, Kingdom kingdom2)
	{
		if (kingdom1 == null || kingdom2 == null)
		{
			return;
		}
		if (!AreAllied(kingdom1, kingdom2))
		{
			LogMessage($"[ALLIANCE] Cannot break alliance: {kingdom1.Name} and {kingdom2.Name} are not allied");
			return;
		}
		string stringId = ((MBObjectBase)kingdom1).StringId;
		string stringId2 = ((MBObjectBase)kingdom2).StringId;
		if (Alliances.ContainsKey(stringId))
		{
			Alliances[stringId].Remove(stringId2);
		}
		if (Alliances.ContainsKey(stringId2))
		{
			Alliances[stringId2].Remove(stringId);
		}
		string allianceKey = GetAllianceKey(stringId, stringId2);
		AllianceTimes.Remove(allianceKey);
		DiplomacyPatches.WithBypass(delegate
		{
			GameVersionCompatibility.EndAlliance(kingdom1, kingdom2);
		});
		LogMessage($"[ALLIANCE] Alliance broken: {kingdom1.Name} ↔ {kingdom2.Name}");
		DiplomacyLogger.Instance.LogDiplomaticAction("alliance_broken", stringId, stringId2, "Alliance dissolved");
		SaveData();
	}

	private void BreakAllianceInGame(Kingdom kingdom1, Kingdom kingdom2)
	{
		if (kingdom1 == null || kingdom2 == null)
		{
			return;
		}
		if (!GameVersionCompatibility.IsAlliedWithFaction((IFaction)(object)kingdom1, (IFaction)(object)kingdom2))
		{
			LogMessage($"[ALLIANCE] {kingdom1.Name} and {kingdom2.Name} are not allied in game");
			return;
		}
		DiplomacyPatches.WithBypass(delegate
		{
			GameVersionCompatibility.EndAlliance(kingdom1, kingdom2);
		});
		LogMessage($"[ALLIANCE] Alliance broken in game: {kingdom1.Name} ↔ {kingdom2.Name}");
	}

	public List<Kingdom> GetAllies(Kingdom kingdom)
	{
		if (kingdom == null)
		{
			return new List<Kingdom>();
		}
		string stringId = ((MBObjectBase)kingdom).StringId;
		if (!Alliances.ContainsKey(stringId))
		{
			return new List<Kingdom>();
		}
		List<string> list = Alliances[stringId];
		List<Kingdom> list2 = new List<Kingdom>();
		foreach (string allyId in list)
		{
			Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == allyId));
			if (val != null && !val.IsEliminated)
			{
				list2.Add(val);
			}
		}
		return list2;
	}

	public string GetAllianceInfoForAI(Kingdom kingdom)
	{
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		if (kingdom == null)
		{
			return "No alliance information available";
		}
		List<Kingdom> allies = GetAllies(kingdom);
		if (!allies.Any())
		{
			return $"{kingdom.Name} has no formal alliances";
		}
		List<string> list = new List<string>();
		foreach (Kingdom item in allies)
		{
			string allianceKey = GetAllianceKey(((MBObjectBase)kingdom).StringId, ((MBObjectBase)item).StringId);
			if (AllianceTimes.TryGetValue(allianceKey, out var value))
			{
				CampaignTime val = CampaignTime.Now - value;
				int num = (int)((CampaignTime)(ref val)).ToDays;
				list.Add($"{item.Name} (allied for {num} days)");
			}
			else
			{
				list.Add($"{item.Name}");
			}
		}
		return string.Format("{0} is allied with: {1}", kingdom.Name, string.Join(", ", list));
	}

	public string GetDetailedAllianceInfo(Kingdom kingdom)
	{
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		if (kingdom == null)
		{
			return "Kingdom is null";
		}
		List<Kingdom> allies = GetAllies(kingdom);
		if (!allies.Any())
		{
			return $"{kingdom.Name} has no allies";
		}
		string text = $"{kingdom.Name} Alliance Network:\n";
		foreach (Kingdom item in allies)
		{
			string allianceKey = GetAllianceKey(((MBObjectBase)kingdom).StringId, ((MBObjectBase)item).StringId);
			if (AllianceTimes.TryGetValue(allianceKey, out var value))
			{
				CampaignTime val = CampaignTime.Now - value;
				int num = (int)((CampaignTime)(ref val)).ToDays;
				text += $"  - {item.Name}: {num} days\n";
			}
			else
			{
				text += $"  - {item.Name}: Unknown duration\n";
			}
		}
		return text;
	}

	public bool WouldBeIsolated(Kingdom kingdom, Kingdom allyToRemove)
	{
		if (kingdom == null)
		{
			return false;
		}
		List<Kingdom> allies = GetAllies(kingdom);
		return allies.Count <= 1 && allies.Contains(allyToRemove);
	}

	public int GetAllianceStrength(Kingdom kingdom)
	{
		if (kingdom == null)
		{
			return 0;
		}
		return GetAllies(kingdom).Count;
	}

	public bool HaveCommonAllies(Kingdom kingdom1, Kingdom kingdom2)
	{
		if (kingdom1 == null || kingdom2 == null)
		{
			return false;
		}
		List<Kingdom> allies = GetAllies(kingdom1);
		List<Kingdom> allies2 = GetAllies(kingdom2);
		return allies.Intersect(allies2).Any();
	}

	public List<Kingdom> GetEnemyAllies(Kingdom kingdom, Kingdom enemy)
	{
		if (kingdom == null || enemy == null)
		{
			return new List<Kingdom>();
		}
		List<Kingdom> allies = GetAllies(enemy);
		List<Kingdom> myAllies = GetAllies(kingdom);
		return allies.Where((Kingdom ally) => !myAllies.Contains(ally) && ally != kingdom).ToList();
	}

	public void CleanupEliminatedKingdoms()
	{
		List<string> list = (from k in (IEnumerable<Kingdom>)Kingdom.All
			where k.IsEliminated
			select ((MBObjectBase)k).StringId).ToList();
		foreach (string item in list)
		{
			if (!Alliances.ContainsKey(item))
			{
				continue;
			}
			List<string> list2 = new List<string>(Alliances[item]);
			foreach (string item2 in list2)
			{
				if (Alliances.ContainsKey(item2))
				{
					Alliances[item2].Remove(item);
				}
				string allianceKey = GetAllianceKey(item, item2);
				AllianceTimes.Remove(allianceKey);
			}
			Alliances.Remove(item);
			LogMessage("[ALLIANCE] Cleaned up alliances for eliminated kingdom: " + item);
		}
	}

	private string GetAllianceKey(string kingdom1Id, string kingdom2Id)
	{
		if (string.Compare(kingdom1Id, kingdom2Id, StringComparison.Ordinal) < 0)
		{
			return kingdom1Id + "_" + kingdom2Id;
		}
		return kingdom2Id + "_" + kingdom1Id;
	}

	public List<string> GetAllActiveAlliances()
	{
		List<string> list = new List<string>();
		HashSet<string> hashSet = new HashSet<string>();
		foreach (KeyValuePair<string, List<string>> alliance in Alliances)
		{
			string kingdom1Id = alliance.Key;
			foreach (string kingdom2Id in alliance.Value)
			{
				string allianceKey = GetAllianceKey(kingdom1Id, kingdom2Id);
				if (!hashSet.Contains(allianceKey))
				{
					Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == kingdom1Id));
					Kingdom val2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == kingdom2Id));
					if (val != null && val2 != null)
					{
						list.Add($"{val.Name} ↔ {val2.Name}");
					}
					hashSet.Add(allianceKey);
				}
			}
		}
		return list;
	}

	private void LogMessage(string message)
	{
		AIInfluenceBehavior.Instance?.LogMessage(message);
	}
}
