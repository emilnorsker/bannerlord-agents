using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AIInfluence.Behaviors.AIActions.TaskSystem;
using AIInfluence.Util;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Behaviors.AIActions;

public class GoToSettlementAction : AIActionBase
{
	private class DestinationRequest
	{
		public Settlement Settlement { get; }

		public CampaignTime WaitDuration { get; }

		public DestinationRequest(Settlement settlement, CampaignTime waitDuration)
		{
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			Settlement = settlement;
			WaitDuration = waitDuration;
		}
	}

	public const float DEFAULT_WAIT_DAYS = 3f;

	private static readonly Dictionary<string, DestinationRequest> PendingRequests = new Dictionary<string, DestinationRequest>();

	private Settlement _targetSettlement;

	private Settlement _originSettlement;

	private CampaignTime _waitDuration = CampaignTime.Days(3f);

	private CampaignTime? _waitUntil;

	private bool _hasArrived;

	private bool _isWaitingPhase;

	private bool _isTemporaryPartyCreated;

	private bool _stopRequested;

	private bool _handleReturnOnStop;

	private bool _skipTaskCancelOnStop;

	private MobileParty _trackedParty;

	private string _destinationName;

	private Vec2? _lastPartyPosition;

	private bool _waitingForSettlementExit;

	private TaskStepType? _pendingActionAfterExit;

	private bool _stopAfterPendingAction;

	private bool _holdModeActive;

	private CampaignTime _lastMoveOrderTime = CampaignTime.Zero;

	private bool _headingMessageShown;

	private int _moveCommandRetryCount = 0;

	private const int MAX_MOVE_RETRIES = 3;

	public override string ActionName => "go_to_settlement";

	public override string Description => "Hero travels to a settlement and waits for the player";

