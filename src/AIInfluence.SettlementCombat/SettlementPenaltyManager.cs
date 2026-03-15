using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Party.PartyComponents;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.SettlementCombat;

public class SettlementPenaltyManager : CampaignBehaviorBase
{
	private Dictionary<string, ActivePenalty> _activePenalties = new Dictionary<string, ActivePenalty>();

	private readonly SettlementCombatLogger _logger;

	private readonly SettlementPenaltiesStorage _storage;

	private bool _initialized = false;

	public static SettlementPenaltyManager Instance { get; private set; }

	public SettlementPenaltyManager()
	{
		_logger = SettlementCombatLogger.Instance;
		_storage = new SettlementPenaltiesStorage();
		Instance = this;
	}

	public override void RegisterEvents()
	{
		CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener((object)this, (Action<CampaignGameStarter>)OnSessionLaunched);
		CampaignEvents.DailyTickEvent.AddNonSerializedListener((object)this, (Action)OnDailyTick);
	}

	public override void SyncData(IDataStore dataStore)
	{
	}

	public void Initialize()
	{
		if (_initialized)
		{
			_logger.Log("SettlementPenaltyManager already initialized - skipping");
			return;
		}
		_logger.Log("Initializing SettlementPenaltyManager...");
		Dictionary<string, ActivePenalty> dictionary = _storage.LoadPenalties();
		if (dictionary != null && dictionary.Count > 0)
		{
			_activePenalties = dictionary;
			_logger.Log($"Loaded {_activePenalties.Count} active penalties from save");
		}
		else
		{
			_logger.Log("No saved penalties found or file is empty");
		}
		_initialized = true;
		_logger.Log("SettlementPenaltyManager initialized successfully");
	}

	private void OnSessionLaunched(CampaignGameStarter starter)
	{
		Initialize();
	}

	public void AddPenalty(Settlement settlement, float prosperityPenaltyPerDay, int durationDays, string reason)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (settlement == null)
			{
				_logger.LogError("AddPenalty", "Settlement is null");
				return;
			}
			ActivePenalty obj = new ActivePenalty
			{
				SettlementId = ((MBObjectBase)settlement).StringId,
				ProsperityPenaltyPerDay = prosperityPenaltyPerDay
			};
			CampaignTime now = CampaignTime.Now;
			obj.StartDay = (float)(now).ToDays;
			obj.DurationDays = durationDays;
			obj.Reason = reason;
			ActivePenalty value = obj;
			_activePenalties[((MBObjectBase)settlement).StringId] = value;
			_storage.SavePenalties(_activePenalties);
			_logger.Log($"Penalty added to {settlement.Name}: -{prosperityPenaltyPerDay}/day for {durationDays} days. Reason: {reason}");
		}
		catch (Exception ex)
		{
			_logger.LogError("AddPenalty", ex.Message, ex);
			throw;
		}
	}

	public ActivePenalty GetActivePenalty(Settlement settlement)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		if (settlement == null)
		{
			return null;
		}
		if (_activePenalties.TryGetValue(((MBObjectBase)settlement).StringId, out var value))
		{
			CampaignTime now = CampaignTime.Now;
			float num = (float)(now).ToDays;
			if (num < value.StartDay + (float)value.DurationDays)
			{
				return value;
			}
		}
		return null;
	}

	public void ApplyCasualtiesToVillage(Settlement settlement, int civiliansKilled)
	{
		try
		{
			if (settlement != null && settlement.IsVillage && civiliansKilled > 0)
			{
				float num = (float)civiliansKilled * 0.5f;
				if (settlement.Village != null)
				{
					settlement.Village.Hearth = Math.Max(50f, settlement.Village.Hearth - num);
					_logger.Log($"Casualties applied to {settlement.Name}: -{num} Hearth (from {civiliansKilled} civilian deaths). New Hearth: {settlement.Village.Hearth:F0}");
				}
				else
				{
					_logger.Log($"ApplyCasualtiesToVillage: Settlement {settlement.Name} is a village but .Village component is null!");
				}
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("ApplyCasualtiesToVillage", ex.Message, ex);
		}
	}

	public void ApplyMilitiaCasualties(Settlement settlement, int militiaKilled)
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (settlement == null || militiaKilled <= 0)
			{
				return;
			}
			MilitiaPartyComponent militiaPartyComponent = settlement.MilitiaPartyComponent;
			MobileParty val = ((militiaPartyComponent != null) ? ((PartyComponent)militiaPartyComponent).MobileParty : null);
			if (val == null || val.MemberRoster == null)
			{
				_logger.Log($"No militia party found for {settlement.Name}");
				return;
			}
			int totalManCount = val.MemberRoster.TotalManCount;
			int num = Math.Min(militiaKilled, totalManCount);
			if (num <= 0)
			{
				return;
			}
			int num2 = 0;
			List<TroopRosterElement> list = ((IEnumerable<TroopRosterElement>)val.MemberRoster.GetTroopRoster()).ToList();
			foreach (TroopRosterElement item in list)
			{
				TroopRosterElement current = item;
				if (num2 >= num)
				{
					break;
				}
				int num3 = Math.Min((current).Number, num - num2);
				val.MemberRoster.AddToCounts(current.Character, -num3, false, 0, 0, true, -1);
				num2 += num3;
			}
			_logger.Log($"Militia casualties applied to {settlement.Name}: {num2} militia removed. Militia count: {totalManCount} → {val.MemberRoster.TotalManCount}");
		}
		catch (Exception ex)
		{
			_logger.LogError("ApplyMilitiaCasualties", ex.Message, ex);
		}
	}

	private void OnDailyTick()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			CampaignTime now = CampaignTime.Now;
			float num = (float)(now).ToDays;
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, ActivePenalty> activePenalty in _activePenalties)
			{
				string key = activePenalty.Key;
				ActivePenalty value = activePenalty.Value;
				if (num >= value.StartDay + (float)value.DurationDays)
				{
					list.Add(key);
					Settlement val = Settlement.Find(key);
					if (val != null)
					{
						_logger.Log($"Penalty expired for {val.Name}");
					}
					continue;
				}
				Settlement val2 = Settlement.Find(key);
				if (val2 != null)
				{
					if (val2.IsVillage && val2.Village != null)
					{
						val2.Village.Hearth = Math.Max(50f, val2.Village.Hearth - value.ProsperityPenaltyPerDay);
						int num2 = value.DurationDays - (int)(num - value.StartDay);
						_logger.Log($"Daily penalty applied to {val2.Name}: -{value.ProsperityPenaltyPerDay} Hearth. Remaining: {num2} days");
					}
					else if (val2.IsTown && val2.Town != null)
					{
						ChangeSettlementProsperity(val2, 0f - value.ProsperityPenaltyPerDay);
						int num3 = value.DurationDays - (int)(num - value.StartDay);
						_logger.Log($"Daily penalty applied to {val2.Name}: -{value.ProsperityPenaltyPerDay} Prosperity. Remaining: {num3} days");
					}
				}
			}
			foreach (string item in list)
			{
				_activePenalties.Remove(item);
			}
			if (_activePenalties.Count > 0 || list.Count > 0)
			{
				_storage.SavePenalties(_activePenalties);
			}
		}
		catch (Exception ex)
		{
			_logger.LogError("OnDailyTick", ex.Message, ex);
			throw;
		}
	}

	private void ChangeSettlementProsperity(Settlement settlement, float change)
	{
		if (settlement != null && settlement.Town != null)
		{
			settlement.Town.Prosperity = Math.Max(0f, settlement.Town.Prosperity + change);
		}
	}
}
