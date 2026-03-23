using System;
using System.Collections.Generic;
using System.Linq;
using AIInfluence.Behaviors.AIActions;
using AIInfluence;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.ChatTools;

/// <summary>Each handler owns its parsing. Dispatched by name from ExecuteChatTool.</summary>
public static class ToolHandlers
{
	public static string Run(string name, string argsJson, Hero npc, NPCContext context, AIInfluenceBehavior behavior)
	{
		string result = name switch
		{
			"follow_player" => RunFollowPlayer(npc, context),
			"stop_action" => RunStopAction(argsJson, npc),
			"go_to_settlement" => RunGoToSettlement(argsJson, npc, context),
			"attack_party" => RunAttackParty(argsJson, npc, context),
			"raid_village" => RunRaidVillage(argsJson, npc, context),
			"patrol_settlement" => RunPatrolSettlement(argsJson, npc, context),
			"wait_near_settlement" => RunWaitNearSettlement(argsJson, npc, context),
			"siege_settlement" => RunSiegeSettlement(argsJson, npc, context),
			"create_party" => RunCreateParty(npc),
			"create_rp_item" => RunCreateRPItem(argsJson, npc, context),
			"transfer_money" => RunTransferMoney(argsJson, npc, context, behavior),
			"transfer_items" => RunTransferItems(argsJson, npc, context, behavior),
			"workshop_sell" => RunWorkshopSell(argsJson, npc, context, behavior),
			"kingdom_action" => RunKingdomAction(argsJson, npc, context, behavior),
			"quest_action" => RunQuestAction(argsJson, npc, context, behavior),
			"character_death" => RunCharacterDeath(argsJson, context),
			"technical_action" => RunTechnicalAction(argsJson, context),
			"map_command" => RunMapCommand(argsJson, context),
			"suspected_lie" => RunSuspectedLie(argsJson, context),
			"dialogue_decision" => RunDialogueDecision(argsJson, context),
			"romance_intent" => RunRomanceIntent(argsJson, context),
			"escalation_update" => RunEscalationUpdate(argsJson, context),
			"allows_letters" => RunAllowsLetters(argsJson, context),
			_ => "unknown"
		};
		ToolCallTelemetry.RaiseCompleted("npc_chat", name, argsJson, result, null);
		return result;
	}

