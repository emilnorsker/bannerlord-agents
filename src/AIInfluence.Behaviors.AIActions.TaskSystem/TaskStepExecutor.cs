using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.ObjectSystem;

namespace AIInfluence.Behaviors.AIActions.TaskSystem;

public static class TaskStepExecutor
{
	public static void ExecuteNextTaskStep(Hero hero, TaskStep nextStep)
	{
		if (hero == null || nextStep == null)
		{
			return;
		}
		try
		{
			switch (nextStep.StepType)
			{
			case TaskStepType.ReturnToPlayer:
				AIActionManager.Instance.StartAction(hero, "return_to_player");
				break;
			case TaskStepType.FollowPlayer:
				AIActionManager.Instance.StartAction(hero, "follow_player");
				break;
			case TaskStepType.AttackParty:
				if (!string.IsNullOrEmpty(nextStep.TargetPartyId))
				{
					AttackPartyAction.PrepareAttackTarget(hero, nextStep.TargetPartyId);
				}
				AIActionManager.Instance.StartAction(hero, "attack_party");
				break;
			case TaskStepType.GoToSettlement:
			case TaskStepType.WaitInSettlement:
			{
				Settlement targetSettlement = nextStep.GetTargetSettlement();
				if (targetSettlement != null)
				{
					GoToSettlementAction.PrepareDestination(hero, targetSettlement);
					AIActionManager.Instance.StartAction(hero, "go_to_settlement");
				}
				break;
			}
			case TaskStepType.PatrolSettlement:
			{
				Settlement targetSettlement2 = nextStep.GetTargetSettlement();
				if (targetSettlement2 != null)
				{
					float durationDays = ((nextStep.PatrolDurationDays > 0f) ? nextStep.PatrolDurationDays : 7f);
					bool patrolAutoReturn = nextStep.PatrolAutoReturn;
					PatrolSettlementAction.PreparePatrolRequest(hero, ((MBObjectBase)targetSettlement2).StringId, durationDays, patrolAutoReturn);
					AIActionManager.Instance.StartAction(hero, "patrol_settlement");
				}
				break;
			}
			case TaskStepType.WaitNearSettlement:
			{
				Settlement targetSettlement3 = nextStep.GetTargetSettlement();
				if (targetSettlement3 != null)
				{
					float waitDays = ((nextStep.WaitNearDurationDays > 0f) ? nextStep.WaitNearDurationDays : 2f);
					float desiredRadius = ((nextStep.WaitNearRadius > 0f) ? nextStep.WaitNearRadius : 10f);
					WaitNearSettlementAction.PrepareWaitRequest(hero, targetSettlement3, waitDays, desiredRadius);
					AIActionManager.Instance.StartAction(hero, "wait_near_settlement");
				}
				break;
			}
			case TaskStepType.SiegeSettlement:
				if (!string.IsNullOrEmpty(nextStep.TargetSettlementId))
				{
					SiegeSettlementAction.PrepareSiegeTarget(hero, nextStep.TargetSettlementId, autoReturn: false);
				}
				AIActionManager.Instance.StartAction(hero, "siege_settlement");
				break;
			case TaskStepType.RaidVillage:
				if (!string.IsNullOrEmpty(nextStep.TargetSettlementId))
				{
					RaidVillageAction.PrepareRaidTarget(hero, nextStep.TargetSettlementId);
				}
				AIActionManager.Instance.StartAction(hero, "raid_village");
				break;
			case TaskStepType.Custom:
				break;
			}
		}
		catch (Exception ex)
		{
			AIInfluenceBehavior.Instance?.LogMessage($"[TaskStepExecutor] ERROR executing next step for {((hero != null) ? hero.Name : null)}: {ex.Message}");
		}
	}
}
