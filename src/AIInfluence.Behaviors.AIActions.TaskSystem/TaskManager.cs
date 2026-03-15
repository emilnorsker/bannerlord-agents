using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Behaviors.AIActions.TaskSystem;

public class TaskManager : CampaignBehaviorBase
{
	private sealed class TaskManagerSaveState
	{
		public Dictionary<string, HeroTaskState> ActiveTasks { get; set; } = new Dictionary<string, HeroTaskState>();

		public Dictionary<string, List<HeroTaskState>> CompletedTasks { get; set; } = new Dictionary<string, List<HeroTaskState>>();
	}

	private sealed class HeroTaskState
	{
		public string TaskId { get; set; }

		public string HeroId { get; set; }

		public TaskStatus Status { get; set; }

		public List<TaskStepState> Steps { get; set; } = new List<TaskStepState>();

		public int CurrentStepIndex { get; set; }

		public double CreatedTimeDays { get; set; }

		public double? CompletedTimeDays { get; set; }

		public string Description { get; set; }
	}

	private sealed class TaskStepState
	{
		public TaskStepType StepType { get; set; }

		public TaskStepStatus Status { get; set; }

		public string TargetSettlementId { get; set; }

		public string TargetPartyId { get; set; }

		public float WaitDays { get; set; }

		public double? WaitStartTimeDays { get; set; }

		public double? WaitUntilTimeDays { get; set; }

		public string CustomData { get; set; }

		public float PatrolDurationDays { get; set; }

		public bool PatrolAutoReturn { get; set; }

		public float WaitNearDurationDays { get; set; }

		public float WaitNearRadius { get; set; }

		public string Description { get; set; }
	}

	private static TaskManager _instance;

