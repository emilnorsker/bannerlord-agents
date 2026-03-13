using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Diplomacy;

public class TradeAgreementSystem
{
	private static TradeAgreementSystem _instance;

	private readonly DiplomacyStorage _storage;

	private ITradeAgreementsCampaignBehavior _vanillaBehavior;

	public static TradeAgreementSystem Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new TradeAgreementSystem();
			}
			return _instance;
		}
	}

	[JsonProperty("trade_agreements")]
	public Dictionary<string, TradeAgreementInfo> TradeAgreements { get; set; } = new Dictionary<string, TradeAgreementInfo>();

	private TradeAgreementSystem()
	{
		_storage = new DiplomacyStorage();
	}

	public static void Reset()
	{
		if (_instance != null)
		{
			_instance.TradeAgreements.Clear();
			_instance._vanillaBehavior = null;
			AIInfluenceBehavior.Instance?.LogMessage("[TRADE_AGREEMENT] Trade agreement system state reset for new campaign");
		}
		_instance = null;
	}

	public void Initialize()
	{
		LogMessage("[TRADE_AGREEMENT] Initializing trade agreement system...");
		TradeAgreements.Clear();
		Campaign current = Campaign.Current;
		_vanillaBehavior = ((current != null) ? current.GetCampaignBehavior<ITradeAgreementsCampaignBehavior>() : null);
		if (_vanillaBehavior == null)
		{
			LogMessage("[TRADE_AGREEMENT] WARNING: Could not find vanilla ITradeAgreementsCampaignBehavior");
		}
		LoadData();
		CleanExpiredAgreements();
		SynchronizeTradeAgreements();
		LogMessage($"[TRADE_AGREEMENT] Trade agreement system initialized with {TradeAgreements.Count} active agreements");
	}

	public void SaveData()
	{
		_storage.SaveTradeAgreements(this);
	}

	private void LoadData()
	{
		_storage.LoadTradeAgreements(this);
	}

	public bool HasTradeAgreement(Kingdom kingdom1, Kingdom kingdom2, out CampaignTime endTime)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		endTime = CampaignTime.Never;
		if (kingdom1 == null || kingdom2 == null || kingdom1 == kingdom2)
		{
			return false;
		}
		if (_vanillaBehavior != null && _vanillaBehavior.HasTradeAgreement(kingdom1, kingdom2))
		{
			endTime = _vanillaBehavior.GetTradeAgreementEndDate(kingdom1, kingdom2);
			return true;
		}
		string agreementKey = GetAgreementKey(((MBObjectBase)kingdom1).StringId, ((MBObjectBase)kingdom2).StringId);
		if (TradeAgreements.ContainsKey(agreementKey))
		{
			TradeAgreementInfo tradeAgreementInfo = TradeAgreements[agreementKey];
			CampaignTime endTime2 = tradeAgreementInfo.EndTime;
			if (((CampaignTime)(ref endTime2)).IsFuture)
			{
				endTime = tradeAgreementInfo.EndTime;
				return true;
			}
			TradeAgreements.Remove(agreementKey);
			SaveData();
		}
		return false;
	}

	public void CreateTradeAgreement(Kingdom kingdom1, Kingdom kingdom2, float durationYears = 1f)
	{
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		if (kingdom1 == null || kingdom2 == null || kingdom1 == kingdom2)
		{
			LogMessage("[TRADE_AGREEMENT] Cannot create agreement: invalid kingdoms");
			return;
		}
		if (kingdom1.IsAtWarWith((IFaction)(object)kingdom2))
		{
			LogMessage($"[TRADE_AGREEMENT] Cannot create agreement: {kingdom1.Name} and {kingdom2.Name} are at war");
			return;
		}
		if (HasTradeAgreement(kingdom1, kingdom2, out var _))
		{
			LogMessage($"[TRADE_AGREEMENT] Trade agreement already exists between {kingdom1.Name} and {kingdom2.Name}, extending by {durationYears} years");
			ExtendTradeAgreement(kingdom1, kingdom2, durationYears);
			return;
		}
		if (_vanillaBehavior != null)
		{
			CampaignTime duration = CampaignTime.Years(durationYears);
			DiplomacyPatches.WithBypass(delegate
			{
				//IL_0028: Unknown result type (might be due to invalid IL or missing references)
				_vanillaBehavior.MakeTradeAgreement(kingdom1, kingdom2, duration);
			});
			LogMessage($"[TRADE_AGREEMENT] Created vanilla trade agreement: {kingdom1.Name} ↔ {kingdom2.Name} for {durationYears} years");
		}
		string agreementKey = GetAgreementKey(((MBObjectBase)kingdom1).StringId, ((MBObjectBase)kingdom2).StringId);
		TradeAgreements[agreementKey] = new TradeAgreementInfo
		{
			Kingdom1Id = ((MBObjectBase)kingdom1).StringId,
			Kingdom2Id = ((MBObjectBase)kingdom2).StringId,
			StartTime = CampaignTime.Now,
			EndTime = CampaignTime.Now + CampaignTime.Years(durationYears),
			DurationYears = durationYears
		};
		SaveData();
		DiplomacyLogger.Instance.LogDiplomaticAction("trade_agreement_created", ((MBObjectBase)kingdom1).StringId, ((MBObjectBase)kingdom2).StringId, $"AI-driven trade agreement for {durationYears} years");
		LogMessage($"[TRADE_AGREEMENT] Trade agreement signed: {kingdom1.Name} ↔ {kingdom2.Name} (expires: {TradeAgreements[agreementKey].EndTime})");
	}

	private void CreateTradeAgreementInGame(Kingdom kingdom1, Kingdom kingdom2, float durationYears)
	{
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		if (kingdom1 == null || kingdom2 == null || kingdom1 == kingdom2)
		{
			return;
		}
		if (kingdom1.IsAtWarWith((IFaction)(object)kingdom2))
		{
			LogMessage($"[TRADE_AGREEMENT] Cannot create agreement: {kingdom1.Name} and {kingdom2.Name} are at war");
		}
		else if (_vanillaBehavior != null && _vanillaBehavior.HasTradeAgreement(kingdom1, kingdom2))
		{
			LogMessage($"[TRADE_AGREEMENT] Trade agreement already exists in game between {kingdom1.Name} and {kingdom2.Name}");
		}
		else if (_vanillaBehavior != null)
		{
			CampaignTime duration = CampaignTime.Years(durationYears);
			DiplomacyPatches.WithBypass(delegate
			{
				//IL_0028: Unknown result type (might be due to invalid IL or missing references)
				_vanillaBehavior.MakeTradeAgreement(kingdom1, kingdom2, duration);
			});
			LogMessage($"[TRADE_AGREEMENT] Synchronized trade agreement in game: {kingdom1.Name} ↔ {kingdom2.Name} for {durationYears} years");
		}
	}

	public void EndTradeAgreement(Kingdom kingdom1, Kingdom kingdom2)
	{
		if (kingdom1 == null || kingdom2 == null)
		{
			return;
		}
		if (_vanillaBehavior != null)
		{
			DiplomacyPatches.WithBypass(delegate
			{
				_vanillaBehavior.EndTradeAgreement(kingdom1, kingdom2);
			});
		}
		string agreementKey = GetAgreementKey(((MBObjectBase)kingdom1).StringId, ((MBObjectBase)kingdom2).StringId);
		if (TradeAgreements.ContainsKey(agreementKey))
		{
			TradeAgreements.Remove(agreementKey);
			SaveData();
			DiplomacyLogger.Instance.LogDiplomaticAction("trade_agreement_ended", ((MBObjectBase)kingdom1).StringId, ((MBObjectBase)kingdom2).StringId, "Trade agreement terminated");
			LogMessage($"[TRADE_AGREEMENT] Trade agreement ended: {kingdom1.Name} ↔ {kingdom2.Name}");
		}
	}

	private void ExtendTradeAgreement(Kingdom kingdom1, Kingdom kingdom2, float additionalYears)
	{
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		if (kingdom1 == null || kingdom2 == null || kingdom1 == kingdom2)
		{
			return;
		}
		string agreementKey = GetAgreementKey(((MBObjectBase)kingdom1).StringId, ((MBObjectBase)kingdom2).StringId);
		if (!TradeAgreements.ContainsKey(agreementKey))
		{
			CreateTradeAgreement(kingdom1, kingdom2, additionalYears);
			return;
		}
		TradeAgreementInfo tradeAgreementInfo = TradeAgreements[agreementKey];
		CampaignTime val = tradeAgreementInfo.EndTime;
		CampaignTime val2 = (tradeAgreementInfo.EndTime = ((!((CampaignTime)(ref val)).IsFuture) ? (CampaignTime.Now + CampaignTime.Years(additionalYears)) : (tradeAgreementInfo.EndTime + CampaignTime.Years(additionalYears))));
		double toDays = ((CampaignTime)(ref val2)).ToDays;
		val = tradeAgreementInfo.StartTime;
		tradeAgreementInfo.DurationYears = (float)((toDays - ((CampaignTime)(ref val)).ToDays) / (double)CampaignTime.DaysInYear);
		if (_vanillaBehavior != null)
		{
			DiplomacyPatches.WithBypass(delegate
			{
				_vanillaBehavior.EndTradeAgreement(kingdom1, kingdom2);
			});
			double toDays2 = ((CampaignTime)(ref val2)).ToDays;
			val = CampaignTime.Now;
			float num = (float)((toDays2 - ((CampaignTime)(ref val)).ToDays) / (double)CampaignTime.DaysInYear);
			if (num > 0f)
			{
				CampaignTime totalDuration = CampaignTime.Years(num);
				DiplomacyPatches.WithBypass(delegate
				{
					//IL_0028: Unknown result type (might be due to invalid IL or missing references)
					_vanillaBehavior.MakeTradeAgreement(kingdom1, kingdom2, totalDuration);
				});
				LogMessage($"[TRADE_AGREEMENT] Extended vanilla trade agreement: {kingdom1.Name} ↔ {kingdom2.Name} until {val2} (duration from now: {num:F1} years)");
			}
		}
		SaveData();
		LogMessage($"[TRADE_AGREEMENT] Trade agreement extended: {kingdom1.Name} ↔ {kingdom2.Name} (new expiry: {val2})");
	}

	private void EndTradeAgreementInGame(Kingdom kingdom1, Kingdom kingdom2)
	{
		if (kingdom1 != null && kingdom2 != null && _vanillaBehavior != null && _vanillaBehavior.HasTradeAgreement(kingdom1, kingdom2))
		{
			DiplomacyPatches.WithBypass(delegate
			{
				_vanillaBehavior.EndTradeAgreement(kingdom1, kingdom2);
			});
			LogMessage($"[TRADE_AGREEMENT] Synchronized: Ended trade agreement in game {kingdom1.Name} ↔ {kingdom2.Name}");
		}
	}

	public List<TradeAgreementInfo> GetTradeAgreementsForKingdom(Kingdom kingdom)
	{
		if (kingdom == null)
		{
			return new List<TradeAgreementInfo>();
		}
		return TradeAgreements.Values.Where(delegate(TradeAgreementInfo a)
		{
			//IL_0031: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Unknown result type (might be due to invalid IL or missing references)
			int result;
			if (a.Kingdom1Id == ((MBObjectBase)kingdom).StringId || a.Kingdom2Id == ((MBObjectBase)kingdom).StringId)
			{
				CampaignTime endTime = a.EndTime;
				result = (((CampaignTime)(ref endTime)).IsFuture ? 1 : 0);
			}
			else
			{
				result = 0;
			}
			return (byte)result != 0;
		}).ToList();
	}

	public int GetTradeAgreementCount(Kingdom kingdom)
	{
		if (kingdom == null)
		{
			return 0;
		}
		return GetTradeAgreementsForKingdom(kingdom).Count;
	}

	public bool CanMakeMoreAgreements(Kingdom kingdom)
	{
		if (kingdom == null || kingdom.IsEliminated)
		{
			return false;
		}
		return true;
	}

	public void CleanExpiredAgreements()
	{
		List<KeyValuePair<string, TradeAgreementInfo>> list = TradeAgreements.Where(delegate(KeyValuePair<string, TradeAgreementInfo> kvp)
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			CampaignTime endTime = kvp.Value.EndTime;
			return ((CampaignTime)(ref endTime)).IsPast;
		}).ToList();
		foreach (KeyValuePair<string, TradeAgreementInfo> item in list)
		{
			TradeAgreementInfo agreement = item.Value;
			Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == agreement.Kingdom1Id));
			Kingdom val2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == agreement.Kingdom2Id));
			if (val != null && val2 != null)
			{
				LogMessage($"[TRADE_AGREEMENT] Removing expired agreement: {val.Name} ↔ {val2.Name}");
				EndTradeAgreementInGame(val, val2);
			}
			TradeAgreements.Remove(item.Key);
		}
		if (list.Any())
		{
			SaveData();
		}
	}

	public void OnDailyTick()
	{
		CleanExpiredAgreements();
	}

	public void OnWarDeclared(Kingdom kingdom1, Kingdom kingdom2)
	{
		if (HasTradeAgreement(kingdom1, kingdom2, out var _))
		{
			LogMessage($"[TRADE_AGREEMENT] War declared, ending trade agreement: {kingdom1.Name} ↔ {kingdom2.Name}");
			EndTradeAgreement(kingdom1, kingdom2);
		}
	}

	public void OnKingdomDestroyed(Kingdom kingdom)
	{
		if (kingdom == null)
		{
			return;
		}
		List<string> list = (from kvp in TradeAgreements
			where kvp.Value.Kingdom1Id == ((MBObjectBase)kingdom).StringId || kvp.Value.Kingdom2Id == ((MBObjectBase)kingdom).StringId
			select kvp.Key).ToList();
		foreach (string item in list)
		{
			TradeAgreements.Remove(item);
		}
		if (list.Any())
		{
			LogMessage($"[TRADE_AGREEMENT] Removed {list.Count} trade agreements for destroyed kingdom: {kingdom.Name}");
			SaveData();
		}
	}

	public string GenerateTradeAgreementSummary()
	{
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		if (!TradeAgreements.Any())
		{
			return "No active trade agreements.";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("Active Trade Agreements:");
		foreach (TradeAgreementInfo agreement in TradeAgreements.Values.Where(delegate(TradeAgreementInfo a)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			CampaignTime endTime2 = a.EndTime;
			return ((CampaignTime)(ref endTime2)).IsFuture;
		}))
		{
			Kingdom val = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == agreement.Kingdom1Id));
			Kingdom val2 = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == agreement.Kingdom2Id));
			if (val != null && val2 != null)
			{
				CampaignTime endTime = agreement.EndTime;
				float num = ((CampaignTime)(ref endTime)).RemainingDaysFromNow / (float)CampaignTime.DaysInYear;
				stringBuilder.AppendLine($"- {val.Name} ↔ {val2.Name} (expires in {num:F1} years)");
			}
		}
		return stringBuilder.ToString().TrimEnd(Array.Empty<char>());
	}

	public void SynchronizeTradeAgreements()
	{
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		LogMessage("[TRADE_AGREEMENT] Synchronizing trade agreements with game state...");
		HashSet<string> hashSet = new HashSet<string>();
		int num = 0;
		int num2 = 0;
		foreach (Kingdom kingdom1 in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated))
		{
			foreach (Kingdom item in ((IEnumerable<Kingdom>)Kingdom.All).Where((Kingdom k) => !k.IsEliminated && k != kingdom1))
			{
				string agreementKey = GetAgreementKey(((MBObjectBase)kingdom1).StringId, ((MBObjectBase)item).StringId);
				if (hashSet.Contains(agreementKey))
				{
					continue;
				}
				hashSet.Add(agreementKey);
				CampaignTime endTime;
				int num3;
				if (TradeAgreements.ContainsKey(agreementKey))
				{
					endTime = TradeAgreements[agreementKey].EndTime;
					num3 = (((CampaignTime)(ref endTime)).IsFuture ? 1 : 0);
				}
				else
				{
					num3 = 0;
				}
				bool flag = (byte)num3 != 0;
				bool flag2 = _vanillaBehavior != null && _vanillaBehavior.HasTradeAgreement(kingdom1, item);
				bool flag3 = FactionManager.IsAtWarAgainstFaction((IFaction)(object)kingdom1, (IFaction)(object)item);
				if (flag && !flag2)
				{
					if (flag3)
					{
						LogMessage($"[TRADE_AGREEMENT] Synchronizing: Cannot create trade agreement {kingdom1.Name} ↔ {item.Name} - they are at war. Removing from file.");
						TradeAgreements.Remove(agreementKey);
						SaveData();
						num2++;
						continue;
					}
					TradeAgreementInfo tradeAgreementInfo = TradeAgreements[agreementKey];
					endTime = tradeAgreementInfo.EndTime;
					float num4 = ((CampaignTime)(ref endTime)).RemainingDaysFromNow / (float)CampaignTime.DaysInYear;
					if (num4 > 0f)
					{
						LogMessage($"[TRADE_AGREEMENT] Synchronizing: Creating missing trade agreement {kingdom1.Name} ↔ {item.Name} (remaining: {num4:F1} years)");
						CreateTradeAgreementInGame(kingdom1, item, num4);
						num++;
					}
				}
				else if (!flag && flag2)
				{
					if (flag3)
					{
						LogMessage($"[TRADE_AGREEMENT] Synchronizing: Ending unexpected trade agreement {kingdom1.Name} ↔ {item.Name} - they are at war");
						EndTradeAgreementInGame(kingdom1, item);
						num2++;
					}
					else
					{
						LogMessage($"[TRADE_AGREEMENT] Synchronizing: Ending unexpected trade agreement {kingdom1.Name} ↔ {item.Name}");
						EndTradeAgreementInGame(kingdom1, item);
						num2++;
					}
				}
				else if (flag && flag2 && flag3)
				{
					LogMessage($"[TRADE_AGREEMENT] Synchronizing: Ending conflicting trade agreement {kingdom1.Name} ↔ {item.Name} - they are at war");
					EndTradeAgreementInGame(kingdom1, item);
					TradeAgreements.Remove(agreementKey);
					SaveData();
					num2++;
				}
			}
		}
		LogMessage($"[TRADE_AGREEMENT] Synchronization complete: {num} created, {num2} ended");
	}

	private string GetAgreementKey(string kingdomId1, string kingdomId2)
	{
		if (string.Compare(kingdomId1, kingdomId2, StringComparison.Ordinal) < 0)
		{
			return kingdomId1 + "_" + kingdomId2;
		}
		return kingdomId2 + "_" + kingdomId1;
	}

	private void LogMessage(string message)
	{
		AIInfluenceBehavior.Instance?.LogMessage(message);
	}
}
