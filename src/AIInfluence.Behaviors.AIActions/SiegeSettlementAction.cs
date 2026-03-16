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
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Siege;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Behaviors.AIActions;

public sealed class SiegeSettlementAction : AIActionBase
{
	private sealed class SiegeOrder
	{
		public string SettlementId;

		public bool AutoReturn;
	}

	private static readonly Dictionary<string, SiegeOrder> _pendingOrders = new Dictionary<string, SiegeOrder>();

	private Settlement _targetSettlement;

	private MobileParty _heroParty;

	private bool _joinedSiege;

	private bool _siegeCompleted;

	private bool _autoReturn;

	private CampaignTime _lastOrderTime = CampaignTime.Zero;

	private bool _warDeclared;

	private const float SIEGE_JOIN_DISTANCE = 6f;

	private CampaignTime _lastSiegeMaintenanceTime = CampaignTime.Zero;

	public override string ActionName => "siege_settlement";

	public override string Description => "Hero besieges a settlement";

	public static bool PrepareSiegeTarget(Hero hero, string settlementStringId, bool autoReturn)
	{
		if (hero == null || string.IsNullOrWhiteSpace(settlementStringId))
		{
			return false;
		}
		_pendingOrders[((MBObjectBase)hero).StringId] = new SiegeOrder
		{
			SettlementId = settlementStringId.Trim(),
			AutoReturn = autoReturn
		};
		return true;
	}

	private SiegeOrder ConsumePendingOrder()
	{
		if (base.TargetHero != null && _pendingOrders.TryGetValue(((MBObjectBase)base.TargetHero).StringId, out var value))
		{
			_pendingOrders.Remove(((MBObjectBase)base.TargetHero).StringId);
			return value;
		}
		return null;
	}

	public override void Initialize(Hero hero)
	{
		base.Initialize(hero);
		_warDeclared = false;
		SiegeOrder siegeOrder = ConsumePendingOrder();
		if (siegeOrder != null)
		{
			_targetSettlement = ResolveSettlement(siegeOrder.SettlementId);
			_autoReturn = siegeOrder.AutoReturn;
		}
	}

	public override bool CanExecute()
	{
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected O, but got Unknown
		if (base.TargetHero == null || base.TargetHero.IsDead || base.TargetHero.IsPrisoner)
		{
			return false;
		}
		if (_targetSettlement == null)
		{
			_targetSettlement = ResolveSettlementFromContext();
			if (_targetSettlement == null)
			{
				TextObject val = new TextObject("{=AIAction_SiegeNoTarget}{HERO_NAME} cannot siege - target settlement not found.", (Dictionary<string, object>)null);
				Hero targetHero = base.TargetHero;
				val.SetTextVariable("HERO_NAME", ((targetHero == null) ? null : ((object)targetHero.Name)?.ToString()) ?? "Unknown");
				ShowErrorMessage(val);
				return false;
			}
		}
		MobileParty partyBelongedTo = base.TargetHero.PartyBelongedTo;
		if (partyBelongedTo == null || partyBelongedTo == MobileParty.MainParty)
		{
			LogError("Cannot start siege: hero must command an independent party (use create_party first).");
			TextObject val2 = new TextObject("{=AIAction_SiegeNoParty}{HERO_NAME} cannot siege - must command an independent party first.", (Dictionary<string, object>)null);
			val2.SetTextVariable("HERO_NAME", base.TargetHero.Name);
			ShowErrorMessage(val2);
			return false;
		}
		if (IsSettlementOwnedByHero(_targetSettlement, base.TargetHero))
		{
			TextObject name = base.TargetHero.Name;
			TextObject name2 = _targetSettlement.Name;
			Clan clan = base.TargetHero.Clan;
			LogError(string.Format("Cannot siege own settlement: {0} attempted to attack {1} which belongs to {2}.", name, name2, ((clan == null) ? null : ((object)clan.Name)?.ToString()) ?? "their faction"));
			TextObject val3 = new TextObject("{=AIAction_SiegeOwnSettlement}{HERO_NAME} cannot siege {SETTLEMENT_NAME} - it belongs to their own faction.", (Dictionary<string, object>)null);
			val3.SetTextVariable("HERO_NAME", base.TargetHero.Name);
			val3.SetTextVariable("SETTLEMENT_NAME", _targetSettlement.Name);
			ShowErrorMessage(val3);
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
		if (IsSettlementOwnedByHero(_targetSettlement, base.TargetHero))
		{
			TextObject name = base.TargetHero.Name;
			TextObject name2 = _targetSettlement.Name;
			Clan clan = base.TargetHero.Clan;
			LogError(string.Format("Cannot start siege: {0} attempted to attack own settlement {1} which belongs to {2}. Action stopped.", name, name2, ((clan == null) ? null : ((object)clan.Name)?.ToString()) ?? "their faction"));
			TextObject val = new TextObject("{=AIAction_SiegeOwnSettlementStart}{HERO_NAME} cannot siege {SETTLEMENT_NAME} - it belongs to their own faction.", (Dictionary<string, object>)null);
			val.SetTextVariable("HERO_NAME", base.TargetHero.Name);
			val.SetTextVariable("SETTLEMENT_NAME", _targetSettlement.Name);
			ShowErrorMessage(val);
			Stop();
			return;
		}
		_heroParty = base.TargetHero.PartyBelongedTo;
		if (_heroParty.CurrentSettlement != null && _heroParty.CurrentSettlement != _targetSettlement)
		{
			try
			{
				LeaveSettlementAction.ApplyForParty(_heroParty);
				LogAction($"Forced {_heroParty.Name} to exit {_heroParty.CurrentSettlement.Name} before moving to siege.");
			}
			catch (Exception ex)
			{
				LogError("Failed to exit settlement: " + ex.Message);
			}
		}
		IssueBesiegeOrder(initial: true);
	}

	protected override void OnUpdate(float deltaTime)
	{
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		if (!base.IsActive)
		{
			return;
		}
		if (_heroParty == null || base.TargetHero == null || _targetSettlement == null)
		{
			Stop();
		}
		else if (!_targetSettlement.IsTown && !_targetSettlement.IsCastle)
		{
			LogError("Target settlement is no longer valid for siege.");
			_siegeCompleted = true;
			Stop();
		}
		else if (!_joinedSiege)
		{
			if (!_warDeclared)
			{
				Vec2 position2D = _heroParty.GetPosition2D();
				float num = (position2D).DistanceSquared(_targetSettlement.GetPosition2D());
				if (num <= 4f)
				{
					if (!EnsureWarState())
					{
						LogError("Failed to ensure war state before starting siege; stopping action.");
						_siegeCompleted = true;
						Stop();
						return;
					}
					_warDeclared = true;
				}
			}
			if (CampaignTime.Now - _lastOrderTime >= CampaignTime.Hours(0.25f))
			{
				IssueBesiegeOrder();
			}
			TryStartOrJoinSiege();
		}
		else
		{
			ManageOngoingSiege();
		}
	}

	protected override void OnStop()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Expected O, but got Unknown
		if (!_siegeCompleted)
		{
			return;
		}
		CompleteTaskStepIfNeeded();
		TextObject val = new TextObject("{=AIAction_SiegeCompleted}{HERO_NAME} completed siege operations at {SETTLEMENT_NAME}.", (Dictionary<string, object>)null);
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
	}

