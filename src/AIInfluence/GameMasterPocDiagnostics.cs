using System;

namespace AIInfluence;

/// <summary>
/// POC slice 8: last observation surfaced for MCM / in-game peek without opening mod_log.
/// </summary>
public static class GameMasterPocDiagnostics
{
	private static readonly object Lock = new object();

	public static string LastJobId { get; private set; } = "";

	public static string LastLine { get; private set; } = "";

	public static string LastObservation { get; private set; } = "";

	public static string LastUpdatedUtc { get; private set; } = "";

	public static void Record(string jobId, string line, string observation)
	{
		lock (Lock)
		{
			LastJobId = jobId ?? "";
			LastLine = line ?? "";
			LastObservation = observation ?? "";
			LastUpdatedUtc = DateTime.UtcNow.ToString("u");
		}
	}

	public static string FormatSummary()
	{
		lock (Lock)
		{
			if (string.IsNullOrEmpty(LastJobId) && string.IsNullOrEmpty(LastObservation))
			{
				return "[GM_POC] No observation recorded yet.";
			}
			return "[GM_POC] job " + LastJobId + "\nline: " + LastLine + "\nobservation:\n" + LastObservation + "\n(updated " + LastUpdatedUtc + " UTC)";
		}
	}
}
