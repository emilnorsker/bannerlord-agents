using System;
using System.Collections.Generic;
using System.Globalization;
using AIInfluence.Behaviors.AIActions.TaskSystem;
using AIInfluence.Util;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Behaviors.AIActions;

public sealed class PatrolSettlementAction : AIActionBase
{
	private class PatrolRequest
	{
		public string SettlementId { get; }

		public float DurationDays { get; }

		public bool AutoReturn { get; }

		public PatrolRequest(string settlementId, float durationDays, bool autoReturn)
		{
			SettlementId = settlementId;
			DurationDays = durationDays;
			AutoReturn = autoReturn;
		}
	}

	public const float DEFAULT_PATROL_DAYS = 7f;

	private static readonly Dictionary<string, PatrolRequest> _pendingRequests = new Dictionary<string, PatrolRequest>();

	private static readonly Dictionary<string, string> _activeTargets = new Dictionary<string, string>();

	private static readonly object _activeTargetsLock = new object();

	private PatrolRequest _activeRequest;

	private Settlement _targetSettlement;

	private MobileParty _heroParty;

	private bool _autoReturn;

	private CampaignTime _patrolUntil;

	private CampaignTime _lastPatrolOrderTime = CampaignTime.Zero;

	private bool _patrolCompleted;

	private bool _isTemporaryPartyCreated;

	public override string ActionName => "patrol_settlement";

	public override string Description => "Hero patrols around a target settlement";

	public static bool PreparePatrolRequest(Hero hero, string settlementId, float durationDays, bool autoReturn)
	{
		if (hero == null || string.IsNullOrWhiteSpace(settlementId))
		{
			AIInfluenceBehavior.Instance?.LogMessage("[patrol_settlement] PreparePatrolRequest failed - hero or settlement missing");
			return false;
		}
		_pendingRequests[((MBObjectBase)hero).StringId] = new PatrolRequest(settlementId.Trim(), MathF.Max(0.1f, durationDays), autoReturn);
		AIInfluenceBehavior.Instance?.LogMessage($"[patrol_settlement] Stored patrol request for {hero.Name} (target={settlementId}, duration={durationDays}, return={autoReturn})");
		return true;
	}

	public static bool TryGetActivePatrolTargetId(Hero hero, out string settlementId)
	{
		settlementId = null;
		if (hero == null)
		{
			return false;
		}
		lock (_activeTargetsLock)
		{
			return _activeTargets.TryGetValue(((MBObjectBase)hero).StringId, out settlementId);
		}
	}

	private static void RegisterActiveTarget(Hero hero, Settlement settlement)
	{
		if (hero == null || settlement == null)
		{
			return;
		}
		lock (_activeTargetsLock)
		{
			_activeTargets[((MBObjectBase)hero).StringId] = ((MBObjectBase)settlement).StringId;
		}
	}

	private static void UnregisterActiveTarget(Hero hero)
	{
		if (hero == null)
		{
			return;
		}
		lock (_activeTargetsLock)
		{
			_activeTargets.Remove(((MBObjectBase)hero).StringId);
		}
	}

	public override void Initialize(Hero hero)
	{
		base.Initialize(hero);
		if (base.TargetHero != null && _pendingRequests.TryGetValue(((MBObjectBase)base.TargetHero).StringId, out var value))
		{
			_activeRequest = value;
			_pendingRequests.Remove(((MBObjectBase)base.TargetHero).StringId);
		}
	}

