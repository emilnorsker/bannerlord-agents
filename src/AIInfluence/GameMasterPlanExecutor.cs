using System;
using System.Collections.Generic;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace AIInfluence;

public enum GameMasterCompletionPath
{
	NpcChat,
	DynamicEvents,
	DiplomacyStatement,
	PlayerStatementAnalysis
}

/// <summary>Slices 9–11, 14, 16, 21–25, 28: enqueue BLGM work from OpenRouter plans.</summary>
public static class GameMasterPlanExecutor
{
	public static void TryEnqueueFromNpcChat(BlgmPlanDto plan, string npcStringId, Hero npc, string backendName)
	{
		TryEnqueue(plan, GameMasterCompletionPath.NpcChat, npcStringId ?? "", backendName, npc, false);
	}

	public static void TryEnqueueFromDynamicEvents(BlgmPlanDto plan, string correlationId, string backendName)
	{
		ModSettings s = GlobalSettings<ModSettings>.Instance;
		bool queryOnly = s != null && s.GameMasterWorldEventsBlgmQueryOnly;
		TryEnqueue(plan, GameMasterCompletionPath.DynamicEvents, correlationId ?? "dyn", backendName, null, queryOnly);
	}

	public static void TryEnqueueFromDiplomacyStatement(BlgmPlanDto plan, string correlationId, string backendName)
	{
		ModSettings s = GlobalSettings<ModSettings>.Instance;
		bool queryOnly = s != null && s.GameMasterDiplomacyBlgmQueryOnly;
		TryEnqueue(plan, GameMasterCompletionPath.DiplomacyStatement, correlationId ?? "dip", backendName, null, queryOnly);
	}

	public static void TryEnqueueFromPlayerStatementAnalysis(BlgmPlanDto plan, string correlationId, string backendName)
	{
		ModSettings s = GlobalSettings<ModSettings>.Instance;
		bool queryOnly = s != null && s.GameMasterDiplomacyBlgmQueryOnly;
		TryEnqueue(plan, GameMasterCompletionPath.PlayerStatementAnalysis, correlationId ?? "player_dip", backendName, null, queryOnly);
	}

	private static string GetObservationBucketKey(GameMasterCompletionPath path, string correlationId)
	{
		if (path == GameMasterCompletionPath.NpcChat)
		{
			return "NpcChat|" + (correlationId ?? "");
		}
		if (path == GameMasterCompletionPath.DynamicEvents)
		{
			return "World|DynamicEvents";
		}
		if (path == GameMasterCompletionPath.DiplomacyStatement)
		{
			return "Dip|Global";
		}
		if (path == GameMasterCompletionPath.PlayerStatementAnalysis)
		{
			return "Dip|PlayerAnalysis";
		}
		return "Gm|misc";
	}

