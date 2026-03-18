using System;
using System.Collections.Generic;
using AIInfluence.Util;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Actions;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.CampaignSystem.Encounters;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Roster;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.Localization;
using TaleWorlds.ObjectSystem;

namespace AIInfluence;

public class AIDecisionHandler
{
	private readonly AIInfluenceBehavior _behavior;

	private readonly Random _random = new Random();

	public AIDecisionHandler(AIInfluenceBehavior behavior)
	{
		_behavior = behavior;
	}

	public void HandleAIDecision(NPCContext context, Hero npc, AIResponse aiResult, string playerInput)
	{
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		if (!GlobalSettings<ModSettings>.Instance.EnableModification)
		{
			return;
		}
		if (context == null || npc == null || aiResult == null)
		{
			_behavior.LogMessage("[ERROR] Invalid context, NPC, or AI response in HandleAIDecision.");
			return;
		}
		string stringId = ((MBObjectBase)npc).StringId;
		string text = ((object)npc.Name)?.ToString() ?? "Unknown";
		bool flag = npc.PartyBelongedTo != null || npc.CurrentSettlement != null;
		context.EscalationState = aiResult.EscalationState ?? "neutral";
		_behavior.LogMessage($"[DEBUG] Handling AI decision for {text}. Escalation state: {context.EscalationState}; Can fight: {flag}; Player input: {playerInput}");
		if (aiResult.Tone == "negative")
		{
			context.NegativeToneCount = context.NegativeToneCount.GetValueOrDefault() + 1;
			_behavior.LogMessage($"[DEBUG] Negative tone detected. NegativeToneCount: {context.NegativeToneCount}");
			string message = ((object)new TextObject("{=AIInfluence_RelationWorsenedTone}{npcName} dislikes your tone.", new Dictionary<string, object> { { "npcName", text } })).ToString();
			context.PendingRelationChange = new PendingRelationChange
			{
				RelationChange = -Math.Min(context.NegativeToneCount.Value, 5),
				Message = message,
				Color = Colors.Yellow
			};
		}
		else
		{
			context.NegativeToneCount = 0;
			if (aiResult.Tone == "neutral" || aiResult.Tone == "positive")
			{
				context.EscalationState = "neutral";
			}
			_behavior.LogMessage("[DEBUG] Non-negative tone detected. Reset NegativeToneCount to 0. EscalationState: " + context.EscalationState);
		}
		if (!flag)
		{
			_behavior.LogMessage("[DEBUG] NPC " + text + " cannot fight (no party and not in settlement). Ignoring decision.");
			if (aiResult.DeescalationAttempt)
			{
				_behavior.LogMessage("[DEBUG] De-escalation attempt detected for " + text + ".");
				TryPersuade(npc, text, context);
			}
			context.CombatResponse = null;
			_behavior.SaveNPCContext(stringId, npc, context);
			return;
		}
		string text2 = aiResult.Decision?.ToLower() ?? "none";
		_behavior.LogMessage($"[DEBUG] AI decision for {text}: {text2}; Response: {aiResult.Response}; Relation: {context.PlayerRelation?.Value ?? 0}; NPC Forces: {context.NPCForces?.PartySize ?? 0}; Player Forces: {context.PlayerForces?.PartySize ?? 0}");
		switch (text2)
		{
		case "attack":
		{
			_behavior.LogMessage("[DEBUG] NPC " + text + " decides to attack.");
			string text6 = aiResult.Response ?? (text + " prepares to fight!");
			context.CombatResponse = "attack: " + text6;
			InitiateCombat(npc, text, context, isPlayerInitiated: false, text6);
			break;
		}
		case "release":
		{
			_behavior.LogMessage("[DEBUG] NPC " + text + " decides to release the player.");
			string text3 = aiResult.Response ?? (text + " lets you go... for now.");
			context.CombatResponse = "release: " + text3;
			context.IsSurrendering = false;
			break;
		}
		case "surrender":
			_behavior.LogMessage("[DEBUG] NPC " + text + " decides to surrender.");
			context.CombatResponse = null;
			break;
		case "accept_surrender":
		{
			_behavior.LogMessage("[DEBUG] NPC " + text + " accepts player surrender.");
			string text5 = aiResult.Response ?? (text + " accepts your surrender.");
			context.CombatResponse = "accept_surrender: " + text5;
			context.IsPlayerSurrendering = true;
			break;
		}
		case "none":
			_behavior.LogMessage("[DEBUG] NPC " + text + " decides to do nothing.");
			context.CombatResponse = null;
			if (aiResult.DeescalationAttempt)
			{
				_behavior.LogMessage("[DEBUG] De-escalation attempt detected for " + text + ".");
				TryPersuade(npc, text, context);
			}
			else
			{
				string text4 = aiResult.Response ?? (text + " remains cautious but takes no action.");
			}
			break;
		case "propose_marriage":
		case "accept_marriage":
		case "reject_marriage":
			_behavior.LogMessage("[DEBUG] NPC " + text + " marriage decision: " + text2 + ". Already processed in AIInfluenceBehavior.");
			context.CombatResponse = null;
			break;
		case "intimate":
			_behavior.LogMessage("[DEBUG] NPC " + text + " agrees to intimate interaction. Will be processed when player views response.");
			context.CombatResponse = null;
			context.PendingIntimacyNotification = true;
			break;
		default:
			_behavior.LogMessage("[WARNING] Invalid AI decision: " + text2 + ". Treating as 'none'.");
			context.CombatResponse = null;
			if (aiResult.DeescalationAttempt)
			{
				TryPersuade(npc, text, context);
			}
			break;
		}
		_behavior.SaveNPCContext(stringId, npc, context);
	}

