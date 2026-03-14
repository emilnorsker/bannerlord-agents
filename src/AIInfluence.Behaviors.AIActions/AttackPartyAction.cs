using System;
using System.Collections.Generic;
using System.Linq;
using AIInfluence.Behaviors.AIActions.TaskSystem;
using AIInfluence.Diplomacy;
using AIInfluence.Util;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Behaviors.AIActions;

public sealed class AttackPartyAction : AIActionBase
{
	private static readonly Dictionary<string, string> _pendingTargets = new Dictionary<string, string>();

	private string _targetPartyId;

	private MobileParty _targetParty;

	private MobileParty _heroParty;

	private bool _battleStarted;

	private bool _attackCompleted;

	private CampaignTime _lastOrderTime = CampaignTime.Zero;

	private bool _warDeclared;

	public override string ActionName => "attack_party";

	public override string Description => "Hero engages a specific party in battle";

	public static bool PrepareAttackTarget(Hero hero, string targetPartyId)
	{
		if (hero == null || string.IsNullOrWhiteSpace(targetPartyId))
		{
			LogPendingTarget("PrepareAttackTarget failed: hero " + ((hero == null) ? "null" : ((object)hero.Name).ToString()) + ", target '" + targetPartyId + "'");
			return false;
		}
		string text = targetPartyId.Trim();
		_pendingTargets[((MBObjectBase)hero).StringId] = text;
		LogPendingTarget($"Pending target '{text}' stored for {hero.Name} ({((MBObjectBase)hero).StringId})");
		return true;
	}

	private string ConsumePendingTarget()
	{
		if (base.TargetHero != null && _pendingTargets.TryGetValue(((MBObjectBase)base.TargetHero).StringId, out var value))
		{
			_pendingTargets.Remove(((MBObjectBase)base.TargetHero).StringId);
			LogPendingTarget($"Consumed pending target '{value}' for {base.TargetHero.Name} ({((MBObjectBase)base.TargetHero).StringId})");
			return value;
		}
		Hero targetHero = base.TargetHero;
		TextObject arg = ((targetHero != null) ? targetHero.Name : null);
		Hero targetHero2 = base.TargetHero;
		LogPendingTarget($"No pending target found for {arg} ({((targetHero2 != null) ? ((MBObjectBase)targetHero2).StringId : null)})");
		return null;
	}

	public override void Initialize(Hero hero)
	{
		base.Initialize(hero);
		_targetPartyId = ConsumePendingTarget();
		_warDeclared = false;
	}

	public override bool CanExecute()
	{
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		if (base.TargetHero == null || base.TargetHero.IsDead || base.TargetHero.IsPrisoner)
		{
			Hero targetHero = base.TargetHero;
			object arg = ((targetHero != null) ? new bool?(targetHero.IsDead) : ((bool?)null));
			Hero targetHero2 = base.TargetHero;
			LogError($"CanExecute check failed: hero invalid (IsDead={arg}, IsPrisoner={((targetHero2 != null) ? new bool?(targetHero2.IsPrisoner) : ((bool?)null))})");
			RestorePendingTarget();
			return false;
		}
		if (!HeroHasIndependentParty(base.TargetHero, out var reason))
		{
			LogError("Hero must command an independent party before issuing attack orders. Use create_party first.");
			LogError("CanExecute check failed: " + reason);
			TextObject val = new TextObject("{=AIAction_AttackNoParty}{HERO_NAME} cannot attack - must command an independent party first.", (Dictionary<string, object>)null);
			val.SetTextVariable("HERO_NAME", base.TargetHero.Name);
			ShowErrorMessage(val);
			RestorePendingTarget();
			return false;
		}
		if (string.IsNullOrEmpty(_targetPartyId))
		{
			_targetPartyId = GetTargetFromTask();
		}
		if (string.IsNullOrEmpty(_targetPartyId))
		{
			LogError("CanExecute check failed: target party id is missing.");
			Hero targetHero3 = base.TargetHero;
			TextObject arg2 = ((targetHero3 != null) ? targetHero3.Name : null);
			Hero targetHero4 = base.TargetHero;
			string arg3 = ((targetHero4 != null) ? ((MBObjectBase)targetHero4).StringId : null);
			Dictionary<string, string> pendingTargets = _pendingTargets;
			Hero targetHero5 = base.TargetHero;
			LogPendingTarget($"Target id missing for {arg2} ({arg3}); pending cache has key: {pendingTargets.ContainsKey(((targetHero5 != null) ? ((MBObjectBase)targetHero5).StringId : null) ?? string.Empty)}");
			TextObject val2 = new TextObject("{=AIAction_AttackNoTarget}{HERO_NAME} cannot attack - target party not specified.", (Dictionary<string, object>)null);
			val2.SetTextVariable("HERO_NAME", base.TargetHero.Name);
			ShowErrorMessage(val2);
			return false;
		}
		return true;
	}

