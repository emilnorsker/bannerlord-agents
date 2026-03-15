using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;

namespace AIInfluence;

public class SaveQueueManager
{
	private class SaveTask
	{
		public string NpcId { get; set; }

		public Hero Npc { get; set; }

		public NPCContext Context { get; set; }

		public DateTime QueueTime { get; set; }
	}

	private readonly Queue<SaveTask> _saveQueue = new Queue<SaveTask>();

	private readonly HashSet<string> _queuedNpcIds = new HashSet<string>();

	private readonly AIInfluenceBehavior _behavior;

	private DateTime _lastProcessTime = DateTime.Now;

	private readonly HashSet<string> _processingNpcs = new HashSet<string>();

	private const int SEMAPHORE_POOL_SIZE = 50;

	private readonly SemaphoreSlim[] _fileLockPool;

	private const double PROCESS_INTERVAL = 0.05;

	private const int MAX_QUEUE_SIZE = 150;

	private const int BATCH_SIZE_SMALL = 4;

	private const int BATCH_SIZE_LARGE = 8;

	private const int MAX_CONCURRENT_SAVES = 4;

	private const int MAX_STARTS_PER_TICK = 5;

	private readonly SemaphoreSlim _concurrentSaveLimiter;

	private int _processedCount = 0;

	private DateTime _lastStatsReset = DateTime.Now;

	private int _skippedOldSaves = 0;

	private int _activeTasks = 0;

	private const int MAX_ACTIVE_TASKS = 50;

	public SaveQueueManager(AIInfluenceBehavior behavior)
	{
		_behavior = behavior;
		_fileLockPool = new SemaphoreSlim[50];
		for (int i = 0; i < 50; i++)
		{
			_fileLockPool[i] = new SemaphoreSlim(1, 1);
		}
		_concurrentSaveLimiter = new SemaphoreSlim(4, 4);
	}

	private SemaphoreSlim GetFileLockFromPool(string npcId)
	{
		int num = Math.Abs(npcId.GetHashCode() % 50);
		return _fileLockPool[num];
	}

	public void QueueSave(string npcId, Hero npc, NPCContext context)
	{
		if (string.IsNullOrEmpty(npcId) || npc == null || context == null)
		{
			_behavior.LogMessage("[ERROR] [SAVE_QUEUE] QueueSave rejected invalid input. npcId=" + (npcId ?? "<null>") + ", npcNull=" + (npc == null) + ", contextNull=" + (context == null));
			return;
		}
		lock (_queuedNpcIds)
		{
			if (_processingNpcs.Contains(npcId) || _queuedNpcIds.Contains(npcId))
			{
				return;
			}
			if (_saveQueue.Count >= 150)
			{
				SaveTask saveTask = _saveQueue.Dequeue();
				_queuedNpcIds.Remove(saveTask.NpcId);
				_skippedOldSaves++;
				_behavior.LogMessage("[ERROR] [SAVE_QUEUE] Queue full (150). Dropping oldest pending save for npcId=" + saveTask.NpcId + ". droppedTotal=" + _skippedOldSaves + ", incomingNpcId=" + npcId);
			}
			_queuedNpcIds.Add(npcId);
			_saveQueue.Enqueue(new SaveTask
			{
				NpcId = npcId,
				Npc = npc,
				Context = context,
				QueueTime = DateTime.Now
			});
		}
	}

	private int GetCurrentBatchSize()
	{
		int count = _saveQueue.Count;
		if (count > 100)
		{
			return 8;
		}
		return 4;
	}

	public void Tick(float dt)
	{
		if (_saveQueue.Count != 0 && _activeTasks < 50)
		{
			DateTime now = DateTime.Now;
			double totalSeconds = (now - _lastProcessTime).TotalSeconds;
			if (totalSeconds >= 0.05)
			{
				_lastProcessTime = now;
				ProcessBatchSave();
			}
		}
	}

	private void ProcessBatchSave()
	{
		if (_saveQueue.Count == 0)
		{
			return;
		}
		int currentCount = _concurrentSaveLimiter.CurrentCount;
		if (currentCount <= 0)
		{
			return;
		}
		int currentBatchSize = GetCurrentBatchSize();
		currentBatchSize = Math.Min(currentBatchSize, currentCount);
		currentBatchSize = Math.Min(currentBatchSize, 5);
		List<Task> list = new List<Task>();
		lock (_queuedNpcIds)
		{
			int num = 0;
			while (_saveQueue.Count > 0 && num < currentBatchSize)
			{
				SaveTask saveTask = _saveQueue.Dequeue();
				_queuedNpcIds.Remove(saveTask.NpcId);
				_processingNpcs.Add(saveTask.NpcId);
				list.Add(ProcessSaveWithLimiterAsync(saveTask.NpcId, saveTask.Npc, saveTask.Context));
				num++;
			}
		}
		if (list.Count > 0)
		{
			Interlocked.Add(ref _activeTasks, list.Count);
			_ = ProcessTasksAsync(list);
		}
	}

