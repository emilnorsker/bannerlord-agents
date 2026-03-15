using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bannerlord.UIExtenderEx;
using MCM.Abstractions.Base.Global;
using SandBox;
using SandBox.Missions.AgentBehaviors;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.MapEvents;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Util;

public static class GameVersionCompatibility
{
	private static readonly string[] BehaviorsToDisable = new string[7] { "PatrolAgentBehavior", "EscortAgentBehavior", "WalkingBehavior", "IdleAgentBehavior", "StandGuardBehavior", "PatrollingGuardBehavior", "ScriptBehavior" };

	public static UIExtender CreateUIExtender(string moduleName)
	{
		return UIExtender.Create(moduleName);
	}

	public static bool TryOpenInventoryScreenAsLoot(Dictionary<PartyBase, ItemRoster> lootDictionary)
	{
		return true;
	}

	public static bool TryOpenPartyScreenAsLoot(TroopRoster leftMemberRoster, TroopRoster rightMemberRoster, TextObject rosterName, int troopCount, Action onDoneAction = null)
	{
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			TroopRoster val = rightMemberRoster ?? TroopRoster.CreateDummyTroopRoster();
			TroopRoster val2 = leftMemberRoster ?? TroopRoster.CreateDummyTroopRoster();
			Type type = AppDomain.CurrentDomain.GetAssemblies().SelectMany(delegate(Assembly a)
			{
				try
				{
					return a.GetTypes();
				}
				catch
				{
					return Type.EmptyTypes;
				}
			}).FirstOrDefault((Type t) => t.Name == "PartyScreenHelper");
			if (type != null)
			{
				IEnumerable<MethodInfo> enumerable = from m in type.GetMethods(BindingFlags.Static | BindingFlags.Public)
					where m.Name == "OpenScreenAsLoot"
					select m;
				foreach (MethodInfo item in enumerable)
				{
					ParameterInfo[] parameters = item.GetParameters();
					try
					{
						if (parameters.Length == 5)
						{
							item.Invoke(null, new object[5]
							{
								val2,
								val,
								((object)rosterName) ?? ((object)new TextObject("", (Dictionary<string, object>)null)),
								troopCount,
								onDoneAction
							});
							return true;
						}
						if (parameters.Length == 4)
						{
							item.Invoke(null, new object[4]
							{
								val2,
								val,
								((object)rosterName) ?? ((object)new TextObject("", (Dictionary<string, object>)null)),
								troopCount
							});
							return true;
						}
					}
					catch (Exception ex)
					{
						AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Failed to invoke PartyScreenHelper.OpenScreenAsLoot: " + ex.Message);
					}
				}
			}
			return false;
		}
		catch (Exception ex2)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Failed to open party screen: " + ex2.Message);
			return false;
		}
	}

	public static IEnumerable<Agent> EnumerateMissionAgentsSafe(Mission mission)
	{
		if (mission == null)
		{
			return Enumerable.Empty<Agent>();
		}
		try
		{
			PropertyInfo property = typeof(Mission).GetProperty("Agents", BindingFlags.Instance | BindingFlags.Public);
			if (property != null)
			{
				object value = property.GetValue(mission);
				if (value is IEnumerable enumerable)
				{
					List<Agent> list = new List<Agent>();
					foreach (object item in enumerable)
					{
						Agent val = (Agent)((item is Agent) ? item : null);
						if (val != null)
						{
							list.Add(val);
						}
					}
					return list;
				}
			}
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] EnumerateMissionAgentsSafe failed: " + ex.Message);
		}
		return Enumerable.Empty<Agent>();
	}

	public static Vec2 GetPosition2D(this MobileParty party)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		if (party == null)
		{
			return Vec2.Invalid;
		}
		try
		{
			return party.GetPosition2D;
		}
		catch
		{
			return Vec2.Invalid;
		}
	}

	public static Vec2 GetPosition2D(this Settlement settlement)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		if (settlement == null)
		{
			return Vec2.Invalid;
		}
		try
		{
			return settlement.GetPosition2D;
		}
		catch
		{
			return Vec2.Invalid;
		}
	}

	public static Vec2 GetGatePosition(this Settlement settlement)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (settlement == null)
		{
			return Vec2.Invalid;
		}
		try
		{
			CampaignVec2 gatePosition = settlement.GatePosition;
			return (gatePosition).ToVec2();
		}
		catch
		{
			return Vec2.Invalid;
		}
	}

	public static Vec2 GetPortPosition(this Settlement settlement)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (settlement == null)
		{
			return Vec2.Invalid;
		}
		try
		{
			CampaignVec2 portPosition = settlement.PortPosition;
			return (portPosition).ToVec2();
		}
		catch
		{
			return Vec2.Invalid;
		}
	}

	public static bool IsAlliedWithFaction(IFaction faction1, IFaction faction2)
	{
		if (faction1 == null || faction2 == null || faction1 == faction2)
		{
			return false;
		}
		Kingdom val = (Kingdom)(object)((faction1 is Kingdom) ? faction1 : null);
		if (val != null)
		{
			Kingdom val2 = (Kingdom)(object)((faction2 is Kingdom) ? faction2 : null);
			if (val2 != null)
			{
				try
				{
					Campaign current = Campaign.Current;
					IAllianceCampaignBehavior val3 = ((current != null) ? current.GetCampaignBehavior<IAllianceCampaignBehavior>() : null);
					return val3 != null && val3.IsAllyWithKingdom(val, val2);
				}
				catch
				{
					return false;
				}
			}
		}
		return false;
	}

	public static void DeclareAlliance(IFaction faction1, IFaction faction2)
	{
		if (faction1 == null || faction2 == null || faction1 == faction2)
		{
			return;
		}
		Kingdom val = (Kingdom)(object)((faction1 is Kingdom) ? faction1 : null);
		if (val == null)
		{
			return;
		}
		Kingdom val2 = (Kingdom)(object)((faction2 is Kingdom) ? faction2 : null);
		if (val2 == null)
		{
			return;
		}
		try
		{
			Campaign current = Campaign.Current;
			IAllianceCampaignBehavior val3 = ((current != null) ? current.GetCampaignBehavior<IAllianceCampaignBehavior>() : null);
			if (val3 != null)
			{
				val3.StartAlliance(val, val2);
			}
		}
		catch (Exception ex)
		{
			Debug.Print("[AIInfluence] Failed to start alliance: " + ex.Message, 0, (DebugColor)12, 17592186044416uL);
		}
	}

	public static void EndAlliance(Kingdom kingdom1, Kingdom kingdom2)
	{
		if (kingdom1 == null || kingdom2 == null || kingdom1 == kingdom2)
		{
			return;
		}
		try
		{
			Campaign current = Campaign.Current;
			IAllianceCampaignBehavior val = ((current != null) ? current.GetCampaignBehavior<IAllianceCampaignBehavior>() : null);
			if (val != null)
			{
				val.EndAlliance(kingdom1, kingdom2);
			}
		}
		catch (Exception ex)
		{
			Debug.Print("[AIInfluence] Failed to end alliance: " + ex.Message, 0, (DebugColor)12, 17592186044416uL);
		}
	}

	public static IEnumerable<Hero> GetLords(this Clan clan)
	{
		if (clan == null)
		{
			return Enumerable.Empty<Hero>();
		}
		try
		{
			IEnumerable<Hero> aliveLords = (IEnumerable<Hero>)clan.AliveLords;
			return aliveLords ?? Enumerable.Empty<Hero>();
		}
		catch
		{
			return Enumerable.Empty<Hero>();
		}
	}

	public static IEnumerable<Kingdom> GetEnemyKingdoms(Kingdom kingdom)
	{
		if (kingdom == null)
		{
			return Enumerable.Empty<Kingdom>();
		}
		try
		{
			return (from k in ((IEnumerable)kingdom.FactionsAtWarWith)?.OfType<Kingdom>()
				where !k.IsEliminated
				select k) ?? Enumerable.Empty<Kingdom>();
		}
		catch
		{
			return Enumerable.Empty<Kingdom>();
		}
	}

	public static IEnumerable<IFaction> GetEnemyFactions(IFaction faction)
	{
		if (faction == null)
		{
			return Enumerable.Empty<IFaction>();
		}
		try
		{
			return ((IEnumerable<IFaction>)faction.FactionsAtWarWith)?.Where((IFaction f) => f != null && !f.IsEliminated) ?? Enumerable.Empty<IFaction>();
		}
		catch
		{
			return Enumerable.Empty<IFaction>();
		}
	}

	public static float GetDistance(MobileParty fromParty, Settlement toSettlement)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		if (fromParty == null || toSettlement == null)
		{
			return float.MaxValue;
		}
		try
		{
			CampaignVec2 position = fromParty.Position;
			Vec2 val = (position).ToVec2();
			return (val).Distance(toSettlement.GetPosition2D);
		}
		catch
		{
			return float.MaxValue;
		}
	}

	public static float GetDistance(MobileParty fromParty, MobileParty toParty)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		if (fromParty == null || toParty == null)
		{
			return float.MaxValue;
		}
		try
		{
			CampaignVec2 position = fromParty.Position;
			Vec2 val = (position).ToVec2();
			position = toParty.Position;
			return (val).Distance((position).ToVec2());
		}
		catch
		{
			return float.MaxValue;
		}
	}

	public static float GetDistance(Settlement fromSettlement, Settlement toSettlement)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		if (fromSettlement == null || toSettlement == null)
		{
			return float.MaxValue;
		}
		try
		{
			Vec2 getPosition2D = fromSettlement.GetPosition2D;
			return (getPosition2D).Distance(toSettlement.GetPosition2D);
		}
		catch
		{
			return float.MaxValue;
		}
	}

	public static EquipmentIndex GetWieldedItemIndex(this Agent agent, HandIndex handIndex)
	{
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Invalid comparison between Unknown and I4
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Invalid comparison between Unknown and I4
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		if (agent == null)
		{
			return (EquipmentIndex)(-1);
		}
		try
		{
			if ((int)handIndex == 0)
			{
				return agent.GetPrimaryWieldedItemIndex();
			}
			if ((int)handIndex == 1)
			{
				return agent.GetOffhandWieldedItemIndex();
			}
		}
		catch
		{
			return (EquipmentIndex)(-1);
		}
		return (EquipmentIndex)(-1);
	}

	public static string GetBuildingTypeName(object building)
	{
		if (building == null)
		{
			return null;
		}
		try
		{
			PropertyInfo property = building.GetType().GetProperty("BuildingType", BindingFlags.Instance | BindingFlags.Public);
			if (property == null)
			{
				return null;
			}
			object value = property.GetValue(building);
			return (value?.GetType().GetProperty("Name", BindingFlags.Instance | BindingFlags.Public))?.GetValue(value)?.ToString();
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] Failed to get BuildingType name: " + ex.Message);
			return null;
		}
	}

	public static int GetPartyTotalTroopCount(MobileParty party)
	{
		int? obj;
		if (party == null)
		{
			obj = null;
		}
		else
		{
			TroopRoster memberRoster = party.MemberRoster;
			obj = ((memberRoster != null) ? new int?(memberRoster.TotalManCount) : ((int?)null));
		}
		int? num = obj;
		return num.GetValueOrDefault();
	}

	public static int GetTotalTroopCount(IEnumerable<PartyBase> parties)
	{
		return parties?.Where((PartyBase p) => ((p != null) ? p.MobileParty : null) != null).Sum((PartyBase p) => GetPartyTotalTroopCount(p.MobileParty)) ?? 0;
	}

	public static int GetTotalTroopCount(IEnumerable<MapEventParty> mapEventParties)
	{
		return mapEventParties?.Where(delegate(MapEventParty p)
		{
			object obj;
			if (p == null)
			{
				obj = null;
			}
			else
			{
				PartyBase party = p.Party;
				obj = ((party != null) ? party.MobileParty : null);
			}
			return obj != null;
		}).Sum((MapEventParty p) => GetPartyTotalTroopCount(p.Party.MobileParty)) ?? 0;
	}

	public static void SetMoveEscortParty(MobileParty partyWithAi, MobileParty partyToEscort)
	{
		if (partyWithAi == null || partyToEscort == null)
		{
			return;
		}
		try
		{
			partyWithAi.SetMoveEscortParty(partyToEscort, (NavigationType)3, false);
			MobilePartyAi ai = partyWithAi.Ai;
			if (ai != null)
			{
				ai.SetDoNotMakeNewDecisions(true);
			}
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] SetMoveEscortParty failed: " + ex.Message);
		}
	}

	public static void ForceAiUpdate(MobileParty party)
	{
		if (((party != null) ? party.Ai : null) == null)
		{
			return;
		}
		try
		{
			Type typeFromHandle = typeof(MobilePartyAi);
			typeFromHandle.GetMethod("ForceDefaultBehaviorUpdate", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)?.Invoke(party.Ai, null);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] ForceAiUpdate failed: " + ex.Message);
		}
	}

	public static void SetMoveModeHold(MobileParty party)
	{
		if (party != null)
		{
			party.SetMoveModeHold();
		}
	}

	public static void EnterSettlementForFollowingHero(Hero hero, Settlement settlement)
	{
		if (hero == null || settlement == null)
		{
			return;
		}
		try
		{
			if (hero.IsNotable)
			{
				hero.StayingInSettlement = settlement;
				if (!((List<Hero>)(object)settlement.Notables).Contains(hero))
				{
					((List<Hero>)(object)settlement.Notables).Add(hero);
					AIInfluenceBehavior.Instance?.LogMessage($"[EnterSettlement] Temporarily added {hero.Name} (notable) to {settlement.Name}.Notables");
				}
				else
				{
					AIInfluenceBehavior.Instance?.LogMessage($"[EnterSettlement] {hero.Name} (notable) already in {settlement.Name}.Notables");
				}
			}
			MobileParty partyBelongedTo = hero.PartyBelongedTo;
			if (partyBelongedTo != null && partyBelongedTo != MobileParty.MainParty)
			{
				MobilePartyAi ai = partyBelongedTo.Ai;
				if (ai != null)
				{
					ai.SetDoNotMakeNewDecisions(true);
				}
				MobilePartyAi ai2 = partyBelongedTo.Ai;
				if (ai2 != null)
				{
					ai2.DisableAi();
				}
				if (partyBelongedTo.CurrentSettlement != settlement)
				{
					EnterSettlementAction.ApplyForParty(partyBelongedTo, settlement);
				}
			}
			EnterSettlementAction.ApplyForCharacterOnly(hero, settlement);
			if (hero.IsNotable)
			{
				AIInfluenceBehavior.Instance?.LogMessage($"[EnterSettlement] {hero.Name} (notable) added to {settlement.Name}.Notables - LocationCharacter will be created on mission start");
			}
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] EnterSettlementForFollowingHero failed: " + ex.Message);
		}
	}

	public static void RestoreAiAfterLeavingSettlement(MobileParty party)
	{
		if (party == null)
		{
			return;
		}
		try
		{
			MobileParty mainParty = MobileParty.MainParty;
			if (mainParty != null)
			{
				MobilePartyAi ai = party.Ai;
				if (ai != null)
				{
					ai.EnableAi();
				}
				SetMoveEscortParty(party, mainParty);
			}
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] RestoreAiAfterLeavingSettlement failed: " + ex.Message);
		}
	}

	public static void DisableConflictingBehaviors(DailyBehaviorGroup behaviorGroup, Hero hero)
	{
		if (behaviorGroup == null || hero == null)
		{
			return;
		}
		try
		{
			foreach (AgentBehavior item in ((AgentBehaviorGroup)behaviorGroup).Behaviors.ToList())
			{
				if (item != null && !(((object)item).GetType().Name == "FollowAgentBehavior") && BehaviorsToDisable.Contains(((object)item).GetType().Name) && item.IsActive)
				{
					item.IsActive = false;
				}
			}
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] DisableConflictingBehaviors failed: " + ex.Message);
		}
	}

	public static void RestoreDisabledBehaviors(DailyBehaviorGroup behaviorGroup, Hero hero)
	{
		if (behaviorGroup == null || hero == null)
		{
			return;
		}
		try
		{
			foreach (AgentBehavior item in ((AgentBehaviorGroup)behaviorGroup).Behaviors.ToList())
			{
				if (item != null && !(((object)item).GetType().Name == "FollowAgentBehavior") && BehaviorsToDisable.Contains(((object)item).GetType().Name) && !item.IsActive)
				{
					item.IsActive = true;
				}
			}
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] RestoreDisabledBehaviors failed: " + ex.Message);
		}
	}

	public static void StopAgentFollowing(Agent agent, Hero hero)
	{
		if (agent == null || hero == null)
		{
			return;
		}
		try
		{
			CampaignAgentComponent component = agent.GetComponent<CampaignAgentComponent>();
			if (((component != null) ? component.AgentNavigator : null) != null)
			{
				DailyBehaviorGroup behaviorGroup = component.AgentNavigator.GetBehaviorGroup<DailyBehaviorGroup>();
				FollowAgentBehavior val = ((behaviorGroup != null) ? ((AgentBehaviorGroup)behaviorGroup).GetBehavior<FollowAgentBehavior>() : null);
				if (val != null)
				{
					((AgentBehavior)val).IsActive = false;
					((AgentBehaviorGroup)behaviorGroup).RemoveBehavior<FollowAgentBehavior>();
					RestoreDisabledBehaviors(behaviorGroup, hero);
				}
				agent.SetLookAgent((Agent)null);
			}
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] StopAgentFollowing failed: " + ex.Message);
		}
	}

	public static void ConditionalDisableAi(MobileParty party)
	{
		if (party == null)
		{
			return;
		}
		try
		{
			MobilePartyAi ai = party.Ai;
			if (ai != null)
			{
				ai.SetDoNotMakeNewDecisions(true);
			}
			MobilePartyAi ai2 = party.Ai;
			if (ai2 != null)
			{
				ai2.DisableAi();
			}
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] ConditionalDisableAi failed: " + ex.Message);
		}
	}

	public static void ConditionalEnableAi(MobileParty party)
	{
		if (party == null)
		{
			return;
		}
		try
		{
			MobilePartyAi ai = party.Ai;
			if (ai != null)
			{
				ai.SetDoNotMakeNewDecisions(false);
			}
			MobilePartyAi ai2 = party.Ai;
			if (ai2 != null)
			{
				ai2.EnableAi();
			}
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] ConditionalEnableAi failed: " + ex.Message);
		}
	}

	public static object GetAgentControllerTypeAI()
	{
		try
		{
			Type type = Type.GetType("TaleWorlds.MountAndBlade.AgentControllerType, TaleWorlds.MountAndBlade");
			if (type != null && type.IsEnum)
			{
				return Enum.Parse(type, "AI");
			}
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] GetAgentControllerTypeAI failed: " + ex.Message);
		}
		return null;
	}

	public static void SetMoveGoToSettlement(MobileParty party, Settlement settlement)
	{
		if (party == null || settlement == null)
		{
			return;
		}
		try
		{
			party.SetMoveGoToSettlement(settlement, (NavigationType)3, false);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] SetMoveGoToSettlement failed: " + ex.Message);
		}
	}

	public static void SetMoveBesiegeSettlement(MobileParty party, Settlement settlement)
	{
		if (party == null || settlement == null)
		{
			return;
		}
		try
		{
			party.SetMoveBesiegeSettlement(settlement, (NavigationType)3);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] SetMoveBesiegeSettlement failed: " + ex.Message);
		}
	}

	public static void SetMoveRaidSettlement(MobileParty party, Settlement settlement)
	{
		if (party == null || settlement == null)
		{
			return;
		}
		try
		{
			party.SetMoveRaidSettlement(settlement, (NavigationType)3);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] SetMoveRaidSettlement failed: " + ex.Message);
		}
	}

	public static void SetMoveEngageParty(MobileParty party, MobileParty targetParty)
	{
		if (party == null || targetParty == null)
		{
			return;
		}
		try
		{
			party.SetMoveEngageParty(targetParty, (NavigationType)3);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] SetMoveEngageParty failed: " + ex.Message);
		}
	}

	public static Settlement GetPartyTargetSettlement(MobileParty party)
	{
		if (party == null)
		{
			return null;
		}
		try
		{
			return party.TargetSettlement;
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] GetPartyTargetSettlement failed: " + ex.Message);
			return null;
		}
	}

	public static MobileParty CreateQuestParty(Vec2 position, float spawnRadius, Settlement homeSettlement, TextObject name, Clan clan, TroopRoster memberRoster, TroopRoster prisonerRoster, Hero owner, string partyStringId = "")
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Expected O, but got Unknown
		//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ec: Expected O, but got Unknown
		try
		{
			bool flag = GlobalSettings<ModSettings>.Instance?.DebugQuestScenarioVerboseLogging ?? false;
			Type type = Type.GetType("TaleWorlds.CampaignSystem.Party.PartyComponents.CustomPartyComponent, TaleWorlds.CampaignSystem");
			if (type == null)
			{
				if (flag)
				{
					AIInfluenceBehavior.Instance?.LogMessage("[QuestDebugVerbose] CreateQuestParty: CustomPartyComponent type not found");
				}
				return null;
			}
			Type type2 = Type.GetType("TaleWorlds.CampaignSystem.CampaignVec2, TaleWorlds.CampaignSystem");
			if (type2 == null)
			{
				if (flag)
				{
					AIInfluenceBehavior.Instance?.LogMessage("[QuestDebugVerbose] CreateQuestParty: CampaignVec2 type not found");
				}
				return null;
			}
			ConstructorInfo constructor = type2.GetConstructor(new Type[2]
			{
				typeof(Vec2),
				typeof(bool)
			});
			if (constructor == null)
			{
				if (flag)
				{
					AIInfluenceBehavior.Instance?.LogMessage("[QuestDebugVerbose] CreateQuestParty: CampaignVec2(Vec2,bool) ctor not found");
				}
				return null;
			}
			object obj = constructor.Invoke(new object[2] { position, true });
			MethodInfo method = type.GetMethod("CreateQuestParty", BindingFlags.Static | BindingFlags.Public, null, new Type[12]
			{
				type2,
				typeof(float),
				typeof(Settlement),
				typeof(TextObject),
				typeof(Clan),
				typeof(TroopRoster),
				typeof(TroopRoster),
				typeof(Hero),
				typeof(string),
				typeof(string),
				typeof(float),
				typeof(bool)
			}, null);
			if (method != null)
			{
				MobileParty mobileParty = (MobileParty)method.Invoke(null, new object[12]
				{
					obj, spawnRadius, homeSettlement, name, clan, memberRoster, prisonerRoster, owner, partyStringId ?? "", "",
					0f, false
				});
				if (flag)
				{
					AIInfluenceBehavior.Instance?.LogMessage($"[QuestDebugVerbose] CreateQuestParty: invoked CreateQuestParty => '{((MBObjectBase)mobileParty)?.StringId ?? "null"}'");
				}
				return mobileParty;
			}
			method = type.GetMethod("CreateCustomPartyWithTroopRoster", BindingFlags.Static | BindingFlags.Public, null, new Type[12]
			{
				type2,
				typeof(float),
				typeof(Settlement),
				typeof(TextObject),
				typeof(Clan),
				typeof(TroopRoster),
				typeof(TroopRoster),
				typeof(Hero),
				typeof(string),
				typeof(string),
				typeof(float),
				typeof(bool)
			}, null);
			if (method != null)
			{
				MobileParty mobileParty2 = (MobileParty)method.Invoke(null, new object[12]
				{
					obj, spawnRadius, homeSettlement, name, clan, memberRoster, prisonerRoster, owner, "", "",
					0f, false
				});
				if (flag)
				{
					if (!string.IsNullOrEmpty(partyStringId))
					{
						AIInfluenceBehavior.Instance?.LogMessage($"[QuestDebugVerbose] CreateQuestParty: CreateCustomPartyWithTroopRoster does not accept explicit party string id in this build; ignored requested id '{partyStringId}'");
					}
					AIInfluenceBehavior.Instance?.LogMessage($"[QuestDebugVerbose] CreateQuestParty: invoked CreateCustomPartyWithTroopRoster => '{((MBObjectBase)mobileParty2)?.StringId ?? "null"}'");
				}
				return mobileParty2;
			}
			if (flag)
			{
				AIInfluenceBehavior.Instance?.LogMessage("[QuestDebugVerbose] CreateQuestParty: no matching factory method found");
			}
			return null;
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] CreateQuestParty failed: " + ex.Message + "\n" + ex.StackTrace);
			return null;
		}
	}

	public static MobileParty CreateNewClanMobileParty(Hero hero, Clan clan)
	{
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Unknown result type (might be due to invalid IL or missing references)
		//IL_0486: Unknown result type (might be due to invalid IL or missing references)
		//IL_048d: Expected O, but got Unknown
		//IL_0509: Unknown result type (might be due to invalid IL or missing references)
		//IL_050f: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bc: Unknown result type (might be due to invalid IL or missing references)
		if (hero == null || clan == null)
		{
			return null;
		}
		try
		{
			float num = 0f;
			Settlement val = null;
			bool flag = false;
			MobileParty partyBelongedTo = hero.PartyBelongedTo;
			CampaignVec2 val2;
			if (hero.CurrentSettlement != null)
			{
				val = hero.CurrentSettlement;
				val2 = val.GatePosition;
				num = 0f;
				if (partyBelongedTo != null && partyBelongedTo.IsMainParty)
				{
					flag = true;
				}
			}
			else if (partyBelongedTo != null && partyBelongedTo.IsMainParty)
			{
				flag = true;
				val2 = MobileParty.MainParty.Position;
				num = Campaign.Current.Models.EncounterModel.GetEncounterJoiningRadius * 2f;
			}
			else if (partyBelongedTo != null)
			{
				CampaignVec2 position = partyBelongedTo.Position;
				Type type = Type.GetType("TaleWorlds.CampaignSystem.NavigationHelper, TaleWorlds.CampaignSystem");
				if (type != null)
				{
					MethodInfo method = type.GetMethod("IsPositionValidForNavigationType", BindingFlags.Static | BindingFlags.Public, null, new Type[2]
					{
						typeof(CampaignVec2),
						typeof(NavigationType)
					}, null);
					if (method != null)
					{
						NavigationType val3 = (NavigationType)1;
						if ((bool)method.Invoke(null, new object[2] { position, val3 }))
						{
							val2 = position;
							num = Campaign.Current.Models.EncounterModel.GetEncounterJoiningRadius * 2f;
						}
						else
						{
							val2 = GetBestSettlementPosition(hero);
							num = Campaign.Current.Models.EncounterModel.GetEncounterJoiningRadius * 2f;
						}
					}
					else
					{
						val2 = position;
						num = Campaign.Current.Models.EncounterModel.GetEncounterJoiningRadius * 2f;
					}
				}
				else
				{
					val2 = position;
					num = Campaign.Current.Models.EncounterModel.GetEncounterJoiningRadius * 2f;
				}
			}
			else if (MobileParty.MainParty != null)
			{
				val2 = MobileParty.MainParty.Position;
				num = Campaign.Current.Models.EncounterModel.GetEncounterJoiningRadius * 2f;
			}
			else
			{
				val2 = GetBestSettlementPosition(hero);
				num = Campaign.Current.Models.EncounterModel.GetEncounterJoiningRadius * 2f;
			}
			if (flag)
			{
				PartyBase.MainParty.MemberRoster.RemoveTroop(hero.CharacterObject, 1, default(UniqueTroopDescriptor), 0);
				AIInfluenceBehavior.Instance?.LogMessage($"[CreateNewClanMobileParty] Removed {hero.Name} from MainParty before creating new party");
				if (PartyBase.MainParty.MemberRoster.Contains(hero.CharacterObject))
				{
					int troopCount = PartyBase.MainParty.MemberRoster.GetTroopCount(hero.CharacterObject);
					if (troopCount > 0)
					{
						PartyBase.MainParty.MemberRoster.RemoveTroop(hero.CharacterObject, troopCount, default(UniqueTroopDescriptor), 0);
						AIInfluenceBehavior.Instance?.LogMessage($"[CreateNewClanMobileParty] Force-removed {troopCount} instances of {hero.Name} from MainParty");
					}
				}
			}
			else if (partyBelongedTo != null && !partyBelongedTo.IsMainParty)
			{
				partyBelongedTo.AddElementToMemberRoster(hero.CharacterObject, -1, false);
				AIInfluenceBehavior.Instance?.LogMessage($"[CreateNewClanMobileParty] Removed {hero.Name} from party {partyBelongedTo.Name} before creating new party");
			}
			Type type2 = Type.GetType("TaleWorlds.CampaignSystem.Party.PartyComponents.LordPartyComponent, TaleWorlds.CampaignSystem");
			if (type2 == null)
			{
				AIInfluenceBehavior.Instance?.LogMessage("[ERROR] LordPartyComponent type not found");
				return null;
			}
			MethodInfo method2 = type2.GetMethod("CreateLordParty", BindingFlags.Static | BindingFlags.Public, null, new Type[6]
			{
				typeof(string),
				typeof(Hero),
				typeof(CampaignVec2),
				typeof(float),
				typeof(Settlement),
				typeof(Hero)
			}, null);
			if (method2 == null)
			{
				AIInfluenceBehavior.Instance?.LogMessage("[ERROR] CreateLordParty method not found");
				return null;
			}
			string stringId = ((MBObjectBase)hero.CharacterObject).StringId;
			MobileParty val4 = (MobileParty)method2.Invoke(null, new object[6] { stringId, hero, val2, num, val, hero });
			if (val4 == null)
			{
				AIInfluenceBehavior.Instance?.LogMessage("[ERROR] CreateLordParty returned null");
				return null;
			}
			if (PartyBase.MainParty.MemberRoster.Contains(hero.CharacterObject))
			{
				int troopCount2 = PartyBase.MainParty.MemberRoster.GetTroopCount(hero.CharacterObject);
				if (troopCount2 > 0)
				{
					PartyBase.MainParty.MemberRoster.RemoveTroop(hero.CharacterObject, troopCount2, default(UniqueTroopDescriptor), 0);
					AIInfluenceBehavior.Instance?.LogMessage($"[CreateNewClanMobileParty] WARNING: Removed {troopCount2} duplicate instance(s) of {hero.Name} from MainParty after party creation");
				}
			}
			if (hero.PartyBelongedTo != val4)
			{
				AIInfluenceBehavior instance = AIInfluenceBehavior.Instance;
				if (instance != null)
				{
					TextObject name = hero.Name;
					MobileParty partyBelongedTo2 = hero.PartyBelongedTo;
					instance.LogMessage(string.Format("[CreateNewClanMobileParty] WARNING: {0} is not in the newly created party. PartyBelongedTo: {1}", name, ((partyBelongedTo2 == null) ? null : ((object)partyBelongedTo2.Name)?.ToString()) ?? "null"));
				}
			}
			AIInfluenceBehavior.Instance?.LogMessage($"[CreateNewClanMobileParty] Created party {val4.Name} for {hero.Name} at position {val2}");
			return val4;
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] CreateNewClanMobileParty failed: " + ex.Message + "\n" + ex.StackTrace);
			return null;
		}
	}

	private static CampaignVec2 GetBestSettlementPosition(Hero hero)
	{
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Type type = Type.GetType("TaleWorlds.CampaignSystem.SettlementHelper, TaleWorlds.CampaignSystem");
			if (type != null)
			{
				MethodInfo method = type.GetMethod("GetBestSettlementToSpawnAround", BindingFlags.Static | BindingFlags.Public, null, new Type[1] { typeof(Hero) }, null);
				if (method != null)
				{
					Settlement val = (Settlement)method.Invoke(null, new object[1] { hero });
					if (val != null)
					{
						return val.GatePosition;
					}
				}
			}
			Settlement val2 = hero.HomeSettlement ?? hero.BornSettlement;
			if (val2 != null)
			{
				return val2.GatePosition;
			}
			MobileParty mainParty = MobileParty.MainParty;
			if (mainParty != null)
			{
				CampaignVec2 position = mainParty.Position;
				Vec2 playerVec2 = (position).ToVec2();
				Settlement val3 = ((IEnumerable<Settlement>)Settlement.All).Where((Settlement s) => s.IsTown || s.IsCastle).OrderBy(delegate(Settlement s)
				{
					//IL_0002: Unknown result type (might be due to invalid IL or missing references)
					//IL_0007: Unknown result type (might be due to invalid IL or missing references)
					//IL_000b: Unknown result type (might be due to invalid IL or missing references)
					Vec2 position2D = s.GetPosition2D();
					return (position2D).DistanceSquared(playerVec2);
				}).FirstOrDefault();
				if (val3 != null)
				{
					return val3.GatePosition;
				}
			}
			if (mainParty != null)
			{
				return mainParty.Position;
			}
			return CampaignVec2.Invalid;
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] GetBestSettlementPosition failed: " + ex.Message);
			return CampaignVec2.Invalid;
		}
	}

	public static void RemoveParty(this MobileParty party)
	{
		if (party == null)
		{
			return;
		}
		try
		{
			RemoveShips(party);
			DestroyPartyAction.Apply((PartyBase)null, party);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage($"[ERROR] Failed to remove party {((party != null) ? party.Name : null)}: {ex.Message}");
		}
	}

	public static bool HasShips(MobileParty party)
	{
		if (party == null)
		{
			return false;
		}
		try
		{
			PropertyInfo property = ((object)party).GetType().GetProperty("Ships", BindingFlags.Instance | BindingFlags.Public);
			if (property != null)
			{
				object value = property.GetValue(party);
				if (value == null)
				{
					return false;
				}
				PropertyInfo property2 = value.GetType().GetProperty("Count", BindingFlags.Instance | BindingFlags.Public);
				if (property2 != null)
				{
					int num = (int)property2.GetValue(value);
					return num > 0;
				}
			}
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] HasShips check failed: " + ex.Message);
		}
		return false;
	}

	public static void RemoveShips(MobileParty party)
	{
		if (party == null)
		{
			return;
		}
		try
		{
			PropertyInfo property = ((object)party).GetType().GetProperty("Ships", BindingFlags.Instance | BindingFlags.Public);
			if (property == null)
			{
				return;
			}
			object value = property.GetValue(party);
			if (value == null)
			{
				return;
			}
			PropertyInfo property2 = value.GetType().GetProperty("Count", BindingFlags.Instance | BindingFlags.Public);
			if (property2 == null || (int)property2.GetValue(value) == 0)
			{
				return;
			}
			Type type = Type.GetType("TaleWorlds.CampaignSystem.Naval.Ship, TaleWorlds.CampaignSystem");
			if (type == null)
			{
				type = Type.GetType("NavalDLC.Ship, NavalDLC");
			}
			if (type == null)
			{
				return;
			}
			PropertyInfo property3 = type.GetProperty("Owner");
			if (property3 == null)
			{
				return;
			}
			List<object> list = new List<object>();
			foreach (object item in (IEnumerable)value)
			{
				list.Add(item);
			}
			foreach (object item2 in list)
			{
				property3.SetValue(item2, null);
			}
			AIInfluenceBehavior.Instance?.LogMessage($"[RemoveShips] Removed {list.Count} ship(s) from {party.Name} before destruction");
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] RemoveShips failed: " + ex.Message);
		}
	}

	public static void GiveTemporaryShip(MobileParty party)
	{
		if (party == null)
		{
			return;
		}
		try
		{
			Type type = Type.GetType("TaleWorlds.Core.ShipHull, TaleWorlds.Core");
			Type type2 = Type.GetType("TaleWorlds.CampaignSystem.Naval.Ship, TaleWorlds.CampaignSystem");
			if (type2 == null)
			{
				type2 = Type.GetType("NavalDLC.Ship, NavalDLC");
			}
			if (type == null || type2 == null)
			{
				AIInfluenceBehavior.Instance?.LogMessage("[ERROR] GiveTemporaryShip failed: Ship or ShipHull type not found");
				return;
			}
			MBObjectManager instance = MBObjectManager.Instance;
			MethodInfo methodInfo = ((object)instance).GetType().GetMethod("GetObjectTypeList").MakeGenericMethod(type);
			IEnumerable enumerable = (IEnumerable)methodInfo.Invoke(instance, null);
			object obj = null;
			foreach (object item in enumerable)
			{
				if (obj == null)
				{
					obj = item;
				}
				PropertyInfo property = type.GetProperty("Name");
				if (property != null)
				{
					string text = property.GetValue(item)?.ToString();
					if (text != null && (text.Contains("Transport") || text.Contains("Cog")))
					{
						obj = item;
						break;
					}
				}
			}
			if (obj == null)
			{
				AIInfluenceBehavior.Instance?.LogMessage("[ERROR] GiveTemporaryShip failed: No ShipHull found");
				return;
			}
			ConstructorInfo constructor = type2.GetConstructor(new Type[1] { type });
			if (constructor == null)
			{
				AIInfluenceBehavior.Instance?.LogMessage("[ERROR] GiveTemporaryShip failed: Ship constructor not found");
				return;
			}
			object obj2 = constructor.Invoke(new object[1] { obj });
			PropertyInfo property2 = type2.GetProperty("Owner");
			if (property2 != null)
			{
				property2.SetValue(obj2, party.Party);
				AIInfluenceBehavior.Instance?.LogMessage($"[GiveTemporaryShip] Gave ship to {party.Name}");
			}
			else
			{
				AIInfluenceBehavior.Instance?.LogMessage("[ERROR] GiveTemporaryShip failed: Owner property not found");
			}
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] GiveTemporaryShip failed: " + ex.Message);
		}
	}
}
