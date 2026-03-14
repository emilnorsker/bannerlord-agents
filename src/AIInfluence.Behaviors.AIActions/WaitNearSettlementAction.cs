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

public sealed class WaitNearSettlementAction : AIActionBase
{
	private class WaitRequest
	{
		public string SettlementId { get; }

		public float WaitDays { get; }

		public float Radius { get; }

		public WaitRequest(string settlementId, float waitDays, float radius)
		{
			SettlementId = settlementId;
			WaitDays = waitDays;
			Radius = radius;
		}
	}

	public const float DEFAULT_WAIT_DAYS = 2f;

	public const float MIN_DISTANCE = 7f;

	public const float MAX_DISTANCE = 18f;

	private const float ORDER_INTERVAL_HOURS = 0.35f;

	private static readonly Dictionary<string, WaitRequest> _pendingRequests = new Dictionary<string, WaitRequest>();

	private Settlement _targetSettlement;

	private MobileParty _heroParty;

	private CampaignTime _waitDuration = CampaignTime.Days(2f);

	private CampaignTime? _waitUntil;

	private bool _isWaiting;

	private float _desiredRadius = 10f;

	private CampaignTime _lastOrderTime = CampaignTime.Zero;

	private bool _arrivalAnnounced;

	private bool _isTemporaryPartyCreated;

	private Settlement _originSettlement;

	public override string ActionName => "wait_near_settlement";

	public override string Description => "Hero waits outside a settlement for a period of time";

