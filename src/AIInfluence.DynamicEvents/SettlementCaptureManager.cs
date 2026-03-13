using System;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.DynamicEvents;

public class SettlementCaptureManager
{
	private static SettlementCaptureManager _instance;

	private readonly Dictionary<string, CampaignTime> _settlementCaptureTimes = new Dictionary<string, CampaignTime>();

	private readonly Dictionary<string, Kingdom> _settlementCapturers = new Dictionary<string, Kingdom>();

	private readonly Dictionary<string, Kingdom> _settlementPreviousOwners = new Dictionary<string, Kingdom>();

	public static SettlementCaptureManager Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new SettlementCaptureManager();
			}
			return _instance;
		}
	}

	private SettlementCaptureManager()
	{
		RegisterCaptureEvents();
	}

	private void RegisterCaptureEvents()
	{
		CampaignEvents.OnSettlementOwnerChangedEvent.AddNonSerializedListener((object)this, (Action<Settlement, bool, Hero, Hero, Hero, ChangeOwnerOfSettlementDetail>)OnSettlementOwnerChanged);
	}

	private void OnSettlementOwnerChanged(Settlement settlement, bool openToClaim, Hero newOwner, Hero oldOwner, Hero capturer, ChangeOwnerOfSettlementDetail detail)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		if (IsRealCapture(newOwner, oldOwner))
		{
			_settlementCaptureTimes[((MBObjectBase)settlement).StringId] = CampaignTime.Now;
			object obj;
			if (newOwner == null)
			{
				obj = null;
			}
			else
			{
				Clan clan = newOwner.Clan;
				obj = ((clan != null) ? clan.Kingdom : null);
			}
			Kingdom val = (Kingdom)obj;
			if (val != null)
			{
				_settlementCapturers[((MBObjectBase)settlement).StringId] = val;
			}
			object obj2;
			if (oldOwner == null)
			{
				obj2 = null;
			}
			else
			{
				Clan clan2 = oldOwner.Clan;
				obj2 = ((clan2 != null) ? clan2.Kingdom : null);
			}
			Kingdom val2 = (Kingdom)obj2;
			if (val2 != null)
			{
				_settlementPreviousOwners[((MBObjectBase)settlement).StringId] = val2;
			}
			AIInfluenceBehavior.Instance?.LogMessage($"[SETTLEMENT_CAPTURE] {settlement.Name} captured by {GetOwnerInfo(newOwner)} from {GetOwnerInfo(oldOwner)} at {CampaignTime.Now}");
		}
		else
		{
			AIInfluenceBehavior.Instance?.LogMessage($"[SETTLEMENT_TRANSFER] {settlement.Name} transferred within {GetOwnerInfo(newOwner)} (not a capture)");
		}
	}

	private bool IsRealCapture(Hero newOwner, Hero oldOwner)
	{
		if (newOwner == null || oldOwner == null)
		{
			return false;
		}
		Clan clan = newOwner.Clan;
		if (((clan != null) ? clan.Kingdom : null) != null)
		{
			Clan clan2 = oldOwner.Clan;
			if (((clan2 != null) ? clan2.Kingdom : null) != null && newOwner.Clan.Kingdom == oldOwner.Clan.Kingdom)
			{
				return false;
			}
		}
		if (newOwner.Clan == oldOwner.Clan)
		{
			return false;
		}
		return true;
	}

	private string GetOwnerInfo(Hero owner)
	{
		if (owner == null)
		{
			return "unknown";
		}
		Clan clan = owner.Clan;
		if (((clan != null) ? clan.Kingdom : null) != null)
		{
			return ((object)owner.Clan.Kingdom.Name).ToString();
		}
		if (owner.Clan != null)
		{
			return ((object)owner.Clan.Name).ToString();
		}
		return ((object)owner.Name).ToString();
	}

	public bool IsRecentlyCaptured(string settlementStringId, int daysThreshold = 30)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		if (!_settlementCaptureTimes.TryGetValue(settlementStringId, out var value))
		{
			return false;
		}
		CampaignTime val = CampaignTime.Now - value;
		double toDays = ((CampaignTime)(ref val)).ToDays;
		return toDays <= (double)daysThreshold;
	}

	public int GetDaysSinceCapture(string settlementStringId)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		if (!_settlementCaptureTimes.TryGetValue(settlementStringId, out var value))
		{
			return -1;
		}
		CampaignTime val = CampaignTime.Now - value;
		return (int)((CampaignTime)(ref val)).ToDays;
	}

	public CampaignTime GetCaptureTime(string settlementStringId)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		CampaignTime value;
		return _settlementCaptureTimes.TryGetValue(settlementStringId, out value) ? value : CampaignTime.Never;
	}

	public Kingdom GetCapturerKingdom(string settlementStringId)
	{
		Kingdom value;
		return _settlementCapturers.TryGetValue(settlementStringId, out value) ? value : null;
	}

	public Kingdom GetPreviousOwnerKingdom(string settlementStringId)
	{
		Kingdom value;
		return _settlementPreviousOwners.TryGetValue(settlementStringId, out value) ? value : null;
	}

	public List<string> GetRecentlyCapturedSettlementsFromKingdom(Kingdom destroyedKingdom, int daysThreshold = 30)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		List<string> list = new List<string>();
		if (destroyedKingdom == null)
		{
			return list;
		}
		foreach (KeyValuePair<string, CampaignTime> settlementCaptureTime in _settlementCaptureTimes)
		{
			string key = settlementCaptureTime.Key;
			CampaignTime value = settlementCaptureTime.Value;
			CampaignTime val = CampaignTime.Now - value;
			double toDays = ((CampaignTime)(ref val)).ToDays;
			if (!(toDays > (double)daysThreshold) && _settlementPreviousOwners.TryGetValue(key, out var value2) && value2 == destroyedKingdom)
			{
				list.Add(key);
			}
		}
		return list;
	}
}
