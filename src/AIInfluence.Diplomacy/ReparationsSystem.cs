using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Diplomacy;

public class ReparationsSystem
{
	private static ReparationsSystem _instance;

	private readonly DiplomacyStorage _storage;

	public static ReparationsSystem Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new ReparationsSystem();
			}
			return _instance;
		}
	}

	[JsonProperty("reparations_history")]
	public List<ReparationRecord> ReparationsHistory { get; set; } = new List<ReparationRecord>();

	[JsonProperty("pending_demands")]
	public Dictionary<string, ReparationDemand> PendingDemands { get; set; } = new Dictionary<string, ReparationDemand>();

	private ReparationsSystem()
	{
		_storage = new DiplomacyStorage();
	}

	public static void Reset()
	{
		if (_instance != null)
		{
			_instance.ReparationsHistory.Clear();
			_instance.PendingDemands.Clear();
			AIInfluenceBehavior.Instance?.LogMessage("[REPARATIONS] Reparations system state reset for new campaign");
		}
		_instance = null;
	}

	public void Initialize()
	{
		LogMessage("[REPARATIONS] Initializing reparations system...");
		ReparationsHistory.Clear();
		PendingDemands.Clear();
		LoadData();
		CleanExpiredDemands();
		LogMessage($"[REPARATIONS] System initialized with {ReparationsHistory.Count} historical payments and {PendingDemands.Count} pending demands");
	}

	public void SaveData()
	{
		_storage.SaveReparations(this);
	}

	private void LoadData()
	{
		_storage.LoadReparations(this);
	}

	public bool DemandReparations(Kingdom demandingKingdom, Kingdom payingKingdom, int amount, string reason)
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		if (demandingKingdom == null || payingKingdom == null)
		{
			LogMessage("[REPARATIONS] ERROR: Invalid kingdoms for reparation demand");
			return false;
		}
		if (demandingKingdom == payingKingdom)
		{
			LogMessage("[REPARATIONS] ERROR: Cannot demand reparations from yourself");
			return false;
		}
		if (amount <= 0)
		{
			LogMessage("[REPARATIONS] ERROR: Invalid reparation amount");
			return false;
		}
		string demandKey = GetDemandKey(((MBObjectBase)demandingKingdom).StringId, ((MBObjectBase)payingKingdom).StringId);
		ReparationDemand value = new ReparationDemand
		{
			DemandingKingdomId = ((MBObjectBase)demandingKingdom).StringId,
			PayingKingdomId = ((MBObjectBase)payingKingdom).StringId,
			Amount = amount,
			DemandTime = CampaignTime.Now,
			ExpirationTime = CampaignTime.Now + CampaignTime.Days(30f),
			Reason = reason,
			Status = ReparationStatus.Pending
		};
		PendingDemands[demandKey] = value;
		SaveData();
		DiplomacyLogger.Instance.LogDiplomaticAction("reparations_demanded", ((MBObjectBase)demandingKingdom).StringId, ((MBObjectBase)payingKingdom).StringId, $"Reparations demanded: {amount} gold. Reason: {reason}");
		LogMessage($"[REPARATIONS] {demandingKingdom.Name} demands {amount} gold reparations from {payingKingdom.Name}");
		LogMessage("[REPARATIONS] Reason: " + reason);
		return true;
	}

	public bool PayReparations(Kingdom payingKingdom, Kingdom receivingKingdom, int amount, string reason)
	{
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		if (payingKingdom == null || receivingKingdom == null)
		{
			LogMessage("[REPARATIONS] ERROR: Invalid kingdoms for reparation payment");
			return false;
		}
		if (amount <= 0)
		{
			LogMessage("[REPARATIONS] ERROR: Invalid payment amount");
			return false;
		}
		Hero leader = payingKingdom.Leader;
		if (leader != null && leader.Gold < amount)
		{
			Hero leader2 = payingKingdom.Leader;
			int num = ((leader2 != null) ? leader2.Gold : 0);
			LogMessage($"[REPARATIONS] WARNING: {payingKingdom.Name} cannot afford full {amount} gold, paying {num} gold");
			amount = num;
			if (amount == 0)
			{
				LogMessage($"[REPARATIONS] ERROR: {payingKingdom.Name} has no gold to pay reparations");
				return false;
			}
		}
		try
		{
			GiveGoldAction.ApplyBetweenCharacters(payingKingdom.Leader, receivingKingdom.Leader, amount, true);
			ReparationRecord item = new ReparationRecord
			{
				PayingKingdomId = ((MBObjectBase)payingKingdom).StringId,
				ReceivingKingdomId = ((MBObjectBase)receivingKingdom).StringId,
				Amount = amount,
				PaymentTime = CampaignTime.Now,
				Reason = reason
			};
			ReparationsHistory.Add(item);
			string demandKey = GetDemandKey(((MBObjectBase)receivingKingdom).StringId, ((MBObjectBase)payingKingdom).StringId);
			if (PendingDemands.ContainsKey(demandKey))
			{
				PendingDemands[demandKey].Status = ReparationStatus.Paid;
				PendingDemands.Remove(demandKey);
			}
			SaveData();
			DiplomacyLogger.Instance.LogDiplomaticAction("reparations_paid", ((MBObjectBase)payingKingdom).StringId, ((MBObjectBase)receivingKingdom).StringId, $"Reparations paid: {amount} gold. Reason: {reason}");
			LogMessage($"[REPARATIONS] {payingKingdom.Name} paid {amount} gold reparations to {receivingKingdom.Name}");
			return true;
		}
		catch (Exception ex)
		{
			LogMessage("[REPARATIONS] ERROR during payment: " + ex.Message);
			return false;
		}
	}

	public void RejectReparations(Kingdom demandingKingdom, Kingdom payingKingdom)
	{
		if (demandingKingdom != null && payingKingdom != null)
		{
			string demandKey = GetDemandKey(((MBObjectBase)demandingKingdom).StringId, ((MBObjectBase)payingKingdom).StringId);
			if (PendingDemands.ContainsKey(demandKey))
			{
				PendingDemands[demandKey].Status = ReparationStatus.Rejected;
				PendingDemands.Remove(demandKey);
				SaveData();
				DiplomacyLogger.Instance.LogDiplomaticAction("reparations_rejected", ((MBObjectBase)payingKingdom).StringId, ((MBObjectBase)demandingKingdom).StringId, "Reparation demand rejected");
				LogMessage($"[REPARATIONS] {payingKingdom.Name} rejected reparation demand from {demandingKingdom.Name}");
			}
		}
	}

	public ReparationDemand GetPendingDemand(Kingdom demandingKingdom, Kingdom payingKingdom)
	{
		if (demandingKingdom == null || payingKingdom == null)
		{
			return null;
		}
		string demandKey = GetDemandKey(((MBObjectBase)demandingKingdom).StringId, ((MBObjectBase)payingKingdom).StringId);
		return PendingDemands.ContainsKey(demandKey) ? PendingDemands[demandKey] : null;
	}

	public List<ReparationDemand> GetPendingDemandsForPayer(Kingdom kingdom)
	{
		if (kingdom == null)
		{
			return new List<ReparationDemand>();
		}
		return PendingDemands.Values.Where(delegate(ReparationDemand d)
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			int result;
			if (d.PayingKingdomId == ((MBObjectBase)kingdom).StringId)
			{
				CampaignTime expirationTime = d.ExpirationTime;
				result = (((CampaignTime)(ref expirationTime)).IsFuture ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}).ToList();
	}

	public List<ReparationDemand> GetDemandsMadeBy(Kingdom kingdom)
	{
		if (kingdom == null)
		{
			return new List<ReparationDemand>();
		}
		return PendingDemands.Values.Where(delegate(ReparationDemand d)
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			int result;
			if (d.DemandingKingdomId == ((MBObjectBase)kingdom).StringId)
			{
				CampaignTime expirationTime = d.ExpirationTime;
				result = (((CampaignTime)(ref expirationTime)).IsFuture ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}).ToList();
	}

	public List<ReparationRecord> GetPaymentHistory(Kingdom kingdom, int maxRecords = 10)
	{
		if (kingdom == null)
		{
			return new List<ReparationRecord>();
		}
		return ReparationsHistory.Where((ReparationRecord r) => r.PayingKingdomId == ((MBObjectBase)kingdom).StringId || r.ReceivingKingdomId == ((MBObjectBase)kingdom).StringId).OrderByDescending(delegate(ReparationRecord r)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			CampaignTime paymentTime = r.PaymentTime;
			return ((CampaignTime)(ref paymentTime)).ElapsedDaysUntilNow;
		}).Take(maxRecords)
			.ToList();
	}

	public int GetTotalPaidBy(Kingdom kingdom, int days = 365)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		if (kingdom == null)
		{
			return 0;
		}
		CampaignTime cutoffTime = CampaignTime.Now - CampaignTime.Days((float)days);
		return ReparationsHistory.Where(delegate(ReparationRecord r)
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			int result;
			if (r.PayingKingdomId == ((MBObjectBase)kingdom).StringId)
			{
				CampaignTime paymentTime = r.PaymentTime;
				result = ((((CampaignTime)(ref paymentTime)).ToSeconds >= ((CampaignTime)(ref cutoffTime)).ToSeconds) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}).Sum((ReparationRecord r) => r.Amount);
	}

	public int GetTotalReceivedBy(Kingdom kingdom, int days = 365)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		if (kingdom == null)
		{
			return 0;
		}
		CampaignTime cutoffTime = CampaignTime.Now - CampaignTime.Days((float)days);
		return ReparationsHistory.Where(delegate(ReparationRecord r)
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			int result;
			if (r.ReceivingKingdomId == ((MBObjectBase)kingdom).StringId)
			{
				CampaignTime paymentTime = r.PaymentTime;
				result = ((((CampaignTime)(ref paymentTime)).ToSeconds >= ((CampaignTime)(ref cutoffTime)).ToSeconds) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}).Sum((ReparationRecord r) => r.Amount);
	}

	private void CleanExpiredDemands()
	{
		List<string> list = (from kvp in PendingDemands.Where(delegate(KeyValuePair<string, ReparationDemand> kvp)
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				CampaignTime expirationTime = kvp.Value.ExpirationTime;
				return ((CampaignTime)(ref expirationTime)).IsPast;
			})
			select kvp.Key).ToList();
		foreach (string item in list)
		{
			LogMessage("[REPARATIONS] Removing expired demand: " + item);
			PendingDemands[item].Status = ReparationStatus.Expired;
			PendingDemands.Remove(item);
		}
		if (list.Any())
		{
			SaveData();
		}
	}

	public void OnDailyTick()
	{
		CleanExpiredDemands();
	}

	public void OnKingdomDestroyed(Kingdom kingdom)
	{
		if (kingdom == null)
		{
			return;
		}
		List<string> list = (from kvp in PendingDemands
			where kvp.Value.DemandingKingdomId == ((MBObjectBase)kingdom).StringId || kvp.Value.PayingKingdomId == ((MBObjectBase)kingdom).StringId
			select kvp.Key).ToList();
		foreach (string item in list)
		{
			PendingDemands.Remove(item);
		}
		if (list.Any())
		{
			LogMessage($"[REPARATIONS] Removed {list.Count} pending demands for destroyed kingdom: {kingdom.Name}");
			SaveData();
		}
	}

	public string GenerateReparationsSummary()
	{
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Unknown result type (might be due to invalid IL or missing references)
		StringBuilder stringBuilder = new StringBuilder();
		CampaignTime val3;
		if (PendingDemands.Any())
		{
			stringBuilder.AppendLine("Pending Reparation Demands:");
			foreach (ReparationDemand demand in PendingDemands.Values.Where(delegate(ReparationDemand d)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				CampaignTime expirationTime = d.ExpirationTime;
				return ((CampaignTime)(ref expirationTime)).IsFuture;
			}))
			{
				Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == demand.DemandingKingdomId));
				Kingdom val2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == demand.PayingKingdomId));
				if (val != null && val2 != null)
				{
					val3 = demand.ExpirationTime;
					float remainingDaysFromNow = ((CampaignTime)(ref val3)).RemainingDaysFromNow;
					stringBuilder.AppendLine($"- {val.Name} demands {demand.Amount} gold from {val2.Name} (expires in {remainingDaysFromNow:F0} days)");
					stringBuilder.AppendLine("  Reason: " + demand.Reason);
				}
			}
		}
		List<ReparationRecord> list = ReparationsHistory.Where(delegate(ReparationRecord r)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			CampaignTime paymentTime = r.PaymentTime;
			return ((CampaignTime)(ref paymentTime)).ElapsedDaysUntilNow <= 30f;
		}).OrderByDescending(delegate(ReparationRecord r)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			CampaignTime paymentTime = r.PaymentTime;
			return ((CampaignTime)(ref paymentTime)).ElapsedDaysUntilNow;
		}).ToList();
		if (list.Any())
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.AppendLine();
			}
			stringBuilder.AppendLine("Recent Reparation Payments (last 30 days):");
			foreach (ReparationRecord payment in list)
			{
				Kingdom val4 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == payment.PayingKingdomId));
				Kingdom val5 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == payment.ReceivingKingdomId));
				if (val4 != null && val5 != null)
				{
					val3 = payment.PaymentTime;
					float elapsedDaysUntilNow = ((CampaignTime)(ref val3)).ElapsedDaysUntilNow;
					stringBuilder.AppendLine($"- {val4.Name} → {val5.Name}: {payment.Amount} gold ({elapsedDaysUntilNow:F0} days ago)");
					stringBuilder.AppendLine("  Reason: " + payment.Reason);
				}
			}
		}
		return (stringBuilder.Length > 0) ? stringBuilder.ToString().TrimEnd(Array.Empty<char>()) : "No reparation demands or recent payments.";
	}

	public void CleanOldRecords()
	{
		if (ReparationsHistory.Count > 100)
		{
			ReparationsHistory = ReparationsHistory.OrderByDescending(delegate(ReparationRecord r)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				CampaignTime paymentTime = r.PaymentTime;
				return ((CampaignTime)(ref paymentTime)).ElapsedDaysUntilNow;
			}).Take(100).ToList();
			SaveData();
			LogMessage("[REPARATIONS] Cleaned old reparation records");
		}
	}

	private string GetDemandKey(string demandingKingdomId, string payingKingdomId)
	{
		return demandingKingdomId + "_demands_from_" + payingKingdomId;
	}

	private void LogMessage(string message)
	{
		AIInfluenceBehavior.Instance?.LogMessage(message);
	}
}