	private async Task ProcessTasksAsync(List<Task> tasks)
	{
		try
		{
			await Task.WhenAll(tasks);
			_processedCount += tasks.Count;
		}
		catch (Exception ex)
		{
			_behavior.LogMessage("[ERROR] [SAVE_QUEUE] Batch processing failed: " + ex);
		}
		finally
		{
			Interlocked.Add(ref _activeTasks, -tasks.Count);
		}
	}

	private async Task ProcessSaveWithLimiterAsync(string npcId, Hero npc, NPCContext context)
	{
		try
		{
			if (!(await _concurrentSaveLimiter.WaitAsync(3000).ConfigureAwait(continueOnCapturedContext: false)))
			{
				_behavior.LogMessage("[ERROR] [SAVE_QUEUE] Timed out waiting for concurrency slot. npcId=" + npcId);
				return;
			}
			try
			{
				await ProcessSaveImmediateAsync(npcId, npc, context);
			}
			finally
			{
				_concurrentSaveLimiter.Release();
			}
		}
		catch (Exception ex)
		{
			_behavior.LogMessage("[ERROR] [SAVE_QUEUE] ProcessSaveWithLimiterAsync failed for npcId=" + npcId + ": " + ex);
		}
		finally
		{
			lock (_queuedNpcIds)
			{
				_processingNpcs.Remove(npcId);
			}
		}
	}

	private Task ProcessSaveImmediateAsync(string npcId, Hero npc, NPCContext context)
	{
		return Task.Run(async delegate
		{
			SemaphoreSlim fileLock = GetFileLockFromPool(npcId);
			try
			{
				if (!(await fileLock.WaitAsync(2000).ConfigureAwait(continueOnCapturedContext: false)))
				{
					_behavior.LogMessage("[ERROR] [SAVE_QUEUE] Timed out waiting file lock. npcId=" + npcId);
					return;
				}
				try
				{
					_behavior.SaveNPCContextImmediate(npcId, npc, context);
				}
				catch (IOException ex)
				{
					_behavior.LogMessage("[ERROR] [SAVE_QUEUE] IO save failure for npcId=" + npcId + ": " + ex);
				}
				catch (Exception ex2)
				{
					_behavior.LogMessage("[ERROR] [SAVE_QUEUE] Unexpected save failure for npcId=" + npcId + ": " + ex2);
				}
				finally
				{
					fileLock.Release();
				}
			}
			catch (Exception ex3)
			{
				_behavior.LogMessage("[ERROR] [SAVE_QUEUE] ProcessSaveImmediateAsync failed for npcId=" + npcId + ": " + ex3);
			}
		});
	}

	public void ProcessAllAsync()
	{
		if (_saveQueue.Count == 0)
		{
			return;
		}
		int num = Math.Min(_saveQueue.Count, 100);
		List<Task> list = new List<Task>();
		lock (_queuedNpcIds)
		{
			int num2 = 0;
			while (_saveQueue.Count > 0 && num2 < num)
			{
				SaveTask saveTask = _saveQueue.Dequeue();
				_queuedNpcIds.Remove(saveTask.NpcId);
				_processingNpcs.Add(saveTask.NpcId);
				list.Add(ProcessSaveWithLimiterAsync(saveTask.NpcId, saveTask.Npc, saveTask.Context));
				num2++;
			}
		}
		if (list.Count > 0)
		{
			Interlocked.Add(ref _activeTasks, list.Count);
			_ = ProcessTasksAsync(list);
		}
	}

	public void ClearQueue()
	{
		lock (_queuedNpcIds)
		{
			int count = _saveQueue.Count;
			_saveQueue.Clear();
			_queuedNpcIds.Clear();
			if (count > 0)
			{
				_behavior.LogMessage($"[SAVE_QUEUE] Cleared {count} pending saves");
			}
		}
	}

	public SaveQueueStats GetStats()
	{
		lock (_queuedNpcIds)
		{
			if ((DateTime.Now - _lastStatsReset).TotalMinutes >= 1.0)
			{
				_processedCount = 0;
				_skippedOldSaves = 0;
				_lastStatsReset = DateTime.Now;
			}
			return new SaveQueueStats
			{
				QueueSize = _saveQueue.Count,
				ProcessingCount = _processingNpcs.Count,
				ProcessedPerMinute = _processedCount,
				ActiveTasks = _activeTasks,
				SkippedOldSaves = _skippedOldSaves,
				OldestQueueTime = ((_saveQueue.Count > 0) ? (DateTime.Now - _saveQueue.Peek().QueueTime) : TimeSpan.Zero)
			};
		}
	}
}
