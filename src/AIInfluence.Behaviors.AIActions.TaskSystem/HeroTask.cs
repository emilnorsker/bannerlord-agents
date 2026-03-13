using System;
using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Behaviors.AIActions.TaskSystem;

[Serializable]
public class HeroTask
{
	public string TaskId { get; set; }

	public string HeroId { get; set; }

	public TaskStatus Status { get; set; }

	public List<TaskStep> Steps { get; set; }

	public int CurrentStepIndex { get; set; }

	public CampaignTime CreatedTime { get; set; }

	public CampaignTime? CompletedTime { get; set; }

	public string Description { get; set; }

	public HeroTask()
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		Steps = new List<TaskStep>();
		CurrentStepIndex = 0;
		Status = TaskStatus.Active;
		CreatedTime = CampaignTime.Now;
		TaskId = Guid.NewGuid().ToString();
	}

	public HeroTask(string heroId, string description = null)
		: this()
	{
		HeroId = heroId;
		Description = description;
	}

	public TaskStep GetCurrentStep()
	{
		if (CurrentStepIndex >= 0 && CurrentStepIndex < Steps.Count)
		{
			return Steps[CurrentStepIndex];
		}
		return null;
	}

	public bool MoveToNextStep()
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		TaskStep currentStep = GetCurrentStep();
		if (currentStep != null)
		{
			currentStep.Status = TaskStepStatus.Completed;
		}
		CurrentStepIndex++;
		if (CurrentStepIndex >= Steps.Count)
		{
			Status = TaskStatus.Completed;
			CompletedTime = CampaignTime.Now;
			return false;
		}
		TaskStep currentStep2 = GetCurrentStep();
		if (currentStep2 != null)
		{
			currentStep2.Status = TaskStepStatus.InProgress;
		}
		return true;
	}

	public bool HasMoreSteps()
	{
		return CurrentStepIndex < Steps.Count;
	}

	public void Cancel()
	{
		Status = TaskStatus.Cancelled;
		TaskStep currentStep = GetCurrentStep();
		if (currentStep != null && currentStep.Status == TaskStepStatus.InProgress)
		{
			currentStep.Status = TaskStepStatus.Cancelled;
		}
	}

	public Hero GetHero()
	{
		if (string.IsNullOrEmpty(HeroId))
		{
			return null;
		}
		return ((IEnumerable<Hero>)Hero.AllAliveHeroes).FirstOrDefault((Func<Hero, bool>)((Hero h) => ((MBObjectBase)h).StringId == HeroId));
	}

	public bool IsActive()
	{
		return Status == TaskStatus.Active && HasMoreSteps();
	}

	public float GetProgress()
	{
		if (Steps.Count == 0)
		{
			return 1f;
		}
		int num = Steps.Count((TaskStep s) => s.Status == TaskStepStatus.Completed);
		return (float)num / (float)Steps.Count;
	}
}
