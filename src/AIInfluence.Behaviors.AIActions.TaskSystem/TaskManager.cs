using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.ObjectSystem;
using TaleWorlds.SaveSystem;

namespace AIInfluence.Behaviors.AIActions.TaskSystem;

public class TaskManager : CampaignBehaviorBase
{
	private static TaskManager _instance;

	[SaveableField(1)]
	private Dictionary<string, HeroTask> _activeTasks;

	[SaveableField(2)]
	private Dictionary<string, List<HeroTask>> _completedTasks;

	public static TaskManager Instance
	{
		get
		{
			if (Campaign.Current != null)
			{
				TaskManager campaignBehavior = Campaign.Current.GetCampaignBehavior<TaskManager>();
				if (campaignBehavior != null)
				{
					_instance = campaignBehavior;
					return _instance;
				}
			}
			return _instance;
		}
	}

	public TaskManager()
	{
		_activeTasks = new Dictionary<string, HeroTask>();
		_completedTasks = new Dictionary<string, List<HeroTask>>();
	}

	public override void RegisterEvents()
	{
		CampaignEvents.HourlyTickEvent.AddNonSerializedListener((object)this, (Action)OnHourlyTick);
		CampaignEvents.DailyTickEvent.AddNonSerializedListener((object)this, (Action)OnDailyTick);
	}

	public override void SyncData(IDataStore dataStore)
	{
		dataStore.SyncData<Dictionary<string, HeroTask>>("_activeTasks", ref _activeTasks);
		dataStore.SyncData<Dictionary<string, List<HeroTask>>>("_completedTasks", ref _completedTasks);
		if (dataStore.IsLoading)
		{
			RestoreTasksAfterLoad();
		}
	}

	public HeroTask CreateTask(Hero hero, string description = null)
	{
		if (hero == null)
		{
			return null;
		}
		if (hero.PartyBelongedTo != null && hero.PartyBelongedTo.Army != null)
		{
			Army army = hero.PartyBelongedTo.Army;
			bool flag = army.LeaderParty == hero.PartyBelongedTo;
			if (!flag && hero.PartyBelongedTo.AttachedTo != null)
			{
				MobileParty leaderParty = army.LeaderParty;
				object obj;
				if (leaderParty == null)
				{
					obj = null;
				}
				else
				{
					Hero leaderHero = leaderParty.LeaderHero;
					obj = ((leaderHero == null) ? null : ((object)leaderHero.Name)?.ToString());
				}
				if (obj == null)
				{
					obj = "unknown";
				}
				string arg = (string)obj;
				AIInfluenceBehavior.Instance?.LogMessage($"[TaskManager] {hero.Name} is in army (leader: {arg}). Detaching to allow player task execution.");
				hero.PartyBelongedTo.AttachedTo = null;
			}
			else if (flag)
			{
				AIInfluenceBehavior.Instance?.LogMessage($"[TaskManager] {hero.Name} is army leader. Not detaching - will go with army.");
			}
		}
		CancelTask(hero);
		HeroTask heroTask = new HeroTask(((MBObjectBase)hero).StringId, description);
		_activeTasks[((MBObjectBase)hero).StringId] = heroTask;
		AIInfluenceBehavior.Instance?.LogMessage(string.Format("[TaskManager] Created task {0} for {1}: {2}", heroTask.TaskId, hero.Name, description ?? "No description"));
		return heroTask;
	}

	public HeroTask GetActiveTask(Hero hero)
	{
		if (hero == null)
		{
			return null;
		}
		if (_activeTasks.TryGetValue(((MBObjectBase)hero).StringId, out var value) && value.IsActive())
		{
			return value;
		}
		return null;
	}

