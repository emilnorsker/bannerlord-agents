using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AIInfluence.Behaviors.AIActions;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace AIInfluence.Behaviors;

public class NonCombatantPartyProtector : CampaignBehaviorBase
{
	private class ProtectionInfo
	{
		public Hero OriginalLeader;

		public CampaignTime ProtectionStartTime;

		public string ActionName;

		public bool WarningShown;
	}

	private static NonCombatantPartyProtector _instance;

	private Dictionary<MobileParty, ProtectionInfo> _protectedParties = new Dictionary<MobileParty, ProtectionInfo>();

	private Dictionary<Hero, CampaignTime> _lastWarningTime = new Dictionary<Hero, CampaignTime>();

	private const float WARNING_COOLDOWN_HOURS = 24f;

	public static NonCombatantPartyProtector Instance => _instance;

	public NonCombatantPartyProtector()
	{
		_instance = this;
	}

	public override void RegisterEvents()
	{
		CampaignEvents.OnPartyDisbandStartedEvent.AddNonSerializedListener((object)this, (Action<MobileParty>)OnPartyDisbandStarted);
		CampaignEvents.DailyTickPartyEvent.AddNonSerializedListener((object)this, (Action<MobileParty>)OnDailyTickParty);
		CampaignEvents.HourlyTickEvent.AddNonSerializedListener((object)this, (Action)OnHourlyTick);
		CampaignEvents.OnHeroTeleportationRequestedEvent.AddNonSerializedListener((object)this, (Action<Hero, Settlement, MobileParty, TeleportationDetail>)OnHeroTeleportationRequested);
		CampaignEvents.OnPartyRemovedEvent.AddNonSerializedListener((object)this, (Action<PartyBase>)OnPartyRemoved);
	}

