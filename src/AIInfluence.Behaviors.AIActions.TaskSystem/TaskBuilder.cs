using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;

namespace AIInfluence.Behaviors.AIActions.TaskSystem;

public class TaskBuilder
{
	private Hero _hero;

	private List<TaskStep> _steps;

	private string _description;

	public TaskBuilder(Hero hero)
	{
		_hero = hero;
		_steps = new List<TaskStep>();
	}

	public TaskBuilder WithDescription(string description)
	{
		_description = description;
		return this;
	}

	public TaskBuilder GoToSettlement(Settlement settlement, string description = null)
	{
		_steps.Add(TaskStep.CreateGoToSettlement(settlement, description));
		return this;
	}

	public TaskBuilder WaitInSettlement(Settlement settlement, float waitDays, string description = null)
	{
		_steps.Add(TaskStep.CreateWaitInSettlement(settlement, waitDays, description));
		return this;
	}

	public TaskBuilder ReturnToPlayer(string description = null)
	{
		_steps.Add(TaskStep.CreateReturnToPlayer(description));
		return this;
	}

	public TaskBuilder FollowPlayer(string description = null)
	{
		_steps.Add(TaskStep.CreateFollowPlayer(description));
		return this;
	}

	public TaskBuilder AttackParty(string targetPartyStringId, string description = null)
	{
		_steps.Add(TaskStep.CreateAttackParty(targetPartyStringId, description));
		return this;
	}

	public TaskBuilder SiegeSettlement(Settlement settlement, string description = null)
	{
		_steps.Add(TaskStep.CreateSiegeSettlement(settlement, description));
		return this;
	}

	public TaskBuilder PatrolSettlement(Settlement settlement, float durationDays, bool autoReturn, string description = null)
	{
		_steps.Add(TaskStep.CreatePatrolSettlement(settlement, durationDays, autoReturn, description));
		return this;
	}

	public TaskBuilder WaitNearSettlement(Settlement settlement, float durationDays, float radius, string description = null)
	{
		_steps.Add(TaskStep.CreateWaitNearSettlement(settlement, durationDays, radius, description));
		return this;
	}

	public TaskBuilder RaidVillage(Settlement village, string description = null)
	{
		_steps.Add(TaskStep.CreateRaidVillage(village, description));
		return this;
	}

	public HeroTask Build()
	{
		if (_hero == null)
		{
			return null;
		}
		TaskManager instance = TaskManager.Instance;
		if (instance == null)
		{
			return null;
		}
		HeroTask heroTask = instance.CreateTask(_hero, _description);
		if (heroTask == null)
		{
			return null;
		}
		heroTask.Steps.AddRange(_steps);
		if (heroTask.Steps.Count > 0)
		{
			heroTask.Steps[0].Status = TaskStepStatus.InProgress;
			if (heroTask.Steps[0].StepType == TaskStepType.WaitInSettlement)
			{
				heroTask.Steps[0].StartWaiting();
			}
		}
		return heroTask;
	}

	public static HeroTask CreateGoToSettlementAndWait(Hero hero, Settlement settlement, float waitDays, string description = null)
	{
		return new TaskBuilder(hero).WithDescription(description ?? $"Go to {((settlement != null) ? settlement.Name : null)} and wait {waitDays} days").GoToSettlement(settlement).WaitInSettlement(settlement, waitDays)
			.Build();
	}

	public static HeroTask CreateGoToSettlementWaitThenGoToAnother(Hero hero, Settlement firstSettlement, float waitDays, Settlement secondSettlement, string description = null)
	{
		return new TaskBuilder(hero).WithDescription(description ?? $"Go to {((firstSettlement != null) ? firstSettlement.Name : null)}, wait {waitDays} days, then go to {((secondSettlement != null) ? secondSettlement.Name : null)}").GoToSettlement(firstSettlement).WaitInSettlement(firstSettlement, waitDays)
			.GoToSettlement(secondSettlement)
			.Build();
	}

	public static HeroTask CreateGoToSettlementWaitThenReturn(Hero hero, Settlement settlement, float waitDays, string description = null)
	{
		return new TaskBuilder(hero).WithDescription(description ?? $"Go to {((settlement != null) ? settlement.Name : null)}, wait {waitDays} days, then return to player").GoToSettlement(settlement).WaitInSettlement(settlement, waitDays)
			.ReturnToPlayer()
			.Build();
	}
}