	public override bool CanExecute()
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		if (base.TargetHero == null || base.TargetHero.IsDead || base.TargetHero.IsPrisoner)
		{
			return false;
		}
		if (_activeRequest == null && !TryLoadRequestFromTask())
		{
			AIInfluenceBehavior.Instance?.LogMessage($"[patrol_settlement] No active request for {base.TargetHero.Name}");
			return false;
		}
		if (base.TargetHero.Clan == null)
		{
			LogError("Cannot patrol: hero has no clan (notables/tavern companions cannot patrol)");
			TextObject val = new TextObject("{=AIAction_PatrolNoClan}{HERO_NAME} cannot patrol - only clan members and lords can lead patrols.", (Dictionary<string, object>)null);
			val.SetTextVariable("HERO_NAME", base.TargetHero.Name);
			ShowErrorMessage(val);
			return false;
		}
		if (!HeroHasIndependentParty(base.TargetHero, out var reason))
		{
			LogAction("Hero has no independent party (" + reason + "), attempting to create real clan party");
		}
		_targetSettlement = ((List<Settlement>)(object)Settlement.All).Find((Predicate<Settlement>)((Settlement s) => ((MBObjectBase)s).StringId == _activeRequest.SettlementId));
		if (_targetSettlement == null)
		{
			LogError("Settlement '" + _activeRequest.SettlementId + "' not found");
			TextObject val2 = new TextObject("{=AIAction_PatrolSettlementNotFound}{HERO_NAME} cannot patrol - settlement '{SETTLEMENT_ID}' not found.", (Dictionary<string, object>)null);
			val2.SetTextVariable("HERO_NAME", base.TargetHero.Name);
			val2.SetTextVariable("SETTLEMENT_ID", _activeRequest.SettlementId);
			ShowErrorMessage(val2);
			return false;
		}
		if (_targetSettlement.MapFaction != null)
		{
			IFaction mapFaction = base.TargetHero.MapFaction;
			if (mapFaction != null && mapFaction.IsAtWarWith(_targetSettlement.MapFaction))
			{
			}
		}
		return true;
	}

	protected override void OnStart()
	{
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		if (!CanExecute())
		{
			Stop();
			return;
		}
		_heroParty = EnsurePartyForPatrol(out var createdNew);
		_isTemporaryPartyCreated = createdNew;
		if (_heroParty == null)
		{
			LogError("Failed to get or create party for patrol");
			TextObject val = new TextObject("{=AIAction_PatrolNoParty}{HERO_NAME} cannot patrol - failed to create a party.", (Dictionary<string, object>)null);
			Hero targetHero = base.TargetHero;
			val.SetTextVariable("HERO_NAME", ((targetHero == null) ? null : ((object)targetHero.Name)?.ToString()) ?? "Unknown");
			ShowErrorMessage(val);
			Stop();
			return;
		}
		_autoReturn = _activeRequest.AutoReturn;
		_patrolUntil = CampaignTime.Now + CampaignTime.Days(MathF.Max(_activeRequest.DurationDays, 7f));
		RegisterActiveTarget(base.TargetHero, _targetSettlement);
		if (_heroParty.CurrentSettlement != null)
		{
			try
			{
				LeaveSettlementAction.ApplyForParty(_heroParty);
			}
			catch (Exception ex)
			{
				LogError("Failed to exit settlement before patrol: " + ex.Message);
			}
		}
		OrderPatrol(initial: true);
	}

	protected override void OnUpdate(float deltaTime)
	{
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		if (!base.IsActive || _heroParty == null)
		{
			return;
		}
		if (!_isTemporaryPartyCreated && _heroParty != null && _heroParty.LeaderHero != null && _heroParty.LeaderHero != base.TargetHero)
		{
			Hero targetHero = base.TargetHero;
			TextObject arg = ((targetHero != null) ? targetHero.Name : null);
			Hero leaderHero = _heroParty.LeaderHero;
			LogError($"Party leader was replaced! Original: {arg}, New: {((leaderHero != null) ? leaderHero.Name : null)}. Stopping action.");
			TextObject val = new TextObject("{=AIAction_PatrolLeaderReplaced}{HERO_NAME} was removed from party leadership. Action stopped.", (Dictionary<string, object>)null);
			Hero targetHero2 = base.TargetHero;
			val.SetTextVariable("HERO_NAME", ((targetHero2 == null) ? null : ((object)targetHero2.Name)?.ToString()) ?? "Unknown");
			InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), Color.FromUint(4294936576u)));
			Stop();
		}
		else if (_heroParty.MapEvent == null)
		{
			if (CampaignTime.Now >= _patrolUntil)
			{
				_patrolCompleted = true;
				Stop();
			}
			else if (CampaignTime.Now - _lastPatrolOrderTime >= CampaignTime.Hours(0.4f))
			{
				OrderPatrol();
			}
		}
	}

	protected override void OnStop()
	{
		UnregisterActiveTarget(base.TargetHero);
		if (_heroParty != null && !_isTemporaryPartyCreated)
		{
			NonCombatantPartyProtector instance = NonCombatantPartyProtector.Instance;
			if (instance != null && instance.IsPartyProtected(_heroParty))
			{
				instance.UnregisterPartyProtection(_heroParty);
				LogAction($"Unregistered party {_heroParty.Name} from non-combatant protection");
			}
		}
		if (_isTemporaryPartyCreated && _heroParty != null && _heroParty != MobileParty.MainParty)
		{
			try
			{
				GameVersionCompatibility.SetMoveModeHold(_heroParty);
				GameVersionCompatibility.ConditionalEnableAi(_heroParty);
				LogAction($"Re-enabled AI for created party {_heroParty.Name}");
			}
			catch (Exception ex)
			{
				LogError("Error re-enabling AI: " + ex.Message);
			}
		}
		bool flag = CompleteTaskStepIfNeeded();
		if (_patrolCompleted && _autoReturn && !flag && !AIActionManager.Instance.StartAction(base.TargetHero, "return_to_player"))
		{
			LogError("Failed to start return_to_player after patrol");
		}
	}

	private void OrderPatrol(bool initial = false)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Expected O, but got Unknown
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		if (_heroParty == null || _targetSettlement == null)
		{
			return;
		}
		try
		{
			_heroParty.SetMovePatrolAroundSettlement(_targetSettlement, (NavigationType)3, false);
			GameVersionCompatibility.ConditionalEnableAi(_heroParty);
			_lastPatrolOrderTime = CampaignTime.Now;
			if (!initial)
			{
				return;
			}
			TextObject val = new TextObject("{=AIAction_PatrolIssued}{HERO_NAME} is patrolling around {SETTLEMENT_NAME}.", (Dictionary<string, object>)null);
			Hero targetHero = base.TargetHero;
			val.SetTextVariable("HERO_NAME", ((targetHero == null) ? null : ((object)targetHero.Name)?.ToString()) ?? "Unknown");
			Settlement targetSettlement = _targetSettlement;
			val.SetTextVariable("SETTLEMENT_NAME", ((targetSettlement == null) ? null : ((object)targetSettlement.Name)?.ToString()) ?? "Unknown");
			DelayedTaskManager delayedTaskManager = AIInfluenceBehavior.Instance?.GetDelayedTaskManager();
			if (delayedTaskManager != null)
			{
				string text = ((object)val).ToString();
				delayedTaskManager.AddTask(6.0, delegate
				{
					//IL_0007: Unknown result type (might be due to invalid IL or missing references)
					//IL_000c: Unknown result type (might be due to invalid IL or missing references)
					//IL_0016: Expected O, but got Unknown
					InformationManager.DisplayMessage(new InformationMessage(text, ExtraColors.GreenAIInfluence));
				});
			}
			else
			{
				InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), ExtraColors.GreenAIInfluence));
			}
			LogAction($"Patrolling {_targetSettlement.Name}");
		}
		catch (Exception ex)
		{
			LogError("Failed to issue patrol order: " + ex.Message);
		}
	}

	private bool TryLoadRequestFromTask()
	{
		TaskStep taskStep = (TaskManager.Instance?.GetActiveTask(base.TargetHero))?.GetCurrentStep();
		if (taskStep != null && taskStep.StepType == TaskStepType.PatrolSettlement)
		{
			float durationDays = ((taskStep.PatrolDurationDays > 0f) ? taskStep.PatrolDurationDays : 7f);
			_activeRequest = new PatrolRequest(taskStep.TargetSettlementId, durationDays, taskStep.PatrolAutoReturn);
			return true;
		}
		return false;
	}

	private MobileParty EnsurePartyForPatrol(out bool createdNew)
	{
		createdNew = false;
		if (base.TargetHero == null)
		{
			return null;
		}
		MobileParty val = base.TargetHero.PartyBelongedTo;
		MobileParty mainParty = MobileParty.MainParty;
		if (val != null && val != mainParty && val.LeaderHero == base.TargetHero)
		{
			LogAction($"{base.TargetHero.Name} already has independent party: {val.Name}");
			return val;
		}
		if (val == mainParty || val == null)
		{
			LogAction($"{base.TargetHero.Name} needs party for patrol - creating real clan party");
			val = CreateRealClanParty();
			if (val != null)
			{
				createdNew = true;
				LogAction($"Created real clan party for {base.TargetHero.Name}: {val.Name}");
			}
		}
		return val;
	}

	private MobileParty CreateRealClanParty()
	{
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		if (base.TargetHero == null || base.TargetHero.Clan == null)
		{
			LogError("Cannot create clan party - hero has no clan");
			return null;
		}
		try
		{
			LogAction($"Creating real clan party for {base.TargetHero.Name} (Clan: {base.TargetHero.Clan.Name})");
			MobileParty val = GameVersionCompatibility.CreateNewClanMobileParty(base.TargetHero, base.TargetHero.Clan);
			if (val == null)
			{
				LogError($"CreateNewClanMobileParty returned null for {base.TargetHero.Name}");
				return null;
			}
			val.IsVisible = true;
			val.IsActive = true;
			LogAction($"Real clan party created: {val.Name} at position {val.GetPosition2D()}");
			if (base.TargetHero.PartyBelongedTo == val && base.TargetHero.PartyBelongedTo != MobileParty.MainParty)
			{
				if (val.CurrentSettlement == null)
				{
					LogAction("Party created on map, ready for patrol");
				}
				else
				{
					LogAction($"Party created in settlement {val.CurrentSettlement.Name}, will exit first");
				}
				NonCombatantPartyProtector instance = NonCombatantPartyProtector.Instance;
				if (instance != null)
				{
					instance.RegisterPartyForProtection(val, base.TargetHero, "PatrolSettlement");
					LogAction($"Registered party {val.Name} for non-combatant protection");
				}
				return val;
			}
			MobileParty partyBelongedTo = base.TargetHero.PartyBelongedTo;
			LogError("Party creation did not assign hero correctly. Hero party: " + (((partyBelongedTo == null) ? null : ((object)partyBelongedTo.Name)?.ToString()) ?? "null"));
			return null;
		}
		catch (Exception ex)
		{
			LogError("Error creating real clan party: " + ex.Message + "\n" + ex.StackTrace);
			return null;
		}
	}

	private bool HeroHasIndependentParty(Hero hero, out string reason)
	{
		reason = string.Empty;
		MobileParty val = ((hero != null) ? hero.PartyBelongedTo : null);
		if (val == null)
		{
			reason = "party reference is null";
			return false;
		}
		if (val == MobileParty.MainParty)
		{
			reason = "hero is still attached to the player's main party";
			return false;
		}
		if (val.LeaderHero != hero)
		{
			reason = "hero is not the leader of their party";
			return false;
		}
		return true;
	}

	private bool CompleteTaskStepIfNeeded()
	{
		TaskManager instance = TaskManager.Instance;
		if (instance == null)
		{
			return false;
		}
		HeroTask activeTask = instance.GetActiveTask(base.TargetHero);
		TaskStep taskStep = activeTask?.GetCurrentStep();
		if (taskStep == null || taskStep.StepType != TaskStepType.PatrolSettlement)
		{
			return false;
		}
		if (instance.MoveToNextStep(base.TargetHero))
		{
			TaskStep currentStep = activeTask.GetCurrentStep();
			TaskStepExecutor.ExecuteNextTaskStep(base.TargetHero, currentStep);
		}
		return true;
	}

	public override Dictionary<string, string> GetStateDataForSave()
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		if (_targetSettlement == null)
		{
			return null;
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>
		{
			["settlementId"] = ((MBObjectBase)_targetSettlement).StringId,
			["autoReturn"] = _autoReturn.ToString()
		};
		double toHours = (_patrolUntil).ToHours;
		CampaignTime now = CampaignTime.Now;
		dictionary["remainingHours"] = MathF.Max(0.1f, (float)(toHours - (now).ToHours)).ToString(CultureInfo.InvariantCulture);
		return dictionary;
	}
}
