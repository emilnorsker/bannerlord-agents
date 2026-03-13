using System;
using System.Collections.Generic;
using AIInfluence.Util;
using Helpers;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.ComponentInterfaces;
using TaleWorlds.CampaignSystem.Conversation;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence;

public static class MarriageSystem
{
	private static readonly AIInfluenceBehavior _behavior = AIInfluenceBehavior.Instance;

	public static void ProposeMarriage(Hero npc, Hero player, NPCContext context)
	{
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Expected O, but got Unknown
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Invalid comparison between Unknown and I4
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
		//IL_026a: Expected O, but got Unknown
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Expected O, but got Unknown
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Invalid comparison between Unknown and I4
		string text = ((object)npc.Name)?.ToString() ?? "Unknown";
		_behavior.LogMessage("[DEBUG] Initiating marriage proposal from " + text + " to player.");
		bool flag = GlobalSettings<ModSettings>.Instance.AllowRomanceWithMarried || (npc.Spouse == null && player.Spouse == null);
		if (!context.IsRomanceEligible || !flag)
		{
			AIInfluenceBehavior behavior = _behavior;
			object[] obj = new object[5] { text, context.RomanceLevel, context.IsRomanceEligible, null, null };
			Hero spouse = npc.Spouse;
			obj[3] = ((spouse != null) ? spouse.Name : null);
			Hero spouse2 = player.Spouse;
			obj[4] = ((spouse2 != null) ? spouse2.Name : null);
			behavior.LogMessage(string.Format("[ERROR] Marriage proposal failed: NPC {0} is not eligible (RomanceLevel: {1:F1}, Eligible: {2}, NPC Spouse: {3}, Player Spouse: {4}).", obj));
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_MarriageError}{npcName} declines to propose marriage.", new Dictionary<string, object> { { "npcName", text } })).ToString(), ExtraColors.RedAIInfluence));
			context.RomanceLevel = Math.Max(0f, context.RomanceLevel - 10f);
			_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
			return;
		}
		try
		{
			if ((int)npc.Occupation == 16 || npc.IsWanderer)
			{
				goto IL_0181;
			}
			if (npc.Clan == null)
			{
				CharacterObject characterObject = npc.CharacterObject;
				if (characterObject != null && (int)characterObject.Occupation == 16)
				{
					goto IL_0181;
				}
			}
			goto IL_0249;
			IL_0181:
			_behavior.LogMessage("[DEBUG] NPC " + text + " is a companion. Converting to Lord and joining player's clan before marriage.");
			if (npc.CompanionOf == player.Clan || npc.IsPlayerCompanion)
			{
				RemoveCompanionAction.ApplyByByTurningToLord(player.Clan, npc);
				_behavior.LogMessage("[DEBUG] Removed " + text + " from companion slot.");
			}
			npc.SetNewOccupation((Occupation)3);
			_behavior.LogMessage("[DEBUG] Changed " + text + " occupation from Wanderer to Lord.");
			if (npc.Clan != player.Clan)
			{
				npc.Clan = player.Clan;
				_behavior.LogMessage("[DEBUG] Joined " + text + " to player's clan.");
			}
			goto IL_0249;
			IL_0249:
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_MarriageProposal}{npcName} has proposed marriage to you!", new Dictionary<string, object> { { "npcName", text } })).ToString(), ExtraColors.GreenAIInfluence));
			ForceMarriage(player, npc);
			_behavior.LogMessage($"[EVENT] Marriage forced successfully by {text}. Marriage applied between {player.Name} and {text}.");
		}
		catch (Exception ex)
		{
			_behavior.LogMessage("[ERROR] Marriage proposal thrown: " + ex.Message);
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_MarriageError}{npcName} cannot propose marriage now.", new Dictionary<string, object> { { "npcName", text } })).ToString(), ExtraColors.RedAIInfluence));
			_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
		}
	}

	public static void AcceptMarriage(Hero npc, Hero player, NPCContext context)
	{
		//IL_0734: Unknown result type (might be due to invalid IL or missing references)
		//IL_0739: Unknown result type (might be due to invalid IL or missing references)
		//IL_0743: Expected O, but got Unknown
		//IL_03db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected O, but got Unknown
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Expected O, but got Unknown
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Invalid comparison between Unknown and I4
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Invalid comparison between Unknown and I4
		//IL_05e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f3: Expected O, but got Unknown
		//IL_05f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0602: Expected O, but got Unknown
		string text = ((object)npc.Name)?.ToString() ?? "Unknown";
		_behavior.LogMessage($"[DEBUG] AcceptMarriage called for {player.Name} and {text} (AI-triggered).");
		bool flag = GlobalSettings<ModSettings>.Instance.AllowRomanceWithMarried || (npc.Spouse == null && player.Spouse == null);
		AIInfluenceBehavior behavior = _behavior;
		object[] obj = new object[6] { context.IsRomanceEligible, flag, null, null, null, null };
		Hero spouse = npc.Spouse;
		obj[2] = ((spouse == null) ? null : ((object)spouse.Name)?.ToString()) ?? "null";
		Hero spouse2 = player.Spouse;
		obj[3] = ((spouse2 == null) ? null : ((object)spouse2.Name)?.ToString()) ?? "null";
		obj[4] = npc.IsPrisoner;
		obj[5] = GlobalSettings<ModSettings>.Instance.AllowRomanceWithMarried;
		behavior.LogMessage(string.Format("[DEBUG] Marriage conditions check: IsRomanceEligible={0}, marriageCheckAccept={1}, NPC Spouse={2}, Player Spouse={3}, NPC IsPrisoner={4}, AllowRomanceWithMarried={5}", obj));
		if (!context.IsRomanceEligible || !flag)
		{
			_behavior.LogMessage($"[ERROR] Marriage impossible: {text} not eligible. IsRomanceEligible={context.IsRomanceEligible}, marriageCheckAccept={flag}");
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_MarriageError}{npcName} cannot marry you now.", new Dictionary<string, object> { { "npcName", text } })).ToString(), ExtraColors.RedAIInfluence));
			context.RomanceLevel = Math.Max(0f, context.RomanceLevel - 10f);
			_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
			return;
		}
		try
		{
			if ((int)npc.Occupation == 16 || npc.IsWanderer)
			{
				goto IL_01ea;
			}
			if (npc.Clan == null)
			{
				CharacterObject characterObject = npc.CharacterObject;
				if (characterObject != null && (int)characterObject.Occupation == 16)
				{
					goto IL_01ea;
				}
			}
			goto IL_04ee;
			IL_01ea:
			_behavior.LogMessage("[DEBUG] NPC " + text + " is a companion. Converting to Lord and joining player's clan before marriage.");
			if (npc.CompanionOf == player.Clan || npc.IsPlayerCompanion)
			{
				try
				{
					if (player.Clan == null)
					{
						_behavior.LogMessage("[ERROR] Cannot remove companion: player.Clan is null.");
						throw new InvalidOperationException("Player clan is null");
					}
					if (npc == null)
					{
						_behavior.LogMessage("[ERROR] Cannot remove companion: npc is null.");
						throw new InvalidOperationException("NPC is null");
					}
					AIInfluenceBehavior behavior2 = _behavior;
					object[] obj2 = new object[4] { text, null, null, null };
					Clan companionOf = npc.CompanionOf;
					obj2[1] = ((companionOf == null) ? null : ((object)companionOf.Name)?.ToString()) ?? "null";
					obj2[2] = npc.IsPlayerCompanion;
					obj2[3] = ((object)player.Clan.Name)?.ToString() ?? "null";
					behavior2.LogMessage(string.Format("[DEBUG] Attempting to remove {0} from companion slot. CompanionOf={1}, IsPlayerCompanion={2}, PlayerClan={3}", obj2));
					RemoveCompanionAction.ApplyByByTurningToLord(player.Clan, npc);
					_behavior.LogMessage("[DEBUG] Removed " + text + " from companion slot.");
				}
				catch (Exception ex)
				{
					_behavior.LogMessage("[ERROR] Failed to remove " + text + " from companion slot: " + ex.Message + ". StackTrace: " + ex.StackTrace);
				}
			}
			try
			{
				if (npc == null)
				{
					_behavior.LogMessage("[ERROR] Cannot set occupation: npc is null.");
					throw new InvalidOperationException("NPC is null");
				}
				if (npc.CharacterObject == null)
				{
					_behavior.LogMessage("[ERROR] Cannot set occupation: npc.CharacterObject is null for " + text + ".");
					throw new InvalidOperationException("NPC CharacterObject is null for " + text);
				}
				_behavior.LogMessage(string.Format("[DEBUG] Attempting to change {0} occupation from {1} to Lord. CharacterObject={2}", text, npc.Occupation, ((object)((BasicCharacterObject)npc.CharacterObject).Name)?.ToString() ?? "null"));
				npc.SetNewOccupation((Occupation)3);
				_behavior.LogMessage("[DEBUG] Changed " + text + " occupation from Wanderer to Lord.");
			}
			catch (Exception ex2)
			{
				_behavior.LogMessage("[ERROR] Failed to set occupation for " + text + ": " + ex2.Message + ". StackTrace: " + ex2.StackTrace);
				throw;
			}
			if (npc.Clan != player.Clan)
			{
				if (player.Clan == null)
				{
					_behavior.LogMessage("[ERROR] Cannot join clan: player.Clan is null.");
					throw new InvalidOperationException("Player clan is null");
				}
				npc.Clan = player.Clan;
				_behavior.LogMessage("[DEBUG] Joined " + text + " to player's clan.");
			}
			goto IL_04ee;
			IL_04ee:
			if (npc.Clan == null)
			{
				_behavior.LogMessage("[ERROR] NPC " + text + " has no clan after conversion. Cannot proceed with marriage.");
				throw new InvalidOperationException("NPC " + text + " has no clan");
			}
			if (player.Clan == null)
			{
				_behavior.LogMessage($"[ERROR] Player {player.Name} has no clan. Cannot proceed with marriage.");
				throw new InvalidOperationException($"Player {player.Name} has no clan");
			}
			_behavior.LogMessage("[DEBUG] Both heroes have clans. NPC Clan: " + (((object)npc.Clan.Name)?.ToString() ?? "null") + ", Player Clan: " + (((object)player.Clan.Name)?.ToString() ?? "null"));
			ForceMarriage(player, npc);
			InformationManager.DisplayMessage(new InformationMessage(((object)new TextObject("{=AIInfluence_MarriageComplete}{npcName} weds you! Congratulations!", new Dictionary<string, object> { { "npcName", text } })).ToString(), ExtraColors.GreenAIInfluence));
			_behavior.LogMessage($"[EVENT] Marriage {player.Name} and {text} done.");
			context.RomanceLevel = 100f;
			_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
			Campaign current = Campaign.Current;
			if (current != null)
			{
				ConversationManager conversationManager = current.ConversationManager;
				if (((conversationManager != null) ? new bool?(conversationManager.IsConversationInProgress) : ((bool?)null)) == true)
				{
					_behavior.LogMessage("[DEBUG] Closing conversation after marriage.");
					Campaign.Current.ConversationManager.EndConversation();
				}
			}
		}
		catch (Exception ex3)
		{
			_behavior.LogMessage("[ERROR] Marriage thrown: " + ex3.Message);
			_behavior.LogMessage("[ERROR] StackTrace: " + ex3.StackTrace);
			if (ex3.InnerException != null)
			{
				_behavior.LogMessage("[ERROR] InnerException: " + ex3.InnerException.Message);
				_behavior.LogMessage("[ERROR] InnerException StackTrace: " + ex3.InnerException.StackTrace);
			}
			InformationManager.DisplayMessage(new InformationMessage("Marriage event failed!", ExtraColors.RedAIInfluence));
			context.MarriageResponse = null;
			_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
		}
	}

	private static void ForceMarriage(Hero firstHero, Hero secondHero)
	{
		if (firstHero == null || secondHero == null)
		{
			_behavior.LogMessage("[ERROR] ForceMarriage called with null hero.");
			return;
		}
		Campaign current = Campaign.Current;
		object obj;
		if (current == null)
		{
			obj = null;
		}
		else
		{
			GameModels models = current.Models;
			obj = ((models != null) ? models.MarriageModel : null);
		}
		MarriageModel val = (MarriageModel)obj;
		Clan val2 = null;
		try
		{
			if (val != null && firstHero.Clan != null && secondHero.Clan != null)
			{
				val2 = val.GetClanAfterMarriage(firstHero, secondHero);
			}
			else if (val != null)
			{
				_behavior.LogMessage("[WARN] MarriageModel.GetClanAfterMarriage skipped due to missing clan, using fallback.");
			}
		}
		catch (Exception ex)
		{
			_behavior.LogMessage("[ERROR] MarriageModel.GetClanAfterMarriage failed: " + ex.Message);
		}
		if (val2 == null)
		{
			val2 = ResolveClanAfterMarriageFallback(firstHero, secondHero);
		}
		firstHero.Spouse = secondHero;
		secondHero.Spouse = firstHero;
		int num = 20;
		try
		{
			num = ((val != null) ? val.GetEffectiveRelationIncrease(firstHero, secondHero) : 20);
		}
		catch (Exception ex2)
		{
			_behavior.LogMessage("[WARN] MarriageModel.GetEffectiveRelationIncrease failed, using default 20: " + ex2.Message);
		}
		ChangeRelationAction.ApplyRelationChangeBetweenHeroes(firstHero, secondHero, num, false);
		CampaignEventDispatcher instance = CampaignEventDispatcher.Instance;
		if (instance != null)
		{
			((CampaignEventReceiver)instance).OnBeforeHeroesMarried(firstHero, secondHero, true);
		}
		if (val2 != null)
		{
			if (firstHero.Clan != val2)
			{
				HandleClanChangeAfterMarriageForHero(firstHero, val2);
			}
			if (secondHero.Clan != val2)
			{
				HandleClanChangeAfterMarriageForHero(secondHero, val2);
			}
		}
		EndAllCourtshipsSafe(firstHero);
		EndAllCourtshipsSafe(secondHero);
		ChangeRomanticStateAction.Apply(firstHero, secondHero, (RomanceLevelEnum)7);
	}

	private static void HandleClanChangeAfterMarriageForHero(Hero hero, Clan clanAfterMarriage)
	{
		//IL_00e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		Clan clan = hero.Clan;
		if (hero.GovernorOf != null)
		{
			ChangeGovernorAction.RemoveGovernorOf(hero);
		}
		if (hero.PartyBelongedTo != null)
		{
			if (((clan != null) ? clan.Kingdom : null) != clanAfterMarriage.Kingdom)
			{
				if (hero.PartyBelongedTo.Army != null)
				{
					if (hero.PartyBelongedTo.Army.LeaderParty == hero.PartyBelongedTo)
					{
						DisbandArmyAction.ApplyByUnknownReason(hero.PartyBelongedTo.Army);
					}
					else
					{
						hero.PartyBelongedTo.Army = null;
					}
				}
				IFaction kingdom = (IFaction)(object)clanAfterMarriage.Kingdom;
				FactionHelper.FinishAllRelatedHostileActionsOfNobleToFaction(hero, (IFaction)(((object)kingdom) ?? ((object)clanAfterMarriage)));
			}
			MobileParty partyBelongedTo = hero.PartyBelongedTo;
			bool flag = hero.PartyBelongedTo.LeaderHero == hero;
			partyBelongedTo.MemberRoster.RemoveTroop(hero.CharacterObject, 1, default(UniqueTroopDescriptor), 0);
			MakeHeroFugitiveAction.Apply(hero, false);
			if (flag && partyBelongedTo.IsLordParty)
			{
				DisbandPartyAction.StartDisband(partyBelongedTo);
			}
		}
		hero.Clan = clanAfterMarriage;
		if (clan != null)
		{
			foreach (Hero item in (List<Hero>)(object)clan.Heroes)
			{
				item.UpdateHomeSettlement();
			}
		}
		foreach (Hero item2 in (List<Hero>)(object)clanAfterMarriage.Heroes)
		{
			item2.UpdateHomeSettlement();
		}
	}

	private static Clan ResolveClanAfterMarriageFallback(Hero firstHero, Hero secondHero)
	{
		if (firstHero.IsHumanPlayerCharacter)
		{
			return firstHero.Clan;
		}
		if (secondHero.IsHumanPlayerCharacter)
		{
			return secondHero.Clan;
		}
		Clan clan = firstHero.Clan;
		if (((clan != null) ? clan.Leader : null) == firstHero)
		{
			return firstHero.Clan;
		}
		Clan clan2 = secondHero.Clan;
		if (((clan2 != null) ? clan2.Leader : null) == secondHero)
		{
			return secondHero.Clan;
		}
		if (!firstHero.IsFemale)
		{
			return firstHero.Clan;
		}
		return secondHero.Clan;
	}

	private static void EndAllCourtshipsSafe(Hero hero)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		List<RomanticState> romanticStateList = Romance.RomanticStateList;
		if (romanticStateList == null || hero == null)
		{
			return;
		}
		foreach (RomanticState item in romanticStateList)
		{
			if (item != null && (item.Person1 == hero || item.Person2 == hero))
			{
				item.Level = (RomanceLevelEnum)(-2);
			}
		}
	}
}
