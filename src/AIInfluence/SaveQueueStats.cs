using System;

namespace AIInfluence;

public class SaveQueueStats
{
	public int QueueSize { get; set; }

	public int ProcessingCount { get; set; }

	public int ProcessedPerMinute { get; set; }

	public int ActiveTasks { get; set; }

	public int SkippedOldSaves { get; set; }

	public TimeSpan OldestQueueTime { get; set; }
}
