using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIInfluence.API;
using AIInfluence.Services;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

namespace AIInfluence;

/// <summary>
/// POC queue: slices 1–8 (correlation id, drain budget, async enqueue, batch lock, serializer, OpenRouter JSON, diagnostics).
/// </summary>
public static class GameMasterPocQueue
{
	private static readonly object BatchEnqueueLock = new object();

	public static readonly ConcurrentQueue<Action> Queue = new ConcurrentQueue<Action>();

	private const string OpenRouterGmPlanPrompt = "Return ONLY one JSON object, no markdown.\r\nKeys: gm_command (string, must start with gm.), args (string array), intent (query|mutate|probe_help), probe_help_first (boolean), story_intent (short string — dramatic purpose, or empty \"\" for pure query).\r\nTask: safe read-only kingdom listing — use gm.query.kingdom with empty args, intent=query, probe_help_first=false, story_intent=\"\".\r\nExample: {\"gm_command\":\"gm.query.kingdom\",\"args\":[],\"intent\":\"query\",\"probe_help_first\":false,\"story_intent\":\"\"}";

	public static void ClearQueueForLifecycle()
	{
		while (Queue.TryDequeue(out _))
		{
		}
	}

	public static Guid EnqueueReadOnlyKingdomQueryProbe()
	{
		string line = GameMasterCommandSerializer.SerializeLine("gm.query.kingdom", Array.Empty<string>());
		Guid jobId = Guid.NewGuid();
		AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] job " + jobId + " enqueued: " + line);
		Queue.Enqueue(delegate
		{
			ExecuteGmLine(jobId, line);
		});
		return jobId;
	}

	public static void EnqueueExecuteLine(Guid jobId, string line, GameMasterGmJobAuditInfo? audit = null)
	{
		if (string.IsNullOrWhiteSpace(line))
		{
			AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] job " + jobId + " rejected: empty line");
			return;
		}
		AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] job " + jobId + " enqueued: " + line);
		Guid captured = jobId;
		string lineCopy = line;
		GameMasterGmJobAuditInfo? auditCopy = audit;
		Queue.Enqueue(delegate
		{
			ExecuteGmLine(captured, lineCopy, auditCopy);
		});
	}

	/// <summary>Slice 5: multiple jobs enqueued without interleaving from another batch.</summary>
	public static void EnqueueBatchReadOnlyKingdomProbesLocked(int count)
	{
		int num = Math.Max(1, Math.Min(20, count));
		lock (BatchEnqueueLock)
		{
			for (int i = 0; i < num; i++)
			{
				EnqueueReadOnlyKingdomQueryProbe();
			}
		}
	}

	/// <summary>Slice 4: enqueue from thread-pool (same as typical LLM callback thread).</summary>
	public static void EnqueueReadOnlyKingdomProbeFromThreadPool()
	{
		Task.Run(delegate
		{
			try
			{
				EnqueueReadOnlyKingdomQueryProbe();
			}
			catch (Exception ex)
			{
				AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] async enqueue error: " + ex.Message);
			}
		});
	}

	/// <summary>Slice 7: OpenRouter returns JSON → serialize line → queue (runs network on thread pool).</summary>
	public static void StartOpenRouterJsonPlanEnqueue()
	{
		Task.Run(async () =>
		{
			try
			{
				bool strict = GlobalSettings<ModSettings>.Instance != null && GlobalSettings<ModSettings>.Instance.GameMasterOpenRouterGmPlanStrictSchema;
				string raw = strict
					? await AIClient.GetOpenRouterRawForGmPlanWithOptionalSchema(OpenRouterGmPlanPrompt, strictSchema: true)
					: await AIClient.GetRawTextResponseWithBackend(OpenRouterGmPlanPrompt, "OpenRouter", 0);
				if (string.IsNullOrEmpty(raw) || raw.StartsWith("Error:", StringComparison.OrdinalIgnoreCase))
				{
					string msg = raw ?? "empty";
					TtsLipSyncService.MainThreadQueue.Enqueue(delegate
					{
						InformationManager.DisplayMessage(new InformationMessage("[GM_POC] OpenRouter: " + msg, Colors.Yellow));
					});
					return;
				}
				if (!GameMasterCommandSerializer.TryParseOpenRouterJson(raw, out string line, out string err))
				{
					TtsLipSyncService.MainThreadQueue.Enqueue(delegate
					{
						InformationManager.DisplayMessage(new InformationMessage("[GM_POC] JSON parse: " + err, Colors.Yellow));
					});
					AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] OpenRouter raw (parse fail): " + raw);
					return;
				}
				Guid jobId = Guid.NewGuid();
				AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] job " + jobId + " from OpenRouter line: " + line);
				EnqueueExecuteLine(jobId, line);
			}
			catch (Exception ex2)
			{
				AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] OpenRouter task error: " + ex2.Message);
				TtsLipSyncService.MainThreadQueue.Enqueue(delegate
				{
					InformationManager.DisplayMessage(new InformationMessage("[GM_POC] OpenRouter: " + ex2.Message, Colors.Red));
				});
			}
		});
	}

	private static void ExecuteGmLine(Guid jobId, string line, GameMasterGmJobAuditInfo? audit = null)
	{
		AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] job " + jobId + " drain (executing)");
		if (Campaign.Current == null)
		{
			string msg = "observation skipped: Campaign.Current is null";
			AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] job " + jobId + " " + msg);
			GameMasterPocDiagnostics.Record(jobId.ToString(), line, msg);
			if (audit.HasValue)
			{
				GameMasterAuditLog.Append(audit.Value.CompletionPath, audit.Value.CorrelationId, jobId, line, audit.Value.PlanJson, "complete", msg);
				TryRecordGmObservation(audit, jobId, line, msg);
			}
			return;
		}
		AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] job " + jobId + " line: " + line);
		string[] array = line.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length == 0)
		{
			GameMasterPocDiagnostics.Record(jobId.ToString(), line, "(empty after split)");
			if (audit.HasValue)
			{
				GameMasterAuditLog.Append(audit.Value.CompletionPath, audit.Value.CorrelationId, jobId, line, audit.Value.PlanJson, "complete", "(empty after split)");
				TryRecordGmObservation(audit, jobId, line, "(empty after split)");
			}
			return;
		}
		string command = array[0].ToLowerInvariant();
		List<string> args = array.Skip(1).ToList();
		try
		{
			if (!CommandLineFunctionality.HasFunctionForCommand(command))
			{
				string msg2 = "command '" + command + "' not registered (Bannerlord.GameMaster not loaded?)";
				AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] job " + jobId + " observation: " + msg2);
				GameMasterPocDiagnostics.Record(jobId.ToString(), line, msg2);
				if (audit.HasValue)
				{
					GameMasterAuditLog.Append(audit.Value.CompletionPath, audit.Value.CorrelationId, jobId, line, audit.Value.PlanJson, "complete", msg2);
					TryRecordGmObservation(audit, jobId, line, msg2);
				}
				return;
			}
			string text = CommandLineFunctionality.CallFunction(command, args, out bool _);
			AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] job " + jobId + " observation (runtime): " + text);
			GameMasterPocDiagnostics.Record(jobId.ToString(), line, text);
			if (audit.HasValue)
			{
				GameMasterAuditLog.Append(audit.Value.CompletionPath, audit.Value.CorrelationId, jobId, line, audit.Value.PlanJson, "complete", text ?? "");
				TryRecordGmObservation(audit, jobId, line, text ?? "");
			}
		}
		catch (Exception ex)
		{
			string msg3 = "exception: " + ex.Message;
			AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] job " + jobId + " observation (exception): " + ex.Message);
			GameMasterPocDiagnostics.Record(jobId.ToString(), line, msg3);
			if (audit.HasValue)
			{
				GameMasterAuditLog.Append(audit.Value.CompletionPath, audit.Value.CorrelationId, jobId, line, audit.Value.PlanJson, "complete", msg3);
				TryRecordGmObservation(audit, jobId, line, msg3);
			}
		}
	}

	private static void TryRecordGmObservation(GameMasterGmJobAuditInfo? audit, Guid jobId, string line, string observation)
	{
		if (!audit.HasValue || string.IsNullOrEmpty(audit.Value.ObservationBucketKey))
		{
			return;
		}
		GameMasterObservationStore.Record(audit.Value.ObservationBucketKey, jobId, line, observation ?? "", audit.Value.StoryIntent);
	}
}
