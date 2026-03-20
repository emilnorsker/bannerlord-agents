using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using MCM.Abstractions.Base.Global;

namespace AIInfluence;

/// <summary>Slices 21 + 28: ring buffer of ground-truth GM observations per correlation bucket for next-prompt injection.</summary>
public static class GameMasterObservationStore
{
	private sealed class Entry
	{
		public Guid JobId;

		public string Line;

		public string Observation;

		public string StoryIntent;

		public DateTime Utc;
	}

	private static readonly ConcurrentDictionary<string, List<Entry>> Buckets = new ConcurrentDictionary<string, List<Entry>>();

	public static void Record(string observationBucketKey, Guid jobId, string line, string observation, string storyIntent)
	{
		if (string.IsNullOrEmpty(observationBucketKey) || GlobalSettings<ModSettings>.Instance == null || !GlobalSettings<ModSettings>.Instance.GameMasterObservationLoopEnabled)
		{
			return;
		}
		int cap = Math.Max(1, Math.Min(20, GlobalSettings<ModSettings>.Instance.GameMasterObservationMaxEntries));
		List<Entry> orAdd = Buckets.GetOrAdd(observationBucketKey, static _ => new List<Entry>());
		lock (orAdd)
		{
			orAdd.Add(new Entry
			{
				JobId = jobId,
				Line = line ?? "",
				Observation = observation ?? "",
				StoryIntent = storyIntent ?? "",
				Utc = DateTime.UtcNow
			});
			while (orAdd.Count > cap)
			{
				orAdd.RemoveAt(0);
			}
		}
	}

	public static string FormatInjectionBlock(string observationBucketKey)
	{
		if (string.IsNullOrEmpty(observationBucketKey) || GlobalSettings<ModSettings>.Instance == null || !GlobalSettings<ModSettings>.Instance.GameMasterObservationLoopEnabled || !GlobalSettings<ModSettings>.Instance.GameMasterObservationInjectIntoPrompt)
		{
			return "";
		}
		if (!Buckets.TryGetValue(observationBucketKey, out List<Entry> list) || list == null || list.Count == 0)
		{
			return "";
		}
		StringBuilder sb = new StringBuilder();
		sb.AppendLine();
		sb.AppendLine("### Last GM observations (runtime ground truth — do not invent results) ###");
		lock (list)
		{
			foreach (Entry e in list)
			{
				sb.Append("- job ").Append(e.JobId).Append(" @ ").Append(e.Utc.ToString("o")).AppendLine();
				if (!string.IsNullOrEmpty(e.StoryIntent))
				{
					sb.Append("  story_intent: ").Append(e.StoryIntent).AppendLine();
				}
				sb.Append("  line: ").Append(e.Line).AppendLine();
				sb.Append("  observation: ").Append(e.Observation).AppendLine();
			}
		}
		return sb.ToString();
	}

	public static void ClearAll()
	{
		Buckets.Clear();
	}
}