	public override void SyncData(IDataStore dataStore)
	{
		//IL_023d: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (dataStore.IsSaving)
			{
				List<MobileParty> list = _protectedParties.Keys.ToList();
				List<Hero> list2 = _protectedParties.Values.Select((ProtectionInfo x) => x.OriginalLeader).ToList();
				List<CampaignTime> list3 = _protectedParties.Values.Select((ProtectionInfo x) => x.ProtectionStartTime).ToList();
				List<string> list4 = _protectedParties.Values.Select((ProtectionInfo x) => x.ActionName).ToList();
				List<bool> list5 = _protectedParties.Values.Select((ProtectionInfo x) => x.WarningShown).ToList();
				dataStore.SyncData<List<MobileParty>>("ProtectedPartiesList", ref list);
				dataStore.SyncData<List<Hero>>("ProtectedLeadersList", ref list2);
				dataStore.SyncData<List<CampaignTime>>("ProtectedStartTimesList", ref list3);
				dataStore.SyncData<List<string>>("ProtectedActionsList", ref list4);
				dataStore.SyncData<List<bool>>("ProtectedWarningsList", ref list5);
			}
			else
			{
				List<MobileParty> list6 = new List<MobileParty>();
				List<Hero> list7 = new List<Hero>();
				List<CampaignTime> list8 = new List<CampaignTime>();
				List<string> list9 = new List<string>();
				List<bool> list10 = new List<bool>();
				dataStore.SyncData<List<MobileParty>>("ProtectedPartiesList", ref list6);
				dataStore.SyncData<List<Hero>>("ProtectedLeadersList", ref list7);
				dataStore.SyncData<List<CampaignTime>>("ProtectedStartTimesList", ref list8);
				dataStore.SyncData<List<string>>("ProtectedActionsList", ref list9);
				dataStore.SyncData<List<bool>>("ProtectedWarningsList", ref list10);
				_protectedParties = new Dictionary<MobileParty, ProtectionInfo>();
				if (list6 != null && list7 != null && list6.Count == list7.Count)
				{
					for (int num = 0; num < list6.Count; num++)
					{
						if (list6[num] != null && list7[num] != null)
						{
							_protectedParties[list6[num]] = new ProtectionInfo
							{
								OriginalLeader = list7[num],
								ProtectionStartTime = ((list8 != null && num < list8.Count) ? list8[num] : CampaignTime.Now),
								ActionName = ((list9 != null && num < list9.Count) ? list9[num] : "Unknown"),
								WarningShown = (list10 != null && num < list10.Count && list10[num])
							};
						}
					}
				}
			}
			dataStore.SyncData<Dictionary<Hero, CampaignTime>>("_lastWarningTime", ref _lastWarningTime);
		}
		catch (Exception ex)
		{
			LogError("Error in SyncData: " + ex.Message);
		}
	}

	public void RegisterPartyForProtection(MobileParty party, Hero leader, string actionName)
	{
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		if (party != null && leader != null && !_protectedParties.ContainsKey(party))
		{
			_protectedParties[party] = new ProtectionInfo
			{
				OriginalLeader = leader,
				ProtectionStartTime = CampaignTime.Now,
				ActionName = actionName,
				WarningShown = false
			};
			LogDebug($"Registered party {party.Name} for protection (Leader: {leader.Name}, Action: {actionName})");
			if (leader.IsNoncombatant && ShouldShowWarning(leader))
			{
				ShowNonCombatantWarning(leader, actionName);
				_protectedParties[party].WarningShown = true;
				_lastWarningTime[leader] = CampaignTime.Now;
			}
		}
	}

	public void UnregisterPartyProtection(MobileParty party)
	{
		if (party != null && _protectedParties.ContainsKey(party))
		{
			LogDebug($"Unregistered party {party.Name} from protection");
			_protectedParties.Remove(party);
		}
	}

	public bool IsPartyProtected(MobileParty party)
	{
		return party != null && _protectedParties.ContainsKey(party);
	}

	private bool ShouldShowWarning(Hero hero)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		if (!_lastWarningTime.ContainsKey(hero))
		{
			return true;
		}
		CampaignTime val = _lastWarningTime[hero];
		return (val).ElapsedHoursUntilNow >= 24f;
	}

	private void ShowNonCombatantWarning(Hero leader, string actionName)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		try
		{
			TextObject val = new TextObject("{=AIInfluence_NonCombatantWarning}{HERO_NAME} is a non-combatant leading a party for action '{ACTION}'. After the task completes, vanilla game may disband this party or replace the leader.", (Dictionary<string, object>)null);
			val.SetTextVariable("HERO_NAME", leader.Name);
			val.SetTextVariable("ACTION", actionName);
			InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), Color.FromUint(4294945280u)));
			LogDebug($"Showed non-combatant warning for {leader.Name}");
		}
		catch (Exception ex)
		{
			LogError("Error showing non-combatant warning: " + ex.Message);
		}
	}

	private void OnPartyDisbandStarted(MobileParty party)
	{
		if (!IsPartyProtected(party))
		{
			return;
		}
		try
		{
			ProtectionInfo protectionInfo = _protectedParties[party];
			LogDebug($"Preventing disband attempt for protected party {party.Name} (Action: {protectionInfo.ActionName})");
			RemovePartyFromDisbandQueue(party);
			DelayedTaskManager delayedTaskManager = AIInfluenceBehavior.Instance?.GetDelayedTaskManager();
			if (delayedTaskManager != null)
			{
				delayedTaskManager.AddTask(0.10000000149011612, delegate
				{
					try
					{
						CampaignEventDispatcher instance2 = CampaignEventDispatcher.Instance;
						if (instance2 != null)
						{
							((CampaignEventReceiver)instance2).OnPartyDisbandCanceled(party);
						}
						LogDebug($"Canceled disband for protected party {party.Name}");
					}
					catch (Exception ex3)
					{
						LogError("Error canceling disband: " + ex3.Message);
					}
				});
				return;
			}
			try
			{
				CampaignEventDispatcher instance = CampaignEventDispatcher.Instance;
				if (instance != null)
				{
					((CampaignEventReceiver)instance).OnPartyDisbandCanceled(party);
				}
				LogDebug($"Canceled disband for protected party {party.Name} (immediate)");
			}
			catch (Exception ex)
			{
				LogError("Error canceling disband (immediate): " + ex.Message);
			}
		}
		catch (Exception ex2)
		{
			LogError("Error in OnPartyDisbandStarted: " + ex2.Message);
		}
	}

	private void RemovePartyFromDisbandQueue(MobileParty party)
	{
		try
		{
			Campaign current = Campaign.Current;
			IDisbandPartyCampaignBehavior obj = ((current != null) ? current.GetCampaignBehavior<IDisbandPartyCampaignBehavior>() : null);
			CampaignBehaviorBase val = (CampaignBehaviorBase)(object)((obj is CampaignBehaviorBase) ? obj : null);
			if (val == null)
			{
				return;
			}
			FieldInfo field = ((object)val).GetType().GetField("_partiesThatWaitingToDisband", BindingFlags.Instance | BindingFlags.NonPublic);
			if (!(field != null) || !(field.GetValue(val) is Dictionary<MobileParty, CampaignTime> dictionary) || !dictionary.ContainsKey(party))
			{
				return;
			}
			dictionary.Remove(party);
			LogDebug($"Removed {party.Name} from disband queue via reflection");
			if (party.IsDisbanding)
			{
				FieldInfo field2 = typeof(MobileParty).GetField("_isDisbanding", BindingFlags.Instance | BindingFlags.NonPublic);
				if (field2 != null)
				{
					field2.SetValue(party, false);
					LogDebug($"Cleared IsDisbanding flag for {party.Name}");
				}
			}
		}
		catch (Exception ex)
		{
			LogError("Error removing party from disband queue: " + ex.Message);
		}
	}

	private void OnDailyTickParty(MobileParty party)
	{
		if (!IsPartyProtected(party))
		{
			return;
		}
		try
		{
			ProtectionInfo info = _protectedParties[party];
			RemovePartyFromDisbandQueue(party);
			if (party.LeaderHero != info.OriginalLeader && party.LeaderHero != null)
			{
				LogDebug($"WARNING: Leader of protected party {party.Name} was replaced! Original: {info.OriginalLeader.Name}, New: {party.LeaderHero.Name}");
				if (!info.OriginalLeader.IsAlive || info.OriginalLeader.PartyBelongedTo == party || info.OriginalLeader.PartyBelongedTo != null)
				{
					return;
				}
				LogDebug($"Attempting to restore original leader {info.OriginalLeader.Name} to party {party.Name}");
				(AIInfluenceBehavior.Instance?.GetDelayedTaskManager())?.AddTask(0.20000000298023224, delegate
				{
					try
					{
						if (party.IsActive && party.LeaderHero != info.OriginalLeader && info.OriginalLeader.IsAlive && info.OriginalLeader.PartyBelongedTo == null)
						{
							party.RemovePartyLeader();
							TeleportHeroAction.ApplyDelayedTeleportToPartyAsPartyLeader(info.OriginalLeader, party);
							LogDebug($"Restored original leader {info.OriginalLeader.Name} to party {party.Name} via teleportation");
							RemovePartyFromDisbandQueue(party);
						}
					}
					catch (Exception ex2)
					{
						LogError("Error restoring leader: " + ex2.Message);
					}
				});
			}
			else if (party.LeaderHero == null)
			{
				if (!info.OriginalLeader.IsAlive || info.OriginalLeader.PartyBelongedTo != null)
				{
					return;
				}
				LogDebug($"Leader was removed from protected party {party.Name}, attempting to restore");
				(AIInfluenceBehavior.Instance?.GetDelayedTaskManager())?.AddTask(0.20000000298023224, delegate
				{
					try
					{
						if (party.IsActive && party.LeaderHero == null && info.OriginalLeader.IsAlive && info.OriginalLeader.PartyBelongedTo == null)
						{
							TeleportHeroAction.ApplyDelayedTeleportToPartyAsPartyLeader(info.OriginalLeader, party);
							LogDebug($"Restored original leader {info.OriginalLeader.Name} to party {party.Name} via teleportation");
							RemovePartyFromDisbandQueue(party);
						}
					}
					catch (Exception ex2)
					{
						LogError("Error restoring removed leader: " + ex2.Message);
					}
				});
			}
			else if (party.LeaderHero == info.OriginalLeader)
			{
				LogDebug($"Protected party {party.Name} daily check passed (Leader: {party.LeaderHero.Name})");
			}
		}
		catch (Exception ex)
		{
			LogError("Error in OnDailyTickParty: " + ex.Message);
		}
	}

	private void OnHeroTeleportationRequested(Hero hero, Settlement targetSettlement, MobileParty targetParty, TeleportationDetail detail)
	{
		if (targetParty != null && hero != null && IsPartyProtected(targetParty))
		{
			ProtectionInfo protectionInfo = _protectedParties[targetParty];
			if (hero != protectionInfo.OriginalLeader)
			{
				LogDebug($"BLOCKED: Attempt to replace leader of protected party {targetParty.Name}. Original: {protectionInfo.OriginalLeader.Name}, Attempted replacement: {hero.Name}");
			}
		}
	}

	private void OnHourlyTick()
	{
		try
		{
			List<MobileParty> list = _protectedParties.Keys.ToList();
			foreach (MobileParty item in list)
			{
				if (item != null && item.IsActive)
				{
					RemovePartyFromDisbandQueue(item);
				}
			}
		}
		catch (Exception ex)
		{
			LogError("Error in OnHourlyTick: " + ex.Message);
		}
	}

	private void OnPartyRemoved(PartyBase party)
	{
		if (((party != null) ? party.MobileParty : null) != null && IsPartyProtected(party.MobileParty))
		{
			LogDebug($"Protected party {party.MobileParty.Name} was removed from game");
			UnregisterPartyProtection(party.MobileParty);
		}
	}

	public void CleanupOldWarnings()
	{
		List<Hero> list = (from kvp in _lastWarningTime.Where(delegate(KeyValuePair<Hero, CampaignTime> kvp)
			{
				//IL_0002: Unknown result type (might be due to invalid IL or missing references)
				//IL_0007: Unknown result type (might be due to invalid IL or missing references)
				CampaignTime value = kvp.Value;
				return (value).ElapsedHoursUntilNow > 48f;
			})
			select kvp.Key).ToList();
		foreach (Hero item in list)
		{
			_lastWarningTime.Remove(item);
		}
	}

	private void LogDebug(string message)
	{
		AIActionsLogger.Instance.Log("[NonCombatantPartyProtector] " + message);
	}

	private void LogError(string message)
	{
		AIActionsLogger.Instance.Log("[NonCombatantPartyProtector] ERROR: " + message);
	}
}
