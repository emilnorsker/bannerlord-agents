using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Diplomacy;

public class TerritoryTransferSystem
{
	private static TerritoryTransferSystem _instance;

	private readonly DiplomacyStorage _storage;

	public static TerritoryTransferSystem Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new TerritoryTransferSystem();
			}
			return _instance;
		}
	}

	[JsonProperty("transfer_history")]
	public List<TerritoryTransferRecord> TransferHistory { get; set; } = new List<TerritoryTransferRecord>();

	private TerritoryTransferSystem()
	{
		_storage = new DiplomacyStorage();
	}

	public static void Reset()
	{
		if (_instance != null)
		{
			_instance.TransferHistory.Clear();
			AIInfluenceBehavior.Instance?.LogMessage("[TERRITORY_TRANSFER] Territory transfer system state reset for new campaign");
		}
		_instance = null;
	}

	public void Initialize()
	{
		LogMessage("[TERRITORY_TRANSFER] Initializing territory transfer system...");
		TransferHistory.Clear();
		LoadData();
		LogMessage($"[TERRITORY_TRANSFER] System initialized with {TransferHistory.Count} historical transfers");
	}

	public void SaveData()
	{
		_storage.SaveTerritoryTransfers(this);
	}

	private void LoadData()
	{
		_storage.LoadTerritoryTransfers(this);
	}

	public bool TransferSettlement(Settlement settlement, Kingdom fromKingdom, Kingdom toKingdom, string reason)
	{
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		if (settlement == null || fromKingdom == null || toKingdom == null)
		{
			LogMessage("[TERRITORY_TRANSFER] ERROR: Invalid parameters for settlement transfer");
			return false;
		}
		if (!settlement.IsTown && !settlement.IsCastle)
		{
			LogMessage($"[TERRITORY_TRANSFER] ERROR: Can only transfer towns and castles, not {settlement.Name}");
			return false;
		}
		Clan ownerClan = settlement.OwnerClan;
		if (((ownerClan != null) ? ownerClan.Kingdom : null) != fromKingdom)
		{
			LogMessage($"[TERRITORY_TRANSFER] ERROR: Settlement {settlement.Name} does not belong to {fromKingdom.Name}");
			return false;
		}
		if (fromKingdom == toKingdom)
		{
			LogMessage("[TERRITORY_TRANSFER] ERROR: Cannot transfer to the same kingdom");
			return false;
		}
		try
		{
			TerritoryTransferRecord item = new TerritoryTransferRecord
			{
				SettlementId = ((MBObjectBase)settlement).StringId,
				SettlementName = ((object)settlement.Name).ToString(),
				FromKingdomId = ((MBObjectBase)fromKingdom).StringId,
				ToKingdomId = ((MBObjectBase)toKingdom).StringId,
				TransferTime = CampaignTime.Now,
				Reason = reason
			};
			LogMessage($"[TERRITORY_TRANSFER] Transferring {settlement.Name} from {fromKingdom.Name} to {toKingdom.Name}");
			LogMessage("[TERRITORY_TRANSFER] Reason: " + reason);
			Clan receivingClan = GetBestClanForSettlement(toKingdom, settlement);
			if (receivingClan == null)
			{
				receivingClan = toKingdom.RulingClan;
			}
			DiplomacyPatches.WithBypass(delegate
			{
				ChangeOwnerOfSettlementAction.ApplyByDefault(receivingClan.Leader, settlement);
			});
			TransferHistory.Add(item);
			SaveData();
			DiplomacyLogger.Instance.LogDiplomaticAction("territory_transferred", ((MBObjectBase)fromKingdom).StringId, ((MBObjectBase)toKingdom).StringId, $"Settlement {settlement.Name} transferred: {reason}");
			LogMessage($"[TERRITORY_TRANSFER] SUCCESS: {settlement.Name} transferred to {toKingdom.Name} (new owner: {receivingClan.Name})");
			return true;
		}
		catch (Exception ex)
		{
			LogMessage("[TERRITORY_TRANSFER] ERROR during transfer: " + ex.Message);
			LogMessage("[TERRITORY_TRANSFER] Stack trace: " + ex.StackTrace);
			return false;
		}
	}

	public bool TransferSettlementById(string settlementId, Kingdom fromKingdom, Kingdom toKingdom, string reason)
	{
		Settlement val = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == settlementId));
		if (val == null)
		{
			LogMessage("[TERRITORY_TRANSFER] ERROR: Settlement with ID '" + settlementId + "' not found");
			return false;
		}
		return TransferSettlement(val, fromKingdom, toKingdom, reason);
	}

	public bool TransferSettlementToClan(Settlement settlement, Clan toClan, string reason)
	{
		if (settlement == null || toClan == null)
		{
			LogMessage("[TERRITORY_TRANSFER] ERROR: Invalid parameters for clan transfer");
			return false;
		}
		if (!settlement.IsTown && !settlement.IsCastle)
		{
			LogMessage($"[TERRITORY_TRANSFER] ERROR: Can only transfer towns and castles, not {settlement.Name}");
			return false;
		}
		if (settlement.OwnerClan == toClan)
		{
			LogMessage($"[TERRITORY_TRANSFER] ERROR: Settlement {settlement.Name} is already owned by {toClan.Name}");
			return false;
		}
		try
		{
			TextObject name = settlement.Name;
			Clan ownerClan = settlement.OwnerClan;
			LogMessage(string.Format("[TERRITORY_TRANSFER] Transferring {0} from {1} to {2}", name, ((ownerClan == null) ? null : ((object)ownerClan.Name)?.ToString()) ?? "None", toClan.Name));
			LogMessage("[TERRITORY_TRANSFER] Reason: " + reason);
			DiplomacyPatches.WithBypass(delegate
			{
				ChangeOwnerOfSettlementAction.ApplyByDefault(toClan.Leader, settlement);
			});
			DiplomacyLogger instance = DiplomacyLogger.Instance;
			Clan ownerClan2 = settlement.OwnerClan;
			object obj;
			if (ownerClan2 == null)
			{
				obj = null;
			}
			else
			{
				Kingdom kingdom = ownerClan2.Kingdom;
				obj = ((kingdom != null) ? ((MBObjectBase)kingdom).StringId : null);
			}
			if (obj == null)
			{
				obj = "none";
			}
			Kingdom kingdom2 = toClan.Kingdom;
			instance.LogDiplomaticAction("fief_granted", (string)obj, ((kingdom2 != null) ? ((MBObjectBase)kingdom2).StringId : null) ?? "none", $"Settlement {settlement.Name} granted to {toClan.Name}: {reason}");
			LogMessage($"[TERRITORY_TRANSFER] SUCCESS: {settlement.Name} transferred to {toClan.Name}");
			return true;
		}
		catch (Exception ex)
		{
			LogMessage("[TERRITORY_TRANSFER] ERROR during clan transfer: " + ex.Message);
			LogMessage("[TERRITORY_TRANSFER] Stack trace: " + ex.StackTrace);
			return false;
		}
	}

	public bool TransferSettlementToClanById(string settlementId, Clan toClan, string reason)
	{
		Settlement val = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == settlementId));
		if (val == null)
		{
			LogMessage("[TERRITORY_TRANSFER] ERROR: Settlement with ID '" + settlementId + "' not found");
			return false;
		}
		return TransferSettlementToClan(val, toClan, reason);
	}

	public List<Settlement> GetTransferableSettlements(Kingdom kingdom)
	{
		if (kingdom == null || kingdom.IsEliminated)
		{
			return new List<Settlement>();
		}
		return ((IEnumerable<Settlement>)Settlement.All).Where(delegate(Settlement s)
		{
			int result;
			if (s.IsTown || s.IsCastle)
			{
				Clan ownerClan = s.OwnerClan;
				if (((ownerClan != null) ? ownerClan.Kingdom : null) == kingdom)
				{
					result = ((!s.IsUnderSiege) ? 1 : 0);
					goto IL_0036;
				}
			}
			result = 0;
			goto IL_0036;
			IL_0036:
			return (byte)result != 0;
		}).ToList();
	}

	public List<Settlement> GetWarRelevantSettlements(Kingdom kingdom1, Kingdom kingdom2)
	{
		if (kingdom1 == null || kingdom2 == null || kingdom1.IsEliminated || kingdom2.IsEliminated)
		{
			return new List<Settlement>();
		}
		SettlementOwnershipTracker instance = SettlementOwnershipTracker.Instance;
		List<Settlement> list = new List<Settlement>();
		HashSet<string> hashSet = new HashSet<string>();
		bool flag = FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom1, (IFaction)(object)kingdom2);
		List<TerritoryTransferRecord> list2 = TransferHistory.Where((TerritoryTransferRecord t) => (t.FromKingdomId == ((MBObjectBase)kingdom1).StringId && t.ToKingdomId == ((MBObjectBase)kingdom2).StringId) || (t.FromKingdomId == ((MBObjectBase)kingdom2).StringId && t.ToKingdomId == ((MBObjectBase)kingdom1).StringId)).Where(delegate(TerritoryTransferRecord t)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			CampaignTime val3 = CampaignTime.Now - t.TransferTime;
			return (val3).ToDays <= 90.0;
		}).ToList();
		foreach (TerritoryTransferRecord transfer in list2)
		{
			Settlement val = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == transfer.SettlementId));
			if (val != null && !val.IsUnderSiege && (val.IsTown || val.IsCastle) && !hashSet.Contains(((MBObjectBase)val).StringId))
			{
				list.Add(val);
				hashSet.Add(((MBObjectBase)val).StringId);
			}
		}
		foreach (Settlement item in (List<Settlement>)(object)Settlement.All)
		{
			if ((!item.IsTown && !item.IsCastle) || item.IsUnderSiege)
			{
				continue;
			}
			Clan ownerClan = item.OwnerClan;
			Kingdom val2 = ((ownerClan != null) ? ownerClan.Kingdom : null);
			if (val2 == null || (val2 != kingdom1 && val2 != kingdom2) || hashSet.Contains(((MBObjectBase)item).StringId))
			{
				continue;
			}
			string ownershipContextForAI = instance.GetOwnershipContextForAI(((MBObjectBase)item).StringId);
			bool flag2 = !string.IsNullOrEmpty(ownershipContextForAI) && !ownershipContextForAI.Contains("Historical") && (ownershipContextForAI.Contains(((object)kingdom1.Name).ToString()) || ownershipContextForAI.Contains(((object)kingdom2.Name).ToString()));
			if (flag)
			{
				Kingdom kingdom3 = ((val2 == kingdom1) ? kingdom2 : kingdom1);
				float distanceToNearestKingdomSettlement = GetDistanceToNearestKingdomSettlement(item, kingdom3);
				if (distanceToNearestKingdomSettlement < 250f || flag2)
				{
					list.Add(item);
					hashSet.Add(((MBObjectBase)item).StringId);
				}
				else if (distanceToNearestKingdomSettlement < 400f && item.IsTown)
				{
					list.Add(item);
					hashSet.Add(((MBObjectBase)item).StringId);
				}
			}
			else if (string.IsNullOrEmpty(ownershipContextForAI) || ownershipContextForAI.Contains("Historical"))
			{
				if (IsBorderSettlement(item, kingdom1, kingdom2))
				{
					list.Add(item);
					hashSet.Add(((MBObjectBase)item).StringId);
				}
			}
			else if (flag2)
			{
				list.Add(item);
				hashSet.Add(((MBObjectBase)item).StringId);
			}
		}
		return list;
	}

	private bool IsBorderSettlement(Settlement settlement, Kingdom kingdom1, Kingdom kingdom2)
	{
		if (settlement == null)
		{
			return false;
		}
		Clan ownerClan = settlement.OwnerClan;
		Kingdom val = ((ownerClan != null) ? ownerClan.Kingdom : null);
		if (val == null)
		{
			return false;
		}
		Kingdom kingdom3 = ((val == kingdom1) ? kingdom2 : kingdom1);
		float distanceToNearestKingdomSettlement = GetDistanceToNearestKingdomSettlement(settlement, kingdom3);
		return distanceToNearestKingdomSettlement < 150f;
	}

	public float GetDistanceToNearestKingdomSettlement(Settlement settlement, Kingdom kingdom)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		if (settlement == null || kingdom == null)
		{
			return float.MaxValue;
		}
		float num = float.MaxValue;
		foreach (Settlement item in (List<Settlement>)(object)Settlement.All)
		{
			if (!item.IsTown && !item.IsCastle)
			{
				continue;
			}
			Clan ownerClan = item.OwnerClan;
			if (((ownerClan != null) ? ownerClan.Kingdom : null) == kingdom)
			{
				CampaignVec2 gatePosition = settlement.GatePosition;
				float num2 = ((CampaignVec2)(ref gatePosition)).DistanceSquared(item.GatePosition);
				if (num2 < num)
				{
					num = num2;
				}
			}
		}
		return (num < float.MaxValue) ? ((float)Math.Sqrt(num)) : float.MaxValue;
	}

	public string GetSettlementGeoTag(Settlement settlement, Kingdom ownerKingdom, Kingdom otherKingdom)
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		if (settlement == null || ownerKingdom == null || otherKingdom == null)
		{
			return "UNKNOWN";
		}
		float distanceToNearestKingdomSettlement = GetDistanceToNearestKingdomSettlement(settlement, otherKingdom);
		float distanceToNearestKingdomSettlement2 = GetDistanceToNearestKingdomSettlement(settlement, ownerKingdom);
		Clan ownerClan = settlement.OwnerClan;
		bool flag = ((ownerClan != null) ? ownerClan.Kingdom : null) == ownerKingdom;
		if (flag)
		{
			float num = float.MaxValue;
			foreach (Settlement item in (List<Settlement>)(object)Settlement.All)
			{
				if (item == settlement || (!item.IsTown && !item.IsCastle))
				{
					continue;
				}
				Clan ownerClan2 = item.OwnerClan;
				if (((ownerClan2 != null) ? ownerClan2.Kingdom : null) == ownerKingdom)
				{
					CampaignVec2 gatePosition = settlement.GatePosition;
					float num2 = ((CampaignVec2)(ref gatePosition)).DistanceSquared(item.GatePosition);
					if (num2 < num)
					{
						num = num2;
					}
				}
			}
			distanceToNearestKingdomSettlement2 = ((num < float.MaxValue) ? ((float)Math.Sqrt(num)) : float.MaxValue);
		}
		SettlementOwnershipTracker instance = SettlementOwnershipTracker.Instance;
		SettlementOwnershipHistory ownershipHistory = instance.GetOwnershipHistory(((MBObjectBase)settlement).StringId);
		if (ownershipHistory != null && ownershipHistory.OwnershipChanges.Count > 0 && !flag && distanceToNearestKingdomSettlement > 300f)
		{
			return "DEEP_BEHIND";
		}
		if (distanceToNearestKingdomSettlement < 100f)
		{
			return "BORDER";
		}
		if (distanceToNearestKingdomSettlement < 200f)
		{
			return "NEAR";
		}
		if (distanceToNearestKingdomSettlement < 350f)
		{
			return "MODERATE";
		}
		return "FAR";
	}

	public string GetKingdomBordersOverview(Kingdom kingdom)
	{
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		if (kingdom == null || kingdom.IsEliminated)
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		List<Settlement> list = ((IEnumerable<Settlement>)Settlement.All).Where(delegate(Settlement s)
		{
			int result;
			if (s.IsTown || s.IsCastle)
			{
				Clan ownerClan = s.OwnerClan;
				result = ((((ownerClan != null) ? ownerClan.Kingdom : null) == kingdom) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}).ToList();
		if (!list.Any())
		{
			return "";
		}
		Dictionary<Kingdom, (int, float, string, string)> dictionary = new Dictionary<Kingdom, (int, float, string, string)>();
		foreach (Kingdom otherKingdom in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated && k != kingdom))
		{
			List<Settlement> list2 = ((IEnumerable<Settlement>)Settlement.All).Where(delegate(Settlement s)
			{
				int result;
				if (s.IsTown || s.IsCastle)
				{
					Clan ownerClan = s.OwnerClan;
					result = ((((ownerClan != null) ? ownerClan.Kingdom : null) == otherKingdom) ? 1 : 0);
				}
				else
				{
					result = 0;
				}
				return (byte)result != 0;
			}).ToList();
			if (!list2.Any())
			{
				continue;
			}
			float num = float.MaxValue;
			string item = "";
			string item2 = "";
			int num2 = 0;
			foreach (Settlement item7 in list)
			{
				foreach (Settlement item8 in list2)
				{
					CampaignVec2 gatePosition = item7.GatePosition;
					float num3 = ((CampaignVec2)(ref gatePosition)).Distance(item8.GatePosition);
					if (num3 < num)
					{
						num = num3;
						item = ((object)item7.Name).ToString();
						item2 = ((object)item8.Name).ToString();
					}
					if (num3 < 150f)
					{
						num2++;
					}
				}
			}
			if (num < float.MaxValue)
			{
				dictionary[otherKingdom] = (num2, num, item, item2);
			}
		}
		foreach (KeyValuePair<Kingdom, (int, float, string, string)> item9 in dictionary.OrderBy<KeyValuePair<Kingdom, (int, float, string, string)>, float>((KeyValuePair<Kingdom, (int borderCount, float closestDist, string closestOurs, string closestTheirs)> x) => x.Value.closestDist))
		{
			Kingdom key = item9.Key;
			(int, float, string, string) value = item9.Value;
			int item3 = value.Item1;
			float item4 = value.Item2;
			string item5 = value.Item3;
			string item6 = value.Item4;
			string text = (FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom, (IFaction)(object)key) ? "AT WAR" : "peace");
			if (item4 < 200f)
			{
				stringBuilder.AppendLine($"- {key.Name} (string_id:{((MBObjectBase)key).StringId}) [{text}]: NEIGHBOR, closest ~{item4:F0} ({item5} ↔ {item6}), {item3} border zone pairs");
			}
			else if (item4 < 400f)
			{
				stringBuilder.AppendLine($"- {key.Name} (string_id:{((MBObjectBase)key).StringId}) [{text}]: NEARBY, closest ~{item4:F0} ({item5} ↔ {item6})");
			}
			else
			{
				stringBuilder.AppendLine($"- {key.Name} (string_id:{((MBObjectBase)key).StringId}) [{text}]: DISTANT (~{item4:F0})");
			}
		}
		return stringBuilder.ToString();
	}

	private Clan GetBestClanForSettlement(Kingdom kingdom, Settlement settlement)
	{
		if (kingdom == null || settlement == null)
		{
			return null;
		}
		return kingdom.RulingClan;
	}

	public List<TerritoryTransferRecord> GetTransferHistory(Kingdom kingdom, int maxRecords = 10)
	{
		if (kingdom == null)
		{
			return new List<TerritoryTransferRecord>();
		}
		return TransferHistory.Where((TerritoryTransferRecord t) => t.FromKingdomId == ((MBObjectBase)kingdom).StringId || t.ToKingdomId == ((MBObjectBase)kingdom).StringId).OrderByDescending(delegate(TerritoryTransferRecord t)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			CampaignTime transferTime = t.TransferTime;
			return (transferTime).ElapsedDaysUntilNow;
		}).Take(maxRecords)
			.ToList();
	}

	public List<TerritoryTransferRecord> GetRecentTransfers(int days = 30)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		CampaignTime cutoffTime = CampaignTime.Now - CampaignTime.Days((float)days);
		return TransferHistory.Where(delegate(TerritoryTransferRecord t)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			CampaignTime transferTime = t.TransferTime;
			return (transferTime).ToSeconds >= (cutoffTime).ToSeconds;
		}).OrderByDescending(delegate(TerritoryTransferRecord t)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			CampaignTime transferTime = t.TransferTime;
			return (transferTime).ElapsedDaysUntilNow;
		}).ToList();
	}

	public string GenerateTerritoryTransferSummary(int days = 30)
	{
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		List<TerritoryTransferRecord> recentTransfers = GetRecentTransfers(days);
		if (!recentTransfers.Any())
		{
			return $"No territory transfers in the last {days} days.";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine($"Recent Territory Transfers (last {days} days):");
		foreach (TerritoryTransferRecord transfer in recentTransfers)
		{
			Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == transfer.FromKingdomId));
			Kingdom val2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == transfer.ToKingdomId));
			if (val != null && val2 != null)
			{
				CampaignTime transferTime = transfer.TransferTime;
				float elapsedDaysUntilNow = (transferTime).ElapsedDaysUntilNow;
				stringBuilder.AppendLine($"- {transfer.SettlementName}: {val.Name} → {val2.Name} ({elapsedDaysUntilNow:F0} days ago)");
				stringBuilder.AppendLine("  Reason: " + transfer.Reason);
			}
		}
		return stringBuilder.ToString().TrimEnd(Array.Empty<char>());
	}

	public void CleanOldRecords()
	{
		if (TransferHistory.Count > 100)
		{
			TransferHistory = TransferHistory.OrderByDescending(delegate(TerritoryTransferRecord t)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				CampaignTime transferTime = t.TransferTime;
				return (transferTime).ElapsedDaysUntilNow;
			}).Take(100).ToList();
			SaveData();
			LogMessage("[TERRITORY_TRANSFER] Cleaned old transfer records");
		}
	}

	private void LogMessage(string message)
	{
		AIInfluenceBehavior.Instance?.LogMessage(message);
	}
}