	public static bool PrepareWaitRequest(Hero hero, Settlement settlement, float waitDays, float desiredRadius)
	{
		if (hero == null || settlement == null)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[wait_near_settlement] PrepareWaitRequest failed - hero or settlement missing");
			return false;
		}
		waitDays = MathF.Max(0.1f, waitDays);
		desiredRadius = MathF.Clamp(desiredRadius, 7f, 18f);
		_pendingRequests[((MBObjectBase)hero).StringId] = new WaitRequest(((MBObjectBase)settlement).StringId, waitDays, desiredRadius);
		AIInfluenceBehavior.Instance?.LogMessage($"[wait_near_settlement] Stored request for {hero.Name} (target={((MBObjectBase)settlement).StringId}, days={waitDays}, radius={desiredRadius})");
		return true;
	}

	public override void Initialize(Hero hero)
	{
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		base.Initialize(hero);
		_targetSettlement = null;
		_heroParty = null;
		_waitUntil = null;
		_isWaiting = false;
		_arrivalAnnounced = false;
		_isTemporaryPartyCreated = false;
		object obj = ((hero != null) ? hero.StayingInSettlement : null);
		if (obj == null)
		{
			obj = ((hero != null) ? hero.CurrentSettlement : null);
			if (obj == null)
			{
				if (hero == null)
				{
					obj = null;
				}
				else
				{
					MobileParty partyBelongedTo = hero.PartyBelongedTo;
					obj = ((partyBelongedTo != null) ? partyBelongedTo.CurrentSettlement : null);
				}
				if (obj == null)
				{
					obj = ((hero != null) ? hero.HomeSettlement : null) ?? ((hero != null) ? hero.BornSettlement : null);
				}
			}
		}
		_originSettlement = (Settlement)obj;
		if (hero != null && _pendingRequests.TryGetValue(((MBObjectBase)hero).StringId, out var request))
		{
			_pendingRequests.Remove(((MBObjectBase)hero).StringId);
			_targetSettlement = ((List<Settlement>)(object)Settlement.All).Find((Predicate<Settlement>)((Settlement s) => ((MBObjectBase)s).StringId == request.SettlementId));
			_waitDuration = CampaignTime.Days(request.WaitDays);
			_desiredRadius = MathF.Clamp(request.Radius, 7f, 18f);
		}
	}

	public override bool CanExecute()
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		if (base.TargetHero == null || base.TargetHero.IsDead || base.TargetHero.IsPrisoner)
		{
			return false;
		}
		if (_targetSettlement == null)
		{
			LogError("Target settlement is not set. Use wait_near_settlement:<settlement_id> first.");
			TextObject val = new TextObject("{=AIAction_WaitNearNoTarget}{HERO_NAME} cannot wait - target settlement is not set.", (Dictionary<string, object>)null);
			val.SetTextVariable("HERO_NAME", base.TargetHero.Name);
			ShowErrorMessage(val);
			return false;
		}
		if (base.TargetHero.Clan == null)
		{
			LogError("Cannot wait near settlement: hero has no clan (notables/tavern companions cannot wait outside)");
			TextObject val2 = new TextObject("{=AIAction_WaitNearNoClan}{HERO_NAME} cannot wait near settlement - only clan members and lords can wait outside settlements.", (Dictionary<string, object>)null);
			val2.SetTextVariable("HERO_NAME", base.TargetHero.Name);
			ShowErrorMessage(val2);
			return false;
		}
		if (!HeroHasIndependentParty(base.TargetHero, out var reason))
		{
			LogAction("Hero has no independent party (" + reason + "), attempting to create real clan party");
		}
		return true;
	}

	protected override void OnStart()
	{
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		if (!CanExecute())
		{
			Stop();
			return;
		}
		if (_targetSettlement == null && !TryLoadRequestFromTask())
		{
			LogError("Target settlement not found for wait_near_settlement");
			TextObject val = new TextObject("{=AIAction_WaitNearSettlementNotFound}{HERO_NAME} cannot wait - target settlement not found.", (Dictionary<string, object>)null);
			Hero targetHero = base.TargetHero;
			val.SetTextVariable("HERO_NAME", ((targetHero == null) ? null : ((object)targetHero.Name)?.ToString()) ?? "Unknown");
			ShowErrorMessage(val);
			Stop();
			return;
		}
		_heroParty = EnsurePartyForWaiting(out var createdNew);
		_isTemporaryPartyCreated = createdNew;
		if (_heroParty == null)
		{
			LogError("Failed to get or create party for waiting");
			TextObject val2 = new TextObject("{=AIAction_WaitNearNoParty}{HERO_NAME} cannot wait - failed to create a party.", (Dictionary<string, object>)null);
			Hero targetHero2 = base.TargetHero;
			val2.SetTextVariable("HERO_NAME", ((targetHero2 == null) ? null : ((object)targetHero2.Name)?.ToString()) ?? "Unknown");
			ShowErrorMessage(val2);
			Stop();
			return;
		}
		if (_heroParty.CurrentSettlement != null)
		{
			try
			{
				LeaveSettlementAction.ApplyForParty(_heroParty);
			}
			catch (Exception ex)
			{
				LogError("Failed to exit settlement before waiting: " + ex.Message);
			}
		}
		_waitUntil = null;
		_isWaiting = false;
		_arrivalAnnounced = false;
		OrderPatrolAroundSettlement(initial: true);
	}

	protected override void OnUpdate(float deltaTime)
	{
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Expected O, but got Unknown
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		if (!base.IsActive || _heroParty == null || _targetSettlement == null)
		{
			return;
		}
		if (!_isTemporaryPartyCreated && _heroParty != null && _heroParty.LeaderHero != null && _heroParty.LeaderHero != base.TargetHero)
		{
			Hero targetHero = base.TargetHero;
			TextObject arg = ((targetHero != null) ? targetHero.Name : null);
			Hero leaderHero = _heroParty.LeaderHero;
			LogError($"Party leader was replaced! Original: {arg}, New: {((leaderHero != null) ? leaderHero.Name : null)}. Stopping action.");
			TextObject val = new TextObject("{=AIAction_WaitNearLeaderReplaced}{HERO_NAME} was removed from party leadership. Action stopped.", (Dictionary<string, object>)null);
			Hero targetHero2 = base.TargetHero;
			val.SetTextVariable("HERO_NAME", ((targetHero2 == null) ? null : ((object)targetHero2.Name)?.ToString()) ?? "Unknown");
			InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), Color.FromUint(4294936576u)));
			Stop();
		}
		else
		{
			if (_heroParty.MapEvent != null)
			{
				return;
			}
			if (_heroParty.CurrentSettlement == _targetSettlement)
			{
				try
				{
					LeaveSettlementAction.ApplyForParty(_heroParty);
					return;
				}
				catch (Exception ex)
				{
					LogError("Failed to force party out of settlement: " + ex.Message);
					return;
				}
			}
			float distanceToSettlement = GetDistanceToSettlement();
			if (!_isWaiting && distanceToSettlement <= _desiredRadius + 1f)
			{
				StartWaiting();
			}
			if (_isWaiting && _waitUntil.HasValue && CampaignTime.Now >= _waitUntil.Value)
			{
				Stop();
			}
			else if (CampaignTime.Now - _lastOrderTime >= CampaignTime.Hours(0.35f))
			{
				OrderPatrolAroundSettlement();
			}
		}
	}

	protected override void OnStop()
	{
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Expected O, but got Unknown
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
		if (_heroParty == null || _targetSettlement == null)
		{
			CompleteTaskStepIfNeeded();
			return;
		}
		if (_isWaiting)
		{
			TextObject val = new TextObject("{=AIAction_WaitNearCompleted}{HERO_NAME} finished waiting near {SETTLEMENT_NAME}.", (Dictionary<string, object>)null);
			Hero targetHero = base.TargetHero;
			val.SetTextVariable("HERO_NAME", ((targetHero == null) ? null : ((object)targetHero.Name)?.ToString()) ?? "Unknown");
			val.SetTextVariable("SETTLEMENT_NAME", ((object)_targetSettlement.Name)?.ToString() ?? "Unknown");
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
			LogAction($"Finished waiting near {_targetSettlement.Name}");
		}
		CompleteTaskStepIfNeeded();
	}

	private void StartWaiting()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		_isWaiting = true;
		_waitUntil = CampaignTime.Now + _waitDuration;
		if (!_arrivalAnnounced)
		{
			TextObject val = new TextObject("{=AIAction_WaitNearArrived}{HERO_NAME} is holding position near {SETTLEMENT_NAME} (radius: {RADIUS}).", (Dictionary<string, object>)null);
			Hero targetHero = base.TargetHero;
			val.SetTextVariable("HERO_NAME", ((targetHero == null) ? null : ((object)targetHero.Name)?.ToString()) ?? "Unknown");
			val.SetTextVariable("SETTLEMENT_NAME", ((object)_targetSettlement.Name)?.ToString() ?? "Unknown");
			val.SetTextVariable("RADIUS", _desiredRadius.ToString("0.0"));
			InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), ExtraColors.GreenAIInfluence));
			LogAction($"Arrived near {_targetSettlement.Name}, waiting for {(_waitDuration).ToDays:F1} days at radius {_desiredRadius}");
			_arrivalAnnounced = true;
		}
	}

	private void OrderPatrolAroundSettlement(bool initial = false)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected O, but got Unknown
		if (_heroParty == null || _targetSettlement == null)
		{
			return;
		}
		try
		{
			CampaignVec2 val = _targetSettlement.Position;
			Vec2 val2 = (val).ToVec2();
			val = _targetSettlement.GatePosition;
			Vec2 val3 = (val).ToVec2();
			Vec2 val4 = val3 - val2;
			if ((val4).LengthSquared < 0.25f)
			{
				(val4)._002Ector(1f, 0f);
			}
			(val4).Normalize();
			Vec2 val5 = val2 + val4 * MathF.Clamp(_desiredRadius, 7f, 18f);
			CampaignVec2 val6 = default(CampaignVec2);
			(val6)._002Ector(val5, true);
			_heroParty.SetMovePatrolAroundPoint(val6, (NavigationType)3);
			GameVersionCompatibility.ConditionalEnableAi(_heroParty);
			_lastOrderTime = CampaignTime.Now;
			if (!initial)
			{
				return;
			}
			TextObject val7 = new TextObject("{=AIAction_WaitNearIssued}{HERO_NAME} will wait near {SETTLEMENT_NAME}.", (Dictionary<string, object>)null);
			Hero targetHero = base.TargetHero;
			val7.SetTextVariable("HERO_NAME", ((targetHero == null) ? null : ((object)targetHero.Name)?.ToString()) ?? "Unknown");
			val7.SetTextVariable("SETTLEMENT_NAME", ((object)_targetSettlement.Name)?.ToString() ?? "Unknown");
			DelayedTaskManager delayedTaskManager = AIInfluenceBehavior.Instance?.GetDelayedTaskManager();
			if (delayedTaskManager != null)
			{
				string text = ((object)val7).ToString();
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
				InformationManager.DisplayMessage(new InformationMessage(((object)val7).ToString(), ExtraColors.GreenAIInfluence));
			}
			LogAction($"Issued wait_near_settlement order for {_targetSettlement.Name}");
		}
		catch (Exception ex)
		{
			LogError("Failed to issue wait-near order: " + ex.Message);
		}
	}

	private float GetDistanceToSettlement()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		if (_heroParty == null || _targetSettlement == null)
		{
			return float.MaxValue;
		}
		Vec2 position2D = _heroParty.GetPosition2D();
		CampaignVec2 position = _targetSettlement.Position;
		return (position2D).Distance((position).ToVec2());
	}

	private MobileParty EnsurePartyForWaiting(out bool createdNew)
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
			LogAction($"{base.TargetHero.Name} needs party for waiting - creating real clan party");
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
					LogAction("Party created on map, ready to wait");
				}
				else
				{
					LogAction($"Party created in settlement {val.CurrentSettlement.Name}, will exit first");
				}
				NonCombatantPartyProtector instance = NonCombatantPartyProtector.Instance;
				if (instance != null)
				{
					instance.RegisterPartyForProtection(val, base.TargetHero, "WaitNearSettlement");
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
		if (hero == null)
		{
			reason = "hero reference is null";
			return false;
		}
		MobileParty partyBelongedTo = hero.PartyBelongedTo;
		if (partyBelongedTo == null)
		{
			reason = "party reference is null";
			return false;
		}
		if (partyBelongedTo == MobileParty.MainParty)
		{
			reason = "hero is in the player's main party";
			return false;
		}
		if (partyBelongedTo.LeaderHero != hero)
		{
			reason = "hero is not the leader of their party";
			return false;
		}
		return true;
	}

	public override Dictionary<string, string> GetStateDataForSave()
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		if (_targetSettlement == null)
		{
			return null;
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string>
		{
			["settlementId"] = ((MBObjectBase)_targetSettlement).StringId,
			["radius"] = _desiredRadius.ToString(CultureInfo.InvariantCulture),
			["isWaiting"] = _isWaiting.ToString()
		};
		float num;
		if (_isWaiting && _waitUntil.HasValue)
		{
			CampaignTime val = _waitUntil.Value;
			double toHours = (val).ToHours;
			val = CampaignTime.Now;
			num = MathF.Max(0.1f, (float)(toHours - (val).ToHours));
		}
		else
		{
			num = (float)(_waitDuration).ToHours;
		}
		dictionary["remainingHours"] = num.ToString(CultureInfo.InvariantCulture);
		return dictionary;
	}

	private bool TryLoadRequestFromTask()
	{
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		TaskManager instance = TaskManager.Instance;
		if (instance == null)
		{
			return false;
		}
		TaskStep taskStep = instance.GetActiveTask(base.TargetHero)?.GetCurrentStep();
		if (taskStep == null || taskStep.StepType != TaskStepType.WaitNearSettlement)
		{
			return false;
		}
		Settlement targetSettlement = taskStep.GetTargetSettlement();
		if (targetSettlement == null)
		{
			LogError("WaitNear step does not have target settlement");
			return false;
		}
		float num = ((taskStep.WaitNearDurationDays > 0f) ? taskStep.WaitNearDurationDays : 2f);
		float num2 = ((taskStep.WaitNearRadius > 0f) ? taskStep.WaitNearRadius : 10f);
		_targetSettlement = targetSettlement;
		_waitDuration = CampaignTime.Days(num);
		_desiredRadius = MathF.Clamp(num2, 7f, 18f);
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
		if (taskStep == null || taskStep.StepType != TaskStepType.WaitNearSettlement)
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
}