	public void HandleSurrender(Hero npc, string npcName, NPCContext context, string surrenderResponse)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0406: Expected O, but got Unknown
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Unknown result type (might be due to invalid IL or missing references)
		if (npc == null)
		{
			_behavior.LogMessage("[NPC] Attempted to process surrender for null NPC.");
			return;
		}
		context.NegativeToneCount = 0;
		context.EscalationState = "neutral";
		context.CombatResponse = null;
		string text = surrenderResponse ?? ((object)new TextObject("{=AIInfluence_NPCSurrender}{npcName} surrenders, unwilling to face your forces.", new Dictionary<string, object> { { "npcName", npcName } })).ToString();
		InformationManager.DisplayMessage(new InformationMessage(text, ExtraColors.GreenAIInfluence));
		string message = ((object)new TextObject("{=AIInfluence_RelationImprovedSurrender}Your relations with {npcName} have worsened due to their surrender.", new Dictionary<string, object> { { "npcName", npcName } })).ToString();
		_behavior.ApplyRelationChangeWithDelay(npc, -15, ExtraColors.RedAIInfluence, message);
		MobileParty partyBelongedTo = npc.PartyBelongedTo;
		bool flag = partyBelongedTo != null && partyBelongedTo.Army != null && partyBelongedTo.Army.LeaderParty == partyBelongedTo;
		if (partyBelongedTo != null && partyBelongedTo.IsActive && partyBelongedTo.MemberRoster.TotalManCount > 0)
		{
			PartyBase party = partyBelongedTo.Party;
			List<MobileParty> list = new List<MobileParty>();
			if (flag)
			{
				_behavior.LogMessage($"[NPC] {npcName} is army leader - processing surrender of entire army ({partyBelongedTo.Army.Name})");
				foreach (MobileParty item in (List<MobileParty>)(object)partyBelongedTo.Army.Parties)
				{
					if (item != null && item.IsActive && item.MemberRoster.TotalManCount > 0)
					{
						list.Add(item);
						_behavior.LogMessage($"[NPC] Adding army party {item.Name} ({item.MemberRoster.TotalManCount} troops) to surrender list");
					}
				}
			}
			else
			{
				_behavior.LogMessage($"[NPC] Processing surrender of {partyBelongedTo.Name} with {partyBelongedTo.MemberRoster.TotalManCount} troops (not army leader).");
				list.Add(partyBelongedTo);
			}
			TroopRoster val = TroopRoster.CreateDummyTroopRoster();
			string text2 = (flag ? ((object)partyBelongedTo.Army.Name).ToString() : ((object)partyBelongedTo.Name).ToString());
			foreach (MobileParty item2 in list)
			{
				foreach (TroopRosterElement item3 in (List<TroopRosterElement>)(object)item2.MemberRoster.GetTroopRoster())
				{
					TroopRosterElement current3 = item3;
					val.AddToCounts(current3.Character, (current3).Number, false, 0, 0, true, -1);
					_behavior.LogMessage($"[NPC] Queued {(current3).Number} of {((BasicCharacterObject)current3.Character).Name} from {item2.Name} for prisoner loot screen.");
				}
				foreach (TroopRosterElement item4 in (List<TroopRosterElement>)(object)item2.PrisonRoster.GetTroopRoster())
				{
					TroopRosterElement current4 = item4;
					val.AddToCounts(current4.Character, (current4).Number, false, 0, 0, true, -1);
					_behavior.LogMessage($"[NPC] Queued {(current4).Number} of {((BasicCharacterObject)current4.Character).Name} from {item2.Name}'s prison roster for loot screen.");
				}
			}
			foreach (MobileParty item5 in list)
			{
				DestroyPartyAction.Apply(PartyBase.MainParty, item5);
				_behavior.LogMessage($"[NPC] Destroyed surrendered party {item5.Name}.");
			}
			try
			{
				if (GameVersionCompatibility.TryOpenPartyScreenAsLoot(TroopRoster.CreateDummyTroopRoster(), val, new TextObject(text2, (Dictionary<string, object>)null), val.TotalManCount))
				{
					_behavior.LogMessage($"[NPC] Opened loot screen for prisoners from {text2} ({list.Count} parties surrendered).");
				}
				else
				{
					_behavior.LogMessage($"[NPC] Prisoners transferred from {list.Count} surrendered parties.");
				}
			}
			catch (Exception ex)
			{
				_behavior.LogMessage("[ERROR] Failed to open loot screens for " + text2 + ": " + ex.Message + "\n" + ex.StackTrace);
			}
		}
		else
		{
			_behavior.LogMessage("[NPC] Adding " + npcName + " as a prisoner (no active party or empty roster).");
			TakePrisonerAction.Apply(PartyBase.MainParty, npc);
		}
		try
		{
			WarHandler.DeclareWar(npc, _behavior);
		}
		catch (Exception ex2)
		{
			_behavior.LogMessage("[ERROR] DeclareWar after surrender failed: " + ex2.Message);
		}
		PlayerEncounter.LeaveEncounter = true;
		_behavior.LogMessage("[NPC] Ended encounter after surrender of " + npcName + ".");
	}

	private float CalculateTraitModifierForPersuasion(Hero npc, NPCContext context)
	{
		float num = 0f;
		num += (float)npc.GetTraitLevel(DefaultTraits.Mercy) * 0.15f;
		num += (float)npc.GetTraitLevel(DefaultTraits.Honor) * 0.1f;
		num += (float)npc.GetTraitLevel(DefaultTraits.Valor) * -0.05f;
		num += (float)npc.GetTraitLevel(DefaultTraits.Generosity) * 0.1f;
		num += (float)npc.GetTraitLevel(DefaultTraits.Calculating) * -0.1f;
		num += (float)npc.GetTraitLevel(DefaultTraits.PersonaEarnest) * 0.1f;
		num += (float)npc.GetTraitLevel(DefaultTraits.PersonaSoftspoken) * 0.05f;
		_behavior.LogMessage($"[DEBUG] Trait modifier for persuasion: {num:F2}");
		return num;
	}

	private void InitiateCombat(Hero npc, string npcName, NPCContext context, bool isPlayerInitiated, string npcResponse)
	{
		if (GlobalSettings<ModSettings>.Instance.EnableModification)
		{
			_behavior.LogMessage($"[DEBUG] Preparing combat with {npcName}. Player initiated: {isPlayerInitiated}. Response: {npcResponse}");
			string text = npcResponse + " (Готовьтесь к бою...)";
			if (Campaign.Current?.ConversationManager != null)
				MBTextManager.SetTextVariable("DYNAMIC_NPC_RESPONSE", text, false);
			_behavior.LogMessage("[DEBUG] Set DYNAMIC_NPC_RESPONSE for combat: " + text);
			context.AddMessage(npcName + ": " + npcResponse);
			_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
		}
	}

	private void TryPersuade(Hero npc, string npcName, NPCContext context)
	{
		//IL_01fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Expected O, but got Unknown
		int skillValue = Hero.MainHero.GetSkillValue(DefaultSkills.Charm);
		if (skillValue < 50)
		{
			_behavior.LogMessage($"[DEBUG] Persuasion bonus skipped: Charm skill {skillValue} is below required 50. NPC already accepted.");
			return;
		}
		float trustLevel = context.TrustLevel;
		int relation = npc.GetRelation(Hero.MainHero);
		bool flag = npc.MapFaction != null && Hero.MainHero.MapFaction != null && npc.MapFaction.IsAtWarWith(Hero.MainHero.MapFaction);
		NPCForces nPCForces = context.NPCForces ?? new NPCForces();
		PlayerForces playerForces = context.PlayerForces ?? new PlayerForces();
		float num = 0.2f + (float)skillValue / 300f + trustLevel * 0.2f + ((relation > 0) ? ((float)relation / 200f) : 0f);
		if (flag)
		{
			num *= 0.8f;
		}
		if ((float)nPCForces.PartySize > (float)playerForces.PartySize * 1.2f)
		{
			num *= 0.9f;
		}
		num += CalculateTraitModifierForPersuasion(npc, context);
		num = Math.Max(0.1f, Math.Min(0.8f, num));
		_behavior.LogMessage($"[DEBUG] Persuasion chance: {num:F2} (Charm: {skillValue}, Trust: {trustLevel:F2}, Relation: {relation}, War: {flag})");
		if (_random.NextDouble() < (double)num)
		{
			float num2 = (flag ? 0.05f : 0.1f);
			int num3 = (flag ? 2 : 5);
			context.TrustLevel = Math.Min(1f, context.TrustLevel + num2);
			context.NegativeToneCount = 0;
			context.EscalationState = "neutral";
			string message = ((object)new TextObject(flag ? "{=AIInfluence_PersuasionSuccessWar}{npcName} grudgingly agrees to hold off, for now." : "{=AIInfluence_PersuasionSuccess}{npcName} calms down and agrees to avoid a fight.", new Dictionary<string, object> { { "npcName", npcName } })).ToString();
			_behavior.ApplyRelationChangeWithDelay(npc, num3, ExtraColors.GreenAIInfluence, message);
			_behavior.LogMessage($"[DEBUG] Persuasion successful with {npcName}. Trust: {context.TrustLevel:F2}, Scheduled relation increase by {num3} after 0.2s.");
			_behavior.SaveNPCContext(((MBObjectBase)npc).StringId, npc, context);
			MBTextManager.SetTextVariable("DYNAMIC_NPC_RESPONSE", new TextObject(flag ? "{=AIInfluence_PersuasionResponseWar}I'll hold my blade... for now." : "{=AIInfluence_PersuasionResponse}Very well, let's keep the peace.", (Dictionary<string, object>)null), false);
		}
		else
		{
			_behavior.LogMessage("[DEBUG] Persuasion bonus roll failed with " + npcName + ". NPC already accepted, no bonus applied.");
		}
	}
}
