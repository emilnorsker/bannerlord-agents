using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AIInfluence.Diplomacy;
using AIInfluence.Util;
using SandBox;
using SandBox.Missions.AgentBehaviors;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.AgentOrigins;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.Settlements.Locations;
using TaleWorlds.CampaignSystem.Siege;
using TaleWorlds.Core;
using TaleWorlds.Engine;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace AIInfluence.Behaviors.AIActions;

public class FollowPlayerAction : AIActionBase
{
	private bool _isTemporaryPartyCreated = false;

	private bool _needsMissionFollowingInit = false;

	private Settlement _originSettlement;

	private CampaignTime _lastDistanceCheckTime = CampaignTime.Zero;

	private int _forcedUpdatesCount = 0;

	private float _lastNoShipMessageTime = 0f;

	private bool _boardedShip = false;

	private float _timeSinceLastForcedUpdate = 0f;

	private const float FORCED_UPDATE_INTERVAL = 3f;

	private bool _wasInSiegeCamp = false;

	private float _missionFollowRecheckTimer = 0f;

	private const float MISSION_FOLLOW_RECHECK_INTERVAL = 5f;

	public override string ActionName => "follow_player";

	public override string Description => "Companion follows the player";

	public bool IsBoardedOnShip => _boardedShip;

	private bool IsLord(Hero hero)
	{
		if (hero == null)
		{
			return false;
		}
		return hero.Clan != null && hero.Clan != Clan.PlayerClan && hero.Clan.Leader != hero && !hero.IsWanderer;
	}

	private bool IsPlayerRelation(Hero hero)
	{
		if (hero == null || Hero.MainHero == null)
		{
			return false;
		}
		return hero == Hero.MainHero.Spouse || Hero.MainHero.Spouse == hero || hero.Siblings.Contains(Hero.MainHero) || Hero.MainHero.Siblings.Contains(hero) || ((List<Hero>)(object)hero.Children).Contains(Hero.MainHero) || ((List<Hero>)(object)Hero.MainHero.Children).Contains(hero) || hero.Father == Hero.MainHero || hero.Mother == Hero.MainHero || Hero.MainHero.Father == hero || Hero.MainHero.Mother == hero;
	}

	public override bool CanExecute()
	{
		if (base.TargetHero == null)
		{
			return false;
		}
		if (IsInPlayerParty())
		{
			return true;
		}
		if (Mission.Current != null && GetPlayerAgent() != null && base.TargetAgent != null)
		{
			return true;
		}
		if (base.TargetHero.PartyBelongedTo != null && MobileParty.MainParty != null)
		{
			return true;
		}
		if (Mission.Current == null && MobileParty.MainParty != null)
		{
			return true;
		}
		return false;
	}

