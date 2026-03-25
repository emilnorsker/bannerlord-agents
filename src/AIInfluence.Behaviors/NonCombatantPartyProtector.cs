using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using AIInfluence.Behaviors.AIActions;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Behaviors;

public class NonCombatantPartyProtector : CampaignBehaviorBase
{
	private class NonCombatantPartyProtectorState
	{
		public List<ProtectionInfoState> ProtectedParties { get; set; } = new List<ProtectionInfoState>();

		public Dictionary<string, double> LastWarningTimeDays { get; set; } = new Dictionary<string, double>();
	}

	private class ProtectionInfoState
	{
		public string PartyId { get; set; }

		public string OriginalLeaderId { get; set; }

		public double ProtectionStartTimeDays { get; set; }

		public string ActionName { get; set; }

		public bool WarningShown { get; set; }
	}

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

	private static string CompressPayload(string payload)
	{
		if (string.IsNullOrEmpty(payload))
		{
			return payload;
		}
		byte[] bytes = Encoding.UTF8.GetBytes(payload);
		using MemoryStream memoryStream = new MemoryStream();
		using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionLevel.Optimal, leaveOpen: true))
		{
			gZipStream.Write(bytes, 0, bytes.Length);
		}
		return "gz:" + Convert.ToBase64String(memoryStream.ToArray());
	}

	private static string DecompressPayload(string payload)
	{
		if (string.IsNullOrEmpty(payload) || !payload.StartsWith("gz:"))
		{
			return payload;
		}
		byte[] buffer = Convert.FromBase64String(payload.Substring(3));
		using MemoryStream stream = new MemoryStream(buffer);
		using GZipStream stream2 = new GZipStream(stream, CompressionMode.Decompress);
		using StreamReader streamReader = new StreamReader(stream2, Encoding.UTF8);
		return streamReader.ReadToEnd();
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
		string syncStage = "sync-start";
		try
		{
			LogDebug($"[SYNC-TRACE] NonCombatantPartyProtector.SyncData enter. isSaving={dataStore.IsSaving}, isLoading={dataStore.IsLoading}");
			string serializedState = null;
			if (dataStore.IsSaving)
			{
				syncStage = "save-serialize-state";
				serializedState = CompressPayload(SerializeState());
			}
			syncStage = "sync-state-json";
			dataStore.SyncData<string>("AIInfluence_nonCombatantPartyProtectorStateJson", ref serializedState);
			if (dataStore.IsLoading)
			{
				_protectedParties = new Dictionary<MobileParty, ProtectionInfo>();
				_lastWarningTime = new Dictionary<Hero, CampaignTime>();
				LogDebug("[SYNC-TRACE] NonCombatantPartyProtector.SyncData payloadLength=" + (serializedState?.Length ?? 0));
				if (!string.IsNullOrEmpty(serializedState))
				{
					syncStage = "load-deserialize-state";
					DeserializeState(DecompressPayload(serializedState));
				}
			}
			LogDebug("[SYNC-TRACE] NonCombatantPartyProtector.SyncData exit success.");
		}
		catch (Exception ex)
		{
			LogError("SyncData failed at stage=" + syncStage + ". protectedCount=" + (_protectedParties?.Count ?? 0) + ", warningCount=" + (_lastWarningTime?.Count ?? 0) + ". " + ex);
			if (dataStore.IsLoading)
			{
				LogError("NonCombatantPartyProtector SyncData load failed; not applying empty state (v5.0.0).");
			}
			throw;
		}
	}

	private string SerializeState()
	{
		NonCombatantPartyProtectorState nonCombatantPartyProtectorState = new NonCombatantPartyProtectorState();
		foreach (KeyValuePair<MobileParty, ProtectionInfo> protectedParty in _protectedParties)
		{
			MobileParty key = protectedParty.Key;
			ProtectionInfo value = protectedParty.Value;
			if (key == null || value?.OriginalLeader == null)
			{
				continue;
			}
			CampaignTime protectionStartTime = value.ProtectionStartTime;
			nonCombatantPartyProtectorState.ProtectedParties.Add(new ProtectionInfoState
			{
				PartyId = ((MBObjectBase)key).StringId,
				OriginalLeaderId = ((MBObjectBase)value.OriginalLeader).StringId,
				ProtectionStartTimeDays = (protectionStartTime).ToDays,
				ActionName = value.ActionName,
				WarningShown = value.WarningShown
			});
		}
		foreach (KeyValuePair<Hero, CampaignTime> item in _lastWarningTime)
		{
			if (item.Key != null)
			{
				CampaignTime value2 = item.Value;
				nonCombatantPartyProtectorState.LastWarningTimeDays[((MBObjectBase)item.Key).StringId] = (value2).ToDays;
			}
		}
		return JsonConvert.SerializeObject(nonCombatantPartyProtectorState);
	}

	private void DeserializeState(string serializedState)
	{
		if (string.IsNullOrEmpty(serializedState))
		{
			return;
		}
		NonCombatantPartyProtectorState nonCombatantPartyProtectorState = JsonConvert.DeserializeObject<NonCombatantPartyProtectorState>(serializedState) ?? throw new InvalidOperationException("NonCombatantPartyProtector state payload deserialized to null.");
		foreach (ProtectionInfoState protectedParty in nonCombatantPartyProtectorState.ProtectedParties ?? new List<ProtectionInfoState>())
		{
			if (protectedParty == null || string.IsNullOrEmpty(protectedParty.PartyId) || string.IsNullOrEmpty(protectedParty.OriginalLeaderId))
			{
				continue;
			}
			MobileParty mobileParty = ((IEnumerable<MobileParty>)MobileParty.All).FirstOrDefault((Func<MobileParty, bool>)((MobileParty p) => ((MBObjectBase)p).StringId == protectedParty.PartyId));
			Hero val = Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == protectedParty.OriginalLeaderId));
			if (mobileParty != null && val != null)
			{
				_protectedParties[mobileParty] = new ProtectionInfo
				{
					OriginalLeader = val,
					ProtectionStartTime = CampaignTime.Days((float)protectedParty.ProtectionStartTimeDays),
					ActionName = protectedParty.ActionName ?? "Unknown",
					WarningShown = protectedParty.WarningShown
				};
			}
		}
		foreach (KeyValuePair<string, double> item in nonCombatantPartyProtectorState.LastWarningTimeDays ?? new Dictionary<string, double>())
		{
			if (!string.IsNullOrEmpty(item.Key))
			{
				Hero val2 = Hero.FindFirst((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == item.Key));
				if (val2 != null)
				{
					_lastWarningTime[val2] = CampaignTime.Days((float)item.Value);
				}
			}
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
