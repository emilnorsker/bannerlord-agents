using System;
using System.Collections.Generic;
using System.Linq;

namespace AIInfluence;

public class DelayedTaskManager
{
	private class DelayedTask
	{
		public DateTime TriggerTime { get; set; }

		public Action Action { get; set; }
	}

	private readonly List<DelayedTask> _tasks = new List<DelayedTask>();

	private readonly AIInfluenceBehavior _behavior;

	public DelayedTaskManager(AIInfluenceBehavior behavior)
	{
		_behavior = behavior;
	}

	public void AddTask(double delaySeconds, Action action)
	{
		if (delaySeconds < 0.0)
		{
			_behavior?.LogMessage($"[ERROR] DelayedTaskManager: Invalid negative delay ({delaySeconds}s). Task ignored.");
			return;
		}
		if (delaySeconds > 315537897600.0)
		{
			_behavior?.LogMessage($"[ERROR] DelayedTaskManager: Delay too large ({delaySeconds}s = {delaySeconds / 3600.0}h). Clamping to max.");
			delaySeconds = 315537897600.0;
		}
		DelayedTask item = new DelayedTask
		{
			TriggerTime = DateTime.Now.AddSeconds(delaySeconds),
			Action = action
		};
		_tasks.Add(item);
	}

	public void Tick(float dt)
	{
		DateTime currentTime = DateTime.Now;
		List<DelayedTask> list = _tasks.Where((DelayedTask t) => t.TriggerTime <= currentTime).ToList();
		foreach (DelayedTask item in list)
		{
			try
			{
				item.Action?.Invoke();
			}
			catch (Exception ex)
			{
				_behavior.LogMessage("[ERROR] Failed to execute delayed task: " + ex.Message);
			}
		}
		_tasks.RemoveAll((DelayedTask t) => t.TriggerTime <= currentTime);
	}
}
