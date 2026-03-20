using System;
using System.Collections.Generic;
using MCM.Abstractions.Base.Global;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;

namespace AIInfluence;

public enum GameMasterCompletionPath
{
	NpcChat,
	DynamicEvents,
	DiplomacyStatement,
	PlayerStatementAnalysis
}

/// <summary>Slices 9–11, 14, 16: enqueue BLGM work from LLM plans (OpenRouter-only gate).</summary>
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
			AIInfluenceBehavior.Instance?.LogMessage("[GM_AGENT] serialize failed: " + ex.Message);
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
		string pathKey = path.ToString();
		string planJson = JsonConvert.SerializeObject(plan);
		GameMasterGmJobAuditInfo audit = new GameMasterGmJobAuditInfo(pathKey, correlationId, planJson);
		string intent = plan.Intent?.Trim() ?? "";
		if (string.Equals(intent, "probe_help", StringComparison.OrdinalIgnoreCase))
		{
			Guid hj = Guid.NewGuid();
			string helpLine = GameMasterCommandSerializer.SerializeLine(cmdToken, Array.Empty<string>());
			GameMasterPocQueue.EnqueueExecuteLine(hj, helpLine, audit);
			GameMasterAuditLog.Append(pathKey, correlationId, hj, helpLine, planJson, "enqueue", "probe_help");
			return;
		}
		if (plan.ProbeHelpFirst && !string.Equals(intent, "query", StringComparison.OrdinalIgnoreCase))
		{
			Guid hj2 = Guid.NewGuid();
			string helpLine2 = GameMasterCommandSerializer.SerializeLine(cmdToken, Array.Empty<string>());
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
