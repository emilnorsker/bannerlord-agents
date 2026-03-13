using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Diplomacy;

public class TributeSystem
{
	private static TributeSystem _instance;

	private readonly DiplomacyStorage _storage;

	public static TributeSystem Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new TributeSystem();
			}
			return _instance;
		}
	}

	[JsonProperty("tributes")]
	public Dictionary<string, TributeAgreement> Tributes { get; set; } = new Dictionary<string, TributeAgreement>();

	[JsonProperty("tribute_history")]
	public List<TributeRecord> TributeHistory { get; set; } = new List<TributeRecord>();

	private TributeSystem()
	{
		_storage = new DiplomacyStorage();
	}

	public static void Reset()
	{
		if (_instance != null)
		{
			_instance.Tributes.Clear();
			_instance.TributeHistory.Clear();
			AIInfluenceBehavior.Instance?.LogMessage("[TRIBUTE] Tribute system state reset for new campaign");
		}
		_instance = null;
	}

	public void Initialize()
	{
		LogMessage("[TRIBUTE] Initializing tribute system...");
		Tributes.Clear();
		TributeHistory.Clear();
		LoadData();
		CleanExpiredTributes();
		LogMessage($"[TRIBUTE] System initialized with {Tributes.Count} active tribute agreements and {TributeHistory.Count} historical records");
	}

	public void SaveData()
	{
		_storage.SaveTributes(this);
	}

	private void LoadData()
	{
		_storage.LoadTributes(this);
	}

	public bool EstablishTribute(Kingdom payerKingdom, Kingdom receiverKingdom, int dailyAmount, int durationDays, string reason)
	{
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		if (payerKingdom == null || receiverKingdom == null)
		{
			LogMessage("[TRIBUTE] ERROR: Invalid kingdoms for tribute");
			return false;
		}
		if (payerKingdom == receiverKingdom)
		{
			LogMessage("[TRIBUTE] ERROR: Cannot establish tribute to the same kingdom");
			return false;
		}
		if (dailyAmount <= 0 || durationDays <= 0)
		{
			LogMessage("[TRIBUTE] ERROR: Invalid tribute amount or duration");
			return false;
		}
		string tributeKey = GetTributeKey(((MBObjectBase)payerKingdom).StringId, ((MBObjectBase)receiverKingdom).StringId);
		if (Tributes.ContainsKey(tributeKey))
		{
			LogMessage($"[TRIBUTE] Tribute already exists from {payerKingdom.Name} to {receiverKingdom.Name}, updating...");
			EndTribute(payerKingdom, receiverKingdom);
		}
		TributeAgreement value = new TributeAgreement
		{
			PayerKingdomId = ((MBObjectBase)payerKingdom).StringId,
			ReceiverKingdomId = ((MBObjectBase)receiverKingdom).StringId,
			DailyAmount = dailyAmount,
			StartTime = CampaignTime.Now,
			EndTime = CampaignTime.Now + CampaignTime.Days((float)durationDays),
			DurationDays = durationDays,
			TotalPaid = 0,
			LastPaymentTime = CampaignTime.Now,
			Reason = reason
		};
		Tributes[tributeKey] = value;
		SaveData();
		DiplomacyLogger.Instance.LogDiplomaticAction("tribute_established", ((MBObjectBase)payerKingdom).StringId, ((MBObjectBase)receiverKingdom).StringId, $"Tribute: {dailyAmount} gold/day for {durationDays} days. Reason: {reason}");
		LogMessage($"[TRIBUTE] Tribute established: {payerKingdom.Name} → {receiverKingdom.Name}");
		LogMessage($"[TRIBUTE] Amount: {dailyAmount} gold/day for {durationDays} days");
		LogMessage("[TRIBUTE] Reason: " + reason);
		return true;
	}

	public void EndTribute(Kingdom payerKingdom, Kingdom receiverKingdom)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		if (payerKingdom != null && receiverKingdom != null)
		{
			string tributeKey = GetTributeKey(((MBObjectBase)payerKingdom).StringId, ((MBObjectBase)receiverKingdom).StringId);
			if (Tributes.ContainsKey(tributeKey))
			{
				TributeAgreement tributeAgreement = Tributes[tributeKey];
				TributeRecord item = new TributeRecord
				{
					PayerKingdomId = tributeAgreement.PayerKingdomId,
					ReceiverKingdomId = tributeAgreement.ReceiverKingdomId,
					DailyAmount = tributeAgreement.DailyAmount,
					StartTime = tributeAgreement.StartTime,
					EndTime = tributeAgreement.EndTime,
					DurationDays = tributeAgreement.DurationDays,
					TotalPaid = tributeAgreement.TotalPaid,
					Reason = tributeAgreement.Reason
				};
				TributeHistory.Add(item);
				Tributes.Remove(tributeKey);
				SaveData();
				DiplomacyLogger.Instance.LogDiplomaticAction("tribute_ended", ((MBObjectBase)payerKingdom).StringId, ((MBObjectBase)receiverKingdom).StringId, $"Tribute ended. Total paid: {tributeAgreement.TotalPaid} gold");
				LogMessage($"[TRIBUTE] Tribute ended: {payerKingdom.Name} → {receiverKingdom.Name}");
				LogMessage($"[TRIBUTE] Total amount paid: {tributeAgreement.TotalPaid} gold");
				LogMessage("[TRIBUTE] Saved to history");
			}
		}
	}

	public void ProcessDailyPayments()
	{
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, TributeAgreement> item2 in Tributes.ToList())
		{
			TributeAgreement tribute = item2.Value;
			string key = item2.Key;
			CampaignTime endTime = tribute.EndTime;
			if (((CampaignTime)(ref endTime)).IsPast)
			{
				LogMessage("[TRIBUTE] Tribute expired: " + key);
				list.Add(key);
				continue;
			}
			Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == tribute.PayerKingdomId));
			Kingdom val2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == tribute.ReceiverKingdomId));
			if (val == null || val.IsEliminated)
			{
				LogMessage("[TRIBUTE] Payer kingdom eliminated or not found, ending tribute: " + key);
				list.Add(key);
			}
			else if (val2 == null || val2.IsEliminated)
			{
				LogMessage("[TRIBUTE] Receiver kingdom eliminated or not found, ending tribute: " + key);
				list.Add(key);
			}
			else if (val.IsAtWarWith((IFaction)(object)val2))
			{
				LogMessage($"[TRIBUTE] War declared, ending tribute: {val.Name} → {val2.Name}");
				list.Add(key);
			}
			else if (!ProcessTributePayment(val, val2, tribute))
			{
				LogMessage("[TRIBUTE] Payment failed for " + key + ", tribute will continue");
			}
		}
		foreach (string item3 in list)
		{
			TributeAgreement tributeAgreement = Tributes[item3];
			TributeRecord item = new TributeRecord
			{
				PayerKingdomId = tributeAgreement.PayerKingdomId,
				ReceiverKingdomId = tributeAgreement.ReceiverKingdomId,
				DailyAmount = tributeAgreement.DailyAmount,
				StartTime = tributeAgreement.StartTime,
				EndTime = tributeAgreement.EndTime,
				DurationDays = tributeAgreement.DurationDays,
				TotalPaid = tributeAgreement.TotalPaid,
				Reason = tributeAgreement.Reason
			};
			TributeHistory.Add(item);
			Tributes.Remove(item3);
		}
		if (list.Any())
		{
			SaveData();
		}
	}

	private bool ProcessTributePayment(Kingdom payerKingdom, Kingdom receiverKingdom, TributeAgreement tribute)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		CampaignTime val = CampaignTime.Now - tribute.LastPaymentTime;
		float num = (float)((CampaignTime)(ref val)).ToHours;
		if (num < 24f)
		{
			return true;
		}
		int num2 = tribute.DailyAmount;
		Hero leader = payerKingdom.Leader;
		if (leader != null && leader.Gold < num2)
		{
			Hero leader2 = payerKingdom.Leader;
			num2 = Math.Max(0, (leader2 != null) ? leader2.Gold : 0);
			if (num2 == 0)
			{
				LogMessage($"[TRIBUTE] WARNING: {payerKingdom.Name} cannot afford tribute payment to {receiverKingdom.Name}");
				return false;
			}
		}
		try
		{
			GiveGoldAction.ApplyBetweenCharacters(payerKingdom.Leader, receiverKingdom.Leader, num2, true);
			tribute.TotalPaid += num2;
			tribute.LastPaymentTime = CampaignTime.Now;
			SaveData();
			val = tribute.EndTime;
			float remainingDaysFromNow = ((CampaignTime)(ref val)).RemainingDaysFromNow;
			LogMessage($"[TRIBUTE] Payment processed: {payerKingdom.Name} → {receiverKingdom.Name}: {num2} gold ({remainingDaysFromNow:F0} days remaining)");
			return true;
		}
		catch (Exception ex)
		{
			LogMessage("[TRIBUTE] ERROR during payment: " + ex.Message);
			return false;
		}
	}

	public List<TributeAgreement> GetTributesForKingdom(Kingdom kingdom)
	{
		if (kingdom == null)
		{
			return new List<TributeAgreement>();
		}
		return Tributes.Values.Where(delegate(TributeAgreement t)
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			int result;
			if (t.PayerKingdomId == ((MBObjectBase)kingdom).StringId || t.ReceiverKingdomId == ((MBObjectBase)kingdom).StringId)
			{
				CampaignTime endTime = t.EndTime;
				result = (((CampaignTime)(ref endTime)).IsFuture ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}).ToList();
	}

	public List<TributeAgreement> GetTributesPaidBy(Kingdom kingdom)
	{
		if (kingdom == null)
		{
			return new List<TributeAgreement>();
		}
		return Tributes.Values.Where(delegate(TributeAgreement t)
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			int result;
			if (t.PayerKingdomId == ((MBObjectBase)kingdom).StringId)
			{
				CampaignTime endTime = t.EndTime;
				result = (((CampaignTime)(ref endTime)).IsFuture ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}).ToList();
	}

	public List<TributeAgreement> GetTributesReceivedBy(Kingdom kingdom)
	{
		if (kingdom == null)
		{
			return new List<TributeAgreement>();
		}
		return Tributes.Values.Where(delegate(TributeAgreement t)
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			int result;
			if (t.ReceiverKingdomId == ((MBObjectBase)kingdom).StringId)
			{
				CampaignTime endTime = t.EndTime;
				result = (((CampaignTime)(ref endTime)).IsFuture ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}).ToList();
	}

	public bool HasTribute(Kingdom payerKingdom, Kingdom receiverKingdom)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		if (payerKingdom == null || receiverKingdom == null)
		{
			return false;
		}
		string tributeKey = GetTributeKey(((MBObjectBase)payerKingdom).StringId, ((MBObjectBase)receiverKingdom).StringId);
		int result;
		if (Tributes.ContainsKey(tributeKey))
		{
			CampaignTime endTime = Tributes[tributeKey].EndTime;
			result = (((CampaignTime)(ref endTime)).IsFuture ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	private void CleanExpiredTributes()
	{
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		List<string> list = (from kvp in Tributes.Where(delegate(KeyValuePair<string, TributeAgreement> kvp)
			{
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				//IL_000c: Unknown result type (might be due to invalid IL or missing references)
				CampaignTime endTime = kvp.Value.EndTime;
				return ((CampaignTime)(ref endTime)).IsPast;
			})
			select kvp.Key).ToList();
		foreach (string item2 in list)
		{
			TributeAgreement tributeAgreement = Tributes[item2];
			LogMessage("[TRIBUTE] Removing expired tribute: " + item2);
			TributeRecord item = new TributeRecord
			{
				PayerKingdomId = tributeAgreement.PayerKingdomId,
				ReceiverKingdomId = tributeAgreement.ReceiverKingdomId,
				DailyAmount = tributeAgreement.DailyAmount,
				StartTime = tributeAgreement.StartTime,
				EndTime = tributeAgreement.EndTime,
				DurationDays = tributeAgreement.DurationDays,
				TotalPaid = tributeAgreement.TotalPaid,
				Reason = tributeAgreement.Reason
			};
			TributeHistory.Add(item);
			Tributes.Remove(item2);
		}
		if (list.Any())
		{
			SaveData();
		}
	}

	public void OnWarDeclared(Kingdom kingdom1, Kingdom kingdom2)
	{
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		string tributeKey = GetTributeKey(((MBObjectBase)kingdom1).StringId, ((MBObjectBase)kingdom2).StringId);
		string tributeKey2 = GetTributeKey(((MBObjectBase)kingdom2).StringId, ((MBObjectBase)kingdom1).StringId);
		bool flag = false;
		if (Tributes.ContainsKey(tributeKey))
		{
			TributeAgreement tributeAgreement = Tributes[tributeKey];
			LogMessage($"[TRIBUTE] War declared, ending tribute: {kingdom1.Name} → {kingdom2.Name}");
			TributeRecord item = new TributeRecord
			{
				PayerKingdomId = tributeAgreement.PayerKingdomId,
				ReceiverKingdomId = tributeAgreement.ReceiverKingdomId,
				DailyAmount = tributeAgreement.DailyAmount,
				StartTime = tributeAgreement.StartTime,
				EndTime = CampaignTime.Now,
				DurationDays = tributeAgreement.DurationDays,
				TotalPaid = tributeAgreement.TotalPaid,
				Reason = "Ended due to war: " + tributeAgreement.Reason
			};
			TributeHistory.Add(item);
			Tributes.Remove(tributeKey);
			flag = true;
		}
		if (Tributes.ContainsKey(tributeKey2))
		{
			TributeAgreement tributeAgreement2 = Tributes[tributeKey2];
			LogMessage($"[TRIBUTE] War declared, ending tribute: {kingdom2.Name} → {kingdom1.Name}");
			TributeRecord item2 = new TributeRecord
			{
				PayerKingdomId = tributeAgreement2.PayerKingdomId,
				ReceiverKingdomId = tributeAgreement2.ReceiverKingdomId,
				DailyAmount = tributeAgreement2.DailyAmount,
				StartTime = tributeAgreement2.StartTime,
				EndTime = CampaignTime.Now,
				DurationDays = tributeAgreement2.DurationDays,
				TotalPaid = tributeAgreement2.TotalPaid,
				Reason = "Ended due to war: " + tributeAgreement2.Reason
			};
			TributeHistory.Add(item2);
			Tributes.Remove(tributeKey2);
			flag = true;
		}
		if (flag)
		{
			SaveData();
		}
	}

	public void OnKingdomDestroyed(Kingdom kingdom)
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		if (kingdom == null)
		{
			return;
		}
		List<KeyValuePair<string, TributeAgreement>> list = Tributes.Where((KeyValuePair<string, TributeAgreement> kvp) => kvp.Value.PayerKingdomId == ((MBObjectBase)kingdom).StringId || kvp.Value.ReceiverKingdomId == ((MBObjectBase)kingdom).StringId).ToList();
		foreach (KeyValuePair<string, TributeAgreement> item2 in list)
		{
			TributeAgreement value = item2.Value;
			TributeRecord item = new TributeRecord
			{
				PayerKingdomId = value.PayerKingdomId,
				ReceiverKingdomId = value.ReceiverKingdomId,
				DailyAmount = value.DailyAmount,
				StartTime = value.StartTime,
				EndTime = CampaignTime.Now,
				DurationDays = value.DurationDays,
				TotalPaid = value.TotalPaid,
				Reason = "Ended due to kingdom destruction: " + value.Reason
			};
			TributeHistory.Add(item);
			Tributes.Remove(item2.Key);
		}
		if (list.Any())
		{
			LogMessage($"[TRIBUTE] Removed {list.Count} tribute agreements for destroyed kingdom: {kingdom.Name}");
			SaveData();
		}
	}

	public List<TributeRecord> GetTributeHistory(Kingdom kingdom, int maxRecords = 10)
	{
		if (kingdom == null)
		{
			return new List<TributeRecord>();
		}
		return TributeHistory.Where((TributeRecord r) => r.PayerKingdomId == ((MBObjectBase)kingdom).StringId || r.ReceiverKingdomId == ((MBObjectBase)kingdom).StringId).OrderByDescending(delegate(TributeRecord r)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			CampaignTime endTime = r.EndTime;
			return ((CampaignTime)(ref endTime)).ElapsedDaysUntilNow;
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
		return TributeHistory.Where(delegate(TributeRecord r)
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			int result;
			if (r.PayerKingdomId == ((MBObjectBase)kingdom).StringId)
			{
				CampaignTime endTime = r.EndTime;
				result = ((((CampaignTime)(ref endTime)).ToSeconds >= ((CampaignTime)(ref cutoffTime)).ToSeconds) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}).Sum((TributeRecord r) => r.TotalPaid);
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
		return TributeHistory.Where(delegate(TributeRecord r)
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			int result;
			if (r.ReceiverKingdomId == ((MBObjectBase)kingdom).StringId)
			{
				CampaignTime endTime = r.EndTime;
				result = ((((CampaignTime)(ref endTime)).ToSeconds >= ((CampaignTime)(ref cutoffTime)).ToSeconds) ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}).Sum((TributeRecord r) => r.TotalPaid);
	}

	public void CleanOldRecords()
	{
		if (TributeHistory.Count > 100)
		{
			TributeHistory = TributeHistory.OrderByDescending(delegate(TributeRecord r)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				CampaignTime endTime = r.EndTime;
				return ((CampaignTime)(ref endTime)).ElapsedDaysUntilNow;
			}).Take(100).ToList();
			SaveData();
			LogMessage("[TRIBUTE] Cleaned old tribute records");
		}
	}

	public string GenerateTributeSummary()
	{
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		if (!Tributes.Any())
		{
			return "No active tribute agreements.";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("Active Tribute Agreements:");
		foreach (TributeAgreement tribute in Tributes.Values.Where(delegate(TributeAgreement t)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			CampaignTime endTime2 = t.EndTime;
			return ((CampaignTime)(ref endTime2)).IsFuture;
		}))
		{
			Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == tribute.PayerKingdomId));
			Kingdom val2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == tribute.ReceiverKingdomId));
			if (val != null && val2 != null)
			{
				CampaignTime endTime = tribute.EndTime;
				float remainingDaysFromNow = ((CampaignTime)(ref endTime)).RemainingDaysFromNow;
				int num = (int)(remainingDaysFromNow * (float)tribute.DailyAmount);
				stringBuilder.AppendLine($"- {val.Name} → {val2.Name}: {tribute.DailyAmount} gold/day ({remainingDaysFromNow:F0} days left, ~{num} gold remaining)");
				stringBuilder.AppendLine($"  Total paid so far: {tribute.TotalPaid} gold");
				stringBuilder.AppendLine("  Reason: " + tribute.Reason);
			}
		}
		return stringBuilder.ToString().TrimEnd(Array.Empty<char>());
	}

	private string GetTributeKey(string payerKingdomId, string receiverKingdomId)
	{
		return payerKingdomId + "_" + receiverKingdomId;
	}

	private void LogMessage(string message)
	{
		AIInfluenceBehavior.Instance?.LogMessage(message);
	}
}
