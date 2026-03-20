using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

namespace AIInfluence;

/// <summary>
/// POC slice 1: thread-safe enqueue, single consumer in <see cref="AIInfluenceBehavior.Tick"/>.
/// No LLM — proves BLGM + <see cref="CommandLineFunctionality"/> + log-only observations.
/// </summary>
public static class GameMasterPocQueue
{
	public static readonly ConcurrentQueue<Action> Queue = new ConcurrentQueue<Action>();

	public static void EnqueueReadOnlyKingdomQueryProbe()
	{
		Queue.Enqueue(ExecuteReadOnlyKingdomQueryProbe);
	}

	private static void ExecuteReadOnlyKingdomQueryProbe()
	{
		if (Campaign.Current == null)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] observation skipped: Campaign.Current is null");
			return;
		}
		const string line = "gm.query.kingdom";
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
				AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] observation: command '" + command + "' not registered (Bannerlord.GameMaster not loaded?)");
				return;
			}
			string text = CommandLineFunctionality.CallFunction(command, args, out bool _);
			AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] observation (runtime): " + text);
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[GM_POC] observation (exception): " + ex.Message);
		}
	}
}