	public bool CancelTask(Hero hero)
	{
		if (hero == null)
		{
			return false;
		}
		if (_activeTasks.TryGetValue(((MBObjectBase)hero).StringId, out var value))
		{
			value.Cancel();
			AIInfluenceBehavior.Instance?.LogMessage($"[TaskManager] Cancelled task {value.TaskId} for {hero.Name}");
			if (!_completedTasks.ContainsKey(((MBObjectBase)hero).StringId))
			{
				_completedTasks[((MBObjectBase)hero).StringId] = new List<HeroTask>();
			}
			_completedTasks[((MBObjectBase)hero).StringId].Add(value);
			_activeTasks.Remove(((MBObjectBase)hero).StringId);
			return true;
		}
		return false;
	}

	public void CompleteTask(Hero hero)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		if (hero != null && _activeTasks.TryGetValue(((MBObjectBase)hero).StringId, out var value))
		{
			value.Status = TaskStatus.Completed;
			value.CompletedTime = CampaignTime.Now;
			AIInfluenceBehavior.Instance?.LogMessage($"[TaskManager] Completed task {value.TaskId} for {hero.Name}");
			if (!_completedTasks.ContainsKey(((MBObjectBase)hero).StringId))
			{
				_completedTasks[((MBObjectBase)hero).StringId] = new List<HeroTask>();
			}
			_completedTasks[((MBObjectBase)hero).StringId].Add(value);
			_activeTasks.Remove(((MBObjectBase)hero).StringId);
		}
	}

	public bool MoveToNextStep(Hero hero)
	{
		HeroTask activeTask = GetActiveTask(hero);
		if (activeTask == null)
		{
			return false;
		}
		bool flag = activeTask.MoveToNextStep();
		if (!flag)
		{
			CompleteTask(hero);
		}
		else
		{
			AIInfluenceBehavior.Instance?.LogMessage($"[TaskManager] Moved to next step in task {activeTask.TaskId} for {hero.Name} (step {activeTask.CurrentStepIndex + 1}/{activeTask.Steps.Count})");
		}
		return flag;
	}

	private void OnHourlyTick()
	{
		List<HeroTask> list = new List<HeroTask>(_activeTasks.Values);
		foreach (HeroTask item in list)
		{
			if (!item.IsActive())
			{
				continue;
			}
			TaskStep currentStep = item.GetCurrentStep();
			if (currentStep != null && currentStep.StepType == TaskStepType.WaitInSettlement && currentStep.IsWaitCompleted())
			{
				Hero hero = item.GetHero();
				if (hero != null)
				{
					AIInfluenceBehavior.Instance?.LogMessage($"[TaskManager] Wait completed for {hero.Name} in step {item.CurrentStepIndex + 1}");
					MoveToNextStep(hero);
				}
			}
		}
	}

	private void OnDailyTick()
	{
	}

	public void RestoreTasksAfterLoad()
	{
		AIInfluenceBehavior.Instance?.LogMessage($"[TaskManager] Restoring {_activeTasks.Count} active tasks after save load");
		foreach (KeyValuePair<string, HeroTask> kvp in _activeTasks.ToList())
		{
			Hero val = ((IEnumerable<Hero>)Hero.AllAliveHeroes).FirstOrDefault((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == kvp.Key));
			if (val == null)
			{
				_activeTasks.Remove(kvp.Key);
				continue;
			}
			HeroTask value = kvp.Value;
			if (!value.IsActive())
			{
				_activeTasks.Remove(kvp.Key);
				continue;
			}
			TaskStep currentStep = value.GetCurrentStep();
			if (currentStep != null && (currentStep.StepType == TaskStepType.WaitInSettlement || currentStep.StepType == TaskStepType.WaitNearSettlement) && currentStep.Status == TaskStepStatus.InProgress && !currentStep.WaitUntilTime.HasValue)
			{
				currentStep.StartWaiting();
				AIInfluenceBehavior.Instance?.LogMessage($"[TaskManager] Restored wait step for {val.Name}, waiting {currentStep.WaitDays} days");
			}
		}
	}

	public static void ResetInstance()
	{
		_instance = null;
	}

	public static void SetInstance(TaskManager instance)
	{
		_instance = instance;
	}
}