	protected override void OnStart()
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		if (!CanExecute())
		{
			RestorePendingTarget();
			Stop();
			return;
		}
		_heroParty = base.TargetHero.PartyBelongedTo;
		if (!HeroHasIndependentParty(base.TargetHero, out var reason))
		{
			LogError("Hero must not be in the player's party when starting attack_party. " + reason);
			TextObject val = new TextObject("{=AIAction_AttackInPlayerParty}{HERO_NAME} cannot attack - must leave your party first.", (Dictionary<string, object>)null);
			val.SetTextVariable("HERO_NAME", base.TargetHero.Name);
			ShowErrorMessage(val);
			RestorePendingTarget();
			Stop();
			return;
		}
		if (!ResolveTargetParty())
		{
			TextObject val2 = new TextObject("{=AIAction_AttackTargetNotFound}{HERO_NAME} cannot attack - target party '{PARTY_ID}' not found.", (Dictionary<string, object>)null);
			val2.SetTextVariable("HERO_NAME", base.TargetHero.Name);
			val2.SetTextVariable("PARTY_ID", _targetPartyId ?? "unknown");
			ShowErrorMessage(val2);
			RestorePendingTarget();
			Stop();
			return;
		}
		if (_heroParty.CurrentSettlement != null)
		{
			try
			{
				LeaveSettlementAction.ApplyForParty(_heroParty);
				LogAction($"Forced {_heroParty.Name} to exit settlement before attacking.");
			}
			catch (Exception ex)
			{
				LogError("Failed to exit settlement: " + ex.Message);
			}
		}
		IssueAttackOrder(initial: true);
	}

	protected override void OnUpdate(float deltaTime)
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		if (!base.IsActive)
		{
			return;
		}
		if (_heroParty == null || base.TargetHero == null)
		{
			Stop();
			return;
		}
		if (!ResolveTargetParty())
		{
			_attackCompleted = true;
			Stop();
			return;
		}
		if (!_warDeclared && _heroParty != null && _targetParty != null)
		{
			Vec2 position2D = _heroParty.GetPosition2D();
			float num = (position2D).DistanceSquared(_targetParty.GetPosition2D());
			if (num <= 1f)
			{
				if (EnsureWarState())
				{
					_warDeclared = true;
				}
				else
				{
					LogError("Failed to ensure war state when initiating attack.");
				}
			}
		}
		if (_heroParty.MapEvent != null)
		{
			if (IsTargetInCurrentBattle())
			{
				_battleStarted = true;
			}
		}
		else if (_battleStarted)
		{
			_attackCompleted = true;
			Stop();
			return;
		}
		if (!_battleStarted && CampaignTime.Now - _lastOrderTime >= CampaignTime.Hours(0.3f))
		{
			IssueAttackOrder();
		}
	}

	protected override void OnStop()
	{
		if (_attackCompleted)
		{
			CompleteTaskStepIfNeeded();
			LogAction("Attack order completed.");
		}
	}

	private bool ResolveTargetParty()
	{
		if (string.IsNullOrEmpty(_targetPartyId))
		{
			return false;
		}
		if (_targetParty != null && (!_targetParty.IsActive || _targetParty.Party == null || _targetParty.IsDisbanding))
		{
			_targetParty = null;
		}
		if (_targetParty == null)
		{
			_targetParty = ((IEnumerable<MobileParty>)MobileParty.All).FirstOrDefault((Func<MobileParty, bool>)((MobileParty p) => ((MBObjectBase)p).StringId == _targetPartyId));
		}
		if (_targetParty == null)
		{
			return false;
		}
		return true;
	}

	private void IssueAttackOrder(bool initial = false)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected O, but got Unknown
		if (_heroParty == null || _targetParty == null)
		{
			return;
		}
		try
		{
			GameVersionCompatibility.SetMoveEngageParty(_heroParty, _targetParty);
			GameVersionCompatibility.ConditionalEnableAi(_heroParty);
			_lastOrderTime = CampaignTime.Now;
			if (!initial)
			{
				return;
			}
			TextObject val = new TextObject("{=AIAction_AttackIssued}{HERO_NAME} is moving to attack {TARGET_NAME}.", (Dictionary<string, object>)null);
			Hero targetHero = base.TargetHero;
			val.SetTextVariable("HERO_NAME", ((targetHero == null) ? null : ((object)targetHero.Name)?.ToString()) ?? "Unknown");
			MobileParty targetParty = _targetParty;
			val.SetTextVariable("TARGET_NAME", ((targetParty == null) ? null : ((object)targetParty.Name)?.ToString()) ?? "Unknown");
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
			LogAction($"Issued attack order: {_heroParty.Name} -> {_targetParty.Name}");
		}
		catch (Exception ex)
		{
			LogError("Failed to issue attack order: " + ex.Message);
		}
	}

	private bool EnsureWarState()
	{
		Hero targetHero = base.TargetHero;
		object obj;
		if (targetHero == null)
		{
			obj = null;
		}
		else
		{
			Clan clan = targetHero.Clan;
			obj = ((clan != null) ? clan.Kingdom : null);
		}
		IFaction attackerFaction = (IFaction)obj;
		if (attackerFaction == null)
		{
			Hero targetHero2 = base.TargetHero;
			attackerFaction = (IFaction)(object)((targetHero2 != null) ? targetHero2.Clan : null);
		}
		MobileParty targetParty = _targetParty;
		IFaction defenderFaction = ((targetParty != null) ? targetParty.MapFaction : null);
		if (attackerFaction == null || defenderFaction == null)
		{
			return true;
		}
		if (attackerFaction.IsAtWarWith(defenderFaction))
		{
			return true;
		}
		try
		{
			DiplomacyPatches.WithBypass(delegate
			{
				DeclareWarAction.ApplyByDefault(attackerFaction, defenderFaction);
			});
			LogAction($"Declared war before attack: {attackerFaction.Name} vs {defenderFaction.Name}");
		}
		catch (Exception ex)
		{
			LogError("Failed to declare war before attack: " + ex.Message);
		}
		return attackerFaction.IsAtWarWith(defenderFaction);
	}

	private bool IsTargetInCurrentBattle()
	{
		MobileParty heroParty = _heroParty;
		if (((heroParty != null) ? heroParty.MapEvent : null) == null || _targetParty == null)
		{
			return false;
		}
		MapEvent mapEvent = _heroParty.MapEvent;
		return ((IEnumerable<MapEventParty>)mapEvent.PartiesOnSide((BattleSideEnum)1)).Any((MapEventParty p) => IsTargetPartyBase((p != null) ? p.Party : null)) || ((IEnumerable<MapEventParty>)mapEvent.PartiesOnSide((BattleSideEnum)0)).Any((MapEventParty p) => IsTargetPartyBase((p != null) ? p.Party : null));
	}

	private bool IsTargetPartyBase(PartyBase partyBase)
	{
		if (partyBase == null || _targetParty == null)
		{
			return false;
		}
		return partyBase.MobileParty == _targetParty;
	}

	private string GetTargetFromTask()
	{
		TaskStep taskStep = (TaskManager.Instance?.GetActiveTask(base.TargetHero))?.GetCurrentStep();
		if (taskStep != null && taskStep.StepType == TaskStepType.AttackParty)
		{
			return taskStep.TargetPartyId;
		}
		return null;
	}

	private void RestorePendingTarget()
	{
		if (base.TargetHero == null)
		{
			return;
		}
		string stringId = ((MBObjectBase)base.TargetHero).StringId;
		if (!string.IsNullOrEmpty(_targetPartyId))
		{
			_pendingTargets[stringId] = _targetPartyId;
			LogPendingTarget($"Restored pending target '{_targetPartyId}' for {base.TargetHero.Name} ({stringId})");
		}
		else if (!_pendingTargets.ContainsKey(stringId))
		{
			string targetFromTask = GetTargetFromTask();
			if (!string.IsNullOrEmpty(targetFromTask))
			{
				_pendingTargets[stringId] = targetFromTask;
				LogPendingTarget($"Restored pending target from task '{targetFromTask}' for {base.TargetHero.Name} ({stringId})");
			}
			else
			{
				LogPendingTarget($"RestorePendingTarget failed: no target id for {base.TargetHero.Name} ({stringId})");
			}
		}
	}

	private bool HeroHasIndependentParty(Hero hero, out string reason)
	{
		reason = string.Empty;
		if (hero == null)
		{
			reason = "hero is null";
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
			reason = "hero is still attached to the player's main party";
			return false;
		}
		if (partyBelongedTo.LeaderHero != hero)
		{
			Hero leaderHero = partyBelongedTo.LeaderHero;
			reason = $"party leader mismatch (leader={((leaderHero != null) ? leaderHero.Name : null)}, hero={hero.Name})";
			return false;
		}
		if (hero.PartyBelongedToAsPrisoner != null)
		{
			reason = "hero is registered as a prisoner party member";
			return false;
		}
		return true;
	}

	private static void LogPendingTarget(string message)
	{
		try
		{
			AIActionsLogger.Instance?.Log("[attack_party][pending] " + message);
		}
		catch
		{
		}
	}

	private void CompleteTaskStepIfNeeded()
	{
		TaskManager instance = TaskManager.Instance;
		if (instance != null)
		{
			HeroTask activeTask = instance.GetActiveTask(base.TargetHero);
			TaskStep taskStep = activeTask?.GetCurrentStep();
			if (taskStep != null && taskStep.StepType == TaskStepType.AttackParty && instance.MoveToNextStep(base.TargetHero))
			{
				TaskStep currentStep = activeTask.GetCurrentStep();
				TaskStepExecutor.ExecuteNextTaskStep(base.TargetHero, currentStep);
			}
		}
	}

	public override Dictionary<string, string> GetStateDataForSave()
	{
		if (string.IsNullOrEmpty(_targetPartyId))
		{
			return null;
		}
		return new Dictionary<string, string> { ["targetPartyId"] = _targetPartyId };
	}
}
