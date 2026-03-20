using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

namespace AIInfluence;

/// <summary>
/// POC: thread-safe enqueue, single consumer in <see cref="AIInfluenceBehavior.Tick"/>.
/// Slice 2: each job has a <see cref="Guid"/>; all log lines for that job include it.
/// </summary>
public static class GameMasterPocQueue
{
	public static readonly ConcurrentQueue<Action> Queue = new ConcurrentQueue<Action>();

	public static Guid EnqueueReadOnlyKingdomQueryProbe()
	{
		Guid jobId = Guid.NewGuid();
		AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] job " + jobId + " enqueued (gm.query.kingdom)");
		Queue.Enqueue(delegate
		{
			ExecuteReadOnlyKingdomQueryProbe(jobId);
		});
		return jobId;
	}

	private static void ExecuteReadOnlyKingdomQueryProbe(Guid jobId)
	{
		AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] job " + jobId + " drain (executing)");
		if (Campaign.Current == null)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] job " + jobId + " observation skipped: Campaign.Current is null");
			return;
		}
		const string line = "gm.query.kingdom";
		AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] job " + jobId + " line: " + line);
		string[] array = line.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		if (array.Length == 0)
		{
			return;
		}
		string command = array[0].ToLowerInvariant();
		List<string> args = array.Skip(1).ToList();
		try
		{
			if (!CommandLineFunctionality.HasFunctionForCommand(command))
			{
				AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] job " + jobId + " observation: command '" + command + "' not registered (Bannerlord.GameMaster not loaded?)");
				return;
			}
			string text = CommandLineFunctionality.CallFunction(command, args, out bool _);
			AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] job " + jobId + " observation (runtime): " + text);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] job " + jobId + " observation (exception): " + ex.Message);
		}
	}
}