	private static string RunFollowPlayer(Hero npc, NPCContext context)
	{
		if (npc.IsPrisoner) return "prisoner";
		AIActionManager.Instance?.StopAction(npc, "follow_player");
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "follow_player", "") != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "follow_player");
		context.LastTechnicalActionForDisplay = "follow_player";
		return "ok";
	}

	private static string RunStopAction(string argsJson, Hero npc)
	{
		string actionName = ParseOrEmpty(argsJson)["action_name"]?.ToString();
		if (string.IsNullOrEmpty(actionName)) return "missing";
		AIActionManager.Instance?.StopAction(npc, actionName, showMessage: true);
		return "stopped";
	}

	private static string RunGoToSettlement(string argsJson, Hero npc, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string settlementName = parsedArgs["settlement_name"]?.ToString();
		if (string.IsNullOrEmpty(settlementName)) return "missing settlement_name";
		float waitDays = parsedArgs["wait_days"]?.Value<float>() ?? 3f;
		var filterList = new List<string>();
		if (parsedArgs["filters"] is JArray fa)
		{
			foreach (JToken t in fa)
			{
				string f = t?.ToString();
				if (!string.IsNullOrWhiteSpace(f)) filterList.Add(f);
			}
		}
		string resolveError = BlgmStyleSettlementResolver.TryResolve(settlementName, filterList, out Settlement settlement);
		if (resolveError != null) return resolveError;
		string settlementStringId = ((MBObjectBase)settlement).StringId;
		string param = settlementStringId + ":" + waitDays;
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "go_to_settlement", param) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "go_to_settlement");
		context.LastTechnicalActionForDisplay = param;
		return "ok";
	}

	private static string RunAttackParty(string argsJson, Hero npc, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string partyStringId = parsedArgs["party_id"]?.ToString();
		if (string.IsNullOrEmpty(partyStringId)) return "missing party_id";
		string param = parsedArgs["then_return"]?.Value<bool>() == true ? partyStringId + ",then:return" : partyStringId;
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "attack_party", param) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "attack_party");
		context.LastTechnicalActionForDisplay = param;
		return "ok";
	}

	private static string RunRaidVillage(string argsJson, Hero npc, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string villageStringId = parsedArgs["village_id"]?.ToString();
		if (string.IsNullOrEmpty(villageStringId)) return "missing village_id";
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "raid_village", villageStringId) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "raid_village");
		context.LastTechnicalActionForDisplay = villageStringId;
		return "ok";
	}

	private static string RunPatrolSettlement(string argsJson, Hero npc, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string settlementStringId = parsedArgs["settlement_id"]?.ToString();
		if (string.IsNullOrEmpty(settlementStringId)) return "missing settlement_id";
		string param = settlementStringId + ":" + (parsedArgs["days"]?.Value<float>() ?? 5f);
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "patrol_settlement", param) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "patrol_settlement");
		context.LastTechnicalActionForDisplay = param;
		return "ok";
	}

	private static string RunWaitNearSettlement(string argsJson, Hero npc, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string settlementStringId = parsedArgs["settlement_id"]?.ToString();
		if (string.IsNullOrEmpty(settlementStringId)) return "missing settlement_id";
		string param = settlementStringId + ":" + (parsedArgs["days"]?.Value<float>() ?? 2f);
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "wait_near_settlement", param) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "wait_near_settlement");
		context.LastTechnicalActionForDisplay = param;
		return "ok";
	}

	private static string RunSiegeSettlement(string argsJson, Hero npc, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string settlementStringId = parsedArgs["settlement_id"]?.ToString();
		if (string.IsNullOrEmpty(settlementStringId)) return "missing settlement_id";
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "siege_settlement", settlementStringId) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "siege_settlement");
		context.LastTechnicalActionForDisplay = settlementStringId;
		return "ok";
	}

	private static string RunCreateParty(Hero npc)
	{
		return AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "create_party", "") == true
			&& AIActionManager.Instance?.StartAction(npc, "create_party") == true ? "ok" : "failed";
	}

	private static string RunCreateRPItem(string argsJson, Hero npc, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string itemName = parsedArgs["name"]?.ToString();
		if (string.IsNullOrEmpty(itemName)) return "missing name";
		string param = itemName + "|" + (parsedArgs["description"]?.ToString() ?? "");
		if (AIActionIntegration.Instance?.TryPrepareActionParameter(npc, "create_rp_item", param) != true) return "failed";
		AIActionManager.Instance?.StartAction(npc, "create_rp_item");
		context.LastTechnicalActionForDisplay = itemName;
		return "ok";
	}

	private static string RunTransferMoney(string argsJson, Hero npc, NPCContext context, AIInfluenceBehavior behavior)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		var moneyTransfer = new MoneyTransferInfo { Action = parsedArgs["action"]?.ToString(), Amount = parsedArgs["amount"]?.Value<int>() ?? 0, OpposedAttribute = parsedArgs["opposed_attribute"]?.ToString() };
		if (moneyTransfer.Amount > 0) behavior.ProcessMoneyTransfer(npc, context, moneyTransfer);
		return "ok";
	}

	private static string RunTransferItems(string argsJson, Hero npc, NPCContext context, AIInfluenceBehavior behavior)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		var arr = parsedArgs["items"] as JArray;
		if (arr == null || arr.Count == 0) return "ok";
		var list = new List<ItemTransferData>();
		foreach (JToken itemRow in arr)
			list.Add(new ItemTransferData { ItemId = itemRow["item_id"]?.ToString(), Amount = itemRow["amount"]?.Value<int>() ?? 1, Action = itemRow["action"]?.ToString() });
		context.PendingItemTransfersOpposedAttribute = parsedArgs["opposed_attribute"]?.ToString();
		behavior.ProcessItemTransfers(npc, context, list);
		return "ok";
	}

	private static string RunWorkshopSell(string argsJson, Hero npc, NPCContext context, AIInfluenceBehavior behavior)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		behavior.ProcessWorkshopSale(npc, context, parsedArgs["workshop_string_id"]?.ToString(), parsedArgs["price"]?.Value<int>() ?? 0);
		return "ok";
	}

	private static string RunKingdomAction(string argsJson, Hero npc, NPCContext context, AIInfluenceBehavior behavior)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string kingdomAction = parsedArgs["action"]?.ToString();
		if (string.IsNullOrEmpty(kingdomAction)) return "ok";
		behavior.ProcessKingdomAction(npc, new AIResponse
		{
			KingdomAction = kingdomAction,
			KingdomActionReason = parsedArgs["reason"]?.ToString() ?? "",
			SettlementId = parsedArgs["settlement_id"]?.ToString()
		}, context);
		return "ok";
	}

	private static string RunCharacterDeath(string argsJson, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		bool shouldDie = parsedArgs["should_die"]?.Value<bool>() ?? false;
		if (!shouldDie)
		{
			context.DeferredCharacterDeathFromTools = null;
			return "ok";
		}
		context.DeferredCharacterDeathFromTools = new CharacterDeathInfo
		{
			ShouldDie = true,
			DeathReason = parsedArgs["death_reason"]?.ToString(),
			KillerStringId = parsedArgs["killer_string_id"]?.ToString(),
			OpposedAttribute = parsedArgs["opposed_attribute"]?.ToString()
		};
		return "ok";
	}

	private static string RunSuspectedLie(string argsJson, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		if (parsedArgs["suspected"] == null)
			return "missing";
		context.DialogueToolSuspectedLie = parsedArgs["suspected"].Value<bool>();
		return "ok";
	}

	private static string RunDialogueDecision(string argsJson, NPCContext context)
	{
		string decision = ParseOrEmpty(argsJson)["decision"]?.ToString();
		if (string.IsNullOrEmpty(decision))
			return "missing";
		context.DialogueToolDecision = decision;
		return "ok";
	}

	private static string RunRomanceIntent(string argsJson, NPCContext context)
	{
		string intent = ParseOrEmpty(argsJson)["intent"]?.ToString();
		if (string.IsNullOrEmpty(intent))
			return "missing";
		context.DialogueToolRomanceIntent = intent;
		return "ok";
	}

	private static string RunEscalationUpdate(string argsJson, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		JToken threatLevelToken = parsedArgs["threat_level"];
		if (threatLevelToken != null && threatLevelToken.Type != JTokenType.Null)
			context.DialogueToolThreatLevel = threatLevelToken.ToString();
		JToken escalationStateToken = parsedArgs["escalation_state"];
		if (escalationStateToken != null && escalationStateToken.Type != JTokenType.Null)
			context.DialogueToolEscalationState = escalationStateToken.ToString();
		JToken deescalationAttemptToken = parsedArgs["deescalation_attempt"];
		if (deescalationAttemptToken != null && deescalationAttemptToken.Type != JTokenType.Null)
			context.DialogueToolDeescalationAttempt = deescalationAttemptToken.Value<bool>();
		return "ok";
	}

	private static string RunAllowsLetters(string argsJson, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		if (parsedArgs["allows"] == null)
			return "missing";
		context.DialogueToolAllowsLetters = parsedArgs["allows"].Value<bool>();
		return "ok";
	}

	private static string RunTechnicalAction(string argsJson, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string npcMapCommandLine = parsedArgs["value"]?.ToString();
		if (string.IsNullOrEmpty(npcMapCommandLine))
			return "ok";
		context.DeferredTechnicalActionFromTools = npcMapCommandLine;
		return "ok";
	}

	/// <summary>Structured map command: <c>action</c> + optional <c>payload</c> (replaces stringly <c>technical_action</c> for new prompts).</summary>
	private static string RunMapCommand(string argsJson, NPCContext context)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		string actionName = parsedArgs["action"]?.ToString();
		if (string.IsNullOrEmpty(actionName))
			return "missing_action";
		JToken payloadToken = parsedArgs["payload"];
		string payload = payloadToken == null || payloadToken.Type == JTokenType.Null ? null : payloadToken.ToString();
		string line = string.IsNullOrEmpty(payload) ? actionName : actionName + ":" + payload;
		context.DeferredTechnicalActionFromTools = line;
		return "ok";
	}

	private static string RunQuestAction(string argsJson, Hero npc, NPCContext context, AIInfluenceBehavior behavior)
	{
		JObject parsedArgs = ParseOrEmpty(argsJson);
		JToken questToken = parsedArgs["quest"];
		if (questToken == null) return "ok";
		QuestActionData questAction = JsonConvert.DeserializeObject<QuestActionData>(questToken.ToString());
		if (questAction != null)
		{
			questAction.Category = parsedArgs["category"]?.ToString();
			context.PendingQuestActionFromTools = questAction;
		}
		return "ok";
	}

	private static JObject ParseOrEmpty(string argsJson) =>
		string.IsNullOrEmpty(argsJson) ? new JObject() : JObject.Parse(argsJson);
}