	public static bool PrepareDestination(Hero hero, Settlement settlement, float waitDays = 3f)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (hero == null || settlement == null)
		{
			return false;
		}
		PendingRequests[((MBObjectBase)hero).StringId] = new DestinationRequest(settlement, CampaignTime.Days(waitDays));
		return true;
	}

	public static bool PrepareDestination(Hero hero, string settlementIdentifier, out Settlement settlement, float waitDays = 3f)
	{
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		settlement = null;
		if (hero == null || string.IsNullOrWhiteSpace(settlementIdentifier))
		{
			return false;
		}
		settlementIdentifier = settlementIdentifier.Trim();
		settlement = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => string.Equals(((MBObjectBase)s).StringId, settlementIdentifier, StringComparison.OrdinalIgnoreCase)));
		if (settlement == null)
		{
			settlement = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => s.Name != (TextObject)null && string.Equals(((object)s.Name).ToString(), settlementIdentifier, StringComparison.OrdinalIgnoreCase)));
		}
		if (settlement == null)
		{
			settlement = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => s.Name != (TextObject)null && ((object)s.Name).ToString().IndexOf(settlementIdentifier, StringComparison.OrdinalIgnoreCase) >= 0));
		}
		if (settlement == null)
		{
			return false;
		}
		PendingRequests[((MBObjectBase)hero).StringId] = new DestinationRequest(settlement, CampaignTime.Days(waitDays));
		return true;
	}

	public override void Initialize(Hero hero)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		base.Initialize(hero);
		_targetSettlement = null;
		_waitDuration = CampaignTime.Days(3f);
		_waitUntil = null;
		_hasArrived = false;
		_isWaitingPhase = false;
		_isTemporaryPartyCreated = false;
		_stopRequested = false;
		_handleReturnOnStop = false;
		_trackedParty = null;
		_destinationName = null;
		_lastPartyPosition = null;
		_waitingForSettlementExit = false;
		_pendingActionAfterExit = null;
		_stopAfterPendingAction = false;
		_lastMoveOrderTime = CampaignTime.Zero;
		_holdModeActive = false;
		_headingMessageShown = false;
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
		if (hero != null && PendingRequests.TryGetValue(((MBObjectBase)hero).StringId, out var value))
		{
			_targetSettlement = value.Settlement;
			_waitDuration = value.WaitDuration;
			Settlement targetSettlement = _targetSettlement;
			_destinationName = ((targetSettlement == null) ? null : ((object)targetSettlement.Name)?.ToString());
			PendingRequests.Remove(((MBObjectBase)hero).StringId);
		}
	}

	public override bool CanExecute()
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		if (base.TargetHero == null || base.TargetHero.IsDead || base.TargetHero.IsPrisoner)
		{
			return false;
		}
		if (_targetSettlement == null)
		{
			LogError("Target settlement is not set. Make sure to call PrepareDestination before starting the action.");
			TextObject val = new TextObject("{=AIAction_GoToNoTarget}{HERO_NAME} cannot travel - target settlement is not set.", (Dictionary<string, object>)null);
			Hero targetHero = base.TargetHero;
			val.SetTextVariable("HERO_NAME", ((targetHero == null) ? null : ((object)targetHero.Name)?.ToString()) ?? "Unknown");
			ShowErrorMessage(val);
			return false;
		}
		return true;
	}

	protected override void OnStart()
	{
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Unknown result type (might be due to invalid IL or missing references)
		Hero targetHero = base.TargetHero;
		LogAction("Starting go_to_settlement for " + (((targetHero == null) ? null : ((object)targetHero.Name)?.ToString()) ?? "null") + " -> " + (_destinationName ?? "unknown"));
		TaskManager instance = TaskManager.Instance;
		HeroTask heroTask = null;
		if (instance != null)
		{
			heroTask = instance.GetActiveTask(base.TargetHero);
			if (heroTask != null)
			{
				TaskStep currentStep = heroTask.GetCurrentStep();
				if (currentStep != null && currentStep.StepType == TaskStepType.GoToSettlement)
				{
					Settlement targetSettlement = currentStep.GetTargetSettlement();
					if (targetSettlement != null && targetSettlement != _targetSettlement)
					{
						_targetSettlement = targetSettlement;
						_destinationName = ((object)_targetSettlement.Name)?.ToString();
						LogAction("Updated target from task: " + _destinationName);
					}
					if (heroTask.CurrentStepIndex + 1 < heroTask.Steps.Count)
					{
						TaskStep taskStep = heroTask.Steps[heroTask.CurrentStepIndex + 1];
						if (taskStep.StepType == TaskStepType.WaitInSettlement)
						{
							_waitDuration = CampaignTime.Days(taskStep.WaitDays);
							LogAction($"Updated wait duration from task: {taskStep.WaitDays} days");
						}
					}
				}
			}
		}
		_trackedParty = EnsurePartyForTravel(out var createdTemporary);
		_isTemporaryPartyCreated = createdTemporary;
		if (_trackedParty == null)
		{
			LogError("Failed to create or find party for travel; stopping action.");
			TextObject val = new TextObject("{=AIAction_GoToNoParty}{HERO_NAME} cannot travel - failed to create a party.", (Dictionary<string, object>)null);
			Hero targetHero2 = base.TargetHero;
			val.SetTextVariable("HERO_NAME", ((targetHero2 == null) ? null : ((object)targetHero2.Name)?.ToString()) ?? "Unknown");
			ShowErrorMessage(val);
			Stop();
			return;
		}
		if (_trackedParty.CurrentSettlement != null && _trackedParty.CurrentSettlement != _targetSettlement)
		{
			LogAction($"Party currently in {_trackedParty.CurrentSettlement.Name}, forcing exit.");
			try
			{
				GameVersionCompatibility.ConditionalDisableAi(_trackedParty);
				LeaveSettlementAction.ApplyForParty(_trackedParty);
				_waitingForSettlementExit = true;
				LogAction("Waiting for party to exit settlement before sending move command");
			}
			catch (Exception ex)
			{
				LogError("Error leaving settlement: " + ex.Message);
				_waitingForSettlementExit = false;
			}
		}
		if (_isTemporaryPartyCreated && _trackedParty != null && !_waitingForSettlementExit)
		{
			_lastPartyPosition = _trackedParty.GetPosition2D();
			LogAction($"Newly created party detected at {_lastPartyPosition.Value}, waiting for party to start moving");
		}
		else if (!_waitingForSettlementExit)
		{
			SendPartyToTarget(_trackedParty);
		}
		if (HasReachedDestination())
		{
			StartWaiting();
		}
	}

	protected override void OnStop()
	{
		_stopRequested = true;
		if (_trackedParty != null && !_isTemporaryPartyCreated)
		{
			NonCombatantPartyProtector instance = NonCombatantPartyProtector.Instance;
			if (instance != null && instance.IsPartyProtected(_trackedParty))
			{
				instance.UnregisterPartyProtection(_trackedParty);
				LogAction($"Unregistered party {_trackedParty.Name} from non-combatant protection");
			}
		}
		if (!_skipTaskCancelOnStop)
		{
			try
			{
				TaskManager instance2 = TaskManager.Instance;
				if (instance2 != null)
				{
					instance2.CancelTask(base.TargetHero);
					Hero targetHero = base.TargetHero;
					LogAction($"Cancelled task for {((targetHero != null) ? targetHero.Name : null)} due to action stop");
				}
			}
			catch (Exception ex)
			{
				LogError("Error cancelling task: " + ex.Message);
			}
		}
		else
		{
			_skipTaskCancelOnStop = false;
		}
		if (_isTemporaryPartyCreated && _trackedParty != null)
		{
			try
			{
				Hero targetHero2 = base.TargetHero;
				MobileParty val = ((targetHero2 != null) ? targetHero2.PartyBelongedTo : null) ?? _trackedParty;
				if (val != null && val != MobileParty.MainParty)
				{
					if (val.CurrentSettlement != null && base.TargetHero != null && base.TargetHero.IsNotable)
					{
						base.TargetHero.StayingInSettlement = val.CurrentSettlement;
						EnterSettlementAction.ApplyForCharacterOnly(base.TargetHero, val.CurrentSettlement);
						LogAction($"Returned {base.TargetHero.Name} to settlement {val.CurrentSettlement.Name}");
					}
					Settlement val2 = DetermineReturnSettlement(val);
					if (val2 != null)
					{
						if (val.CurrentSettlement != null)
						{
							LeaveSettlementAction.ApplyForParty(val);
						}
						GameVersionCompatibility.SetMoveGoToSettlement(val, val2);
						GameVersionCompatibility.ConditionalDisableAi(val);
						AIActionManager.Instance.RegisterPartyForRemoval(base.TargetHero, val, val2);
						LogAction($"Registered temporary party for removal to {val2.Name}");
					}
					else
					{
						LogAction("Cannot determine return destination - destroying temporary party immediately");
						if (val.CurrentSettlement != null)
						{
							LeaveSettlementAction.ApplyForParty(val);
						}
						GameVersionCompatibility.RemoveShips(val);
						DestroyPartyAction.Apply((PartyBase)null, val);
					}
				}
				return;
			}
			catch (Exception ex2)
			{
				LogError("Error handling temporary party cleanup on stop: " + ex2.Message);
				return;
			}
		}
		if (_handleReturnOnStop)
		{
			HandleReturnAfterWait();
		}
	}

	protected override void OnUpdate(float deltaTime)
	{
		//IL_06f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0703: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a13: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected O, but got Unknown
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0481: Unknown result type (might be due to invalid IL or missing references)
		if (_stopRequested || base.TargetHero == null)
		{
			return;
		}
		if (base.TargetHero.IsDead || base.TargetHero.IsPrisoner)
		{
			LogAction("Hero became dead or prisoner during travel; stopping action.");
			Stop();
			return;
		}
		if (!_isTemporaryPartyCreated && _trackedParty != null && _trackedParty.LeaderHero != null && _trackedParty.LeaderHero != base.TargetHero)
		{
			Hero targetHero = base.TargetHero;
			TextObject arg = ((targetHero != null) ? targetHero.Name : null);
			Hero leaderHero = _trackedParty.LeaderHero;
			LogError($"Party leader was replaced! Original: {arg}, New: {((leaderHero != null) ? leaderHero.Name : null)}. Stopping action.");
			TextObject val = new TextObject("{=AIAction_GoToLeaderReplaced}{HERO_NAME} was removed from party leadership. Action stopped.", (Dictionary<string, object>)null);
			Hero targetHero2 = base.TargetHero;
			val.SetTextVariable("HERO_NAME", ((targetHero2 == null) ? null : ((object)targetHero2.Name)?.ToString()) ?? "Unknown");
			InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), Color.FromUint(4294936576u)));
			Stop();
			return;
		}
		if (_waitingForSettlementExit && _trackedParty != null)
		{
			if (_trackedParty.CurrentSettlement != null)
			{
				return;
			}
			LogAction("Party exited settlement");
			_waitingForSettlementExit = false;
			if (_pendingActionAfterExit == TaskStepType.ReturnToPlayer)
			{
				_isWaitingPhase = false;
				_waitUntil = null;
				if (AIActionManager.Instance.StartAction(base.TargetHero, "return_to_player"))
				{
					LogAction("Started return_to_player action after settlement exit");
					_pendingActionAfterExit = null;
					CompletePendingActionTransition();
					return;
				}
				LogError("Failed to start return_to_player after settlement exit");
				_pendingActionAfterExit = null;
				_stopAfterPendingAction = false;
			}
			else if (_pendingActionAfterExit == TaskStepType.FollowPlayer)
			{
				_isWaitingPhase = false;
				_waitUntil = null;
				if (AIActionManager.Instance.StartAction(base.TargetHero, "follow_player"))
				{
					LogAction("Started follow_player action after settlement exit");
					_pendingActionAfterExit = null;
					CompletePendingActionTransition();
					return;
				}
				LogError("Failed to start follow_player after settlement exit");
				_pendingActionAfterExit = null;
				_stopAfterPendingAction = false;
			}
			if (_targetSettlement == null)
			{
				LogError("Target settlement is null after settlement exit - cannot send party to target");
				_pendingActionAfterExit = null;
				return;
			}
			if (_isTemporaryPartyCreated)
			{
				_lastPartyPosition = _trackedParty.GetPosition2D();
				LogAction($"Newly created party detected at {_lastPartyPosition.Value}, waiting for party to start moving");
			}
			else
			{
				Settlement partyTargetSettlement = GameVersionCompatibility.GetPartyTargetSettlement(_trackedParty);
				if (partyTargetSettlement != _targetSettlement)
				{
					SendPartyToTarget(_trackedParty);
				}
				else
				{
					LogAction($"Party already has correct target ({_targetSettlement.Name}), skipping duplicate command");
				}
			}
			_pendingActionAfterExit = null;
		}
		if (_isTemporaryPartyCreated && _trackedParty != null && _lastPartyPosition.HasValue)
		{
			Vec2 position2D = _trackedParty.GetPosition2D();
			Settlement partyTargetSettlement2 = GameVersionCompatibility.GetPartyTargetSettlement(_trackedParty);
			bool flag = false;
			if (((Vec2)(ref position2D)).DistanceSquared(_lastPartyPosition.Value) > 0.01f)
			{
				flag = true;
				LogAction($"Newly created party started moving (position changed from {_lastPartyPosition.Value} to {position2D})");
			}
			else if (partyTargetSettlement2 != null)
			{
				flag = true;
				LogAction($"Newly created party has a target ({partyTargetSettlement2.Name}), intercepting with our target");
			}
			if (!flag)
			{
				_lastPartyPosition = position2D;
				return;
			}
			LogAction("Intercepting party movement, sending command to " + (_destinationName ?? "target settlement"));
			SendPartyToTarget(_trackedParty);
			_lastPartyPosition = null;
		}
		if (!_hasArrived)
		{
			if (HasReachedDestination())
			{
				TaskManager instance = TaskManager.Instance;
				TaskStep taskStep = null;
				if (instance != null)
				{
					HeroTask activeTask = instance.GetActiveTask(base.TargetHero);
					if (activeTask != null)
					{
						taskStep = activeTask.GetCurrentStep();
					}
				}
				StartWaiting();
				try
				{
					if (instance != null && taskStep != null && taskStep.StepType == TaskStepType.GoToSettlement)
					{
						instance.MoveToNextStep(base.TargetHero);
						LogAction("Moved to next step in task (waiting phase)");
					}
					return;
				}
				catch (Exception ex)
				{
					LogError("Error updating task step: " + ex.Message);
					return;
				}
			}
			if (_isTemporaryPartyCreated && _moveCommandRetryCount < 3)
			{
				MobileParty val2 = base.TargetHero.PartyBelongedTo ?? _trackedParty;
				if (val2 != null && val2.CurrentSettlement == null)
				{
					Settlement partyTargetSettlement3 = GameVersionCompatibility.GetPartyTargetSettlement(val2);
					if (partyTargetSettlement3 != _targetSettlement)
					{
						LogAction($"Newly created party target not set correctly (attempt {_moveCommandRetryCount + 1}/{3}), retrying...");
						SendPartyToTarget(val2);
						_moveCommandRetryCount++;
					}
					else
					{
						EnsurePartyKeepsHeadingToTarget();
					}
				}
			}
			else
			{
				EnsurePartyKeepsHeadingToTarget();
			}
		}
		else
		{
			if (!_isWaitingPhase || !_waitUntil.HasValue)
			{
				return;
			}
			MobileParty val3 = base.TargetHero.PartyBelongedTo ?? _trackedParty;
			if (val3 != null && val3.CurrentSettlement != _targetSettlement)
			{
				try
				{
					LogAction($"Party exited settlement {_targetSettlement.Name} during wait - forcing re-entry");
					GameVersionCompatibility.ConditionalDisableAi(val3);
					EnterSettlementAction.ApplyForParty(val3, _targetSettlement);
					HoldPartyInSettlement();
				}
				catch (Exception ex2)
				{
					LogError("Error forcing party re-entry into settlement: " + ex2.Message);
				}
			}
			else if (val3 != null && val3.CurrentSettlement == _targetSettlement)
			{
				HoldPartyInSettlement();
			}
			if (!(CampaignTime.Now >= _waitUntil.Value))
			{
				return;
			}
			LogAction(string.Format("Waiting period finished for {0} in {1} (waited {2:F1} days)", base.TargetHero.Name, _destinationName ?? "unknown", ((CampaignTime)(ref _waitDuration)).ToDays));
			bool flag2 = false;
			try
			{
				TaskManager instance2 = TaskManager.Instance;
				if (instance2 != null)
				{
					HeroTask activeTask2 = instance2.GetActiveTask(base.TargetHero);
					if (activeTask2 != null)
					{
						TaskStep currentStep = activeTask2.GetCurrentStep();
						if (currentStep != null && currentStep.StepType == TaskStepType.WaitInSettlement)
						{
							int num = activeTask2.CurrentStepIndex + 1;
							if (num < activeTask2.Steps.Count)
							{
								if (instance2.MoveToNextStep(base.TargetHero))
								{
									TaskStep currentStep2 = activeTask2.GetCurrentStep();
									if (currentStep2 != null)
									{
										LogAction($"Moved to next step in task: {currentStep2.StepType}");
										flag2 = true;
										ExecuteNextTaskStep(currentStep2, activeTask2);
										if (currentStep2.StepType == TaskStepType.ReturnToPlayer)
										{
											_handleReturnOnStop = false;
											_skipTaskCancelOnStop = true;
											_stopAfterPendingAction = true;
											return;
										}
									}
								}
								else
								{
									LogAction("Task unexpectedly completed during step transition");
									flag2 = false;
								}
							}
							else
							{
								if (activeTask2.Steps.Count > 0)
								{
									TaskStep taskStep2 = activeTask2.Steps[activeTask2.Steps.Count - 1];
									if (taskStep2.StepType == TaskStepType.ReturnToPlayer)
									{
										LogAction("Task completed, executing final ReturnToPlayer step");
										_handleReturnOnStop = false;
										_skipTaskCancelOnStop = true;
										_stopAfterPendingAction = true;
										ExecuteNextTaskStep(taskStep2, activeTask2);
										flag2 = true;
										return;
									}
								}
								instance2.MoveToNextStep(base.TargetHero);
								LogAction($"Task completed for {base.TargetHero.Name}");
								flag2 = false;
							}
						}
					}
				}
			}
			catch (Exception ex3)
			{
				LogError("Error updating task step: " + ex3.Message);
			}
			if (!flag2)
			{
				TaskManager instance3 = TaskManager.Instance;
				if (instance3 != null)
				{
					HeroTask activeTask3 = instance3.GetActiveTask(base.TargetHero);
					if (activeTask3 != null && activeTask3.Steps.Count > 0)
					{
						TaskStep taskStep3 = activeTask3.Steps[activeTask3.Steps.Count - 1];
						if (taskStep3.StepType == TaskStepType.ReturnToPlayer)
						{
							LogAction("Task completed, executing final ReturnToPlayer step");
							ExecuteNextTaskStep(taskStep3, activeTask3);
							return;
						}
					}
				}
				_handleReturnOnStop = true;
				Stop();
			}
			else
			{
				_hasArrived = false;
				_isWaitingPhase = false;
				_waitUntil = null;
				_waitDuration = CampaignTime.Days(3f);
				_lastPartyPosition = null;
				_moveCommandRetryCount = 0;
				MobileParty val4 = base.TargetHero.PartyBelongedTo ?? _trackedParty;
				if (val4 != null && val4.CurrentSettlement != null)
				{
					LeaveSettlementAction.ApplyForParty(val4);
					_waitingForSettlementExit = true;
					_holdModeActive = false;
					LogAction("Exiting settlement to continue task");
				}
			}
		}
	}

	private MobileParty EnsurePartyForTravel(out bool createdTemporary)
	{
		createdTemporary = false;
		if (base.TargetHero == null)
		{
			return null;
		}
		MobileParty val = base.TargetHero.PartyBelongedTo;
		MobileParty mainParty = MobileParty.MainParty;
		if (val != null && val != mainParty)
		{
			LogAction($"{base.TargetHero.Name} already has own party: {val.Name}");
			return val;
		}
		if (val == mainParty || val == null)
		{
			bool flag = val == null;
			if (val == mainParty)
			{
				LogAction($"{base.TargetHero.Name} is currently in the player's party. Creating separate party for travel.");
				flag = true;
			}
			if (flag)
			{
				val = CreateTemporaryParty(mainParty);
				if (val != null)
				{
					createdTemporary = true;
				}
			}
		}
		return val;
	}

	private MobileParty CreateTemporaryParty(MobileParty sourcePlayerParty = null)
	{
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_0367: Expected O, but got Unknown
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Expected O, but got Unknown
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Expected O, but got Unknown
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		if (base.TargetHero == null)
		{
			return null;
		}
		try
		{
			MobileParty val = null;
			if (base.TargetHero.Clan != null)
			{
				LogAction($"Attempting to create REAL clan party for {base.TargetHero.Name} (Clan: {base.TargetHero.Clan.Name})");
				MobileParty partyBelongedTo = base.TargetHero.PartyBelongedTo;
				LogAction(string.Format("Before creation: hero party = {0}, hero clan = {1}", ((partyBelongedTo == null) ? null : ((object)partyBelongedTo.Name)?.ToString()) ?? "null", base.TargetHero.Clan.Name));
				val = GameVersionCompatibility.CreateNewClanMobileParty(base.TargetHero, base.TargetHero.Clan);
				if (val == null)
				{
					LogError($"CreateNewClanMobileParty returned null for {base.TargetHero.Name}");
				}
				else
				{
					MobileParty partyBelongedTo2 = base.TargetHero.PartyBelongedTo;
					LogAction(string.Format("After creation: hero party = {0}, new party = {1}", ((partyBelongedTo2 == null) ? null : ((object)partyBelongedTo2.Name)?.ToString()) ?? "null", val.Name));
					val.IsVisible = true;
					val.IsActive = true;
					LogAction($"Real clan party for {base.TargetHero.Name} created at position {val.GetPosition2D()}");
					if (base.TargetHero.PartyBelongedTo == val && base.TargetHero.PartyBelongedTo != MobileParty.MainParty)
					{
						try
						{
							if (val.CurrentSettlement == null)
							{
								LogAction($"Party created on map at position {val.GetPosition2D()}, ready to move");
							}
							else
							{
								LogAction($"Party created in settlement {val.CurrentSettlement.Name}, will exit first");
							}
						}
						catch (Exception ex)
						{
							LogError("Error checking party state after creation: " + ex.Message);
						}
						NonCombatantPartyProtector instance = NonCombatantPartyProtector.Instance;
						if (instance != null)
						{
							instance.RegisterPartyForProtection(val, base.TargetHero, "GoToSettlement");
							LogAction($"Registered party {val.Name} for non-combatant protection");
						}
						return val;
					}
					MobileParty partyBelongedTo3 = base.TargetHero.PartyBelongedTo;
					LogError("Clan party creation did not assign hero to new party correctly. Hero party: " + (((partyBelongedTo3 == null) ? null : ((object)partyBelongedTo3.Name)?.ToString()) ?? "null"));
				}
			}
			if (base.TargetHero.IsNotable || (base.TargetHero.IsWanderer && base.TargetHero.Clan == null))
			{
				MobileParty mainParty = MobileParty.MainParty;
				if (mainParty == null)
				{
					LogError("Cannot create temporary party - MainParty is null");
					return null;
				}
				Settlement currentSettlement = Hero.MainHero.CurrentSettlement;
				Vec2 position;
				if (currentSettlement != null)
				{
					position = currentSettlement.GetGatePosition();
					LogAction($"Creating temporary party at {currentSettlement.Name} gates for {base.TargetHero.Name}");
				}
				else
				{
					position = mainParty.GetPosition2D();
					LogAction($"Creating temporary party near player for {base.TargetHero.Name}");
				}
				TextObject val2 = new TextObject("{=AIAction_TemporaryPartyName}{HERO_NAME}'s Party (Temporary)", (Dictionary<string, object>)null);
				val2.SetTextVariable("HERO_NAME", base.TargetHero.Name);
				TroopRoster memberRoster = new TroopRoster((PartyBase)null);
				TroopRoster prisonerRoster = new TroopRoster((PartyBase)null);
				val = GameVersionCompatibility.CreateQuestParty(position, 0.1f, currentSettlement ?? _originSettlement, val2, Clan.PlayerClan, memberRoster, prisonerRoster, base.TargetHero);
				if (val == null)
				{
					LogError($"Failed to create temporary quest party for {base.TargetHero.Name}");
					return null;
				}
				LogAction($"Created temporary party for {base.TargetHero.Name}");
				val.IsVisible = true;
				val.IsActive = true;
				if (base.TargetHero.PartyBelongedTo != val)
				{
					LogAction(string.Format("Moving {0} from {1} to temporary party", base.TargetHero.Name, (base.TargetHero.PartyBelongedTo != null) ? ((object)base.TargetHero.PartyBelongedTo.Name).ToString() : "null"));
					AddHeroToPartyAction.Apply(base.TargetHero, val, true);
					if (MobileParty.MainParty != null && MobileParty.MainParty.MemberRoster.Contains(base.TargetHero.CharacterObject))
					{
						LogAction($"DUPLICATION FIX: Removing {base.TargetHero.Name} from MainParty roster manually");
						int troopCount = MobileParty.MainParty.MemberRoster.GetTroopCount(base.TargetHero.CharacterObject);
						if (troopCount > 0)
						{
							MobileParty.MainParty.MemberRoster.AddToCounts(base.TargetHero.CharacterObject, -troopCount, false, 0, 0, true, -1);
						}
					}
					int troopCount2 = val.MemberRoster.GetTroopCount(base.TargetHero.CharacterObject);
					if (troopCount2 > 1)
					{
						LogAction("Fixing hero duplication in temporary party roster");
						val.MemberRoster.AddToCounts(base.TargetHero.CharacterObject, -(troopCount2 - 1), false, 0, 0, true, -1);
					}
					else if (troopCount2 == 0)
					{
						LogAction("Fixing missing hero in temporary party roster");
						val.MemberRoster.AddToCounts(base.TargetHero.CharacterObject, 1, false, 0, 0, true, -1);
					}
				}
				return val;
			}
			LogError($"Cannot create party for {base.TargetHero.Name} - hero is not a clan member, notable, or wanderer");
			return null;
		}
		catch (Exception ex2)
		{
			LogError("Error creating party: " + ex2.Message + "\n" + ex2.StackTrace);
			return null;
		}
	}

	private void SendPartyToTarget(MobileParty party)
	{
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d2: Expected O, but got Unknown
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0312: Unknown result type (might be due to invalid IL or missing references)
		//IL_031c: Expected O, but got Unknown
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		if (party == null || _targetSettlement == null)
		{
			return;
		}
		try
		{
			if (party.CurrentSettlement != null && party.CurrentSettlement != _targetSettlement)
			{
				LogAction($"Party is in settlement {party.CurrentSettlement.Name}, cannot move yet");
				return;
			}
			bool isVillage = _targetSettlement.IsVillage;
			GameVersionCompatibility.SetMoveGoToSettlement(party, _targetSettlement);
			if (!isVillage && party.Ai != null)
			{
				GameVersionCompatibility.ConditionalDisableAi(party);
				LogAction($"Disabled AI for party {party.Name} after setting target to {_targetSettlement.Name}");
			}
			Settlement partyTargetSettlement = GameVersionCompatibility.GetPartyTargetSettlement(party);
			if (partyTargetSettlement != _targetSettlement)
			{
				Settlement targetSettlement = _targetSettlement;
				string text = ((targetSettlement == null) ? null : ((object)targetSettlement.Name)?.ToString()) ?? "null";
				string text2 = ((partyTargetSettlement == null) ? null : ((object)partyTargetSettlement.Name)?.ToString()) ?? "null";
				LogError("Failed to set party target: expected " + text + ", got " + text2);
				GameVersionCompatibility.SetMoveGoToSettlement(party, _targetSettlement);
			}
			else
			{
				_moveCommandRetryCount = 0;
			}
			if (!isVillage && (_isTemporaryPartyCreated || base.TargetHero.IsNotable || base.TargetHero.Clan == Clan.PlayerClan))
			{
				GameVersionCompatibility.ConditionalDisableAi(party);
			}
			else
			{
				GameVersionCompatibility.ConditionalEnableAi(party);
			}
			if (!_headingMessageShown)
			{
				TextObject val = new TextObject("{=AIAction_GoToHeading}{HERO_NAME} is heading to {SETTLEMENT_NAME}.", (Dictionary<string, object>)null);
				Hero targetHero = base.TargetHero;
				val.SetTextVariable("HERO_NAME", ((targetHero == null) ? null : ((object)targetHero.Name)?.ToString()) ?? "Unknown");
				Settlement targetSettlement2 = _targetSettlement;
				val.SetTextVariable("SETTLEMENT_NAME", ((targetSettlement2 == null) ? null : ((object)targetSettlement2.Name)?.ToString()) ?? "Unknown");
				DelayedTaskManager delayedTaskManager = AIInfluenceBehavior.Instance?.GetDelayedTaskManager();
				if (delayedTaskManager != null)
				{
					string text3 = ((object)val).ToString();
					delayedTaskManager.AddTask(1.0, delegate
					{
						//IL_0007: Unknown result type (might be due to invalid IL or missing references)
						//IL_000c: Unknown result type (might be due to invalid IL or missing references)
						//IL_0016: Expected O, but got Unknown
						InformationManager.DisplayMessage(new InformationMessage(text3, ExtraColors.GreenAIInfluence));
					});
				}
				else
				{
					InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), ExtraColors.GreenAIInfluence));
				}
				_headingMessageShown = true;
			}
			LogAction($"Party heading to {_targetSettlement.Name}");
			_lastMoveOrderTime = CampaignTime.Now;
		}
		catch (Exception ex)
		{
			TextObject val2 = new TextObject("{=AIAction_GoToFailed}Failed to send {HERO_NAME} to settlement", (Dictionary<string, object>)null);
			Hero targetHero2 = base.TargetHero;
			val2.SetTextVariable("HERO_NAME", ((targetHero2 == null) ? null : ((object)targetHero2.Name)?.ToString()) ?? "Unknown");
			InformationManager.DisplayMessage(new InformationMessage(((object)val2).ToString(), ExtraColors.RedAIInfluence));
			LogError("Failed to send party to target settlement: " + ex.Message);
		}
	}

	private bool HasReachedDestination()
	{
		if (_targetSettlement == null || base.TargetHero == null)
		{
			return false;
		}
		if (base.TargetHero.PartyBelongedTo != null && base.TargetHero.PartyBelongedTo.CurrentSettlement == _targetSettlement)
		{
			return true;
		}
		if (base.TargetHero.CurrentSettlement == _targetSettlement || base.TargetHero.StayingInSettlement == _targetSettlement)
		{
			return true;
		}
		if (_targetSettlement.IsVillage && base.TargetHero.PartyBelongedTo != null)
		{
			MobileParty partyBelongedTo = base.TargetHero.PartyBelongedTo;
			if (partyBelongedTo.CurrentSettlement == null)
			{
				float distance = GameVersionCompatibility.GetDistance(partyBelongedTo, _targetSettlement);
				if (distance <= 0.2f)
				{
					return true;
				}
			}
		}
		return false;
	}

	private void StartWaiting()
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		if (_hasArrived || _targetSettlement == null)
		{
			return;
		}
		_hasArrived = true;
		_isWaitingPhase = true;
		_waitUntil = CampaignTime.Now + _waitDuration;
		LogAction(string.Format("Hero {0} arrived at {1}; waiting for {2:F1} days", base.TargetHero.Name, _destinationName ?? "unknown", ((CampaignTime)(ref _waitDuration)).ToDays));
		try
		{
			TaskManager instance = TaskManager.Instance;
			if (instance != null)
			{
				HeroTask activeTask = instance.GetActiveTask(base.TargetHero);
				if (activeTask != null)
				{
					TaskStep currentStep = activeTask.GetCurrentStep();
					if (currentStep != null && currentStep.StepType == TaskStepType.WaitInSettlement)
					{
						currentStep.StartWaiting();
						LogAction($"Started waiting step in task: will wait until {currentStep.WaitUntilTime}");
					}
				}
			}
		}
		catch (Exception ex)
		{
			LogError("Error updating wait step: " + ex.Message);
		}
		MobileParty val = base.TargetHero.PartyBelongedTo ?? _trackedParty;
		if (val != null && val.CurrentSettlement != _targetSettlement)
		{
			try
			{
				GameVersionCompatibility.ConditionalDisableAi(val);
				EnterSettlementAction.ApplyForParty(val, _targetSettlement);
				LogAction($"Forced party entry into {_targetSettlement.Name}");
			}
			catch (Exception ex2)
			{
				LogError("Error forcing party entry into settlement: " + ex2.Message);
			}
		}
		EnsureHeroInsideTargetSettlement();
		HoldPartyInSettlement();
	}

	private void ExecuteNextTaskStep(TaskStep nextStep, HeroTask task)
	{
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		if (nextStep == null)
		{
			return;
		}
		try
		{
			switch (nextStep.StepType)
			{
			case TaskStepType.GoToSettlement:
			{
				Settlement targetSettlement2 = nextStep.GetTargetSettlement();
				if (targetSettlement2 == null)
				{
					break;
				}
				_targetSettlement = targetSettlement2;
				_destinationName = ((object)targetSettlement2.Name)?.ToString();
				_hasArrived = false;
				_isWaitingPhase = false;
				_waitUntil = null;
				int currentStepIndex = task.CurrentStepIndex;
				if (currentStepIndex + 1 < task.Steps.Count)
				{
					TaskStep taskStep = task.Steps[currentStepIndex + 1];
					if (taskStep.StepType == TaskStepType.WaitInSettlement)
					{
						_waitDuration = CampaignTime.Days(taskStep.WaitDays);
					}
				}
				PrepareDestination(base.TargetHero, targetSettlement2);
				_trackedParty = base.TargetHero.PartyBelongedTo;
				if (_trackedParty == null)
				{
					_trackedParty = EnsurePartyForTravel(out var createdTemporary);
					_isTemporaryPartyCreated = createdTemporary;
				}
				if (_trackedParty != null)
				{
					if (_trackedParty.CurrentSettlement != null && _trackedParty.CurrentSettlement != targetSettlement2)
					{
						LeaveSettlementAction.ApplyForParty(_trackedParty);
						_waitingForSettlementExit = true;
						LogAction($"Exiting settlement to continue to next settlement: {targetSettlement2.Name}");
					}
					else
					{
						SendPartyToTarget(_trackedParty);
						LogAction($"Updated action to continue to next settlement: {targetSettlement2.Name}");
					}
				}
				break;
			}
			case TaskStepType.ReturnToPlayer:
			{
				MobileParty val = base.TargetHero.PartyBelongedTo ?? _trackedParty;
				_isWaitingPhase = false;
				_waitUntil = null;
				if (val != null && val.CurrentSettlement != null)
				{
					LeaveSettlementAction.ApplyForParty(val);
					LogAction("Exiting settlement before returning to player (player not in settlement)");
					_waitingForSettlementExit = true;
					_pendingActionAfterExit = TaskStepType.ReturnToPlayer;
					_handleReturnOnStop = false;
					_stopAfterPendingAction = true;
				}
				else if (AIActionManager.Instance.StartAction(base.TargetHero, "return_to_player"))
				{
					LogAction("Started next step: return to player (party already outside settlement)");
					_pendingActionAfterExit = null;
					_stopAfterPendingAction = true;
					CompletePendingActionTransition();
				}
				else
				{
					LogError("Failed to start return_to_player when party already outside settlement");
					_stopAfterPendingAction = false;
				}
				break;
			}
			case TaskStepType.FollowPlayer:
			{
				MobileParty val2 = base.TargetHero.PartyBelongedTo ?? _trackedParty;
				_isWaitingPhase = false;
				_waitUntil = null;
				if (val2 != null && val2.CurrentSettlement != null)
				{
					LeaveSettlementAction.ApplyForParty(val2);
					LogAction("Exiting settlement before following player (player not in settlement)");
					_waitingForSettlementExit = true;
				}
				else if (AIActionManager.Instance.StartAction(base.TargetHero, "follow_player"))
				{
					LogAction("Started next step: follow player (party already outside settlement)");
					_pendingActionAfterExit = null;
					CompletePendingActionTransition();
				}
				else
				{
					LogError("Failed to start follow_player when party already outside settlement");
					_stopAfterPendingAction = false;
				}
				break;
			}
			case TaskStepType.AttackParty:
				if (!string.IsNullOrEmpty(nextStep.TargetPartyId))
				{
					AttackPartyAction.PrepareAttackTarget(base.TargetHero, nextStep.TargetPartyId);
				}
				else
				{
					LogError("Attack step does not have target party id");
				}
				if (!AIActionManager.Instance.StartAction(base.TargetHero, "attack_party"))
				{
					LogError("Failed to start attack_party action for next step");
				}
				break;
			case TaskStepType.PatrolSettlement:
			{
				Settlement targetSettlement3 = nextStep.GetTargetSettlement();
				if (targetSettlement3 != null)
				{
					float durationDays = ((nextStep.PatrolDurationDays > 0f) ? nextStep.PatrolDurationDays : 7f);
					PatrolSettlementAction.PreparePatrolRequest(base.TargetHero, ((MBObjectBase)targetSettlement3).StringId, durationDays, nextStep.PatrolAutoReturn);
					if (!AIActionManager.Instance.StartAction(base.TargetHero, "patrol_settlement"))
					{
						LogError("Failed to start patrol_settlement action for next step");
					}
				}
				else
				{
					LogError("Patrol step does not have target settlement");
				}
				break;
			}
			case TaskStepType.SiegeSettlement:
			{
				Settlement targetSettlement5 = nextStep.GetTargetSettlement();
				if (targetSettlement5 != null)
				{
					SiegeSettlementAction.PrepareSiegeTarget(base.TargetHero, ((MBObjectBase)targetSettlement5).StringId, autoReturn: false);
					if (!AIActionManager.Instance.StartAction(base.TargetHero, "siege_settlement"))
					{
						LogError("Failed to start siege_settlement action for next step");
					}
				}
				else
				{
					LogError("Siege step does not have target settlement");
				}
				break;
			}
			case TaskStepType.WaitInSettlement:
				LogAction("Next step is wait - already in progress");
				break;
			case TaskStepType.WaitNearSettlement:
			{
				Settlement targetSettlement4 = nextStep.GetTargetSettlement();
				if (targetSettlement4 != null)
				{
					float waitDays = ((nextStep.WaitNearDurationDays > 0f) ? nextStep.WaitNearDurationDays : 2f);
					float desiredRadius = ((nextStep.WaitNearRadius > 0f) ? nextStep.WaitNearRadius : 10f);
					WaitNearSettlementAction.PrepareWaitRequest(base.TargetHero, targetSettlement4, waitDays, desiredRadius);
					if (!AIActionManager.Instance.StartAction(base.TargetHero, "wait_near_settlement"))
					{
						LogError("Failed to start wait_near_settlement action for next step");
					}
				}
				else
				{
					LogError("WaitNear step does not have target settlement");
				}
				break;
			}
			case TaskStepType.RaidVillage:
			{
				Settlement targetSettlement = nextStep.GetTargetSettlement();
				if (targetSettlement != null && targetSettlement.IsVillage)
				{
					RaidVillageAction.PrepareRaidTarget(base.TargetHero, ((MBObjectBase)targetSettlement).StringId);
					if (!AIActionManager.Instance.StartAction(base.TargetHero, "raid_village"))
					{
						LogError("Failed to start raid_village action for next step");
					}
				}
				else
				{
					LogError("RaidVillage step does not have valid village settlement");
				}
				break;
			}
			default:
				LogAction($"Unknown step type: {nextStep.StepType}");
				break;
			}
		}
		catch (Exception ex)
		{
			LogError("Error executing next task step: " + ex.Message);
		}
	}

	private void CompletePendingActionTransition()
	{
		if (_stopAfterPendingAction)
		{
			if (_stopRequested)
			{
				_stopAfterPendingAction = false;
				return;
			}
			_stopAfterPendingAction = false;
			_handleReturnOnStop = false;
			_skipTaskCancelOnStop = true;
			Stop();
		}
	}

	private void EnsureHeroInsideTargetSettlement()
	{
		if (_targetSettlement == null || base.TargetHero == null)
		{
			return;
		}
		try
		{
			if (base.TargetHero.CurrentSettlement != _targetSettlement)
			{
				base.TargetHero.StayingInSettlement = _targetSettlement;
				EnterSettlementAction.ApplyForCharacterOnly(base.TargetHero, _targetSettlement);
			}
		}
		catch (Exception ex)
		{
			LogError("Error placing hero in settlement: " + ex.Message);
		}
	}

	private void HoldPartyInSettlement()
	{
		MobileParty partyBelongedTo = base.TargetHero.PartyBelongedTo;
		if (partyBelongedTo == null || partyBelongedTo.CurrentSettlement != _targetSettlement)
		{
			_holdModeActive = false;
			return;
		}
		try
		{
			if (!_holdModeActive)
			{
				GameVersionCompatibility.SetMoveModeHold(partyBelongedTo);
				GameVersionCompatibility.ConditionalDisableAi(partyBelongedTo);
				LogAction($"Set hold mode for party in {_targetSettlement.Name} (AI disabled)");
				_holdModeActive = true;
			}
		}
		catch (Exception ex)
		{
			LogError("Error setting hold mode for party: " + ex.Message);
			_holdModeActive = false;
		}
	}

	private void EnsurePartyKeepsHeadingToTarget()
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		MobileParty val = base.TargetHero.PartyBelongedTo ?? _trackedParty;
		if (val == null || _targetSettlement == null || val.CurrentSettlement == _targetSettlement)
		{
			return;
		}
		try
		{
			Settlement val2 = GameVersionCompatibility.GetPartyTargetSettlement(val);
			if (val2 == null)
			{
				val2 = val.TargetSettlement ?? val.ShortTermTargetSettlement;
			}
			if (val2 != _targetSettlement && CampaignTime.Now - _lastMoveOrderTime >= CampaignTime.Hours(0.05f))
			{
				LogAction("Party target changed to " + (((val2 == null) ? null : ((object)val2.Name)?.ToString()) ?? "null") + "; re-issuing order to " + (_destinationName ?? "unknown"));
				SendPartyToTarget(val);
			}
			if (val.Ai != null && val.Ai.DoNotMakeNewDecisions && val2 == null && val.CurrentSettlement == null && CampaignTime.Now - _lastMoveOrderTime >= CampaignTime.Hours(0.05f))
			{
				LogAction("Party seems stuck, re-issuing move command to " + (_destinationName ?? "unknown"));
				SendPartyToTarget(val);
			}
		}
		catch (Exception ex)
		{
			LogError("Error checking party target: " + ex.Message);
		}
	}

	private void HandleReturnAfterWait()
	{
		if (base.TargetHero == null)
		{
			return;
		}
		MobileParty val = base.TargetHero.PartyBelongedTo ?? _trackedParty;
		if (val == null)
		{
			LogAction("No party available after waiting; leaving hero in settlement.");
			return;
		}
		try
		{
			if (_isTemporaryPartyCreated)
			{
				Settlement val2 = DetermineReturnSettlement(val);
				if (val2 != null)
				{
					GameVersionCompatibility.SetMoveGoToSettlement(val, val2);
					GameVersionCompatibility.ConditionalDisableAi(val);
					AIActionManager.Instance.RegisterPartyForRemoval(base.TargetHero, val, val2);
					LogAction($"Temporary party sent to {val2.Name} for cleanup.");
				}
				else if (val == MobileParty.MainParty)
				{
					LogError("CRITICAL: Attempted to destroy MainParty in GoToSettlementAction! This would corrupt the game. Skipping destruction.");
				}
				else
				{
					LogError("Could not determine return destination for temporary party; destroying party.");
					GameVersionCompatibility.RemoveShips(val);
					DestroyPartyAction.Apply((PartyBase)null, val);
				}
			}
			else if (base.TargetHero.IsNotable || (base.TargetHero.IsWanderer && base.TargetHero.Clan == null))
			{
				Settlement val3 = DetermineReturnSettlement(val);
				if (val3 != null)
				{
					GameVersionCompatibility.SetMoveGoToSettlement(val, val3);
					GameVersionCompatibility.ConditionalDisableAi(val);
					AIActionManager.Instance.RegisterPartyForRemoval(base.TargetHero, val, val3);
					LogAction($"Registered party to return to {val3.Name}");
				}
				else
				{
					LogError("No destination determined for notable/companion return.");
				}
			}
			else
			{
				if (val.CurrentSettlement != null)
				{
					string arg = ((object)val.CurrentSettlement.Name)?.ToString() ?? "unknown";
					LeaveSettlementAction.ApplyForParty(val);
					LogAction($"Party {val.Name} left settlement {arg}");
				}
				GameVersionCompatibility.ConditionalEnableAi(val);
				LogAction($"AI re-enabled for {base.TargetHero.Name}'s party - party will behave as normal on the map");
			}
		}
		catch (Exception ex)
		{
			LogError("Error during return handling: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	private Settlement DetermineReturnSettlement(MobileParty party)
	{
		Settlement val = null;
		if (base.TargetHero.IsNotable)
		{
			object obj = base.TargetHero.HomeSettlement;
			if (obj == null)
			{
				obj = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => s.Notables != null && ((List<Hero>)(object)s.Notables).Contains(base.TargetHero)));
				if (obj == null)
				{
					obj = base.TargetHero.StayingInSettlement;
					if (obj == null)
					{
						obj = base.TargetHero.CurrentSettlement;
						if (obj == null)
						{
							MobileParty partyBelongedTo = base.TargetHero.PartyBelongedTo;
							obj = ((partyBelongedTo != null) ? partyBelongedTo.CurrentSettlement : null);
						}
					}
				}
			}
			val = (Settlement)obj;
			if (val != null)
			{
				return val;
			}
		}
		if (base.TargetHero.IsWanderer && base.TargetHero.Clan == null)
		{
			if (party != null)
			{
				val = ((IEnumerable<Settlement>)Settlement.All).Where((Settlement s) => s.IsTown && s.Town != null).OrderBy(delegate(Settlement s)
				{
					//IL_0001: Unknown result type (might be due to invalid IL or missing references)
					//IL_0006: Unknown result type (might be due to invalid IL or missing references)
					//IL_000f: Unknown result type (might be due to invalid IL or missing references)
					Vec2 position2D = s.GetPosition2D();
					return ((Vec2)(ref position2D)).DistanceSquared(party.GetPosition2D());
				}).FirstOrDefault();
				if (val != null)
				{
					return val;
				}
			}
			return null;
		}
		val = _originSettlement;
		if (val == null && base.TargetHero.Clan != null)
		{
			val = base.TargetHero.Clan.HomeSettlement;
		}
		if (val == null)
		{
			val = base.TargetHero.BornSettlement;
		}
		if (val == null && party != null)
		{
			val = ((IEnumerable<Settlement>)Settlement.All).Where((Settlement s) => s.IsTown && s.Town != null).OrderBy(delegate(Settlement s)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_000f: Unknown result type (might be due to invalid IL or missing references)
				Vec2 position2D = s.GetPosition2D();
				return ((Vec2)(ref position2D)).DistanceSquared(party.GetPosition2D());
			}).FirstOrDefault();
		}
		if (val == null && party != null)
		{
			val = ((IEnumerable<Settlement>)Settlement.All).Where((Settlement s) => s.IsCastle || s.IsVillage).OrderBy(delegate(Settlement s)
			{
				//IL_0001: Unknown result type (might be due to invalid IL or missing references)
				//IL_0006: Unknown result type (might be due to invalid IL or missing references)
				//IL_000f: Unknown result type (might be due to invalid IL or missing references)
				Vec2 position2D = s.GetPosition2D();
				return ((Vec2)(ref position2D)).DistanceSquared(party.GetPosition2D());
			}).FirstOrDefault();
		}
		return val;
	}

	public override Dictionary<string, string> GetStateDataForSave()
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		if (_targetSettlement == null)
		{
			return null;
		}
		Dictionary<string, string> dictionary = new Dictionary<string, string> { ["settlementId"] = ((MBObjectBase)_targetSettlement).StringId };
		float num;
		if (_waitUntil.HasValue && _isWaitingPhase)
		{
			CampaignTime val = _waitUntil.Value;
			double toHours = ((CampaignTime)(ref val)).ToHours;
			val = CampaignTime.Now;
			num = MathF.Max(0.1f, (float)(toHours - ((CampaignTime)(ref val)).ToHours));
		}
		else
		{
			num = (float)((CampaignTime)(ref _waitDuration)).ToHours;
		}
		float num2 = ((CampaignTime.HoursInDay > 0) ? ((float)CampaignTime.HoursInDay) : 24f);
		dictionary["waitDays"] = ((num2 > 0f) ? (num / num2) : 3f).ToString(CultureInfo.InvariantCulture);
		dictionary["isWaiting"] = _isWaitingPhase.ToString();
		return dictionary;
	}
}