	private static void TryEnqueue(BlgmPlanDto plan, GameMasterCompletionPath path, string correlationId, string backendName, Hero npcForHazard, bool worldQueryOnly)
	{
		ModSettings settings = GlobalSettings<ModSettings>.Instance;
		if (settings == null || plan == null || string.IsNullOrWhiteSpace(plan.GmCommand))
		{
			return;
		}
		if (!IsPathEnabled(path, settings))
		{
			return;
		}
		if (!string.Equals(backendName, "OpenRouter", StringComparison.OrdinalIgnoreCase))
		{
			AIInfluenceBehavior.Instance?.LogMessage("[GM_AGENT] blgm_plan ignored: OpenRouter-only gate, backend=" + (backendName ?? "null"));
			return;
		}
		string cmdToken = plan.GmCommand.Trim();
		List<string> args = plan.Args ?? new List<string>();
		string line;
		try
		{
			line = GameMasterCommandSerializer.SerializeLine(cmdToken, args);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[GM_SCHEMA] serialize failed: " + ex.Message);
			return;
		}
		string intent = plan.Intent?.Trim() ?? "";
		string helpLineOnly = GameMasterCommandSerializer.SerializeLine(cmdToken, Array.Empty<string>());
		if (string.Equals(intent, "probe_help", StringComparison.OrdinalIgnoreCase))
		{
			if (worldQueryOnly && !cmdToken.StartsWith("gm.query.", StringComparison.OrdinalIgnoreCase))
			{
				AIInfluenceBehavior.Instance?.LogMessage("[GM_AGENT] rejected (world query-only policy): " + helpLineOnly);
				return;
			}
			if (settings.GameMasterHazardIndexEnforce && !GameMasterHazardIndex.TryPassPreconditions(helpLineOnly, npcForHazard, out string hzPh))
			{
				AIInfluenceBehavior.Instance?.LogMessage("[GM_AGENT] hazard rejection: " + hzPh + " | " + helpLineOnly);
				return;
			}
			string pathKeyPh = path.ToString();
			string planJsonPh = JsonConvert.SerializeObject(plan);
			string bucketPh = GetObservationBucketKey(path, correlationId);
			string storyIntentPh = plan.StoryIntent?.Trim() ?? "";
			GameMasterGmJobAuditInfo auditPh = new GameMasterGmJobAuditInfo(pathKeyPh, correlationId, planJsonPh, bucketPh, storyIntentPh);
			if (!GameMasterHostPolicy.TryAcceptPlan(helpLineOnly, out string phPolicy, 0))
			{
				AIInfluenceBehavior.Instance?.LogMessage(phPolicy);
				return;
			}
			GameMasterHostPolicy.RegisterPlanAccepted();
			Guid hj = Guid.NewGuid();
			GameMasterPocQueue.EnqueueExecuteLine(hj, helpLineOnly, auditPh);
			GameMasterAuditLog.Append(pathKeyPh, correlationId, hj, helpLineOnly, planJsonPh, "enqueue", "probe_help");
			return;
		}
		if (worldQueryOnly && !cmdToken.StartsWith("gm.query.", StringComparison.OrdinalIgnoreCase))
		{
			AIInfluenceBehavior.Instance?.LogMessage("[GM_AGENT] rejected (world query-only policy): " + line);
			return;
		}
		if (settings.GameMasterHazardIndexEnforce && !GameMasterHazardIndex.TryPassPreconditions(line, npcForHazard, out string hz))
		{
			AIInfluenceBehavior.Instance?.LogMessage("[GM_AGENT] hazard rejection: " + hz + " | " + line);
			return;
		}
		bool isMutate = !string.Equals(intent, "query", StringComparison.OrdinalIgnoreCase) && !string.Equals(intent, "probe_help", StringComparison.OrdinalIgnoreCase) && !cmdToken.StartsWith("gm.query.", StringComparison.OrdinalIgnoreCase);
		if (settings.GameMasterSkillCheckMutates && isMutate && npcForHazard != null && Hero.MainHero != null)
		{
			CharacterAttribute attr = OpposedSkillCheck.ParseAttribute("social");
			if (!OpposedSkillCheck.PlayerWins(Hero.MainHero, npcForHazard, attr, out int _, out int _, out int _))
			{
				AIInfluenceBehavior.Instance?.LogMessage("[GM_AGENT] skill-check gate failed for mutate: " + line);
				return;
			}
		}
		string pathKey = path.ToString();
		string planJson = JsonConvert.SerializeObject(plan);
		string bucket = GetObservationBucketKey(path, correlationId);
		string storyIntent = plan.StoryIntent?.Trim() ?? "";
		GameMasterGmJobAuditInfo audit = new GameMasterGmJobAuditInfo(pathKey, correlationId, planJson, bucket, storyIntent);
		bool chainHelp = plan.ProbeHelpFirst && !string.Equals(intent, "query", StringComparison.OrdinalIgnoreCase);
		if (!GameMasterHostPolicy.TryAcceptPlan(line, out string policyMsg, chainHelp ? 1 : 0))
		{
			AIInfluenceBehavior.Instance?.LogMessage(policyMsg);
			return;
		}
		GameMasterHostPolicy.RegisterPlanAccepted();
		if (chainHelp)
		{
			string helpLine2 = GameMasterCommandSerializer.SerializeLine(cmdToken, Array.Empty<string>());
			Guid hj2 = Guid.NewGuid();
			GameMasterPocQueue.EnqueueExecuteLine(hj2, helpLine2, audit);
			GameMasterAuditLog.Append(pathKey, correlationId, hj2, helpLine2, planJson, "enqueue", "probe_help_first");
		}
		Guid j = Guid.NewGuid();
		GameMasterPocQueue.EnqueueExecuteLine(j, line, audit);
		GameMasterAuditLog.Append(pathKey, correlationId, j, line, planJson, "enqueue", "primary");
	}

	private static bool IsPathEnabled(GameMasterCompletionPath path, ModSettings s)
	{
		return path switch
		{
			GameMasterCompletionPath.NpcChat => s.GameMasterNpcChatBlgmEnabled, 
			GameMasterCompletionPath.DynamicEvents => s.GameMasterDynamicEventsBlgmEnabled, 
			GameMasterCompletionPath.DiplomacyStatement => s.GameMasterDiplomacyBlgmEnabled, 
			GameMasterCompletionPath.PlayerStatementAnalysis => s.GameMasterDiplomacyBlgmEnabled, 
			_ => false
		};
	}
}