	private Dictionary<string, HeroTask> _activeTasks;

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
		string syncStage = "sync-start";
		try
		{
			AIInfluenceBehavior.Instance?.LogMessage($"[SYNC-TRACE] TaskManager.SyncData enter. isSaving={dataStore.IsSaving}, isLoading={dataStore.IsLoading}");
			_activeTasks ??= new Dictionary<string, HeroTask>();
			_completedTasks ??= new Dictionary<string, List<HeroTask>>();
			string serializedTaskState = null;
			if (dataStore.IsSaving)
			{
				syncStage = "save-serialize-task-state";
				serializedTaskState = SerializeTaskState();
			}
			syncStage = "sync-taskManagerStateJson";
			dataStore.SyncData<string>("AIInfluence_taskManagerStateJson", ref serializedTaskState);
			if (dataStore.IsLoading)
			{
				AIInfluenceBehavior.Instance?.LogMessage("[SYNC-TRACE] TaskManager.SyncData payloadLength=" + (serializedTaskState?.Length ?? 0));
				syncStage = "load-deserialize-task-state";
				if (!string.IsNullOrEmpty(serializedTaskState))
				{
					DeserializeTaskState(serializedTaskState);
				}
				else
				{
					_activeTasks = new Dictionary<string, HeroTask>();
					_completedTasks = new Dictionary<string, List<HeroTask>>();
				}
				syncStage = "load-restore-tasks";
				RestoreTasksAfterLoad();
			}
			AIInfluenceBehavior.Instance?.LogMessage("[SYNC-TRACE] TaskManager.SyncData exit success.");
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage("[ERROR] TaskManager.SyncData failed at stage=" + syncStage + ". activeCount=" + (_activeTasks?.Count ?? 0) + ", completedCount=" + (_completedTasks?.Count ?? 0) + ". " + ex);
			throw;
		}
	}

	private string SerializeTaskState()
	{
		TaskManagerSaveState taskManagerSaveState = new TaskManagerSaveState
		{
			ActiveTasks = _activeTasks.ToDictionary((KeyValuePair<string, HeroTask> kvp) => kvp.Key, (KeyValuePair<string, HeroTask> kvp) => ToHeroTaskState(kvp.Value)),
			CompletedTasks = _completedTasks.ToDictionary((KeyValuePair<string, List<HeroTask>> kvp) => kvp.Key, (KeyValuePair<string, List<HeroTask>> kvp) => (kvp.Value ?? new List<HeroTask>()).Select(ToHeroTaskState).ToList())
		};
		return JsonConvert.SerializeObject(taskManagerSaveState);
	}

	private void DeserializeTaskState(string serializedTaskState)
	{
		TaskManagerSaveState taskManagerSaveState = JsonConvert.DeserializeObject<TaskManagerSaveState>(serializedTaskState) ?? throw new InvalidOperationException("TaskManager state payload deserialized to null.");
		_activeTasks = (taskManagerSaveState.ActiveTasks ?? new Dictionary<string, HeroTaskState>()).Where((KeyValuePair<string, HeroTaskState> kvp) => kvp.Value != null).ToDictionary((KeyValuePair<string, HeroTaskState> kvp) => kvp.Key, (KeyValuePair<string, HeroTaskState> kvp) => FromHeroTaskState(kvp.Value));
		_completedTasks = (taskManagerSaveState.CompletedTasks ?? new Dictionary<string, List<HeroTaskState>>()).ToDictionary((KeyValuePair<string, List<HeroTaskState>> kvp) => kvp.Key, (KeyValuePair<string, List<HeroTaskState>> kvp) => (kvp.Value ?? new List<HeroTaskState>()).Where((HeroTaskState state) => state != null).Select(FromHeroTaskState).ToList());
	}

	private static HeroTaskState ToHeroTaskState(HeroTask task)
	{
		HeroTaskState heroTaskState = new HeroTaskState
		{
			TaskId = task?.TaskId,
			HeroId = task?.HeroId,
			Status = ((task != null) ? task.Status : TaskStatus.Active),
			CurrentStepIndex = ((task != null) ? task.CurrentStepIndex : 0),
			Description = task?.Description
		};
		if (task != null)
		{
			CampaignTime createdTime = task.CreatedTime;
			heroTaskState.CreatedTimeDays = (createdTime).ToDays;
			heroTaskState.CompletedTimeDays = task.CompletedTime.HasValue ? new double?((task.CompletedTime.Value).ToDays) : null;
			heroTaskState.Steps = (task.Steps ?? new List<TaskStep>()).Select(ToTaskStepState).ToList();
		}
		return heroTaskState;
	}

	private static HeroTask FromHeroTaskState(HeroTaskState state)
	{
		HeroTask heroTask = new HeroTask
		{
			TaskId = state.TaskId ?? Guid.NewGuid().ToString(),
			HeroId = state.HeroId,
			Status = state.Status,
			CurrentStepIndex = Math.Max(0, state.CurrentStepIndex),
			Description = state.Description,
			CreatedTime = CampaignTime.Days((float)state.CreatedTimeDays),
			CompletedTime = (state.CompletedTimeDays.HasValue ? new CampaignTime?(CampaignTime.Days((float)state.CompletedTimeDays.Value)) : null),
			Steps = (state.Steps ?? new List<TaskStepState>()).Where((TaskStepState stepState) => stepState != null).Select(FromTaskStepState).ToList()
		};
		if (heroTask.CurrentStepIndex > heroTask.Steps.Count)
		{
			// Steps.Count is a valid sentinel for completed tasks.
			heroTask.CurrentStepIndex = heroTask.Steps.Count;
		}
		return heroTask;
	}

	private static TaskStepState ToTaskStepState(TaskStep step)
	{
		if (step == null)
		{
			return new TaskStepState();
		}
		return new TaskStepState
		{
			StepType = step.StepType,
			Status = step.Status,
			TargetSettlementId = step.TargetSettlementId,
			TargetPartyId = step.TargetPartyId,
			WaitDays = step.WaitDays,
			WaitStartTimeDays = step.WaitStartTime.HasValue ? new double?((step.WaitStartTime.Value).ToDays) : null,
			WaitUntilTimeDays = step.WaitUntilTime.HasValue ? new double?((step.WaitUntilTime.Value).ToDays) : null,
			CustomData = step.CustomData,
			PatrolDurationDays = step.PatrolDurationDays,
			PatrolAutoReturn = step.PatrolAutoReturn,
			WaitNearDurationDays = step.WaitNearDurationDays,
			WaitNearRadius = step.WaitNearRadius,
			Description = step.Description
		};
	}

	private static TaskStep FromTaskStepState(TaskStepState state)
	{
		if (state == null)
		{
			return new TaskStep();
		}
		return new TaskStep
		{
			StepType = state.StepType,
			Status = state.Status,
			TargetSettlementId = state.TargetSettlementId,
			TargetPartyId = state.TargetPartyId,
			WaitDays = state.WaitDays,
			WaitStartTime = (state.WaitStartTimeDays.HasValue ? new CampaignTime?(CampaignTime.Days((float)state.WaitStartTimeDays.Value)) : null),
			WaitUntilTime = (state.WaitUntilTimeDays.HasValue ? new CampaignTime?(CampaignTime.Days((float)state.WaitUntilTimeDays.Value)) : null),
			CustomData = state.CustomData,
			PatrolDurationDays = state.PatrolDurationDays,
			PatrolAutoReturn = state.PatrolAutoReturn,
			WaitNearDurationDays = state.WaitNearDurationDays,
			WaitNearRadius = state.WaitNearRadius,
			Description = state.Description
		};
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
