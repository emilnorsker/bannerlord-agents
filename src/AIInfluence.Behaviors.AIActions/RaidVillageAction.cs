using System;
using System.Collections.Generic;
using System.Linq;
using AIInfluence.Behaviors.AIActions.TaskSystem;
using AIInfluence.Diplomacy;
using AIInfluence.Util;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Behaviors.AIActions;

public sealed class RaidVillageAction : AIActionBase
{
	private static readonly Dictionary<string, string> _pendingTargets = new Dictionary<string, string>();

	private string _targetVillageId;

	private Settlement _targetVillage;

	private MobileParty _heroParty;

	private bool _raidCompleted;

	private bool _warDeclared;

	private CampaignTime _lastOrderTime = CampaignTime.Zero;

	public override string ActionName => "raid_village";

	public override string Description => "Hero raids the specified village (loots it)";

	public static bool PrepareRaidTarget(Hero hero, string settlementId)
	{
		if (hero == null || string.IsNullOrWhiteSpace(settlementId))
		{
			return false;
		}
		_pendingTargets[((MBObjectBase)hero).StringId] = settlementId.Trim();
		return true;
	}

	private string ConsumePendingTarget()
	{
		if (base.TargetHero != null && _pendingTargets.TryGetValue(((MBObjectBase)base.TargetHero).StringId, out var value))
		{
			_pendingTargets.Remove(((MBObjectBase)base.TargetHero).StringId);
			return value;
		}
		return null;
	}

	public override void Initialize(Hero hero)
	{
		base.Initialize(hero);
		_targetVillageId = ConsumePendingTarget();
		_warDeclared = false;
	}