	protected override void OnStart()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		LogAction($"OnStart called for {base.TargetHero.Name}");
		CaptureOriginSettlementIfNeeded();
		if (!CanExecute())
		{
			LogError("Cannot start following: conditions not met");
			TextObject val = new TextObject("{=AIAction_FollowCannotStart}{HERO_NAME} cannot follow you - required conditions not met.", (Dictionary<string, object>)null);
			Hero targetHero = base.TargetHero;
			val.SetTextVariable("HERO_NAME", ((targetHero == null) ? null : ((object)targetHero.Name)?.ToString()) ?? "Unknown");
			ShowErrorMessage(val);
			Stop();
			return;
		}
		LogAction($"Starting follow action for {base.TargetHero.Name}");
		bool flag = base.TargetHero.PartyBelongedTo == MobileParty.MainParty;
		SetupFollowing();
		_forcedUpdatesCount = 0;
		_timeSinceLastForcedUpdate = 0f;
		if (!flag)
		{
			ShowFollowingStartedMessage();
		}
		else
		{
			LogAction($"{base.TargetHero.Name} is already in player party - skipping follow message");
		}
	}

	protected override void OnStop()
	{
		if (base.TargetHero == null)
		{
			LogError("CRITICAL: TargetHero is null during OnStop! Skipping cleanup.");
			return;
		}
		if (base.TargetHero == Hero.MainHero)
		{
			LogError("CRITICAL: Attempted to stop follow action for MainHero! Skipping cleanup.");
			return;
		}
		if (MobileParty.MainParty == null)
		{
			LogError("CRITICAL: MobileParty.MainParty is null during OnStop! Skipping cleanup to prevent game corruption.");
			return;
		}
		LogAction($"OnStop called for {base.TargetHero.Name} (_needsMissionFollowingInit was {_needsMissionFollowingInit})");
		Hero targetHero = base.TargetHero;
		MobileParty val = ((targetHero != null) ? targetHero.PartyBelongedTo : null);
		if (val != null && !_isTemporaryPartyCreated)
		{
			NonCombatantPartyProtector instance = NonCombatantPartyProtector.Instance;
			if (instance != null && instance.IsPartyProtected(val))
			{
				instance.UnregisterPartyProtection(val);
				LogAction($"Unregistered party {val.Name} from non-combatant protection");
			}
		}
		_needsMissionFollowingInit = false;
		Hero targetHero2 = base.TargetHero;
		MobileParty val2 = ((targetHero2 != null) ? targetHero2.PartyBelongedTo : null);
		if (val2 != null && (val2.BesiegerCamp != null || _wasInSiegeCamp))
		{
			val2.BesiegerCamp = null;
			_wasInSiegeCamp = false;
			GameVersionCompatibility.ConditionalEnableAi(val2);
			LogAction($"Cleaned up siege camp and re-enabled AI for {val2.Name} on action stop");
		}
		CleanupFollowing();
		if (base.TargetHero == null)
		{
			return;
		}
		bool flag = ReturnToPlayerAction.IsHeroReturning(base.TargetHero);
		bool flag2 = RequiresForcedReturn(base.TargetHero);
		if (flag)
		{
			Hero targetHero3 = base.TargetHero;
			MobileParty val3 = ((targetHero3 != null) ? targetHero3.PartyBelongedTo : null);
			if (val3 != null && val3 != MobileParty.MainParty)
			{
				GameVersionCompatibility.SetMoveModeHold(val3);
				GameVersionCompatibility.ConditionalEnableAi(val3);
				LogAction($"Return-to-player scenario cancelled for {base.TargetHero.Name}; stopped following and re-enabled AI");
			}
			return;
		}
		if (!flag2)
		{
			MobileParty partyBelongedTo = base.TargetHero.PartyBelongedTo;
			if (partyBelongedTo != null && partyBelongedTo != MobileParty.MainParty)
			{
				GameVersionCompatibility.SetMoveModeHold(partyBelongedTo);
				GameVersionCompatibility.ConditionalEnableAi(partyBelongedTo);
				LogAction($"Hero {base.TargetHero.Name} stopped following; party will act autonomously");
			}
			return;
		}
		Settlement val4 = null;
		if (base.TargetHero.IsNotable)
		{
			val4 = base.TargetHero.HomeSettlement;
		}
		else if (base.TargetHero.IsWanderer && (base.TargetHero.Clan == null || base.TargetHero.Clan != Clan.PlayerClan))
		{
			val4 = null;
		}
		Settlement val5 = Settlement.CurrentSettlement;
		if (val5 == null)
		{
			val5 = base.TargetHero.CurrentSettlement;
		}
		if (val5 == null)
		{
			val5 = base.TargetHero.StayingInSettlement;
		}
		if (val4 == null || val5 != val4)
		{
			string arg = ((val5 == null) ? null : ((object)val5.Name)?.ToString()) ?? "null";
			string arg2 = ((val4 == null) ? null : ((object)val4.Name)?.ToString()) ?? "null";
			LogAction($"Hero {base.TargetHero.Name} is NOT in home settlement (current: {arg}, home: {arg2}) - setting up return");
			if (IsInMission() && Settlement.CurrentSettlement != null)
			{
				LogAction($"Player is in mission/settlement - setting up return logic for {base.TargetHero.Name}");
				SetupReturnFromSettlement();
			}
			else
			{
				LogAction($"Player is on global map - setting up return for {base.TargetHero.Name}");
				SetupReturnFromGlobalMap();
			}
		}
		else
		{
			LogAction($"Hero {base.TargetHero.Name} is in home settlement - no return needed");
		}
	}

	private bool RequiresForcedReturn(Hero hero)
	{
		if (hero == null)
		{
			return false;
		}
		if (hero.CompanionOf == Clan.PlayerClan)
		{
			return false;
		}
		if (_isTemporaryPartyCreated)
		{
			return true;
		}
		if (hero.IsNotable)
		{
			return true;
		}
		if (hero.IsWanderer && (hero.Clan == null || hero.Clan != Clan.PlayerClan))
		{
			return true;
		}
		return false;
	}

	public void SetupReturnFromGlobalMap()
	{
		if (base.TargetHero == null)
		{
			return;
		}
		if (!RequiresForcedReturn(base.TargetHero))
		{
			MobileParty partyBelongedTo = base.TargetHero.PartyBelongedTo;
			if (partyBelongedTo != null && partyBelongedTo != MobileParty.MainParty)
			{
				GameVersionCompatibility.ConditionalEnableAi(partyBelongedTo);
				LogAction($"Skipping forced global-map return for {base.TargetHero.Name}; AI re-enabled to let party roam");
			}
			return;
		}
		try
		{
			MobileParty partyBelongedTo2 = base.TargetHero.PartyBelongedTo;
			if (partyBelongedTo2 == null)
			{
				LogAction($"Hero {base.TargetHero.Name} has no party - creating one for return");
				EnsureGlobalMapParty(forceCreate: true);
				partyBelongedTo2 = base.TargetHero.PartyBelongedTo;
				if (partyBelongedTo2 == null)
				{
					LogError($"Failed to create party for {base.TargetHero.Name} - cannot setup return");
					return;
				}
				LogAction($"Created party for {base.TargetHero.Name} - party: {partyBelongedTo2.Name}");
			}
			if (partyBelongedTo2 == MobileParty.MainParty)
			{
				LogAction($"Hero {base.TargetHero.Name} is in player party - no return needed");
				return;
			}
			Settlement val = DetermineReturnSettlement(partyBelongedTo2);
			string arg = ((val == null) ? null : ((object)val.Name)?.ToString()) ?? "unknown destination";
			LogAction($"Return destination for {base.TargetHero.Name}: {arg}");
			if (val == null)
			{
				LogError($"Could not determine return destination for {base.TargetHero.Name}");
			}
			else if (_isTemporaryPartyCreated)
			{
				GameVersionCompatibility.SetMoveGoToSettlement(partyBelongedTo2, val);
				GameVersionCompatibility.ConditionalDisableAi(partyBelongedTo2);
				AIActionManager.Instance.RegisterPartyForRemoval(base.TargetHero, partyBelongedTo2, val);
				LogAction($"Set return destination for temporary party of {base.TargetHero.Name} to {val.Name}");
			}
			else if (base.TargetHero.IsNotable)
			{
				GameVersionCompatibility.SetMoveGoToSettlement(partyBelongedTo2, val);
				GameVersionCompatibility.ConditionalDisableAi(partyBelongedTo2);
				AIActionManager.Instance.RegisterPartyForRemoval(base.TargetHero, partyBelongedTo2, val);
				LogAction($"Set return destination for notable {base.TargetHero.Name} to {val.Name}");
			}
			else if (base.TargetHero.IsWanderer)
			{
				GameVersionCompatibility.SetMoveGoToSettlement(partyBelongedTo2, val);
				GameVersionCompatibility.ConditionalDisableAi(partyBelongedTo2);
				AIActionManager.Instance.RegisterPartyForRemoval(base.TargetHero, partyBelongedTo2, val);
				LogAction($"Set return destination for wanderer {base.TargetHero.Name} to {val.Name}");
			}
			else
			{
				GameVersionCompatibility.ConditionalEnableAi(partyBelongedTo2);
				LogAction($"Re-enabled AI for lord {base.TargetHero.Name} - will decide destination himself");
			}
		}
		catch (Exception ex)
		{
			LogError("Error setting up return from global map: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	public void SetupReturnFromSettlement()
	{
		if (base.TargetHero == null)
		{
			return;
		}
		if (!RequiresForcedReturn(base.TargetHero))
		{
			MobileParty partyBelongedTo = base.TargetHero.PartyBelongedTo;
			if (partyBelongedTo != null && partyBelongedTo != MobileParty.MainParty)
			{
				GameVersionCompatibility.ConditionalEnableAi(partyBelongedTo);
				LogAction($"Skipping settlement return for {base.TargetHero.Name}; party resumes autonomous behavior");
			}
			return;
		}
		try
		{
			MobileParty partyBelongedTo2 = base.TargetHero.PartyBelongedTo;
			if (partyBelongedTo2 == null)
			{
				LogAction($"Hero {base.TargetHero.Name} has no party - creating one for return");
				EnsureGlobalMapParty(forceCreate: true);
				partyBelongedTo2 = base.TargetHero.PartyBelongedTo;
				if (partyBelongedTo2 == null)
				{
					LogError($"Failed to create party for {base.TargetHero.Name} - cannot setup return");
					return;
				}
				LogAction($"Created party for {base.TargetHero.Name} - party: {partyBelongedTo2.Name}");
			}
			if (partyBelongedTo2 == MobileParty.MainParty)
			{
				LogAction($"Hero {base.TargetHero.Name} is in player party - no return needed");
				return;
			}
			Settlement currentSettlement = Settlement.CurrentSettlement;
			if (currentSettlement == null)
			{
				LogAction("No current settlement - cannot setup return");
				return;
			}
			if (partyBelongedTo2.CurrentSettlement == currentSettlement)
			{
				LogAction($"Hero {base.TargetHero.Name}'s party is in settlement {currentSettlement.Name} - will exit and return");
				Settlement val = DetermineReturnSettlement(partyBelongedTo2);
				string arg = ((val == null) ? null : ((object)val.Name)?.ToString()) ?? "unknown destination";
				LogAction($"Return destination for {base.TargetHero.Name}: {arg}");
				if (_isTemporaryPartyCreated)
				{
					if (val != null)
					{
						GameVersionCompatibility.SetMoveGoToSettlement(partyBelongedTo2, val);
						GameVersionCompatibility.ConditionalDisableAi(partyBelongedTo2);
						AIActionManager.Instance.RegisterPartyForRemoval(base.TargetHero, partyBelongedTo2, val);
						LogAction($"Set return destination for temporary party of {base.TargetHero.Name} to {val.Name}");
					}
				}
				else if (base.TargetHero.IsNotable)
				{
					if (val != null)
					{
						GameVersionCompatibility.SetMoveGoToSettlement(partyBelongedTo2, val);
						GameVersionCompatibility.ConditionalDisableAi(partyBelongedTo2);
						AIActionManager.Instance.RegisterPartyForRemoval(base.TargetHero, partyBelongedTo2, val);
						LogAction($"Set return destination for notable {base.TargetHero.Name} to {val.Name}");
					}
				}
				else if (base.TargetHero.IsWanderer)
				{
					if (val != null)
					{
						GameVersionCompatibility.SetMoveGoToSettlement(partyBelongedTo2, val);
						GameVersionCompatibility.ConditionalDisableAi(partyBelongedTo2);
						AIActionManager.Instance.RegisterPartyForRemoval(base.TargetHero, partyBelongedTo2, val);
						LogAction($"Set return destination for wanderer {base.TargetHero.Name} to {val.Name}");
					}
				}
				else
				{
					GameVersionCompatibility.ConditionalEnableAi(partyBelongedTo2);
					LogAction($"Re-enabled AI for lord {base.TargetHero.Name} - will decide destination himself");
				}
				try
				{
					if (partyBelongedTo2.CurrentSettlement == currentSettlement)
					{
						LeaveSettlementAction.ApplyForParty(partyBelongedTo2);
						LogAction($"Forced party of {base.TargetHero.Name} to exit settlement {currentSettlement.Name}");
					}
					return;
				}
				catch (Exception ex)
				{
					LogError("Error forcing party exit: " + ex.Message);
					return;
				}
			}
			LogAction($"Hero {base.TargetHero.Name}'s party is not in settlement - calling StopGlobalMapFollowing");
			StopGlobalMapFollowing();
		}
		catch (Exception ex2)
		{
			LogError("Error setting up return from settlement: " + ex2.Message + "\n" + ex2.StackTrace);
		}
	}

	public void StopWithMessage()
	{
		Stop();
		ShowFollowingStoppedMessage();
	}

	protected override void OnUpdate(float deltaTime)
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Expected O, but got Unknown
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Expected O, but got Unknown
		if (!_isTemporaryPartyCreated && base.TargetHero != null)
		{
			MobileParty partyBelongedTo = base.TargetHero.PartyBelongedTo;
			if (partyBelongedTo != null && partyBelongedTo.LeaderHero != null && partyBelongedTo.LeaderHero != base.TargetHero)
			{
				Hero targetHero = base.TargetHero;
				TextObject arg = ((targetHero != null) ? targetHero.Name : null);
				Hero leaderHero = partyBelongedTo.LeaderHero;
				LogError($"Party leader was replaced! Original: {arg}, New: {((leaderHero != null) ? leaderHero.Name : null)}. Stopping action.");
				TextObject val = new TextObject("{=AIAction_FollowLeaderReplaced}{HERO_NAME} was removed from party leadership. Action stopped.", (Dictionary<string, object>)null);
				Hero targetHero2 = base.TargetHero;
				val.SetTextVariable("HERO_NAME", ((targetHero2 == null) ? null : ((object)targetHero2.Name)?.ToString()) ?? "Unknown");
				InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), Color.FromUint(4294936576u)));
				Stop();
				return;
			}
		}
		if (IsInMission() && base.IsActive)
		{
			if (_needsMissionFollowingInit)
			{
				LogAction($"Initializing mission following for {base.TargetHero.Name} while already in mission");
				_needsMissionFollowingInit = false;
				ReinitializeMissionFollowing();
			}
			Agent playerAgent = GetPlayerAgent();
			if (playerAgent == null || !playerAgent.IsActive())
			{
				LogError("Player agent lost during mission");
				Stop();
				return;
			}
			if (base.TargetAgent == null || !base.TargetAgent.IsActive())
			{
				LogAction($"Target agent for {base.TargetHero.Name} lost during mission - stopping follow");
				Stop();
				return;
			}
			_missionFollowRecheckTimer += deltaTime;
			if (_missionFollowRecheckTimer >= 5f)
			{
				_missionFollowRecheckTimer = 0f;
				ReenforceFollowBehaviorIfNeeded(playerAgent);
			}
		}
		else if (!IsInMission() && base.IsActive && base.TargetHero != null)
		{
			UpdateSeaTravelLogic();
			UpdateGlobalFollowing();
			ProcessForcedAiUpdates(deltaTime);
		}
	}

	private void ProcessForcedAiUpdates(float deltaTime)
	{
		if (_forcedUpdatesCount >= 3)
		{
			return;
		}
		Hero targetHero = base.TargetHero;
		if (((targetHero != null) ? targetHero.PartyBelongedTo : null) == null)
		{
			return;
		}
		_timeSinceLastForcedUpdate += deltaTime;
		if (_timeSinceLastForcedUpdate >= 3f)
		{
			string message = $"Performing forced AI reset {_forcedUpdatesCount + 1}/3 for {base.TargetHero.Name}";
			LogAction(message);
			try
			{
				GameVersionCompatibility.SetMoveModeHold(base.TargetHero.PartyBelongedTo);
				EnsureGlobalMapParty();
			}
			catch (Exception ex)
			{
				LogError("Error during forced AI reset: " + ex.Message);
			}
			_forcedUpdatesCount++;
			_timeSinceLastForcedUpdate = 0f;
		}
	}

	private void UpdateSeaTravelLogic()
	{
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Expected O, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected O, but got Unknown
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		try
		{
			bool flag = IsPlayerOnShip();
			if (_boardedShip && !flag)
			{
				string text = ((object)new TextObject("{=AIAction_Disembarking}{HERO_NAME} leaves your ship.", (Dictionary<string, object>)null).SetTextVariable("HERO_NAME", base.TargetHero.Name)).ToString();
				LogAction(text);
				InformationManager.DisplayMessage(new InformationMessage(text, Colors.Gray));
				EnsureGlobalMapParty(forceCreate: true);
				_boardedShip = false;
			}
			else
			{
				if (!(!_boardedShip && flag))
				{
					return;
				}
				MobileParty partyBelongedTo = base.TargetHero.PartyBelongedTo;
				if (partyBelongedTo == null || !partyBelongedTo.IsActive || partyBelongedTo == MobileParty.MainParty)
				{
					return;
				}
				Vec2 position2D = partyBelongedTo.GetPosition2D();
				float num = (position2D).Distance(MobileParty.MainParty.GetPosition2D());
				if (partyBelongedTo.IsCaravan || partyBelongedTo.MemberRoster.TotalManCount > 1)
				{
					if (num < 15f && !GameVersionCompatibility.HasShips(partyBelongedTo))
					{
						float applicationTime = Time.ApplicationTime;
						if (applicationTime - _lastNoShipMessageTime > 10f)
						{
							string text2 = ((object)new TextObject("{=AIAction_NoShips}{HERO_NAME} has no ships and cannot follow you.", (Dictionary<string, object>)null).SetTextVariable("HERO_NAME", base.TargetHero.Name)).ToString();
							InformationManager.DisplayMessage(new InformationMessage(text2, Colors.Gray));
							_lastNoShipMessageTime = applicationTime;
						}
					}
				}
				else if (num < 3.5f)
				{
					string text3 = ((object)new TextObject("{=AIAction_Boarding}{HERO_NAME} boards your ship.", (Dictionary<string, object>)null).SetTextVariable("HERO_NAME", base.TargetHero.Name)).ToString();
					LogAction(text3);
					InformationManager.DisplayMessage(new InformationMessage(text3, Colors.Gray));
					BoardShip(partyBelongedTo);
				}
			}
		}
		catch (Exception ex)
		{
			LogError("Error in sea travel logic: " + ex.Message);
			InformationManager.DisplayMessage(new InformationMessage("Error: " + ex.Message, ExtraColors.RedAIInfluence));
		}
	}

	private void BoardShip(MobileParty heroParty)
	{
		if (heroParty == null)
		{
			return;
		}
		try
		{
			_boardedShip = true;
			if (base.TargetHero.PartyBelongedTo != MobileParty.MainParty)
			{
				AddHeroToPartyAction.Apply(base.TargetHero, MobileParty.MainParty, true);
			}
			if (heroParty.MemberRoster.TotalManCount > 0)
			{
				MobileParty.MainParty.MemberRoster.Add(heroParty.MemberRoster);
				LogAction($"Merged troops from {heroParty.Name} to player ship");
			}
			if (heroParty.PrisonRoster.TotalManCount > 0)
			{
				MobileParty.MainParty.PrisonRoster.Add(heroParty.PrisonRoster);
			}
			if (heroParty.IsActive && heroParty != MobileParty.MainParty)
			{
				GameVersionCompatibility.RemoveShips(heroParty);
				DestroyPartyAction.Apply((PartyBase)null, heroParty);
				LogAction($"Destroyed old party of {base.TargetHero.Name} after boarding");
			}
			else if (heroParty == MobileParty.MainParty)
			{
				LogError("CRITICAL: Attempted to destroy MainParty in BoardShip! This would corrupt the game. Skipping destruction.");
			}
		}
		catch (Exception ex)
		{
			LogError("Failed to board ship: " + ex.Message);
			_boardedShip = false;
		}
	}

	private bool IsPlayerOnShip()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Invalid comparison between Unknown and I4
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Invalid comparison between Unknown and I4
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Invalid comparison between Unknown and I4
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Invalid comparison between Unknown and I4
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Invalid comparison between Unknown and I4
		if (MobileParty.MainParty == null)
		{
			return false;
		}
		TerrainType faceTerrainType = Campaign.Current.MapSceneWrapper.GetFaceTerrainType(MobileParty.MainParty.CurrentNavigationFace);
		return (int)faceTerrainType == 10 || (int)faceTerrainType == 8 || (int)faceTerrainType == 11 || (int)faceTerrainType == 18 || (int)faceTerrainType == 19;
	}

	private void UpdateGlobalFollowing()
	{
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e9: Invalid comparison between Unknown and I4
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		if (base.TargetHero == null)
		{
			return;
		}
		try
		{
			MobileParty partyBelongedTo = base.TargetHero.PartyBelongedTo;
			MobileParty mainParty = MobileParty.MainParty;
			if (partyBelongedTo == null || mainParty == null || partyBelongedTo == mainParty || partyBelongedTo.CurrentSettlement != null)
			{
				return;
			}
			if (AIActionManager.Instance.IsPartyRegisteredForReturn(base.TargetHero))
			{
				LogAction($"Party of {base.TargetHero.Name} is registered for return to settlement - skipping escort restoration");
				return;
			}
			Vec2 position2D;
			if (mainParty.BesiegedSettlement != null)
			{
				Settlement besiegedSettlement = mainParty.BesiegedSettlement;
				SiegeEvent val = ((besiegedSettlement != null) ? besiegedSettlement.SiegeEvent : null);
				if (val != null && val.BesiegerCamp != null)
				{
					if (partyBelongedTo.BesiegerCamp == null || partyBelongedTo.BesiegerCamp != val.BesiegerCamp)
					{
						position2D = partyBelongedTo.GetPosition2D();
						float num = (position2D).Distance(besiegedSettlement.GetPosition2D());
						if (num <= 6f)
						{
							if (!EnsureWarStateForSiege(base.TargetHero, besiegedSettlement))
							{
								LogError($"Failed to ensure war state for {base.TargetHero.Name} before joining siege of {besiegedSettlement.Name}");
								return;
							}
							partyBelongedTo.BesiegerCamp = val.BesiegerCamp;
							LogAction($"Party {partyBelongedTo.Name} joined BesiegerCamp for siege of {besiegedSettlement.Name} (following player)");
							GameVersionCompatibility.ConditionalDisableAi(partyBelongedTo);
							_wasInSiegeCamp = true;
							LogAction($"Disabled AI for {partyBelongedTo.Name} to prevent leaving siege camp");
						}
						else if (!EnsureWarStateForSiege(base.TargetHero, besiegedSettlement))
						{
							LogError($"Failed to ensure war state for {base.TargetHero.Name} before moving to siege of {besiegedSettlement.Name}");
						}
						else
						{
							GameVersionCompatibility.SetMoveBesiegeSettlement(partyBelongedTo, besiegedSettlement);
						}
					}
					else
					{
						GameVersionCompatibility.ConditionalDisableAi(partyBelongedTo);
						_wasInSiegeCamp = true;
					}
					return;
				}
			}
			else if (partyBelongedTo.BesiegerCamp != null || _wasInSiegeCamp)
			{
				partyBelongedTo.BesiegerCamp = null;
				_wasInSiegeCamp = false;
				LogAction($"Party {partyBelongedTo.Name} left BesiegerCamp (player is no longer in siege)");
				GameVersionCompatibility.ConditionalEnableAi(partyBelongedTo);
				LogAction($"Re-enabled AI for {partyBelongedTo.Name} after leaving siege");
			}
			if (!(CampaignTime.Now - _lastDistanceCheckTime < CampaignTime.Hours(2f)))
			{
				_lastDistanceCheckTime = CampaignTime.Now;
				position2D = partyBelongedTo.GetPosition2D();
				float num2 = (position2D).Distance(mainParty.GetPosition2D());
				if (partyBelongedTo.TargetParty == mainParty && (int)partyBelongedTo.DefaultBehavior == 14)
				{
					GameVersionCompatibility.ConditionalEnableAi(partyBelongedTo);
					GameVersionCompatibility.SetMoveEscortParty(partyBelongedTo, mainParty);
				}
				else if (num2 > 6f)
				{
					EnsureGlobalMapParty();
				}
				else
				{
					GameVersionCompatibility.ConditionalEnableAi(partyBelongedTo);
					GameVersionCompatibility.SetMoveEscortParty(partyBelongedTo, mainParty);
				}
			}
		}
		catch (Exception ex)
		{
			LogError("Error updating global following: " + ex.Message);
		}
	}

	private void SetupMissionFollowing()
	{
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		LogAction($"Setting up mission following for {base.TargetHero.Name}");
		if (base.TargetAgent == null)
		{
			LogAction($"TargetAgent is null for {base.TargetHero.Name}, attempting to create/find agent");
			if (Hero.MainHero.CurrentSettlement == null || PlayerEncounter.LocationEncounter == null)
			{
				Settlement currentSettlement = Hero.MainHero.CurrentSettlement;
				LogAction($"Not in settlement location or no LocationEncounter - CurrentSettlement: {((currentSettlement != null) ? currentSettlement.Name : null)}, LocationEncounter: {PlayerEncounter.LocationEncounter != null}");
				return;
			}
			LogAction($"In settlement {Hero.MainHero.CurrentSettlement.Name}, has LocationEncounter: {PlayerEncounter.LocationEncounter != null}");
			try
			{
				base.TargetAgent = FindAgentForHero(base.TargetHero);
				LogAction($"Initial FindAgentForHero for {base.TargetHero.Name} returned: {base.TargetAgent != null}");
				if (base.TargetAgent == null)
				{
					AddToAccompanyingCharacters();
					LogAction($"Added {base.TargetHero.Name} to accompanying characters");
					base.TargetAgent = FindAgentForHero(base.TargetHero);
					LogAction($"After AddToAccompanyingCharacters, FindAgentForHero returned: {base.TargetAgent != null}");
				}
				bool flag = IsLord(base.TargetHero);
				bool isNotable = base.TargetHero.IsNotable;
				bool isWanderer = base.TargetHero.IsWanderer;
				bool flag2 = base.TargetAgent == null && (flag || isNotable || isWanderer);
				LogAction($"Agent creation check for {base.TargetHero.Name}: TargetAgent==null={base.TargetAgent == null}, IsLord={flag}, IsNotable={isNotable}, IsWanderer={isWanderer}, ShouldSpawn={flag2}");
				if (flag2)
				{
					string arg = (flag ? "Lord" : (isNotable ? "Notable" : "Wanderer"));
					LogAction($"{arg} {base.TargetHero.Name} has no agent, creating manually");
					base.TargetAgent = SpawnLordAgentInMission();
					LogAction($"SpawnLordAgentInMission returned: {base.TargetAgent != null}");
					if (base.TargetAgent != null)
					{
						AddToAccompanyingCharacters();
						LogAction($"Added {base.TargetHero.Name} to accompanying characters after spawning agent");
					}
				}
				if (base.TargetAgent == null)
				{
					LogAction($"Agent for {base.TargetHero.Name} still not found after all attempts");
					return;
				}
				LogAction($"Successfully created/spawned agent for {base.TargetHero.Name} at position {base.TargetAgent.Position}");
			}
			catch (Exception ex)
			{
				LogError("Error setting up lord agent: " + ex.Message);
				return;
			}
		}
		else
		{
			LogAction($"TargetAgent already exists for {base.TargetHero.Name}");
		}
		Agent playerAgent = GetPlayerAgent();
		if (playerAgent == null)
		{
			LogError("Player agent not found in mission");
			return;
		}
		try
		{
			LogAction($"Configuring follow behavior for {base.TargetHero.Name}");
			CampaignAgentComponent component = base.TargetAgent.GetComponent<CampaignAgentComponent>();
			if (component != null && component.AgentNavigator != null)
			{
				DailyBehaviorGroup behaviorGroup = component.AgentNavigator.GetBehaviorGroup<DailyBehaviorGroup>();
				if (behaviorGroup != null)
				{
					FollowAgentBehavior behavior = ((AgentBehaviorGroup)behaviorGroup).GetBehavior<FollowAgentBehavior>();
					if (behavior != null)
					{
						((AgentBehaviorGroup)behaviorGroup).RemoveBehavior<FollowAgentBehavior>();
						LogAction($"Removed existing FollowAgentBehavior for {base.TargetHero.Name}");
					}
					GameVersionCompatibility.DisableConflictingBehaviors(behaviorGroup, base.TargetHero);
					FollowAgentBehavior val = ((AgentBehaviorGroup)behaviorGroup).AddBehavior<FollowAgentBehavior>();
					if (val != null)
					{
						val.SetTargetAgent(playerAgent);
						if (!((AgentBehavior)val).IsActive)
						{
							((AgentBehavior)val).IsActive = true;
							LogAction($"{base.TargetHero.Name} activated FollowAgentBehavior");
						}
						LogAction($"{base.TargetHero.Name} using standard FollowAgentBehavior (Active: {((AgentBehavior)val).IsActive})");
					}
					else
					{
						LogError($"Failed to create FollowAgentBehavior for {base.TargetHero.Name}");
						UseSimpleFollowing(playerAgent);
					}
				}
				else
				{
					LogAction($"DailyBehaviorGroup not found for {base.TargetHero.Name}, using simple following");
					UseSimpleFollowing(playerAgent);
				}
			}
			else
			{
				LogAction($"AgentNavigator not available for {base.TargetHero.Name}, using simple following");
				UseSimpleFollowing(playerAgent);
			}
			if (Hero.MainHero.CurrentSettlement != null && PlayerEncounter.LocationEncounter != null)
			{
				AddToAccompanyingCharacters();
			}
		}
		catch (Exception ex2)
		{
			LogError("Error setting up mission following: " + ex2.Message);
			try
			{
				LogAction($"Using fallback following for {base.TargetHero.Name}");
				UseSimpleFollowing(playerAgent);
			}
			catch (Exception ex3)
			{
				LogError("Fallback following also failed: " + ex3.Message);
			}
		}
	}

	private void UseSimpleFollowing(Agent playerAgent)
	{
		if (playerAgent != null && base.TargetAgent != null)
		{
			base.TargetAgent.SetLookAgent(playerAgent);
			LogAction($"{base.TargetHero.Name} using simple following (fallback)");
		}
	}

	private void ReenforceFollowBehaviorIfNeeded(Agent playerAgent)
	{
		if (base.TargetAgent == null || !base.TargetAgent.IsActive() || playerAgent == null)
		{
			return;
		}
		try
		{
			CampaignAgentComponent component = base.TargetAgent.GetComponent<CampaignAgentComponent>();
			if (((component != null) ? component.AgentNavigator : null) == null)
			{
				return;
			}
			DailyBehaviorGroup behaviorGroup = component.AgentNavigator.GetBehaviorGroup<DailyBehaviorGroup>();
			if (behaviorGroup == null)
			{
				return;
			}
			FollowAgentBehavior behavior = ((AgentBehaviorGroup)behaviorGroup).GetBehavior<FollowAgentBehavior>();
			if (behavior == null)
			{
				LogAction($"FollowAgentBehavior was removed for {base.TargetHero.Name}, re-creating");
				GameVersionCompatibility.DisableConflictingBehaviors(behaviorGroup, base.TargetHero);
				behavior = ((AgentBehaviorGroup)behaviorGroup).AddBehavior<FollowAgentBehavior>();
				if (behavior != null)
				{
					behavior.SetTargetAgent(playerAgent);
					((AgentBehavior)behavior).IsActive = true;
				}
			}
			else if (!((AgentBehavior)behavior).IsActive)
			{
				GameVersionCompatibility.DisableConflictingBehaviors(behaviorGroup, base.TargetHero);
				behavior.SetTargetAgent(playerAgent);
				((AgentBehavior)behavior).IsActive = true;
				LogAction($"Re-enforced FollowAgentBehavior for {base.TargetHero.Name} (was deactivated by game)");
			}
		}
		catch (Exception ex)
		{
			LogError("Error in ReenforceFollowBehaviorIfNeeded: " + ex.Message);
		}
	}

	public void CleanupMissionFollowing()
	{
		LogAction($"Cleaning up mission following for {base.TargetHero.Name}");
		try
		{
			if (PlayerEncounter.LocationEncounter != null)
			{
				PlayerEncounter.LocationEncounter.RemoveAccompanyingCharacter(base.TargetHero);
				LogAction($"{base.TargetHero.Name} removed from accompanying characters");
			}
			Agent val = FindAgentForHero(base.TargetHero);
			if (val != null && val.IsActive())
			{
				try
				{
					GameVersionCompatibility.StopAgentFollowing(val, base.TargetHero);
					LogAction($"Cleaned up following for {base.TargetHero.Name}");
					return;
				}
				catch (Exception ex)
				{
					LogError("Error cleaning up agent: " + ex.Message);
					return;
				}
			}
			LogAction($"No active agent found for {base.TargetHero.Name}");
		}
		catch (Exception ex2)
		{
			LogError("Error in cleanup: " + ex2.Message);
		}
	}

	private void SetupFollowing()
	{
		LogAction($"Setting up following for {base.TargetHero.Name}");
		if (IsInMission())
		{
			if (base.TargetAgent == null || !base.TargetAgent.IsActive())
			{
				base.TargetAgent = FindAgentForHero(base.TargetHero);
				LogAction($"Updated TargetAgent in SetupFollowing: {base.TargetAgent != null}");
			}
			SetupMissionFollowing();
			if (base.TargetHero.PartyBelongedTo == MobileParty.MainParty)
			{
				LogAction($"Skipping party creation for {base.TargetHero.Name} - already in player party");
			}
			else
			{
				LogAction($"Deferring party creation for {base.TargetHero.Name} until player leaves settlement");
			}
		}
		else
		{
			EnsureGlobalMapParty();
		}
	}

	private void CleanupFollowing()
	{
		if (base.TargetHero == null)
		{
			LogError("CRITICAL: TargetHero is null during CleanupFollowing! Skipping cleanup.");
			return;
		}
		if (base.TargetHero == Hero.MainHero)
		{
			LogError("CRITICAL: Attempted to cleanup following for MainHero! Skipping cleanup.");
			return;
		}
		if (MobileParty.MainParty == null)
		{
			LogError("CRITICAL: MobileParty.MainParty is null during cleanup! Skipping cleanup to prevent game corruption.");
			return;
		}
		LogAction($"Cleaning up following for {base.TargetHero.Name}");
		if (Mission.Current != null)
		{
			LogAction("Mission.Current exists, attempting to cleanup mission following");
			CleanupMissionFollowing();
		}
		else if (IsInMission())
		{
			LogAction("IsInMission() is true, cleaning up mission following");
			CleanupMissionFollowing();
		}
		else
		{
			LogAction("No mission detected (Mission.Current is null and IsInMission() is false)");
		}
		if (base.TargetHero != null && base.TargetHero.PartyBelongedTo != null)
		{
			MobileParty partyBelongedTo = base.TargetHero.PartyBelongedTo;
			if (partyBelongedTo != MobileParty.MainParty && MobileParty.MainParty != null)
			{
				LogAction($"Stopping global map following for {base.TargetHero.Name}");
				StopGlobalMapFollowing();
			}
			else if (partyBelongedTo == MobileParty.MainParty)
			{
				LogAction($"Hero {base.TargetHero.Name} is in MainParty - skipping global map cleanup");
			}
		}
	}

	public void SetNeedsMissionFollowingInit(bool needsInit)
	{
		_needsMissionFollowingInit = needsInit;
		LogAction($"Set _needsMissionFollowingInit = {needsInit} for {base.TargetHero.Name} (current action state: IsActive={base.IsActive}, IsInMission={IsInMission()})");
	}

	public bool GetNeedsMissionFollowingInit()
	{
		return _needsMissionFollowingInit;
	}

	public void ReinitializeMissionFollowing()
	{
		LogAction($"ReinitializeMissionFollowing called for {base.TargetHero.Name}, Mission.Current: {Mission.Current != null}, IsActive: {base.IsActive}");
		if (Mission.Current != null && base.IsActive)
		{
			LogAction($"Reinitializing mission following for {base.TargetHero.Name}");
			AddToAccompanyingCharacters();
			SetupMissionFollowing();
		}
		else
		{
			LogAction($"Skipping reinitialization for {base.TargetHero.Name} - no mission or not active");
		}
	}

	public void EnsureGlobalMapParty(bool forceCreate = false)
	{
		if (base.TargetHero == null)
		{
			return;
		}
		bool flag = IsPlayerRelation(base.TargetHero);
		bool flag2 = false;
		if (flag)
		{
			MobileParty mainParty = MobileParty.MainParty;
			flag2 = ((mainParty != null) ? mainParty.CurrentSettlement : null) != null;
			if (!flag2)
			{
				Hero mainHero = Hero.MainHero;
				if (((mainHero != null) ? mainHero.CurrentSettlement : null) != null)
				{
					LogAction($"EnsureGlobalMapParty: Player relation {base.TargetHero.Name} - party not in settlement, but Hero.CurrentSettlement is set - allowing party creation");
					flag2 = false;
				}
			}
		}
		else
		{
			Hero mainHero2 = Hero.MainHero;
			flag2 = ((mainHero2 != null) ? mainHero2.CurrentSettlement : null) != null;
		}
		if (!forceCreate && flag2)
		{
			LogAction($"EnsureGlobalMapParty skipped for {base.TargetHero.Name} (player in settlement, forceCreate=false, isPlayerRelation={flag})");
		}
		else if (IsInMission() && !forceCreate)
		{
			LogAction($"EnsureGlobalMapParty skipped for {base.TargetHero.Name} (in mission, forceCreate=false)");
		}
		else if (IsLord(base.TargetHero))
		{
			EnsureLordParty(forceCreate);
		}
		else
		{
			EnsureTavernCompanionParty(forceCreate);
		}
	}

	private void EnsureLordParty(bool forceCreate = false)
	{
		TextObject name = base.TargetHero.Name;
		MobileParty partyBelongedTo = base.TargetHero.PartyBelongedTo;
		LogAction(string.Format("EnsureLordParty for {0}: PartyBelongedTo={1}, forceCreate={2}", name, ((partyBelongedTo == null) ? null : ((object)partyBelongedTo.Name)?.ToString()) ?? "null", forceCreate));
		if (base.TargetHero.PartyBelongedTo == MobileParty.MainParty)
		{
			if (!forceCreate)
			{
				LogAction($"Lord {base.TargetHero.Name} is already in player party - doing nothing (forceCreate=false)");
				return;
			}
			LogAction($"Lord {base.TargetHero.Name} is in player party, but forceCreate=true - forcing separation");
		}
		MobileParty partyBelongedTo2 = base.TargetHero.PartyBelongedTo;
		if (partyBelongedTo2 != null && partyBelongedTo2 != MobileParty.MainParty)
		{
			LogAction($"Lord {base.TargetHero.Name} has existing party: {partyBelongedTo2.Name}");
			if (partyBelongedTo2.CurrentSettlement != null)
			{
				LogAction($"Conditionally disabling AI for lord {base.TargetHero.Name}'s party before leaving settlement");
				GameVersionCompatibility.ConditionalDisableAi(partyBelongedTo2);
				LogAction($"Lord {base.TargetHero.Name} party is in settlement, bringing it out");
				LeaveSettlementAction.ApplyForParty(partyBelongedTo2);
				LogAction($"Brought {base.TargetHero.Name}'s party out of settlement");
			}
			SetupGlobalMapFollowing();
		}
		else
		{
			LogAction($"Lord {base.TargetHero.Name} needs party - initiating party creation");
			partyBelongedTo2 = CreateTemporaryParty();
			if (partyBelongedTo2 != null)
			{
				_isTemporaryPartyCreated = true;
				LogAction($"Party created for lord {base.TargetHero.Name}");
				SetupGlobalMapFollowing();
			}
			else
			{
				LogError($"Failed to create temporary party for lord {base.TargetHero.Name}");
			}
		}
	}

	private void EnsureTavernCompanionParty(bool forceCreate = false)
	{
		if (base.TargetHero.PartyBelongedTo == MobileParty.MainParty)
		{
			if (!forceCreate)
			{
				return;
			}
			LogAction($"Tavern companion {base.TargetHero.Name} is in MainParty but forceCreate=true - forcing separation");
		}
		if (base.TargetHero.PartyBelongedTo != null && base.TargetHero.PartyBelongedTo != MobileParty.MainParty && base.TargetHero.PartyBelongedTo.CurrentSettlement == null)
		{
			SetupGlobalMapFollowing();
		}
		else if (base.TargetHero.PartyBelongedTo != null && base.TargetHero.PartyBelongedTo != MobileParty.MainParty && base.TargetHero.PartyBelongedTo.CurrentSettlement != null)
		{
			LogAction($"Tavern companion {base.TargetHero.Name} has party in settlement, bringing it out");
			MobileParty partyBelongedTo = base.TargetHero.PartyBelongedTo;
			LeaveSettlementAction.ApplyForParty(partyBelongedTo);
			LogAction($"Brought {base.TargetHero.Name}'s party out of settlement");
			SetupGlobalMapFollowing();
		}
		else
		{
			SetupGlobalMapFollowing();
		}
	}

	private void SetupLordParty()
	{
		if (base.TargetHero == null)
		{
			LogError("Hero not found for lord party setup");
			return;
		}
		try
		{
			MobileParty mainParty = MobileParty.MainParty;
			if (mainParty == null)
			{
				LogError("Player party not found");
				return;
			}
			if (base.TargetHero.PartyBelongedTo == mainParty)
			{
				LogAction($"{base.TargetHero.Name} is already in player party - follow_player goal is already achieved");
				return;
			}
			MobileParty val = base.TargetHero.PartyBelongedTo;
			if (val == null)
			{
				val = CreateTemporaryParty();
				if (val == null)
				{
					LogError("Failed to create temporary party for lord");
					return;
				}
				_isTemporaryPartyCreated = true;
				LogAction($"Created temporary party for lord {base.TargetHero.Name}");
			}
			if (val != mainParty)
			{
				GameVersionCompatibility.SetMoveEscortParty(val, mainParty);
			}
		}
		catch (Exception ex)
		{
			LogError("Error setting up lord party: " + ex.Message);
		}
	}

	private void AddToAccompanyingCharacters()
	{
		try
		{
			if (LocationComplex.Current == null)
			{
				LogAction($"{base.TargetHero.Name} cannot be added to accompanying characters: LocationComplex.Current is null");
				return;
			}
			if (PlayerEncounter.LocationEncounter == null)
			{
				LogAction($"{base.TargetHero.Name} cannot be added to accompanying characters: PlayerEncounter.LocationEncounter is null");
				return;
			}
			LocationEncounter locationEncounter = PlayerEncounter.LocationEncounter;
			if (base.TargetHero.IsNotable)
			{
				LocationComplex current = LocationComplex.Current;
				LocationCharacter val = ((current != null) ? current.GetLocationCharacterOfHero(base.TargetHero) : null);
				if (val != null)
				{
					LogAction($"{base.TargetHero.Name} (notable) is already part of LocationComplex - not adding to accompanying characters");
					return;
				}
				LogAction($"{base.TargetHero.Name} (notable) is NOT part of LocationComplex - will add to accompanying characters after agent creation");
			}
			LocationCharacter val2 = null;
			if (base.TargetAgent != null && base.TargetAgent.IsActive())
			{
				val2 = LocationComplex.Current.FindCharacter((IAgent)(object)base.TargetAgent);
				LogAction($"{base.TargetHero.Name} agent LocationCharacter found: {val2 != null}");
			}
			LocationComplex current2 = LocationComplex.Current;
			LocationCharacter val3 = ((current2 != null) ? current2.GetLocationCharacterOfHero(base.TargetHero) : null);
			LogAction($"{base.TargetHero.Name} hero LocationCharacter found: {val3 != null}");
			if (val3 != null)
			{
				locationEncounter.AddAccompanyingCharacter(val3, true);
				LogAction($"{base.TargetHero.Name} added to accompanying characters in settlement (existing LocationCharacter)");
			}
			else if (val2 != null)
			{
				locationEncounter.AddAccompanyingCharacter(val2, true);
				LogAction($"{base.TargetHero.Name} added to accompanying characters in settlement (by agent LocationCharacter)");
			}
			else
			{
				LogAction($"{base.TargetHero.Name} has no LocationCharacter - agent will be created manually and LocationCharacter will be added then");
			}
		}
		catch (Exception ex)
		{
			LogError("Error adding to accompanying characters: " + ex.Message + "\n" + ex.StackTrace);
		}
	}

	private void RemoveFromAccompanyingCharacters()
	{
		try
		{
			if (PlayerEncounter.LocationEncounter == null || base.TargetHero == null)
			{
				Hero targetHero = base.TargetHero;
				LogAction("Cannot remove " + (((targetHero == null) ? null : ((object)targetHero.Name)?.ToString()) ?? "null") + " from accompanying characters - LocationEncounter or TargetHero is null");
				return;
			}
			LocationComplex current = LocationComplex.Current;
			LocationCharacter val = ((current != null) ? current.GetLocationCharacterOfHero(base.TargetHero) : null);
			if (val == null)
			{
				LogAction($"{base.TargetHero.Name} has no LocationCharacter in current location");
				return;
			}
			PlayerEncounter.LocationEncounter.RemoveAccompanyingCharacter(base.TargetHero);
			LogAction($"{base.TargetHero.Name} removed from accompanying characters in settlement");
		}
		catch (Exception ex)
		{
			LogError("Error removing from accompanying characters: " + ex.Message);
		}
	}

	private void SetupGlobalMapFollowing()
	{
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Invalid comparison between Unknown and I4
		if (base.TargetHero == null)
		{
			LogError("Hero not found for global map following");
			return;
		}
		if (!base.IsActive)
		{
			LogAction($"Not setting up global map following for {base.TargetHero.Name} - action is not active");
			return;
		}
		try
		{
			MobileParty mainParty = MobileParty.MainParty;
			if (mainParty == null)
			{
				LogError("Player party not found");
				return;
			}
			bool flag = IsPlayerRelation(base.TargetHero);
			bool flag2 = false;
			if (flag)
			{
				MobileParty mainParty2 = MobileParty.MainParty;
				flag2 = ((mainParty2 != null) ? mainParty2.CurrentSettlement : null) != null;
				if (!flag2)
				{
					Hero mainHero = Hero.MainHero;
					if (((mainHero != null) ? mainHero.CurrentSettlement : null) != null)
					{
						LogAction($"SetupGlobalMapFollowing: Player relation {base.TargetHero.Name} - party not in settlement, allowing setup");
						flag2 = false;
					}
				}
			}
			else
			{
				Hero mainHero2 = Hero.MainHero;
				flag2 = ((mainHero2 != null) ? mainHero2.CurrentSettlement : null) != null;
			}
			if (flag2)
			{
				LogAction($"Player is in settlement - deferring party creation for {base.TargetHero.Name} until player leaves");
				return;
			}
			MobileParty val = base.TargetHero.PartyBelongedTo;
			bool flag3 = val == null;
			if (val == mainParty)
			{
				flag3 = true;
			}
			if (AIActionManager.Instance.IsPartyRegisteredForReturn(base.TargetHero))
			{
				LogAction($"Party of {base.TargetHero.Name} was registered for return to settlement - canceling return and setting up follow_player");
				AIActionManager.Instance.UnregisterPartyForReturn(base.TargetHero);
				if (val != null && val != MobileParty.MainParty)
				{
					GameVersionCompatibility.ConditionalEnableAi(val);
					LogAction($"Re-enabled AI for {base.TargetHero.Name}'s party after canceling return");
				}
			}
			if (flag3)
			{
				if (base.TargetHero.IsWanderer && base.TargetHero.Clan == null)
				{
					val = CreateTemporaryParty();
					if (val == null)
					{
						LogError("Failed to create temporary party");
						return;
					}
					_isTemporaryPartyCreated = true;
					LogAction($"Created temporary party for tavern companion {base.TargetHero.Name}");
				}
				else
				{
					val = CreateTemporaryParty();
					if (val == null)
					{
						LogError("Failed to create temporary party");
						return;
					}
					_isTemporaryPartyCreated = true;
					LogAction($"Created temporary party for lord {base.TargetHero.Name}");
				}
			}
			if (val == null || val == mainParty)
			{
				LogAction($"{base.TargetHero.Name} is still in player party (or null) after SetupGlobalMapFollowing attempt - cannot setup escort");
			}
			else if (val.TargetParty == mainParty && (int)val.DefaultBehavior == 14)
			{
				GameVersionCompatibility.ConditionalEnableAi(val);
				GameVersionCompatibility.SetMoveEscortParty(val, mainParty);
				LogAction($"{base.TargetHero.Name} is already escorting player - updating escort mode to refresh target");
			}
			else
			{
				GameVersionCompatibility.ConditionalEnableAi(val);
				GameVersionCompatibility.SetMoveEscortParty(val, mainParty);
				LogAction($"Set up escort mode for {base.TargetHero.Name}");
			}
		}
		catch (Exception ex)
		{
			LogError("Error setting up global map following: " + ex.Message);
		}
	}

	private void StopGlobalMapFollowing()
	{
		if (base.TargetHero == null)
		{
			return;
		}
		try
		{
			MobileParty partyBelongedTo = base.TargetHero.PartyBelongedTo;
			MobileParty mainParty = MobileParty.MainParty;
			if (partyBelongedTo == null || partyBelongedTo == mainParty)
			{
				return;
			}
			if (_isTemporaryPartyCreated)
			{
				Settlement val = SendTemporaryPartyToDestination(partyBelongedTo);
				AIActionManager.Instance.RegisterPartyForRemoval(base.TargetHero, partyBelongedTo, val);
				string arg = ((val != null) ? ((object)val.Name).ToString() : "unknown destination");
				LogAction($"Sending temporary party to {arg} for {base.TargetHero.Name}");
			}
			else if (base.TargetHero.IsNotable)
			{
				Settlement val2 = DetermineReturnSettlement(partyBelongedTo);
				string arg2 = ((val2 == null) ? null : ((object)val2.Name)?.ToString()) ?? "unknown destination";
				TextObject name = base.TargetHero.Name;
				Settlement originSettlement = _originSettlement;
				LogAction(string.Format("Notable {0} stop follow -> destination: {1} (_originSettlement={2})", name, arg2, ((originSettlement == null) ? null : ((object)originSettlement.Name)?.ToString()) ?? "null"));
				if (val2 != null)
				{
					GameVersionCompatibility.SetMoveGoToSettlement(partyBelongedTo, val2);
					GameVersionCompatibility.ConditionalDisableAi(partyBelongedTo);
					AIActionManager.Instance.RegisterPartyForRemoval(base.TargetHero, partyBelongedTo, val2);
					LogAction($"Stopped escort mode for notable {base.TargetHero.Name}, sent party back to {val2.Name}, and disabled AI to prevent direction override");
				}
				else
				{
					GameVersionCompatibility.SetMoveModeHold(partyBelongedTo);
					LogAction($"Stopped escort mode for notable {base.TargetHero.Name}, but destination not found - holding position");
				}
			}
			else
			{
				GameVersionCompatibility.SetMoveModeHold(partyBelongedTo);
				GameVersionCompatibility.ConditionalEnableAi(partyBelongedTo);
				LogAction($"Stopped escort mode and re-enabled AI for {base.TargetHero.Name}'s party (party will stop following)");
			}
		}
		catch (Exception ex)
		{
			LogError("Error stopping global map following: " + ex.Message);
		}
	}

	private void ShowFollowingStartedMessage()
	{
		DelayedTaskManager delayedTaskManager = AIInfluenceBehavior.Instance?.GetDelayedTaskManager();
		if (delayedTaskManager == null || base.TargetHero == null)
		{
			return;
		}
		string heroName = ((object)base.TargetHero.Name)?.ToString() ?? "Unknown";
		bool isInMission = IsInMission();
		delayedTaskManager.AddTask(2.0, delegate
		{
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Expected O, but got Unknown
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Expected O, but got Unknown
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Expected O, but got Unknown
			if (isInMission)
			{
				TextObject val = new TextObject("{=AIAction_FollowStarted}{HERO_NAME} is now following you", (Dictionary<string, object>)null);
				val.SetTextVariable("HERO_NAME", heroName);
				InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), ExtraColors.GreenAIInfluence));
			}
			else
			{
				TextObject val2 = new TextObject("{=AIAction_FollowStartedMap}{HERO_NAME}'s party is now following you on the map", (Dictionary<string, object>)null);
				val2.SetTextVariable("HERO_NAME", heroName);
				InformationManager.DisplayMessage(new InformationMessage(((object)val2).ToString(), ExtraColors.GreenAIInfluence));
			}
		});
	}

	private void ShowFollowingStoppedMessage()
	{
		DelayedTaskManager delayedTaskManager = AIInfluenceBehavior.Instance?.GetDelayedTaskManager();
		if (delayedTaskManager == null || base.TargetHero == null)
		{
			return;
		}
		string heroName = ((object)base.TargetHero.Name)?.ToString() ?? "Unknown";
		bool isInMission = IsInMission();
		delayedTaskManager.AddTask(2.0, delegate
		{
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected O, but got Unknown
			//IL_0068: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0077: Expected O, but got Unknown
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Expected O, but got Unknown
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003f: Expected O, but got Unknown
			if (isInMission)
			{
				TextObject val = new TextObject("{=AIAction_FollowStopped}{HERO_NAME} stopped following you", (Dictionary<string, object>)null);
				val.SetTextVariable("HERO_NAME", heroName);
				InformationManager.DisplayMessage(new InformationMessage(((object)val).ToString(), ExtraColors.RedAIInfluence));
			}
			else
			{
				TextObject val2 = new TextObject("{=AIAction_FollowStoppedMap}{HERO_NAME}'s party stopped following you", (Dictionary<string, object>)null);
				val2.SetTextVariable("HERO_NAME", heroName);
				InformationManager.DisplayMessage(new InformationMessage(((object)val2).ToString(), ExtraColors.RedAIInfluence));
			}
		});
	}

	private MobileParty CreateTemporaryParty()
	{
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected O, but got Unknown
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Expected O, but got Unknown
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		if (base.TargetHero == null)
		{
			return null;
		}
		try
		{
			if (base.TargetHero.Clan != null)
			{
				LogAction($"Attempting to create REAL Lord Party for {base.TargetHero.Name} (Clan: {base.TargetHero.Clan.Name})");
				MobileParty val = GameVersionCompatibility.CreateNewClanMobileParty(base.TargetHero, base.TargetHero.Clan);
				if (val != null)
				{
					val.IsVisible = true;
					val.IsActive = true;
					if (val.LeaderHero != base.TargetHero)
					{
						LogAction(string.Format("WARNING: Real party created, but leader is {0}. Setting leader to {1}", (val.LeaderHero != null) ? ((object)val.LeaderHero.Name).ToString() : "null", base.TargetHero.Name));
					}
					NonCombatantPartyProtector instance = NonCombatantPartyProtector.Instance;
					if (instance != null)
					{
						instance.RegisterPartyForProtection(val, base.TargetHero, "FollowPlayer");
						LogAction($"Registered party {val.Name} for non-combatant protection");
					}
					LogAction($"Created REAL party {val.Name} for {base.TargetHero.Name}");
					return val;
				}
				LogError($"Failed to create real party for {base.TargetHero.Name}, falling back to temporary party");
			}
			MobileParty mainParty = MobileParty.MainParty;
			if (mainParty == null)
			{
				return null;
			}
			Settlement currentSettlement = Hero.MainHero.CurrentSettlement;
			Vec2 position;
			if (currentSettlement != null)
			{
				position = currentSettlement.GetGatePosition();
				LogAction($"Creating party at {currentSettlement.Name} gates");
			}
			else
			{
				position = mainParty.GetPosition2D();
			}
			TextObject val2 = new TextObject("{=AIAction_TemporaryPartyName}{HERO_NAME}'s Party (Temporary)", (Dictionary<string, object>)null);
			val2.SetTextVariable("HERO_NAME", base.TargetHero.Name);
			TroopRoster memberRoster = new TroopRoster((PartyBase)null);
			TroopRoster prisonerRoster = new TroopRoster((PartyBase)null);
			MobileParty val3 = GameVersionCompatibility.CreateQuestParty(position, 0.1f, _originSettlement ?? currentSettlement, val2, Clan.PlayerClan, memberRoster, prisonerRoster, base.TargetHero);
			LogAction($"Created party as part of player clan {Clan.PlayerClan.Name}");
			val3.IsVisible = true;
			val3.IsActive = true;
			if (base.TargetHero.PartyBelongedTo != val3)
			{
				LogAction(string.Format("Moving {0} from {1} to new temporary party", base.TargetHero.Name, (base.TargetHero.PartyBelongedTo != null) ? ((object)base.TargetHero.PartyBelongedTo.Name).ToString() : "null"));
				AddHeroToPartyAction.Apply(base.TargetHero, val3, true);
				if (MobileParty.MainParty != null && MobileParty.MainParty.MemberRoster.Contains(base.TargetHero.CharacterObject))
				{
					LogAction($"DUPLICATION FIX: Removing {base.TargetHero.Name} from MainParty roster manually.");
					int troopCount = MobileParty.MainParty.MemberRoster.GetTroopCount(base.TargetHero.CharacterObject);
					if (troopCount > 0)
					{
						MobileParty.MainParty.MemberRoster.AddToCounts(base.TargetHero.CharacterObject, -troopCount, false, 0, 0, true, -1);
					}
				}
				if (val3.MemberRoster.GetTroopCount(base.TargetHero.CharacterObject) > 1)
				{
					LogAction("Fixing hero duplication in temporary party roster");
					int troopCount2 = val3.MemberRoster.GetTroopCount(base.TargetHero.CharacterObject);
					val3.MemberRoster.AddToCounts(base.TargetHero.CharacterObject, -(troopCount2 - 1), false, 0, 0, true, -1);
				}
				if (val3.MemberRoster.GetTroopCount(base.TargetHero.CharacterObject) == 0)
				{
					LogAction("Fixing missing hero in temporary party roster");
					val3.MemberRoster.AddToCounts(base.TargetHero.CharacterObject, 1, false, 0, 0, true, -1);
				}
			}
			LogAction($"Created temporary party for {base.TargetHero.Name} at gates");
			return val3;
		}
		catch (Exception ex)
		{
			LogError("Error creating temporary party: " + ex.Message);
			return null;
		}
	}

	private Settlement SendTemporaryPartyToDestination(MobileParty party)
	{
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		if (party == null || base.TargetHero == null)
		{
			return null;
		}
		try
		{
			CaptureOriginSettlementIfNeeded();
			Settlement val = DetermineReturnSettlement(party);
			if (val == null)
			{
				LogError("Could not determine destination settlement for temporary party");
				return null;
			}
			GameVersionCompatibility.SetMoveGoToSettlement(party, val);
			if (base.TargetHero.IsNotable)
			{
				if (!GameVersionCompatibility.HasShips(party))
				{
					GameVersionCompatibility.GiveTemporaryShip(party);
					string message = ((object)new TextObject("{=AIAction_TemporaryShipGranted}{HERO_NAME} received a temporary ship to return home.", (Dictionary<string, object>)null).SetTextVariable("HERO_NAME", base.TargetHero.Name)).ToString();
					LogAction(message);
				}
				GameVersionCompatibility.ConditionalDisableAi(party);
				LogAction($"{base.TargetHero.Name}'s temporary party is traveling to {val.Name} (AI disabled to prevent direction override)");
			}
			else
			{
				GameVersionCompatibility.ConditionalEnableAi(party);
				LogAction($"{base.TargetHero.Name}'s party is traveling to {val.Name}");
			}
			return val;
		}
		catch (Exception ex)
		{
			LogError("Error sending temporary party to destination: " + ex.Message);
			return null;
		}
	}

	private Settlement DetermineReturnSettlement(MobileParty party)
	{
		Settlement val = null;
		if (base.TargetHero.IsNotable)
		{
			val = base.TargetHero.HomeSettlement;
			if (val == null)
			{
				val = ((IEnumerable<Settlement>)Settlement.All).FirstOrDefault((Func<Settlement, bool>)((Settlement s) => s.Notables != null && ((List<Hero>)(object)s.Notables).Contains(base.TargetHero)));
			}
			if (val == null)
			{
				val = base.TargetHero.StayingInSettlement;
			}
			if (val == null)
			{
				val = base.TargetHero.CurrentSettlement;
			}
			if (val == null)
			{
				MobileParty partyBelongedTo = base.TargetHero.PartyBelongedTo;
				val = ((partyBelongedTo != null) ? partyBelongedTo.CurrentSettlement : null);
			}
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
					return (position2D).DistanceSquared(party.GetPosition2D());
				}).FirstOrDefault();
				if (val != null)
				{
					LogAction($"Companion {base.TargetHero.Name} from tavern will return to nearest town: {val.Name}");
					return val;
				}
			}
			LogAction($"Could not find town for companion {base.TargetHero.Name} from tavern");
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
				return (position2D).DistanceSquared(party.GetPosition2D());
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
				return (position2D).DistanceSquared(party.GetPosition2D());
			}).FirstOrDefault();
		}
		return val;
	}

	private void CaptureOriginSettlementIfNeeded()
	{
		if (base.TargetHero == null || _originSettlement != null)
		{
			return;
		}
		Settlement val = null;
		if (base.TargetHero.StayingInSettlement != null)
		{
			val = base.TargetHero.StayingInSettlement;
		}
		else if (base.TargetHero.CurrentSettlement != null)
		{
			val = base.TargetHero.CurrentSettlement;
		}
		else
		{
			MobileParty partyBelongedTo = base.TargetHero.PartyBelongedTo;
			if (((partyBelongedTo != null) ? partyBelongedTo.CurrentSettlement : null) != null)
			{
				val = base.TargetHero.PartyBelongedTo.CurrentSettlement;
			}
		}
		if (val == null && base.TargetHero.IsNotable)
		{
			val = base.TargetHero.HomeSettlement;
		}
		if (val == null)
		{
			val = base.TargetHero.HomeSettlement ?? base.TargetHero.BornSettlement;
		}
		if (val != null)
		{
			_originSettlement = val;
			LogAction($"Captured origin settlement {_originSettlement.Name} for {base.TargetHero.Name}");
		}
		else
		{
			LogAction($"Could not determine origin settlement for {base.TargetHero.Name}");
		}
	}

	private Agent SpawnLordAgentInMission()
	{
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_034f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0351: Unknown result type (might be due to invalid IL or missing references)
		//IL_035b: Expected O, but got Unknown
		//IL_03b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bd: Expected O, but got Unknown
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Expected O, but got Unknown
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0250: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		LogAction($"SpawnLordAgentInMission called for {base.TargetHero.Name}");
		try
		{
			if (Mission.Current == null)
			{
				LogError("No current mission to spawn agent in");
				return null;
			}
			LogAction("Mission.Current exists: " + Mission.Current.SceneName);
			Agent val = GetPlayerAgent();
			if (val == null)
			{
				LogAction("MainAgent is null, searching for player agent among all agents");
				foreach (Agent item in (List<Agent>)(object)Mission.Current.Agents)
				{
					if (item != null && item.IsMainAgent)
					{
						val = item;
						LogAction("Found player agent: " + item.Name);
						break;
					}
				}
			}
			Vec3 val2 = Vec3.Zero;
			Vec2 val3 = Vec2.Zero;
			if (val != null)
			{
				val2 = val.Position;
				val3 = val.GetMovementDirection();
				LogAction($"Using player agent position: {val2}");
			}
			else
			{
				if (LocationComplex.Current != null)
				{
					try
					{
						LocationCharacter locationCharacterOfHero = LocationComplex.Current.GetLocationCharacterOfHero(Hero.MainHero);
						if (locationCharacterOfHero != null)
						{
							foreach (Agent item2 in (List<Agent>)(object)Mission.Current.Agents)
							{
								if (item2 != null && item2.IsMainAgent)
								{
									val2 = item2.Position;
									val3 = item2.GetMovementDirection();
									LogAction($"Using player agent position from LocationCharacter: {val2}");
									break;
								}
							}
						}
					}
					catch (Exception ex)
					{
						LogError("Error getting LocationCharacter position: " + ex.Message);
					}
				}
				if (val2 == Vec3.Zero)
				{
					foreach (Agent item3 in (List<Agent>)(object)Mission.Current.Agents)
					{
						if (item3 != null && item3.Team != null && item3.Team.IsPlayerTeam)
						{
							val2 = item3.Position;
							val3 = item3.GetMovementDirection();
							LogAction($"Using first player team agent position: {val2}");
							break;
						}
					}
				}
				if (val2 == Vec3.Zero)
				{
					LogError("Could not determine spawn position for agent");
					return null;
				}
			}
			object agentControllerTypeAI = GameVersionCompatibility.GetAgentControllerTypeAI();
			AgentBuildData val4 = new AgentBuildData((BasicCharacterObject)(object)base.TargetHero.CharacterObject).Team(Mission.Current.PlayerTeam).InitialPosition(ref val2).InitialDirection(ref val3);
			if (agentControllerTypeAI != null)
			{
				MethodInfo method = typeof(AgentBuildData).GetMethod("Controller", BindingFlags.Instance | BindingFlags.Public);
				if (method != null)
				{
					val4 = (AgentBuildData)method.Invoke(val4, new object[1] { agentControllerTypeAI });
				}
			}
			val4 = val4.TroopOrigin((IAgentOriginBase)new SimpleAgentOrigin((BasicCharacterObject)(object)base.TargetHero.CharacterObject, -1, (Banner)null, default(UniqueTroopDescriptor)));
			LogAction($"Created AgentBuildData for {base.TargetHero.Name}, attempting to spawn agent");
			Agent val5 = Mission.Current.SpawnAgent(val4, false);
			LogAction($"Mission.SpawnAgent returned: {val5 != null}");
			if (val5 != null)
			{
				val5.AddComponent((AgentComponent)new CampaignAgentComponent(val5));
				LogAction($"Successfully spawned lord {base.TargetHero.Name} agent in mission at position {val5.Position}");
				return val5;
			}
			LogError($"Failed to spawn agent for lord {base.TargetHero.Name} - SpawnAgent returned null");
			return null;
		}
		catch (Exception ex2)
		{
			LogError("Error spawning lord agent: " + ex2.Message + "\n" + ex2.StackTrace);
			return null;
		}
	}

	private bool EnsureWarStateForSiege(Hero followerHero, Settlement besiegedSettlement)
	{
		if (followerHero == null || besiegedSettlement == null)
		{
			LogError("EnsureWarStateForSiege: followerHero or besiegedSettlement is null");
			return false;
		}
		Clan clan = followerHero.Clan;
		IFaction followerFaction = (IFaction)(object)((clan != null) ? clan.Kingdom : null);
		if (followerFaction == null)
		{
			followerFaction = (IFaction)(object)followerHero.Clan;
		}
		IFaction defenderFaction = besiegedSettlement.MapFaction;
		if (followerFaction == null || defenderFaction == null)
		{
			IFaction obj = followerFaction;
			TextObject arg = ((obj != null) ? obj.Name : null);
			IFaction obj2 = defenderFaction;
			LogAction($"EnsureWarStateForSiege: Cannot determine factions (follower: {arg}, defender: {((obj2 != null) ? obj2.Name : null)})");
			return true;
		}
		if (followerFaction == defenderFaction)
		{
			return true;
		}
		if (followerFaction.IsAtWarWith(defenderFaction))
		{
			return true;
		}
		try
		{
			LogAction($"EnsureWarStateForSiege: Declaring war: {followerFaction.Name} vs {defenderFaction.Name} (follower: {followerHero.Name}, settlement: {besiegedSettlement.Name})");
			DiplomacyPatches.WithBypass(delegate
			{
				DeclareWarAction.ApplyByDefault(followerFaction, defenderFaction);
			});
			bool flag = followerFaction.IsAtWarWith(defenderFaction);
			if (flag)
			{
				LogAction($"EnsureWarStateForSiege: Successfully declared war: {followerFaction.Name} vs {defenderFaction.Name}");
			}
			else
			{
				LogError($"EnsureWarStateForSiege: War declaration failed - {followerFaction.Name} is still not at war with {defenderFaction.Name}");
			}
			return flag;
		}
		catch (Exception ex)
		{
			LogError("EnsureWarStateForSiege: Failed to declare war: " + ex.Message + "\n" + ex.StackTrace);
			return false;
		}
	}
}