	private void IssueBesiegeOrder(bool initial = false)
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
			GameVersionCompatibility.SetMoveBesiegeSettlement(_heroParty, _targetSettlement);
			GameVersionCompatibility.ConditionalEnableAi(_heroParty);
			_lastOrderTime = CampaignTime.Now;
			if (!initial)
			{
				return;
			}
			TextObject val = new TextObject("{=AIAction_SiegeMarch}{HERO_NAME} is marching to besiege {SETTLEMENT_NAME}.", (Dictionary<string, object>)null);
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
		}
		catch (Exception ex)
		{
			LogError("Failed to set besiege order: " + ex.Message);
		}
	}

	private void TryStartOrJoinSiege()
	{
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected O, but got Unknown
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Expected O, but got Unknown
		if (_heroParty == null || _targetSettlement == null)
		{
			return;
		}
		SiegeEvent siegeEvent = _targetSettlement.SiegeEvent;
		if (siegeEvent != null)
		{
			if (siegeEvent.BesiegerCamp.IsBesiegerSideParty(_heroParty))
			{
				_joinedSiege = true;
				LogAction($"Joined existing siege of {_targetSettlement.Name}");
				JoinPartyToSiege(siegeEvent);
			}
		}
		else
		{
			if (!EnsureWarState())
			{
				return;
			}
			Vec2 position2D = _heroParty.GetPosition2D();
			float num = (position2D).DistanceSquared(_targetSettlement.GetPosition2D());
			if (!(num <= 9f))
			{
				return;
			}
			try
			{
				Campaign.Current.SiegeEventManager.StartSiegeEvent(_targetSettlement, _heroParty);
				_joinedSiege = true;
				LogAction($"Started siege of {_targetSettlement.Name}");
				SiegeEvent siegeEvent2 = _targetSettlement.SiegeEvent;
				if (siegeEvent2 != null)
				{
					JoinPartyToSiege(siegeEvent2);
				}
				TextObject val = new TextObject("{=AIAction_SiegeStarted}{HERO_NAME} has started sieging {SETTLEMENT_NAME}.", (Dictionary<string, object>)null);
				Hero targetHero = base.TargetHero;
				val.SetTextVariable("HERO_NAME", ((targetHero == null) ? null : ((object)targetHero.Name)?.ToString()) ?? "Unknown");
				Settlement targetSettlement = _targetSettlement;
				val.SetTextVariable("SETTLEMENT_NAME", ((targetSettlement == null) ? null : ((object)targetSettlement.Name)?.ToString()) ?? "Unknown");
				InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), ExtraColors.GreenAIInfluence));
			}
			catch (Exception ex)
			{
				LogError("Failed to start siege: " + ex.Message);
			}
		}
	}

	private void JoinPartyToSiege(SiegeEvent siegeEvent)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		if (_heroParty == null || siegeEvent == null || siegeEvent.BesiegerCamp == null)
		{
			return;
		}
		try
		{
			if (_heroParty.BesiegerCamp == null)
			{
				Vec2 position2D = _heroParty.GetPosition2D();
				float num = (position2D).Distance(_targetSettlement.GetPosition2D());
				if (num <= 6f)
				{
					_heroParty.BesiegerCamp = siegeEvent.BesiegerCamp;
					LogAction($"Party {_heroParty.Name} joined BesiegerCamp for siege of {_targetSettlement.Name}");
				}
			}
		}
		catch (Exception ex)
		{
			LogError("Failed to join party to siege: " + ex.Message);
		}
	}

	private void ManageOngoingSiege()
	{
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		if (_heroParty == null || _targetSettlement == null || base.TargetHero == null)
		{
			_siegeCompleted = true;
			Stop();
			return;
		}
		if (!EnsureWarState())
		{
			LogAction($"Peace declared during siege, ending siege action for {base.TargetHero.Name}");
			_siegeCompleted = true;
			Stop();
			return;
		}
		if (!_targetSettlement.IsUnderSiege)
		{
			CheckSiegeCompletion();
			return;
		}
		SiegeEvent siegeEvent = _targetSettlement.SiegeEvent;
		if (siegeEvent == null || siegeEvent.BesiegedSettlement != _targetSettlement)
		{
			CheckSiegeCompletion();
			return;
		}
		if (_heroParty.BesiegerCamp == null)
		{
			JoinPartyToSiege(siegeEvent);
		}
		if (CampaignTime.Now - _lastSiegeMaintenanceTime >= CampaignTime.Hours(1f))
		{
			try
			{
				Vec2 position2D = _heroParty.GetPosition2D();
				float num = (position2D).Distance(_targetSettlement.GetPosition2D());
				if (num > 9f)
				{
					GameVersionCompatibility.SetMoveBesiegeSettlement(_heroParty, _targetSettlement);
					LogAction($"Maintaining siege position for {_heroParty.Name} at {_targetSettlement.Name}");
				}
				_lastSiegeMaintenanceTime = CampaignTime.Now;
			}
			catch (Exception ex)
			{
				LogError("Failed to maintain siege position: " + ex.Message);
			}
		}
		if (_heroParty.BesiegerCamp == null || !siegeEvent.BesiegerCamp.IsBesiegerSideParty(_heroParty))
		{
			JoinPartyToSiege(siegeEvent);
		}
	}

	private void CheckSiegeCompletion()
	{
		if (_targetSettlement == null || base.TargetHero == null)
		{
			_siegeCompleted = true;
			Stop();
			return;
		}
		Clan clan = base.TargetHero.Clan;
		if (clan != null)
		{
			if (_targetSettlement.OwnerClan == clan)
			{
				LogAction($"Siege successful: {_targetSettlement.Name} now belongs to {clan.Name}");
			}
			else
			{
				MapEvent siegeMapEvent = GetSiegeMapEvent();
				if (siegeMapEvent != null && WasSiegeSuccessful(siegeMapEvent))
				{
					LogAction($"Siege successful: battle won at {_targetSettlement.Name}");
				}
			}
		}
		_siegeCompleted = true;
		Stop();
	}

	private MapEvent GetSiegeMapEvent()
	{
		try
		{
			Settlement targetSettlement = _targetSettlement;
			SiegeEvent val = ((targetSettlement != null) ? targetSettlement.SiegeEvent : null);
			if (val == null)
			{
				return null;
			}
			Settlement besiegedSettlement = val.BesiegedSettlement;
			object obj;
			if (besiegedSettlement == null)
			{
				obj = null;
			}
			else
			{
				PartyBase party = besiegedSettlement.Party;
				obj = ((party != null) ? party.MapEvent : null);
			}
			if (obj == null)
			{
				BesiegerCamp besiegerCamp = val.BesiegerCamp;
				if (besiegerCamp == null)
				{
					obj = null;
				}
				else
				{
					MobileParty leaderParty = besiegerCamp.LeaderParty;
					obj = ((leaderParty != null) ? leaderParty.MapEvent : null);
				}
			}
			return (MapEvent)obj;
		}
		catch
		{
			return null;
		}
	}

	private bool WasSiegeSuccessful(MapEvent mapEvent)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Invalid comparison between Unknown and I4
		if (mapEvent == null)
		{
			return false;
		}
		try
		{
			return (int)mapEvent.WinningSide == 1;
		}
		catch
		{
			return false;
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
		IFaction val = (IFaction)obj;
		if (val == null)
		{
			Hero targetHero2 = base.TargetHero;
			val = (IFaction)(object)((targetHero2 != null) ? targetHero2.Clan : null);
		}
		Settlement targetSettlement = _targetSettlement;
		IFaction val2 = ((targetSettlement != null) ? targetSettlement.MapFaction : null);
		if (val == null || val2 == null)
		{
			return true;
		}
		if (val.IsAtWarWith(val2))
		{
			return true;
		}
		Kingdom attackerKingdom = (Kingdom)(object)((val is Kingdom) ? val : null);
		if (attackerKingdom != null)
		{
			Kingdom defenderKingdom = (Kingdom)(object)((val2 is Kingdom) ? val2 : null);
			if (defenderKingdom != null)
			{
				try
				{
					DiplomacyPatches.WithBypass(delegate
					{
						DeclareWarAction.ApplyByDefault((IFaction)(object)attackerKingdom, (IFaction)(object)defenderKingdom);
					});
					LogAction($"Declared war: {attackerKingdom.Name} vs {defenderKingdom.Name} before siege.");
				}
				catch (Exception ex)
				{
					LogError("Failed to declare war: " + ex.Message);
				}
				return val.IsAtWarWith(val2);
			}
		}
		return val.IsAtWarWith(val2);
	}

	private Settlement ResolveSettlementFromContext()
	{
		SiegeOrder siegeOrder = ConsumePendingOrder();
		if (siegeOrder != null)
		{
			_autoReturn = siegeOrder.AutoReturn;
			return ResolveSettlement(siegeOrder.SettlementId);
		}
		TaskStep taskStep = (TaskManager.Instance?.GetActiveTask(base.TargetHero))?.GetCurrentStep();
		if (taskStep != null && taskStep.StepType == TaskStepType.SiegeSettlement)
		{
			_autoReturn = false;
			return taskStep.GetTargetSettlement();
		}
		return null;
	}

	private Settlement ResolveSettlement(string settlementId)
	{
		if (string.IsNullOrEmpty(settlementId))
		{
			return null;
		}
		Settlement val = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => ((MBObjectBase)s).StringId.Equals(settlementId, StringComparison.OrdinalIgnoreCase)));
		if (val == null)
		{
			val = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)delegate(Settlement s)
			{
				TextObject name = s.Name;
				return name != null && ((object)name).ToString()?.Equals(settlementId, StringComparison.OrdinalIgnoreCase) == true;
			});
		}
		return val;
	}

	private bool IsSettlementOwnedByHero(Settlement settlement, Hero hero)
	{
		if (settlement == null || hero == null || hero.Clan == null)
		{
			return false;
		}
		if (settlement.OwnerClan == hero.Clan)
		{
			return true;
		}
		if (hero.Clan.Kingdom != null && (object)settlement.MapFaction == hero.Clan.Kingdom)
		{
			return true;
		}
		if (hero.Clan.Kingdom == null && (object)settlement.MapFaction == hero.Clan)
		{
			return true;
		}
		return false;
	}

	private void CompleteTaskStepIfNeeded()
	{
		TaskManager instance = TaskManager.Instance;
		if (instance == null)
		{
			if (_autoReturn)
			{
				AIActionManager.Instance.StartAction(base.TargetHero, "return_to_player");
			}
			return;
		}
		HeroTask activeTask = instance.GetActiveTask(base.TargetHero);
		TaskStep taskStep = activeTask?.GetCurrentStep();
		if (taskStep == null || taskStep.StepType != TaskStepType.SiegeSettlement)
		{
			if (_autoReturn)
			{
				AIActionManager.Instance.StartAction(base.TargetHero, "return_to_player");
			}
		}
		else if (instance.MoveToNextStep(base.TargetHero))
		{
			TaskStep currentStep = activeTask.GetCurrentStep();
			TaskStepExecutor.ExecuteNextTaskStep(base.TargetHero, currentStep);
		}
		else if (_autoReturn)
		{
			AIActionManager.Instance.StartAction(base.TargetHero, "return_to_player");
		}
	}

	public override Dictionary<string, string> GetStateDataForSave()
	{
		if (_targetSettlement == null)
		{
			return null;
		}
		return new Dictionary<string, string>
		{
			["settlementId"] = ((MBObjectBase)_targetSettlement).StringId,
			["autoReturn"] = _autoReturn.ToString()
		};
	}
}