	public override bool CanExecute()
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Expected O, but got Unknown
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Expected O, but got Unknown
		if (base.TargetHero == null || base.TargetHero.IsDead || base.TargetHero.IsPrisoner)
		{
			return false;
		}
		MobileParty partyBelongedTo = base.TargetHero.PartyBelongedTo;
		if (partyBelongedTo == null || partyBelongedTo == MobileParty.MainParty)
		{
			LogError("Cannot raid village: hero must command an independent party (use create_party first).");
			TextObject val = new TextObject("{=AIAction_RaidNoParty}{HERO_NAME} cannot raid - must command an independent party first.", (Dictionary<string, object>)null);
			val.SetTextVariable("HERO_NAME", base.TargetHero.Name);
			ShowErrorMessage(val);
			return false;
		}
		if (string.IsNullOrEmpty(_targetVillageId))
		{
			_targetVillageId = GetTargetFromTask();
		}
		if (string.IsNullOrEmpty(_targetVillageId))
		{
			LogError("Cannot raid village: target settlement id is missing.");
			TextObject val2 = new TextObject("{=AIAction_RaidNoTarget}{HERO_NAME} cannot raid - target village not specified.", (Dictionary<string, object>)null);
			val2.SetTextVariable("HERO_NAME", base.TargetHero.Name);
			ShowErrorMessage(val2);
			return false;
		}
		_targetVillage = ResolveVillage(_targetVillageId);
		if (_targetVillage == null || !_targetVillage.IsVillage)
		{
			LogError("Cannot raid village: settlement '" + _targetVillageId + "' is not a valid village.");
			TextObject val3 = new TextObject("{=AIAction_RaidNotVillage}{HERO_NAME} cannot raid '{SETTLEMENT_ID}' - it is not a valid village.", (Dictionary<string, object>)null);
			val3.SetTextVariable("HERO_NAME", base.TargetHero.Name);
			val3.SetTextVariable("SETTLEMENT_ID", _targetVillageId);
			ShowErrorMessage(val3);
			return false;
		}
		if (IsVillageOwnedByHero(_targetVillage, base.TargetHero))
		{
			TextObject name = base.TargetHero.Name;
			TextObject name2 = _targetVillage.Name;
			Clan clan = base.TargetHero.Clan;
			LogError(string.Format("Cannot raid own village: {0} attempted to raid {1} which belongs to {2}.", name, name2, ((clan == null) ? null : ((object)clan.Name)?.ToString()) ?? "their faction"));
			TextObject val4 = new TextObject("{=AIAction_RaidOwnVillage}{HERO_NAME} cannot raid {VILLAGE_NAME} - it belongs to their own faction.", (Dictionary<string, object>)null);
			val4.SetTextVariable("HERO_NAME", base.TargetHero.Name);
			val4.SetTextVariable("VILLAGE_NAME", _targetVillage.Name);
			ShowErrorMessage(val4);
			return false;
		}
		return true;
	}

	protected override void OnStart()
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		if (!CanExecute())
		{
			Stop();
			return;
		}
		if (IsVillageOwnedByHero(_targetVillage, base.TargetHero))
		{
			TextObject name = base.TargetHero.Name;
			TextObject name2 = _targetVillage.Name;
			Clan clan = base.TargetHero.Clan;
			LogError(string.Format("Cannot start raid: {0} attempted to raid own village {1} which belongs to {2}. Action stopped.", name, name2, ((clan == null) ? null : ((object)clan.Name)?.ToString()) ?? "their faction"));
			TextObject val = new TextObject("{=AIAction_RaidOwnVillageStart}{HERO_NAME} cannot raid {VILLAGE_NAME} - it belongs to their own faction.", (Dictionary<string, object>)null);
			val.SetTextVariable("HERO_NAME", base.TargetHero.Name);
			val.SetTextVariable("VILLAGE_NAME", _targetVillage.Name);
			ShowErrorMessage(val);
			Stop();
			return;
		}
		_heroParty = base.TargetHero.PartyBelongedTo;
		if (_heroParty.CurrentSettlement != null && _heroParty.CurrentSettlement != _targetVillage)
		{
			try
			{
				LeaveSettlementAction.ApplyForParty(_heroParty);
				LogAction($"Forced {_heroParty.Name} to exit {_heroParty.CurrentSettlement.Name} before moving to raid.");
			}
			catch (Exception ex)
			{
				LogError("Failed to exit settlement before raid: " + ex.Message);
			}
		}
		IssueRaidOrder(initial: true);
	}

	protected override void OnUpdate(float deltaTime)
	{
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		if (!base.IsActive)
		{
			return;
		}
		if (_heroParty == null || base.TargetHero == null || _targetVillage == null)
		{
			Stop();
		}
		else if (!_targetVillage.IsVillage)
		{
			LogError("Target settlement is no longer a village - cancelling raid.");
			_raidCompleted = true;
			Stop();
		}
		else
		{
			if (_raidCompleted)
			{
				return;
			}
			if (!_warDeclared)
			{
				Vec2 position2D = _heroParty.GetPosition2D();
				float num = ((Vec2)(ref position2D)).DistanceSquared(_targetVillage.GetPosition2D());
				if (num <= 4f)
				{
					if (!EnsureWarState())
					{
						LogError("Failed to ensure war state before raid; stopping action.");
						_raidCompleted = true;
						Stop();
						return;
					}
					_warDeclared = true;
				}
			}
			if (_heroParty.MapEvent != null)
			{
				if (_heroParty.MapEvent.HasWinner)
				{
					_raidCompleted = true;
					Stop();
				}
			}
			else if (CampaignTime.Now - _lastOrderTime >= CampaignTime.Hours(0.25f))
			{
				IssueRaidOrder();
			}
		}
	}

	protected override void OnStop()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		if (!_raidCompleted)
		{
			return;
		}
		CompleteTaskStepIfNeeded();
		TextObject val = new TextObject("{=AIAction_RaidCompleted}{HERO_NAME} completed a raid on {SETTLEMENT_NAME}.", (Dictionary<string, object>)null);
		Hero targetHero = base.TargetHero;
		val.SetTextVariable("HERO_NAME", ((targetHero == null) ? null : ((object)targetHero.Name)?.ToString()) ?? "Unknown");
		Settlement targetVillage = _targetVillage;
		val.SetTextVariable("SETTLEMENT_NAME", ((targetVillage == null) ? null : ((object)targetVillage.Name)?.ToString()) ?? "Unknown");
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
	}

	private void IssueRaidOrder(bool initial = false)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		try
		{
			GameVersionCompatibility.SetMoveRaidSettlement(_heroParty, _targetVillage);
			GameVersionCompatibility.ConditionalEnableAi(_heroParty);
			_lastOrderTime = CampaignTime.Now;
			if (!initial)
			{
				return;
			}
			TextObject val = new TextObject("{=AIAction_RaidIssued}{HERO_NAME} is moving to raid {SETTLEMENT_NAME}.", (Dictionary<string, object>)null);
			Hero targetHero = base.TargetHero;
			val.SetTextVariable("HERO_NAME", ((targetHero == null) ? null : ((object)targetHero.Name)?.ToString()) ?? "Unknown");
			Settlement targetVillage = _targetVillage;
			val.SetTextVariable("SETTLEMENT_NAME", ((targetVillage == null) ? null : ((object)targetVillage.Name)?.ToString()) ?? "Unknown");
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
			LogAction($"Issued raid order: {_heroParty.Name} -> {_targetVillage.Name}");
		}
		catch (Exception ex)
		{
			LogError("Failed to issue raid order: " + ex.Message);
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
		Settlement targetVillage = _targetVillage;
		IFaction defenderFaction = ((targetVillage != null) ? targetVillage.MapFaction : null);
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
			LogAction($"Declared war before raid: {attackerFaction.Name} vs {defenderFaction.Name}");
		}
		catch (Exception ex)
		{
			LogError("Failed to declare war before raid: " + ex.Message);
		}
		return attackerFaction.IsAtWarWith(defenderFaction);
	}

	private string GetTargetFromTask()
	{
		TaskStep taskStep = (TaskManager.Instance?.GetActiveTask(base.TargetHero))?.GetCurrentStep();
		if (taskStep != null && taskStep.StepType == TaskStepType.RaidVillage)
		{
			return taskStep.TargetSettlementId;
		}
		return null;
	}

	private Settlement ResolveVillage(string settlementId)
	{
		if (string.IsNullOrEmpty(settlementId))
		{
			return null;
		}
		return ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => s.IsVillage && ((MBObjectBase)s).StringId.Equals(settlementId, StringComparison.OrdinalIgnoreCase)));
	}

	private bool IsVillageOwnedByHero(Settlement village, Hero hero)
	{
		if (village == null || hero == null || hero.Clan == null)
		{
			return false;
		}
		if (village.OwnerClan == hero.Clan)
		{
			return true;
		}
		if (hero.Clan.Kingdom != null && (object)village.MapFaction == hero.Clan.Kingdom)
		{
			return true;
		}
		if (hero.Clan.Kingdom == null && (object)village.MapFaction == hero.Clan)
		{
			return true;
		}
		Village village2 = village.Village;
		if (((village2 != null) ? village2.Bound : null) != null)
		{
			Settlement bound = village.Village.Bound;
			if (bound.OwnerClan == hero.Clan)
			{
				return true;
			}
			if (hero.Clan.Kingdom != null && (object)bound.MapFaction == hero.Clan.Kingdom)
			{
				return true;
			}
		}
		return false;
	}

	private void CompleteTaskStepIfNeeded()
	{
		TaskManager instance = TaskManager.Instance;
		if (instance != null)
		{
			HeroTask activeTask = instance.GetActiveTask(base.TargetHero);
			TaskStep taskStep = activeTask?.GetCurrentStep();
			if (taskStep != null && taskStep.StepType == TaskStepType.RaidVillage && instance.MoveToNextStep(base.TargetHero))
			{
				TaskStep currentStep = activeTask.GetCurrentStep();
				TaskStepExecutor.ExecuteNextTaskStep(base.TargetHero, currentStep);
			}
		}
	}

	public override Dictionary<string, string> GetStateDataForSave()
	{
		Dictionary<string, string> dictionary = base.GetStateDataForSave();
		if (dictionary == null)
		{
			dictionary = new Dictionary<string, string>();
		}
		Dictionary<string, string> dictionary2 = dictionary;
		Settlement targetVillage = _targetVillage;
		dictionary2["targetVillageId"] = ((targetVillage != null) ? ((MBObjectBase)targetVillage).StringId : null) ?? _targetVillageId ?? string.Empty;
		dictionary["warDeclared"] = _warDeclared.ToString();
		return dictionary;
	}
}
