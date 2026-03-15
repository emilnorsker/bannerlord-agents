using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.DynamicEvents;

public class EconomicEffectsManager : CampaignBehaviorBase
{
	private readonly EconomicEffectsStorage _storage;

	private readonly List<ActiveEconomicEffect> _activeEffects = new List<ActiveEconomicEffect>();

	public static EconomicEffectsManager Instance { get; private set; }

	public EconomicEffectsManager()
	{
		_storage = new EconomicEffectsStorage();
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

	private void OnSessionLaunched(CampaignGameStarter starter)
	{
		try
		{
			AIInfluenceBehavior.Instance?.LogMessage("[SYNC-TRACE] EconomicEffectsManager loading persisted effects.");
			_activeEffects.Clear();
			List<ActiveEconomicEffect> list = _storage.LoadEffects();
			if (list != null && list.Count > 0)
			{
				_activeEffects.AddRange(list);
			}
			AIInfluenceBehavior.Instance?.LogMessage("[SYNC-TRACE] EconomicEffectsManager loaded effects count=" + _activeEffects.Count);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] EconomicEffectsManager failed loading persisted effects: " + ex);
			throw;
		}
	}

	public List<ActiveEconomicEffect> GetActiveEffects()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			CampaignTime now = CampaignTime.Now;
			float currentDay = (float)(now).ToDays;
			return _activeEffects.Where((ActiveEconomicEffect e) => currentDay < e.StartDay + (float)e.DurationDays).ToList();
		}
		catch
		{
			return new List<ActiveEconomicEffect>();
		}
	}

	public bool TryGetSettlementDailyEffect(Settlement settlement, out float prosperityPerDay, out float foodPerDay, out string reason)
	{
		float securityPerDay;
		float loyaltyPerDay;
		return TryGetSettlementDailyEffect(settlement, out prosperityPerDay, out foodPerDay, out securityPerDay, out loyaltyPerDay, out reason);
	}

	public bool TryGetSettlementDailyEffect(Settlement settlement, out float prosperityPerDay, out float foodPerDay, out float securityPerDay, out float loyaltyPerDay, out string reason)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		prosperityPerDay = 0f;
		foodPerDay = 0f;
		securityPerDay = 0f;
		loyaltyPerDay = 0f;
		reason = null;
		if (settlement == null)
		{
			return false;
		}
		try
		{
			string id = ((MBObjectBase)settlement).StringId;
			CampaignTime now = CampaignTime.Now;
			float currentDay = (float)(now).ToDays;
			List<ActiveEconomicEffect> list = _activeEffects.Where((ActiveEconomicEffect e) => e.TargetType == "settlement" && e.TargetId == id && currentDay < e.StartDay + (float)e.DurationDays).ToList();
			if (!list.Any())
			{
				return false;
			}
			foreach (ActiveEconomicEffect item in list)
			{
				prosperityPerDay += item.ProsperityDeltaPerDay;
				foodPerDay += item.FoodDeltaPerDay;
				securityPerDay += item.SecurityDeltaPerDay;
				loyaltyPerDay += item.LoyaltyDeltaPerDay;
				if (!string.IsNullOrEmpty(item.Reason))
				{
					if (string.IsNullOrEmpty(reason))
					{
						reason = item.Reason;
					}
					else if (!reason.Contains(item.Reason))
					{
						reason = reason + "; " + item.Reason;
					}
				}
			}
			if (string.IsNullOrEmpty(reason))
			{
				reason = "Economic effect from recent events";
			}
			return Math.Abs(prosperityPerDay) > 0.001f || Math.Abs(foodPerDay) > 0.001f || Math.Abs(securityPerDay) > 0.001f || Math.Abs(loyaltyPerDay) > 0.001f;
		}
		catch
		{
			return false;
		}
	}

	public float GetSettlementIncomeMultiplier(Settlement settlement)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		if (settlement == null)
		{
			return 1f;
		}
		try
		{
			string id = ((MBObjectBase)settlement).StringId;
			CampaignTime now = CampaignTime.Now;
			float currentDay = (float)(now).ToDays;
			List<ActiveEconomicEffect> list = _activeEffects.Where((ActiveEconomicEffect e) => e.TargetType == "settlement" && e.TargetId == id && currentDay < e.StartDay + (float)e.DurationDays && Math.Abs(e.IncomeMultiplier - 1f) > 0.001f).ToList();
			if (!list.Any())
			{
				return 1f;
			}
			float num = 1f;
			foreach (ActiveEconomicEffect item in list)
			{
				num += item.IncomeMultiplier - 1f;
			}
			return num;
		}
		catch
		{
			return 1f;
		}
	}

	public void AddEconomicEffects(IEnumerable<EconomicEffect> effects)
	{
		if (effects == null)
		{
			return;
		}
		foreach (EconomicEffect effect in effects)
		{
			if (effect != null && !string.IsNullOrEmpty(effect.TargetType))
			{
				bool flag = !string.IsNullOrEmpty(effect.TargetId);
				bool flag2 = effect.TargetIds != null && effect.TargetIds.Count > 0;
				if (flag || flag2)
				{
					ApplyInstantEffect(effect);
					CreateActiveEffects(effect);
				}
			}
		}
		_storage.SaveEffects(_activeEffects);
	}

	private void CreateActiveEffects(EconomicEffect effect)
	{
		if (effect.DurationDays <= 0 || (effect.ProsperityDeltaPerDay == 0f && effect.FoodDeltaPerDay == 0f && effect.SecurityDeltaPerDay == 0f && effect.LoyaltyDeltaPerDay == 0f && !(Math.Abs(effect.IncomeMultiplier - 1f) > 0.001f)))
		{
			return;
		}
		try
		{
			switch (effect.TargetType)
			{
			case "settlement":
				if (effect.TargetIds != null && effect.TargetIds.Count > 0)
				{
					foreach (string targetId in effect.TargetIds)
					{
						if (!string.IsNullOrEmpty(targetId))
						{
							AddActiveEffectForSettlement(effect, targetId);
						}
					}
					break;
				}
				if (!string.IsNullOrEmpty(effect.TargetId))
				{
					AddActiveEffectForSettlement(effect, effect.TargetId);
				}
				break;
			case "kingdom":
				AddActiveEffectsForKingdom(effect);
				break;
			case "clan":
				AddActiveEffectsForClan(effect);
				break;
			}
		}
		catch
		{
		}
	}

	private void AddActiveEffectForSettlement(EconomicEffect effect, string settlementId)
	{
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		Settlement val = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == settlementId));
		bool flag = val != null && val.IsVillage;
		ActiveEconomicEffect obj = new ActiveEconomicEffect
		{
			TargetType = "settlement",
			TargetId = settlementId,
			ProsperityDeltaPerDay = effect.ProsperityDeltaPerDay,
			FoodDeltaPerDay = (flag ? 0f : effect.FoodDeltaPerDay),
			SecurityDeltaPerDay = (flag ? 0f : effect.SecurityDeltaPerDay),
			LoyaltyDeltaPerDay = (flag ? 0f : effect.LoyaltyDeltaPerDay),
			IncomeMultiplier = effect.IncomeMultiplier
		};
		CampaignTime now = CampaignTime.Now;
		obj.StartDay = (float)(now).ToDays;
		obj.DurationDays = effect.DurationDays;
		obj.Reason = effect.Reason;
		ActiveEconomicEffect item = obj;
		_activeEffects.Add(item);
	}

	private void AddActiveEffectsForKingdom(EconomicEffect effect)
	{
		Kingdom kingdom = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == effect.TargetId));
		if (kingdom == null)
		{
			return;
		}
		string text = effect.TargetScope ?? "single";
		if (text == "all")
		{
			text = "all_settlements";
		}
		if (text == "single")
		{
			return;
		}
		IEnumerable<Settlement> enumerable = ((IEnumerable<Settlement>)Settlement.All).Where((Settlement s) => s.OwnerClan != null && s.OwnerClan.Kingdom == kingdom);
		switch (text)
		{
		case "towns":
			enumerable = enumerable.Where((Settlement s) => s.IsTown);
			break;
		case "castles":
			enumerable = enumerable.Where((Settlement s) => s.IsCastle);
			break;
		case "villages":
			enumerable = enumerable.Where((Settlement s) => s.IsVillage);
			break;
		}
		foreach (Settlement item in enumerable)
		{
			AddActiveEffectForSettlement(effect, ((MBObjectBase)item).StringId);
		}
	}

	private void AddActiveEffectsForClan(EconomicEffect effect)
	{
		Clan clan = ((IEnumerable<Clan>)Clan.All).FirstOrDefault((Func<Clan, bool>)((Clan c) => ((MBObjectBase)c).StringId == effect.TargetId));
		if (clan == null)
		{
			return;
		}
		string text = effect.TargetScope ?? "single";
		if (text == "single")
		{
			return;
		}
		IEnumerable<Settlement> enumerable = ((IEnumerable<Settlement>)Settlement.All).Where((Settlement s) => s.OwnerClan == clan);
		switch (text)
		{
		case "towns":
			enumerable = enumerable.Where((Settlement s) => s.IsTown);
			break;
		case "castles":
			enumerable = enumerable.Where((Settlement s) => s.IsCastle);
			break;
		case "villages":
			enumerable = enumerable.Where((Settlement s) => s.IsVillage);
			break;
		}
		foreach (Settlement item in enumerable)
		{
			AddActiveEffectForSettlement(effect, ((MBObjectBase)item).StringId);
		}
	}

	private void ApplyInstantEffect(EconomicEffect effect)
	{
		if (effect == null || string.IsNullOrEmpty(effect.TargetType))
		{
			return;
		}
		try
		{
			switch (effect.TargetType)
			{
			case "settlement":
				ApplyInstantSettlementEffect(effect);
				break;
			case "kingdom":
				ApplyInstantKingdomEffect(effect);
				break;
			case "clan":
				ApplyInstantClanEffect(effect);
				break;
			}
		}
		catch
		{
		}
	}

	private void ApplyInstantSettlementEffect(EconomicEffect effect)
	{
		IEnumerable<string> enumerable;
		if (effect.TargetIds != null && effect.TargetIds.Count > 0)
		{
			enumerable = effect.TargetIds.Where((string value) => !string.IsNullOrEmpty(value));
		}
		else
		{
			if (string.IsNullOrEmpty(effect.TargetId))
			{
				return;
			}
			enumerable = new string[1] { effect.TargetId };
		}
		foreach (string id in enumerable)
		{
			Settlement val = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == id));
			if (val == null)
			{
				continue;
			}
			if (val.IsVillage && val.Village != null)
			{
				if (effect.ProsperityDelta != 0f)
				{
					val.Village.Hearth = Math.Max(50f, val.Village.Hearth + effect.ProsperityDelta);
				}
			}
			else if ((val.IsTown || val.IsCastle) && val.Town != null)
			{
				if (effect.ProsperityDelta != 0f)
				{
					val.Town.Prosperity = Math.Max(0f, val.Town.Prosperity + effect.ProsperityDelta);
				}
				if (effect.FoodDelta != 0f)
				{
					((Fief)val.Town).FoodStocks = Math.Max(0f, ((Fief)val.Town).FoodStocks + effect.FoodDelta);
				}
				if (effect.SecurityDelta != 0f)
				{
					val.Town.Security = Math.Max(0f, val.Town.Security + effect.SecurityDelta);
				}
				if (effect.LoyaltyDelta != 0f)
				{
					val.Town.Loyalty = Math.Max(0f, val.Town.Loyalty + effect.LoyaltyDelta);
				}
			}
		}
	}

	private void ApplyInstantKingdomEffect(EconomicEffect effect)
	{
		Kingdom kingdom = ((IEnumerable<Kingdom>)Kingdom.All).FirstOrDefault((Func<Kingdom, bool>)((Kingdom k) => ((MBObjectBase)k).StringId == effect.TargetId));
		if (kingdom == null)
		{
			return;
		}
		string text = effect.TargetScope ?? "single";
		if (text == "all")
		{
			text = "all_settlements";
		}
		if (text == "single")
		{
			return;
		}
		IEnumerable<Settlement> enumerable = ((IEnumerable<Settlement>)Settlement.All).Where((Settlement s) => s.OwnerClan != null && s.OwnerClan.Kingdom == kingdom);
		switch (text)
		{
		case "towns":
			enumerable = enumerable.Where((Settlement s) => s.IsTown);
			break;
		case "castles":
			enumerable = enumerable.Where((Settlement s) => s.IsCastle);
			break;
		case "villages":
			enumerable = enumerable.Where((Settlement s) => s.IsVillage);
			break;
		}
		foreach (Settlement item in enumerable)
		{
			if (item.IsVillage && item.Village != null)
			{
				if (effect.ProsperityDelta != 0f)
				{
					item.Village.Hearth = Math.Max(50f, item.Village.Hearth + effect.ProsperityDelta);
				}
			}
			else if ((item.IsTown || item.IsCastle) && item.Town != null)
			{
				if (effect.ProsperityDelta != 0f)
				{
					item.Town.Prosperity = Math.Max(0f, item.Town.Prosperity + effect.ProsperityDelta);
				}
				if (effect.FoodDelta != 0f)
				{
					((Fief)item.Town).FoodStocks = Math.Max(0f, ((Fief)item.Town).FoodStocks + effect.FoodDelta);
				}
				if (effect.SecurityDelta != 0f)
				{
					item.Town.Security = Math.Max(0f, item.Town.Security + effect.SecurityDelta);
				}
				if (effect.LoyaltyDelta != 0f)
				{
					item.Town.Loyalty = Math.Max(0f, item.Town.Loyalty + effect.LoyaltyDelta);
				}
			}
		}
	}

	private void ApplyInstantClanEffect(EconomicEffect effect)
	{
		Clan clan = ((IEnumerable<Clan>)Clan.All).FirstOrDefault((Func<Clan, bool>)((Clan c) => ((MBObjectBase)c).StringId == effect.TargetId));
		if (clan == null)
		{
			return;
		}
		string text = effect.TargetScope ?? "single";
		if (text == "all")
		{
			text = "all_settlements";
		}
		if (text == "single")
		{
			return;
		}
		IEnumerable<Settlement> enumerable = ((IEnumerable<Settlement>)Settlement.All).Where((Settlement s) => s.OwnerClan == clan);
		switch (text)
		{
		case "towns":
			enumerable = enumerable.Where((Settlement s) => s.IsTown);
			break;
		case "castles":
			enumerable = enumerable.Where((Settlement s) => s.IsCastle);
			break;
		case "villages":
			enumerable = enumerable.Where((Settlement s) => s.IsVillage);
			break;
		}
		foreach (Settlement item in enumerable)
		{
			if (item.IsVillage && item.Village != null)
			{
				if (effect.ProsperityDelta != 0f)
				{
					item.Village.Hearth = Math.Max(50f, item.Village.Hearth + effect.ProsperityDelta);
				}
			}
			else if ((item.IsTown || item.IsCastle) && item.Town != null)
			{
				if (effect.ProsperityDelta != 0f)
				{
					item.Town.Prosperity = Math.Max(0f, item.Town.Prosperity + effect.ProsperityDelta);
				}
				if (effect.FoodDelta != 0f)
				{
					((Fief)item.Town).FoodStocks = Math.Max(0f, ((Fief)item.Town).FoodStocks + effect.FoodDelta);
				}
				if (effect.SecurityDelta != 0f)
				{
					item.Town.Security = Math.Max(0f, item.Town.Security + effect.SecurityDelta);
				}
				if (effect.LoyaltyDelta != 0f)
				{
					item.Town.Loyalty = Math.Max(0f, item.Town.Loyalty + effect.LoyaltyDelta);
				}
			}
		}
	}

	private void OnDailyTick()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (_activeEffects.Count == 0)
			{
				return;
			}
			CampaignTime now = CampaignTime.Now;
			float num = (float)(now).ToDays;
			List<ActiveEconomicEffect> list = new List<ActiveEconomicEffect>();
			foreach (ActiveEconomicEffect activeEffect in _activeEffects)
			{
				if (num >= activeEffect.StartDay + (float)activeEffect.DurationDays)
				{
					list.Add(activeEffect);
				}
				else
				{
					ApplyDailyEffect(activeEffect);
				}
			}
			if (list.Count <= 0)
			{
				return;
			}
			foreach (ActiveEconomicEffect item in list)
			{
				_activeEffects.Remove(item);
			}
			_storage.SaveEffects(_activeEffects);
			AIInfluenceBehavior.Instance?.LogMessage("[SYNC-TRACE] EconomicEffectsManager persisted effects count=" + _activeEffects.Count);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] EconomicEffectsManager.OnDailyTick persistence failed: " + ex);
			throw;
		}
	}

	private void ApplyDailyEffect(ActiveEconomicEffect active)
	{
		switch (active.TargetType)
		{
		case "settlement":
			ApplyDailySettlementEffect(active);
			break;
		case "kingdom":
			break;
		case "clan":
			break;
		}
	}

	private void ApplyDailySettlementEffect(ActiveEconomicEffect active)
	{
		Settlement val = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId == active.TargetId));
		if (val == null)
		{
			return;
		}
		if (val.IsVillage && val.Village != null)
		{
			if (active.ProsperityDeltaPerDay != 0f)
			{
				val.Village.Hearth = Math.Max(50f, val.Village.Hearth + active.ProsperityDeltaPerDay);
			}
		}
		else if ((val.IsTown || val.IsCastle) && val.Town != null)
		{
			if (active.ProsperityDeltaPerDay != 0f)
			{
				val.Town.Prosperity = Math.Max(0f, val.Town.Prosperity + active.ProsperityDeltaPerDay);
			}
			if (active.FoodDeltaPerDay != 0f)
			{
				((Fief)val.Town).FoodStocks = Math.Max(0f, ((Fief)val.Town).FoodStocks + active.FoodDeltaPerDay);
			}
			if (active.SecurityDeltaPerDay != 0f)
			{
				val.Town.Security = Math.Max(0f, Math.Min(100f, val.Town.Security + active.SecurityDeltaPerDay));
			}
			if (active.LoyaltyDeltaPerDay != 0f)
			{
				val.Town.Loyalty = Math.Max(0f, Math.Min(100f, val.Town.Loyalty + active.LoyaltyDeltaPerDay));
			}
		}
	}
}
